using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchCreateChannelStreamScheduleSegmentResponse : RefCounted, ITwitcherSharp<TwitchCreateChannelStreamScheduleSegmentResponse>
{
    private GodotObject? _data;
    public TwitchResponseData Data { get => field ??= _data?.Get<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static TwitchCreateChannelStreamScheduleSegmentResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateChannelStreamScheduleSegmentResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The broadcaster’s streaming scheduled. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public TwitchChannelStreamScheduleSegment[] Segments { get => field ??= _data?.GetArray<TwitchChannelStreamScheduleSegment>("segments")!; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string BroadcasterName { get; set; } = null!;
        public string BroadcasterLogin { get; set; } = null!;
        public TwitchResponseVacation Vacation { get => field ??= _data?.Get<TwitchResponseVacation>("vacation")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Segments != null) request.Set("segments", Segments.ToGodotArray());
            if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
            if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
            if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
            if(Vacation != null) request.Set("vacation", Vacation.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled. 
        /// </summary>
        public partial class TwitchResponseVacation : RefCounted, ITwitcherSharp<TwitchResponseVacation>
        {
            private GodotObject? _data;
            public string StartTime { get; set; } = null!;
            public string EndTime { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseVacation object.
            /// </summary> 
            public static TwitchResponseVacation? FromObject(GodotObject? data)
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd");
                var twitchResponseVacationClass = script.Get("ResponseVacation").AsGodotObject();
                var request = twitchResponseVacationClass.Call("new").AsGodotObject();
                if(StartTime != null) request.Set("start_time", StartTime);
                if(EndTime != null) request.Set("end_time", EndTime);
                return request;
            }
        
        }
    
    }

}
