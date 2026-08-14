using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCreateCustomRewardsResponse : RefCounted, ITwitcherSharp<TwitchCreateCustomRewardsResponse>
{
    private GodotObject? _data;
    public TwitchCustomReward[]? Data { get => field ??= _data?.GetArray<TwitchCustomReward>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateCustomRewardsResponse object.
    /// </summary> 
    public static TwitchCreateCustomRewardsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateCustomRewardsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_custom_rewards.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
