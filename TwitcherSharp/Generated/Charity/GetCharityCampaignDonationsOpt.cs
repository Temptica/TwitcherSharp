using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Charity;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCharityCampaignDonations 
/// </summary>
public partial class GetCharityCampaignDonationsOpt : Resource, ITwitcherSharp<GetCharityCampaignDonationsOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCharityCampaignDonationsOpt object.
    /// </summary> 
    public static GetCharityCampaignDonationsOpt FromObject(GodotObject data)
    {
        return new GetCharityCampaignDonationsOpt
        {

			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign_donations_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
