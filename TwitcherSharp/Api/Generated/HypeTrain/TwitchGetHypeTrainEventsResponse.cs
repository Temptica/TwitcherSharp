using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;

public partial class TwitchGetHypeTrainEventsResponse : Resource, ITwitcherSharp<TwitchGetHypeTrainEventsResponse>
{
    private GodotObject _data;
    public TwitchHypeTrainEvent[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainEventsResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainEventsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetHypeTrainEventsResponse
        {
            Data = dataArray.Select(TwitchHypeTrainEvent.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_events.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public partial class TwitchHypeTrainEvent : Resource, ITwitcherSharp<TwitchHypeTrainEvent>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string EventType { get; set; }
        public string EventTimestamp { get; set; }
        public string Version { get; set; }
        public TwitchEventData EventData { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchHypeTrainEvent object.
        /// </summary> 
        public static TwitchHypeTrainEvent FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchHypeTrainEvent
            {
                Id = data.Get("id").AsString(),
                EventType = data.Get("event_type").AsString(),
                EventTimestamp = data.Get("event_timestamp").AsString(),
                Version = data.Get("version").AsString(),
                EventData = data.Get("event_data").As<TwitchEventData>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_hype_train_event.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("event_type", EventType);
            request.Set("event_timestamp", EventTimestamp);
            request.Set("version", Version);
            request.Set("event_data", EventData);
            return request;
        }
        
        /// <summary> 
        /// The event’s data. 
        /// </summary>
        public partial class TwitchEventData : Resource, ITwitcherSharp<TwitchEventData>
        {
            private GodotObject _data;
            public string BroadcasterId { get; set; }
            public string CooldownEndTime { get; set; }
            public string ExpiresAt { get; set; }
            public int Goal { get; set; }
            public string Id { get; set; }
            public TwitchLastContribution LastContribution { get; set; }
            public int Level { get; set; }
            public string StartedAt { get; set; }
            public TwitchTopContributions[] TopContributions { get; set; }
            public int Total { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchEventData object.
            /// </summary> 
            public static TwitchEventData FromObject(GodotObject data)
            {
                if(data == null) return null;
                var topContributionsArray = data.Get("top_contributions").AsGodotArray<GodotObject>();
                return new TwitchEventData
                {
                    BroadcasterId = data.Get("broadcaster_id").AsString(),
                    CooldownEndTime = data.Get("cooldown_end_time").AsString(),
                    ExpiresAt = data.Get("expires_at").AsString(),
                    Goal = data.Get("goal").AsInt32(),
                    Id = data.Get("id").AsString(),
                    LastContribution = data.Get("last_contribution").As<TwitchLastContribution>(),
                    Level = data.Get("level").AsInt32(),
                    StartedAt = data.Get("started_at").AsString(),
                    TopContributions = topContributionsArray.Select(TwitchTopContributions.FromObject).ToArray(),
                    Total = data.Get("total").AsInt32(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_event_data.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("broadcaster_id", BroadcasterId);
                request.Set("cooldown_end_time", CooldownEndTime);
                request.Set("expires_at", ExpiresAt);
                request.Set("goal", Goal);
                request.Set("id", Id);
                request.Set("last_contribution", LastContribution);
                request.Set("level", Level);
                request.Set("started_at", StartedAt);
                request.Set("top_contributions", TopContributions);
                request.Set("total", Total);
                return request;
            }
            
            /// <summary> 
            /// The most recent contribution towards the Hype Train’s goal. 
            /// </summary>
            public partial class TwitchLastContribution : Resource, ITwitcherSharp<TwitchLastContribution>
            {
                private GodotObject _data;
                public int Total { get; set; }
                public string Type { get; set; }
                public string User { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchLastContribution object.
                /// </summary> 
                public static TwitchLastContribution FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchLastContribution
                    {
                        Total = data.Get("total").AsInt32(),
                        Type = data.Get("type").AsString(),
                        User = data.Get("user").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_last_contribution.gd");
                    var request = script.Call("new").AsGodotObject();
                    request.Set("total", Total);
                    request.Set("type", Type);
                    request.Set("user", User);
                    return request;
                }
            
            }
            
            /// <summary> 
            /// The top contributors for each contribution type. For example, the top contributor using BITS (by aggregate) and the top contributor using SUBS (by count). 
            /// </summary>
            public partial class TwitchTopContributions : Resource, ITwitcherSharp<TwitchTopContributions>
            {
                private GodotObject _data;
                public int Total { get; set; }
                public string Type { get; set; }
                public string User { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchTopContributions object.
                /// </summary> 
                public static TwitchTopContributions FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchTopContributions
                    {
                        Total = data.Get("total").AsInt32(),
                        Type = data.Get("type").AsString(),
                        User = data.Get("user").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_top_contributions.gd");
                    var request = script.Call("new").AsGodotObject();
                    request.Set("total", Total);
                    request.Set("type", Type);
                    request.Set("user", User);
                    return request;
                }
            
            }
        
        }
    
    }

}
