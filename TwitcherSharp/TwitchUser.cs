using Godot;
using Godot.Collections;
using System;

namespace TwitcherSharp;

public partial class TwitchUser(GodotObject data) : Resource
{
    /// <summary>
    /// An ID that identifies the user.
    /// </summary>
    public string Id { get; } = data.Get("id").AsString(); 

    /// <summary>
    /// The user's login name.
    /// </summary>
    public string Login { get; } = data.Get("login").AsString();

    /// <summary>
    /// The user's display name.
    /// </summary>
    public string DisplayName { get; } = data.Get("display_name").AsString();

    /// <summary>
    /// The type of user (admin, global_mod, staff, or empty).
    /// </summary>
    public string Type { get; } = data.Get("type").AsString();

    /// <summary>
    /// The type of broadcaster (affiliate, partner, or empty).
    /// </summary>
    public string BroadcasterType { get; } = data.Get("broadcaster_type").AsString();

    /// <summary>
    /// The user's description of their channel.
    /// </summary>
    public string Description { get; } = data.Get("description").AsString();

    /// <summary>
    /// A URL to the user's profile image.
    /// </summary>
    public string ProfileImageUrl { get; } = data.Get("profile_image_url").AsString();

    /// <summary>
    /// A URL to the user's offline image.
    /// </summary>
    public string OfflineImageUrl { get; } = data.Get("offline_image_url").AsString();

    /// <summary>
    /// The number of times the user's channel has been viewed (Deprecated).
    /// </summary>
    [Obsolete("View count has been deprecated by Twitch.")]
    public int ViewCount { get; } = data.Get("view_count").AsInt32();

    /// <summary>
    /// The user's verified email address.
    /// </summary>
    public string Email { get; } = data.Get("email").AsString();

    /// <summary>
    /// The UTC date and time that the user's account was created.
    /// </summary>
    public string CreatedAt { get; } = data.Get("created_at").AsString();
}