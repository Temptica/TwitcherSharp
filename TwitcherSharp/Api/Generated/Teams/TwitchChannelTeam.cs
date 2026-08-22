using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchChannelTeam : RefCounted, ITwitcherSharp<TwitchChannelTeam>
{
    private GodotObject? _data;
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
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            BackgroundImageUrl = data.Get("background_image_url").AsString(),
            Banner = data.Get("banner").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            UpdatedAt = data.Get("updated_at").AsString(),
            Info = data.Get("info").AsString(),
            ThumbnailUrl = data.Get("thumbnail_url").AsString(),
            TeamName = data.Get("team_name").AsString(),
            TeamDisplayName = data.Get("team_display_name").AsString(),
            Id = data.Get("id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_team.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(BackgroundImageUrl != null) request.Set("background_image_url", BackgroundImageUrl);
        if(Banner != null) request.Set("banner", Banner);
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        if(UpdatedAt != null) request.Set("updated_at", UpdatedAt);
        if(Info != null) request.Set("info", Info);
        if(ThumbnailUrl != null) request.Set("thumbnail_url", ThumbnailUrl);
        if(TeamName != null) request.Set("team_name", TeamName);
        if(TeamDisplayName != null) request.Set("team_display_name", TeamDisplayName);
        if(Id != null) request.Set("id", Id);
        return request;
    }

}
