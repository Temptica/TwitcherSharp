using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
{
    private Variant _data;
    
    /// <summary> 
    /// The text of the resubscription chat message.
    /// </summary>
    public string? Text { get; set; }

    /// <summary> 
    /// An array that includes the emote ID and start and end positions for where the emote appears in the text.
    /// </summary>
    public TwitchEmotes[]? Emotes { get => field ??= _data.GetArray<TwitchEmotes>("emotes"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMessage object.
    /// </summary> 
    public static TwitchMessage? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchMessage
        {
            Text = data.Read("text", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
        if(Text != null) request.SetValue("text", Text);
        if(Emotes != null) request.SetArray("emotes", Emotes);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
