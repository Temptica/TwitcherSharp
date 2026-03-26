using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetReleasedExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetReleasedExtensionsResponse>
{
    private GodotObject _data;
    public TwitchExtension[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetReleasedExtensionsResponse object.
    /// </summary> 
    public static TwitchGetReleasedExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetReleasedExtensionsResponse
        {
            Data = dataArray.Select(TwitchExtension.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_released_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
