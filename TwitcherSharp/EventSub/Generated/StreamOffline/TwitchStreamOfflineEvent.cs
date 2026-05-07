using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOffline;

public partial class TwitchStreamOfflineEvent : RefCounted, ITwitcherSharpEventSub<TwitchStreamOfflineEvent>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The broadcaster’s user id.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s user login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s user display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOfflineEvent object.
    /// </summary> 
    public static TwitchStreamOfflineEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamOfflineEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_stream_offline.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        return request;
    }
}
