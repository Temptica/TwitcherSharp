using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchAutoModSettings : Resource, ITwitcherSharp<TwitchAutoModSettings>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string ModeratorId { get; set; }
	public int OverallLevel { get; set; }
	public int Disability { get; set; }
	public int Aggression { get; set; }
	public int SexualitySexOrGender { get; set; }
	public int Misogyny { get; set; }
	public int Bullying { get; set; }
	public int Swearing { get; set; }
	public int RaceEthnicityOrReligion { get; set; }
	public int SexBasedTerms { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutoModSettings object.
    /// </summary> 
    public static TwitchAutoModSettings FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchAutoModSettings
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			ModeratorId = data.Get("moderator_id").AsString(),
			OverallLevel = data.Get("overall_level").AsInt32(),
			Disability = data.Get("disability").AsInt32(),
			Aggression = data.Get("aggression").AsInt32(),
			SexualitySexOrGender = data.Get("sexuality_sex_or_gender").AsInt32(),
			Misogyny = data.Get("misogyny").AsInt32(),
			Bullying = data.Get("bullying").AsInt32(),
			Swearing = data.Get("swearing").AsInt32(),
			RaceEthnicityOrReligion = data.Get("race_ethnicity_or_religion").AsInt32(),
			SexBasedTerms = data.Get("sex_based_terms").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_auto_mod_settings.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("moderator_id", ModeratorId);
		request.Set("overall_level", OverallLevel);
		request.Set("disability", Disability);
		request.Set("aggression", Aggression);
		request.Set("sexuality_sex_or_gender", SexualitySexOrGender);
		request.Set("misogyny", Misogyny);
		request.Set("bullying", Bullying);
		request.Set("swearing", Swearing);
		request.Set("race_ethnicity_or_religion", RaceEthnicityOrReligion);
		request.Set("sex_based_terms", SexBasedTerms);
		return request;
	}

}
