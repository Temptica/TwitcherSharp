// using Godot;
// using Godot.Collections;
// using System;
// using TwitcherSharp.Interfaces;
//
// namespace TwitcherSharp;
//
// public partial class TwitchUser : Resource, ITwitcherSharp<TwitchUser>
// {
//     /// <summary>
//     /// An ID that identifies the user.
//     /// </summary>
//     public string Id { get; set; }
//
//     /// <summary>
//     /// The user's login name.
//     /// </summary>
//     public string Login { get; set; }
//
//     /// <summary>
//     /// The user's display name.
//     /// </summary>
//     public string DisplayName { get; set; }
//
//     /// <summary>
//     /// The type of user (admin, global_mod, staff, or empty).
//     /// </summary>
//     public string Type { get; set; }
//
//     /// <summary>
//     /// The type of broadcaster (affiliate, partner, or empty).
//     /// </summary>
//     public string BroadcasterType { get; set; }
//
//     /// <summary>
//     /// The user's description of their channel.
//     /// </summary>
//     public string Description { get; set; }
//
//     /// <summary>
//     /// A URL to the user's profile image.
//     /// </summary>
//     public string ProfileImageUrl { get; set; } 
//
//     /// <summary>
//     /// A URL to the user's offline image.
//     /// </summary>
//     public string OfflineImageUrl { get; set; } 
//
//     /// <summary>
//     /// The number of times the user's channel has been viewed (Deprecated).
//     /// </summary>
//     [Obsolete("View count has been deprecated by Twitch.")]
//     public int ViewCount { get; set; }
//
//     /// <summary>
//     /// The user's verified email address.
//     /// </summary>
//     public string Email { get; set; }
//
//     /// <summary>
//     /// The UTC date and time that the user's account was created.
//     /// </summary>
//     public string CreatedAt { get; set; }
//
//     public static TwitchUser FromObject(GodotObject data)
//     {
//         return new TwitchUser
//         {
//             Id = data.Get("id").AsString(),
//             Login = data.Get("login").AsString(),
//             DisplayName = data.Get("display_name").AsString(),
//             Type = data.Get("type").AsString(),
//             BroadcasterType = data.Get("broadcaster_type").AsString(),
//             Description = data.Get("description").AsString(),
//             ProfileImageUrl = data.Get("profile_image_url").AsString(),
//             OfflineImageUrl = data.Get("offline_image_url").AsString(),
//             Email = data.Get("email").AsString(),
//             CreatedAt = data.Get("created_at").AsString()
//         };
//     }
//
//     public GodotObject ToGodotObject()
//     {
//         var path = 
//     }
// }