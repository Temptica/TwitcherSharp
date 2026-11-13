# EventSub Reference

Every EventSub subscription type, grouped by resource.

Source: https://dev.twitch.tv/docs/eventsub/reference/

## AutoMod {#automod}

Events raised when AutoMod holds, updates or reviews a message, and when a broadcaster changes their AutoMod settings or terms.

- [AutoMod Message Hold](https://dev.twitch.tv/docs/eventsub/reference/automod.md#automod-message-hold): Notifies a user if their chat message was caught by AutoMod for review.
- [AutoMod Message Hold V2](https://dev.twitch.tv/docs/eventsub/reference/automod.md#automod-message-hold-v2): A user is notified if a message is caught by automod for review. Only public blocked terms trigger notifications, not private ones.
- [AutoMod Message Update](https://dev.twitch.tv/docs/eventsub/reference/automod.md#automod-message-update): A message in the automod queue had its status changed.
- [AutoMod Message Update V2](https://dev.twitch.tv/docs/eventsub/reference/automod.md#automod-message-update-v2): A message in the automod queue had its status changed. Only public blocked terms trigger notifications, not private ones.
- [AutoMod Settings Update](https://dev.twitch.tv/docs/eventsub/reference/automod.md#automod-settings-update): A notification is sent when a broadcaster's automod settings are updated.
- [AutoMod Terms Update](https://dev.twitch.tv/docs/eventsub/reference/automod.md#automod-terms-update): A notification is sent when a broadcaster's automod terms are updated. Changes to private terms are not sent.

## Channel {#channel}

Actions on Twitch relating to a Twitch channel.

- [Channel Ad Break Begin](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-ad-break-begin): A midroll commercial break has started running.
- [Channel Bits Use](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-bits-use): A notification is sent whenever Bits are used on a channel.
- [Channel Cheer](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-cheer): A user cheers on the specified channel.
- [Channel Custom Power-ups Redemption Add](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-custom-power-up-redemption-add): A viewer has redeemed a custom Power-up on the specified channel.
- [Channel Follow](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-follow): A specified channel receives a follow.
- [Channel Raid](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-raid): A broadcaster raids another broadcaster's channel.
- [Shoutout Create](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-shoutout-create): Sends a notification when the specified broadcaster sends a Shoutout.
- [Shoutout Received](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-shoutout-receive): Sends a notification when the specified broadcaster receives a Shoutout.
- [Channel Subscribe](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-subscribe): A notification is sent when a specified channel receives a subscriber. This does not include resubscribes.
- [Channel Subscription End](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-subscription-end): A notification when a subscription to the specified channel ends.
- [Channel Subscription Gift](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-subscription-gift): A notification when a viewer gives a gift subscription to one or more users in the specified channel.
- [Channel Subscription Message](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-subscription-message): A notification when a user sends a resubscription chat message in a specific channel.
- [Channel Update](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-update): A broadcaster updates their channel properties *e.g.*, category, title, content classification labels, broadcast, or language.
- [Channel VIP Add](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-vip-add): A VIP is added to the channel.
- [Channel VIP Remove](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-vip-remove): A VIP is removed from the channel.

## Channel Moderation {#channel-moderation}

Events raised when a moderation event happens on a Twitch channel.

- [Channel Ban](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-ban): A viewer is banned from the specified channel.
- [Channel Moderate](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-moderate): A moderator performs a moderation action in a channel.
- [Channel Moderate V2](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-moderate-v2): A moderator performs a moderation action in a channel. Includes warnings.
- [Channel Moderator Add](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-moderator-add): Moderator privileges were added to a user on a specified channel.
- [Channel Moderator Remove](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-moderator-remove): Moderator privileges were removed from a user on a specified channel.
- [Shield Mode Begin](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-shield-mode-begin): Sends a notification when the broadcaster activates Shield Mode.
- [Shield Mode End](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-shield-mode-end): Sends a notification when the broadcaster deactivates Shield Mode.
- [Channel Suspicious User Message](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-suspicious-user-message): A chat message has been sent by a suspicious user.
- [Channel Suspicious User Update](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-suspicious-user-update): A suspicious user has been updated.
- [Channel Unban](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-unban): A viewer is unbanned from the specified channel.
- [Channel Unban Request Create](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-unban-request-create): A user creates an unban request.
- [Channel Unban Request Resolve](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-unban-request-resolve): An unban request has been resolved.
- [Channel Warning Acknowledgement](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-warning-acknowledge): A user acknowledges a warning. Broadcasters and moderators can see the warning's details.
- [Channel Warning Send](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-warning-send): A user is sent a warning. Broadcasters and moderators can see the warning's details.

## Channel Points {#channel-points}

Events raised when a broadcaster manages their Channel Points rewards, and when a viewer redeems an automatic or custom reward.

- [Channel Points Automatic Reward Redemption Add](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-automatic-reward-redemption-add): A viewer has redeemed an automatic channel points reward on the specified channel.
- [Channel Points Automatic Reward Redemption Add V2](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-automatic-reward-redemption-add-v2): A viewer has redeemed an automatic channel points reward on the specified channel.
- [Channel Points Custom Reward Redemption Add](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-custom-reward-redemption-add): A viewer has redeemed a custom channel points reward on the specified channel.
- [Channel Points Custom Reward Redemption Update](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-custom-reward-redemption-update): A redemption of a channel points custom reward has been updated for the specified channel.
- [Channel Points Custom Reward Add](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-custom-reward-add): A custom channel points reward has been created for the specified channel.
- [Channel Points Custom Reward Remove](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-custom-reward-remove): A custom channel points reward has been removed from the specified channel.
- [Channel Points Custom Reward Update](https://dev.twitch.tv/docs/eventsub/reference/channel-points.md#channel-channel-points-custom-reward-update): A custom channel points reward has been updated for the specified channel.

## Charity {#charity}

Events raised as a broadcaster's charity campaign starts, receives donations, progresses and stops.

- [Charity Donation](https://dev.twitch.tv/docs/eventsub/reference/charity.md#channel-charity-campaign-donate): Sends an event notification when a user donates to the broadcaster's charity campaign.
- [Charity Campaign Progress](https://dev.twitch.tv/docs/eventsub/reference/charity.md#channel-charity-campaign-progress): Sends an event notification when progress is made towards the campaign's goal or when the broadcaster changes the fundraising goal.
- [Charity Campaign Start](https://dev.twitch.tv/docs/eventsub/reference/charity.md#channel-charity-campaign-start): Sends an event notification when the broadcaster starts a charity campaign.
- [Charity Campaign Stop](https://dev.twitch.tv/docs/eventsub/reference/charity.md#channel-charity-campaign-stop): Sends an event notification when the broadcaster stops a charity campaign.

## Chat {#chat}

Events raised by activity in a channel's chat room — messages, deletions, holds, and the shared chat sessions a channel takes part in.

- [Channel Chat Settings Update](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-settings-update): A notification for when a broadcaster's chat settings are updated.
- [Channel Chat Clear](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-clear): A moderator or bot has cleared all messages from the chat room.
- [Channel Chat Clear User Messages](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-clear-user-messages): A moderator or bot has cleared all messages from a specific user.
- [Channel Chat Message](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-message): Any user sends a message to a specific chat room.
- [Channel Chat Message Delete](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-message-delete): A moderator has removed a specific message.
- [Channel Chat Notification](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-notification): A notification for when an event that appears in chat has occurred.
- [Channel Chat User Message Hold](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-user-message-hold): A user is notified if their message is caught by automod.
- [Channel Chat User Message Update](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-chat-user-message-update): A user is notified if their message's automod status is updated.
- [Channel Shared Chat Session Begin](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-shared-chat-begin): A notification when a channel becomes active in an active shared chat session.
- [Channel Shared Chat Session End](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-shared-chat-end): A notification when a channel leaves a shared chat session or the session ends.
- [Channel Shared Chat Session Update](https://dev.twitch.tv/docs/eventsub/reference/chat.md#channel-shared-chat-update): A notification when the active shared chat session the channel is in changes.

## Conduit {#conduit}

Events raised when a conduit's shards change state.

- [Conduit Shard Disabled](https://dev.twitch.tv/docs/eventsub/reference/conduit.md#conduit-shard-disabled): Sends a notification when EventSub disables a shard due to the status of the underlying transport changing.

## Drop {#drop}

Events raised when a Drop entitlement is granted.

- [Drop Entitlement Grant](https://dev.twitch.tv/docs/eventsub/reference/drop.md#drop-entitlement-grant): An entitlement for a Drop is granted to a user.

## Extension {#extension}

Events raised when a viewer completes a Bits transaction in an extension.

- [Extension Bits Transaction Create](https://dev.twitch.tv/docs/eventsub/reference/extension.md#extension-bits-transaction-create): A Bits transaction occurred for a specified Twitch Extension.

## Goal {#goal}

Events raised as a broadcaster's creator goal starts, progresses and ends.

- [Goal Begin](https://dev.twitch.tv/docs/eventsub/reference/goal.md#channel-goal-begin): Get notified when a broadcaster begins a goal.
- [Goal End](https://dev.twitch.tv/docs/eventsub/reference/goal.md#channel-goal-end): Get notified when a broadcaster ends a goal.
- [Goal Progress](https://dev.twitch.tv/docs/eventsub/reference/goal.md#channel-goal-progress): Get notified when progress (either positive or negative) is made towards a broadcaster's goal.

## Guest Star {#guest-star}

Events raised as a Guest Star session begins and ends, a guest or slot changes, and the host updates their Guest Star preferences.

- [Channel Guest Star Guest Update](https://dev.twitch.tv/docs/eventsub/reference/guest-star.md#channel-guest-star-guest-update): A guest or a slot is updated in an active Guest Star session.
- [Channel Guest Star Session Begin](https://dev.twitch.tv/docs/eventsub/reference/guest-star.md#channel-guest-star-session-begin): The host began a new Guest Star session.
- [Channel Guest Star Session End](https://dev.twitch.tv/docs/eventsub/reference/guest-star.md#channel-guest-star-session-end): A running Guest Star session has ended.
- [Channel Guest Star Settings Update](https://dev.twitch.tv/docs/eventsub/reference/guest-star.md#channel-guest-star-settings-update): The host preferences for Guest Star have been updated.

## Hype Train {#hype-train}

Events raised when a Hype Train starts, progresses, or ends on a channel.

- [Hype Train Begin](https://dev.twitch.tv/docs/eventsub/reference/hype-train.md#channel-hype-train-begin): A Hype Train begins on the specified channel.
- [Hype Train End](https://dev.twitch.tv/docs/eventsub/reference/hype-train.md#channel-hype-train-end): A Hype Train ends on the specified channel.
- [Hype Train Progress](https://dev.twitch.tv/docs/eventsub/reference/hype-train.md#channel-hype-train-progress): A Hype Train makes progress on the specified channel.

## Poll {#poll}

Events raised as a poll starts, collects votes and ends on a channel.

- [Channel Poll Begin](https://dev.twitch.tv/docs/eventsub/reference/poll.md#channel-poll-begin): A poll started on a specified channel.
- [Channel Poll End](https://dev.twitch.tv/docs/eventsub/reference/poll.md#channel-poll-end): A poll ended on a specified channel.
- [Channel Poll Progress](https://dev.twitch.tv/docs/eventsub/reference/poll.md#channel-poll-progress): Users respond to a poll on a specified channel.

## Prediction {#prediction}

Events raised as a Channel Points Prediction starts, takes predictions, locks and resolves.

- [Channel Prediction Begin](https://dev.twitch.tv/docs/eventsub/reference/prediction.md#channel-prediction-begin): A Prediction started on a specified channel.
- [Channel Prediction End](https://dev.twitch.tv/docs/eventsub/reference/prediction.md#channel-prediction-end): A Prediction ended on a specified channel.
- [Channel Prediction Lock](https://dev.twitch.tv/docs/eventsub/reference/prediction.md#channel-prediction-lock): A Prediction was locked on a specified channel.
- [Channel Prediction Progress](https://dev.twitch.tv/docs/eventsub/reference/prediction.md#channel-prediction-progress): Users participated in a Prediction on a specified channel.

## Stream {#stream}

Events raised when a broadcaster starts or stops streaming.

- [Stream Offline](https://dev.twitch.tv/docs/eventsub/reference/stream.md#stream-offline): The specified broadcaster stops a stream.
- [Stream Online](https://dev.twitch.tv/docs/eventsub/reference/stream.md#stream-online): The specified broadcaster starts a stream.

## User {#user}

Events raised when a user updates their account, manages your app's authorization, or receives a whisper.

- [User Authorization Grant](https://dev.twitch.tv/docs/eventsub/reference/user.md#user-authorization-grant): A user's authorization has been granted to your client id.
- [User Authorization Revoke](https://dev.twitch.tv/docs/eventsub/reference/user.md#user-authorization-revoke): A user's authorization has been revoked for your client id.
- [User Update](https://dev.twitch.tv/docs/eventsub/reference/user.md#user-update): A user has updated their account.
- [Whisper Received](https://dev.twitch.tv/docs/eventsub/reference/user.md#user-whisper-message): A user receives a whisper.
