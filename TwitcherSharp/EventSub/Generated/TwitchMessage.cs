using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

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

	public static TwitchMessage FromData(Dictionary data)
	{
	    return new TwitchMessage
	    {
			Text = data["text"].AsString(),
			Emotes = data["emotes"].AsGodotArray().Select(x => TwitchEmotes.FromData(x.AsGodotDictionary())).ToArray(),
		};
	}

}
