using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchCreateChannelStreamScheduleSegmentResponse : RefCounted, ITwitcherSharp<TwitchCreateChannelStreamScheduleSegmentResponse>
{
    private Variant _data;
    public TwitchResponseData Data { get => field ??= _data.Get<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static TwitchCreateChannelStreamScheduleSegmentResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateChannelStreamScheduleSegmentResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd", "Response");
        if(Data != null) request.SetObject("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The broadcaster’s streaming scheduled. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public TwitchChannelStreamScheduleSegment[] Segments { get => field ??= _data.GetArray<TwitchChannelStreamScheduleSegment>("segments")!; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string BroadcasterName { get; set; } = null!;
        public string BroadcasterLogin { get; set; } = null!;
        public TwitchResponseVacation Vacation { get => field ??= _data.Get<TwitchResponseVacation>("vacation")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
                BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd", "ResponseData");
            if(Segments != null) request.SetArray("segments", Segments);
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
            if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
            if(Vacation != null) request.SetObject("vacation", Vacation);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled. 
        /// </summary>
        public partial class TwitchResponseVacation : RefCounted, ITwitcherSharp<TwitchResponseVacation>
        {
            private Variant _data;
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
                    StartTime = data.Read("start_time", static v => v.AsString()),
                    EndTime = data.Read("end_time", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment.gd", "ResponseVacation");
                if(StartTime != null) request.SetValue("start_time", StartTime);
                if(EndTime != null) request.SetValue("end_time", EndTime);
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

}
