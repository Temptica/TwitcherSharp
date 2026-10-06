using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchChannelTeam : RefCounted, ITwitcherSharp<TwitchChannelTeam>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string BackgroundImageUrl { get; set; } = null!;
    public string Banner { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string UpdatedAt { get; set; } = null!;
    public string Info { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public string TeamName { get; set; } = null!;
    public string TeamDisplayName { get; set; } = null!;
    public string Id { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelTeam object.
    /// </summary> 
    public static TwitchChannelTeam? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelTeam
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            BackgroundImageUrl = data.Read("background_image_url", static v => v.AsString()),
            Banner = data.Read("banner", static v => v.AsString()),
            CreatedAt = data.Read("created_at", static v => v.AsString()),
            UpdatedAt = data.Read("updated_at", static v => v.AsString()),
            Info = data.Read("info", static v => v.AsString()),
            ThumbnailUrl = data.Read("thumbnail_url", static v => v.AsString()),
            TeamName = data.Read("team_name", static v => v.AsString()),
            TeamDisplayName = data.Read("team_display_name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_channel_team.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(BackgroundImageUrl != null) request.SetValue("background_image_url", BackgroundImageUrl);
        if(Banner != null) request.SetValue("banner", Banner);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(UpdatedAt != null) request.SetValue("updated_at", UpdatedAt);
        if(Info != null) request.SetValue("info", Info);
        if(ThumbnailUrl != null) request.SetValue("thumbnail_url", ThumbnailUrl);
        if(TeamName != null) request.SetValue("team_name", TeamName);
        if(TeamDisplayName != null) request.SetValue("team_display_name", TeamDisplayName);
        if(Id != null) request.SetValue("id", Id);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
