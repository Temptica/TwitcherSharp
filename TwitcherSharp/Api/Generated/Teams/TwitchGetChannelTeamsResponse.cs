using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchGetChannelTeamsResponse : Resource, ITwitcherSharp<TwitchGetChannelTeamsResponse>
{
    private GodotObject _data;
    public TwitchChannelTeam[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelTeamsResponse object.
    /// </summary> 
    public static TwitchGetChannelTeamsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelTeamsResponse
        {
            Data = dataArray.Select(TwitchChannelTeam.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_teams.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }
    public partial class TwitchChannelTeam : Resource, ITwitcherSharp<TwitchChannelTeam>
    {
        private GodotObject _data;
        public string BroadcasterId { get; set; }
        public string BroadcasterLogin { get; set; }
        public string BroadcasterName { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string Banner { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Info { get; set; }
        public string ThumbnailUrl { get; set; }
        public string TeamName { get; set; }
        public string TeamDisplayName { get; set; }
        public string Id { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchChannelTeam object.
        /// </summary> 
        public static TwitchChannelTeam FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchChannelTeam
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
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_team.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("background_image_url", BackgroundImageUrl);
            request.Set("banner", Banner);
            request.Set("created_at", CreatedAt);
            request.Set("updated_at", UpdatedAt);
            request.Set("info", Info);
            request.Set("thumbnail_url", ThumbnailUrl);
            request.Set("team_name", TeamName);
            request.Set("team_display_name", TeamDisplayName);
            request.Set("id", Id);
            return request;
        }
    
    }

}
