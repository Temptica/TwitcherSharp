using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCharityCampaignDonations 
/// </summary>
public partial class TwitchGetCharityCampaignDonationsOpt : Resource, ITwitcherSharp<TwitchGetCharityCampaignDonationsOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignDonationsOpt object.
    /// </summary> 
    public static TwitchGetCharityCampaignDonationsOpt FromObject(GodotObject data)
    {
		return new TwitchGetCharityCampaignDonationsOpt
		{
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign_donations.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
