using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Charity;
 
/// <summary> 
///  
/// </summary>
public partial class GetCharityCampaignResponse : Resource, ITwitcherSharp<GetCharityCampaignResponse>
{
    private GodotObject _data;
	public CharityCampaign[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCharityCampaignResponse object.
    /// </summary> 
    public static GetCharityCampaignResponse FromObject(GodotObject data)
    {
        return new GetCharityCampaignResponse
        {

			Data = data.Get("data").As<CharityCampaign[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
