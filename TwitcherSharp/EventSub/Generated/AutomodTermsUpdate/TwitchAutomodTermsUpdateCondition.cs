using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodTermsUpdate;

public partial class TwitchAutomodTermsUpdateCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchAutomodTermsUpdateCondition>
{
    private GodotObject? _data;
    
    public string Name => nameof(TwitchAutomodTermsUpdateCondition);

    /// <summary> 
    /// User ID of the broadcaster (channel). Maximum:1.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// User ID of the moderator creating the subscription. Maximum:1
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodTermsUpdateCondition object.
    /// </summary> 
    public static TwitchAutomodTermsUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodTermsUpdateCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_terms_update.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchAutomodTermsUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchAutomodTermsUpdateCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
            {"moderator_user_id", ModeratorUserId},
        };
    }
}
