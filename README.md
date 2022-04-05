# GodotLuaModdingTest
This project was created to better understand MoonSharp (Lua) for implementing modding into a game.

Learn Lua: https://www.lua.org/pil/contents.html  
Learn MoonSharp: https://www.moonsharp.org/getting_started.html  

## Todo
- [x] Figure out how to do something like `player:setHealth(x)` from Lua
- [x] Figure out how to add something like Godots `_process(float delta)` in Lua so modders can call a function every frame if so desired
- [x] Do not add mod if lua scripts did not compile and give some kind of feedback in console about this
- [x] Do not add mod if info.json does not exist
- [x] Figure out how to use Lua debugger
- [ ] Add a game menu and list all mods / add stuff to manage / reload mods

## Setup
### Godot Mono (C#)
1. Install [Godot Mono 64 Bit](https://godotengine.org)
2. Install [.NET SDK from this link](https://dotnet.microsoft.com/en-us/download)
3. Install [.NET Framework 4.7.2](https://duckduckgo.com/?q=.net+framework+4.7.2)
4. Launch Godot through [VSCode](#vscode)
5. In Godot Editor > Editor Settings > Mono > Builds > Make sure `Build Tool` is set to `dotnet CLI`

If the startup scene is the main menu, the [game server](https://github.com/Raccoons-Rise-Up/server/blob/main/.github/CONTRIBUTING.md#setup) and [web server](https://github.com/Raccoons-Rise-Up/website/blob/main/.github/CONTRIBUTING.md) will need to be running to get past the login screen to the main game scene, otherwise you can change the startup scene to the main game scene by going to `Godot > Project Settings > Application > Run > Main Scene`.

### VSCode
VSCode is a UI friendly text editor for developers
1. Install [VSCode](https://code.visualstudio.com)
2. Install the following extensions for VSCode
    - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
    - [C# Tools for Godot](https://marketplace.visualstudio.com/items?itemName=neikeq.godot-csharp-vscode)
    - [godot-tools](https://marketplace.visualstudio.com/items?itemName=geequlim.godot-tools)
    - [Mono Debug](https://marketplace.visualstudio.com/items?itemName=ms-vscode.mono-debug)
3. Launch Godot through VSCode by hitting `F1` to open up VSCode command and run `godot tools: open workspace with godot editor` or simply click the `Open Godot Editor` button bottom right

### Lua
For non-exported; Mods folder is created in project folder. For exported; Mods folder is created next to game executable.

Create the following inside Mods folder.
```
|-Mods
|--ModTest
|---info.json
|---script.lua
```

info.json
```json
{
    "name": "ModTest",
    "version": "0.0.1",
    "author": "valkyrienyanko"
}
```

script.lua
```lua
Player = Player:new{id = 1}
Player.health = Player.health - 10
```

Notice how player health is set to 90 on game start.

### Debugging
1. In `VSCode`, go to `Run and Debug` tab > `Create a launch.json file` > `C# Godot`
2. Add the following to configurations in `launch.json`
```json
{
    "name": "MoonSharp Attach",
    "type": "moonsharp-debug",
    "request": "attach",
    "debugServer": 41912
}
```
3. Launch the configuration `Play in Editor` (if configuration is set to this already then just press `F5`)
4. Launch the configuration `MoonSharp Attach`
5. Place a debug point anywhere in Lua or C# script to start debugging
