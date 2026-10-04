extends RefCounted
## Offline stand-ins for twitcher nodes whose functions await. Each override awaits a frame before it answers,
## like the real function awaits its HTTP request, so a C# wrapper only sees the result when it awaits the call.


## Answers get_emotes_by_definition from memory: one SpriteFrames per definition, tagged with the emote id.
class FakeMediaLoader extends TwitchMediaLoader:
	func get_emotes_by_definition(emote_definitions: Array[TwitchEmoteDefinition]) -> Dictionary[TwitchEmoteDefinition, SpriteFrames]:
		await (Engine.get_main_loop() as SceneTree).process_frame
		var result: Dictionary[TwitchEmoteDefinition, SpriteFrames] = {}
		for definition in emote_definitions:
			var frames := SpriteFrames.new()
			frames.set_meta(&"emote_id", definition.id)
			result[definition] = frames
		return result


	func get_badges(badges: Array[TwitchBadgeDefinition]) -> Dictionary[TwitchBadgeDefinition, SpriteFrames]:
		await (Engine.get_main_loop() as SceneTree).process_frame
		var result: Dictionary[TwitchBadgeDefinition, SpriteFrames] = {}
		for badge in badges:
			var frames := SpriteFrames.new()
			frames.set_meta(&"badge", badge.get_cache_id())
			result[badge] = frames
		return result


	func preload_emotes(channel_id: String = "global") -> void:
		await (Engine.get_main_loop() as SceneTree).process_frame
		set_meta(&"preloaded", channel_id)


class FakeService extends TwitchService:
	func subscribe_event(definition: TwitchEventsubDefinition, conditions: Dictionary) -> TwitchEventsubConfig:
		await (Engine.get_main_loop() as SceneTree).process_frame
		return TwitchEventsubConfig.create(definition, conditions)


	func send_shoutout(user: TwitchUser, _broadcaster: TwitchUser = null, _moderator: TwitchUser = null) -> void:
		await (Engine.get_main_loop() as SceneTree).process_frame
		set_meta(&"shoutout", user.login)


	func send_announcement(message: String, _color: TwitchAnnouncementColor = TwitchAnnouncementColor.PRIMARY, _broadcaster: TwitchUser = null, _moderator: TwitchUser = null) -> void:
		await (Engine.get_main_loop() as SceneTree).process_frame
		set_meta(&"announcement", message)


	func whisper(message: String, to_user_id: String) -> void:
		await (Engine.get_main_loop() as SceneTree).process_frame
		set_meta(&"whisper", "%s:%s" % [to_user_id, message])


class FakeChat extends TwitchChat:
	func subscribe() -> void:
		await (Engine.get_main_loop() as SceneTree).process_frame
		set_meta(&"subscribed", true)


class FakeRewardService extends TwitchRewardService:
	func _init() -> void:
		super(null, null)


	func load_reward(twitch_reward: TwitchReward) -> LoadError:
		await (Engine.get_main_loop() as SceneTree).process_frame
		twitch_reward.title = "Loaded"
		return LoadError.NO_REWARD_FOUND


	func save_reward(_twitch_reward: TwitchReward) -> SaveError:
		await (Engine.get_main_loop() as SceneTree).process_frame
		return SaveError.REWARD_NOT_OWNED


	func delete_reward(_twitch_reward: TwitchReward) -> DeleteError:
		await (Engine.get_main_loop() as SceneTree).process_frame
		return DeleteError.NO_BROADCASTER_USER
