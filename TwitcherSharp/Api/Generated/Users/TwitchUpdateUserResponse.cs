using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUpdateUserResponse : RefCounted, ITwitcherSharp<TwitchUpdateUserResponse>
{
    private GodotObject _data;
    public TwitchUser[] Data { get => field ??= _data?.GetArray<TwitchUser>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserResponse object.
    /// </summary> 
    public static TwitchUpdateUserResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateUserResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
