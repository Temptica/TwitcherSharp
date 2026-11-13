using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestCreate;

public partial class TwitchChannelUnbanRequestCreateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelUnbanRequestCreateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the unban request.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The broadcaster’s user ID for the channel the unban request was created for.
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
    /// User ID of user that is requesting to be unbanned.
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
    /// Message sent in the unban request.
    /// </summary>
    public string? Text { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the unban request was created.
    /// </summary>
    public string? CreatedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestCreateEvent object.
    /// </summary> 
    public static TwitchChannelUnbanRequestCreateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUnbanRequestCreateEvent
        {
            Id = data.ReadAsString("id"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            Text = data.ReadAsString("text"),
            CreatedAt = data.ReadAsString("created_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_create.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Text != null) request.SetValue("text", Text);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
