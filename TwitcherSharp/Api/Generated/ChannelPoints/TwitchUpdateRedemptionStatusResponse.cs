using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateRedemptionStatusResponse : RefCounted, ITwitcherSharp<TwitchUpdateRedemptionStatusResponse>
{
    private Variant _data;
    public TwitchCustomRewardRedemption[] Data { get => field ??= _data.GetArray<TwitchCustomRewardRedemption>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateRedemptionStatusResponse object.
    /// </summary> 
    public static TwitchUpdateRedemptionStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateRedemptionStatusResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_redemption_status.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
