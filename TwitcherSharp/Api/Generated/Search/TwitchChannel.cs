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
            BroadcasterLanguage = data.ReadAsString("broadcaster_language"),
            BroadcasterLogin = data.ReadAsString("broadcaster_login"),
            DisplayName = data.ReadAsString("display_name"),
            GameId = data.ReadAsString("game_id"),
            GameName = data.ReadAsString("game_name"),
            Id = data.ReadAsString("id"),
            IsLive = data.ReadAsBool("is_live"),
            TagIds = data.ReadAsStringArray("tag_ids"),
            Tags = data.ReadAsStringArray("tags"),
            ThumbnailUrl = data.ReadAsString("thumbnail_url"),
            Title = data.ReadAsString("title"),
            StartedAt = data.ReadAsString("started_at"),
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
