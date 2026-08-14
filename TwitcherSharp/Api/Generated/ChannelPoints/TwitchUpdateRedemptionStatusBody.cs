using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateRedemptionStatusBody : RefCounted, ITwitcherSharp<TwitchUpdateRedemptionStatusBody>
{
    private GodotObject? _data;
    public string? Status { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateRedemptionStatusBody object.
    /// </summary> 
    public static TwitchUpdateRedemptionStatusBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateRedemptionStatusBody
        {
            Status = data.Get("status").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_redemption_status.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Status != null) request.Set("status", Status);
        return request;
    }

}
