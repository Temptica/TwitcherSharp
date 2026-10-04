using Godot;
using TwitcherSharp.Extensions;
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
        response.ResponseMessage = data.Read("respond_message", static v => v.AsString());
        response.UseBot = data.Read("use_bot", static v => v.AsBool());
        return response;
    }

    public GodotObject ToGodotObject()
    {
        var instance = InteropExtension.NewObject("res://addons/twitcher/chat/twitch_chat_command_respond.gd");
        if (ResponseMessage != null) instance.SetValue("respond_message", ResponseMessage);
        instance.SetValue("use_bot", UseBot);
        return instance;
    }
}