using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetAutoModSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetAutoModSettingsResponse>
{
    private GodotObject? _data;
    public TwitchAutoModSettings[]? Data { get => field ??= _data?.GetArray<TwitchAutoModSettings>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAutoModSettingsResponse object.
    /// </summary> 
    public static TwitchGetAutoModSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAutoModSettingsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_auto_mod_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
