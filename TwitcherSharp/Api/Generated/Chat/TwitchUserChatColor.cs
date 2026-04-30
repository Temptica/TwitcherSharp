using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchUserChatColor : RefCounted, ITwitcherSharp<TwitchUserChatColor>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string UserLogin { get; set; }
    public string UserName { get; set; }
    public string Color { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserChatColor object.
    /// </summary> 
    public static TwitchUserChatColor FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserChatColor
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Color = data.Get("color").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_chat_color.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("color", Color);
        return request;
    }

}
