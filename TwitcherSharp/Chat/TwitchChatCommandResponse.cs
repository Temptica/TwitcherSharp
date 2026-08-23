using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchChatCommandResponse: RefCounted, ITwitcherSharp<TwitchChatCommandResponse>
{
    public string? ResponseMessage { get; set; }
    public bool UseBot { get; set; } = true;
    public static TwitchChatCommandResponse? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var response = new TwitchChatCommandResponse();
        response.ResponseMessage = data.Get("respond_message").AsString();
        response.UseBot = data.Get("use_bot").AsBool();
        return response;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_command_respond.gd");
        var instance = script.New().AsGodotObject();
        if (ResponseMessage != null) instance.Set("respond_message", ResponseMessage);
        instance.Set("use_bot", UseBot);
        return instance;
    }
}