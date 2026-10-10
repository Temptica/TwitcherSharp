using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchGetAdScheduleResponse : RefCounted, ITwitcherSharp<TwitchGetAdScheduleResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAdScheduleResponse object.
    /// </summary> 
    public static TwitchGetAdScheduleResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAdScheduleResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_ad_schedule.gd", "Response");
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
    /// A list that contains information related to the channel’s ad schedule. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public int SnoozeCount { get; set; }
        public long SnoozeRefreshAt { get; set; }
        public long NextAdAt { get; set; }
        public int Duration { get; set; }
        public long LastAdAt { get; set; }
        public int PrerollFreeTime { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                SnoozeCount = data.ReadAsInt32("snooze_count"),
                SnoozeRefreshAt = data.ReadAsInt64("snooze_refresh_at"),
                NextAdAt = data.ReadAsInt64("next_ad_at"),
                Duration = data.ReadAsInt32("duration"),
                LastAdAt = data.ReadAsInt64("last_ad_at"),
                PrerollFreeTime = data.ReadAsInt32("preroll_free_time"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_ad_schedule.gd", "ResponseData");
            request.SetValue("snooze_count", SnoozeCount);
            request.SetValue("snooze_refresh_at", SnoozeRefreshAt);
            request.SetValue("next_ad_at", NextAdAt);
            request.SetValue("duration", Duration);
            request.SetValue("last_ad_at", LastAdAt);
            request.SetValue("preroll_free_time", PrerollFreeTime);
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
