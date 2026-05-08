using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetReleasedExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetReleasedExtensionsResponse>
{
    private GodotObject _data;
    public TwitchExtension[] Data { get => field ??= _data?.GetArray<TwitchExtension>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetReleasedExtensionsResponse object.
    /// </summary> 
    public static TwitchGetReleasedExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetReleasedExtensionsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_released_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
