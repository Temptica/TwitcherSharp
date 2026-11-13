# API Reference

Every endpoint in the Twitch API, grouped by resource.

Source: https://dev.twitch.tv/docs/api/reference/

## Ads {#ads}

Start, stop, and get information about ads on Twitch.

- [Get Ad Schedule](https://dev.twitch.tv/docs/api/reference/ads.md#get-ad-schedule): Returns ad schedule related information.
- [Snooze Next Ad](https://dev.twitch.tv/docs/api/reference/ads.md#snooze-next-ad): Pushes back the timestamp of the upcoming automatic mid-roll ad by 5 minutes.
- [Start Commercial](https://dev.twitch.tv/docs/api/reference/ads.md#start-commercial): Starts a commercial on the specified channel.

## Analytics {#analytics}

Get access to analytics on your Extension and games on Twitch.

- [Get Extension Analytics](https://dev.twitch.tv/docs/api/reference/analytics.md#get-extension-analytics): Gets an analytics report for one or more extensions.
- [Get Game Analytics](https://dev.twitch.tv/docs/api/reference/analytics.md#get-game-analytics): Gets an analytics report for one or more games.

## Bits {#bits}

Get access to information involving Bits products and transactions.

- [Get Cheermotes](https://dev.twitch.tv/docs/api/reference/bits.md#get-cheermotes): Gets a list of Cheermotes that users can use to cheer Bits.
- [Get Custom Power-up](https://dev.twitch.tv/docs/api/reference/bits.md#get-custom-power-up): Gets a list of custom Power-ups that the specified broadcaster created.
- [Get Bits Leaderboard](https://dev.twitch.tv/docs/api/reference/bits.md#get-bits-leaderboard): Gets the Bits leaderboard for the authenticated broadcaster.
- [Get Extension Transactions](https://dev.twitch.tv/docs/api/reference/bits.md#get-extension-transactions): Gets an extension's list of transactions.

## CCLs {#ccls}

Get the Content Classification Labels a broadcaster can apply to their channel.

- [Get Content Classification Labels](https://dev.twitch.tv/docs/api/reference/ccls.md#get-content-classification-labels): Gets information about Twitch content classification labels.

## Channel Points {#channel-points}

Get, remove, and manage Channel Points rewards and Redemptions.

- [Get Custom Reward](https://dev.twitch.tv/docs/api/reference/channel-points.md#get-custom-reward): Gets a list of custom rewards that the specified broadcaster created.
- [Create Custom Rewards](https://dev.twitch.tv/docs/api/reference/channel-points.md#create-custom-rewards): Creates a Custom Reward in the broadcaster's channel.
- [Update Custom Reward](https://dev.twitch.tv/docs/api/reference/channel-points.md#update-custom-reward): Updates a custom reward.
- [Delete Custom Reward](https://dev.twitch.tv/docs/api/reference/channel-points.md#delete-custom-reward): Deletes a custom reward that the broadcaster created.
- [Get Custom Reward Redemption](https://dev.twitch.tv/docs/api/reference/channel-points.md#get-custom-reward-redemption): Gets a list of redemptions for a custom reward.
- [Update Redemption Status](https://dev.twitch.tv/docs/api/reference/channel-points.md#update-redemption-status): Updates a redemption's status.

## Channels {#channels}

Get information and manage settings related to a user's Twitch channel.

- [Get Channel Information](https://dev.twitch.tv/docs/api/reference/channels.md#get-channel-information): Gets information about one or more channels.
- [Modify Channel Information](https://dev.twitch.tv/docs/api/reference/channels.md#modify-channel-information): Updates a channel's properties.
- [Get Channel Editors](https://dev.twitch.tv/docs/api/reference/channels.md#get-channel-editors): Gets the broadcaster's list editors.
- [Get Followed Channels](https://dev.twitch.tv/docs/api/reference/channels.md#get-followed-channels): Gets a list of broadcasters that the specified user follows, or checks if a user follows a specific broadcaster.
- [Get Channel Followers](https://dev.twitch.tv/docs/api/reference/channels.md#get-channel-followers): Gets a list of users that follow the specified broadcaster, or checks if a specific user follows the broadcaster.

## Charity {#charity}

Manage charity campaign and donations made through Twitch's Charity Tool.

- [Get Charity Campaign](https://dev.twitch.tv/docs/api/reference/charity.md#get-charity-campaign): Gets information about the broadcaster's active charity campaign.
- [Get Charity Campaign Donations](https://dev.twitch.tv/docs/api/reference/charity.md#get-charity-campaign-donations): Gets the list of donations that users have made to the broadcaster's active charity campaign.

## Chat {#chat}

Manage and interact with Twitch Chat.

- [Send Chat Announcement](https://dev.twitch.tv/docs/api/reference/chat.md#send-chat-announcement): Sends an announcement to the broadcaster's chat room.
- [Get Channel Chat Badges](https://dev.twitch.tv/docs/api/reference/chat.md#get-channel-chat-badges): Gets the broadcaster's list of custom chat badges.
- [Get Global Chat Badges](https://dev.twitch.tv/docs/api/reference/chat.md#get-global-chat-badges): Gets Twitch's list of chat badges.
- [Get Chatters](https://dev.twitch.tv/docs/api/reference/chat.md#get-chatters): Gets the list of users that are connected to the broadcaster's chat session.
- [Get User Chat Color](https://dev.twitch.tv/docs/api/reference/chat.md#get-user-chat-color): Gets the color used for the user's name in chat.
- [Update User Chat Color](https://dev.twitch.tv/docs/api/reference/chat.md#update-user-chat-color): Updates the color used for the user's name in chat.
- [Get Channel Emotes](https://dev.twitch.tv/docs/api/reference/chat.md#get-channel-emotes): Gets the broadcaster's list of custom emotes.
- [Get Global Emotes](https://dev.twitch.tv/docs/api/reference/chat.md#get-global-emotes): Gets all global emotes.
- [Get Emote Sets](https://dev.twitch.tv/docs/api/reference/chat.md#get-emote-sets): Gets emotes for one or more specified emote sets.
- [Get User Emotes](https://dev.twitch.tv/docs/api/reference/chat.md#get-user-emotes): Retrieves emotes available to the user across all channels.
- [Send Chat Message](https://dev.twitch.tv/docs/api/reference/chat.md#send-chat-message): Sends a message to the broadcaster's chat room.
- [Get Pinned Chat Message](https://dev.twitch.tv/docs/api/reference/chat.md#get-pinned-chat-message): Gets the currently pinned message for the broadcaster's chat room.
- [Pin Chat Message](https://dev.twitch.tv/docs/api/reference/chat.md#pin-chat-message): Pins a chat message to the specified broadcaster's chat room.
- [Update Pinned Chat Message](https://dev.twitch.tv/docs/api/reference/chat.md#update-pinned-chat-message): Updates the duration of a pinned chat message.
- [Unpin Chat Message](https://dev.twitch.tv/docs/api/reference/chat.md#unpin-chat-message): Unpins a pinned chat message from the broadcaster's chat room.
- [Get Chat Settings](https://dev.twitch.tv/docs/api/reference/chat.md#get-chat-settings): Gets the broadcaster's chat settings.
- [Update Chat Settings](https://dev.twitch.tv/docs/api/reference/chat.md#update-chat-settings): Updates the broadcaster's chat settings.
- [Send a Shoutout](https://dev.twitch.tv/docs/api/reference/chat.md#send-a-shoutout): Sends a Shoutout to the specified broadcaster.
- [Get Shared Chat Session](https://dev.twitch.tv/docs/api/reference/chat.md#get-shared-chat-session): Retrieves the active shared chat session for a channel.

## Clips {#clips}

Create and manage clips on Twitch

- [Get Clips](https://dev.twitch.tv/docs/api/reference/clips.md#get-clips): Gets one or more video clips.
- [Create Clip](https://dev.twitch.tv/docs/api/reference/clips.md#create-clip): Creates a clip from the broadcaster's stream.
- [Get Clips Download](https://dev.twitch.tv/docs/api/reference/clips.md#get-clips-download): Provides URLs to download the video file(s) for the specified clips.
- [Create Clip From VOD](https://dev.twitch.tv/docs/api/reference/clips.md#create-clip-from-vod): Creates a clip from the broadcaster's VOD.

## Conduits {#conduits}

Create and manage conduits and their shards for sending EventSub notifications.

- [Get Conduits](https://dev.twitch.tv/docs/api/reference/conduits.md#get-conduits): Gets the conduits for a client ID.
- [Create Conduits](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits): Creates a new conduit.
- [Update Conduits](https://dev.twitch.tv/docs/api/reference/conduits.md#update-conduits): Updates a conduit's shard count.
- [Delete Conduit](https://dev.twitch.tv/docs/api/reference/conduits.md#delete-conduit): Deletes a specified conduit.
- [Get Conduit Shards](https://dev.twitch.tv/docs/api/reference/conduits.md#get-conduit-shards): Gets a list of shards for a conduit.
- [Update Conduit Shards](https://dev.twitch.tv/docs/api/reference/conduits.md#update-conduit-shards): Updates shard(s) for a conduit.

## Entitlements {#entitlements}

Manage your game's Twitch Drops system using the Twitch API.

- [Get Drops Entitlements](https://dev.twitch.tv/docs/api/reference/entitlements.md#get-drops-entitlements): Gets an organization's list of entitlements that have been granted to a game, a user, or both.
- [Update Drops Entitlements](https://dev.twitch.tv/docs/api/reference/entitlements.md#update-drops-entitlements): Updates the Drop entitlement's fulfillment status.

## EventSub {#eventsub}

Create, list, and delete EventSub subscriptions.

- [Get EventSub Subscriptions](https://dev.twitch.tv/docs/api/reference/eventsub.md#get-eventsub-subscriptions): Gets a list of EventSub subscriptions that the client in the access token created.
- [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription): Creates an EventSub subscription.
- [Delete EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#delete-eventsub-subscription): Deletes an EventSub subscription.

## Extensions {#extensions}

Manage and interact on behalf of your Twitch Extensions.

- [Get Extension Bits Products](https://dev.twitch.tv/docs/api/reference/extensions.md#get-extension-bits-products): Gets the list of Bits products that belongs to the extension.
- [Update Extension Bits Product](https://dev.twitch.tv/docs/api/reference/extensions.md#update-extension-bits-product): Adds or updates a Bits product that the extension created.
- [Get Extensions](https://dev.twitch.tv/docs/api/reference/extensions.md#get-extensions): Gets information about an extension.
- [Send Extension Chat Message](https://dev.twitch.tv/docs/api/reference/extensions.md#send-extension-chat-message): Sends a message to the specified broadcaster's chat room.
- [Get Extension Configuration Segment](https://dev.twitch.tv/docs/api/reference/extensions.md#get-extension-configuration-segment): Gets the specified configuration segment from the specified extension.
- [Set Extension Configuration Segment](https://dev.twitch.tv/docs/api/reference/extensions.md#set-extension-configuration-segment): Updates a configuration segment.
- [Get Extension Secrets](https://dev.twitch.tv/docs/api/reference/extensions.md#get-extension-secrets): Gets an extension's list of shared secrets.
- [Create Extension Secret](https://dev.twitch.tv/docs/api/reference/extensions.md#create-extension-secret): Creates a shared secret used to sign and verify JWT tokens.
- [Get Extension Live Channels](https://dev.twitch.tv/docs/api/reference/extensions.md#get-extension-live-channels): Gets a list of broadcasters that are streaming live and have installed or activated the extension.
- [Send Extension PubSub Message](https://dev.twitch.tv/docs/api/reference/extensions.md#send-extension-pubsub-message): Sends a message to one or more viewers.
- [Get Released Extensions](https://dev.twitch.tv/docs/api/reference/extensions.md#get-released-extensions): Gets information about a released extension.
- [Set Extension Required Configuration](https://dev.twitch.tv/docs/api/reference/extensions.md#set-extension-required-configuration): Updates the extension's _required_configuration_ string.

## Games {#games}

Get information about categories on Twitch.

- [Get Games](https://dev.twitch.tv/docs/api/reference/games.md#get-games): Gets information about specified categories or games.
- [Get Top Games](https://dev.twitch.tv/docs/api/reference/games.md#get-top-games): Gets information about the categories and games that have the most viewers on Twitch.

## Goals {#goals}

View information related to a creator's goals.

- [Get Creator Goals](https://dev.twitch.tv/docs/api/reference/goals.md#get-creator-goals): Gets the broadcaster's list of active goals.

## Guest Star {#guest-star}

Manage and view information related to a broadcaster's Stream Together session.

- [Get Channel Guest Star Settings](https://dev.twitch.tv/docs/api/reference/guest-star.md#get-channel-guest-star-settings): Gets the channel settings for configuration of the Guest Star feature for a particular host.
- [Update Channel Guest Star Settings](https://dev.twitch.tv/docs/api/reference/guest-star.md#update-channel-guest-star-settings): Mutates the channel settings for configuration of the Guest Star feature for a particular host.
- [Get Guest Star Invites](https://dev.twitch.tv/docs/api/reference/guest-star.md#get-guest-star-invites): Provides the caller with a list of pending invites to a Guest Star session.
- [Send Guest Star Invite](https://dev.twitch.tv/docs/api/reference/guest-star.md#send-guest-star-invite): Sends an invite to a specified guest on behalf of the broadcaster for a Guest Star session in progress.
- [Delete Guest Star Invite](https://dev.twitch.tv/docs/api/reference/guest-star.md#delete-guest-star-invite): Revokes a previously sent invite for a Guest Star
session.
- [Get Guest Star Session](https://dev.twitch.tv/docs/api/reference/guest-star.md#get-guest-star-session): Gets information about an ongoing Guest Star session for a particular channel.
- [Create Guest Star Session](https://dev.twitch.tv/docs/api/reference/guest-star.md#create-guest-star-session): Programmatically creates a Guest Star session on behalf
of the broadcaster.
- [End Guest Star Session](https://dev.twitch.tv/docs/api/reference/guest-star.md#end-guest-star-session): Programmatically ends a Guest Star session on behalf of the broadcaster.
- [Assign Guest Star Slot](https://dev.twitch.tv/docs/api/reference/guest-star.md#assign-guest-star-slot): Allows a previously invited user to be assigned a slot
within the active Guest Star session.
- [Update Guest Star Slot](https://dev.twitch.tv/docs/api/reference/guest-star.md#update-guest-star-slot): Allows a user to update the assigned slot for a particular user within the active Guest Star session.
- [Delete Guest Star Slot](https://dev.twitch.tv/docs/api/reference/guest-star.md#delete-guest-star-slot): Allows a caller to remove a slot assignment from a user participating in an active Guest Star session.
- [Update Guest Star Slot Settings](https://dev.twitch.tv/docs/api/reference/guest-star.md#update-guest-star-slot-settings): Allows a user to update slot settings for a particular guest within a Guest Star session.

## Hype Train {#hype-train}

View information related a channel's ongoing Hype Train.

- [Get Hype Train Status](https://dev.twitch.tv/docs/api/reference/hype-train.md#get-hype-train-status): Gets the status of a Hype Train for the specified broadcaster.

## Moderation {#moderation}

Manage a Twitch channel's moderation settings, including banning and warning users.

- [Get VIPs](https://dev.twitch.tv/docs/api/reference/moderation.md#get-vips): Gets a list of the broadcaster's VIPs.
- [Add Channel VIP](https://dev.twitch.tv/docs/api/reference/moderation.md#add-channel-vip): Adds the specified user as a VIP in the broadcaster's channel.
- [Remove Channel VIP](https://dev.twitch.tv/docs/api/reference/moderation.md#remove-channel-vip): Removes the specified user as a VIP in the broadcaster's channel.
- [Manage Held AutoMod Messages](https://dev.twitch.tv/docs/api/reference/moderation.md#manage-held-automod-messages): Allow or deny the message that AutoMod flagged for review.
- [Get AutoMod Settings](https://dev.twitch.tv/docs/api/reference/moderation.md#get-automod-settings): Gets the broadcaster's AutoMod settings.
- [Update AutoMod Settings](https://dev.twitch.tv/docs/api/reference/moderation.md#update-automod-settings): Updates the broadcaster's AutoMod settings.
- [Get Banned Users](https://dev.twitch.tv/docs/api/reference/moderation.md#get-banned-users): Gets all users that the broadcaster banned or put in a timeout.
- [Ban User](https://dev.twitch.tv/docs/api/reference/moderation.md#ban-user): Bans a user from participating in a broadcaster's chat room or puts them in a timeout.
- [Unban User](https://dev.twitch.tv/docs/api/reference/moderation.md#unban-user): Removes the ban or timeout that was placed on the specified user.
- [Get Blocked Terms](https://dev.twitch.tv/docs/api/reference/moderation.md#get-blocked-terms): Gets the broadcaster's list of blocked words or phrases.
- [Add Blocked Term](https://dev.twitch.tv/docs/api/reference/moderation.md#add-blocked-term): Adds a word or phrase to the broadcaster's list of blocked terms.
- [Remove Blocked Term](https://dev.twitch.tv/docs/api/reference/moderation.md#remove-blocked-term): Removes the word or phrase from the broadcaster's list of blocked terms.
- [Get Moderated Channels](https://dev.twitch.tv/docs/api/reference/moderation.md#get-moderated-channels): Gets a list of channels that the specified user has moderator privileges in.
- [Delete Chat Messages](https://dev.twitch.tv/docs/api/reference/moderation.md#delete-chat-messages): Removes a single chat message or all chat messages from the broadcaster's chat room.
- [Check AutoMod Status](https://dev.twitch.tv/docs/api/reference/moderation.md#check-automod-status): Checks whether AutoMod would flag the specified message for review.
- [Get Moderators](https://dev.twitch.tv/docs/api/reference/moderation.md#get-moderators): Gets all users allowed to moderate the broadcaster's chat room.
- [Add Channel Moderator](https://dev.twitch.tv/docs/api/reference/moderation.md#add-channel-moderator): Adds a moderator to the broadcaster's chat room.
- [Remove Channel Moderator](https://dev.twitch.tv/docs/api/reference/moderation.md#remove-channel-moderator): Removes a moderator from the broadcaster's chat room.
- [Get Shield Mode Status](https://dev.twitch.tv/docs/api/reference/moderation.md#get-shield-mode-status): Gets the broadcaster's Shield Mode activation status.
- [Update Shield Mode Status](https://dev.twitch.tv/docs/api/reference/moderation.md#update-shield-mode-status): Activates or deactivates the broadcaster's Shield Mode.
- [Add Suspicious Status to Chat User](https://dev.twitch.tv/docs/api/reference/moderation.md#add-suspicious-status-to-chat-user): Adds a suspicious user status to a chatter on the broadcaster's channel.
- [Remove Suspicious Status From Chat User](https://dev.twitch.tv/docs/api/reference/moderation.md#remove-suspicious-status-from-chat-user): Remove a suspicious user status from a chatter on broadcaster's channel.
- [Get Unban Requests](https://dev.twitch.tv/docs/api/reference/moderation.md#get-unban-requests): Gets a list of unban requests for a broadcaster's channel.
- [Resolve Unban Requests](https://dev.twitch.tv/docs/api/reference/moderation.md#resolve-unban-requests): Resolves an unban request by approving or denying it.
- [Warn Chat User](https://dev.twitch.tv/docs/api/reference/moderation.md#warn-chat-user): Warns a user in the specified broadcaster's chat room, preventing them from chat interaction until the warning is acknowledged.

## Polls {#polls}

Start, stop, and get information relating to polls on a Twitch channel.

- [Get Polls](https://dev.twitch.tv/docs/api/reference/polls.md#get-polls): Gets a list of polls that the broadcaster created.
- [Create Poll](https://dev.twitch.tv/docs/api/reference/polls.md#create-poll): Creates a poll that viewers in the broadcaster's channel can vote on.
- [End Poll](https://dev.twitch.tv/docs/api/reference/polls.md#end-poll): End an active poll.

## Predictions {#predictions}

Start, stop, and get information relating to predictions on a Twitch channel.

- [Get Predictions](https://dev.twitch.tv/docs/api/reference/predictions.md#get-predictions): Gets a list of Channel Points Predictions that the broadcaster created.
- [Create Prediction](https://dev.twitch.tv/docs/api/reference/predictions.md#create-prediction): Create a Channel Points Prediction.
- [End Prediction](https://dev.twitch.tv/docs/api/reference/predictions.md#end-prediction): Locks, resolves, or cancels a Channel Points Prediction.

## Raids {#raids}

Start and stop raids on a Twitch channel.

- [Start a raid](https://dev.twitch.tv/docs/api/reference/raids.md#start-a-raid): Raid another channel by sending the broadcaster's viewers to the targeted channel.
- [Cancel a raid](https://dev.twitch.tv/docs/api/reference/raids.md#cancel-a-raid): Cancel a pending raid.

## Schedule {#schedule}

Manage and get information related to a broadcaster's stream schedule.

- [Get Channel Stream Schedule](https://dev.twitch.tv/docs/api/reference/schedule.md#get-channel-stream-schedule): Gets the broadcaster's streaming schedule.
- [Get Channel iCalendar](https://dev.twitch.tv/docs/api/reference/schedule.md#get-channel-icalendar): Gets the broadcaster's streaming schedule as an [iCalendar](https://datatracker.ietf.org/doc/html/rfc5545).
- [Create Channel Stream Schedule Segment](https://dev.twitch.tv/docs/api/reference/schedule.md#create-channel-stream-schedule-segment): Adds a single or recurring broadcast to the broadcaster's streaming schedule.
- [Update Channel Stream Schedule Segment](https://dev.twitch.tv/docs/api/reference/schedule.md#update-channel-stream-schedule-segment): Updates a scheduled broadcast segment.
- [Delete Channel Stream Schedule Segment](https://dev.twitch.tv/docs/api/reference/schedule.md#delete-channel-stream-schedule-segment): Deletes a broadcast from the broadcaster's streaming schedule.
- [Update Channel Stream Schedule](https://dev.twitch.tv/docs/api/reference/schedule.md#update-channel-stream-schedule): Updates the broadcaster's schedule settings, such as scheduling a vacation.

## Search {#search}

Search for categories and channels on Twitch.

- [Search Categories](https://dev.twitch.tv/docs/api/reference/search.md#search-categories): Gets the games or categories that match the specified query.
- [Search Channels](https://dev.twitch.tv/docs/api/reference/search.md#search-channels): Gets the channels that match the specified query.

## Streams {#streams}

Get and manage information relating to a stream, or the ability to stream.

- [Get Streams](https://dev.twitch.tv/docs/api/reference/streams.md#get-streams): Gets a list of all streams.
- [Get Followed Streams](https://dev.twitch.tv/docs/api/reference/streams.md#get-followed-streams): Gets the list of broadcasters that the user follows and that are streaming live.
- [Get Stream Key](https://dev.twitch.tv/docs/api/reference/streams.md#get-stream-key): Gets the channel's stream key.
- [Get Stream Markers](https://dev.twitch.tv/docs/api/reference/streams.md#get-stream-markers): Gets a list of markers from the user's most recent stream or from the specified VOD/video.
- [Create Stream Marker](https://dev.twitch.tv/docs/api/reference/streams.md#create-stream-marker): Adds a marker to a live stream.

## Subscriptions {#subscriptions}

Get information related to subscriptions on a Twitch channel.

- [Get Broadcaster Subscriptions](https://dev.twitch.tv/docs/api/reference/subscriptions.md#get-broadcaster-subscriptions): Gets a list of users that subscribe to the specified broadcaster.
- [Check User Subscription](https://dev.twitch.tv/docs/api/reference/subscriptions.md#check-user-subscription): Checks whether the user subscribes to the broadcaster's channel.

## Teams {#teams}

Get information related to Twitch Teams.

- [Get Teams](https://dev.twitch.tv/docs/api/reference/teams.md#get-teams): Gets information about the specified Twitch team.
- [Get Channel Teams](https://dev.twitch.tv/docs/api/reference/teams.md#get-channel-teams): Gets the list of Twitch teams that the broadcaster is a member of.

## Users {#users}

Get information related to users, and act on behalf of a Twitch user's account.

- [Get Authorization By User](https://dev.twitch.tv/docs/api/reference/users.md#get-authorization-by-user): Gets the authorization scopes that the specified user has granted the application.
- [Get Users](https://dev.twitch.tv/docs/api/reference/users.md#get-users): Gets information about one or more users.
- [Update User](https://dev.twitch.tv/docs/api/reference/users.md#update-user): Updates the user's information.
- [Get User Block List](https://dev.twitch.tv/docs/api/reference/users.md#get-user-block-list): Gets the list of users that the broadcaster has blocked.
- [Block User](https://dev.twitch.tv/docs/api/reference/users.md#block-user): Blocks the specified user from interacting with or having contact with the broadcaster.
- [Unblock User](https://dev.twitch.tv/docs/api/reference/users.md#unblock-user): Removes the user from the broadcaster's list of blocked users.
- [Get User Active Extensions](https://dev.twitch.tv/docs/api/reference/users.md#get-user-active-extensions): Gets the active extensions that the broadcaster has installed for each configuration.
- [Update User Extensions](https://dev.twitch.tv/docs/api/reference/users.md#update-user-extensions): Updates an installed extension's information.
- [Get User Extensions](https://dev.twitch.tv/docs/api/reference/users.md#get-user-extensions): Gets a list of all extensions (both active and inactive) that the broadcaster has installed.

## Videos {#videos}

Get and manage and a broadcaster's Twitch VODs.

- [Get Videos](https://dev.twitch.tv/docs/api/reference/videos.md#get-videos): Gets information about one or more published videos.
- [Delete Videos](https://dev.twitch.tv/docs/api/reference/videos.md#delete-videos): Deletes one or more videos.

## Whispers {#whispers}

Send whispers on behalf of a Twitch user.

- [Send Whisper](https://dev.twitch.tv/docs/api/reference/whispers.md#send-whisper): Sends a whisper message to the specified user.
