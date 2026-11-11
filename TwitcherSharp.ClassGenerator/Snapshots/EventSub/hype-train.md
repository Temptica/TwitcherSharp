# Hype Train

Events raised when a Hype Train starts, progresses, or ends on a channel.

Source: https://dev.twitch.tv/docs/eventsub/reference/hype-train/

## Contents {#contents}

3 entries on this page:

- [Hype Train Begin](#channel-hype-train-begin)
- [Hype Train End](#channel-hype-train-end)
- [Hype Train Progress](#channel-hype-train-progress)

## Hype Train Begin {#channel-hype-train-begin}

The `channel.hype_train.begin` subscription type sends a notification when a Hype Train begins on the specified channel. In addition to a `channel.hype_train.begin` event, one `channel.hype_train.progress` event will be sent for each contribution that caused the Hype Train to begin. EventSub does not make strong assurances about the order of message delivery, so it is possible to receive `channel.hype_train.progress` notifications before you receive the corresponding `channel.hype_train.begin` notification.
After the Hype Train begins, any additional cheers or subscriptions on the channel will cause `channel.hype_train.progress` notifications to be sent. When the Hype Train is over, `channel.hype_train.end` is emitted.

### Subscription

- Type: `channel.hype_train.begin`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:hype_train** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:hype_train** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.hype_train.begin`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to Hype Train begin notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to get Hype Train begin notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to get Hype Train begin notifications for.
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
  - `event.id` — String. The Hype Train ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.total` — Integer. Total points contributed to the Hype Train.
  - `event.progress` — Integer. The number of points contributed to the Hype Train at the current level.
  - `event.goal` — Integer. The number of points required to reach the next level.
  - `event.top_contributions` — Object[]. The contributors with the most points contributed.
    - `event.top_contributions.user_id` — String. The ID of the user that made the contribution.
    - `event.top_contributions.user_login` — String. The user's login name.
    - `event.top_contributions.user_name` — String. The user's display name.
    - `event.top_contributions.type` — String. The contribution method used.
      Possible values:
      - `bits`: Bits contributions with Cheering and Power-ups.
      - `subscription`: Subscription activity like subscribing or gifting subscriptions.
      - `other`: Covers other contribution methods not listed.
    - `event.top_contributions.total` — Integer. The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
  - `event.level` — Integer. The current level of the Hype Train.
  - `event.all_time_high_level` — Integer. The all-time high level this type of Hype Train has reached for this broadcaster.
  - `event.all_time_high_total` — Integer. The all-time high total this type of Hype Train has reached for this broadcaster.
  - `event.shared_train_participants` — Object[], Nullable. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_id` — String. The ID of the broadcaster participating in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_login` — String. The login of the broadcaster participating in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_name` — String. The display name of the broadcaster participating in the shared Hype Train.
  - `event.started_at` — String. The time when the Hype Train started.
  - `event.expires_at` — String. The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
  - `event.type` — String. The type of the Hype Train.
    Possible values:
    - `treasure`
    - `golden_kappa`
    - `regular`
  - `event.is_shared_train` — Boolean. Indicates if the Hype Train is shared. When true, `shared_train_participants` will contain the list of broadcasters the train is shared with.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.hype_train.begin",
  "version": "2",
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
        "type": "channel.hype_train.begin",
        "version": "2",
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
        "id": "1b0AsbInCHZW2SQFQkCzqN07Ib2",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "total": 137,
        "progress": 137,
        "goal": 500,
        "top_contributions": [
            {
                "user_id": "123",
                "user_login": "pogchamp",
                "user_name": "PogChamp",
                "type": "bits",
                "total": 50
            }
        ],
        "shared_train_participants": null,
        "level": 1,
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "expires_at": "2020-07-15T17:16:11.17106713Z",
        "is_shared_train": false,
        "type": "regular",
        "all_time_high_level": 4,
        "all_time_high_total": 2845
    }
}
```

## Hype Train End {#channel-hype-train-end}

The `channel.hype_train.end` subscription type sends a notification when a Hype Train ends on the specified channel.

### Subscription

- Type: `channel.hype_train.end`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:hype_train** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:hype_train** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.hype_train.end`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to Hype Train end notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to get Hype Train end notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to get Hype Train end notifications for.
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
  - `event.id` — String. The Hype Train ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.total` — Integer. Total points contributed to the Hype Train.
  - `event.top_contributions` — Object[]. The contributors with the most points contributed.
    - `event.top_contributions.user_id` — String. The ID of the user that made the contribution.
    - `event.top_contributions.user_login` — String. The user's login name.
    - `event.top_contributions.user_name` — String. The user's display name.
    - `event.top_contributions.type` — String. The contribution method used.
      Possible values:
      - `bits`: Bits contributions with Cheering, Power-ups, and Extensions.
      - `subscription`: Subscription activity like subscribing or gifting subscriptions.
      - `other`: Covers other contribution methods not listed.
    - `event.top_contributions.total` — Integer. The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
  - `event.level` — Integer. The current level of the Hype Train.
  - `event.shared_train_participants` — Object[], Nullable. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_id` — String. The ID of the broadcaster participating in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_login` — String. The login of the broadcaster participating in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_name` — String. The display name of the broadcaster participating in the shared Hype Train.
  - `event.started_at` — String. The time when the Hype Train started.
  - `event.cooldown_ends_at` — String. The time when the Hype Train cooldown ends so that the next Hype Train can start.
  - `event.ended_at` — String. The time when the Hype Train ended.
  - `event.type` — String. The type of the Hype Train.
    Possible values:
    - `treasure`
    - `golden_kappa`
    - `regular`
  - `event.is_shared_train` — Boolean. Indicates if the Hype Train is shared. When true, `shared_train_participants` will contain the list of broadcasters the train is shared with.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.hype_train.end",
  "version": "2",
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
        "type": "channel.hype_train.end",
        "version": "2",
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
        "id": "1b0AsbInCHZW2SQFQkCzqN07Ib2",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "total": 137,
        "top_contributions": [
            {
                "user_id": "123",
                "user_login": "pogchamp",
                "user_name": "PogChamp",
                "type": "bits",
                "total": 50
            }
        ],
        "shared_train_participants": null,
        "level": 1,
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "ended_at": "2020-07-15T17:16:11.17106713Z",
        "cooldown_ends_at": "2020-07-16T17:16:11.17106713Z",
        "is_shared_train": false,
        "type": "regular"
    }
}
```

## Hype Train Progress {#channel-hype-train-progress}

The `channel.hype_train.progress` subscription type sends a notification when a Hype Train makes progress on the specified channel. `channel.hype_train.progress` notifications are sent periodically while a Hype Train is making progress. EventSub does not make strong assurances about the order of message delivery, so it is possible to receive `channel.hype_train.progress` before you receive the corresponding `channel.hype_train.begin`.
When the Hype Train is over, `channel.hype_train.end` is emitted.

### Subscription

- Type: `channel.hype_train.progress`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:hype_train** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:hype_train** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.hype_train.progress`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to Hype Train progress notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to get Hype Train progress notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to get Hype Train progress notifications for.
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
  - `event.id` — String. The Hype Train ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.total` — Integer. Total points contributed to the Hype Train.
  - `event.progress` — Integer. The number of points contributed to the Hype Train at the current level.
  - `event.goal` — Integer. The number of points required to reach the next level.
  - `event.top_contributions` — Object[]. The contributors with the most points contributed.
    - `event.top_contributions.user_id` — String. The ID of the user that made the contribution.
    - `event.top_contributions.user_login` — String. The user's login name.
    - `event.top_contributions.user_name` — String. The user's display name.
    - `event.top_contributions.type` — String. The contribution method used.
      Possible values:
      - `bits`: Bits contributions with Cheering, Power-ups, and Extensions.
      - `subscription`: Subscription activity like subscribing or gifting subscriptions.
      - `other`: Covers other contribution methods not listed.
    - `event.top_contributions.total` — Integer. The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
  - `event.level` — Integer. The current level of the Hype Train.
  - `event.shared_train_participants` — Object[], Nullable. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_id` — String. The ID of the broadcaster participating in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_login` — String. The login of the broadcaster participating in the shared Hype Train.
    - `event.shared_train_participants.broadcaster_user_name` — String. The display name of the broadcaster participating in the shared Hype Train.
  - `event.started_at` — String. The time when the Hype Train started.
  - `event.expires_at` — String. The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
  - `event.type` — String. The type of the Hype Train.
    Possible values:
    - `treasure`
    - `golden_kappa`
    - `regular`
  - `event.is_shared_train` — Boolean. Indicates if the Hype Train is shared. When true, `shared_train_participants` will contain the list of broadcasters the train is shared with.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.hype_train.progress",
  "version": "2",
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
        "type": "channel.hype_train.progress",
        "version": "2",
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
        "id": "1b0AsbInCHZW2SQFQkCzqN07Ib2",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "total": 137,
        "progress": 137,
        "goal": 500,
        "top_contributions": [
            {
                "user_id": "123",
                "user_login": "pogchamp",
                "user_name": "PogChamp",
                "type": "bits",
                "total": 50
            }
        ],
        "shared_train_participants": null,
        "level": 1,
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "expires_at": "2020-07-15T17:16:11.17106713Z",
        "is_shared_train": false,
        "type": "regular"
    }
}
```
