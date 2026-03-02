using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchStartCommercialBody : Resource, ITwitcherSharp<TwitchStartCommercialBody>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public int Length { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartCommercialBody object.
    /// </summary> 
    public static TwitchStartCommercialBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchStartCommercialBody
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Length = data.Get("length").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_commercial.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("length", Length);
        return request;
    }

}
