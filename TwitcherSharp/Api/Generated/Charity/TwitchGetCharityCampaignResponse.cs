using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchGetCharityCampaignResponse : RefCounted, ITwitcherSharp<TwitchGetCharityCampaignResponse>
{
    private GodotObject _data;
    public TwitchCharityCampaign[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignResponse object.
    /// </summary> 
    public static TwitchGetCharityCampaignResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetCharityCampaignResponse
        {
            Data = dataArray.Select(TwitchCharityCampaign.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
