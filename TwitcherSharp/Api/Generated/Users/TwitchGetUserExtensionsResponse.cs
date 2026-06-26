using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetUserExtensionsResponse>
{
    private GodotObject _data;
    public TwitchUserExtension[] Data { get => field ??= _data?.GetArray<TwitchUserExtension>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserExtensionsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
