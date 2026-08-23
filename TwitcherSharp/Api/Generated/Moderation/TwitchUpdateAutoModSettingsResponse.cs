using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateAutoModSettingsResponse : RefCounted, ITwitcherSharp<TwitchUpdateAutoModSettingsResponse>
{
    private GodotObject? _data;
    public TwitchAutoModSettings[] Data { get => field ??= _data?.GetArray<TwitchAutoModSettings>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateAutoModSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateAutoModSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateAutoModSettingsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_auto_mod_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
