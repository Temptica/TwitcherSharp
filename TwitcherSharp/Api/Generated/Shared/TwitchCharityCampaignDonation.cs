using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCharityCampaignDonation : Resource, ITwitcherSharp<TwitchCharityCampaignDonation>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string CampaignId { get; set; }
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public TwitchAmount Amount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignDonation object.
    /// </summary> 
    public static TwitchCharityCampaignDonation FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCharityCampaignDonation
		{
			Id = data.Get("id").AsString(),
			CampaignId = data.Get("campaign_id").AsString(),
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			Amount = data.Get("amount").As<TwitchAmount>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_charity_campaign_donation.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("campaign_id", CampaignId);
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("amount", Amount);
		return request;
	}
}
