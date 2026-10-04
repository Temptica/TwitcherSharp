using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUserVip : RefCounted, ITwitcherSharp<TwitchUserVip>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserLogin { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserVip object.
    /// </summary> 
    public static TwitchUserVip? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserVip
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_vip.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
