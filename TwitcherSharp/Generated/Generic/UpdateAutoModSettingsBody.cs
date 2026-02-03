using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateAutoModSettingsBody : Resource, ITwitcherSharp<UpdateAutoModSettingsBody>
{
    private GodotObject _data;
	public int Aggression { get; set; }
	public int Bullying { get; set; }
	public int Disability { get; set; }
	public int Misogyny { get; set; }
	public int OverallLevel { get; set; }
	public int RaceEthnicityOrReligion { get; set; }
	public int SexBasedTerms { get; set; }
	public int SexualitySexOrGender { get; set; }
	public int Swearing { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateAutoModSettingsBody object.
    /// </summary> 
    public static UpdateAutoModSettingsBody FromObject(GodotObject data)
    {
        return new UpdateAutoModSettingsBody
        {

			Aggression = data.Get("aggression").AsInt32(),
			Bullying = data.Get("bullying").AsInt32(),
			Disability = data.Get("disability").AsInt32(),
			Misogyny = data.Get("misogyny").AsInt32(),
			OverallLevel = data.Get("overall_level").AsInt32(),
			RaceEthnicityOrReligion = data.Get("race_ethnicity_or_religion").AsInt32(),
			SexBasedTerms = data.Get("sex_based_terms").AsInt32(),
			SexualitySexOrGender = data.Get("sexuality_sex_or_gender").AsInt32(),
			Swearing = data.Get("swearing").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_auto_mod_settings_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("aggression", Aggression);
		request.Set("bullying", Bullying);
		request.Set("disability", Disability);
		request.Set("misogyny", Misogyny);
		request.Set("overall_level", OverallLevel);
		request.Set("race_ethnicity_or_religion", RaceEthnicityOrReligion);
		request.Set("sex_based_terms", SexBasedTerms);
		request.Set("sexuality_sex_or_gender", SexualitySexOrGender);
		request.Set("swearing", Swearing);
		return request;
	}
}
