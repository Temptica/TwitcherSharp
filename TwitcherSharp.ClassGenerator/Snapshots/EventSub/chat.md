# Chat

Events raised by activity in a channel's chat room — messages, deletions, holds, and the shared chat sessions a channel takes part in.

Source: https://dev.twitch.tv/docs/eventsub/reference/chat/

## Contents {#contents}

11 entries on this page:

- [Channel Chat Settings Update](#channel-chat-settings-update)
- [Channel Chat Clear](#channel-chat-clear)
- [Channel Chat Clear User Messages](#channel-chat-clear-user-messages)
- [Channel Chat Message](#channel-chat-message)
- [Channel Chat Message Delete](#channel-chat-message-delete)
- [Channel Chat Notification](#channel-chat-notification)
- [Channel Chat User Message Hold](#channel-chat-user-message-hold)
- [Channel Chat User Message Update](#channel-chat-user-message-update)
- [Channel Shared Chat Session Begin](#channel-shared-chat-begin)
- [Channel Shared Chat Session End](#channel-shared-chat-end)
- [Channel Shared Chat Session Update](#channel-shared-chat-update)

## Channel Chat Settings Update {#channel-chat-settings-update}

This event sends a notification when a broadcaster's chat settings are updated.

### Subscription

- Type: `channel.chat_settings.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.
  - The **channel:bot** scope for the user represented by the *broadcaster_user_id* event condition.
    Not required if the user in *user_id* already has moderator status.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat_settings.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat settings update events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat settings update events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The ID of the broadcaster specified in the request.
  - `event.broadcaster_user_login` — String. The login of the broadcaster specified in the request.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster specified in the request.
  - `event.emote_mode` — Boolean. A Boolean value that determines whether chat messages must contain only emotes. True if only messages that are 100% emotes are allowed; otherwise false.
  - `event.follower_mode` — Boolean
    A Boolean value that determines whether the broadcaster restricts the chat room to followers only, based on how long they've followed.

    True if the broadcaster restricts the chat room to followers only; otherwise false.

    See `follower_mode_duration_minutes` for how long the followers must have followed the broadcaster to participate in the chat room.
  - `event.follower_mode_duration_minutes` — Integer, Nullable
    The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room. See `follower_mode`.

    Null if `follower_mode` is false.
  - `event.slow_mode` — Boolean
    A Boolean value that determines whether the broadcaster limits how often users in the chat room are allowed to send messages.

    Is true, if the broadcaster applies a delay; otherwise, false.

    See `slow_mode_wait_time_seconds` for the delay.
  - `event.slow_mode_wait_time_seconds` — Integer, Nullable
    The amount of time, in seconds, that users need to wait between sending messages. See `slow_mode`.

    Null if `slow_mode` is false.
  - `event.subscriber_mode` — Boolean
    A Boolean value that determines whether only users that subscribe to the broadcaster's channel can talk in the chat room.

    True if the broadcaster restricts the chat room to subscribers only; otherwise false.
  - `event.unique_chat_mode` — Boolean
    A Boolean value that determines whether the broadcaster requires users to post only unique messages in the chat room.

    True if the broadcaster requires unique messages only; otherwise false.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat_settings.update",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
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
        "type": "channel.chat_settings.update",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "user_id": "9001"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:12.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "emote_mode": true,
        "follower_mode": false,
        "follower_mode_duration_minutes": null,
        "slow_mode": true,
        "slow_mode_wait_time_seconds": 10,
        "subscriber_mode": false,
        "unique_chat_mode": false
    }
}
```

## Channel Chat Clear {#channel-chat-clear}

The `channel.chat.clear` subscription type sends a notification when a moderator or bot clears all messages from the chat room.

### Subscription

- Type: `channel.chat.clear`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.
  - The **channel:bot** scope for the user represented by the *broadcaster_user_id* event condition.
    Not required if the user in *user_id* already has moderator status.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.clear`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat clear events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat clear events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.broadcaster_user_login` — String. The broadcaster login.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.clear",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
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
        "type": "channel.chat.clear",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "user_id": "9001"
        },
        "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:12.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_name": "Cool_User",
        "broadcaster_user_login": "cool_user"
    }
}
```

## Channel Chat Clear User Messages {#channel-chat-clear-user-messages}

The `channel.chat.clear_user_messages` subscription type sends a notification when a moderator or bot clears all messages for a specific user.

### Subscription

- Type: `channel.chat.clear_user_messages`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.
  - The **channel:bot** scope for the user represented by the *broadcaster_user_id* event condition.
    Not required if the user in *user_id* already has moderator status.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.clear_user_messages`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat clear user messages events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat clear user messages events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.target_user_id` — String. The ID of the user that was banned or put in a timeout. All of their messages are deleted.
  - `event.target_user_name` — String. The user name of the user that was banned or put in a timeout.
  - `event.target_user_login` — String. The user login of the user that was banned or put in a timeout.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.clear_user_messages",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
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
        "type": "channel.chat.clear_user_messages",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "user_id": "9001"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:12.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_name": "Cool_User",
        "broadcaster_user_login": "cool_user",
        "target_user_id": "7734",
        "target_user_name": "Uncool_viewer",
        "target_user_login": "uncool_viewer"
    }
}
```

## Channel Chat Message {#channel-chat-message}

The `channel.chat.message` subscription type sends a notification when any user sends a message to a channel's chat room.

### Subscription

- Type: `channel.chat.message`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.
  - The **channel:bot** scope for the user represented by the *broadcaster_user_id* event condition.
    Not required if the user in *user_id* already has moderator status.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.message`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the channel to receive chat message events for.
  - `condition.user_id` — String, **Required**. The User ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the channel to receive chat message events for.
    - `subscription.condition.user_id` — String. The User ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.chatter_user_id` — String. The user ID of the user that sent the message.
  - `event.chatter_user_name` — String. The user name of the user that sent the message.
  - `event.chatter_user_login` — String. The user login of the user that sent the message.
  - `event.message_id` — String. A UUID that identifies the message.
  - `event.message` — Object. The structured chat message.
    - `event.message.text` — String. The chat message in plain text.
    - `event.message.fragments` — Object[]. Ordered list of chat message fragments.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `cheermote`
        - `emote`
        - `mention`
        - `gif`
      - `event.message.fragments.text` — String. Message text in fragment.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
        - `event.message.fragments.emote.owner_id` — String. The ID of the broadcaster who owns the emote.
        - `event.message.fragments.emote.format` — String[]. The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated.
          Possible values:
          - `animated`: An animated GIF is available for this emote.
          - `static`: A static PNG file is available for this emote.
      - `event.message.fragments.mention` — Object, Nullable. Metadata pertaining to the mention.
        - `event.message.fragments.mention.user_id` — String. The user ID of the mentioned user.
        - `event.message.fragments.mention.user_name` — String. The user name of the mentioned user.
        - `event.message.fragments.mention.user_login` — String. The user login of the mentioned user.
      - `event.message.fragments.gif` — Object, Nullable. Metadata pertaining to the GIF.
        - `event.message.fragments.gif.id` — String. An ID that uniquely identifies this GIF.
        - `event.message.fragments.gif.url` — String. The URL of the GIF asset. Applications rendering the GIF must use the full URL provided; it must not be modified.
  - `event.message_type` — String. The type of message.
    Possible values:
    - `text`
    - `channel_points_highlighted`
    - `channel_points_sub_only`
    - `user_intro`
    - `power_ups_message_effect`
    - `power_ups_gigantified_emote`
  - `event.badges` — Object[]. List of chat badges.
    - `event.badges.set_id` — String. An ID that identifies this set of chat badges. For example, Bits or Subscriber.
    - `event.badges.id` — String. An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
    - `event.badges.info` — String. Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
  - `event.cheer` — Object, Nullable. Metadata if this message is a cheer.
    - `event.cheer.bits` — Integer. The amount of Bits the user cheered.
  - `event.color` — String. The color of the user's name in the chat room. This is a hexadecimal RGB color code in the form, `#<RGB>`. This tag may be empty if it is never set.
  - `event.reply` — Object, Nullable. Metadata if this message is a reply.
    - `event.reply.parent_message_id` — String. An ID that uniquely identifies the parent message that this message is replying to.
    - `event.reply.parent_message_body` — String. The message body of the parent message.
    - `event.reply.parent_user_id` — String. User ID of the sender of the parent message.
    - `event.reply.parent_user_name` — String. User name of the sender of the parent message.
    - `event.reply.parent_user_login` — String. User login of the sender of the parent message.
    - `event.reply.thread_message_id` — String. An ID that identifies the parent message of the reply thread.
    - `event.reply.thread_user_id` — String. User ID of the sender of the thread's parent message.
    - `event.reply.thread_user_name` — String. User name of the sender of the thread's parent message.
    - `event.reply.thread_user_login` — String. User login of the sender of the thread's parent message.
  - `event.channel_points_custom_reward_id` — String, Nullable. The ID of a channel points custom reward that was redeemed.
  - `event.source_broadcaster_user_id` — String, Nullable. The broadcaster user ID of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_broadcaster_user_name` — String, Nullable. The user name of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_broadcaster_user_login` — String, Nullable. The login of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_message_id` — String, Nullable. The UUID that identifies the source message from the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_badges` — Object[], Nullable. The list of chat badges for the chatter in the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    - `event.source_badges.set_id` — String. The ID that identifies this set of chat badges. For example, Bits or Subscriber.
    - `event.source_badges.id` — String. The ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
    - `event.source_badges.info` — String. Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
  - `event.is_source_only` — Boolean, Nullable. Determines if a message delivered during a shared chat session is only sent to the source channel. Has no effect if the message is not sent during a shared chat session.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.message",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
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
    "id": "0b7f3361-672b-4d39-b307-dd5b576c9b27",
    "status": "enabled",
    "type": "channel.chat.message",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1971641",
      "user_id": "2914196"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQHR3s6Mb4T8GFB1l3DlPfiRIGY2VsbC1h"
    },
    "created_at": "2023-11-06T18:11:47.492253549Z",
    "cost": 0
  },
  "event": {
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "chatter_user_id": "4145994",
    "chatter_user_login": "viewer32",
    "chatter_user_name": "viewer32",
    "message_id": "cc106a89-1814-919d-454c-f4f2f970aae7",
    "message": {
      "text": "Hi chat",
      "fragments": [
        {
          "type": "text",
          "text": "Hi chat",
          "cheermote": null,
          "emote": null,
          "mention": null
        }
      ]
    },
    "color": "#00FF7F",
    "badges": [
      {
        "set_id": "moderator",
        "id": "1",
        "info": ""
      },
      {
        "set_id": "subscriber",
        "id": "12",
        "info": "16"
      },
      {
        "set_id": "sub-gifter",
        "id": "1",
        "info": ""
      }
    ],
    "message_type": "text",
    "cheer": null,
    "reply": null,
    "channel_points_custom_reward_id": null,
    "source_broadcaster_user_id": null,
    "source_broadcaster_user_login": null,
    "source_broadcaster_user_name": null,
    "source_message_id": null,
    "source_badges": null
  }
}
```

## Channel Chat Message Delete {#channel-chat-message-delete}

The `channel.chat.message_delete` subscription type sends a notification when a moderator removes a specific message.

### Subscription

- Type: `channel.chat.message_delete`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.
  - The **channel:bot** scope for the user represented by the *broadcaster_user_id* event condition.
    Not required if the user in *user_id* already has moderator status.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.message_delete`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat message delete events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat message delete events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.target_user_id` — String. The ID of the user whose message was deleted.
  - `event.target_user_name` — String. The user name of the user whose message was deleted.
  - `event.target_user_login` — String. The user login of the user whose message was deleted.
  - `event.message_id` — String. A UUID that identifies the message that was removed.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.message_delete",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

## Channel Chat Notification {#channel-chat-notification}

The `channel.chat.notification` subscription type sends a notification when an event that appears in chat occurs, such as someone subscribing to the channel or a subscription is gifted.

### Subscription

- Type: `channel.chat.notification`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.
  - The **channel:bot** scope for the user represented by the *broadcaster_user_id* event condition.
    Not required if the user in *user_id* already has moderator status.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.notification`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat notification events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat notification events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.chatter_user_id` — String. The user ID of the user that sent the message.
  - `event.chatter_user_name` — String. The display name of the user that sent the message.
  - `event.chatter_user_login` — String. The user login of the user that sent the message.
  - `event.chatter_is_anonymous` — Boolean. Whether or not the chatter is anonymous.
  - `event.color` — String. The color of the user's name in the chat room.
  - `event.badges` — Object[]. The list of chat badges for the chatter in the channel the message was sent from.
    - `event.badges.set_id` — String. An ID that identifies this set of chat badges. For example, Bits or Subscriber.
    - `event.badges.id` — String. An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
    - `event.badges.info` — String. Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
  - `event.system_message` — String. The message Twitch shows in the chat room for this notice.
  - `event.message_id` — String. A UUID that identifies the message.
  - `event.message` — Object. The structured chat message.
    - `event.message.text` — String. The chat message in plain text.
    - `event.message.fragments` — Object[]. Ordered list of chat message fragments.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `cheermote`
        - `emote`
        - `mention`
      - `event.message.fragments.text` — String. Message text in fragment.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
        - `event.message.fragments.emote.owner_id` — String. The ID of the broadcaster who owns the emote.
        - `event.message.fragments.emote.format` — String[]. The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated.
          Possible values:
          - `animated`: An animated GIF is available for this emote.
          - `static`: A static PNG file is available for this emote.
      - `event.message.fragments.mention` — Object, Nullable. Metadata pertaining to the mention.
        - `event.message.fragments.mention.user_id` — String. The user ID of the mentioned user.
        - `event.message.fragments.mention.user_name` — String. The user name of the mentioned user.
        - `event.message.fragments.mention.user_login` — String. The user login of the mentioned user.
  - `event.notice_type` — String. The type of notice.
    Possible values:
    - `sub`
    - `resub`
    - `sub_gift`
    - `community_sub_gift`
    - `gift_paid_upgrade`
    - `prime_paid_upgrade`
    - `raid`
    - `unraid`
    - `pay_it_forward`
    - `announcement`
    - `bits_badge_tier`
    - `charity_donation`
    - `watch_streak`
    - `modiversary`
    - `gifted_drops_summary`
    - `shared_chat_sub`
    - `shared_chat_resub`
    - `shared_chat_sub_gift`
    - `shared_chat_community_sub_gift`
    - `shared_chat_gift_paid_upgrade`
    - `shared_chat_prime_paid_upgrade`
    - `shared_chat_raid`
    - `shared_chat_pay_it_forward`
    - `shared_chat_announcement`
    - `shared_chat_modiversary`
    - `shared_chat_gifted_drops_summary`
    - `unknown`
  - `event.sub` — Object, Nullable. Information about the sub event. Null if `notice_type` is not `sub`.
    - `event.sub.sub_tier` — String. The type of subscription plan being used.
      Possible values:
      - `1000`: First level of paid or Prime subscription.
      - `2000`: Second level of paid subscription.
      - `3000`: Third level of paid subscription.
    - `event.sub.is_prime` — Boolean. Indicates if the subscription was obtained through Amazon Prime.
    - `event.sub.duration_months` — Integer. The number of months the subscription is for.
  - `event.resub` — Object, Nullable. Information about the resub event. Null if `notice_type` is not `resub`.
    - `event.resub.cumulative_months` — Integer. The total number of months the user has subscribed.
    - `event.resub.duration_months` — Integer. The number of months the subscription is for.
    - `event.resub.streak_months` — Integer, Nullable. The total number of months the user has subscribed.
    - `event.resub.sub_tier` — String. The type of subscription plan being used.
      Possible values:
      - `1000`: First level of paid or Prime subscription.
      - `2000`: Second level of paid subscription.
      - `3000`: Third level of paid subscription.
    - `event.resub.is_prime` — Boolean, Nullable. Whether or not this subscription is a Prime subscription.
    - `event.resub.is_gift` — Boolean. Whether or not the resub was a result of a gift.
    - `event.resub.gifter_is_anonymous` — Boolean, Nullable. Whether or not the gift was anonymous.
    - `event.resub.gifter_user_id` — String, Nullable. The user ID of the subscription gifter. Null if anonymous.
    - `event.resub.gifter_user_name` — String, Nullable. The user name of the subscription gifter. Null if anonymous.
    - `event.resub.gifter_user_login` — String, Nullable. The user login of the subscription gifter. Null if anonymous.
  - `event.sub_gift` — Object, Nullable. Information about the gift sub event. Null if notice_type is not sub_gift.
    - `event.sub_gift.duration_months` — Integer. The number of months the subscription is for.
    - `event.sub_gift.cumulative_total` — Integer, Nullable. The amount of gifts the gifter has given in this channel. Null if anonymous.
    - `event.sub_gift.recipient_user_id` — String. The user ID of the subscription gift recipient.
    - `event.sub_gift.recipient_user_name` — String. The user name of the subscription gift recipient.
    - `event.sub_gift.recipient_user_login` — String. The user login of the subscription gift recipient.
    - `event.sub_gift.sub_tier` — String. The type of subscription plan being used.
      Possible values:
      - `1000`: First level of paid or Prime subscription.
      - `2000`: Second level of paid subscription.
      - `3000`: Third level of paid subscription.
    - `event.sub_gift.community_gift_id` — String, Nullable. The ID of the associated community gift. Null if not associated with a community gift.
  - `event.community_sub_gift` — Object, Nullable. Information about the community gift sub event. Null if `notice_type` is not `community_sub_gift`.
    - `event.community_sub_gift.id` — String. The ID of the associated community gift.
    - `event.community_sub_gift.total` — Integer. Number of subscriptions being gifted.
    - `event.community_sub_gift.sub_tier` — String. The type of subscription plan being used.
      Possible values:
      - `1000`: First level of paid or Prime subscription.
      - `2000`: Second level of paid subscription.
      - `3000`: Third level of paid subscription.
    - `event.community_sub_gift.cumulative_total` — Integer, Nullable. The amount of gifts the gifter has given in this channel. Null if anonymous.
  - `event.gift_paid_upgrade` — Object, Nullable. Information about the community gift paid upgrade event. Null if `notice_type` is not `gift_paid_upgrade`.
    - `event.gift_paid_upgrade.gifter_is_anonymous` — Boolean. Whether the gift was given anonymously.
    - `event.gift_paid_upgrade.gifter_user_id` — String, Nullable. The user ID of the user who gifted the subscription. Null if anonymous.
    - `event.gift_paid_upgrade.gifter_user_name` — String, Nullable. The user name of the user who gifted the subscription. Null if anonymous.
  - `event.prime_paid_upgrade` — Object, Nullable. Information about the Prime gift paid upgrade event. Null if `notice_type` is not `prime_paid_upgrade`
    - `event.prime_paid_upgrade.sub_tier` — String. The type of subscription plan being used.
      Possible values:
      - `1000`: First level of paid or Prime subscription.
      - `2000`: Second level of paid subscription.
      - `3000`: Third level of paid subscription.
  - `event.pay_it_forward` — Object, Nullable. Information about the pay it forward event. Null if `notice_type` is not `pay_it_forward`
    - `event.pay_it_forward.gifter_is_anonymous` — Boolean. Whether the gift was given anonymously.
    - `event.pay_it_forward.gifter_user_id` — String, Nullable. The user ID of the user who gifted the subscription. Null if anonymous.
    - `event.pay_it_forward.gifter_user_name` — String, Nullable. The user name of the user who gifted the subscription. Null if anonymous.
    - `event.pay_it_forward.gifter_user_login` — String, Nullable. The user login of the user who gifted the subscription. Null if anonymous.
  - `event.raid` — Object, Nullable. Information about the raid event. Null if `notice_type` is not `raid`
    - `event.raid.user_id` — String. The user ID of the broadcaster raiding this channel.
    - `event.raid.user_name` — String. The user name of the broadcaster raiding this channel.
    - `event.raid.user_login` — String. The login name of the broadcaster raiding this channel.
    - `event.raid.viewer_count` — Integer. The number of viewers raiding this channel from the broadcaster's channel.
    - `event.raid.profile_image_url` — String. Profile image URL of the broadcaster raiding this channel.
  - `event.unraid` — Object, Nullable. Returns an empty payload if `notice_type` is `unraid`, otherwise returns null.
  - `event.announcement` — Object, Nullable. Information about the announcement event. Null if `notice_type` is not `announcement`
    - `event.announcement.color` — String. Color of the announcement.
  - `event.bits_badge_tier` — Object, Nullable. Information about the Bits badge tier event. Null if `notice_type` is not `bits_badge_tier`
    - `event.bits_badge_tier.tier` — Integer. The tier of the Bits badge the user just earned. For example, 100, 1000, or 10000.
  - `event.charity_donation` — Object, Nullable. Information about the announcement event. Null if `notice_type` is not `charity_donation`
    - `event.charity_donation.charity_name` — String. Name of the charity.
    - `event.charity_donation.amount` — Object. An object that contains the amount of money that the user paid.
      - `event.charity_donation.amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
      - `event.charity_donation.amount.decimal_place` — Integer. The number of decimal places used by the currency. For example, USD uses two decimal places.
      - `event.charity_donation.amount.currency` — String. The [ISO-4217](https://www.iso.org/iso-4217-currency-codes.html) three-letter currency code that identifies the type of currency in value.
  - `event.watch_streak` — Object, Nullable. Information about the Watch Streak event. Null if `notice_type` is not `watch_streak`.
    - `event.watch_streak.streak_count` — Integer. The number of consecutive broadcasts for which the user has been watching.
    - `event.watch_streak.channel_points_awarded` — Integer. The number of channel points awarded for the Watch Streak milestone.
  - `event.modiversary` — Object, Nullable. Information about the modiversary event. Null if `notice_type` is not `modiversary`.
    - `event.modiversary.months` — Integer. The number of months the user has been a moderator in this channel.
  - `event.gifted_drops_summary` — Object, Nullable. Information about the gifted Drops summary event. Null if `notice_type` is not `gifted_drops_summary`
    - `event.gifted_drops_summary.recipient_count` — Integer. The number of users who received a gifted Drop.
  - `event.source_broadcaster_user_id` — String, Nullable. The broadcaster user ID of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_broadcaster_user_name` — String, Nullable. The user name of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_broadcaster_user_login` — String, Nullable. The login of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_message_id` — String, Nullable. The UUID that identifies the source message from the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
  - `event.source_badges` — Object[], Nullable. The list of chat badges for the chatter in the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    - `event.source_badges.set_id` — String. The ID that identifies this set of chat badges. For example, Bits or Subscriber.
    - `event.source_badges.id` — String. The ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
    - `event.source_badges.info` — String. Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
  - `event.is_source_only` — Boolean, Nullable. Whether the notification is only sent to the source channel. Is **null** if the notification is not in a shared chat session.
  - `event.shared_chat_sub` — Object, Nullable. Information about the `shared_chat_sub` event. Is null if `notice_type` is not `shared_chat_sub`. This field has the same information as the `sub` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_resub` — Object, Nullable. Information about the `shared_chat_resub` event. Is null if `notice_type` is not `shared_chat_resub`. This field has the same information as the `resub` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_sub_gift` — Object, Nullable. Information about the `shared_chat_sub_gift` event. Is null if `notice_type` is not `shared_chat_sub_gift`. This field has the same information as the `chat_sub_gift` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_community_sub_gift` — Object, Nullable. Information about the `shared_chat_community_sub_gift` event. Is null if `notice_type` is not `shared_chat_community_sub_gift`. This field has the same information as the `community_sub_gift` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_gift_paid_upgrade` — Object, Nullable. Information about the `shared_chat_gift_paid_upgrade` event. Is null if `notice_type` is not `shared_chat_gift_paid_upgrade`. This field has the same information as the `gift_paid_upgrade` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_prime_paid_upgrade` — Object, Nullable. Information about the `shared_chat_chat_prime_paid_upgrade` event. Is null if `notice_type` is not `shared_chat_prime_paid_upgrade`. This field has the same information as the `prime_paid_upgrade` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_pay_it_forward` — Object, Nullable. Information about the `shared_chat_pay_it_forward` event. Is null if `notice_type` is not `shared_chat_pay_it_forward`. This field has the same information as the `pay_it_forward` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_raid` — Object, Nullable. Information about the `shared_chat_raid` event. Is null if `notice_type` is not `shared_chat_raid`. This field has the same information as the `raid` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_announcement` — Object, Nullable. Information about the `shared_chat_announcement` event. Is null if `notice_type` is not `shared_chat_announcement`. This field has the same information as the `announcement` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_modiversary` — Object, Nullable. Information about the `shared_chat_modiversary` event. Is null if `notice_type` is not `shared_chat_modiversary`. This field has the same information as the `modiversary` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
  - `event.shared_chat_gifted_drops_summary` — Object, Nullable. Information about the `shared_chat_gifted_drops_summary` event. Is null if `notice_type` is not `shared_chat_gifted_drops_summary`. This field has the same information as the `gifted_drops_summary` field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.notification",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1971641",
    "user_id": "2914196"
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
    "id": "dc1a3cfc-a930-4972-bf9e-0ffc4e7a8996",
    "status": "enabled",
    "type": "channel.chat.notification",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1971641",
      "user_id": "2914196"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQOtgGkFvXRlSkij343CndhIGY2VsbC1h"
    },
    "created_at": "2023-10-06T18:04:38.807682738Z",
    "cost": 0
  },
  "event": {
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "chatter_user_id": "49912639",
    "chatter_user_login": "viewer23",
    "chatter_user_name": "viewer23",
    "chatter_is_anonymous": false,
    "color": "",
    "badges": [],
    "system_message": "viewer23 subscribed at Tier 1. They've subscribed for 10 months!",
    "message_id": "d62235c8-47ff-a4f4--84e8-5a29a65a9c03",
    "message": {
      "text": "",
      "fragments": []
    },
    "notice_type": "resub",
    "sub": null,
    "resub": {
      "cumulative_months": 10,
      "duration_months": 0,
      "streak_months": null,
      "sub_plan": "1000",
      "is_gift": false,
      "gifter_is_anonymous": null,
      "gifter_user_id": null,
      "gifter_user_name": null,
      "gifter_user_login": null
    },
    "sub_gift": null,
    "community_sub_gift": null,
    "gift_paid_upgrade": null,
    "prime_paid_upgrade": null,
    "pay_it_forward": null,
    "raid": null,
    "unraid": null,
    "announcement": null,
    "bits_badge_tier": null,
    "charity_donation": null,
    "watch_streak": null,
    "modiversary": null,
    "shared_chat_sub": null,
    "shared_chat_resub": null,
    "shared_chat_sub_gift": null,
    "shared_chat_community_sub_gift": null,
    "shared_chat_gift_paid_upgrade": null,
    "shared_chat_prime_paid_upgrade": null,
    "shared_chat_pay_it_forward": null,
    "shared_chat_raid": null,
    "shared_chat_announcement": null,
    "shared_chat_modiversary": null,
    "source_broadcaster_user_id": null,
    "source_broadcaster_user_login": null,
    "source_broadcaster_user_name": null,
    "source_message_id": null,
    "source_badges": null,
    "is_source_only": null
  }
}
```

## Channel Chat User Message Hold {#channel-chat-user-message-hold}

The `channel.chat.user_message_hold` subscription type notifies a user if their message is caught by AutoMod.

### Subscription

- Type: `channel.chat.user_message_hold`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.user_message_hold`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat message events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat message events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The ID of the broadcaster specified in the request.
  - `event.broadcaster_user_login` — String. The login of the broadcaster specified in the request.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster specified in the request.
  - `event.user_id` — String. The User ID of the message sender.
  - `event.user_login` — String. The message sender's login.
  - `event.user_name` — String. The message sender's display name.
  - `event.message_id` — String. The ID of the message that was flagged by automod.
  - `event.message` — Object. The body of the message.
    - `event.message.text` — String. The contents of the message caught by automod.
    - `event.message.fragments` — Object[]. Ordered list of chat message fragments.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `cheermote`
        - `emote`
        - `mention`
        - `gif`
      - `event.message.fragments.text` — String. Message text in a fragment.
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.user_message_hold",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
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
    "type": "channel.chat.user_message_hold",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "user_id": "9001"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2023-04-11T10:11:12.123Z"
  },
  "event": {
    "broadcaster_user_id": "123",
    "broadcaster_user_login": "bob",
    "broadcaster_user_name": "Bob",
    "user_id": "456",
    "user_login": "tom",
    "user_name": "Tommy",
    "message_id": "789",
    "message": {
      "text": "hey world",
      "fragments": [
        {
          "type": "emote",
          "text": "hey world",
          "cheermote": null,
          "emote": {
            "id": "foo",
            "emote_set_id": "7"
          }
        },
        {
          "type": "cheermote",
          "text": "bye world",
          "cheermote": {
            "prefix": "prefix",
            "bits": 100,
            "tier": 1
          },
          "emote": null
        },
        {
          "type": "text",
          "text": "surprise",
          "cheermote": null,
          "emote": null
        }
      ]
    }
  }
}
```

## Channel Chat User Message Update {#channel-chat-user-message-update}

The `channel.chat.user_message_update` subscription type notifies a user if their message's AutoMod status is updated.

### Subscription

- Type: `channel.chat.user_message_update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:chat**, **user:bot** scopes for the user represented by the *user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.chat.user_message_update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the channel to receive chat message events for.
  - `condition.user_id` — String, **Required**. The user ID to read chat as.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the channel to receive chat message events for.
    - `subscription.condition.user_id` — String. The user ID to read chat as.
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
  - `event.broadcaster_user_id` — String. The ID of the broadcaster specified in the request.
  - `event.broadcaster_user_login` — String. The login of the broadcaster specified in the request.
  - `event.broadcaster_user_name` — String. The user name of the broadcaster specified in the request.
  - `event.user_id` — String. The User ID of the message sender.
  - `event.user_login` — String. The message sender's login.
  - `event.user_name` — String. The message sender's user name.
  - `event.status` — String. The message's status.
    Possible values:
    - `approved`
    - `denied`
    - `invalid`
  - `event.message_id` — String. The ID of the message that was flagged by automod.
  - `event.message` — Object. The body of the message.
    - `event.message.text` — String. The contents of the message caught by automod.
    - `event.message.fragments` — Object[]. Ordered list of chat message fragments.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `cheermote`
        - `emote`
        - `mention`
        - `gif`
      - `event.message.fragments.text` — String. Message text in a fragment.
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.chat.user_message_update",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "user_id": "9001"
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
        "type": "channel.chat.user_message_update",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "user_id": "9001"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:12.123Z"
    },
    "event": {
   "broadcaster_user_id": "123",
   "broadcaster_user_login": "bob",
   "broadcaster_user_name": "Bob",
   "user_id": "456",
   "user_login": "tom",
   "user_name": "Tommy",
   "status": "approved",
   "message_id": "789",
   "message": {
     "text": "hey world",
     "fragments": [
       {
         "type": "emote",
         "text": "hey world",
         "cheermote": null,
         "emote": {
             "id": "foo",
             "emote_set_id": "7"
         }
       },
       {
         "type": "cheermote",
         "text": "bye world",
         "cheermote": {
             "prefix": "prefix",
             "bits": 100,
             "tier": 1
         },
         "emote": null
       },
       {
         "type": "text",
         "text": "surprise",
         "cheermote": null,
         "emote": null
       }
     ]
   }
 }
}
```

## Channel Shared Chat Session Begin {#channel-shared-chat-begin}

The `channel.shared_chat.begin` subscription type sends a notification when a channel becomes active in an active shared chat session.

### Subscription

- Type: `channel.shared_chat.begin`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

No authorization required.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.shared_chat.begin`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the channel to receive shared chat session begin events for.
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
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the channel to receive shared chat session begin events for.
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
  - `event.session_id` — String. The unique identifier for the shared chat session.
  - `event.broadcaster_user_id` — String. The User ID of the channel in the subscription condition which is now active in the shared chat session.
  - `event.broadcaster_user_name` — String. The display name of the channel in the subscription condition which is now active in the shared chat session.
  - `event.broadcaster_user_login` — String. The user login of the channel in the subscription condition which is now active in the shared chat session.
  - `event.host_broadcaster_user_id` — String. The User ID of the host channel.
  - `event.host_broadcaster_user_name` — String. The display name of the host channel.
  - `event.host_broadcaster_user_login` — String. The user login of the host channel.
  - `event.participants` — Object[]. The list of participants in the session.
    - `event.participants.broadcaster_user_id` — String. The User ID of the participant channel.
    - `event.participants.broadcaster_user_name` — String. The display name of the participant channel.
    - `event.participants.broadcaster_user_login` — String. The user login of the participant channel.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shared_chat.begin",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1971641"
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
    "id": "bf0602d2-5b39-4ece-b1a4-44191d52df6b",
    "status": "enabled",
    "type": "channel.shared_chat.begin",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1971641"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQOtgGkFvXRlSkij343CndhIGY2VsbC1h"
    },
    "created_at": "2023-10-06T18:04:38.807682738Z",
    "cost": 0
  },
  "event": {
    "session_id": "2b64a92a-dbb8-424e-b1c3-304423ba1b6f",
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "host_broadcaster_user_id": "1971641",
    "host_broadcaster_user_login": "streamer",
    "host_broadcaster_user_name": "streamer",
    "participants": [
      {
        "broadcaster_user_id": "1971641",
        "broadcaster_user_name": "streamer",
        "broadcaster_user_login": "streamer"
      },
      {
        "broadcaster_user_id": "112233",
        "broadcaster_user_name": "streamer33",
        "broadcaster_user_login": "streamer33"
      }
    ]
  }
}
```

## Channel Shared Chat Session End {#channel-shared-chat-end}

The `channel.shared_chat.end` subscription type sends a notification when a channel leaves a shared chat session or the session ends.

### Subscription

- Type: `channel.shared_chat.end`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

No authorization required.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.shared_chat.end`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the channel to receive shared chat session end events for.
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
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the channel to receive shared chat session end events for.
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
  - `event.session_id` — String. The unique identifier for the shared chat session.
  - `event.broadcaster_user_id` — String. The User ID of the channel in the subscription condition which is no longer active in the shared chat session.
  - `event.broadcaster_user_name` — String. The display name of the channel in the subscription condition which is no longer active in the shared chat session.
  - `event.broadcaster_user_login` — String. The user login of the channel in the subscription condition which is no longer active in the shared chat session.
  - `event.host_broadcaster_user_id` — String. The User ID of the host channel.
  - `event.host_broadcaster_user_name` — String. The display name of the host channel.
  - `event.host_broadcaster_user_login` — String. The user login of the host channel.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shared_chat.end",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1971641"
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
    "id": "84a875f1-1dc0-43b2-8ed3-d7db4d650c37",
    "status": "enabled",
    "type": "channel.shared_chat.end",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "112233"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQOtgGkFvXRlSkij343CndhIGY2VsbC1h"
    },
    "created_at": "2023-10-06T18:04:38.807682738Z",
    "cost": 0
  },
  "event": {
    "session_id": "2b64a92a-dbb8-424e-b1c3-304423ba1b6f",
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "host_broadcaster_user_id": "1971641",
    "host_broadcaster_user_login": "streamer",
    "host_broadcaster_user_name": "streamer"
  }
}
```

## Channel Shared Chat Session Update {#channel-shared-chat-update}

The `channel.shared_chat.update` subscription type sends a notification when the active shared chat session the channel is in changes.

### Subscription

- Type: `channel.shared_chat.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

No authorization required.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.shared_chat.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the channel to receive shared chat session update events for.
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
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the channel to receive shared chat session update events for.
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
  - `event.session_id` — String. The unique identifier for the shared chat session.
  - `event.broadcaster_user_id` — String. The User ID of the channel in the subscription condition.
  - `event.broadcaster_user_name` — String. The display name of the channel in the subscription condition.
  - `event.broadcaster_user_login` — String. The user login of the channel in the subscription condition.
  - `event.host_broadcaster_user_id` — String. The User ID of the host channel.
  - `event.host_broadcaster_user_name` — String. The display name of the host channel.
  - `event.host_broadcaster_user_login` — String. The user login of the host channel.
  - `event.participants` — Object[]. The list of participants in the session.
    - `event.participants.broadcaster_user_id` — String. The User ID of the participant channel.
    - `event.participants.broadcaster_user_name` — String. The display name of the participant channel.
    - `event.participants.broadcaster_user_login` — String. The user login of the participant channel.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shared_chat.update",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1971641"
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
    "id": "5f65d0a7-0069-4f2b-944b-bc81b160ae49",
    "status": "enabled",
    "type": "channel.shared_chat.update",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1971641"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQOtgGkFvXRlSkij343CndhIGY2VsbC1h"
    },
    "created_at": "2023-10-06T18:04:38.807682738Z",
    "cost": 0
  },
  "event": {
    "session_id": "2b64a92a-dbb8-424e-b1c3-304423ba1b6f",
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "host_broadcaster_user_id": "1971641",
    "host_broadcaster_user_login": "streamer",
    "host_broadcaster_user_name": "streamer",
    "participants": [
      {
        "broadcaster_user_id": "1971641",
        "broadcaster_user_name": "streamer",
        "broadcaster_user_login": "streamer"
      },
      {
        "broadcaster_user_id": "112233",
        "broadcaster_user_name": "streamer33",
        "broadcaster_user_login": "streamer33"
      },
      {
        "broadcaster_user_id": "332211",
        "broadcaster_user_name": "streamer11",
        "broadcaster_user_login": "streamer11"
      }
    ]
  }
}
```
