using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateCustomRewardResponse : RefCounted, ITwitcherSharp<TwitchUpdateCustomRewardResponse>
{
    private Variant _data;
    public TwitchCustomReward[] Data { get => field ??= _data.GetArray<TwitchCustomReward>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateCustomRewardResponse object.
    /// </summary> 
    public static TwitchUpdateCustomRewardResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateCustomRewardResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_custom_reward.gd", "Response");
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
