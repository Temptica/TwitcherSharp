using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchGetCustomRewardResponse : RefCounted, ITwitcherSharp<TwitchGetCustomRewardResponse>
{
    private GodotObject _data;
    public TwitchCustomReward[] Data { get => field ??= _data?.GetArray<TwitchCustomReward>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardResponse object.
    /// </summary> 
    public static TwitchGetCustomRewardResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomRewardResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
