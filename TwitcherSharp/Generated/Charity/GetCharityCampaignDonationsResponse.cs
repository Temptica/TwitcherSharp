using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Charity;
 
/// <summary> 
///  
/// </summary>
public partial class GetCharityCampaignDonationsResponse : Resource, ITwitcherSharp<GetCharityCampaignDonationsResponse>
{
    private GodotObject _data;
	public CharityCampaignDonation[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCharityCampaignDonationsResponse object.
    /// </summary> 
    public static GetCharityCampaignDonationsResponse FromObject(GodotObject data)
    {
        return new GetCharityCampaignDonationsResponse
        {

			Data = data.Get("data").As<CharityCampaignDonation[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign_donations_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
