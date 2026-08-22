using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUser : RefCounted, ITwitcherSharp<TwitchUser>
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string BroadcasterType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ProfileImageUrl { get; set; } = null!;
    public string OfflineImageUrl { get; set; } = null!;
    public int ViewCount { get; set; }
    public string? Email { get; set; }
    public string CreatedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUser object.
    /// </summary> 
    public static TwitchUser? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUser
        {
            Id = data.Get("id").AsString(),
            Login = data.Get("login").AsString(),
            DisplayName = data.Get("display_name").AsString(),
            Type = data.Get("type").AsString(),
            BroadcasterType = data.Get("broadcaster_type").AsString(),
            Description = data.Get("description").AsString(),
            ProfileImageUrl = data.Get("profile_image_url").AsString(),
            OfflineImageUrl = data.Get("offline_image_url").AsString(),
            ViewCount = data.Get("view_count").AsInt32(),
            Email = data.Get("email").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Login != null) request.Set("login", Login);
        if(DisplayName != null) request.Set("display_name", DisplayName);
        if(Type != null) request.Set("type", Type);
        if(BroadcasterType != null) request.Set("broadcaster_type", BroadcasterType);
        if(Description != null) request.Set("description", Description);
        if(ProfileImageUrl != null) request.Set("profile_image_url", ProfileImageUrl);
        if(OfflineImageUrl != null) request.Set("offline_image_url", OfflineImageUrl);
        request.Set("view_count", ViewCount);
        if(Email != null) request.Set("email", Email);
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        return request;
    }

}
