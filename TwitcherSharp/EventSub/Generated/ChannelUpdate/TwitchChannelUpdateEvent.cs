using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUpdate;

public partial class TwitchChannelUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelUpdateEvent>
{
    /// <summary> 
    /// The broadcaster’s user ID.
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
    /// The channel’s stream title.
    /// </summary>
    public string Title { get; set; }

    /// <summary> 
    /// The channel’s broadcast language.
    /// </summary>
    public string Language { get; set; }

    /// <summary> 
    /// The channel’s category ID.
    /// </summary>
    public string CategoryId { get; set; }

    /// <summary> 
    /// The category name.
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary> 
    /// Array of content classification label IDs currently applied on the Channel. To retrieve a list of all possible IDs, use the Get Content Classification Labels API endpoint.
    /// </summary>
    public string[] ContentClassificationLabels { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUpdateEvent object.
    /// </summary> 
    public static TwitchChannelUpdateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelUpdateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Title = data.Get("title").AsString(),
            Language = data.Get("language").AsString(),
            CategoryId = data.Get("category_id").AsString(),
            CategoryName = data.Get("category_name").AsString(),
            ContentClassificationLabels = data.Get("content_classification_labels").AsStringArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_update.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("title", Title);
        request.Set("language", Language);
        request.Set("category_id", CategoryId);
        request.Set("category_name", CategoryName);
        request.Set("content_classification_labels", ContentClassificationLabels);
        return request;
    }
}
