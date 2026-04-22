using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

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
    public TwitchResponseMutedSegments[] MutedSegments { get; set; }

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
            MutedSegments = mutedSegmentsArray.Select(TwitchResponseMutedSegments.FromObject).ToArray(),
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
        if(MutedSegments != null) request.Set("muted_segments", MutedSegments?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// The segments that Twitch Audio Recognition muted; otherwise, **null**. 
    /// </summary>
    public partial class TwitchResponseMutedSegments : RefCounted, ITwitcherSharp<TwitchResponseMutedSegments>
    {
        private GodotObject _data;
        public int Duration { get; set; }
        public int Offset { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseMutedSegments object.
        /// </summary> 
        public static TwitchResponseMutedSegments FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseMutedSegments
            {
                Duration = data.Get("duration").AsInt32(),
                Offset = data.Get("offset").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video.gd");
            var twitchResponseMutedSegmentsClass = script.Get("MutedSegments").AsGodotObject();
            var request = twitchResponseMutedSegmentsClass.Call("new").AsGodotObject();
            request.Set("duration", Duration);
            request.Set("offset", Offset);
            return request;
        }
    
    }

}
