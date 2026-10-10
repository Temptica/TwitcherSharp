using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestResolve;

public partial class TwitchChannelUnbanRequestResolveEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelUnbanRequestResolveEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the unban request.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The broadcaster’s user ID for the channel the unban request was updated for.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// Optional. User ID of moderator who approved/denied the request.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// Optional. The moderator’s login name
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// Optional. The moderator’s display name
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// User ID of user that requested to be unbanned.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user’s login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// Optional. Resolution text supplied by the mod/broadcaster upon approval/denial of the request.
    /// </summary>
    public string? ResolutionText { get; set; }

    /// <summary> 
    /// Dictates whether the unban request was approved or denied. Can be the following: approvedcanceleddenied
    /// </summary>
    public string? Status { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestResolveEvent object.
    /// </summary> 
    public static TwitchChannelUnbanRequestResolveEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUnbanRequestResolveEvent
        {
            Id = data.ReadAsString("id"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            ModeratorUserId = data.ReadAsString("moderator_user_id"),
            ModeratorUserLogin = data.ReadAsString("moderator_user_login"),
            ModeratorUserName = data.ReadAsString("moderator_user_name"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            ResolutionText = data.ReadAsString("resolution_text"),
            Status = data.ReadAsString("status"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_resolve.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(ResolutionText != null) request.SetValue("resolution_text", ResolutionText);
        if(Status != null) request.SetValue("status", Status);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
