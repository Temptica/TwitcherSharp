using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchGetChannelStreamScheduleResponse : RefCounted, ITwitcherSharp<TwitchGetChannelStreamScheduleResponse>
{
    private GodotObject _data;
    public TwitchResponseData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelStreamScheduleResponse object.
    /// </summary> 
    public static TwitchGetChannelStreamScheduleResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetChannelStreamScheduleResponse
        {
            Data = data.Get("data").As<TwitchResponseData>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The broadcaster’s streaming schedule. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public TwitchChannelStreamScheduleSegment[] Segments { get; set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterName { get; set; }
        public string BroadcasterLogin { get; set; }
        public TwitchResponseVacation Vacation { get; set; }
        public ResponsePagination Pagination { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var segmentsArray = data.Get("segments").AsGodotArray<GodotObject>();
            return new TwitchResponseData
            {
                Segments = segmentsArray.Select(TwitchChannelStreamScheduleSegment.FromObject).ToArray(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                Vacation = data.Get("vacation").As<TwitchResponseVacation>(),
                Pagination = data.Get("pagination").As<ResponsePagination>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Segments != null) request.Set("segments", Segments?.ToGodotArray());
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("vacation", Vacation?.ToGodotObject());
            if(Pagination != null) request.Set("pagination", Pagination);
            return request;
        }
        public async Task<TwitchResponseData> NextPage() =>
            await _data.CallAsync<TwitchResponseData>("next_page");
        
        /// <summary> 
        /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
        /// </summary>
        public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
        {
            private GodotObject _data;
            public string Cursor { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a ResponsePagination object.
            /// </summary> 
            public static ResponsePagination FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new ResponsePagination
                {
                    Cursor = data.Get("cursor").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
                var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
                var request = responsePaginationClass.Call("new").AsGodotObject();
                if(Cursor != null) request.Set("cursor", Cursor);
                return request;
            }
        
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
                return new TwitchResponseVacation
                {
                    StartTime = data.Get("start_time").AsString(),
                    EndTime = data.Get("end_time").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_stream_schedule.gd");
                var twitchResponseVacationClass = script.Get("ResponseVacation").AsGodotObject();
                var request = twitchResponseVacationClass.Call("new").AsGodotObject();
                request.Set("start_time", StartTime);
                request.Set("end_time", EndTime);
                return request;
            }
        
        }
    
    }

}
