using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateRedemptionStatusBody : RefCounted, ITwitcherSharp<TwitchUpdateRedemptionStatusBody>
{
    private Variant _data;
    public string Status { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateRedemptionStatusBody object.
    /// </summary> 
    public static TwitchUpdateRedemptionStatusBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateRedemptionStatusBody
        {
            Status = data.Read("status", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_redemption_status.gd", "Body");
        if(Status != null) request.SetValue("status", Status);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
