using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchAutomodSettingsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchAutomodSettingsUpdateEvent>
{

	/// <summary> 
	/// The ID of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user name of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The ID of the moderator who changed the channel settings.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The moderator’s login.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The moderator’s user name.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The Automod level for hostility involving name calling or insults.
	/// </summary>
	public int Bullying { get; set; }

	/// <summary> 
	/// The default AutoMod level for the broadcaster. This field is null if the broadcaster has set one or more of the individual settings.
	/// </summary>
	public int? OverallLevel { get; set; }

	/// <summary> 
	/// The Automod level for discrimination against disability.
	/// </summary>
	public int Disability { get; set; }

	/// <summary> 
	/// The Automod level for racial discrimination.
	/// </summary>
	public int RaceEthnicityOrReligion { get; set; }

	/// <summary> 
	/// The Automod level for discrimination against women.
	/// </summary>
	public int Misogyny { get; set; }

	/// <summary> 
	/// The AutoMod level for discrimination based on sexuality, sex, or gender.
	/// </summary>
	public int SexualitySexOrGender { get; set; }

	/// <summary> 
	/// The Automod level for hostility involving aggression.
	/// </summary>
	public int Aggression { get; set; }

	/// <summary> 
	/// The Automod level for sexual content.
	/// </summary>
	public int SexBasedTerms { get; set; }

	/// <summary> 
	/// The Automod level for profanity.
	/// </summary>
	public int Swearing { get; set; }

	public static TwitchAutomodSettingsUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchAutomodSettingsUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			Bullying = data["bullying"].AsInt32(),
			OverallLevel = data["overall_level"].As<int?>(),
			Disability = data["disability"].AsInt32(),
			RaceEthnicityOrReligion = data["race_ethnicity_or_religion"].AsInt32(),
			Misogyny = data["misogyny"].AsInt32(),
			SexualitySexOrGender = data["sexuality_sex_or_gender"].AsInt32(),
			Aggression = data["aggression"].AsInt32(),
			SexBasedTerms = data["sex_based_terms"].AsInt32(),
			Swearing = data["swearing"].AsInt32(),
		};
	}

}
