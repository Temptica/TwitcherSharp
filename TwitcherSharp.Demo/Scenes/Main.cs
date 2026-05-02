using Godot;
using System;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelChatMessage;

namespace TwitcherSharp.Demo.Scenes;

public partial class Main : Node3D
{
    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        await TwitchService.Instance.Setup();
        GD.Print("test");
        var user = await TwitchService.Instance.GetCurrentUser();
        var test = TwitchService.Instance.SubscribeEvent(TwitchEventSubDefinition.ChannelChatMessage,
            new TwitchChannelChatMessageCondition()
            {
                BroadcasterUserId = user.Id,
                UserId = user.Id,
            });
        GD.Print("test2");
        GD.Print(test);
    }
}