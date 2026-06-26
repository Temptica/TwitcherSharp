using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchGetAdScheduleResponse : RefCounted, ITwitcherSharp<TwitchGetAdScheduleResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAdScheduleResponse object.
    /// </summary> 
    public static TwitchGetAdScheduleResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAdScheduleResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_ad_schedule.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains information related to the channel’s ad schedule. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public int SnoozeCount { get; set; }
        public float SnoozeRefreshAt { get; set; }
        public float NextAdAt { get; set; }
        public int Duration { get; set; }
        public float LastAdAt { get; set; }
        public int PrerollFreeTime { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                SnoozeCount = data.Get("snooze_count").AsInt32(),
                SnoozeRefreshAt = data.Get("snooze_refresh_at").As<float>(),
                NextAdAt = data.Get("next_ad_at").As<float>(),
                Duration = data.Get("duration").AsInt32(),
                LastAdAt = data.Get("last_ad_at").As<float>(),
                PrerollFreeTime = data.Get("preroll_free_time").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_ad_schedule.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("snooze_count", SnoozeCount);
            request.Set("snooze_refresh_at", SnoozeRefreshAt);
            request.Set("next_ad_at", NextAdAt);
            request.Set("duration", Duration);
            request.Set("last_ad_at", LastAdAt);
            request.Set("preroll_free_time", PrerollFreeTime);
            return request;
        }
    
    }

}
