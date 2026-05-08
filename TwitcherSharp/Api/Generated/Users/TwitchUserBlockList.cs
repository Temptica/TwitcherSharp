using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUserBlockList : RefCounted, ITwitcherSharp<TwitchUserBlockList>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string UserLogin { get; set; }
    public string DisplayName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserBlockList object.
    /// </summary> 
    public static TwitchUserBlockList FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUserBlockList
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            DisplayName = data.Get("display_name").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_block_list.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("display_name", DisplayName);
        return request;
    }

}
