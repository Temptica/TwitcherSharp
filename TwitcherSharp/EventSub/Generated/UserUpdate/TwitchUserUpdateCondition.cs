using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserUpdate;

public partial class TwitchUserUpdateCondition(string userId) : RefCounted, ITwitcherSharpCondition<TwitchUserUpdateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchUserUpdateCondition);

    /// <summary> 
    /// The user ID for the user you want update notifications for.
    /// </summary>
    public string UserId { get; set; } = userId;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserUpdateCondition object.
    /// </summary> 
    public static TwitchUserUpdateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserUpdateCondition(data.Read("user_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_user_update.gd", "Condition");
        request.SetValue("user_id", UserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
