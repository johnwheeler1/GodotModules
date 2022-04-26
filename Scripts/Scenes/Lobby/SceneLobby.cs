using Timer = System.Threading.Timer;

using Godot;
using GodotModules.Netcode;
using GodotModules.Netcode.Client;
using GodotModules.Netcode.Server;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GodotModules
{
    public class SceneLobby : Node
    {
        public static LobbyListing CurrentLobby { get; set; }
        private static SceneLobby Instance { get; set; }
        
        [Export] public readonly NodePath NodePathPlayers;
        [Export] public readonly NodePath NodePathChatText;
        [Export] public readonly NodePath NodePathChatInput;
        [Export] public readonly NodePath NodePathLobbyName;
        [Export] public readonly NodePath NodePathLobbyMaxPlayers;
        [Export] public readonly NodePath NodePathBtnReady;
        [Export] public readonly NodePath NodePathBtnStart;

        private Control ListPlayers { get; set; }
        private static RichTextLabel ChatText { get; set; }
        private LineEdit ChatInput { get; set; }
        private Label LobbyName { get; set; }
        private Label LobbyMaxPlayers { get; set; }
        private Button BtnReady { get; set; }
        private Button BtnStart { get; set; }

        public bool Start { get; set; }

        private System.Threading.Timer TimerCountdownGameStart { get; set; }
        private int CountdownGameStart = 2;

        private Dictionary<uint, UILobbyPlayerListing> UIPlayers { get; set; }

        public override void _Ready()
        {
            Instance = this;
            ListPlayers = GetNode<Control>(NodePathPlayers);
            ChatText = GetNode<RichTextLabel>(NodePathChatText);
            ChatInput = GetNode<LineEdit>(NodePathChatInput);
            LobbyName = GetNode<Label>(NodePathLobbyName);
            LobbyMaxPlayers = GetNode<Label>(NodePathLobbyMaxPlayers);
            BtnReady = GetNode<Button>(NodePathBtnReady);
            BtnStart = GetNode<Button>(NodePathBtnStart);

            UIPlayers = new Dictionary<uint, UILobbyPlayerListing>();

            //var info = UIGameServers.Instance.CurrentLobby;
            //LobbyName.Text = info.Name;
            //LobbyMaxPlayers.Text = "" + info.MaxPlayerCount;

            if (!ENetClient.IsHost)
                Instance.BtnStart.Disabled = true;

            foreach (var player in GameClient.Players)
                UIAddPlayer(player.Key, player.Value);
        }

        public override void _Input(InputEvent @event)
        {
            Utils.EscapeToScene("GameServers", async () => {
                NetworkManager.WebClient.Client.CancelPendingRequests();
                NetworkManager.WebClient.TimerPingMasterServer.Stop();
                await GameClient.Stop();
                if (ENetServer.Running)
                    await GameServer.Stop();
            });
        }

        public static Dictionary<uint, UILobbyPlayerListing> GetPlayers()
        {
            if (SceneManager.ActiveScene != "Lobby")
                return null;

            return Instance.UIPlayers;
        }

        public static void AddPlayer(uint id, string name) 
        {
            if (GameClient.Players.ContainsKey(id))
            {
                GD.Print($"Players contains id: '{id}' already");
                GD.Print(GameClient.Players.Print());
                return;
            }

            GameClient.Players.Add(id, name);

            if (SceneManager.ActiveScene == "Lobby")
                Instance.UIAddPlayer(id, name);
        }

        public static void RemovePlayer(uint id)
        {
            GameClient.Players.Remove(id);

            if (SceneManager.ActiveScene == "Lobby")
            {
                var uiPlayer = Instance.UIPlayers[id];
                uiPlayer.QueueFree();
                Instance.UIPlayers.Remove(id);
            }
        }

        public void UIAddPlayer(uint id, string name)
        {
            var player = Prefabs.LobbyPlayerListing.Instance<UILobbyPlayerListing>();
            UIPlayers.Add(id, player);
            
            ListPlayers.AddChild(player);

            player.SetUsername(name);
            player.SetReady(false);
        }

        private async void _on_Ready_pressed()
        {
            var player = UIPlayers[ENetClient.PeerId];
            player.SetReady(!player.Ready);

            BtnReady.Text = player.Ready ? "Ready" : "Not Ready";

            await ENetClient.Send(ClientPacketOpcode.LobbyReady, new CPacketLobbyReady {
                Ready = player.Ready
            });
        }

        public static void SetReady(uint id, bool ready)
        {
            if (SceneManager.ActiveScene == "Lobby") 
            {
                var player = Instance.UIPlayers[id];
                player.SetReady(ready);
            }
        }

        public static void CancelGameCountdown()
        {
            if (SceneManager.ActiveScene == "Lobby")
            {
                Instance.TimerCountdownGameStart.Dispose();
                Instance.CountdownGameStart = 5;
                Instance.BtnReady.Disabled = false;
                Log("Game start was cancelled");
            }
        }

        public static void StartGameCountdown()
        {
            if (SceneManager.ActiveScene == "Lobby")
            {
                Instance.TimerCountdownGameStart = new Timer(Instance.TimerCountdownCallback, "state", 0, 1000);
                Instance.BtnReady.Disabled = true;
            }
        }

        private async void _on_Start_pressed()
        {
            if (!ENetClient.IsHost)
                return;

            // check if all players are ready
            var playersNotReady = new List<string>();
            foreach (var pair in UIPlayers)
                if (!pair.Value.Ready)
                    playersNotReady.Add(pair.Value.Username);

            if (playersNotReady.Count > 0)
            {
                var isAre = playersNotReady.Count == 1 ? "is" : "are";
                Log($"Cannot start because {string.Join(" ", playersNotReady.ToArray())} {isAre} not ready");
                return;
            }

            Start = !Start;
            BtnStart.Text = Start ? "Cancel" : "Start";

            if (Start)
            {
                await ENetClient.Send(ClientPacketOpcode.LobbyCountdownChange, new CPacketLobbyCountdownChange{ CountdownRunning = true });
                StartGameCountdown();
            }
            else
            {
                await ENetClient.Send(ClientPacketOpcode.LobbyCountdownChange, new CPacketLobbyCountdownChange{ CountdownRunning = false });
                CancelGameCountdown();
            }
        }

        private async void TimerCountdownCallback(object state)
        {
            Log($"Game starting in {CountdownGameStart--}");

            if (CountdownGameStart == 0)
            {
                TimerCountdownGameStart.Dispose();

                if (ENetClient.IsHost)
                {
                    // tell everyone game has started
                    await GameClient.Send(ClientPacketOpcode.LobbyGameStart);
                }
            }
        }

        public static void Log(string text) 
        {
            ChatText.AddText($"{text}\n");
            ChatText.ScrollToLine(ChatText.GetLineCount() - 1);
        }

        public static void Log(uint peerId, string text) 
        {
            if (SceneManager.ActiveScene != "Lobby")
                return;

            var playerName = GameClient.Players[peerId];
            Log($"{playerName}: {text}");
        }

        private async void _on_Chat_Input_text_entered(string text)
        {
            ChatInput.Clear();
            if (!string.IsNullOrWhiteSpace(text))
            {
                await GameClient.Send(ClientPacketOpcode.LobbyChatMessage, new CPacketLobbyChatMessage {
                    Message = text.Trim()
                });
            }
        }
    }
}