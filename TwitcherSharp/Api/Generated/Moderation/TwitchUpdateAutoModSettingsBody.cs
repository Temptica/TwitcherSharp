using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateAutoModSettingsBody : RefCounted, ITwitcherSharp<TwitchUpdateAutoModSettingsBody>
{
    private Variant _data;
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
    public static TwitchUpdateAutoModSettingsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateAutoModSettingsBody
        {
            Aggression = data.ReadAsInt32("aggression"),
            Bullying = data.ReadAsInt32("bullying"),
            Disability = data.ReadAsInt32("disability"),
            Misogyny = data.ReadAsInt32("misogyny"),
            OverallLevel = data.ReadAsInt32("overall_level"),
            RaceEthnicityOrReligion = data.ReadAsInt32("race_ethnicity_or_religion"),
            SexBasedTerms = data.ReadAsInt32("sex_based_terms"),
            SexualitySexOrGender = data.ReadAsInt32("sexuality_sex_or_gender"),
            Swearing = data.ReadAsInt32("swearing"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_auto_mod_settings.gd", "Body");
        if(Aggression.HasValue) request.SetValue("aggression", Aggression.Value);
        if(Bullying.HasValue) request.SetValue("bullying", Bullying.Value);
        if(Disability.HasValue) request.SetValue("disability", Disability.Value);
        if(Misogyny.HasValue) request.SetValue("misogyny", Misogyny.Value);
        if(OverallLevel.HasValue) request.SetValue("overall_level", OverallLevel.Value);
        if(RaceEthnicityOrReligion.HasValue) request.SetValue("race_ethnicity_or_religion", RaceEthnicityOrReligion.Value);
        if(SexBasedTerms.HasValue) request.SetValue("sex_based_terms", SexBasedTerms.Value);
        if(SexualitySexOrGender.HasValue) request.SetValue("sexuality_sex_or_gender", SexualitySexOrGender.Value);
        if(Swearing.HasValue) request.SetValue("swearing", Swearing.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
