using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetCharityCampaignDonationsResponse : Resource, ITwitcherSharp<TwitchGetCharityCampaignDonationsResponse>
{
    private GodotObject _data;
	public TwitchCharityCampaignDonation[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignDonationsResponse object.
    /// </summary> 
    public static TwitchGetCharityCampaignDonationsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetCharityCampaignDonationsResponse
		{
			Data = dataArray.Select(TwitchCharityCampaignDonation.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign_donations.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
}
