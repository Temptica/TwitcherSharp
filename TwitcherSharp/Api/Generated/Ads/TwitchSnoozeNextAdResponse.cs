using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchSnoozeNextAdResponse : RefCounted, ITwitcherSharp<TwitchSnoozeNextAdResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSnoozeNextAdResponse object.
    /// </summary> 
    public static TwitchSnoozeNextAdResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchSnoozeNextAdResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_snooze_next_ad.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains information about the channel’s snoozes and next upcoming ad after successfully snoozing. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public int SnoozeCount { get; set; }
        public int SnoozeRefreshAt { get; set; }
        public int NextAdAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                SnoozeCount = data.Get("snooze_count").AsInt32(),
                SnoozeRefreshAt = data.Get("snooze_refresh_at").AsInt32(),
                NextAdAt = data.Get("next_ad_at").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("snooze_count", SnoozeCount);
            request.Set("snooze_refresh_at", SnoozeRefreshAt);
            request.Set("next_ad_at", NextAdAt);
            return request;
        }
    
    }

}
