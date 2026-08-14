using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The text of the resubscription chat message.
    /// </summary>
    public string? Text { get; set; }

    /// <summary> 
    /// An array that includes the emote ID and start and end positions for where the emote appears in the text.
    /// </summary>
    public TwitchEmotes[]? Emotes { get => field ??= _data?.GetArray<TwitchEmotes>("emotes"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMessage object.
    /// </summary> 
    public static TwitchMessage? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchMessage
        {
            Text = data.Get("text").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
        var request = script.New().AsGodotObject();
        if(Text != null) request.Set("text", Text);
        if(Emotes != null) request.Set("emotes", Emotes.ToGodotArray());
        return request;
    }
}
