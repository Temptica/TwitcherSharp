using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateShieldModeStatusBody : RefCounted, ITwitcherSharp<TwitchUpdateShieldModeStatusBody>
{
    private Variant _data;
    public bool IsActive { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateShieldModeStatusBody object.
    /// </summary> 
    public static TwitchUpdateShieldModeStatusBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateShieldModeStatusBody
        {
            IsActive = data.Read("is_active", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd", "Body");
        request.SetValue("is_active", IsActive);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
