using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchTeam : RefCounted, ITwitcherSharp<TwitchTeam>
{
    private GodotObject _data;
    public TwitchResponseUsers[] Users { get => field ??= _data?.GetArray<TwitchResponseUsers>("users"); set; }
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
    /// Transforms the godot data into a TwitchTeam object.
    /// </summary> 
    public static TwitchTeam FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchTeam
        {
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_team.gd");
        var request = script.Call("new").AsGodotObject();
        if(Users != null) request.Set("users", Users?.ToGodotArray());
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
    
    /// <summary> 
    /// The list of team members. 
    /// </summary>
    public partial class TwitchResponseUsers : RefCounted, ITwitcherSharp<TwitchResponseUsers>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseUsers object.
        /// </summary> 
        public static TwitchResponseUsers FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseUsers
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_team.gd");
            var twitchResponseUsersClass = script.Get("Users").AsGodotObject();
            var request = twitchResponseUsersClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    
    }

}
