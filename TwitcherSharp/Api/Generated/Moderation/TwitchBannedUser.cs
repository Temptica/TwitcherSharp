using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBannedUser : RefCounted, ITwitcherSharp<TwitchBannedUser>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string ExpiresAt { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string Reason { get; set; } = null!;
    public string ModeratorId { get; set; } = null!;
    public string ModeratorLogin { get; set; } = null!;
    public string ModeratorName { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchBannedUser object.
    /// </summary> 
    public static TwitchBannedUser? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBannedUser
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            ExpiresAt = data.Read("expires_at", static v => v.AsString()),
            CreatedAt = data.Read("created_at", static v => v.AsString()),
            Reason = data.Read("reason", static v => v.AsString()),
            ModeratorId = data.Read("moderator_id", static v => v.AsString()),
            ModeratorLogin = data.Read("moderator_login", static v => v.AsString()),
            ModeratorName = data.Read("moderator_name", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_banned_user.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(Reason != null) request.SetValue("reason", Reason);
        if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
        if(ModeratorLogin != null) request.SetValue("moderator_login", ModeratorLogin);
        if(ModeratorName != null) request.SetValue("moderator_name", ModeratorName);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
