using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchGetClipsResponse : RefCounted, ITwitcherSharp<TwitchGetClipsResponse>
{
    private GodotObject _data;
    public TwitchClip[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetClipsResponse object.
    /// </summary> 
    public static TwitchGetClipsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetClipsResponse
        {
            Data = dataArray.Select(TwitchClip.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetClipsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetClipsResponse>("next_page");
    
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
    public partial class TwitchClip : RefCounted, ITwitcherSharp<TwitchClip>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Url { get; set; }
        public string EmbedUrl { get; set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterName { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string VideoId { get; set; }
        public string GameId { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public int ViewCount { get; set; }
        public string CreatedAt { get; set; }
        public string ThumbnailUrl { get; set; }
        public double Duration { get; set; }
        public int VodOffset { get; set; }
        public bool IsFeatured { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchClip object.
        /// </summary> 
        public static TwitchClip FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchClip
            {
                Id = data.Get("id").AsString(),
                Url = data.Get("url").AsString(),
                EmbedUrl = data.Get("embed_url").AsString(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                CreatorId = data.Get("creator_id").AsString(),
                CreatorName = data.Get("creator_name").AsString(),
                VideoId = data.Get("video_id").AsString(),
                GameId = data.Get("game_id").AsString(),
                Language = data.Get("language").AsString(),
                Title = data.Get("title").AsString(),
                ViewCount = data.Get("view_count").AsInt32(),
                CreatedAt = data.Get("created_at").AsString(),
                ThumbnailUrl = data.Get("thumbnail_url").AsString(),
                Duration = data.Get("duration").AsDouble(),
                VodOffset = data.Get("vod_offset").AsInt32(),
                IsFeatured = data.Get("is_featured").AsBool(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_clip.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("url", Url);
            request.Set("embed_url", EmbedUrl);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("creator_id", CreatorId);
            request.Set("creator_name", CreatorName);
            request.Set("video_id", VideoId);
            request.Set("game_id", GameId);
            request.Set("language", Language);
            request.Set("title", Title);
            request.Set("view_count", ViewCount);
            request.Set("created_at", CreatedAt);
            request.Set("thumbnail_url", ThumbnailUrl);
            request.Set("duration", Duration);
            request.Set("vod_offset", VodOffset);
            request.Set("is_featured", IsFeatured);
            return request;
        }
    
    }

}
