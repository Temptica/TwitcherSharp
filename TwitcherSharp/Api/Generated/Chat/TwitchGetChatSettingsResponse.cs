using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChatSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetChatSettingsResponse>
{
    private GodotObject? _data;
    public TwitchChatSettings[] Data { get => field ??= _data?.GetArray<TwitchChatSettings>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChatSettingsResponse object.
    /// </summary> 
    public static TwitchGetChatSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChatSettingsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chat_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
