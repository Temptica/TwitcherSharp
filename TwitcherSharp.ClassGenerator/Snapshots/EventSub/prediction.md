# Prediction

Events raised as a Channel Points Prediction starts, takes predictions, locks and resolves.

Source: https://dev.twitch.tv/docs/eventsub/reference/prediction/

## Contents {#contents}

4 entries on this page:

- [Channel Prediction Begin](#channel-prediction-begin)
- [Channel Prediction End](#channel-prediction-end)
- [Channel Prediction Lock](#channel-prediction-lock)
- [Channel Prediction Progress](#channel-prediction-progress)

## Channel Prediction Begin {#channel-prediction-begin}

The `channel.prediction.begin` subscription type sends a notification when a Prediction begins on the specified channel.

### Subscription

- Type: `channel.prediction.begin`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:predictions** or **channel:manage:predictions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:predictions** or **channel:manage:predictions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.prediction.begin`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive prediction begin notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "prediction begin" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "prediction begin" notifications will be received.
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
  - `event.id` — String. Channel Points Prediction ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Title for the Channel Points Prediction.
  - `event.outcomes` — Object[]. An array of outcomes for the Channel Points Prediction.
    - `event.outcomes.id` — String. The outcome ID.
    - `event.outcomes.title` — String. The outcome title.
    - `event.outcomes.color` — String. The color for the outcome. Valid values are **pink** and **blue**.
    - `event.outcomes.users` — Integer. The number of users who used Channel Points on this outcome.
    - `event.outcomes.channel_points` — Integer. The total number of Channel Points used on this outcome.
    - `event.outcomes.top_predictors` — Object[]. An array of users who used the most Channel Points on this outcome.
      - `event.outcomes.top_predictors.user_id` — String. The ID of the user.
      - `event.outcomes.top_predictors.user_login` — String. The login of the user.
      - `event.outcomes.top_predictors.user_name` — String. The display name of the user.
      - `event.outcomes.top_predictors.channel_points_won` — Integer, Nullable. The number of Channel Points won. This value is always **null** in the event payload for Prediction progress and Prediction lock. This value is 0 if the outcome did not win or if the Prediction was canceled and Channel Points were refunded.
      - `event.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points used to participate in the Prediction.
  - `event.started_at` — String. The time the Channel Points Prediction started.
  - `event.locks_at` — String. The time the Channel Points Prediction will automatically lock.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.prediction.begin",
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
        "type": "channel.prediction.begin",
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
        "outcomes": [
            {"id": "1243456", "title": "Yeah!", "color": "blue"},
            {"id": "2243456", "title": "No!", "color": "pink"}
        ],
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "locks_at": "2020-07-15T17:21:03.17106713Z"
    }
}
```

## Channel Prediction End {#channel-prediction-end}

The `channel.prediction.end` subscription type sends a notification when a Prediction ends on the specified channel.

### Subscription

- Type: `channel.prediction.end`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:predictions** or **channel:manage:predictions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:predictions** or **channel:manage:predictions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.prediction.end`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive prediction lock notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "prediction end" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "prediction end" notifications will be received.
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
  - `event.id` — String. Channel Points Prediction ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Title for the Channel Points Prediction.
  - `event.winning_outcome_id` — String. ID of the winning outcome.
  - `event.outcomes` — Object[]. An array of outcomes for the Channel Points Prediction. Includes `top_predictors`.
    - `event.outcomes.id` — String. The outcome ID.
    - `event.outcomes.title` — String. The outcome title.
    - `event.outcomes.color` — String. The color for the outcome. Valid values are **pink** and **blue**.
    - `event.outcomes.users` — Integer. The number of users who used Channel Points on this outcome.
    - `event.outcomes.channel_points` — Integer. The total number of Channel Points used on this outcome.
    - `event.outcomes.top_predictors` — Object[]. An array of users who used the most Channel Points on this outcome.
      - `event.outcomes.top_predictors.user_id` — String. The ID of the user.
      - `event.outcomes.top_predictors.user_login` — String. The login of the user.
      - `event.outcomes.top_predictors.user_name` — String. The display name of the user.
      - `event.outcomes.top_predictors.channel_points_won` — Integer, Nullable. The number of Channel Points won. This value is always **null** in the event payload for Prediction progress and Prediction lock. This value is 0 if the outcome did not win or if the Prediction was canceled and Channel Points were refunded.
      - `event.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points used to participate in the Prediction.
  - `event.status` — String. The status of the Channel Points Prediction. Valid values are **resolved** and **canceled**.
  - `event.started_at` — String. The time the Channel Points Prediction started.
  - `event.ended_at` — String. The time the Channel Points Prediction ended.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.prediction.end",
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
        "type": "channel.prediction.end",
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
        "winning_outcome_id": "12345",
        "outcomes": [
            {
                "id": "12345",
                "title": "Yeah!",
                "color": "blue",
                "users": 2,
                "channel_points": 15000,
                "top_predictors": [
                    {
                        "user_name": "Cool_User",
                        "user_login": "cool_user",
                        "user_id": "1234",
                        "channel_points_won": 10000,
                        "channel_points_used": 500
                    },
                    {
                        "user_name": "Coolest_User",
                        "user_login": "coolest_user",
                        "user_id": "1236",
                        "channel_points_won": 5000,
                        "channel_points_used": 100
                    }
                ]
            },
            {
                "id": "22435",
                "title": "No!",
                "users": 2,
                "channel_points": 200,
                "color": "pink",
                "top_predictors": [
                    {
                        "user_name": "Cooler_User",
                        "user_login": "cooler_user",
                        "user_id": 12345,
                        "channel_points_won": null,
                        "channel_points_used": 100
                    },
                    {
                        "user_name": "Elite_User",
                        "user_login": "elite_user",
                        "user_id": 1337,
                        "channel_points_won": null,
                        "channel_points_used": 100
                    }
                ]
            }
        ],
        "status": "resolved",
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "ended_at": "2020-07-15T17:16:11.17106713Z"
    }
}
```

## Channel Prediction Lock {#channel-prediction-lock}

The `channel.prediction.lock` subscription type sends a notification when a Prediction is locked on the specified channel.

### Subscription

- Type: `channel.prediction.lock`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:predictions** or **channel:manage:predictions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:predictions** or **channel:manage:predictions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.prediction.lock`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive prediction lock notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "prediction lock" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "prediction lock" notifications will be received.
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
  - `event.id` — String. Channel Points Prediction ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Title for the Channel Points Prediction.
  - `event.outcomes` — Object[]. An array of outcomes for the Channel Points Prediction. Includes `top_predictors`.
    - `event.outcomes.id` — String. The outcome ID.
    - `event.outcomes.title` — String. The outcome title.
    - `event.outcomes.color` — String. The color for the outcome. Valid values are **pink** and **blue**.
    - `event.outcomes.users` — Integer. The number of users who used Channel Points on this outcome.
    - `event.outcomes.channel_points` — Integer. The total number of Channel Points used on this outcome.
    - `event.outcomes.top_predictors` — Object[]. An array of users who used the most Channel Points on this outcome.
      - `event.outcomes.top_predictors.user_id` — String. The ID of the user.
      - `event.outcomes.top_predictors.user_login` — String. The login of the user.
      - `event.outcomes.top_predictors.user_name` — String. The display name of the user.
      - `event.outcomes.top_predictors.channel_points_won` — Integer, Nullable. The number of Channel Points won. This value is always **null** in the event payload for Prediction progress and Prediction lock. This value is 0 if the outcome did not win or if the Prediction was canceled and Channel Points were refunded.
      - `event.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points used to participate in the Prediction.
  - `event.started_at` — String. The time the Channel Points Prediction started.
  - `event.locked_at` — String. The time the Channel Points Prediction was locked.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.prediction.lock",
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
        "type": "channel.prediction.lock",
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
        "outcomes": [
            {
                "id": "1243456",
                "title": "Yeah!",
                "color": "blue",
                "users": 10,
                "channel_points": 15000,
                "top_predictors": [
                    {
                        "user_name": "Cool_User",
                        "user_login": "cool_user",
                        "user_id": "1234",
                        "channel_points_won": null,
                        "channel_points_used": 500
                    },
                    {
                        "user_name": "Coolest_User",
                        "user_login": "coolest_user",
                        "user_id": "1236",
                        "channel_points_won": null,
                        "channel_points_used": 200
                    }
                ]
            },
            {
                "id": "2243456",
                "title": "No!",
                "color": "pink",
                "top_predictors": [
                    {
                        "user_name": "Cooler_User",
                        "user_login": "cooler_user",
                        "user_id": 12345,
                        "channel_points_won": null,
                        "channel_points_used": 5000
                    }
                ]
            }
        ],
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "locked_at": "2020-07-15T17:21:03.17106713Z"
    }
}
```

## Channel Prediction Progress {#channel-prediction-progress}

The `channel.prediction.progress` subscription type sends a notification when users participate in a Prediction on the specified channel.

### Subscription

- Type: `channel.prediction.progress`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:predictions** or **channel:manage:predictions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:predictions** or **channel:manage:predictions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.prediction.progress`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive prediction progress notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID of the channel for which "prediction progress" notifications will be received.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID of the channel for which "prediction progress" notifications will be received.
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
  - `event.id` — String. Channel Points Prediction ID.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.title` — String. Title for the Channel Points Prediction.
  - `event.outcomes` — Object[]. An array of outcomes for the Channel Points Prediction. Includes `top_predictors`.
    - `event.outcomes.id` — String. The outcome ID.
    - `event.outcomes.title` — String. The outcome title.
    - `event.outcomes.color` — String. The color for the outcome. Valid values are **pink** and **blue**.
    - `event.outcomes.users` — Integer. The number of users who used Channel Points on this outcome.
    - `event.outcomes.channel_points` — Integer. The total number of Channel Points used on this outcome.
    - `event.outcomes.top_predictors` — Object[]. An array of users who used the most Channel Points on this outcome.
      - `event.outcomes.top_predictors.user_id` — String. The ID of the user.
      - `event.outcomes.top_predictors.user_login` — String. The login of the user.
      - `event.outcomes.top_predictors.user_name` — String. The display name of the user.
      - `event.outcomes.top_predictors.channel_points_won` — Integer, Nullable. The number of Channel Points won. This value is always **null** in the event payload for Prediction progress and Prediction lock. This value is 0 if the outcome did not win or if the Prediction was canceled and Channel Points were refunded.
      - `event.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points used to participate in the Prediction.
  - `event.started_at` — String. The time the Channel Points Prediction started.
  - `event.locks_at` — String. The time the Channel Points Prediction will automatically lock.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.prediction.progress",
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
        "type": "channel.prediction.progress",
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
        "outcomes": [
            {
                "id": "1243456",
                "title": "Yeah!",
                "color": "blue",
                "users": 10,
                "channel_points": 15000,
                "top_predictors": [
                    {
                        "user_name": "Cool_User",
                        "user_login": "cool_user",
                        "user_id": "1234",
                        "channel_points_won": null,
                        "channel_points_used": 500
                    },
                    {
                        "user_name": "Coolest_User",
                        "user_login": "coolest_user",
                        "user_id": "1236",
                        "channel_points_won": null,
                        "channel_points_used": 200
                    }
                ]
            },
            {
                "id": "2243456",
                "title": "No!",
                "color": "pink",
                "top_predictors": [
                    {
                        "user_name": "Cooler_User",
                        "user_login": "cooler_user",
                        "user_id": 12345,
                        "channel_points_won": null,
                        "channel_points_used": 5000
                    }
                ]
            }
        ],
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "locks_at": "2020-07-15T17:21:03.17106713Z"
    }
}
```
