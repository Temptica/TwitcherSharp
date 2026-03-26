using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

public partial class TwitchGetExtensionAnalyticsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionAnalyticsResponse>
{
    private GodotObject _data;
    public TwitchExtensionAnalytics[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionAnalyticsResponse object.
    /// </summary> 
    public static TwitchGetExtensionAnalyticsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetExtensionAnalyticsResponse
        {
            Data = dataArray.Select(TwitchExtensionAnalytics.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_analytics.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetExtensionAnalyticsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetExtensionAnalyticsResponse>("next_page");
    
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
    public partial class TwitchExtensionAnalytics : RefCounted, ITwitcherSharp<TwitchExtensionAnalytics>
    {
        private GodotObject _data;
        public string ExtensionId { get; set; }
        public string URL { get; set; }
        public string Type { get; set; }
        public TwitchDateRange DateRange { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchExtensionAnalytics object.
        /// </summary> 
        public static TwitchExtensionAnalytics FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchExtensionAnalytics
            {
                ExtensionId = data.Get("extension_id").AsString(),
                URL = data.Get("url").AsString(),
                Type = data.Get("type").AsString(),
                DateRange = data.Get("date_range").As<TwitchDateRange>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_analytics.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("extension_id", ExtensionId);
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
