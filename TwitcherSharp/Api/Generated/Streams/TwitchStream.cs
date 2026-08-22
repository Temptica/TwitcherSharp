using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStream : RefCounted, ITwitcherSharp<TwitchStream>
{
    private GodotObject? _data;
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
            Id = data.Get("id").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            GameId = data.Get("game_id").AsString(),
            GameName = data.Get("game_name").AsString(),
            Type = data.Get("type").AsString(),
            Title = data.Get("title").AsString(),
            ViewerCount = data.Get("viewer_count").AsInt32(),
            StartedAt = data.Get("started_at").AsString(),
            Language = data.Get("language").AsString(),
            ThumbnailUrl = data.Get("thumbnail_url").AsString(),
            TagIds = data.Get("tag_ids").AsStringArray(),
            Tags = data.Get("tags").AsStringArray(),
            IsMature = data.Get("is_mature").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(GameId != null) request.Set("game_id", GameId);
        if(GameName != null) request.Set("game_name", GameName);
        if(Type != null) request.Set("type", Type);
        if(Title != null) request.Set("title", Title);
        request.Set("viewer_count", ViewerCount);
        if(StartedAt != null) request.Set("started_at", StartedAt);
        if(Language != null) request.Set("language", Language);
        if(ThumbnailUrl != null) request.Set("thumbnail_url", ThumbnailUrl);
        if(TagIds != null) request.Set("tag_ids", new Godot.Collections.Array<string>(TagIds));
        if(Tags != null) request.Set("tags", new Godot.Collections.Array<string>(Tags));
        request.Set("is_mature", IsMature);
        return request;
    }

}
