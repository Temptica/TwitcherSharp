using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.CreateExtensionSecret 
/// </summary>
public partial class TwitchCreateExtensionSecretOpt : RefCounted, ITwitcherSharp<TwitchCreateExtensionSecretOpt>
{
    private GodotObject _data;
    public int? Delay { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateExtensionSecretOpt object.
    /// </summary> 
    public static TwitchCreateExtensionSecretOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateExtensionSecretOpt
        {
            Delay = data.Get("delay").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_extension_secret.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Delay.HasValue) request.Set("delay", Delay.Value);
        return request;
    }

}
