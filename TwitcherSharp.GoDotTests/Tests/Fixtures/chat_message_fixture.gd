extends RefCounted
## Builds the GDScript chat objects the C# mapping tests read: a TwitchChatMessage with every field set,
## the way twitcher fills it from an EventSub notification.


static func full_message() -> TwitchChatMessage:
	var message := TwitchChatMessage.new()
	message.broadcaster_user_id = "1001"
	message.broadcaster_user_name = "Broadcaster"
	message.broadcaster_user_login = "broadcaster"
	message.chatter_user_id = "2002"
	message.chatter_user_name = "Chatter"
	message.chatter_user_login = "chatter"
	message.message_id = "message-1"
	message.message_type = TwitchChatMessage.MessageType.channel_points_highlighted
	message.color = "#FF00FF"
	message.channel_points_custom_reward_id = "reward-1"
	message.source_broadcaster_user_id = "3003"
	message.source_broadcaster_user_name = "Source"
	message.source_broadcaster_user_login = "source"
	message.source_message_id = "source-message-1"
	message.is_source_only = true
	message.badges.append(badge("subscriber", "12", "14"))
	message.badges.append(badge("moderator", "1", ""))
	message.source_badges.append(badge("vip", "1", ""))

	message.cheer = TwitchChatMessage.Cheer.new()
	message.cheer.bits = 100

	message.reply = TwitchChatMessage.Reply.new()
	message.reply.parent_message_id = "parent-1"
	message.reply.parent_message_body = "Parent body"
	message.reply.parent_user_id = "5005"
	message.reply.parent_user_name = "Parent"
	message.reply.parent_user_login = "parent"
	message.reply.thread_message_id = "thread-1"
	message.reply.thread_user_id = "6006"
	message.reply.thread_user_name = "Thread"
	message.reply.thread_user_login = "thread"

	message.message = TwitchChatMessage.Message.new()
	message.message.text = "Hello Kappa cheer100 @friend"

	var text := fragment(TwitchChatMessage.FragmentType.text, "Hello ")
	message.message.fragments.append(text)

	var emote := fragment(TwitchChatMessage.FragmentType.emote, "Kappa")
	emote.emote = TwitchChatMessage.Emote.new()
	emote.emote.id = "25"
	emote.emote.emote_set_id = "0"
	emote.emote.owner_id = "7007"
	emote.emote.format.append(TwitchChatMessage.EmoteFormat._static)
	emote.emote.format.append(TwitchChatMessage.EmoteFormat.animated)
	message.message.fragments.append(emote)

	var cheermote := fragment(TwitchChatMessage.FragmentType.cheermote, "cheer100")
	cheermote.cheermote = TwitchChatMessage.Cheermote.new()
	cheermote.cheermote.prefix = "cheer"
	cheermote.cheermote.bits = 100
	cheermote.cheermote.tier = 2
	message.message.fragments.append(cheermote)

	var mention := fragment(TwitchChatMessage.FragmentType.mention, "@friend")
	mention.mention = TwitchChatMessage.Mention.new()
	mention.mention.user_id = "4004"
	mention.mention.user_name = "Friend"
	mention.mention.user_login = "friend"
	message.message.fragments.append(mention)

	return message


static func badge(set_id: String, id: String, info: String) -> TwitchChatMessage.Badge:
	var result := TwitchChatMessage.Badge.new()
	result.set_id = set_id
	result.id = id
	result.info = info
	return result


static func fragment(type: TwitchChatMessage.FragmentType, text: String) -> TwitchChatMessage.Fragment:
	var result := TwitchChatMessage.Fragment.new()
	result.type = type
	result.text = text
	return result
