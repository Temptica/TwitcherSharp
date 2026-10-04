using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStream : RefCounted, ITwitcherSharp<TwitchStream>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string GameName { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int ViewerCount { get; set; }
    public string StartedAt { get; set; } = null!;
    public string Language { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public string[] TagIds { get; set; } = null!;
    public string[] Tags { get; set; } = null!;
    public bool IsMature { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStream object.
    /// </summary> 
    public static TwitchStream? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStream
        {
            Id = data.Read("id", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            GameName = data.Read("game_name", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            ViewerCount = data.Read("viewer_count", static v => v.AsInt32()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            Language = data.Read("language", static v => v.AsString()),
            ThumbnailUrl = data.Read("thumbnail_url", static v => v.AsString()),
            TagIds = data.Read("tag_ids", static v => v.AsStringArray()),
            Tags = data.Read("tags", static v => v.AsStringArray()),
            IsMature = data.Read("is_mature", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_stream.gd");
        if(Id != null) request.SetValue("id", Id);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(GameName != null) request.SetValue("game_name", GameName);
        if(Type != null) request.SetValue("type", Type);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("viewer_count", ViewerCount);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(Language != null) request.SetValue("language", Language);
        if(ThumbnailUrl != null) request.SetValue("thumbnail_url", ThumbnailUrl);
        if(TagIds != null) request.SetValue("tag_ids", new Godot.Collections.Array<string>(TagIds));
        if(Tags != null) request.SetValue("tags", new Godot.Collections.Array<string>(Tags));
        request.SetValue("is_mature", IsMature);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
