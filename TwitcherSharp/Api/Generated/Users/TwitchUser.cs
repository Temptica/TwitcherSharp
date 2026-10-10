using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUser : RefCounted, ITwitcherSharp<TwitchUser>
{
    private Variant _data;
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
            Id = data.ReadAsString("id"),
            Login = data.ReadAsString("login"),
            DisplayName = data.ReadAsString("display_name"),
            Type = data.ReadAsString("type"),
            BroadcasterType = data.ReadAsString("broadcaster_type"),
            Description = data.ReadAsString("description"),
            ProfileImageUrl = data.ReadAsString("profile_image_url"),
            OfflineImageUrl = data.ReadAsString("offline_image_url"),
            ViewCount = data.ReadAsInt32("view_count"),
            Email = data.ReadAsString("email"),
            CreatedAt = data.ReadAsString("created_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Login != null) request.SetValue("login", Login);
        if(DisplayName != null) request.SetValue("display_name", DisplayName);
        if(Type != null) request.SetValue("type", Type);
        if(BroadcasterType != null) request.SetValue("broadcaster_type", BroadcasterType);
        if(Description != null) request.SetValue("description", Description);
        if(ProfileImageUrl != null) request.SetValue("profile_image_url", ProfileImageUrl);
        if(OfflineImageUrl != null) request.SetValue("offline_image_url", OfflineImageUrl);
        request.SetValue("view_count", ViewCount);
        if(Email != null) request.SetValue("email", Email);
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
