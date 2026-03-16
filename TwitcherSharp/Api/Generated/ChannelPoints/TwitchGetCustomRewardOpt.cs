using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomReward 
/// </summary>
public partial class TwitchGetCustomRewardOpt : RefCounted, ITwitcherSharp<TwitchGetCustomRewardOpt>
{
    private GodotObject _data;
    public string[] Id { get; set; }
    public bool? OnlyManageableRewards { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardOpt object.
    /// </summary> 
    public static TwitchGetCustomRewardOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetCustomRewardOpt
        {
            Id = data.Get("id").AsStringArray(),
            OnlyManageableRewards = data.Get("only_manageable_rewards").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(OnlyManageableRewards.HasValue) request.Set("only_manageable_rewards", OnlyManageableRewards.Value);
        return request;
    }

}
