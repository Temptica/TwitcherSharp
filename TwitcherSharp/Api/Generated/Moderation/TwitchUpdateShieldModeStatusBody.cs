using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateShieldModeStatusBody : RefCounted, ITwitcherSharp<TwitchUpdateShieldModeStatusBody>
{
    private GodotObject _data;
    public bool IsActive { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateShieldModeStatusBody object.
    /// </summary> 
    public static TwitchUpdateShieldModeStatusBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUpdateShieldModeStatusBody
        {
            IsActive = data.Get("is_active").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("is_active", IsActive);
        return request;
    }

}
