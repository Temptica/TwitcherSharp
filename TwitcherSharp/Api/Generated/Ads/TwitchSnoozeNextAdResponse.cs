using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchSnoozeNextAdResponse : RefCounted, ITwitcherSharp<TwitchSnoozeNextAdResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSnoozeNextAdResponse object.
    /// </summary> 
    public static TwitchSnoozeNextAdResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSnoozeNextAdResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_snooze_next_ad.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list that contains information about the channel’s snoozes and next upcoming ad after successfully snoozing. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public int SnoozeCount { get; set; }
        public int SnoozeRefreshAt { get; set; }
        public int NextAdAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                SnoozeCount = data.Read("snooze_count", static v => v.AsInt32()),
                SnoozeRefreshAt = data.Read("snooze_refresh_at", static v => v.AsInt32()),
                NextAdAt = data.Read("next_ad_at", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_snooze_next_ad.gd", "ResponseData");
            request.SetValue("snooze_count", SnoozeCount);
            request.SetValue("snooze_refresh_at", SnoozeRefreshAt);
            request.SetValue("next_ad_at", NextAdAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
