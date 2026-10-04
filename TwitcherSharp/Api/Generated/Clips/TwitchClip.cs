using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchClip : RefCounted, ITwitcherSharp<TwitchClip>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string EmbedUrl { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string CreatorId { get; set; } = null!;
    public string CreatorName { get; set; } = null!;
    public string VideoId { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string Language { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int ViewCount { get; set; }
    public string CreatedAt { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public double Duration { get; set; }
    public int VodOffset { get; set; }
    public bool IsFeatured { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchClip object.
    /// </summary> 
    public static TwitchClip? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchClip
        {
            Id = data.Read("id", static v => v.AsString()),
            Url = data.Read("url", static v => v.AsString()),
            EmbedUrl = data.Read("embed_url", static v => v.AsString()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            CreatorId = data.Read("creator_id", static v => v.AsString()),
            CreatorName = data.Read("creator_name", static v => v.AsString()),
            VideoId = data.Read("video_id", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            Language = data.Read("language", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            ViewCount = data.Read("view_count", static v => v.AsInt32()),
            CreatedAt = data.Read("created_at", static v => v.AsString()),
            ThumbnailUrl = data.Read("thumbnail_url", static v => v.AsString()),
            Duration = data.Read("duration", static v => v.AsDouble()),
            VodOffset = data.Read("vod_offset", static v => v.AsInt32()),
            IsFeatured = data.Read("is_featured", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_clip.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Url != null) request.SetValue("url", Url);
        if(EmbedUrl != null) request.SetValue("embed_url", EmbedUrl);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(CreatorId != null) request.SetValue("creator_id", CreatorId);
        if(CreatorName != null) request.SetValue("creator_name", CreatorName);
        if(VideoId != null) request.SetValue("video_id", VideoId);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(Language != null) request.SetValue("language", Language);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("view_count", ViewCount);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(ThumbnailUrl != null) request.SetValue("thumbnail_url", ThumbnailUrl);
        request.SetValue("duration", Duration);
        request.SetValue("vod_offset", VodOffset);
        request.SetValue("is_featured", IsFeatured);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
