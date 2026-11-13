# Guest Star

Events raised as a Guest Star session begins and ends, a guest or slot changes, and the host updates their Guest Star preferences.

Source: https://dev.twitch.tv/docs/eventsub/reference/guest-star/

## Contents {#contents}

4 entries on this page:

- [Channel Guest Star Guest Update](#channel-guest-star-guest-update)
- [Channel Guest Star Session Begin](#channel-guest-star-session-begin)
- [Channel Guest Star Session End](#channel-guest-star-session-end)
- [Channel Guest Star Settings Update](#channel-guest-star-settings-update)

## Channel Guest Star Guest Update {#channel-guest-star-guest-update}

The `channel.guest_star_guest.update` subscription type sends a notification when a guest or a slot is updated in an active Guest Star session.

### Subscription

- Type: `channel.guest_star_guest.update`
- Version: `beta`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.guest_star_guest.update`.
- `version` — String, **Required**. The subscription type version: `beta`.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive Guest Star guest update notifications for.
  - `condition.moderator_user_id` — String, **Required**. The user ID of the moderator or broadcaster of the specified channel.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive Guest Star guest update notifications for.
    - `subscription.condition.moderator_user_id` — String. The user ID of the moderator or broadcaster of the specified channel.
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
  - `event.broadcaster_user_id` — String. The non-host broadcaster user ID.
  - `event.broadcaster_user_name` — String. The non-host broadcaster display name.
  - `event.broadcaster_user_login` — String. The non-host broadcaster login.
  - `event.session_id` — String. ID representing the unique session that was started.
  - `event.moderator_user_id` — String, Nullable. The user ID of the moderator who updated the guest's state (could be the host). **null** if the update was performed by the guest.
  - `event.moderator_user_name` — String, Nullable. The moderator display name.**null** if the update was performed by the guest.
  - `event.moderator_user_login` — String, Nullable. The moderator login. **null** if the update was performed by the guest.
  - `event.guest_user_id` — String, Nullable. The user ID of the guest who transitioned states in the session. **null** if the slot is now empty.
  - `event.guest_user_name` — String, Nullable. The guest display name. **null** if the slot is now empty.
  - `event.guest_user_login` — String, Nullable. The guest login. **null** if the slot is now empty.
  - `event.slot_id` — String, Nullable. The ID of the slot assignment the guest is assigned to. **null** if the guest is in the INVITED, REMOVED, READY, or ACCEPTED state.
  - `event.state` — String, Nullable. The current state of the user after the update has taken place. **null** if the slot is now empty.
    Possible values:
    - `invited`: The guest has transitioned to the invite queue. This can take place when the guest was previously assigned a slot, but have been removed from the call and are sent back to the invite queue.
    - `accepted`: The guest has accepted the invite and is currently in the process of setting up to join the session.
    - `ready`: The guest has signaled they are ready and can be assigned a slot.
    - `backstage`: The guest has been assigned a slot in the session, but is not currently seen live in the broadcasting software.
    - `live`: The guest is now live in the host's broadcasting software.
  - `event.host_user_id` — String. User ID of the host channel.
  - `event.host_user_name` — String. The host display name.
  - `event.host_user_login` — String. The host login.
  - `event.host_video_enabled` — Boolean, Nullable. Flag that signals whether the host is allowing the slot's video to be seen by participants within the session. **null** if the guest is not slotted.
  - `event.host_audio_enabled` — Boolean, Nullable. Flag that signals whether the host is allowing the slot's audio to be heard by participants within the session. **null** if the guest is not slotted.
  - `event.host_volume` — Integer, Nullable. Value between 0-100 that represents the slot's audio level as heard by participants within the session. **null** if the guest is not slotted.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.guest_star_guest.update",
  "version": "beta",
  "condition": {
    "broadcaster_user_id": "1337",
    "moderator_user_id": "1312"
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
        "type": "channel.guest_star_guest.update",
        "version": "beta",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "moderator_user_id": "1312"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:32.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_name": "Cool_User",
        "broadcaster_user_login": "cool_user",
        "session_id": "2KFRQbFtpmfyD3IevNRnCzOPRJI",
        "moderator_user_id": "1312",
        "moderator_user_name": "Cool_Mod",
        "moderator_user_login": "cool_mod",
        "guest_user_id": "1234",
        "guest_user_name": "Cool_Guest",
        "guest_user_login": "cool_guest",
        "slot_id": "1",
        "state": "live",
        "host_video_enabled": true,
        "host_audio_enabled": true,
        "host_volume": 100
    }
}
```

## Channel Guest Star Session Begin {#channel-guest-star-session-begin}

The `channel.guest_star_session.begin` subscription type sends a notification when the host begins a new Guest Star session.

### Subscription

- Type: `channel.guest_star_session.begin`
- Version: `beta`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.guest_star_session.begin`.
- `version` — String, **Required**. The subscription type version: `beta`.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive Guest Star session begin notifications for.
  - `condition.moderator_user_id` — String, **Required**. The user ID of the moderator or broadcaster of the specified channel.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive Guest Star session begin notifications for.
    - `subscription.condition.moderator_user_id` — String. The user ID of the moderator or broadcaster of the specified channel.
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
  - `event.session_id` — String. ID representing the unique session that was started.
  - `event.started_at` — String. RFC3339 timestamp indicating the time the session began.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.guest_star_session.begin",
  "version": "beta",
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
        "type": "channel.guest_star_session.begin",
        "version": "beta",
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
        "created_at": "2023-04-11T10:11:12.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_name": "Cool_User",
        "broadcaster_user_login": "cool_user",
        "session_id": "2KFRQbFtpmfyD3IevNRnCzOPRJI",
        "started_at": "2023-04-11T16:20:03.17106713Z"
    }
}
```

## Channel Guest Star Session End {#channel-guest-star-session-end}

The `channel.guest_star_session.end` subscription type sends a notification when a running Guest Star session is ended by the host, or automatically by the system.

### Subscription

- Type: `channel.guest_star_session.end`
- Version: `beta`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.guest_star_session.end`.
- `version` — String, **Required**. The subscription type version: `beta`.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive Guest Star session end notifications for.
  - `condition.moderator_user_id` — String, **Required**. The user ID of the moderator or broadcaster of the specified channel.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive Guest Star session end notifications for.
    - `subscription.condition.moderator_user_id` — String. The user ID of the moderator or broadcaster of the specified channel.
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
  - `event.broadcaster_user_id` — String. The non-host broadcaster user ID.
  - `event.broadcaster_user_name` — String. The non-host broadcaster display name.
  - `event.broadcaster_user_login` — String. The non-host broadcaster login.
  - `event.session_id` — String. ID representing the unique session that was started.
  - `event.started_at` — String. RFC3339 timestamp indicating the time the session began.
  - `event.ended_at` — String. RFC3339 timestamp indicating the time the session ended.
  - `event.host_user_id` — String. User ID of the host channel.
  - `event.host_user_name` — String. The host display name.
  - `event.host_user_login` — String. The host login.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.guest_star_session.end",
  "version": "beta",
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
        "type": "channel.guest_star_session.end",
        "version": "beta",
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
        "created_at": "2023-04-11T10:11:22.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_name": "Cool_User",
        "broadcaster_user_login": "cool_user",
        "session_id": "2KFRQbFtpmfyD3IevNRnCzOPRJI",
        "started_at": "2023-04-11T16:20:03.17106713Z",
        "ended_at": "2023-04-11T17:51:29.153485Z",
        "host_user_id": "141981764",
        "host_user_login": "twitchdev",
        "host_user_name": "TwitchDev"
    }
}
```

## Channel Guest Star Settings Update {#channel-guest-star-settings-update}

The `channel.guest_star_settings.update` subscription type sends a notification when the host preferences for Guest Star have been updated.

### Subscription

- Type: `channel.guest_star_settings.update`
- Version: `beta`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:guest_star**, **channel:manage:guest_star**, **moderator:read:guest_star**, or **moderator:manage:guest_star** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.guest_star_settings.update`.
- `version` — String, **Required**. The subscription type version: `beta`.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive Guest Star settings update notifications for.
  - `condition.moderator_user_id` — String, **Required**. The user ID of the moderator or broadcaster of the specified channel.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive Guest Star settings update notifications for.
    - `subscription.condition.moderator_user_id` — String. The user ID of the moderator or broadcaster of the specified channel.
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
  - `event.broadcaster_user_id` — String. User ID of the host channel.
  - `event.broadcaster_user_name` — String. The broadcaster display name
  - `event.broadcaster_user_login` — String. he broadcaster login.
  - `event.is_moderator_send_live_enabled` — Boolean. Flag determining if Guest Star moderators have access to control whether a guest is live once assigned to a slot.
  - `event.slot_count` — Integer. Number of slots the Guest Star call interface will allow the host to add to a call.
  - `event.is_browser_source_audio_enabled` — Boolean. Flag determining if browser sources subscribed to sessions on this channel should output audio.
  - `event.group_layout` — String. This setting determines how the guests within a session should be laid out within a group browser source.
    Possible values:
    - `tiled`: All live guests are tiled within the browser source with the same size.
    - `screenshare`: All live guests are tiled within the browser source with the same size. If there is an active screen share, it is sized larger than the other guests.
    - `horizontal_top`: Indicates the group layout will contain all participants in a top-aligned horizontal stack.
    - `horizontal_bottom`: Indicates the group layout will contain all participants in a bottom-aligned horizontal stack.
    - `vertical_left`: Indicates the group layout will contain all participants in a left-aligned vertical stack.
    - `vertical_right`: Indicates the group layout will contain all participants in a right-aligned vertical stack.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.guest_star_settings.update",
  "version": "beta",
  "condition": {
    "broadcaster_user_id": "1337",
    "moderator_user_id": "1312"
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
        "type": "channel.guest_star_settings.update",
        "version": "beta",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "moderator_user_id": "1312"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:52.123Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_name": "Cool_User",
        "broadcaster_user_login": "cool_user",
        "is_moderator_send_live_enabled": true,
        "slot_count": 5,
        "is_browser_source_audio_enabled": true,
        "group_layout": "tiled"
    }
}
```
