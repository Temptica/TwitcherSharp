using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatMessageEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatMessageEvent>
{

	/// <summary> 
	/// The broadcaster user ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user ID of the user that sent the message.
	/// </summary>
	public string ChatterUserId { get; set; }

	/// <summary> 
	/// The user name of the user that sent the message.
	/// </summary>
	public string ChatterUserName { get; set; }

	/// <summary> 
	/// The user login of the user that sent the message.
	/// </summary>
	public string ChatterUserLogin { get; set; }

	/// <summary> 
	/// A UUID that identifies the message.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The structured chat message.
	/// </summary>
	public object Message { get; set; }

	/// <summary> 
	/// The chat message in plain text.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The type of message fragment. Possible values: textcheermoteemotemention
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Message text in fragment.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// Optional. Metadata pertaining to the cheermote.
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
	/// Optional. Metadata pertaining to the emote.
	/// </summary>
	public object Emote { get; set; }

	/// <summary> 
	/// An ID that uniquely identifies this emote.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// An ID that identifies the emote set that the emote belongs to.
	/// </summary>
	public string EmoteSetId { get; set; }

	/// <summary> 
	/// The ID of the broadcaster who owns the emote.
	/// </summary>
	public string OwnerId { get; set; }

	/// <summary> 
	/// Optional. Metadata pertaining to the mention.
	/// </summary>
	public object Mention { get; set; }

	/// <summary> 
	/// The user ID of the mentioned user.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user name of the mentioned user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The user login of the mentioned user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The type of message. Possible values: &lt;ul&gt;&lt;li&gt;text&lt;/li&gt;&lt;li&gt;channel_points_highlighted&lt;/li&gt;&lt;li&gt;channel_points_sub_only&lt;/li&gt;&lt;li&gt;user_intro&lt;/li&gt;&lt;li&gt;power_ups_message_effect&lt;/li&gt;&lt;li&gt;power_ups_gigantified_emote&lt;/li&gt;&lt;/ul&gt;
	/// </summary>
	public string MessageType { get; set; }

	/// <summary> 
	/// An ID that identifies this set of chat badges. For example, Bits or Subscriber.
	/// </summary>
	public string SetId { get; set; }

	/// <summary> 
	/// An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
	/// </summary>
	public string Info { get; set; }

	/// <summary> 
	/// Optional. Metadata if this message is a cheer.
	/// </summary>
	public object Cheer { get; set; }

	/// <summary> 
	/// The amount of Bits the user cheered.
	/// </summary>
	public int Bits { get; set; }

	/// <summary> 
	/// The color of the user’s name in the chat room. This is a hexadecimal RGB color code in the form, #&amp;lt;RGB&amp;gt;. This tag may be empty if it is never set.
	/// </summary>
	public string Color { get; set; }

	/// <summary> 
	/// Optional. Metadata if this message is a reply.
	/// </summary>
	public object Reply { get; set; }

	/// <summary> 
	/// An ID that uniquely identifies the parent message that this message is replying to.
	/// </summary>
	public string ParentMessageId { get; set; }

	/// <summary> 
	/// The message body of the parent message.
	/// </summary>
	public string ParentMessageBody { get; set; }

	/// <summary> 
	/// User ID of the sender of the parent message.
	/// </summary>
	public string ParentUserId { get; set; }

	/// <summary> 
	/// User name of the sender of the parent message.
	/// </summary>
	public string ParentUserName { get; set; }

	/// <summary> 
	/// User login of the sender of the parent message.
	/// </summary>
	public string ParentUserLogin { get; set; }

	/// <summary> 
	/// An ID that identifies the parent message of the reply thread.
	/// </summary>
	public string ThreadMessageId { get; set; }

	/// <summary> 
	/// User ID of the sender of the thread’s parent message.
	/// </summary>
	public string ThreadUserId { get; set; }

	/// <summary> 
	/// User name of the sender of the thread’s parent message.
	/// </summary>
	public string ThreadUserName { get; set; }

	/// <summary> 
	/// User login of the sender of the thread’s parent message.
	/// </summary>
	public string ThreadUserLogin { get; set; }

	/// <summary> 
	/// Optional. The ID of a channel points custom reward that was redeemed.
	/// </summary>
	public string ChannelPointsCustomRewardId { get; set; }

	/// <summary> 
	/// Optional. The broadcaster user ID of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserId { get; set; }

	/// <summary> 
	/// Optional. The user name of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserName { get; set; }

	/// <summary> 
	/// Optional. The login of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// Optional. The UUID that identifies the source message from the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceMessageId { get; set; }

	/// <summary> 
	/// Optional. The list of chat badges for the chatter in the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public object SourceBadges { get; set; }

	/// <summary> 
	/// The ID that identifies this set of chat badges. For example, Bits or Subscriber.
	/// </summary>
	public string SetId { get; set; }

	/// <summary> 
	/// The ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
	/// </summary>
	public string Info { get; set; }

	/// <summary> 
	/// Optional. Determines if a message delivered during a shared chat session is only sent to the source channel. Has no effect if the message is not sent during a shared chat session.
	/// </summary>
	public bool IsSourceOnly { get; set; }

	public static TwitchChannelChatMessageEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatMessageEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			ChatterUserId = data["chatter_user_id"].AsString(),
			ChatterUserName = data["chatter_user_name"].AsString(),
			ChatterUserLogin = data["chatter_user_login"].AsString(),
			MessageId = data["message_id"].AsString(),
			Message = data["message"].As<object>(),
			Text = data["text"].AsString(),
			Type = data["type"].AsString(),
			Text = data["text"].AsString(),
			Cheermote = data["cheermote"].As<object>(),
			Prefix = data["prefix"].AsString(),
			Bits = data["bits"].AsInt32(),
			Tier = data["tier"].AsInt32(),
			Emote = data["emote"].As<object>(),
			Id = data["id"].AsString(),
			EmoteSetId = data["emote_set_id"].AsString(),
			OwnerId = data["owner_id"].AsString(),
			Mention = data["mention"].As<object>(),
			UserId = data["user_id"].AsString(),
			UserName = data["user_name"].AsString(),
			UserLogin = data["user_login"].AsString(),
			MessageType = data["message_type"].AsString(),
			SetId = data["set_id"].AsString(),
			Id = data["id"].AsString(),
			Info = data["info"].AsString(),
			Cheer = data["cheer"].As<object>(),
			Bits = data["bits"].AsInt32(),
			Color = data["color"].AsString(),
			Reply = data["reply"].As<object>(),
			ParentMessageId = data["parent_message_id"].AsString(),
			ParentMessageBody = data["parent_message_body"].AsString(),
			ParentUserId = data["parent_user_id"].AsString(),
			ParentUserName = data["parent_user_name"].AsString(),
			ParentUserLogin = data["parent_user_login"].AsString(),
			ThreadMessageId = data["thread_message_id"].AsString(),
			ThreadUserId = data["thread_user_id"].AsString(),
			ThreadUserName = data["thread_user_name"].AsString(),
			ThreadUserLogin = data["thread_user_login"].AsString(),
			ChannelPointsCustomRewardId = data["channel_points_custom_reward_id"].AsString(),
			SourceBroadcasterUserId = data["source_broadcaster_user_id"].AsString(),
			SourceBroadcasterUserName = data["source_broadcaster_user_name"].AsString(),
			SourceBroadcasterUserLogin = data["source_broadcaster_user_login"].AsString(),
			SourceMessageId = data["source_message_id"].AsString(),
			SourceBadges = data["source_badges"].As<object>(),
			SetId = data["set_id"].AsString(),
			Id = data["id"].AsString(),
			Info = data["info"].AsString(),
			IsSourceOnly = data["is_source_only"].AsBool(),
		};
	}

}
