using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchTeam : RefCounted, ITwitcherSharp<TwitchTeam>
{
    private Variant _data;
    public TwitchResponseUsers[] Users { get => field ??= _data.GetArray<TwitchResponseUsers>("users")!; set; } = null!;
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
    /// Transforms the godot data into a TwitchTeam object.
    /// </summary> 
    public static TwitchTeam? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchTeam
        {
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
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_team.gd");
        if(Users != null) request.SetArray("users", Users);
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
    
    /// <summary> 
    /// The list of team members. 
    /// </summary>
    public partial class TwitchResponseUsers : RefCounted, ITwitcherSharp<TwitchResponseUsers>
    {
        private Variant _data;
        public string UserId { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public string UserName { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseUsers object.
        /// </summary> 
        public static TwitchResponseUsers? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseUsers
            {
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_team.gd", "Users");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
