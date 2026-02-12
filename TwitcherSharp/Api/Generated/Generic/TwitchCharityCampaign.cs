using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCharityCampaign : Resource, ITwitcherSharp<TwitchCharityCampaign>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string BroadcasterId { get; set; }
	public string BroadcasterLogin { get; set; }
	public string BroadcasterName { get; set; }
	public string CharityName { get; set; }
	public string CharityDescription { get; set; }
	public string CharityLogo { get; set; }
	public string CharityWebsite { get; set; }
	public TwitchCurrentAmount CurrentAmount { get; set; }
	public TwitchTargetAmount TargetAmount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaign object.
    /// </summary> 
    public static TwitchCharityCampaign FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCharityCampaign
		{
			Id = data.Get("id").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			CharityName = data.Get("charity_name").AsString(),
			CharityDescription = data.Get("charity_description").AsString(),
			CharityLogo = data.Get("charity_logo").AsString(),
			CharityWebsite = data.Get("charity_website").AsString(),
			CurrentAmount = data.Get("current_amount").As<TwitchCurrentAmount>(),
			TargetAmount = data.Get("target_amount").As<TwitchTargetAmount>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_charity_campaign.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("broadcaster_login", BroadcasterLogin);
		request.Set("broadcaster_name", BroadcasterName);
		request.Set("charity_name", CharityName);
		request.Set("charity_description", CharityDescription);
		request.Set("charity_logo", CharityLogo);
		request.Set("charity_website", CharityWebsite);
		request.Set("current_amount", CurrentAmount);
		request.Set("target_amount", TargetAmount);
		return request;
	}
}
