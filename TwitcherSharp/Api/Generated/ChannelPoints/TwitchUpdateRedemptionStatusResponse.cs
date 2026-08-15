using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateRedemptionStatusResponse : RefCounted, ITwitcherSharp<TwitchUpdateRedemptionStatusResponse>
{
    private GodotObject _data;
    public TwitchCustomRewardRedemption[] Data { get => field ??= _data?.GetArray<TwitchCustomRewardRedemption>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateRedemptionStatusResponse object.
    /// </summary> 
    public static TwitchUpdateRedemptionStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateRedemptionStatusResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_redemption_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
