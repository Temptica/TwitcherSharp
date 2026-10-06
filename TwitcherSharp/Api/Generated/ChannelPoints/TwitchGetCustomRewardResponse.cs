using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchGetCustomRewardResponse : RefCounted, ITwitcherSharp<TwitchGetCustomRewardResponse>
{
    private Variant _data;
    public TwitchCustomReward[] Data { get => field ??= _data.GetArray<TwitchCustomReward>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardResponse object.
    /// </summary> 
    public static TwitchGetCustomRewardResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomRewardResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_reward.gd", "Response");
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
