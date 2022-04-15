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
    - [MoonSharp Debug](https://marketplace.visualstudio.com/items?itemName=xanathar.moonsharp-debug) (only if debugging lua)
3. Launch Godot through VSCode by hitting `F1` to open up VSCode command and run `godot tools: open workspace with godot editor` or simply click the `Open Godot Editor` button bottom right

## Debugging
1. Launch the VSCode configuration `Play in Editor` (if configuration is set to this already then just press `F5`)
2. While the debugger is running in the editor and if you want to debug Lua scripts as well launch the VSCode configuration `MoonSharp Attach`
3. Place a debug point anywhere in Lua or C# script to start debugging