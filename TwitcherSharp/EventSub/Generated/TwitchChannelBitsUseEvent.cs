using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelBitsUseEvent : Resource, ITwitcherSharpEventSub<TwitchChannelBitsUseEvent>
{

	/// <summary> 
	/// The User ID of the channel where the Bits were redeemed.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the channel where the Bits were used.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The display name of the channel where the Bits were used.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The User ID of the redeeming user.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login name of the redeeming user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The display name of the redeeming user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The number of Bits used.
	/// </summary>
	public int Bits { get; set; }

	/// <summary> 
	/// Possible values are: cheerpower_up
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Optional. An object that contains the user message and emote information needed to recreate the message.
	/// </summary>
	public object Message { get; set; }
	/// <summary> 
	/// The chat message in plain text.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The message text in fragment.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The type of message fragment. Possible values are: textcheermoteemote
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Optional. The metadata pertaining to the emote.
	/// </summary>
	public object Emote { get; set; }

	/// <summary> 
	/// The ID that uniquely identifies this emote.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The ID that identifies the emote set that the emote belongs to.
	/// </summary>
	public string EmoteSetId { get; set; }

	/// <summary> 
	/// The ID of the broadcaster who owns the emote.
	/// </summary>
	public string OwnerId { get; set; }

	/// <summary> 
	/// The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated. The possible formats are: animated - An animated GIF is available for this emote.static - A static PNG file is available for this emote.
	/// </summary>
	public []string Format { get; set; }

	/// <summary> 
	/// Optional. The metadata pertaining to the cheermote.
	/// </summary>
	public object Cheermote { get; set; }

	/// <summary> 
	/// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
	/// </summary>
	public string Prefix { get; set; }

	/// <summary> 
	/// The amount of Bits cheered.
	/// </summary>
	public int Bits { get; set; }

	/// <summary> 
	/// The tier level of the cheermote.
	/// </summary>
	public int Tier { get; set; }

	/// <summary> 
	/// Optional. Data about Power-up.
	/// </summary>
	public object PowerUp { get; set; }

	/// <summary> 
	/// Possible values: message_effectcelebrationgigantify_an_emote
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Optional. Emote associated with the reward.
	/// </summary>
	public object Emote { get; set; }

	/// <summary> 
	/// The ID that uniquely identifies this emote.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The human readable emote token.
	/// </summary>
	public string Name { get; set; }

	/// <summary> 
	/// Optional. The ID of the message effect.
	/// </summary>
	public string MessageEffectId { get; set; }

	public static TwitchChannelBitsUseEvent FromData(Dictionary data)
	{
	    return new TwitchChannelBitsUseEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Bits = data["bits"].AsInt32(),
			Type = data["type"].AsString(),
			Message = data["message"].As<object>(),
			Text = data["text"].AsString(),
			Text = data["text"].AsString(),
			Type = data["type"].AsString(),
			Emote = data["emote"].As<object>(),
			Id = data["id"].AsString(),
			EmoteSetId = data["emote_set_id"].AsString(),
			OwnerId = data["owner_id"].AsString(),
			Format = data["format"].As<[]string>(),
			Cheermote = data["cheermote"].As<object>(),
			Prefix = data["prefix"].AsString(),
			Bits = data["bits"].AsInt32(),
			Tier = data["tier"].AsInt32(),
			PowerUp = data["power_up"].As<object>(),
			Type = data["type"].AsString(),
			Emote = data["emote"].As<object>(),
			Id = data["id"].AsString(),
			Name = data["name"].AsString(),
			MessageEffectId = data["message_effect_id"].AsString(),
		};
	}

}
