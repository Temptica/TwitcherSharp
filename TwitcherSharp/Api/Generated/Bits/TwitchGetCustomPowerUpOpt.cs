using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomPowerUp 
/// </summary>
public partial class TwitchGetCustomPowerUpOpt : RefCounted, ITwitcherSharp<TwitchGetCustomPowerUpOpt>
{
    private GodotObject? _data;
    public string[]? Id { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomPowerUpOpt object.
    /// </summary> 
    public static TwitchGetCustomPowerUpOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomPowerUpOpt
        {
            Id = data.Get("id").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", new Godot.Collections.Array<string>(Id));
        return request;
    }

}
