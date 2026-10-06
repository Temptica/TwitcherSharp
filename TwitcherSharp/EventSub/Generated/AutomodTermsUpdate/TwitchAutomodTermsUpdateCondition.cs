using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodTermsUpdate;

public partial class TwitchAutomodTermsUpdateCondition(string broadcasterUserId, string moderatorUserId) : RefCounted, ITwitcherSharpCondition<TwitchAutomodTermsUpdateCondition>
{
    private Variant _data;
    
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
        var instance = new TwitchAutomodTermsUpdateCondition(data.Read("broadcaster_user_id", static v => v.AsString()), data.Read("moderator_user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_terms_update.gd", "Condition");
        request.SetValue("broadcaster_user_id", BroadcasterUserId);
        request.SetValue("moderator_user_id", ModeratorUserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
