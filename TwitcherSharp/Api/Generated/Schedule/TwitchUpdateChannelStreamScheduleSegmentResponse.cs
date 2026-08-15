using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchUpdateChannelStreamScheduleSegmentResponse : RefCounted, ITwitcherSharp<TwitchUpdateChannelStreamScheduleSegmentResponse>
{
    private GodotObject _data;
    public TwitchResponseData Data { get => field ??= _data?.Get<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static TwitchUpdateChannelStreamScheduleSegmentResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChannelStreamScheduleSegmentResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_stream_schedule_segment.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The broadcaster’s streaming scheduled. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public TwitchChannelStreamScheduleSegment[] Segments { get => field ??= _data?.GetArray<TwitchChannelStreamScheduleSegment>("segments"); set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterName { get; set; }
        public string BroadcasterLogin { get; set; }
        public TwitchResponseVacation Vacation { get => field ??= _data?.Get<TwitchResponseVacation>("vacation"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_stream_schedule_segment.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Segments != null) request.SetArray("segments", Segments);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("vacation", Vacation?.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled. 
        /// </summary>
        public partial class TwitchResponseVacation : RefCounted, ITwitcherSharp<TwitchResponseVacation>
        {
            private GodotObject _data;
            public string StartTime { get; set; }
            public string EndTime { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseVacation object.
            /// </summary> 
            public static TwitchResponseVacation FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseVacation
                {
                    StartTime = data.Get("start_time").AsString(),
                    EndTime = data.Get("end_time").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_stream_schedule_segment.gd");
                var twitchResponseVacationClass = script.Get("ResponseVacation").AsGodotObject();
                var request = twitchResponseVacationClass.Call("new").AsGodotObject();
                request.Set("start_time", StartTime);
                request.Set("end_time", EndTime);
                return request;
            }
        
        }
    
    }

}
