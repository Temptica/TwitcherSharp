using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchDataObject : Resource, ITwitcherSharpEventSub<TwitchDataObject>
{

	/// <summary> 
	/// The ID of the organization that owns the game that has Drops enabled.
	/// </summary>
	public string OrganizationId { get; set; }

	/// <summary> 
	/// Twitch category ID of the game that was being played when this benefit was entitled.
	/// </summary>
	public string CategoryId { get; set; }

	/// <summary> 
	/// The category name.
	/// </summary>
	public string CategoryName { get; set; }

	/// <summary> 
	/// The campaign this entitlement is associated with.
	/// </summary>
	public string CampaignId { get; set; }

	/// <summary> 
	/// Twitch user ID of the user who was granted the entitlement.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user display name of the user who was granted the entitlement.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The user login of the user who was granted the entitlement.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// Unique identifier of the entitlement. Use this to de-duplicate entitlements.
	/// </summary>
	public string EntitlementId { get; set; }

	/// <summary> 
	/// Identifier of the Benefit.
	/// </summary>
	public string BenefitId { get; set; }

	/// <summary> 
	/// UTC timestamp in ISO format when this entitlement was granted on Twitch.
	/// </summary>
	public string CreatedAt { get; set; }

	public static TwitchDataObject FromData(Dictionary data)
	{
	    return new TwitchDataObject
	    {
			OrganizationId = data["organization_id"].AsString(),
			CategoryId = data["category_id"].AsString(),
			CategoryName = data["category_name"].AsString(),
			CampaignId = data["campaign_id"].AsString(),
			UserId = data["user_id"].AsString(),
			UserName = data["user_name"].AsString(),
			UserLogin = data["user_login"].AsString(),
			EntitlementId = data["entitlement_id"].AsString(),
			BenefitId = data["benefit_id"].AsString(),
			CreatedAt = data["created_at"].AsString(),
		};
	}

}
