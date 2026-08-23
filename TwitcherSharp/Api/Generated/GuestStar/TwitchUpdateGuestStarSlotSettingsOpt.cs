using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;


/// <summary> 
/// All optional parameters for TwitchAPI.UpdateGuestStarSlotSettings 
/// </summary>
public partial class TwitchUpdateGuestStarSlotSettingsOpt : RefCounted, ITwitcherSharp<TwitchUpdateGuestStarSlotSettingsOpt>
{
    private GodotObject? _data;
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
            IsAudioEnabled = data.Get("is_audio_enabled").AsBool(),
            IsVideoEnabled = data.Get("is_video_enabled").AsBool(),
            IsLive = data.Get("is_live").AsBool(),
            Volume = data.Get("volume").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_guest_star_slot_settings.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(IsAudioEnabled.HasValue) request.Set("is_audio_enabled", IsAudioEnabled.Value);
        if(IsVideoEnabled.HasValue) request.Set("is_video_enabled", IsVideoEnabled.Value);
        if(IsLive.HasValue) request.Set("is_live", IsLive.Value);
        if(Volume.HasValue) request.Set("volume", Volume.Value);
        return request;
    }

}
