using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatNotificationEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatNotificationEvent>
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
	/// The user login of the user that sent the message.
	/// </summary>
	public string ChatterUserName { get; set; }

	/// <summary> 
	/// Whether or not the chatter is anonymous.
	/// </summary>
	public bool ChatterIsAnonymous { get; set; }

	/// <summary> 
	/// The color of the user’s name in the chat room.
	/// </summary>
	public string Color { get; set; }

	/// <summary> 
	/// The color of the user’s name in the chat room.
	/// </summary>
	public TwitchBadges[] Badges { get; set; }

	/// <summary> 
	/// The message Twitch shows in the chat room for this notice.
	/// </summary>
	public string SystemMessage { get; set; }

	/// <summary> 
	/// A UUID that identifies the message.
	/// </summary>
	public string MessageId { get; set; }

	/// <summary> 
	/// The structured chat message.
	/// </summary>
	public TwitchMessage Message { get; set; }

	/// <summary> 
	/// The type of notice. Possible values are: subresubsub_giftcommunity_sub_giftgift_paid_upgradeprime_paid_upgraderaidunraidpay_it_forwardannouncementbits_badge_tiercharity_donationshared_chat_subshared_chat_resubshared_chat_sub_giftshared_chat_community_sub_giftshared_chat_gift_paid_upgradeshared_chat_prime_paid_upgradeshared_chat_raidshared_chat_pay_it_forwardshared_chat_announcement
	/// </summary>
	public string NoticeType { get; set; }

	/// <summary> 
	/// Information about the sub event. Null if notice_type is not sub.
	/// </summary>
	public TwitchSub Sub { get; set; }

	/// <summary> 
	/// Information about the resub event. Null if notice_type is not resub.
	/// </summary>
	public TwitchResub Resub { get; set; }

	/// <summary> 
	/// Information about the gift sub event. Null if notice_type is not sub_gift.
	/// </summary>
	public TwitchSubGift SubGift { get; set; }

	/// <summary> 
	/// Information about the community gift sub event. Null if notice_type is not community_sub_gift.
	/// </summary>
	public TwitchCommunitySubGift CommunitySubGift { get; set; }

	/// <summary> 
	/// Information about the community gift paid upgrade event. Null if notice_type is not gift_paid_upgrade.
	/// </summary>
	public TwitchGiftPaidUpgrade GiftPaidUpgrade { get; set; }

	/// <summary> 
	/// Information about the Prime gift paid upgrade event. Null if notice_type is not prime_paid_upgrade
	/// </summary>
	public TwitchPrimePaidUpgrade PrimePaidUpgrade { get; set; }

	/// <summary> 
	/// Information about the pay it forward event. Null if notice_type is not pay_it_forward
	/// </summary>
	public TwitchPayItForward PayItForward { get; set; }

	/// <summary> 
	/// Information about the raid event. Null if notice_type is not raid
	/// </summary>
	public TwitchRaid Raid { get; set; }

	/// <summary> 
	/// Returns an empty payload if  notice_type is not unraid, otherwise returns null.
	/// </summary>
	public TwitchUnraid Unraid { get; set; }

	/// <summary> 
	/// Information about the announcement event. Null if notice_type is not {::nomarkdown}announcement
	/// </summary>
	public TwitchAnnouncement Announcement { get; set; }

	/// <summary> 
	/// Information about the Bits badge tier event. Null if notice_type is not bits_badge_tier
	/// </summary>
	public TwitchBitsBadgeTier BitsBadgeTier { get; set; }

	/// <summary> 
	/// Information about the announcement event. Null if notice_type is not charity_donation
	/// </summary>
	public string CharityDonation { get; set; }

	/// <summary> 
	/// Name of the charity.
	/// </summary>
	public string CharityName { get; set; }

	/// <summary> 
	/// An object that contains the amount of money that the user paid.
	/// </summary>
	public TwitchAmount Amount { get; set; }

	/// <summary> 
	/// Optional. The broadcaster user ID of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserId { get; set; }

	/// <summary> 
	/// Optional. The user name of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserName { get; set; }

	/// <summary> 
	/// Optional. The login of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// Optional. The UUID that identifies the source message from the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public string SourceMessageId { get; set; }

	/// <summary> 
	/// Optional. The list of chat badges for the chatter in the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
	/// </summary>
	public TwitchSourceBadges SourceBadges { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_sub event. Is null if notice_type is not shared_chat_sub. This field has the same information as the sub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatSub SharedChatSub { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_resub event. Is null if notice_type is not shared_chat_resub. This field has the same information as the resub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatResub SharedChatResub { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_sub_gift event. Is null if notice_type is not shared_chat_sub_gift. This field has the same information as the chat_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatSubGift SharedChatSubGift { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_community_sub_gift event. Is null if notice_type is not shared_chat_community_sub_gift. This field has the same information as the community_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatCommunitySubGift SharedChatCommunitySubGift { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_gift_paid_upgrade event. Is null if notice_type is not shared_chat_gift_paid_upgrade. This field has the same information as the gift_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatGiftPaidUpgrade SharedChatGiftPaidUpgrade { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_chat_prime_paid_upgrade event. Is null if notice_type is not shared_chat_prime_paid_upgrade. This field has the same information as the prime_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatPrimePaidUpgrade SharedChatPrimePaidUpgrade { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_pay_it_forward event. Is null if notice_type is not shared_chat_pay_it_forward. This field has the same information as the pay_it_forward field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatPayItForward SharedChatPayItForward { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_raid event. Is null if notice_type is not shared_chat_raid. This field has the same information as the raid field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatRaid SharedChatRaid { get; set; }

	/// <summary> 
	/// Optional. Information about the shared_chat_announcement event. Is null if notice_type is not shared_chat_announcement. This field has the same information as the announcement field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
	/// </summary>
	public TwitchSharedChatAnnouncement SharedChatAnnouncement { get; set; }

	public static TwitchChannelChatNotificationEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatNotificationEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			ChatterUserId = data["chatter_user_id"].AsString(),
			ChatterUserName = data["chatter_user_name"].AsString(),
			ChatterIsAnonymous = data["chatter_is_anonymous"].AsBool(),
			Color = data["color"].AsString(),
			Badges = data["badges"].AsGodotArray().Select(x => TwitchBadges.FromData(x.AsGodotDictionary())).ToArray(),
			SystemMessage = data["system_message"].AsString(),
			MessageId = data["message_id"].AsString(),
			Message = TwitchMessage.FromData(data["message"].AsGodotDictionary()),
			NoticeType = data["notice_type"].AsString(),
			Sub = TwitchSub.FromData(data["sub"].AsGodotDictionary()),
			Resub = TwitchResub.FromData(data["resub"].AsGodotDictionary()),
			SubGift = TwitchSubGift.FromData(data["sub_gift"].AsGodotDictionary()),
			CommunitySubGift = TwitchCommunitySubGift.FromData(data["community_sub_gift"].AsGodotDictionary()),
			GiftPaidUpgrade = TwitchGiftPaidUpgrade.FromData(data["gift_paid_upgrade"].AsGodotDictionary()),
			PrimePaidUpgrade = TwitchPrimePaidUpgrade.FromData(data["prime_paid_upgrade"].AsGodotDictionary()),
			PayItForward = TwitchPayItForward.FromData(data["pay_it_forward"].AsGodotDictionary()),
			Raid = TwitchRaid.FromData(data["raid"].AsGodotDictionary()),
			Unraid = TwitchUnraid.FromData(data["unraid"].AsGodotDictionary()),
			Announcement = TwitchAnnouncement.FromData(data["announcement"].AsGodotDictionary()),
			BitsBadgeTier = TwitchBitsBadgeTier.FromData(data["bits_badge_tier"].AsGodotDictionary()),
			CharityDonation = data["charity_donation"].AsString(),
			CharityName = data["charity_name"].AsString(),
			Amount = TwitchAmount.FromData(data["amount"].AsGodotDictionary()),
			SourceBroadcasterUserId = data["source_broadcaster_user_id"].AsString(),
			SourceBroadcasterUserName = data["source_broadcaster_user_name"].AsString(),
			SourceBroadcasterUserLogin = data["source_broadcaster_user_login"].AsString(),
			SourceMessageId = data["source_message_id"].AsString(),
			SourceBadges = TwitchSourceBadges.FromData(data["source_badges"].AsGodotDictionary()),
			SharedChatSub = TwitchSharedChatSub.FromData(data["shared_chat_sub"].AsGodotDictionary()),
			SharedChatResub = TwitchSharedChatResub.FromData(data["shared_chat_resub"].AsGodotDictionary()),
			SharedChatSubGift = TwitchSharedChatSubGift.FromData(data["shared_chat_sub_gift"].AsGodotDictionary()),
			SharedChatCommunitySubGift = TwitchSharedChatCommunitySubGift.FromData(data["shared_chat_community_sub_gift"].AsGodotDictionary()),
			SharedChatGiftPaidUpgrade = TwitchSharedChatGiftPaidUpgrade.FromData(data["shared_chat_gift_paid_upgrade"].AsGodotDictionary()),
			SharedChatPrimePaidUpgrade = TwitchSharedChatPrimePaidUpgrade.FromData(data["shared_chat_prime_paid_upgrade"].AsGodotDictionary()),
			SharedChatPayItForward = TwitchSharedChatPayItForward.FromData(data["shared_chat_pay_it_forward"].AsGodotDictionary()),
			SharedChatRaid = TwitchSharedChatRaid.FromData(data["shared_chat_raid"].AsGodotDictionary()),
			SharedChatAnnouncement = TwitchSharedChatAnnouncement.FromData(data["shared_chat_announcement"].AsGodotDictionary()),
		};
	}

public partial class TwitchBadges : Resource, ITwitcherSharpEventSub<TwitchBadges>
{

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

	public static TwitchBadges FromData(Dictionary data)
	{
	    return new TwitchBadges
	    {
			SetId = data["set_id"].AsString(),
			Id = data["id"].AsString(),
			Info = data["info"].AsString(),
		};
	}

}
public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
{

	/// <summary> 
	/// The chat message in plain text.
	/// </summary>
	public TwitchText Text { get; set; }

	/// <summary> 
	/// Ordered list of chat message fragments.
	/// </summary>
	public TwitchFragments[] Fragments { get; set; }

	public static TwitchMessage FromData(Dictionary data)
	{
	    return new TwitchMessage
	    {
			Text = TwitchText.FromData(data["text"].AsGodotDictionary()),
			Fragments = data["fragments"].AsGodotArray().Select(x => TwitchFragments.FromData(x.AsGodotDictionary())).ToArray(),
		};
	}

	public partial class TwitchText : Resource, ITwitcherSharpEventSub<TwitchText>
	{
	
		public static TwitchText FromData(Dictionary data)
		{
		    return new TwitchText
		    {
			};
		}
	
}
	public partial class TwitchFragments : Resource, ITwitcherSharpEventSub<TwitchFragments>
	{
	
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
		public TwitchCheermote Cheermote { get; set; }
	
		/// <summary> 
		/// Optional. Metadata pertaining to the emote.
		/// </summary>
		public TwitchEmote Emote { get; set; }
	
		/// <summary> 
		/// Optional.  Metadata pertaining to the mention.
		/// </summary>
		public TwitchMention Mention { get; set; }
	
		public static TwitchFragments FromData(Dictionary data)
		{
		    return new TwitchFragments
		    {
				Type = data["type"].AsString(),
				Text = data["text"].AsString(),
				Cheermote = TwitchCheermote.FromData(data["cheermote"].AsGodotDictionary()),
				Emote = TwitchEmote.FromData(data["emote"].AsGodotDictionary()),
				Mention = TwitchMention.FromData(data["mention"].AsGodotDictionary()),
			};
		}
	
			public partial class TwitchCheermote : Resource, ITwitcherSharpEventSub<TwitchCheermote>
			{
			
				/// <summary> 
				/// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
				/// </summary>
				public TwitchPrefix Prefix { get; set; }
			
				/// <summary> 
				/// The amount of Bits cheered.
				/// </summary>
				public int Bits { get; set; }
			
				/// <summary> 
				/// The tier level of the cheermote.
				/// </summary>
				public int Tier { get; set; }
			
				public static TwitchCheermote FromData(Dictionary data)
				{
				    return new TwitchCheermote
				    {
						Prefix = TwitchPrefix.FromData(data["prefix"].AsGodotDictionary()),
						Bits = data["bits"].AsInt32(),
						Tier = data["tier"].AsInt32(),
					};
				}
			
						public partial class TwitchPrefix : Resource, ITwitcherSharpEventSub<TwitchPrefix>
						{
						
							public static TwitchPrefix FromData(Dictionary data)
							{
							    return new TwitchPrefix
							    {
								};
							}
						
			}
			
	}
			public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
			{
			
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
			
				public static TwitchEmote FromData(Dictionary data)
				{
				    return new TwitchEmote
				    {
						Id = data["id"].AsString(),
						EmoteSetId = data["emote_set_id"].AsString(),
						OwnerId = data["owner_id"].AsString(),
					};
				}
			
	}
			public partial class TwitchMention : Resource, ITwitcherSharpEventSub<TwitchMention>
			{
			
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
			
				public static TwitchMention FromData(Dictionary data)
				{
				    return new TwitchMention
				    {
						UserId = data["user_id"].AsString(),
						UserName = data["user_name"].AsString(),
						UserLogin = data["user_login"].AsString(),
					};
				}
			
	}
	
}

}
public partial class TwitchSub : Resource, ITwitcherSharpEventSub<TwitchSub>
{

	/// <summary> 
	/// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
	/// </summary>
	public string SubTier { get; set; }

	/// <summary> 
	/// Indicates if the subscription was obtained through Amazon Prime.
	/// </summary>
	public bool IsPrime { get; set; }

	/// <summary> 
	/// The number of months the subscription is for.
	/// </summary>
	public int DurationMonths { get; set; }

	public static TwitchSub FromData(Dictionary data)
	{
	    return new TwitchSub
	    {
			SubTier = data["sub_tier"].AsString(),
			IsPrime = data["is_prime"].AsBool(),
			DurationMonths = data["duration_months"].AsInt32(),
		};
	}

}
public partial class TwitchResub : Resource, ITwitcherSharpEventSub<TwitchResub>
{

	/// <summary> 
	/// The total number of months the user has subscribed.
	/// </summary>
	public int CumulativeMonths { get; set; }

	/// <summary> 
	/// The number of months the subscription is for.
	/// </summary>
	public int DurationMonths { get; set; }

	/// <summary> 
	/// The total number of months the user has subscribed.
	/// </summary>
	public int StreakMonths { get; set; }

	/// <summary> 
	/// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
	/// </summary>
	public string SubTier { get; set; }

	/// <summary> 
	/// Optional. The number of consecutive months the user has subscribed.
	/// </summary>
	public bool IsPrime { get; set; }

	/// <summary> 
	/// Whether or not the resub was a result of a gift.
	/// </summary>
	public bool IsGift { get; set; }

	/// <summary> 
	/// Optional. Whether or not the gift was anonymous.
	/// </summary>
	public bool GifterIsAnonymous { get; set; }

	/// <summary> 
	/// The user ID of the subscription gifter. Null if anonymous.
	/// </summary>
	public string GifterUserId { get; set; }

	/// <summary> 
	/// The user name of the subscription gifter. Null if anonymous.
	/// </summary>
	public string GifterUserName { get; set; }

	/// <summary> 
	/// Optional. The user login of the subscription gifter. Null if anonymous.
	/// </summary>
	public string GifterUserLogin { get; set; }

	public static TwitchResub FromData(Dictionary data)
	{
	    return new TwitchResub
	    {
			CumulativeMonths = data["cumulative_months"].AsInt32(),
			DurationMonths = data["duration_months"].AsInt32(),
			StreakMonths = data["streak_months"].AsInt32(),
			SubTier = data["sub_tier"].AsString(),
			IsPrime = data["is_prime"].AsBool(),
			IsGift = data["is_gift"].AsBool(),
			GifterIsAnonymous = data["gifter_is_anonymous"].AsBool(),
			GifterUserId = data["gifter_user_id"].AsString(),
			GifterUserName = data["gifter_user_name"].AsString(),
			GifterUserLogin = data["gifter_user_login"].AsString(),
		};
	}

}
public partial class TwitchSubGift : Resource, ITwitcherSharpEventSub<TwitchSubGift>
{

	/// <summary> 
	/// The number of months the subscription is for.
	/// </summary>
	public int DurationMonths { get; set; }

	/// <summary> 
	/// Optional. The amount of gifts the gifter has given in this channel. Null if anonymous.
	/// </summary>
	public int CumulativeTotal { get; set; }

	/// <summary> 
	/// The user ID of the subscription gift recipient.
	/// </summary>
	public string RecipientUserId { get; set; }

	/// <summary> 
	/// The user name of the subscription gift recipient.
	/// </summary>
	public string RecipientUserName { get; set; }

	/// <summary> 
	/// The user login of the subscription gift recipient.
	/// </summary>
	public string RecipientUserLogin { get; set; }

	/// <summary> 
	/// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
	/// </summary>
	public string SubTier { get; set; }

	/// <summary> 
	/// Optional. The ID of the associated community gift. Null if not associated with a community gift.
	/// </summary>
	public string CommunityGiftId { get; set; }

	public static TwitchSubGift FromData(Dictionary data)
	{
	    return new TwitchSubGift
	    {
			DurationMonths = data["duration_months"].AsInt32(),
			CumulativeTotal = data["cumulative_total"].AsInt32(),
			RecipientUserId = data["recipient_user_id"].AsString(),
			RecipientUserName = data["recipient_user_name"].AsString(),
			RecipientUserLogin = data["recipient_user_login"].AsString(),
			SubTier = data["sub_tier"].AsString(),
			CommunityGiftId = data["community_gift_id"].AsString(),
		};
	}

}
public partial class TwitchCommunitySubGift : Resource, ITwitcherSharpEventSub<TwitchCommunitySubGift>
{

	/// <summary> 
	/// The ID of the associated community gift.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// Number of subscriptions being gifted.
	/// </summary>
	public int Total { get; set; }

	/// <summary> 
	/// The type of subscription plan being used. Possible values are: &lt;ul&gt;&lt;li&gt;1000 - First level of paid or Prime subscription.&lt;/li&gt;&lt;li&gt;2000 - Second level of paid subscription.&lt;/li&gt;&lt;li&gt;3000 - Third level of paid subscription.&lt;/li&gt;&lt;/ul&gt;
	/// </summary>
	public string SubTier { get; set; }

	/// <summary> 
	/// Optional. The amount of gifts the gifter has given in this channel. Null if anonymous.
	/// </summary>
	public int CumulativeTotal { get; set; }

	public static TwitchCommunitySubGift FromData(Dictionary data)
	{
	    return new TwitchCommunitySubGift
	    {
			Id = data["id"].AsString(),
			Total = data["total"].AsInt32(),
			SubTier = data["sub_tier"].AsString(),
			CumulativeTotal = data["cumulative_total"].AsInt32(),
		};
	}

}
public partial class TwitchGiftPaidUpgrade : Resource, ITwitcherSharpEventSub<TwitchGiftPaidUpgrade>
{

	/// <summary> 
	/// Whether the gift was given anonymously.
	/// </summary>
	public bool GifterIsAnonymous { get; set; }

	/// <summary> 
	/// Optional. The user ID of the user who gifted the subscription. Null if anonymous.
	/// </summary>
	public string GifterUserId { get; set; }

	/// <summary> 
	/// Optional. The user name of the user who gifted the subscription. Null if anonymous.
	/// </summary>
	public string GifterUserName { get; set; }

	public static TwitchGiftPaidUpgrade FromData(Dictionary data)
	{
	    return new TwitchGiftPaidUpgrade
	    {
			GifterIsAnonymous = data["gifter_is_anonymous"].AsBool(),
			GifterUserId = data["gifter_user_id"].AsString(),
			GifterUserName = data["gifter_user_name"].AsString(),
		};
	}

}
public partial class TwitchPrimePaidUpgrade : Resource, ITwitcherSharpEventSub<TwitchPrimePaidUpgrade>
{

	/// <summary> 
	/// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
	/// </summary>
	public string SubTier { get; set; }

	public static TwitchPrimePaidUpgrade FromData(Dictionary data)
	{
	    return new TwitchPrimePaidUpgrade
	    {
			SubTier = data["sub_tier"].AsString(),
		};
	}

}
public partial class TwitchPayItForward : Resource, ITwitcherSharpEventSub<TwitchPayItForward>
{

	/// <summary> 
	/// Whether the gift was given anonymously.
	/// </summary>
	public bool GifterIsAnonymous { get; set; }

	/// <summary> 
	/// The user ID of the user who gifted the subscription. Null if anonymous.
	/// </summary>
	public string GifterUserId { get; set; }

	/// <summary> 
	/// Optional. The user name of the user who gifted the subscription. Null if anonymous.
	/// </summary>
	public string GifterUserName { get; set; }

	/// <summary> 
	/// The user login of the user who gifted the subscription. Null if anonymous.
	/// </summary>
	public string GifterUserLogin { get; set; }

	public static TwitchPayItForward FromData(Dictionary data)
	{
	    return new TwitchPayItForward
	    {
			GifterIsAnonymous = data["gifter_is_anonymous"].AsBool(),
			GifterUserId = data["gifter_user_id"].AsString(),
			GifterUserName = data["gifter_user_name"].AsString(),
			GifterUserLogin = data["gifter_user_login"].AsString(),
		};
	}

}
public partial class TwitchRaid : Resource, ITwitcherSharpEventSub<TwitchRaid>
{

	/// <summary> 
	/// The user ID of the broadcaster raiding this channel.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user name of the broadcaster raiding this channel.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The login name of the broadcaster raiding this channel.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The number of viewers raiding this channel from the broadcaster’s channel.
	/// </summary>
	public int ViewerCount { get; set; }

	/// <summary> 
	/// Profile image URL of the broadcaster raiding this channel.
	/// </summary>
	public string ProfileImageUrl { get; set; }

	public static TwitchRaid FromData(Dictionary data)
	{
	    return new TwitchRaid
	    {
			UserId = data["user_id"].AsString(),
			UserName = data["user_name"].AsString(),
			UserLogin = data["user_login"].AsString(),
			ViewerCount = data["viewer_count"].AsInt32(),
			ProfileImageUrl = data["profile_image_url"].AsString(),
		};
	}

}
public partial class TwitchUnraid : Resource, ITwitcherSharpEventSub<TwitchUnraid>
{

	public static TwitchUnraid FromData(Dictionary data)
	{
	    return new TwitchUnraid
	    {
		};
	}

}
public partial class TwitchAnnouncement : Resource, ITwitcherSharpEventSub<TwitchAnnouncement>
{

	/// <summary> 
	/// Color of the announcement.
	/// </summary>
	public string Color { get; set; }

	public static TwitchAnnouncement FromData(Dictionary data)
	{
	    return new TwitchAnnouncement
	    {
			Color = data["color"].AsString(),
		};
	}

}
public partial class TwitchBitsBadgeTier : Resource, ITwitcherSharpEventSub<TwitchBitsBadgeTier>
{

	/// <summary> 
	/// The tier of the Bits badge the user just earned. For example, 100, 1000, or 10000.
	/// </summary>
	public int Tier { get; set; }

	public static TwitchBitsBadgeTier FromData(Dictionary data)
	{
	    return new TwitchBitsBadgeTier
	    {
			Tier = data["tier"].AsInt32(),
		};
	}

}
public partial class TwitchAmount : Resource, ITwitcherSharpEventSub<TwitchAmount>
{

	/// <summary> 
	/// The monetary amount. The amount is specified in the currency’s minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
	/// </summary>
	public int Value { get; set; }

	/// <summary> 
	/// The number of decimal places used by the currency. For example, USD uses two decimal places.
	/// </summary>
	public int DecimalPlace { get; set; }

	/// <summary> 
	/// The ISO-4217 three-letter currency code that identifies the type of currency in value.
	/// </summary>
	public string Currency { get; set; }

	public static TwitchAmount FromData(Dictionary data)
	{
	    return new TwitchAmount
	    {
			Value = data["value"].AsInt32(),
			DecimalPlace = data["decimal_place"].AsInt32(),
			Currency = data["currency"].AsString(),
		};
	}

}
public partial class TwitchSourceBadges : Resource, ITwitcherSharpEventSub<TwitchSourceBadges>
{

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

	public static TwitchSourceBadges FromData(Dictionary data)
	{
	    return new TwitchSourceBadges
	    {
			SetId = data["set_id"].AsString(),
			Id = data["id"].AsString(),
			Info = data["info"].AsString(),
		};
	}

}
public partial class TwitchSharedChatSub : Resource, ITwitcherSharpEventSub<TwitchSharedChatSub>
{

	public static TwitchSharedChatSub FromData(Dictionary data)
	{
	    return new TwitchSharedChatSub
	    {
		};
	}

}
public partial class TwitchSharedChatResub : Resource, ITwitcherSharpEventSub<TwitchSharedChatResub>
{

	public static TwitchSharedChatResub FromData(Dictionary data)
	{
	    return new TwitchSharedChatResub
	    {
		};
	}

}
public partial class TwitchSharedChatSubGift : Resource, ITwitcherSharpEventSub<TwitchSharedChatSubGift>
{

	public static TwitchSharedChatSubGift FromData(Dictionary data)
	{
	    return new TwitchSharedChatSubGift
	    {
		};
	}

}
public partial class TwitchSharedChatCommunitySubGift : Resource, ITwitcherSharpEventSub<TwitchSharedChatCommunitySubGift>
{

	public static TwitchSharedChatCommunitySubGift FromData(Dictionary data)
	{
	    return new TwitchSharedChatCommunitySubGift
	    {
		};
	}

}
public partial class TwitchSharedChatGiftPaidUpgrade : Resource, ITwitcherSharpEventSub<TwitchSharedChatGiftPaidUpgrade>
{

	public static TwitchSharedChatGiftPaidUpgrade FromData(Dictionary data)
	{
	    return new TwitchSharedChatGiftPaidUpgrade
	    {
		};
	}

}
public partial class TwitchSharedChatPrimePaidUpgrade : Resource, ITwitcherSharpEventSub<TwitchSharedChatPrimePaidUpgrade>
{

	public static TwitchSharedChatPrimePaidUpgrade FromData(Dictionary data)
	{
	    return new TwitchSharedChatPrimePaidUpgrade
	    {
		};
	}

}
public partial class TwitchSharedChatPayItForward : Resource, ITwitcherSharpEventSub<TwitchSharedChatPayItForward>
{

	public static TwitchSharedChatPayItForward FromData(Dictionary data)
	{
	    return new TwitchSharedChatPayItForward
	    {
		};
	}

}
public partial class TwitchSharedChatRaid : Resource, ITwitcherSharpEventSub<TwitchSharedChatRaid>
{

	public static TwitchSharedChatRaid FromData(Dictionary data)
	{
	    return new TwitchSharedChatRaid
	    {
		};
	}

}
public partial class TwitchSharedChatAnnouncement : Resource, ITwitcherSharpEventSub<TwitchSharedChatAnnouncement>
{

	public static TwitchSharedChatAnnouncement FromData(Dictionary data)
	{
	    return new TwitchSharedChatAnnouncement
	    {
		};
	}

}

}
