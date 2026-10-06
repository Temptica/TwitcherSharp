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
            Id = data.Read("id", static v => v.AsString()),
            Login = data.Read("login", static v => v.AsString()),
            DisplayName = data.Read("display_name", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            BroadcasterType = data.Read("broadcaster_type", static v => v.AsString()),
            Description = data.Read("description", static v => v.AsString()),
            ProfileImageUrl = data.Read("profile_image_url", static v => v.AsString()),
            OfflineImageUrl = data.Read("offline_image_url", static v => v.AsString()),
            ViewCount = data.Read("view_count", static v => v.AsInt32()),
            Email = data.Read("email", static v => v.AsString()),
            CreatedAt = data.Read("created_at", static v => v.AsString()),
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
