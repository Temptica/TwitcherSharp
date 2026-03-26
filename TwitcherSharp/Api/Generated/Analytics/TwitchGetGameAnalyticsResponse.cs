using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

public partial class TwitchGetGameAnalyticsResponse : RefCounted, ITwitcherSharp<TwitchGetGameAnalyticsResponse>
{
    private GodotObject _data;
    public TwitchGameAnalytics[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGameAnalyticsResponse object.
    /// </summary> 
    public static TwitchGetGameAnalyticsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetGameAnalyticsResponse
        {
            Data = dataArray.Select(TwitchGameAnalytics.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_game_analytics.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetGameAnalyticsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetGameAnalyticsResponse>("next_page");
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/response_pagination.gd");
            var paginationClass = script.Get("Pagination").AsGodotObject();
            var request = paginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    public partial class TwitchGameAnalytics : RefCounted, ITwitcherSharp<TwitchGameAnalytics>
    {
        private GodotObject _data;
        public string GameId { get; set; }
        public string URL { get; set; }
        public string Type { get; set; }
        public TwitchDateRange DateRange { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGameAnalytics object.
        /// </summary> 
        public static TwitchGameAnalytics FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchGameAnalytics
            {
                GameId = data.Get("game_id").AsString(),
                URL = data.Get("url").AsString(),
                Type = data.Get("type").AsString(),
                DateRange = data.Get("date_range").As<TwitchDateRange>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("game_id", GameId);
            request.Set("url", URL);
            request.Set("type", Type);
            request.Set("date_range", DateRange);
            return request;
        }
        
        /// <summary> 
        /// The reporting window’s start and end dates, in RFC3339 format. 
        /// </summary>
        public partial class TwitchDateRange : RefCounted, ITwitcherSharp<TwitchDateRange>
        {
            private GodotObject _data;
            public string StartedAt { get; set; }
            public string EndedAt { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchDateRange object.
            /// </summary> 
            public static TwitchDateRange FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchDateRange
                {
                    StartedAt = data.Get("started_at").AsString(),
                    EndedAt = data.Get("ended_at").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_date_range.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("started_at", StartedAt);
                request.Set("ended_at", EndedAt);
                return request;
            }
        
        }
    
    }

}
