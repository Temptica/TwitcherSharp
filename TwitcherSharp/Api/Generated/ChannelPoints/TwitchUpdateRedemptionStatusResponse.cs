using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateRedemptionStatusResponse : Resource, ITwitcherSharp<TwitchUpdateRedemptionStatusResponse>
{
    private GodotObject _data;
    public TwitchCustomRewardRedemption[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateRedemptionStatusResponse object.
    /// </summary> 
    public static TwitchUpdateRedemptionStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchUpdateRedemptionStatusResponse
        {
            Data = dataArray.Select(TwitchCustomRewardRedemption.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_redemption_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }

}
