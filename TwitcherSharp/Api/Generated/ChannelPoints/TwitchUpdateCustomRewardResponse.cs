using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchUpdateCustomRewardResponse : RefCounted, ITwitcherSharp<TwitchUpdateCustomRewardResponse>
{
    private GodotObject? _data;
    public TwitchCustomReward[]? Data { get => field ??= _data?.GetArray<TwitchCustomReward>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateCustomRewardResponse object.
    /// </summary> 
    public static TwitchUpdateCustomRewardResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateCustomRewardResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_custom_reward.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
