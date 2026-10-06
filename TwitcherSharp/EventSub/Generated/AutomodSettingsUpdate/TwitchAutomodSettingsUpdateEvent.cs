using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodSettingsUpdate;

public partial class TwitchAutomodSettingsUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchAutomodSettingsUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the moderator who changed the channel settings.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The moderator’s login.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The moderator’s user name.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The Automod level for hostility involving name calling or insults.
    /// </summary>
    public int Bullying { get; set; }

    /// <summary> 
    /// The default AutoMod level for the broadcaster. This field is null if the broadcaster has set one or more of the individual settings.
    /// </summary>
    public int OverallLevel { get; set; }

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

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodSettingsUpdateEvent object.
    /// </summary> 
    public static TwitchAutomodSettingsUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodSettingsUpdateEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            Bullying = data.Read("bullying", static v => v.AsInt32()),
            OverallLevel = data.Read("overall_level", static v => v.AsInt32()),
            Disability = data.Read("disability", static v => v.AsInt32()),
            RaceEthnicityOrReligion = data.Read("race_ethnicity_or_religion", static v => v.AsInt32()),
            Misogyny = data.Read("misogyny", static v => v.AsInt32()),
            SexualitySexOrGender = data.Read("sexuality_sex_or_gender", static v => v.AsInt32()),
            Aggression = data.Read("aggression", static v => v.AsInt32()),
            SexBasedTerms = data.Read("sex_based_terms", static v => v.AsInt32()),
            Swearing = data.Read("swearing", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_settings_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        request.SetValue("bullying", Bullying);
        request.SetValue("overall_level", OverallLevel);
        request.SetValue("disability", Disability);
        request.SetValue("race_ethnicity_or_religion", RaceEthnicityOrReligion);
        request.SetValue("misogyny", Misogyny);
        request.SetValue("sexuality_sex_or_gender", SexualitySexOrGender);
        request.SetValue("aggression", Aggression);
        request.SetValue("sex_based_terms", SexBasedTerms);
        request.SetValue("swearing", Swearing);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
