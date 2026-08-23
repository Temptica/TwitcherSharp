using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchChannel : RefCounted, ITwitcherSharp<TwitchChannel>
{
    private GodotObject? _data;
    public string BroadcasterLanguage { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string GameName { get; set; } = null!;
    public string Id { get; set; } = null!;
    public bool IsLive { get; set; }
    public string[] TagIds { get; set; } = null!;
    public string[] Tags { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string StartedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannel object.
    /// </summary> 
    public static TwitchChannel? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannel
        {
            BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            DisplayName = data.Get("display_name").AsString(),
            GameId = data.Get("game_id").AsString(),
            GameName = data.Get("game_name").AsString(),
            Id = data.Get("id").AsString(),
            IsLive = data.Get("is_live").AsBool(),
            TagIds = data.Get("tag_ids").AsStringArray(),
            Tags = data.Get("tags").AsStringArray(),
            ThumbnailUrl = data.Get("thumbnail_url").AsString(),
            Title = data.Get("title").AsString(),
            StartedAt = data.Get("started_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterLanguage != null) request.Set("broadcaster_language", BroadcasterLanguage);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(DisplayName != null) request.Set("display_name", DisplayName);
        if(GameId != null) request.Set("game_id", GameId);
        if(GameName != null) request.Set("game_name", GameName);
        if(Id != null) request.Set("id", Id);
        request.Set("is_live", IsLive);
        if(TagIds != null) request.Set("tag_ids", new Godot.Collections.Array<string>(TagIds));
        if(Tags != null) request.Set("tags", new Godot.Collections.Array<string>(Tags));
        if(ThumbnailUrl != null) request.Set("thumbnail_url", ThumbnailUrl);
        if(Title != null) request.Set("title", Title);
        if(StartedAt != null) request.Set("started_at", StartedAt);
        return request;
    }

}
