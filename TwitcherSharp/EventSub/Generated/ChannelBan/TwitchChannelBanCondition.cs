using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBan;

public partial class TwitchChannelBanCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchChannelBanCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchChannelBanCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get ban notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBanCondition object.
    /// </summary> 
    public static TwitchChannelBanCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelBanCondition(data.Get("broadcaster_user_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_ban.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelBanCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelBanCondition(data["broadcaster_user_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
