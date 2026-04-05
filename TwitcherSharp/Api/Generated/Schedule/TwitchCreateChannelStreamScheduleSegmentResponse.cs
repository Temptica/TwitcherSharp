using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchCreateChannelStreamScheduleSegmentResponse : RefCounted, ITwitcherSharp<TwitchCreateChannelStreamScheduleSegmentResponse>
{
    private GodotObject _data;
    public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static TwitchCreateChannelStreamScheduleSegmentResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCreateChannelStreamScheduleSegmentResponse
        {
            Data = data.Get("data").As<TwitchData>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The broadcaster’s streaming scheduled. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public TwitchChannelStreamScheduleSegment[] Segments { get; set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterName { get; set; }
        public string BroadcasterLogin { get; set; }
        public TwitchVacation Vacation { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var segmentsArray = data.Get("segments").AsGodotArray<GodotObject>();
            return new TwitchData
            {
                Segments = segmentsArray.Select(TwitchChannelStreamScheduleSegment.FromObject).ToArray(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                Vacation = data.Get("vacation").As<TwitchVacation>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            if(Segments != null) request.Set("segments", new Godot.Collections.Array<GodotObject>(Segments.Select(x => x.ToGodotObject()).ToArray()));
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("vacation", Vacation?.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled. 
        /// </summary>
        public partial class TwitchVacation : RefCounted, ITwitcherSharp<TwitchVacation>
        {
            private GodotObject _data;
            public string StartTime { get; set; }
            public string EndTime { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchVacation object.
            /// </summary> 
            public static TwitchVacation FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchVacation
                {
                    StartTime = data.Get("start_time").AsString(),
                    EndTime = data.Get("end_time").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_vacation.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("start_time", StartTime);
                request.Set("end_time", EndTime);
                return request;
            }
        
        }
    
    }

}
