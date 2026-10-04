using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Goals;

public partial class TwitchGoalsCondition(string broadcasterUserId) : RefCounted, ITwitcherSharpCondition<TwitchGoalsCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchGoalsCondition);

    /// <summary> 
    /// The ID of the broadcaster to get notified about. The ID must match the user_id in the OAuth access token.
    /// </summary>
    public string BroadcasterUserId { get; set; } = broadcasterUserId;

    /// <summary> 
    /// Transforms the godot data into a TwitchGoalsCondition object.
    /// </summary> 
    public static TwitchGoalsCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGoalsCondition(data.Read("broadcaster_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_goals.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchGoalsCondition FromDictionary(Dictionary data)
    {
        return new TwitchGoalsCondition(data["broadcaster_user_id"].AsString())
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
