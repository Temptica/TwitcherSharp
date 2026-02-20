using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateAutoModSettingsBody : Resource, ITwitcherSharp<TwitchUpdateAutoModSettingsBody>
{
    private GodotObject _data;
    public int? Aggression { get; set; }
    public int? Bullying { get; set; }
    public int? Disability { get; set; }
    public int? Misogyny { get; set; }
    public int? OverallLevel { get; set; }
    public int? RaceEthnicityOrReligion { get; set; }
    public int? SexBasedTerms { get; set; }
    public int? SexualitySexOrGender { get; set; }
    public int? Swearing { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateAutoModSettingsBody object.
    /// </summary> 
    public static TwitchUpdateAutoModSettingsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUpdateAutoModSettingsBody
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_auto_mod_settings.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Aggression.HasValue) request.Set("aggression", Aggression.Value);
        if(Bullying.HasValue) request.Set("bullying", Bullying.Value);
        if(Disability.HasValue) request.Set("disability", Disability.Value);
        if(Misogyny.HasValue) request.Set("misogyny", Misogyny.Value);
        if(OverallLevel.HasValue) request.Set("overall_level", OverallLevel.Value);
        if(RaceEthnicityOrReligion.HasValue) request.Set("race_ethnicity_or_religion", RaceEthnicityOrReligion.Value);
        if(SexBasedTerms.HasValue) request.Set("sex_based_terms", SexBasedTerms.Value);
        if(SexualitySexOrGender.HasValue) request.Set("sexuality_sex_or_gender", SexualitySexOrGender.Value);
        if(Swearing.HasValue) request.Set("swearing", Swearing.Value);
        return request;
    }

}
