using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetCharityCampaignResponse : Resource, ITwitcherSharp<TwitchGetCharityCampaignResponse>
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
		request.Set("data", Data);
		return request;
	}
}
