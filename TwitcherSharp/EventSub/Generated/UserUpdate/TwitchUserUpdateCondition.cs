using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserUpdate;

public partial class TwitchUserUpdateCondition(string userId) : RefCounted, ITwitcherSharpCondition<TwitchUserUpdateCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchUserUpdateCondition);

    /// <summary> 
    /// The user ID for the user you want update notifications for.
    /// </summary>
    public string UserId { get; set; } = userId;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserUpdateCondition object.
    /// </summary> 
    public static TwitchUserUpdateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUserUpdateCondition(data.Get("user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_update.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        return request;
    }

    public static TwitchUserUpdateCondition FromDictionary(Dictionary data)
    {
        return new TwitchUserUpdateCondition(data["user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"user_id", UserId},
        };
    }
}
