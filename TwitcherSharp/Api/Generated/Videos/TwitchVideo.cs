using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;

public partial class TwitchVideo : RefCounted, ITwitcherSharp<TwitchVideo>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string StreamId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string PublishedAt { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public string Viewable { get; set; } = null!;
    public int ViewCount { get; set; }
    public string Language { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Duration { get; set; } = null!;
    public TwitchResponseMutedSegments[] MutedSegments { get => field ??= _data.GetArray<TwitchResponseMutedSegments>("muted_segments")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchVideo object.
    /// </summary> 
    public static TwitchVideo? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchVideo
        {
            Id = data.ReadAsString("id"),
            StreamId = data.ReadAsString("stream_id"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            Title = data.ReadAsString("title"),
            Description = data.ReadAsString("description"),
            CreatedAt = data.ReadAsString("created_at"),
            PublishedAt = data.ReadAsString("published_at"),
            Url = data.ReadAsString("url"),
            ThumbnailUrl = data.ReadAsString("thumbnail_url"),
            Viewable = data.ReadAsString("viewable"),
            ViewCount = data.ReadAsInt32("view_count"),
            Language = data.ReadAsString("language"),
            Type = data.ReadAsString("type"),
            Duration = data.ReadAsString("duration"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_video.gd");
        if(Id != null) request.SetValue("id", Id);
        if(StreamId != null) request.SetValue("stream_id", StreamId);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Title != null) request.SetValue("title", Title);
        if(Description != null) request.SetValue("description", Description);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(PublishedAt != null) request.SetValue("published_at", PublishedAt);
        if(Url != null) request.SetValue("url", Url);
        if(ThumbnailUrl != null) request.SetValue("thumbnail_url", ThumbnailUrl);
        if(Viewable != null) request.SetValue("viewable", Viewable);
        request.SetValue("view_count", ViewCount);
        if(Language != null) request.SetValue("language", Language);
        if(Type != null) request.SetValue("type", Type);
        if(Duration != null) request.SetValue("duration", Duration);
        if(MutedSegments != null) request.SetArray("muted_segments", MutedSegments);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The segments that Twitch Audio Recognition muted; otherwise, **null**. 
    /// </summary>
    public partial class TwitchResponseMutedSegments : RefCounted, ITwitcherSharp<TwitchResponseMutedSegments>
    {
        private Variant _data;
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
                Duration = data.ReadAsInt32("duration"),
                Offset = data.ReadAsInt32("offset"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_video.gd", "MutedSegments");
            request.SetValue("duration", Duration);
            request.SetValue("offset", Offset);
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
