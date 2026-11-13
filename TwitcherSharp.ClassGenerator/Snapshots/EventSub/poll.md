# Poll

Events raised as a poll starts, collects votes and ends on a channel.

Source: https://dev.twitch.tv/docs/eventsub/reference/poll/

## Contents {#contents}

3 entries on this page:

- [Channel Poll Begin](#channel-poll-begin)
- [Channel Poll End](#channel-poll-end)
- [Channel Poll Progress](#channel-poll-progress)

## Channel Poll Begin {#channel-poll-begin}

The `channel.poll.begin` subscription type sends a notification when a poll begins on the specified channel.

### Subscription

- Type: `channel.poll.begin`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:polls** or **channel:manage:polls** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:polls** or **channel:manage:polls** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.poll.begin`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive poll begin notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "poll begin" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "poll begin" notifications will be received.
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
  - `event.id` — String. ID of the poll.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Question displayed for the poll.
  - `event.choices` — Object[]. An array of choices for the poll.
    - `event.choices.id` — String. ID for the choice.
    - `event.choices.title` — String. Text displayed for the choice.
    - `event.choices.bits_votes` — Integer. Not used; will be set to 0.
    - `event.choices.channel_points_votes` — Integer. Number of votes received via Channel Points.
    - `event.choices.votes` — Integer. Total number of votes received for the choice across all methods of voting.
  - `event.bits_voting` — Object. Not supported.
    - `event.bits_voting.is_enabled` — Boolean. Not used; will be set to **false**.
    - `event.bits_voting.amount_per_vote` — Integer. Not used; will be set to 0.
  - `event.channel_points_voting` — Object. The Channel Points voting settings for the poll.
    - `event.channel_points_voting.is_enabled` — Boolean. Indicates if Channel Points can be used for voting.
    - `event.channel_points_voting.amount_per_vote` — Integer. Number of Channel Points required to vote once with Channel Points.
  - `event.started_at` — String. The time the poll started.
  - `event.ends_at` — String. The time the poll will end.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.poll.begin",
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
        "type": "channel.poll.begin",
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
        "id": "1243456",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "title": "Aren't shoes just really hard socks?",
        "choices": [
            {"id": "123", "title": "Yeah!"},
            {"id": "124", "title": "No!"},
            {"id": "125", "title": "Maybe!"}
        ],
        "bits_voting": {
            "is_enabled": true,
            "amount_per_vote": 10
        },
        "channel_points_voting": {
            "is_enabled": true,
            "amount_per_vote": 10
        },
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "ends_at": "2020-07-15T17:16:08.17106713Z"
    }
}
```

## Channel Poll End {#channel-poll-end}

The `channel.poll.end` subscription type sends a notification when a poll ends on the specified channel.

### Subscription

- Type: `channel.poll.end`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:polls** or **channel:manage:polls** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:polls** or **channel:manage:polls** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.poll.end`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive poll end notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "poll end" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "poll end" notifications will be received.
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
  - `event.id` — String. ID of the poll.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Question displayed for the poll.
  - `event.choices` — Object[]. An array of choices for the poll. Includes vote counts.
    - `event.choices.id` — String. ID for the choice.
    - `event.choices.title` — String. Text displayed for the choice.
    - `event.choices.bits_votes` — Integer. Not used; will be set to 0.
    - `event.choices.channel_points_votes` — Integer. Number of votes received via Channel Points.
    - `event.choices.votes` — Integer. Total number of votes received for the choice across all methods of voting.
  - `event.bits_voting` — Object. Not supported.
    - `event.bits_voting.is_enabled` — Boolean. Not used; will be set to **false**.
    - `event.bits_voting.amount_per_vote` — Integer. Not used; will be set to 0.
  - `event.channel_points_voting` — Object. The Channel Points voting settings for the poll.
    - `event.channel_points_voting.is_enabled` — Boolean. Indicates if Channel Points can be used for voting.
    - `event.channel_points_voting.amount_per_vote` — Integer. Number of Channel Points required to vote once with Channel Points.
  - `event.status` — String. The status of the poll. Valid values are **completed**, **archived**, and **terminated**.
  - `event.started_at` — String. The time the poll started.
  - `event.ended_at` — String. The time the poll ended.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.poll.end",
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
        "type": "channel.poll.end",
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
        "id": "1243456",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "title": "Aren't shoes just really hard socks?",
        "choices": [
            {"id": "123", "title": "Blue", "bits_votes": 50, "channel_points_votes": 70, "votes": 120},
            {"id": "124", "title": "Yellow", "bits_votes": 100, "channel_points_votes": 40, "votes": 140},
            {"id": "125", "title": "Green", "bits_votes": 10, "channel_points_votes": 70, "votes": 80}
        ],
        "bits_voting": {
            "is_enabled": true,
            "amount_per_vote": 10
        },
        "channel_points_voting": {
            "is_enabled": true,
            "amount_per_vote": 10
        },
        "status": "completed",
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "ended_at": "2020-07-15T17:16:11.17106713Z"
    }
}
```

## Channel Poll Progress {#channel-poll-progress}

The `channel.poll.progress` subscription type sends a notification when users respond to a poll on the specified channel.

### Subscription

- Type: `channel.poll.progress`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:polls** or **channel:manage:polls** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:polls** or **channel:manage:polls** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.poll.progress`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive poll progress notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "poll progress" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "poll progress" notifications will be received.
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
  - `event.id` — String. ID of the poll.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Question displayed for the poll.
  - `event.choices` — Object[]. An array of choices for the poll. Includes vote counts.
    - `event.choices.id` — String. ID for the choice.
    - `event.choices.title` — String. Text displayed for the choice.
    - `event.choices.bits_votes` — Integer. Not used; will be set to 0.
    - `event.choices.channel_points_votes` — Integer. Number of votes received via Channel Points.
    - `event.choices.votes` — Integer. Total number of votes received for the choice across all methods of voting.
  - `event.bits_voting` — Object. Not supported.
    - `event.bits_voting.is_enabled` — Boolean. Not used; will be set to **false**.
    - `event.bits_voting.amount_per_vote` — Integer. Not used; will be set to 0.
  - `event.channel_points_voting` — Object. The Channel Points voting settings for the poll.
    - `event.channel_points_voting.is_enabled` — Boolean. Indicates if Channel Points can be used for voting.
    - `event.channel_points_voting.amount_per_vote` — Integer. Number of Channel Points required to vote once with Channel Points.
  - `event.started_at` — String. The time the poll started.
  - `event.ends_at` — String. The time the poll will end.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.poll.progress",
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
        "type": "channel.poll.progress",
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
        "id": "1243456",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "title": "Aren't shoes just really hard socks?",
        "choices": [
            {"id": "123", "title": "Yeah!", "bits_votes": 5, "channel_points_votes": 7, "votes": 12},
            {"id": "124", "title": "No!", "bits_votes": 10, "channel_points_votes": 4, "votes": 14},
            {"id": "125", "title": "Maybe!", "bits_votes": 0, "channel_points_votes": 7, "votes": 7}
        ],
        "bits_voting": {
            "is_enabled": true,
            "amount_per_vote": 10
        },
        "channel_points_voting": {
            "is_enabled": true,
            "amount_per_vote": 10
        },
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "ends_at": "2020-07-15T17:16:08.17106713Z"
    }
}
```
