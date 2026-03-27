using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

public partial class TwitchGetVideosResponse : RefCounted, ITwitcherSharp<TwitchGetVideosResponse>
{
    private GodotObject _data;
    public TwitchVideo[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetVideosResponse object.
    /// </summary> 
    public static TwitchGetVideosResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetVideosResponse
        {
            Data = dataArray.Select(TwitchVideo.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_videos.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetVideosResponse> NextPage() =>
        await _data.CallAsync<TwitchGetVideosResponse>("next_page");
    
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
    public partial class TwitchVideo : RefCounted, ITwitcherSharp<TwitchVideo>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string StreamId { get; set; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string PublishedAt { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Viewable { get; set; }
        public int ViewCount { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public TwitchMutedSegments[] MutedSegments { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVideo object.
        /// </summary> 
        public static TwitchVideo FromObject(GodotObject data)
        {
            if(data == null) return null;
            var mutedSegmentsArray = data.Get("muted_segments").AsGodotArray<GodotObject>();
            return new TwitchVideo
            {
                Id = data.Get("id").AsString(),
                StreamId = data.Get("stream_id").AsString(),
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Title = data.Get("title").AsString(),
                Description = data.Get("description").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
                PublishedAt = data.Get("published_at").AsString(),
                Url = data.Get("url").AsString(),
                ThumbnailUrl = data.Get("thumbnail_url").AsString(),
                Viewable = data.Get("viewable").AsString(),
                ViewCount = data.Get("view_count").AsInt32(),
                Language = data.Get("language").AsString(),
                Type = data.Get("type").AsString(),
                Duration = data.Get("duration").AsString(),
                MutedSegments = mutedSegmentsArray.Select(TwitchMutedSegments.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("stream_id", StreamId);
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("title", Title);
            request.Set("description", Description);
            request.Set("created_at", CreatedAt);
            request.Set("published_at", PublishedAt);
            request.Set("url", Url);
            request.Set("thumbnail_url", ThumbnailUrl);
            request.Set("viewable", Viewable);
            request.Set("view_count", ViewCount);
            request.Set("language", Language);
            request.Set("type", Type);
            request.Set("duration", Duration);
            request.Set("muted_segments", MutedSegments?.Select(x => x.ToGodotObject()).ToArray());
            return request;
        }
        
        /// <summary> 
        /// The segments that Twitch Audio Recognition muted; otherwise, **null**. 
        /// </summary>
        public partial class TwitchMutedSegments : RefCounted, ITwitcherSharp<TwitchMutedSegments>
        {
            private GodotObject _data;
            public int Duration { get; set; }
            public int Offset { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchMutedSegments object.
            /// </summary> 
            public static TwitchMutedSegments FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchMutedSegments
                {
                    Duration = data.Get("duration").AsInt32(),
                    Offset = data.Get("offset").AsInt32(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_muted_segments.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("duration", Duration);
                request.Set("offset", Offset);
                return request;
            }
        
        }
    
    }

}
