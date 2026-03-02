using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchGetTeamsResponse : Resource, ITwitcherSharp<TwitchGetTeamsResponse>
{
    private GodotObject _data;
    public TwitchTeam[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTeamsResponse object.
    /// </summary> 
    public static TwitchGetTeamsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetTeamsResponse
        {
            Data = dataArray.Select(TwitchTeam.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }
    public partial class TwitchTeam : Resource, ITwitcherSharp<TwitchTeam>
    {
        private GodotObject _data;
        public TwitchUsers[] Users { get; set; }
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
            var usersArray = data.Get("users").AsGodotArray<GodotObject>();
            return new TwitchTeam
            {
                Users = usersArray.Select(TwitchUsers.FromObject).ToArray(),
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_team.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("users", Users);
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
        public partial class TwitchUsers : Resource, ITwitcherSharp<TwitchUsers>
        {
            private GodotObject _data;
            public string UserId { get; set; }
            public string UserLogin { get; set; }
            public string UserName { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchUsers object.
            /// </summary> 
            public static TwitchUsers FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchUsers
                {
                    UserId = data.Get("user_id").AsString(),
                    UserLogin = data.Get("user_login").AsString(),
                    UserName = data.Get("user_name").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_users.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("user_id", UserId);
                request.Set("user_login", UserLogin);
                request.Set("user_name", UserName);
                return request;
            }
        
        }
    
    }

}
