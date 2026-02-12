using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchCharityCampaignStartEvent : Resource, ITwitcherSharpEventSub<TwitchCharityCampaignStartEvent>
{

	/// <summary> 
	/// An ID that identifies the charity campaign.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// An ID that identifies the broadcaster that’s running the campaign.
	/// </summary>
	public string BroadcasterId { get; set; }

	/// <summary> 
	/// The broadcaster’s login name.
	/// </summary>
	public string BroadcasterLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s display name.
	/// </summary>
	public string BroadcasterName { get; set; }

	/// <summary> 
	/// The charity’s name.
	/// </summary>
	public string CharityName { get; set; }

	/// <summary> 
	/// A description of the charity.
	/// </summary>
	public string CharityDescription { get; set; }

	/// <summary> 
	/// A URL to an image of the charity’s logo. The image’s type is PNG and its size is 100px X 100px.
	/// </summary>
	public string CharityLogo { get; set; }

	/// <summary> 
	/// A URL to the charity’s website.
	/// </summary>
	public string CharityWebsite { get; set; }

	/// <summary> 
	/// An object that contains the current amount of donations that the campaign has received.
	/// </summary>
	public TwitchCurrentAmount CurrentAmount { get; set; }

	/// <summary> 
	/// An object that contains the campaign’s target fundraising goal.
	/// </summary>
	public TwitchTargetAmount TargetAmount { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the broadcaster started the campaign.
	/// </summary>
	public string StartedAt { get; set; }

	public static TwitchCharityCampaignStartEvent FromData(Dictionary data)
	{
	    return new TwitchCharityCampaignStartEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterId = data["broadcaster_id"].AsString(),
			BroadcasterLogin = data["broadcaster_login"].AsString(),
			BroadcasterName = data["broadcaster_name"].AsString(),
			CharityName = data["charity_name"].AsString(),
			CharityDescription = data["charity_description"].AsString(),
			CharityLogo = data["charity_logo"].AsString(),
			CharityWebsite = data["charity_website"].AsString(),
			CurrentAmount = TwitchCurrentAmount.FromData(data["current_amount"].AsGodotDictionary()),
			TargetAmount = TwitchTargetAmount.FromData(data["target_amount"].AsGodotDictionary()),
			StartedAt = data["started_at"].AsString(),
		};
	}

public partial class TwitchCurrentAmount : Resource, ITwitcherSharpEventSub<TwitchCurrentAmount>
{

	/// <summary> 
	/// The monetary amount. The amount is specified in the currency’s minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
	/// </summary>
	public int Value { get; set; }

	/// <summary> 
	/// The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate value from minor units to major units by using the formula:value / 10^decimal_places
	/// </summary>
	public int DecimalPlaces { get; set; }

	/// <summary> 
	/// The ISO-4217 three-letter currency code that identifies the type of currency in value.
	/// </summary>
	public string Currency { get; set; }

	public static TwitchCurrentAmount FromData(Dictionary data)
	{
	    return new TwitchCurrentAmount
	    {
			Value = data["value"].AsInt32(),
			DecimalPlaces = data["decimal_places"].AsInt32(),
			Currency = data["currency"].AsString(),
		};
	}

}
public partial class TwitchTargetAmount : Resource, ITwitcherSharpEventSub<TwitchTargetAmount>
{

	/// <summary> 
	/// The monetary amount. The amount is specified in the currency’s minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
	/// </summary>
	public int Value { get; set; }

	/// <summary> 
	/// The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate value from minor units to major units by using the formula:value / 10^decimal_places
	/// </summary>
	public int DecimalPlaces { get; set; }

	/// <summary> 
	/// The ISO-4217 three-letter currency code that identifies the type of currency in value.
	/// </summary>
	public string Currency { get; set; }

	public static TwitchTargetAmount FromData(Dictionary data)
	{
	    return new TwitchTargetAmount
	    {
			Value = data["value"].AsInt32(),
			DecimalPlaces = data["decimal_places"].AsInt32(),
			Currency = data["currency"].AsString(),
		};
	}

}

}
