using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomReward 
/// </summary>
public partial class TwitchGetCustomRewardOpt : RefCounted, ITwitcherSharp<TwitchGetCustomRewardOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public bool? OnlyManageableRewards { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardOpt object.
    /// </summary> 
    public static TwitchGetCustomRewardOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomRewardOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
            OnlyManageableRewards = data.Read("only_manageable_rewards", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_reward.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(OnlyManageableRewards.HasValue) request.SetValue("only_manageable_rewards", OnlyManageableRewards.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
