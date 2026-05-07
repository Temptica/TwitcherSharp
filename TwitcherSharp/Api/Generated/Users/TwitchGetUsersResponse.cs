using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUsersResponse : RefCounted, ITwitcherSharp<TwitchGetUsersResponse>
{
    private GodotObject _data;
    public TwitchUser[] Data { get => field ??= _data?.GetArray<TwitchUser>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUsersResponse object.
    /// </summary> 
    public static TwitchGetUsersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUsersResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
