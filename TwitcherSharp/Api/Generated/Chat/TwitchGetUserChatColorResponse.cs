using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetUserChatColorResponse : RefCounted, ITwitcherSharp<TwitchGetUserChatColorResponse>
{
    private GodotObject? _data;
    public TwitchUserChatColor[] Data { get => field ??= _data?.GetArray<TwitchUserChatColor>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserChatColorResponse object.
    /// </summary> 
    public static TwitchGetUserChatColorResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserChatColorResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_chat_color.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
