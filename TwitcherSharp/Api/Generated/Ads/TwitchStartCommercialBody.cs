using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchStartCommercialBody : RefCounted, ITwitcherSharp<TwitchStartCommercialBody>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public int Length { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartCommercialBody object.
    /// </summary> 
    public static TwitchStartCommercialBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStartCommercialBody
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            Length = data.Read("length", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_start_commercial.gd", "Body");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        request.SetValue("length", Length);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
