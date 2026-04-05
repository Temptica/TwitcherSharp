using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchGetAdScheduleResponse : RefCounted, ITwitcherSharp<TwitchGetAdScheduleResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAdScheduleResponse object.
    /// </summary> 
    public static TwitchGetAdScheduleResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetAdScheduleResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_ad_schedule.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }
    
    /// <summary> 
    /// A list that contains information related to the channel’s ad schedule. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public int SnoozeCount { get; set; }
        public float SnoozeRefreshAt { get; set; }
        public float NextAdAt { get; set; }
        public int Duration { get; set; }
        public float LastAdAt { get; set; }
        public int PrerollFreeTime { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                SnoozeCount = data.Get("snooze_count").AsInt32(),
                SnoozeRefreshAt = data.Get("snooze_refresh_at").As<float>(),
                NextAdAt = data.Get("next_ad_at").As<float>(),
                Duration = data.Get("duration").AsInt32(),
                LastAdAt = data.Get("last_ad_at").As<float>(),
                PrerollFreeTime = data.Get("preroll_free_time").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
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
