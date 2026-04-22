# TwitcherSharp
.Net wrapper for Godot Twitcher

### Still under development. 
About 90% of the mapping is done. Though the tool requires more testing. Feel free to try it out and report any issues.

## What is it?
TwitcherSharp is a .Net wrapper for the Godot Twitcher addon made by kanimaru. It's purpose is to make it easier to use Twitcher within C# projects. It is not meant to replace twitcher but instead allows you to use both gdScript and C# in the same project.

## How to install?
Download the package from [Nuget](https://www.nuget.org/packages/Temptica.TwitcherSharp). Make sure to take the same version as your twitcher version.
If you don't have Twitcher installed, download it from the godot market place or from [Github](https://github.com/kanimaru/twitcher) directly

**Make sure that twitcher is located under res://addons/twitcher/**. This should be the default location.

## How to use?
The prefered way is to make the Twitcher nodes in the scene like you would normally do. Though the nodes can also be added at run-time.

Your first step will always be the same. Please check out the Twitcher [Getting Started](https://twitcher.kani.dev/introduction/getting-started.html) page for his.

Once you have twitcher installed and the editor set up, you'll need to set up the TwitcherService node in godot. This can be done in 2 ways:
1. You can manually add the TwicherService node into your scene at a specific location.
2. You let TwitcherSharp automatically add it to the root of the scene.

Thereafter you have to add a script to your scene. This script is meant for initialization and should thus be the parent node or a node that gets called later than the other twitch nodes.

In this script, you have to call ```await TwitchService.GetOrCreateInstance().Setup();```

```GetOrCreateInstance()``` is a method that exists on singleton Twitcher classes. It will return the existing instance. If there isn't any, it will instead look if an instance exists in gdScript. If neither exists, it will then create the gdscript TwitcherService node, add it to the scene root and return a c# TwitcherSharp instance, which is connected to the gdScript instance.
Removing the gdScript node will also free the c# instance.

## Best practices
### Getting and binding nodes
All TwitcherSharp classes implement RefCounted. This allows you to bind the TwitcherSharp class to a Node's MetaData. This can be done easily using ```
