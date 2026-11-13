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
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            ModeratorUserId = data.ReadAsString("moderator_user_id"),
            ModeratorUserLogin = data.ReadAsString("moderator_user_login"),
            ModeratorUserName = data.ReadAsString("moderator_user_name"),
            Bullying = data.ReadAsInt32("bullying"),
            OverallLevel = data.ReadAsInt32("overall_level"),
            Disability = data.ReadAsInt32("disability"),
            RaceEthnicityOrReligion = data.ReadAsInt32("race_ethnicity_or_religion"),
            Misogyny = data.ReadAsInt32("misogyny"),
            SexualitySexOrGender = data.ReadAsInt32("sexuality_sex_or_gender"),
            Aggression = data.ReadAsInt32("aggression"),
            SexBasedTerms = data.ReadAsInt32("sex_based_terms"),
            Swearing = data.ReadAsInt32("swearing"),
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
