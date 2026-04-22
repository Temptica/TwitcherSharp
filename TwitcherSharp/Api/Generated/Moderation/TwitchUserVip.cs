using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUserVip : RefCounted, ITwitcherSharp<TwitchUserVip>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserVip object.
    /// </summary> 
    public static TwitchUserVip FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserVip
        {
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_vip.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_name", UserName);
        request.Set("user_login", UserLogin);
        return request;
    }

}
