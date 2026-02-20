using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{
    /// <summary> 
    /// The text of the resubscription chat message.
    /// </summary>
    public string Text { get; set; }

    /// <summary> 
    /// An array that includes the emote ID and start and end positions for where the emote appears in the text.
    /// </summary>
    public TwitchEmotes[] Emotes { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMessage object.
    /// </summary> 
    public static TwitchMessage FromObject(GodotObject data)
    {
        if(data == null) return null;
        var emotesArray = data.Get("emotes").AsGodotArray<GodotObject>();
        return new TwitchMessage
        {
            Text = data.Get("text").AsString(),
            Emotes = emotesArray.Select(TwitchEmotes.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
        var twitchMessageClass = script.Get("TwitchMessage").AsGodotObject();
        var request = twitchMessageClass.Call("new").AsGodotObject();
        request.Set("text", Text);
        request.Set("emotes", Emotes);
        return request;
    }
}
