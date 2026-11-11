# Goal

Events raised as a broadcaster's creator goal starts, progresses and ends.

Source: https://dev.twitch.tv/docs/eventsub/reference/goal/

## Contents {#contents}

3 entries on this page:

- [Goal Begin](#channel-goal-begin)
- [Goal End](#channel-goal-end)
- [Goal Progress](#channel-goal-progress)

## Goal Begin {#channel-goal-begin}

Notifies the subscriber when the specified broadcaster begins a goal.

> **Note** It's possible to receive the Begin event after receiving Progress events.

### Subscription

- Type: `channel.goal.begin`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:goals** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:goals** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.goal.begin`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Set the **Condition** object's *broadcaster_user_id* field to the ID of the broadcaster whose goals you want to get notified about.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster to get notified about. The ID must match the `user_id` in the OAuth access token.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster to get notified about. The ID must match the `user_id` in the OAuth access token.
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
  - `event.id` — String. An ID that identifies this event.
  - `event.broadcaster_user_id` — String. An ID that uniquely identifies the broadcaster.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.broadcaster_user_login` — String. The broadcaster's user handle.
  - `event.type` — String. The type of goal.
    Possible values:
    - `follow`: The goal is to increase followers.
    - `subscription`: The goal is to increase subscriptions. This type shows the net increase or decrease in tier points associated with the subscriptions.
    - `subscription_count`: The goal is to increase subscriptions. This type shows the net increase or decrease in the number of subscriptions.
    - `new_subscription`: The goal is to increase subscriptions. This type shows only the net increase in tier points associated with the subscriptions (it does not account for users that unsubscribed since the goal started).
    - `new_subscription_count`: The goal is to increase subscriptions. This type shows only the net increase in the number of subscriptions (it does not account for users that unsubscribed since the goal started).
    - `new_bit`: The goal is to increase the amount of Bits used on the channel.
    - `new_cheerer`: The goal is to increase the number of unique Cheerers to Cheer on the channel.
  - `event.description` — String. A description of the goal, if specified. The description may contain a maximum of 40 characters.
  - `event.is_achieved` — Boolean
    A Boolean value that indicates whether the broadcaster achieved their goal. Is **true** if the goal was achieved; otherwise, **false**.

    Only the **channel.goal.end** event includes this field.
  - `event.current_amount` — Integer
    The goal's current value.

    The goal's `type` determines how this value is increased or decreased.

    - If `type` is follow, this field is set to the broadcaster's current number of followers. This number increases with new followers and decreases when users unfollow the broadcaster.
    - If `type` is subscription, this field is increased and decreased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased or decreased by 2, not 1.
    - If `type` is subscription_count, this field is increased by 1 for each new subscription and decreased by 1 for each user that unsubscribes.
    - If `type` is new_subscription, this field is increased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased by 2, not 1.
    - If `type` is new_subscription_count, this field is increased by 1 for each new subscription.
  - `event.target_amount` — Integer. The goal's target value. For example, if the broadcaster has 200 followers before creating the goal, and their goal is to double that number, this field is set to 400.
  - `event.started_at` — String. The UTC timestamp in [RFC 3339](https://datatracker.ietf.org/doc/html/rfc3339) format, which indicates when the broadcaster created the goal.
  - `event.ended_at` — String
    The UTC timestamp in [RFC 3339](https://datatracker.ietf.org/doc/html/rfc3339) format, which indicates when the broadcaster ended the goal.

    Only the **channel.goal.end** event includes this field.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.goal.begin",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "141981764"
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
        "status": "enabled",
        "type": "channel.goal.begin",
        "version": "1",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "141981764"
        },
        "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2021-07-15T10:11:12.123Z"
    },
    "event": {
        "id": "12345-cool-event",
        "broadcaster_user_id": "141981764",
        "broadcaster_user_name": "TwitchDev",
        "broadcaster_user_login": "twitchdev",
        "type": "subscription",
        "description": "Help me get partner!",
        "current_amount": 100,
        "target_amount": 220,
        "started_at": "2021-07-15T17:16:03.17106713Z"
    }
}
```

## Goal End {#channel-goal-end}

Notifies the subscriber when the specified broadcaster ends a goal.

### Subscription

- Type: `channel.goal.end`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:goals** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:goals** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.goal.end`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Set the **Condition** object's *broadcaster_user_id* field to the ID of the broadcaster whose goals you want to get notified about.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster to get notified about. The ID must match the `user_id` in the OAuth access token.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster to get notified about. The ID must match the `user_id` in the OAuth access token.
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
  - `event.id` — String. An ID that identifies this event.
  - `event.broadcaster_user_id` — String. An ID that uniquely identifies the broadcaster.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.broadcaster_user_login` — String. The broadcaster's user handle.
  - `event.type` — String. The type of goal.
    Possible values:
    - `follow`: The goal is to increase followers.
    - `subscription`: The goal is to increase subscriptions. This type shows the net increase or decrease in tier points associated with the subscriptions.
    - `subscription_count`: The goal is to increase subscriptions. This type shows the net increase or decrease in the number of subscriptions.
    - `new_subscription`: The goal is to increase subscriptions. This type shows only the net increase in tier points associated with the subscriptions (it does not account for users that unsubscribed since the goal started).
    - `new_subscription_count`: The goal is to increase subscriptions. This type shows only the net increase in the number of subscriptions (it does not account for users that unsubscribed since the goal started).
    - `new_bit`: The goal is to increase the amount of Bits used on the channel.
    - `new_cheerer`: The goal is to increase the number of unique Cheerers to Cheer on the channel.
  - `event.description` — String. A description of the goal, if specified. The description may contain a maximum of 40 characters.
  - `event.is_achieved` — Boolean
    A Boolean value that indicates whether the broadcaster achieved their goal. Is **true** if the goal was achieved; otherwise, **false**.

    Only the **channel.goal.end** event includes this field.
  - `event.current_amount` — Integer
    The goal's current value.

    The goal's `type` determines how this value is increased or decreased.

    - If `type` is follow, this field is set to the broadcaster's current number of followers. This number increases with new followers and decreases when users unfollow the broadcaster.
    - If `type` is subscription, this field is increased and decreased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased or decreased by 2, not 1.
    - If `type` is subscription_count, this field is increased by 1 for each new subscription and decreased by 1 for each user that unsubscribes.
    - If `type` is new_subscription, this field is increased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased by 2, not 1.
    - If `type` is new_subscription_count, this field is increased by 1 for each new subscription.
  - `event.target_amount` — Integer. The goal's target value. For example, if the broadcaster has 200 followers before creating the goal, and their goal is to double that number, this field is set to 400.
  - `event.started_at` — String. The UTC timestamp in [RFC 3339](https://datatracker.ietf.org/doc/html/rfc3339) format, which indicates when the broadcaster created the goal.
  - `event.ended_at` — String
    The UTC timestamp in [RFC 3339](https://datatracker.ietf.org/doc/html/rfc3339) format, which indicates when the broadcaster ended the goal.

    Only the **channel.goal.end** event includes this field.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.goal.end",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "141981764"
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
        "status": "enabled",
        "type": "channel.goal.end",
        "version": "1",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "141981764"
        },
        "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2021-07-15T10:11:12.123Z"
    },
    "event": {
        "id": "12345-abc-678-defgh",
        "broadcaster_user_id": "141981764",
        "broadcaster_user_name": "TwitchDev",
        "broadcaster_user_login": "twitchdev",
        "type": "subscription",
        "description": "Help me get partner!",
        "is_achieved": false,
        "current_amount": 180,
        "target_amount": 220,
        "started_at": "2021-07-15T17:16:03.17106713Z",
        "ended_at": "2020-07-16T17:16:03.17106713Z"
    }
}
```

## Goal Progress {#channel-goal-progress}

Notifies the subscriber when progress is made towards the specified broadcaster's goal. Progress could be positive (added followers) or negative (lost followers).

> **Note** It's possible to receive Progress events before receiving the Begin event.

### Subscription

- Type: `channel.goal.progress`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:goals** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:goals** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.goal.progress`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Set the **Condition** object's *broadcaster_user_id* field to the ID of the broadcaster whose goals you want to get notified about.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster to get notified about. The ID must match the `user_id` in the OAuth access token.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster to get notified about. The ID must match the `user_id` in the OAuth access token.
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
  - `event.id` — String. An ID that identifies this event.
  - `event.broadcaster_user_id` — String. An ID that uniquely identifies the broadcaster.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.broadcaster_user_login` — String. The broadcaster's user handle.
  - `event.type` — String. The type of goal.
    Possible values:
    - `follow`: The goal is to increase followers.
    - `subscription`: The goal is to increase subscriptions. This type shows the net increase or decrease in tier points associated with the subscriptions.
    - `subscription_count`: The goal is to increase subscriptions. This type shows the net increase or decrease in the number of subscriptions.
    - `new_subscription`: The goal is to increase subscriptions. This type shows only the net increase in tier points associated with the subscriptions (it does not account for users that unsubscribed since the goal started).
    - `new_subscription_count`: The goal is to increase subscriptions. This type shows only the net increase in the number of subscriptions (it does not account for users that unsubscribed since the goal started).
    - `new_bit`: The goal is to increase the amount of Bits used on the channel.
    - `new_cheerer`: The goal is to increase the number of unique Cheerers to Cheer on the channel.
  - `event.description` — String. A description of the goal, if specified. The description may contain a maximum of 40 characters.
  - `event.is_achieved` — Boolean
    A Boolean value that indicates whether the broadcaster achieved their goal. Is **true** if the goal was achieved; otherwise, **false**.

    Only the **channel.goal.end** event includes this field.
  - `event.current_amount` — Integer
    The goal's current value.

    The goal's `type` determines how this value is increased or decreased.

    - If `type` is follow, this field is set to the broadcaster's current number of followers. This number increases with new followers and decreases when users unfollow the broadcaster.
    - If `type` is subscription, this field is increased and decreased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased or decreased by 2, not 1.
    - If `type` is subscription_count, this field is increased by 1 for each new subscription and decreased by 1 for each user that unsubscribes.
    - If `type` is new_subscription, this field is increased by the points value associated with the subscription tier. For example, if a tier-two subscription is worth 2 points, this field is increased by 2, not 1.
    - If `type` is new_subscription_count, this field is increased by 1 for each new subscription.
  - `event.target_amount` — Integer. The goal's target value. For example, if the broadcaster has 200 followers before creating the goal, and their goal is to double that number, this field is set to 400.
  - `event.started_at` — String. The UTC timestamp in [RFC 3339](https://datatracker.ietf.org/doc/html/rfc3339) format, which indicates when the broadcaster created the goal.
  - `event.ended_at` — String
    The UTC timestamp in [RFC 3339](https://datatracker.ietf.org/doc/html/rfc3339) format, which indicates when the broadcaster ended the goal.

    Only the **channel.goal.end** event includes this field.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.goal.progress",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "141981764"
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
        "status": "enabled",
        "type": "channel.goal.progress",
        "version": "1",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "141981764"
        },
        "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2021-07-15T10:11:12.123Z"
    },
    "event": {
        "id": "12345-cool-event",
        "broadcaster_user_id": "141981764",
        "broadcaster_user_name": "TwitchDev",
        "broadcaster_user_login": "twitchdev",
        "type": "subscription",
        "description": "Help me get partner!",
        "current_amount": 120,
        "target_amount": 220,
        "started_at": "2021-07-15T17:16:03.17106713Z"
    }
}
```
