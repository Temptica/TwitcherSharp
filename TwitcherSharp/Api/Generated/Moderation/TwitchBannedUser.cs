using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBannedUser : RefCounted, ITwitcherSharp<TwitchBannedUser>
{
    private GodotObject? _data;
    public string? UserId { get; set; }
    public string? UserLogin { get; set; }
    public string? UserName { get; set; }
    public string? ExpiresAt { get; set; }
    public string? CreatedAt { get; set; }
    public string? Reason { get; set; }
    public string? ModeratorId { get; set; }
    public string? ModeratorLogin { get; set; }
    public string? ModeratorName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBannedUser object.
    /// </summary> 
    public static TwitchBannedUser? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBannedUser
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            ExpiresAt = data.Get("expires_at").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            Reason = data.Get("reason").AsString(),
            ModeratorId = data.Get("moderator_id").AsString(),
            ModeratorLogin = data.Get("moderator_login").AsString(),
            ModeratorName = data.Get("moderator_name").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_banned_user.gd");
        var request = script.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(ExpiresAt != null) request.Set("expires_at", ExpiresAt);
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        if(Reason != null) request.Set("reason", Reason);
        if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
        if(ModeratorLogin != null) request.Set("moderator_login", ModeratorLogin);
        if(ModeratorName != null) request.Set("moderator_name", ModeratorName);
        return request;
    }

}
