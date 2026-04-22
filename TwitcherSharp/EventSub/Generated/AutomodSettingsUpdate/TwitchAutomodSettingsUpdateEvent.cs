using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodSettingsUpdate;

public partial class TwitchAutomodSettingsUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchAutomodSettingsUpdateEvent>
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
    public static TwitchAutomodSettingsUpdateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAutomodSettingsUpdateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            Bullying = data.Get("bullying").AsInt32(),
            OverallLevel = data.Get("overall_level").AsInt32(),
            Disability = data.Get("disability").AsInt32(),
            RaceEthnicityOrReligion = data.Get("race_ethnicity_or_religion").AsInt32(),
            Misogyny = data.Get("misogyny").AsInt32(),
            SexualitySexOrGender = data.Get("sexuality_sex_or_gender").AsInt32(),
            Aggression = data.Get("aggression").AsInt32(),
            SexBasedTerms = data.Get("sex_based_terms").AsInt32(),
            Swearing = data.Get("swearing").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_settings_update.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("bullying", Bullying);
        request.Set("overall_level", OverallLevel);
        request.Set("disability", Disability);
        request.Set("race_ethnicity_or_religion", RaceEthnicityOrReligion);
        request.Set("misogyny", Misogyny);
        request.Set("sexuality_sex_or_gender", SexualitySexOrGender);
        request.Set("aggression", Aggression);
        request.Set("sex_based_terms", SexBasedTerms);
        request.Set("swearing", Swearing);
        return request;
    }
}
