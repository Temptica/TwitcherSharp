# Channel Moderation

Events raised when a moderation event happens on a Twitch channel.

Source: https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/

## Contents {#contents}

14 entries on this page:

- [Channel Ban](#channel-ban)
- [Channel Moderate](#channel-moderate)
- [Channel Moderate V2](#channel-moderate-v2)
- [Channel Moderator Add](#channel-moderator-add)
- [Channel Moderator Remove](#channel-moderator-remove)
- [Shield Mode Begin](#channel-shield-mode-begin)
- [Shield Mode End](#channel-shield-mode-end)
- [Channel Suspicious User Message](#channel-suspicious-user-message)
- [Channel Suspicious User Update](#channel-suspicious-user-update)
- [Channel Unban](#channel-unban)
- [Channel Unban Request Create](#channel-unban-request-create)
- [Channel Unban Request Resolve](#channel-unban-request-resolve)
- [Channel Warning Acknowledgement](#channel-warning-acknowledge)
- [Channel Warning Send](#channel-warning-send)

## Channel Ban {#channel-ban}

The `channel.ban` subscription type sends a notification when a viewer is timed out or banned from the specified channel.

### Subscription

- Type: `channel.ban`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:moderate** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:moderate** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.ban`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive ban notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get ban notifications for.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get ban notifications for.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.user_id` — String. The user ID for the user who was banned on the specified channel.
  - `event.user_login` — String. The user login for the user who was banned on the specified channel.
  - `event.user_name` — String. The user display name for the user who was banned on the specified channel.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.moderator_user_id` — String. The user ID of the issuer of the ban.
  - `event.moderator_user_login` — String. The user login of the issuer of the ban.
  - `event.moderator_user_name` — String. The user name of the issuer of the ban.
  - `event.reason` — String. The reason behind the ban.
  - `event.banned_at` — String. The UTC date and time (in RFC3339 format) of when the user was banned or put in a timeout.
  - `event.ends_at` — String, Nullable. The UTC date and time (in RFC3339 format) of when the timeout ends. Is **null** if the user was banned instead of put in a timeout.
  - `event.is_permanent` — Boolean. Indicates whether the ban is permanent (true) or a timeout (false). If true, `ends_at` will be null.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.ban",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
    "subscription": {
        "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
        "type": "channel.ban",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "user_id": "1234",
        "user_login": "cool_user",
        "user_name": "Cool_User",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cooler_user",
        "broadcaster_user_name": "Cooler_User",
        "moderator_user_id": "1339",
        "moderator_user_login": "mod_user",
        "moderator_user_name": "Mod_User",
        "reason": "Offensive language",
        "banned_at": "2020-07-15T18:15:11.17106713Z",
        "ends_at": "2020-07-15T18:16:11.17106713Z",
        "is_permanent": false
    }
}
```

## Channel Moderate {#channel-moderate}

The `channel.moderate` subscription type sends a notification when a moderator performs a moderation action in a channel. Some of these actions affect chatters in other channels during Shared Chat.

### Subscription

- Type: `channel.moderate`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes all of the following:
  - **moderator:read:blocked_terms** or **moderator:manage:blocked_terms**
  - **moderator:read:chat_settings** or **moderator:manage:chat_settings**
  - **moderator:read:unban_requests** or **moderator:manage:unban_requests**
  - **moderator:read:banned_users** or **moderator:manage:banned_users**
  - **moderator:read:chat_messages** or **moderator:manage:chat_messages**
  - **moderator:read:warnings** or **moderator:manage:warnings**
  - **moderator:read:moderators**
  - **moderator:read:vips**
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - All of the following, for the user represented by the *moderator_user_id* event condition:
    - **moderator:read:blocked_terms** or **moderator:manage:blocked_terms**
    - **moderator:read:chat_settings** or **moderator:manage:chat_settings**
    - **moderator:read:unban_requests** or **moderator:manage:unban_requests**
    - **moderator:read:banned_users** or **moderator:manage:banned_users**
    - **moderator:read:chat_messages** or **moderator:manage:chat_messages**
    - **moderator:read:warnings** or **moderator:manage:warnings**
    - **moderator:read:moderators**
    - **moderator:read:vips**

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.moderate`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The user ID of the broadcaster.
  - `condition.moderator_user_id` — String, **Required**. The user ID of the moderator.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The user ID of the broadcaster.
    - `subscription.condition.moderator_user_id` — String. The user ID of the moderator.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The ID of the broadcaster.
  - `event.broadcaster_user_login` — String. The login of the broadcaster.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster.
  - `event.source_broadcaster_user_id` — String. The channel in which the action originally occurred. Is the same as the `broadcaster_user_id` if not in shared chat.
  - `event.source_broadcaster_user_login` — String. The channel in which the action originally occurred. Is the same as the `broadcaster_user_login` if not in shared chat.
  - `event.source_broadcaster_user_name` — String, Nullable. The channel in which the action originally occurred. Is **null** when the moderator action happens in the same channel as the broadcaster. Is not **null** when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.moderator_user_id` — String. The ID of the moderator who performed the action.
  - `event.moderator_user_login` — String. The login of the moderator.
  - `event.moderator_user_name` — String. The user name of the moderator.
  - `event.action` — String. The type of action: Possible values are.
    Possible values:
    - `ban`
    - `timeout`
    - `unban`
    - `untimeout`
    - `clear`
    - `emoteonly`
    - `emoteonlyoff`
    - `followers`
    - `followersoff`
    - `uniquechat`
    - `uniquechatoff`
    - `slow`
    - `slowoff`
    - `subscribers`
    - `subscribersoff`
    - `unraid`
    - `delete`
    - `unvip`
    - `vip`
    - `raid`
    - `add_blocked_term`
    - `add_permitted_term`
    - `remove_blocked_term`
    - `remove_permitted_term`
    - `mod`
    - `unmod`
    - `approve_unban_request`
    - `deny_unban_request`
    - `shared_chat_ban`
    - `shared_chat_timeout`
    - `shared_chat_untimeout`
    - `shared_chat_unban`
    - `shared_chat_delete`
  - `event.followers` — Object, Nullable. Metadata associated with the followers command.
    - `event.followers.follow_duration_minutes` — Integer. The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
  - `event.slow` — Object, Nullable. Metadata associated with the slow command.
    - `event.slow.wait_time_seconds` — Integer. The amount of time, in seconds, that users need to wait between sending messages.
  - `event.vip` — Object, Nullable. Metadata associated with the vip command.
    - `event.vip.user_id` — String. The ID of the user gaining VIP status.
    - `event.vip.user_login` — String. The login of the user gaining VIP status.
    - `event.vip.user_name` — String. The user name of the user gaining VIP status.
  - `event.unvip` — Object, Nullable. Metadata associated with the unvip command.
    - `event.unvip.user_id` — String. The ID of the user losing VIP status.
    - `event.unvip.user_login` — String. The login of the user losing VIP status.
    - `event.unvip.user_name` — String. The user name of the user losing VIP status.
  - `event.mod` — Object, Nullable. Metadata associated with the mod command.
    - `event.mod.user_id` — String. The ID of the user gaining mod status.
    - `event.mod.user_login` — String. The login of the user gaining mod status.
    - `event.mod.user_name` — String. The user name of the user gaining mod status.
  - `event.unmod` — Object, Nullable. Metadata associated with the unmod command.
    - `event.unmod.user_id` — String. The ID of the user losing mod status.
    - `event.unmod.user_login` — String. The login of the user losing mod status.
    - `event.unmod.user_name` — String. The user name of the user losing mod status.
  - `event.ban` — Object, Nullable. Metadata associated with the ban command.
    - `event.ban.user_id` — String. The ID of the user being banned.
    - `event.ban.user_login` — String. The login of the user being banned.
    - `event.ban.user_name` — String. The user name of the user being banned.
    - `event.ban.reason` — String, Nullable. Reason given for the ban.
  - `event.unban` — Object, Nullable. Metadata associated with the unban command.
    - `event.unban.user_id` — String. The ID of the user being unbanned.
    - `event.unban.user_login` — String. The login of the user being unbanned.
    - `event.unban.user_name` — String. The user name of the user being unbanned.
  - `event.timeout` — Object, Nullable. Metadata associated with the timeout command.
    - `event.timeout.user_id` — String. The ID of the user being timed out.
    - `event.timeout.user_login` — String. The login of the user being timed out.
    - `event.timeout.user_name` — String. The user name of the user being timed out.
    - `event.timeout.reason` — String, Nullable. The reason given for the timeout.
    - `event.timeout.expires_at` — String. The time at which the timeout ends.
  - `event.untimeout` — Object, Nullable. Metadata associated with the untimeout command.
    - `event.untimeout.user_id` — String. The ID of the user being untimed out.
    - `event.untimeout.user_login` — String. The login of the user being untimed out.
    - `event.untimeout.user_name` — String. The user name of the user untimed out.
  - `event.raid` — Object, Nullable. Metadata associated with the raid command.
    - `event.raid.user_id` — String. The ID of the user being raided.
    - `event.raid.user_login` — String. The login of the user being raided.
    - `event.raid.user_name` — String. The user name of the user raided.
    - `event.raid.viewer_count` — Integer. The viewer count.
  - `event.unraid` — Object, Nullable. Metadata associated with the unraid command.
    - `event.unraid.user_id` — String. The ID of the user no longer being raided.
    - `event.unraid.user_login` — String. The login of the user no longer being raided.
    - `event.unraid.user_name` — String. The user name of the no longer user raided.
  - `event.delete` — Object, Nullable. Metadata associated with the delete command.
    - `event.delete.user_id` — String. The ID of the user whose message is being deleted.
    - `event.delete.user_login` — String. The login of the user.
    - `event.delete.user_name` — String. The user name of the user.
    - `event.delete.message_id` — String. The ID of the message being deleted.
    - `event.delete.message_body` — String. The message body of the message being deleted.
  - `event.automod_terms` — Object, Nullable. Metadata associated with the automod terms changes.
    - `event.automod_terms.action` — String. Either “add” or “remove”.
    - `event.automod_terms.list` — String. Either “blocked” or “permitted”.
    - `event.automod_terms.terms` — String[]. Terms being added or removed.
    - `event.automod_terms.from_automod` — Boolean. Whether the terms were added due to an Automod message approve/deny action.
  - `event.unban_request` — Object, Nullable. Metadata associated with an unban request.
    - `event.unban_request.is_approved` — Boolean. Whether or not the unban request was approved or denied.
    - `event.unban_request.user_id` — String. The ID of the banned user.
    - `event.unban_request.user_login` — String. The login of the user.
    - `event.unban_request.user_name` — String. The user name of the user.
    - `event.unban_request.moderator_message` — String. The message included by the moderator explaining their approval or denial.
  - `event.shared_chat_ban` — Object, Nullable. Information about the `shared_chat_ban` event. Is null if `action` is not `shared_chat_ban`. This field has the same information as the `ban` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_unban` — Object, Nullable. Information about the `shared_chat_unban` event. Is null if `action` is not `shared_chat_unban`. This field has the same information as the `unban` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_timeout` — Object, Nullable. Information about the `shared_chat_timeout` event. Is null if `action` is not `shared_chat_timeout`. This field has the same information as the `timeout` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_untimeout` — Object, Nullable. Information about the `shared_chat_untimeout` event. Is null if `action` is not `shared_chat_untimeout`. This field has the same information as the `untimeout` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_delete` — Object, Nullable. Information about the `shared_chat_delete` event. Is null if `action` is not `shared_chat_delete`. This field has the same information as the `delete` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.moderate",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "423374343",
    "moderator_user_id": "424596340"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "7297f7eb-3bf5-461f-8ae6-7cd7781ebce3",
    "status": "enabled",
    "type": "channel.moderate",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1337"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2024-02-23T21:12:33.771005262Z"
  },
  "event": {
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "glowillig",
    "broadcaster_user_name": "glowillig",
    "moderator_user_id": "424596340",
    "moderator_user_login": "quotrok",
    "moderator_user_name": "quotrok",
    "action": "mod",
    "followers": null,
    "slow": null,
    "vip": null,
    "unvip": null,
    "mod": {
      "user_id": "141981764",
      "user_login": "twitchdev",
      "user_name": "TwitchDev"
    },
    "unmod": null,
    "ban": null,
    "unban": null,
    "timeout": null,
    "untimeout": null,
    "raid": null,
    "unraid": null,
    "delete": null,
    "automod_terms": null,
    "unban_request": null,
    "shared_chat_ban": null,
    "shared_chat_unban": null,
    "shared_chat_timeout": null,
    "shared_chat_untimeout": null,
    "shared_chat_delete": null
  }
}
```

## Channel Moderate V2 {#channel-moderate-v2}

The `channel.moderate` subscription type sends a notification when a moderator performs a moderation action in a channel. Some of these actions affect chatters in other channels during Shared Chat.
 * This is the second version of `channel.moderate` with warnings added.

### Subscription

- Type: `channel.moderate`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes all of the following:
  - **moderator:read:blocked_terms** or **moderator:manage:blocked_terms**
  - **moderator:read:chat_settings** or **moderator:manage:chat_settings**
  - **moderator:read:unban_requests** or **moderator:manage:unban_requests**
  - **moderator:read:banned_users** or **moderator:manage:banned_users**
  - **moderator:read:chat_messages** or **moderator:manage:chat_messages**
  - **moderator:read:warnings** or **moderator:manage:warnings**
  - **moderator:read:moderators**
  - **moderator:read:vips**
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - All of the following, for the user represented by the *moderator_user_id* event condition:
    - **moderator:read:blocked_terms** or **moderator:manage:blocked_terms**
    - **moderator:read:chat_settings** or **moderator:manage:chat_settings**
    - **moderator:read:unban_requests** or **moderator:manage:unban_requests**
    - **moderator:read:banned_users** or **moderator:manage:banned_users**
    - **moderator:read:chat_messages** or **moderator:manage:chat_messages**
    - **moderator:read:warnings** or **moderator:manage:warnings**
    - **moderator:read:moderators**
    - **moderator:read:vips**

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.moderate`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The user ID of the broadcaster.
  - `condition.moderator_user_id` — String, **Required**. The user ID of the moderator.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The user ID of the broadcaster.
    - `subscription.condition.moderator_user_id` — String. The user ID of the moderator.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The ID of the broadcaster.
  - `event.broadcaster_user_login` — String. The login of the broadcaster.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster.
  - `event.source_broadcaster_user_id` — String. The channel in which the action originally occurred. Is the same as the broadcaster_user_id if not in shared chat.
  - `event.source_broadcaster_user_login` — String. The channel in which the action originally occurred. Is the same as the broadcaster_user_login if not in shared chat.
  - `event.source_broadcaster_user_name` — String, Nullable. The channel in which the action originally occurred. Is **null** when the moderator action happens in the same channel as the broadcaster. Is not **null** when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.moderator_user_id` — String. The ID of the moderator who performed the action.
  - `event.moderator_user_login` — String. The login of the moderator.
  - `event.moderator_user_name` — String. The user name of the moderator.
  - `event.action` — String. The action performed.
    Possible values:
    - `ban`
    - `timeout`
    - `unban`
    - `untimeout`
    - `clear`
    - `emoteonly`
    - `emoteonlyoff`
    - `followers`
    - `followersoff`
    - `uniquechat`
    - `uniquechatoff`
    - `slow`
    - `slowoff`
    - `subscribers`
    - `subscribersoff`
    - `unraid`
    - `delete`
    - `unvip`
    - `vip`
    - `raid`
    - `add_blocked_term`
    - `add_permitted_term`
    - `remove_blocked_term`
    - `remove_permitted_term`
    - `mod`
    - `unmod`
    - `approve_unban_request`
    - `deny_unban_request`
    - `warn`
    - `shared_chat_ban`
    - `shared_chat_timeout`
    - `shared_chat_unban`
    - `shared_chat_untimeout`
    - `shared_chat_delete`
  - `event.followers` — Object, Nullable. Metadata associated with the followers command.
    - `event.followers.follow_duration_minutes` — Integer. The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
  - `event.slow` — Object, Nullable. Metadata associated with the slow command.
    - `event.slow.wait_time_seconds` — Integer. The amount of time, in seconds, that users need to wait between sending messages.
  - `event.vip` — Object, Nullable. Metadata associated with the vip command.
    - `event.vip.user_id` — String. The ID of the user gaining VIP status.
    - `event.vip.user_login` — String. The login of the user gaining VIP status.
    - `event.vip.user_name` — String. The user name of the user gaining VIP status.
  - `event.unvip` — Object, Nullable. Metadata associated with the unvip command.
    - `event.unvip.user_id` — String. The ID of the user losing VIP status.
    - `event.unvip.user_login` — String. The login of the user losing VIP status.
    - `event.unvip.user_name` — String. The user name of the user losing VIP status.
  - `event.mod` — Object, Nullable. Metadata associated with the mod command.
    - `event.mod.user_id` — String. The ID of the user gaining mod status.
    - `event.mod.user_login` — String. The login of the user gaining mod status.
    - `event.mod.user_name` — String. The user name of the user gaining mod status.
  - `event.unmod` — Object, Nullable. Metadata associated with the unmod command.
    - `event.unmod.user_id` — String. The ID of the user losing mod status.
    - `event.unmod.user_login` — String. The login of the user losing mod status.
    - `event.unmod.user_name` — String. The user name of the user losing mod status.
  - `event.ban` — Object, Nullable. Metadata associated with the ban command.
    - `event.ban.user_id` — String. The ID of the user being banned.
    - `event.ban.user_login` — String. The login of the user being banned.
    - `event.ban.user_name` — String. The user name of the user being banned.
    - `event.ban.reason` — String, Nullable. Reason given for the ban.
  - `event.unban` — Object, Nullable. Metadata associated with the unban command.
    - `event.unban.user_id` — String. The ID of the user being unbanned.
    - `event.unban.user_login` — String. The login of the user being unbanned.
    - `event.unban.user_name` — String. The user name of the user being unbanned.
  - `event.timeout` — Object, Nullable. Metadata associated with the timeout command.
    - `event.timeout.user_id` — String. The ID of the user being timed out.
    - `event.timeout.user_login` — String. The login of the user being timed out.
    - `event.timeout.user_name` — String. The user name of the user being timed out.
    - `event.timeout.reason` — String, Nullable. The reason given for the timeout.
    - `event.timeout.expires_at` — String. The time at which the timeout ends.
  - `event.untimeout` — Object, Nullable. Metadata associated with the untimeout command.
    - `event.untimeout.user_id` — String. The ID of the user being untimed out.
    - `event.untimeout.user_login` — String. The login of the user being untimed out.
    - `event.untimeout.user_name` — String. The user name of the user untimed out.
  - `event.raid` — Object, Nullable. Metadata associated with the raid command.
    - `event.raid.user_id` — String. The ID of the user being raided.
    - `event.raid.user_login` — String. The login of the user being raided.
    - `event.raid.user_name` — String. The user name of the user raided.
    - `event.raid.viewer_count` — Integer. The viewer count.
  - `event.unraid` — Object, Nullable. Metadata associated with the unraid command.
    - `event.unraid.user_id` — String. The ID of the user no longer being raided.
    - `event.unraid.user_login` — String. The login of the user no longer being raided.
    - `event.unraid.user_name` — String. The user name of the no longer user raided.
  - `event.delete` — Object, Nullable. Metadata associated with the delete command.
    - `event.delete.user_id` — String. The ID of the user whose message is being deleted.
    - `event.delete.user_login` — String. The login of the user.
    - `event.delete.user_name` — String. The user name of the user.
    - `event.delete.message_id` — String. The ID of the message being deleted.
    - `event.delete.message_body` — String. The message body of the message being deleted.
  - `event.automod_terms` — Object, Nullable. Metadata associated with the automod terms changes.
    - `event.automod_terms.action` — String. Either “add” or “remove”.
    - `event.automod_terms.list` — String. Either “blocked” or “permitted”.
    - `event.automod_terms.terms` — String[]. Terms being added or removed.
    - `event.automod_terms.from_automod` — Boolean. Whether the terms were added due to an Automod message approve/deny action.
  - `event.unban_request` — Object, Nullable. Metadata associated with an unban request.
    - `event.unban_request.is_approved` — Boolean. Whether or not the unban request was approved or denied.
    - `event.unban_request.user_id` — String. The ID of the banned user.
    - `event.unban_request.user_login` — String. The login of the user.
    - `event.unban_request.user_name` — String. The user name of the user.
    - `event.unban_request.moderator_message` — String. The message included by the moderator explaining their approval or denial.
  - `event.warn` — Object, Nullable. Metadata associated with the warn command.
    - `event.warn.user_id` — String. The ID of the user being warned.
    - `event.warn.user_login` — String. The login of the user being warned.
    - `event.warn.user_name` — String. The user name of the user being warned.
    - `event.warn.reason` — String, Nullable. Reason given for the warning.
    - `event.warn.chat_rules_cited` — String[], Nullable. Chat rules cited for the warning.
  - `event.shared_chat_ban` — Object, Nullable. Information about the `shared_chat_ban` event. Is null if `action` is not `shared_chat_ban`. This field has the same information as the `ban` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_unban` — Object, Nullable. Information about the `shared_chat_unban` event. Is null if `action` is not `shared_chat_unban`. This field has the same information as the `unban` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_timeout` — Object, Nullable. Information about the `shared_chat_timeout` event. Is null if `action` is not `shared_chat_timeout`. This field has the same information as the `timeout` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_untimeout` — Object, Nullable. Information about the `shared_chat_untimeout` event. Is null if `action` is not `shared_chat_untimeout`. This field has the same information as the `untimeout` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_delete` — Object, Nullable. Information about the `shared_chat_delete` event. Is null if `action` is not `shared_chat_delete`. This field has the same information as the `delete` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.moderate",
  "version": "2",
  "condition": {
    "broadcaster_user_id": "423374343",
    "moderator_user_id": "424596340"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "7297f7eb-3bf5-461f-8ae6-7cd7781ebce3",
    "status": "enabled",
    "type": "channel.moderate",
    "version": "2",
    "condition": {
      "broadcaster_user_id": "423374343",
      "moderator_user_id": "424596340"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2024-02-23T21:12:33.771005262Z"
  },
  "event": {
      "broadcaster_user_id": "423374343",
      "broadcaster_user_login": "glowillig",
      "broadcaster_user_name": "glowillig",
      "source_broadcaster_user_id": "41292030",
      "source_broadcaster_user_login": "adflynn404",
      "source_broadcaster_user_name": "adflynn404",
      "moderator_user_id": "424596340",
      "moderator_user_login": "quotrok",
      "moderator_user_name": "quotrok",
      "action": "warn",
      "followers": null,
      "slow": null,
      "vip": null,
      "unvip": null,
      "warn": {
        "user_id": "141981764",
        "user_login": "twitchdev",
        "user_name": "TwitchDev",
        "reason": "cut it out",
        "chat_rules_cited": null
      },
      "unmod": null,
      "ban": null,
      "unban": null,
      "timeout": null,
      "untimeout": null,
      "raid": null,
      "unraid": null,
      "delete": null,
      "automod_terms": null,
      "unban_request": null,
      "shared_chat_ban": null,
      "shared_chat_unban": null,
      "shared_chat_timeout": null,
      "shared_chat_untimeout": null,
      "shared_chat_delete": null
  }
}
```

## Channel Moderator Add {#channel-moderator-add}

The `channel.moderator.add` subscription type sends a notification when a user is given moderator privileges on a specified channel.

### Subscription

- Type: `channel.moderator.add`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderation:read** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderation:read** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.moderator.add`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive moderator addition notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get moderator addition notifications for.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get moderator addition notifications for.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.user_id` — String. The user ID of the new moderator.
  - `event.user_login` — String. The user login of the new moderator.
  - `event.user_name` — String. The display name of the new moderator.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.moderator.add",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
    "subscription": {
        "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
        "type": "channel.moderator.add",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "user_id": "1234",
        "user_login": "mod_user",
        "user_name": "Mod_User",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cooler_user",
        "broadcaster_user_name": "Cooler_User"
    }
}
```

## Channel Moderator Remove {#channel-moderator-remove}

The `channel.moderator.remove` subscription type sends a notification when a user has moderator privileges removed on a specified channel.

### Subscription

- Type: `channel.moderator.remove`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderation:read** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderation:read** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.moderator.remove`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive moderator removal notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get moderator removal notifications for.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get moderator removal notifications for.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.user_id` — String. The user ID of the removed moderator.
  - `event.user_login` — String. The user login of the removed moderator.
  - `event.user_name` — String. The display name of the removed moderator.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.moderator.remove",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
    "subscription": {
        "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
        "type": "channel.moderator.remove",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "user_id": "1234",
        "user_login": "not_mod_user",
        "user_name": "Not_Mod_User",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cooler_user",
        "broadcaster_user_name": "Cooler_User"
    }
}
```

## Shield Mode Begin {#channel-shield-mode-begin}

Sends a notification when the broadcaster activates Shield Mode.
This event informs the subscriber that the broadcaster's moderation settings were changed based on the broadcaster's Shield Mode configuration settings.

### Subscription

- Type: `channel.shield_mode.begin`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.shield_mode.begin**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when they activate Shield Mode.
  - `condition.moderator_user_id` — String, **Required**. The ID of the broadcaster or one of the broadcaster's moderators.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending event notifications.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when they activate Shield Mode.
    - `subscription.condition.moderator_user_id` — String. The ID of the broadcaster or one of the broadcaster's moderators.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. An ID that identifies the broadcaster whose Shield Mode status was updated.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.moderator_user_id` — String. An ID that identifies the moderator that updated the Shield Mode's status. If the broadcaster updated the status, this ID will be the same as `broadcaster_user_id`.
  - `event.moderator_user_login` — String. The moderator's login name.
  - `event.moderator_user_name` — String. The moderator's display name.
  - `event.started_at` — String. The UTC timestamp (in RFC3339 format) of when the moderator activated Shield Mode. The object includes this field only for **channel.shield_mode.begin** events.
  - `event.ended_at` — String. The UTC timestamp (in RFC3339 format) of when the moderator deactivated Shield Mode. The object includes this field only for **channel.shield_mode.end** events.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shield_mode.begin",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "12345",
    "moderator_user_id": "98765"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.shield_mode.begin",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "12345",
      "moderator_user_id": "98765"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.1236739Z"
  },
  "event": {
    "broadcaster_user_id": "12345",
    "broadcaster_user_name": "SimplySimple",
    "broadcaster_user_login": "simplysimple",
    "moderator_user_id": "98765",
    "moderator_user_name": "ParticularlyParticular123",
    "moderator_user_login": "particularlyparticular123",
    "started_at": "2022-07-26T17:00:03.17106713Z"
  }
}
```

## Shield Mode End {#channel-shield-mode-end}

Sends a notification when the broadcaster deactivates Shield Mode.
This event informs the subscriber that the broadcaster's moderation settings were changed back to the broadcaster's previous moderation settings.

### Subscription

- Type: `channel.shield_mode.end`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.shield_mode.end**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when they deactivate Shield Mode.
  - `condition.moderator_user_id` — String, **Required**. The ID of the broadcaster or one of the broadcaster's moderators.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending event notifications.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when they deactivate Shield Mode.
    - `subscription.condition.moderator_user_id` — String. The ID of the broadcaster or one of the broadcaster's moderators.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. An ID that identifies the broadcaster whose Shield Mode status was updated.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.moderator_user_id` — String. An ID that identifies the moderator that updated the Shield Mode's status. If the broadcaster updated the status, this ID will be the same as `broadcaster_user_id`.
  - `event.moderator_user_login` — String. The moderator's login name.
  - `event.moderator_user_name` — String. The moderator's display name.
  - `event.started_at` — String. The UTC timestamp (in RFC3339 format) of when the moderator activated Shield Mode. The object includes this field only for **channel.shield_mode.begin** events.
  - `event.ended_at` — String. The UTC timestamp (in RFC3339 format) of when the moderator deactivated Shield Mode. The object includes this field only for **channel.shield_mode.end** events.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shield_mode.end",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "12345",
    "moderator_user_id": "98765"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.shield_mode.end",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "12345",
      "moderator_user_id": "98765"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.1236739Z"
  },
  "event": {
    "broadcaster_user_id": "12345",
    "broadcaster_user_name": "SimplySimple",
    "broadcaster_user_login": "simplysimple",
    "moderator_user_id": "98765",
    "moderator_user_name": "ParticularlyParticular123",
    "moderator_user_login": "particularlyparticular123",
    "ended_at": "2022-07-27T01:30:23.17106713Z"
  }
}
```

## Channel Suspicious User Message {#channel-suspicious-user-message}

The `channel.suspicious_user.message` subscription type sends a notification when a chat message has been sent from a suspicious user.

### Subscription

- Type: `channel.suspicious_user.message`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:suspicious_users** scope. If you use WebSockets, the ID in *moderator_user_id* must match the user ID in the user access token.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:suspicious_users** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.suspicious_user.message`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.moderator_user_id` — String, **Required**. The ID of a user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat message events for.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.moderator_user_id` — String. The ID of a user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat message events for.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The ID of the channel where the treatment for a suspicious user was updated.
  - `event.broadcaster_user_name` — String. The display name of the channel where the treatment for a suspicious user was updated.
  - `event.broadcaster_user_login` — String. The login of the channel where the treatment for a suspicious user was updated.
  - `event.user_id` — String. The user ID of the user that sent the message.
  - `event.user_name` — String. The user name of the user that sent the message.
  - `event.user_login` — String. The user login of the user that sent the message.
  - `event.low_trust_status` — String. The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”
  - `event.shared_ban_channel_ids` — String[]. A list of channel IDs where the suspicious user is also banned.
  - `event.types` — String[]. User types (if any) that apply to the suspicious user, can be “manually_added”, “ban_evader”, or “banned_in_shared_channel”.
  - `event.ban_evasion_evaluation` — String. A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “unknown”, “possible”, or “likely”.
  - `event.message` — Object. The structured chat message.
    - `event.message.message_id` — String. The UUID that identifies the message.
    - `event.message.text` — String. The chat message in plain text.
    - `event.message.fragments` — Object[]. Ordered list of chat message fragments.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `cheermote`
        - `emote`
      - `event.message.fragments.text` — String. Message text in fragment.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.suspicious_user.message",
  "version": "1",
  "condition": {
    "moderator_user_id": "9001",
    "broadcaster_user_id": "1337"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

## Channel Suspicious User Update {#channel-suspicious-user-update}

The `channel.suspicious_user.update` subscription type sends a notification when a suspicious user has been updated.

### Subscription

- Type: `channel.suspicious_user.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:suspicious_users** scope. If you use WebSockets, the ID in *moderator_user_id* must match the user ID in the user access token.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:suspicious_users** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.suspicious_user.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.moderator_user_id` — String, **Required**. The ID of a user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster you want to get chat unban request notifications for.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.moderator_user_id` — String. The ID of a user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster you want to get chat unban request notifications for.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The ID of the channel where the treatment for a suspicious user was updated.
  - `event.broadcaster_user_name` — String. The display name of the channel where the treatment for a suspicious user was updated.
  - `event.broadcaster_user_login` — String. The Login of the channel where the treatment for a suspicious user was updated.
  - `event.moderator_user_id` — String. The ID of the moderator that updated the treatment for a suspicious user.
  - `event.moderator_user_name` — String. The display name of the moderator that updated the treatment for a suspicious user.
  - `event.moderator_user_login` — String. The login of the moderator that updated the treatment for a suspicious user.
  - `event.user_id` — String. The ID of the suspicious user whose treatment was updated.
  - `event.user_name` — String. The display name of the suspicious user whose treatment was updated.
  - `event.user_login` — String. The login of the suspicious user whose treatment was updated.
  - `event.low_trust_status` — String. The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.suspicious_user.update",
  "version": "1",
  "condition": {
    "moderator_user_id": "9001",
    "broadcaster_user_id": "1337"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.suspicious_user.update",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1050263435",
      "moderator_user_id": "1050263436"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2023-04-11T10:11:12.123Z"
  },
  "event": {
    "broadcaster_user_id": "1050263435",
    "broadcaster_user_name": "77f111cbb75341449f5",
    "broadcaster_user_login": "77f111cbb75341449f5",
    "moderator_user_id": "1050263436",
    "moderator_user_name": "29087e59dfc441968f6",
    "moderator_user_login": "29087e59dfc441968f6",
    "user_id": "1050263437",
    "user_name": "06fbcc75952245c5a87",
    "user_login": "06fbcc75952245c5a87",
    "low_trust_status": "restricted"
  }
}
```

## Channel Unban {#channel-unban}

The `channel.unban` subscription type sends a notification when a viewer is unbanned from the specified channel.

### Subscription

- Type: `channel.unban`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:moderate** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:moderate** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.unban`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive unban notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get unban notifications for.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get unban notifications for.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.user_id` — String. The user id for the user who was unbanned on the specified channel.
  - `event.user_login` — String. The user login for the user who was unbanned on the specified channel.
  - `event.user_name` — String. The user display name for the user who was unbanned on the specified channel.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.moderator_user_id` — String. The user ID of the issuer of the unban.
  - `event.moderator_user_login` — String. The user login of the issuer of the unban.
  - `event.moderator_user_name` — String. The user name of the issuer of the unban.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.unban",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
    "subscription": {
        "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
        "type": "channel.unban",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "user_id": "1234",
        "user_login": "cool_user",
        "user_name": "Cool_User",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cooler_user",
        "broadcaster_user_name": "Cooler_User",
        "moderator_user_id": "1339",
        "moderator_user_login": "mod_user",
        "moderator_user_name": "Mod_User"
    }
}
```

## Channel Unban Request Create {#channel-unban-request-create}

The `channel.unban_request.create` subscription type sends a notification when a user creates an unban request.

### Subscription

- Type: `channel.unban_request.create`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:unban_requests** or **moderator:manage:unban_requests** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:unban_requests** or **moderator:manage:unban_requests** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.unban_request.create`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.moderator_user_id` — String, **Required**. The ID of the user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster you want to get chat unban request notifications for. Maximum: 1.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.moderator_user_id` — String. The ID of the user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster you want to get chat unban request notifications for. Maximum: 1.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.id` — String. The ID of the unban request.
  - `event.broadcaster_user_id` — String. The broadcaster's user ID for the channel the unban request was created for.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.user_id` — String. User ID of user that is requesting to be unbanned.
  - `event.user_login` — String. The user's login name.
  - `event.user_name` — String. The user's display name.
  - `event.text` — String. Message sent in the unban request.
  - `event.created_at` — String. The UTC timestamp (in RFC3339 format) of when the unban request was created.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.unban_request.create",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "moderator_user_id": "1338"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.unban_request.create",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "moderator_user_id": "1338"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2019-11-16T10:11:12.634234626Z"
  },
  "event": {
    "id": "60",
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "cool_user",
    "broadcaster_user_name": "Cool_User",
    "user_id": "1339",
    "user_login": "not_cool_user",
    "user_name": "Not_Cool_User",
    "text": "unban me",
    "created_at": "2023-11-16T10:11:12.634234626Z"
  }
}
```

## Channel Unban Request Resolve {#channel-unban-request-resolve}

The `channel.unban_request.resolve` subscription type sends a notification when an unban request has been resolved.

### Subscription

- Type: `channel.unban_request.resolve`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:unban_requests** or **moderator:manage:unban_requests** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:unban_requests** or **moderator:manage:unban_requests** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.unban_request.resolve`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.moderator_user_id` — String, **Required**. The ID of the user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster you want to get unban request resolution notifications for. Maximum: 1.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.moderator_user_id` — String. The ID of the user that has permission to moderate the broadcaster's channel and has granted your app permission to subscribe to this subscription type.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster you want to get unban request resolution notifications for. Maximum: 1.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.id` — String. The ID of the unban request.
  - `event.broadcaster_user_id` — String. The broadcaster's user ID for the channel the unban request was updated for.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.moderator_user_id` — String, Nullable. User ID of moderator who approved/denied the request.
  - `event.moderator_user_login` — String, Nullable. The moderator's login name
  - `event.moderator_user_name` — String, Nullable. The moderator's display name
  - `event.user_id` — String. User ID of user that requested to be unbanned.
  - `event.user_login` — String. The user's login name.
  - `event.user_name` — String. The user's display name.
  - `event.resolution_text` — String, Nullable. Resolution text supplied by the mod/broadcaster upon approval/denial of the request.
  - `event.status` — String. Dictates whether the unban request was approved or denied. Can be the following.
    Possible values:
    - `approved`
    - `canceled`
    - `denied`

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.unban_request.resolve",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "moderator_user_id": "1338"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.unban_request.resolve",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "moderator_user_id": "1338"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2019-11-16T10:11:12.634234626Z"
  },
  "event": {
    "id": "60",
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "cool_user",
    "broadcaster_user_name": "Cool_User",
    "moderator_user_id": "1337",
    "moderator_user_login": "cool_user",
    "moderator_user_name": "Cool_User",
    "user_id": "1339",
    "user_login": "not_cool_user",
    "user_name": "Not_Cool_User",
    "resolution_text": "no",
    "status": "denied"
  }
}
```

## Channel Warning Acknowledgement {#channel-warning-acknowledge}

The `channel.warning.acknowledge` subscription type sends a notification when a warning is acknowledged by a user. Broadcasters and moderators can see the warning's details.

### Subscription

- Type: `channel.warning.acknowledge`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:warnings** or **moderator:manage:warnings** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:warnings** or **moderator:manage:warnings** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.warning.acknowledge`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the broadcaster.
  - `condition.moderator_user_id` — String, **Required**. The User ID of the moderator.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the broadcaster.
    - `subscription.condition.moderator_user_id` — String. The User ID of the moderator.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The user ID of the broadcaster.
  - `event.broadcaster_user_login` — String. The login of the broadcaster.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster.
  - `event.user_id` — String. The ID of the user that has acknowledged their warning.
  - `event.user_login` — String. The login of the user that has acknowledged their warning.
  - `event.user_name` — String. The user name of the user that has acknowledged their warning.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.warning.acknowledge",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "423374343",
    "moderator_user_id": "424596340"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "7297f7eb-3bf5-461f-8ae6-7cd7781ebce3",
    "status": "enabled",
    "type": "channel.warning.acknowledge",
    "version": "1",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "423374343",
      "moderator_user_id": "424596340"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2024-02-23T21:12:33.771005262Z"
  },
  "event": {
    "broadcaster_user_id": "423374343",
    "broadcaster_user_login": "glowillig",
    "broadcaster_user_name": "glowillig",
    "user_id": "141981764",
    "user_login": "twitchdev",
    "user_name": "TwitchDev"
  }
}
```

## Channel Warning Send {#channel-warning-send}

The `channel.warning.send` subscription type sends a notification when a warning is sent to a user. Broadcasters and moderators can see the warning's details.

### Subscription

- Type: `channel.warning.send`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:warnings** or **moderator:manage:warnings** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:warnings** or **moderator:manage:warnings** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.warning.send`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the broadcaster.
  - `condition.moderator_user_id` — String, **Required**. The User ID of the moderator.
- `transport` — Object, **Required**. Transport-specific parameters.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the broadcaster.
    - `subscription.condition.moderator_user_id` — String. The User ID of the moderator.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.broadcaster_user_id` — String. The user ID of the broadcaster.
  - `event.broadcaster_user_login` — String. The login of the broadcaster.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster.
  - `event.moderator_user_id` — String. The user ID of the moderator who sent the warning.
  - `event.moderator_user_login` — String. The login of the moderator.
  - `event.moderator_user_name` — String. The user name of the moderator.
  - `event.user_id` — String. The ID of the user being warned.
  - `event.user_login` — String. The login of the user being warned.
  - `event.user_name` — String. The user name of the user being.
  - `event.reason` — String, Nullable. The reason given for the warning.
  - `event.chat_rules_cited` — String[], Nullable. The chat rules cited for the warning.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.warning.send",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "423374343",
    "moderator_user_id": "424596340"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "7297f7eb-3bf5-461f-8ae6-7cd7781ebce3",
    "status": "enabled",
    "type": "channel.warning.send",
    "version": "1",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "423374343",
      "moderator_user_id": "424596340"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2024-02-23T21:12:33.771005262Z"
  },
  "event": {
    "broadcaster_user_id": "423374343",
    "broadcaster_user_login": "glowillig",
    "broadcaster_user_name": "glowillig",
    "moderator_user_id": "424596340",
    "moderator_user_login": "quotrok",
    "moderator_user_name": "quotrok",
    "user_id": "141981764",
    "user_login": "twitchdev",
    "user_name": "TwitchDev",
    "reason": "cut it out",
    "chat_rules_cited": null
  }
}
```
