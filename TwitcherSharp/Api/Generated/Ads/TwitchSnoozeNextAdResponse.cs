using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchSnoozeNextAdResponse : RefCounted, ITwitcherSharp<TwitchSnoozeNextAdResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSnoozeNextAdResponse object.
    /// </summary> 
    public static TwitchSnoozeNextAdResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchSnoozeNextAdResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_snooze_next_ad.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }
    
    /// <summary> 
    /// A list that contains information about the channel’s snoozes and next upcoming ad after successfully snoozing. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public int SnoozeCount { get; set; }
        public int SnoozeRefreshAt { get; set; }
        public int NextAdAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                SnoozeCount = data.Get("snooze_count").AsInt32(),
                SnoozeRefreshAt = data.Get("snooze_refresh_at").AsInt32(),
                NextAdAt = data.Get("next_ad_at").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_snooze_next_ad.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("snooze_count", SnoozeCount);
            request.Set("snooze_refresh_at", SnoozeRefreshAt);
            request.Set("next_ad_at", NextAdAt);
            return request;
        }
    
    }

}
