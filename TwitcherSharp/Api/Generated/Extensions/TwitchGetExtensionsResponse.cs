using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionsResponse>
{
    private GodotObject _data;
    public TwitchExtension[] Data { get => field ??= _data?.GetArray<TwitchExtension>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionsResponse object.
    /// </summary> 
    public static TwitchGetExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
