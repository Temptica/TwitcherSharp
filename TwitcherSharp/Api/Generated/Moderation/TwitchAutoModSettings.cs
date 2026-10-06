using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAutoModSettings : RefCounted, ITwitcherSharp<TwitchAutoModSettings>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string ModeratorId { get; set; } = null!;
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
    public static TwitchAutoModSettings? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutoModSettings
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            ModeratorId = data.Read("moderator_id", static v => v.AsString()),
            OverallLevel = data.Read("overall_level", static v => v.AsInt32()),
            Disability = data.Read("disability", static v => v.AsInt32()),
            Aggression = data.Read("aggression", static v => v.AsInt32()),
            SexualitySexOrGender = data.Read("sexuality_sex_or_gender", static v => v.AsInt32()),
            Misogyny = data.Read("misogyny", static v => v.AsInt32()),
            Bullying = data.Read("bullying", static v => v.AsInt32()),
            Swearing = data.Read("swearing", static v => v.AsInt32()),
            RaceEthnicityOrReligion = data.Read("race_ethnicity_or_religion", static v => v.AsInt32()),
            SexBasedTerms = data.Read("sex_based_terms", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_auto_mod_settings.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
        request.SetValue("overall_level", OverallLevel);
        request.SetValue("disability", Disability);
        request.SetValue("aggression", Aggression);
        request.SetValue("sexuality_sex_or_gender", SexualitySexOrGender);
        request.SetValue("misogyny", Misogyny);
        request.SetValue("bullying", Bullying);
        request.SetValue("swearing", Swearing);
        request.SetValue("race_ethnicity_or_religion", RaceEthnicityOrReligion);
        request.SetValue("sex_based_terms", SexBasedTerms);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
