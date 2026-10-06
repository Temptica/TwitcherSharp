using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateAutoModSettingsResponse : RefCounted, ITwitcherSharp<TwitchUpdateAutoModSettingsResponse>
{
    private Variant _data;
    public TwitchAutoModSettings[] Data { get => field ??= _data.GetArray<TwitchAutoModSettings>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateAutoModSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateAutoModSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateAutoModSettingsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_auto_mod_settings.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
