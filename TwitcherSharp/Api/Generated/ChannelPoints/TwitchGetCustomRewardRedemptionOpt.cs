using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;


/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomRewardRedemption 
/// </summary>
public partial class TwitchGetCustomRewardRedemptionOpt : RefCounted, ITwitcherSharp<TwitchGetCustomRewardRedemptionOpt>
{
    private Variant _data;
    public string? Status { get; set; }
    public string[]? Id { get; set; }
    public string? Sort { get; set; }
    public string? After { get; set; }
    public int? First { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardRedemptionOpt object.
    /// </summary> 
    public static TwitchGetCustomRewardRedemptionOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomRewardRedemptionOpt
        {
            Status = data.Read("status", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsStringArray()),
            Sort = data.Read("sort", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_reward_redemption.gd", "Opt");
        if(Status != null) request.SetValue("status", Status);
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(Sort != null) request.SetValue("sort", Sort);
        if(After != null) request.SetValue("after", After);
        if(First.HasValue) request.SetValue("first", First.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
