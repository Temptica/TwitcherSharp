using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChannelChatBadgesResponse : RefCounted, ITwitcherSharp<TwitchGetChannelChatBadgesResponse>
{
    private GodotObject? _data;
    public TwitchChatBadge[] Data { get => field ??= _data?.GetArray<TwitchChatBadge>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelChatBadgesResponse object.
    /// </summary> 
    public static TwitchGetChannelChatBadgesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelChatBadgesResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_chat_badges.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
