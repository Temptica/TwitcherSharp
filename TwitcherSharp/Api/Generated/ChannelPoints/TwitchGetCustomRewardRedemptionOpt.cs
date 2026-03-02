using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomRewardRedemption 
/// </summary>
public partial class TwitchGetCustomRewardRedemptionOpt : Resource, ITwitcherSharp<TwitchGetCustomRewardRedemptionOpt>
{
    private GodotObject _data;
    public string Status { get; set; }
    public string[] Id { get; set; }
    public string Sort { get; set; }
    public string After { get; set; }
    public int? First { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardRedemptionOpt object.
    /// </summary> 
    public static TwitchGetCustomRewardRedemptionOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetCustomRewardRedemptionOpt
        {
            Status = data.Get("status").AsString(),
            Id = data.Get("id").AsStringArray(),
            Sort = data.Get("sort").AsString(),
            After = data.Get("after").AsString(),
            First = data.Get("first").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_redemption.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Status != null) request.Set("status", Status);
        if(Id != null) request.Set("id", Id);
        if(Sort != null) request.Set("sort", Sort);
        if(After != null) request.Set("after", After);
        if(First.HasValue) request.Set("first", First.Value);
        return request;
    }

}
