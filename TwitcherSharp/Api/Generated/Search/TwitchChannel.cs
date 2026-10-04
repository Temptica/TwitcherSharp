using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchChannel : RefCounted, ITwitcherSharp<TwitchChannel>
{
    private Variant _data;
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
            BroadcasterLanguage = data.Read("broadcaster_language", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            DisplayName = data.Read("display_name", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            GameName = data.Read("game_name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            IsLive = data.Read("is_live", static v => v.AsBool()),
            TagIds = data.Read("tag_ids", static v => v.AsStringArray()),
            Tags = data.Read("tags", static v => v.AsStringArray()),
            ThumbnailUrl = data.Read("thumbnail_url", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_channel.gd");
        if(BroadcasterLanguage != null) request.SetValue("broadcaster_language", BroadcasterLanguage);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(DisplayName != null) request.SetValue("display_name", DisplayName);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(GameName != null) request.SetValue("game_name", GameName);
        if(Id != null) request.SetValue("id", Id);
        request.SetValue("is_live", IsLive);
        if(TagIds != null) request.SetValue("tag_ids", new Godot.Collections.Array<string>(TagIds));
        if(Tags != null) request.SetValue("tags", new Godot.Collections.Array<string>(Tags));
        if(ThumbnailUrl != null) request.SetValue("thumbnail_url", ThumbnailUrl);
        if(Title != null) request.SetValue("title", Title);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
