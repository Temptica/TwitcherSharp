using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchUpdateChatSettingsResponse : RefCounted, ITwitcherSharp<TwitchUpdateChatSettingsResponse>
{
    private GodotObject? _data;
    public TwitchChatSettingsUpdated[] Data { get => field ??= _data?.GetArray<TwitchChatSettingsUpdated>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChatSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateChatSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChatSettingsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_chat_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
