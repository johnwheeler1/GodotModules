# Godot Modules
[![](https://img.shields.io/github/forks/GodotModules/GodotModules?label=forks&logo=github&style=flat-square&color=purple)](https://github.com/GodotModules/GodotModulesCSharp/fork)
[![](https://img.shields.io/static/v1?style=flat-square&logo=discord&logoColor=white&color=blue&label=discord&message=valks%20games)](https://discord.gg/866cg8yfxZ)


[Godot Modules](https://github.com/GodotModules/GodotModulesCSharp) is a collection of useful modules and scripts writing [Godot](https://godotengine.org/) games in C#.

## Notice
Development of Godot Modules has been put on hold because I am currently working on a new non-profit open source 2D platfomer called [Sankari](https://github.com/Valks-Games/sankari) licensed under the MIT license which makes use of all the Godot Module scripts and more. Development of Sankari has really helped fix a lot of issues in the Godot Module scripts. I will make the effort sometimes to merge the better code from Sankari into Godot Modules dev branch but as of right now Sankari is basically a better version of the Godot Modules project. If you want to help contribute to the Godot Modules project, I encourage you to check out Sankari and contribute there.

## Table of Contents

- [Godot Modules](#godot-modules)
  - [Table of Contents](#table-of-contents)
  - [Why make this?](#why-make-this)
  - [Modules](#modules)
    - [Core](#core)
    - [ModLoader](#modloader)
    - [Netcode](#netcode)
    - [Tech Tree](#tech-tree)
    - [Helper Scripts](#helper-scripts)
  - [Contributing](#contributing)
  - [Credit](#credit)
    - [Programming](#programming)
    - [Testers](#testers)

## Why make this?
I was thinking to myself, *I want to make a bullet hell game, but I am also going to be making more then just one game in the future*.

I do not want to redo the same things over again. If I want multiplayer, I can just grab it from here. If I want a modloader, I can find it here. If I want hotkeys, I can just get it from here. And so on.. That is the motivation behind this project!

> ⚠️ A lot of things showcased here are not on the main branch. Check out the main branch for a working multiplayer scenario and the dev branch for everything else. The main branch is where all the old code is at, dev branch is where all the latest and the greatest is at. Eventually the dev branch will be merged with the main branch.

![Menu](https://user-images.githubusercontent.com/6277739/176084227-c1f748bf-2cc0-4492-b132-b68f49ea1301.gif)  
Quick look at the menus  

![Cat with sword](https://user-images.githubusercontent.com/6277739/176084038-5483a55f-5698-4dc3-8a9c-0d08b7257d7c.gif)  
Attack animation  

![2DDungeon](https://user-images.githubusercontent.com/6277739/176084389-33209fb7-b793-47ba-827c-33aeff9a9381.gif)  
Dungeon environment  

![inv](https://user-images.githubusercontent.com/6277739/176084833-ea29cf7b-f7ef-46ec-8b56-5531ec735b7c.gif)  
Working on a inventory  

https://user-images.githubusercontent.com/6277739/176085117-7e61e96a-02ef-4f62-9aa0-c185abd94e90.mp4  

Attempting to make a FPS  

## Modules

### Core
There is an in-game console (shown by pressing F12) that supports custom commands, useful for in-game testing and debugging.

![image](https://user-images.githubusercontent.com/6277739/166569933-de699808-6de9-4f7f-ac90-1a8ae460e262.png)

There are also popup error and message windows. The bottom right corner of the screen shows a small red box which notifies you of any errors (along with the total error count every second).


### [ModLoader](https://github.com/valkyrienyanko/GodotModules/blob/main/.github/MOD_LOADER.md)

![image](https://user-images.githubusercontent.com/6277739/176084658-e5bbdf50-3569-484c-a3b1-3f123969b306.png)



### [Netcode](https://github.com/valkyrienyanko/GodotModules/blob/main/.github/NETCODE.md)

![image](https://user-images.githubusercontent.com/6277739/164528687-8ce3891f-2aa2-4c43-b9d2-404620aefad2.png)
![image](https://user-images.githubusercontent.com/6277739/176084492-d642fac2-569b-4f0e-a14e-a02a6e95bd38.png)
![image](https://user-images.githubusercontent.com/6277739/164519290-fcd96048-3267-4278-bbd9-34bd7c0a86c0.png)
![image](https://user-images.githubusercontent.com/6277739/164519339-a23cc3be-29dd-4df8-ad3b-e975508f5ec8.png)

https://user-images.githubusercontent.com/6277739/165597959-cb42938a-d680-45ec-99f0-d2ba4495a534.mp4

[Click here to see an attempt at trying to sync enemy physics with server and client](https://www.reddit.com/r/opensourcegames/comments/umbqn1/my_first_time_with_server_simulated_enemies_what/)


### Tech Tree
Tech tree where nodes in tree are positioned automatically via script

The code for this has not been merged to this repository yet and can be found [here](https://github.com/Raccoons-Rise-Up/client-godot/blob/main/Scripts/UI/UITechTreeResearch.cs)


### [Helper Scripts](https://github.com/valkyrienyanko/GodotModules/blob/main/.github/UTILITY_SCRIPTS.md)


## Contributing
See [CONTRIBUTING.md](https://github.com/valkyrienyanko/GodotModules/blob/main/.github/CONTRIBUTING.md)


## Credit
Thank you to the following wonderful people who helped make this project become something even greater!


### Programming
- irj [[GitHub]](https://github.com/irj)
- LazerGoat [[GitHub]](https://github.com/LazerGoat)
- Scorpieth [[GitHub]](https://github.com/Scorpieth)


### Testers
- SCUDSTORM [[Twitch]](https://www.twitch.tv/perezdispenser)
