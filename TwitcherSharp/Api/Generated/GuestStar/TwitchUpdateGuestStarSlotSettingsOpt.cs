using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;


/// <summary> 
/// All optional parameters for TwitchAPI.UpdateGuestStarSlotSettings 
/// </summary>
public partial class TwitchUpdateGuestStarSlotSettingsOpt : RefCounted, ITwitcherSharp<TwitchUpdateGuestStarSlotSettingsOpt>
{
    private Variant _data;
    public bool? IsAudioEnabled { get; set; }
    public bool? IsVideoEnabled { get; set; }
    public bool? IsLive { get; set; }
    public int? Volume { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateGuestStarSlotSettingsOpt object.
    /// </summary> 
    public static TwitchUpdateGuestStarSlotSettingsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateGuestStarSlotSettingsOpt
        {
            IsAudioEnabled = data.Read("is_audio_enabled", static v => v.AsBool()),
            IsVideoEnabled = data.Read("is_video_enabled", static v => v.AsBool()),
            IsLive = data.Read("is_live", static v => v.AsBool()),
            Volume = data.Read("volume", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_guest_star_slot_settings.gd", "Opt");
        if(IsAudioEnabled.HasValue) request.SetValue("is_audio_enabled", IsAudioEnabled.Value);
        if(IsVideoEnabled.HasValue) request.SetValue("is_video_enabled", IsVideoEnabled.Value);
        if(IsLive.HasValue) request.SetValue("is_live", IsLive.Value);
        if(Volume.HasValue) request.SetValue("volume", Volume.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
