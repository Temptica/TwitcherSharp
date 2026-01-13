# TwitcherSharp
.Net wrapper for Godot Twitcher

### Still under development. Currently only has a wrapper for EventSub (listener) and TwitchCommands (listener)

## How to use?
There are two ways of listening to the events after creating the Twitcher Node. 

### 1)
Get the Node from the scene like var command = GetNode("DiscordTwitchCommandListener")
command.ConnectCommandReceived((string username, TwitchCommandInfo commandInfo, string[] args) => {//DoStuff}));

### 2)
*only works for commands currently*
You can get the node as a c# object and listen to the signal
var command = this.GetTwitchCommand("DiscordTwitchCommandListener")
command.CommandReceived += (string username, TwitchCommandInfo commandInfo, string[] args) => {//DoStuff};
