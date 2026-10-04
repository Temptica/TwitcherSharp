using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUpdate;

public partial class TwitchChannelUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The broadcaster’s user ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s user login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s user display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The channel’s stream title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// The channel’s broadcast language.
    /// </summary>
    public string? Language { get; set; }

    /// <summary> 
    /// The channel’s category ID.
    /// </summary>
    public string? CategoryId { get; set; }

    /// <summary> 
    /// The category name.
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary> 
    /// Array of content classification label IDs currently applied on the Channel. To retrieve a list of all possible IDs, use the Get Content Classification Labels API endpoint.
    /// </summary>
    public string[]? ContentClassificationLabels { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUpdateEvent object.
    /// </summary> 
    public static TwitchChannelUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelUpdateEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Language = data.Read("language", static v => v.AsString()),
            CategoryId = data.Read("category_id", static v => v.AsString()),
            CategoryName = data.Read("category_name", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Title != null) request.SetValue("title", Title);
        if(Language != null) request.SetValue("language", Language);
        if(CategoryId != null) request.SetValue("category_id", CategoryId);
        if(CategoryName != null) request.SetValue("category_name", CategoryName);
        if(ContentClassificationLabels != null) request.SetValue("content_classification_labels", new Godot.Collections.Array<string>(ContentClassificationLabels));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
