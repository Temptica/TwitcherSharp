using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestResolve;

public partial class TwitchChannelUnbanRequestResolveEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelUnbanRequestResolveEvent>
{
    private GodotObject? _data;
    
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
    public string? ModeratorId { get; set; }

    /// <summary> 
    /// Optional. The moderator’s login name
    /// </summary>
    public string? ModeratorLogin { get; set; }

    /// <summary> 
    /// Optional. The moderator’s display name
    /// </summary>
    public string? ModeratorName { get; set; }

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
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ModeratorId = data.Get("moderator_id").AsString(),
            ModeratorLogin = data.Get("moderator_login").AsString(),
            ModeratorName = data.Get("moderator_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            ResolutionText = data.Get("resolution_text").AsString(),
            Status = data.Get("status").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_resolve.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
        if(ModeratorLogin != null) request.Set("moderator_login", ModeratorLogin);
        if(ModeratorName != null) request.Set("moderator_name", ModeratorName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(ResolutionText != null) request.Set("resolution_text", ResolutionText);
        if(Status != null) request.Set("status", Status);
        return request;
    }
}
