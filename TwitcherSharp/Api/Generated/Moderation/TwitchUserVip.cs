using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUserVip : RefCounted, ITwitcherSharp<TwitchUserVip>
{
    private GodotObject? _data;
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
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_vip.gd");
        var request = script.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserName != null) request.Set("user_name", UserName);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        return request;
    }

}
