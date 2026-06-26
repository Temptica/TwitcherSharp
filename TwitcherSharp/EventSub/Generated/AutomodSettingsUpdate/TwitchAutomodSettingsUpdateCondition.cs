using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodSettingsUpdate;

public partial class TwitchAutomodSettingsUpdateCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchAutomodSettingsUpdateCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchAutomodSettingsUpdateCondition);

    /// <summary> 
    /// User ID of the broadcaster (channel). Maximum:1.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// User ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; } = moderatorUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodSettingsUpdateCondition object.
    /// </summary> 
    public static TwitchAutomodSettingsUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodSettingsUpdateCondition(data.Get("broadcaster_user_id").AsString(), data.Get("moderator_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_settings_update.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("moderator_user_id", ModeratorUserId);
        return request;
    }

    public static TwitchAutomodSettingsUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchAutomodSettingsUpdateCondition(data["broadcaster_user_id"].AsString(), data["moderator_user_id"].AsString())
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
