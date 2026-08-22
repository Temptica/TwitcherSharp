using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChatter : RefCounted, ITwitcherSharp<TwitchChatter>
{
    private GodotObject? _data;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChatter object.
    /// </summary> 
    public static TwitchChatter? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChatter
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chatter.gd");
        var request = script.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        return request;
    }

}
