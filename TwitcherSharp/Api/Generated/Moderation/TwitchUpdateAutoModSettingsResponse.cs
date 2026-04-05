using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateAutoModSettingsResponse : RefCounted, ITwitcherSharp<TwitchUpdateAutoModSettingsResponse>
{
    private GodotObject _data;
    public TwitchAutoModSettings[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateAutoModSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateAutoModSettingsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchUpdateAutoModSettingsResponse
        {
            Data = dataArray.Select(TwitchAutoModSettings.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_auto_mod_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
