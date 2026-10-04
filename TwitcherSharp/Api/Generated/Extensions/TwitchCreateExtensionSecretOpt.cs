using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.CreateExtensionSecret 
/// </summary>
public partial class TwitchCreateExtensionSecretOpt : RefCounted, ITwitcherSharp<TwitchCreateExtensionSecretOpt>
{
    private Variant _data;
    public int? Delay { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateExtensionSecretOpt object.
    /// </summary> 
    public static TwitchCreateExtensionSecretOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateExtensionSecretOpt
        {
            Delay = data.Read("delay", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_extension_secret.gd", "Opt");
        if(Delay.HasValue) request.SetValue("delay", Delay.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
