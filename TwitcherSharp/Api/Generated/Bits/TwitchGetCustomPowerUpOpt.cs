using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomPowerUp 
/// </summary>
public partial class TwitchGetCustomPowerUpOpt : RefCounted, ITwitcherSharp<TwitchGetCustomPowerUpOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomPowerUpOpt object.
    /// </summary> 
    public static TwitchGetCustomPowerUpOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomPowerUpOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
