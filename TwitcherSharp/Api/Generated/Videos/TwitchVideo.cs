using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

public partial class TwitchVideo : RefCounted, ITwitcherSharp<TwitchVideo>
{
    private GodotObject? _data;
    public string? Id { get; set; }
    public string? StreamId { get; set; }
    public string? UserId { get; set; }
    public string? UserLogin { get; set; }
    public string? UserName { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? CreatedAt { get; set; }
    public string? PublishedAt { get; set; }
    public string? Url { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Viewable { get; set; }
    public int ViewCount { get; set; }
    public string? Language { get; set; }
    public string? Type { get; set; }
    public string? Duration { get; set; }
    public TwitchResponseMutedSegments[]? MutedSegments { get => field ??= _data?.GetArray<TwitchResponseMutedSegments>("muted_segments"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchVideo object.
    /// </summary> 
    public static TwitchVideo? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchVideo
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
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(StreamId != null) request.Set("stream_id", StreamId);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(Title != null) request.Set("title", Title);
        if(Description != null) request.Set("description", Description);
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        if(PublishedAt != null) request.Set("published_at", PublishedAt);
        if(Url != null) request.Set("url", Url);
        if(ThumbnailUrl != null) request.Set("thumbnail_url", ThumbnailUrl);
        if(Viewable != null) request.Set("viewable", Viewable);
        request.Set("view_count", ViewCount);
        if(Language != null) request.Set("language", Language);
        if(Type != null) request.Set("type", Type);
        if(Duration != null) request.Set("duration", Duration);
        if(MutedSegments != null) request.Set("muted_segments", MutedSegments.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// The segments that Twitch Audio Recognition muted; otherwise, **null**. 
    /// </summary>
    public partial class TwitchResponseMutedSegments : RefCounted, ITwitcherSharp<TwitchResponseMutedSegments>
    {
        private GodotObject? _data;
        public int Duration { get; set; }
        public int Offset { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseMutedSegments object.
        /// </summary> 
        public static TwitchResponseMutedSegments? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseMutedSegments
            {
                Duration = data.Get("duration").AsInt32(),
                Offset = data.Get("offset").AsInt32(),
            };
            
            instance._data = data;
            return instance;
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
