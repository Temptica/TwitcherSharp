# Channel

Actions on Twitch relating to a Twitch channel.

Source: https://dev.twitch.tv/docs/eventsub/reference/channel/

## Contents {#contents}

15 entries on this page:

- [Channel Ad Break Begin](#channel-ad-break-begin)
- [Channel Bits Use](#channel-bits-use)
- [Channel Cheer](#channel-cheer)
- [Channel Custom Power-ups Redemption Add](#channel-custom-power-up-redemption-add)
- [Channel Follow](#channel-follow)
- [Channel Raid](#channel-raid)
- [Shoutout Create](#channel-shoutout-create)
- [Shoutout Received](#channel-shoutout-receive)
- [Channel Subscribe](#channel-subscribe)
- [Channel Subscription End](#channel-subscription-end)
- [Channel Subscription Gift](#channel-subscription-gift)
- [Channel Subscription Message](#channel-subscription-message)
- [Channel Update](#channel-update)
- [Channel VIP Add](#channel-vip-add)
- [Channel VIP Remove](#channel-vip-remove)

## Channel Ad Break Begin {#channel-ad-break-begin}

The `channel.ad_break.begin` subscription type sends a notification when a user runs a midroll commercial break, either manually or automatically via ads manager.

### Subscription

- Type: `channel.ad_break.begin`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:ads** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:ads** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.ad_break.begin`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to get Channel Ad Break begin notifications for. Maximum: 1
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to get Channel Ad Break begin notifications for. Maximum: 1
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
  - `event.duration_seconds` — Integer. Length in seconds of the mid-roll ad break requested
  - `event.started_at` — String. The UTC timestamp of when the ad break began, in RFC3339 format. Note that there is potential delay between this event, when the streamer requested the ad break, and when the viewers will see ads.
  - `event.is_automatic` — Boolean. Indicates if the ad was automatically scheduled via Ads Manager
  - `event.broadcaster_user_id` — String. The broadcaster's user ID for the channel the ad was run on.
  - `event.broadcaster_user_login` — String. The broadcaster's user login for the channel the ad was run on.
  - `event.broadcaster_user_name` — String. The broadcaster's user display name for the channel the ad was run on.
  - `event.requester_user_id` — String. The ID of the user that requested the ad. For automatic ads, this will be the ID of the broadcaster.
  - `event.requester_user_login` — String. The login of the user that requested the ad.
  - `event.requester_user_name` — String. The display name of the user that requested the ad.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.ad_break.begin",
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
        "type": "channel.ad_break.begin",
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
        "duration_seconds": "60",
        "started_at": "2019-11-16T10:11:12.634234626Z",
        "is_automatic": "false",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "requester_user_id": "1337",
        "requester_user_login": "cool_user",
        "requester_user_name": "Cool_User"
    }
}
```

## Channel Bits Use {#channel-bits-use}

The `channel.bits.use` subscription type sends a notification whenever Bits are used on a channel.

This event is designed to be an all-purpose event for when Bits are used in a channel and might be
updated in the future as more Twitch features use Bits.

Currently, this event will be sent when a user:

1. Cheers
1. Uses a Power-up
    - Will not emit when a streamer uses a Power-up for free in their own channel.
1. Uses a Custom Power-Up
    - Will not emit when a streamer uses a Power-up for free in their own channel.

Bits transactions via Twitch Extensions are not included in this subscription type.

### Subscription

- Type: `channel.bits.use`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **bits:read** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **bits:read** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.bits.use`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The user ID of the channel broadcaster. Maximum: 1.
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
    - `subscription.condition.broadcaster_user_id` — String. The user ID of the channel broadcaster. Maximum: 1.
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
  - `event.broadcaster_user_id` — String. The User ID of the channel where the Bits were redeemed.
  - `event.broadcaster_user_login` — String. The login of the channel where the Bits were used.
  - `event.broadcaster_user_name` — String. The display name of the channel where the Bits were used.
  - `event.user_id` — String. The User ID of the redeeming user.
  - `event.user_login` — String. The login name of the redeeming user.
  - `event.user_name` — String. The display name of the redeeming user.
  - `event.bits` — Integer. The number of Bits used.
  - `event.type` — String
    Possible values:
    - `cheer`
    - `power_up`
    - `custom_power_up`
  - `event.message` — Object, Nullable. An object that contains the user message and emote information needed to recreate the message.
    - `event.message.text` — String. The chat message in plain text.
    - `event.message.fragments` — Object[]. The ordered list of chat message fragments.
      - `event.message.fragments.text` — String. The message text in fragment.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `cheermote`
        - `emote`
      - `event.message.fragments.emote` — Object, Nullable. The metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. The ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. The ID that identifies the emote set that the emote belongs to.
        - `event.message.fragments.emote.owner_id` — String. The ID of the broadcaster who owns the emote.
        - `event.message.fragments.emote.format` — String[]. The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated.
          Possible values:
          - `animated`: An animated GIF is available for this emote.
          - `static`: A static PNG file is available for this emote.
      - `event.message.fragments.cheermote` — Object, Nullable. The metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.
  - `event.power_up` — Object, Nullable. Data about a default (i.e. built-in) Power-up.
    - `event.power_up.type` — String
      Possible values:
      - `message_effect`
      - `celebration`
      - `gigantify_an_emote`
    - `event.power_up.emote` — Object, Nullable. Emote associated with the reward.
      - `event.power_up.emote.id` — String. The ID that uniquely identifies this emote.
      - `event.power_up.emote.name` — String. The human readable emote token.
    - `event.power_up.message_effect_id` — String, Nullable. The ID of the message effect.
  - `event.custom_power_up` — Object, Nullable. Data about a custom Power-up.
    - `event.custom_power_up.title` — String. The title of the custom Power-up.
    - `event.custom_power_up.reward_id` — String. The ID of the custom Power-up.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.bits.use",
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
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.bits.use",
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
    "bits": 2,
    "type": "cheer",
    "power_up": null,
    "custom_power_up": null,
    "message": {
      "text": "cheer1 hi cheer1",
      "fragments": [
        {
          "type": "cheermote",
          "text": "cheer1",
          "cheermote": {
            "prefix": "cheer",
            "bits": 1,
            "tier": 1
          },
          "emote": null
        },
        {
          "type": "text",
          "text": " hi ",
          "cheermote": null,
          "emote": null
        },
        {
          "type": "cheermote",
          "text": "cheer1",
          "cheermote": {
            "prefix": "cheer",
            "bits": 1,
            "tier": 1
          },
          "emote": null
        }
      ]
    }
  }
}
```

## Channel Cheer {#channel-cheer}

The `channel.cheer` subscription type sends a notification when a user cheers on the specified channel.

### Subscription

- Type: `channel.cheer`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **bits:read** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **bits:read** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.cheer`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive cheer notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get cheer notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get cheer notifications for.
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
  - `event.is_anonymous` — Boolean. Whether the user cheered anonymously or not.
  - `event.user_id` — String, Nullable. The user ID for the user who cheered on the specified channel. This is null if `is_anonymous` is true.
  - `event.user_login` — String, Nullable. The user login for the user who cheered on the specified channel. This is null if `is_anonymous` is true.
  - `event.user_name` — String, Nullable. The user display name for the user who cheered on the specified channel. This is null if `is_anonymous` is true.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.message` — String. The message sent with the cheer.
  - `event.bits` — Integer. The number of Bits cheered.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.cheer",
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
        "type": "channel.cheer",
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
        "is_anonymous": false,
        "user_id": "1234",          // null if is_anonymous=true
        "user_login": "cool_user",  // null if is_anonymous=true
        "user_name": "Cool_User",   // null if is_anonymous=true
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cooler_user",
        "broadcaster_user_name": "Cooler_User",
        "message": "pogchamp",
        "bits": 1000
    }
}
```

## Channel Custom Power-ups Redemption Add {#channel-custom-power-up-redemption-add}

The `channel.custom_power_up_redemption.add` subscription type sends a notification when a viewer has redeemed a custom Power-up on the specified channel.

### Subscription

- Type: `channel.custom_power_up_redemption.add`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **bits:read** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **bits:read** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.custom_power_up_redemption.add`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive custom Power-up redemption notifications for. You can optionally pass in a Power-up id to only receive notifications for a specific Power-up.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive custom Power-up redemption add notifications for.
  - `condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific custom Power-up.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive custom Power-up redemption add notifications for.
    - `subscription.condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific custom Power-up.
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
  - `event.id` — String. The redemption identifier.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.user_id` — String. User ID of the user that redeemed the custom Power-up.
  - `event.user_login` — String. Login of the user that redeemed the custom Power-up.
  - `event.user_name` — String. Display name of the user that redeemed the custom Power-up.
  - `event.user_input` — String. The user input provided. Empty string if not provided.
  - `event.status` — String. Defaults to **unfulfilled**. Possible values are **unknown**, **unfulfilled**, **fulfilled**, and **canceled**.
  - `event.custom_power_up` — Object. Basic information about the custom Power-up that was redeemed, at the time it was redeemed.
    - `event.custom_power_up.id` — String. The unique ID for this Custom Power-up.
    - `event.custom_power_up.title` — String. The user-viewable name of this Custom Power-up.
    - `event.custom_power_up.bits` — Integer. The cost of the Custom Power-up to redeem.
    - `event.custom_power_up.prompt` — String. The creator-provided description for this Power-up.
  - `event.redeemed_at` — String. RFC3339 timestamp of when the custom Power-up was redeemed.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.custom_power_up_redemption.add",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "reward_id": "92af127c-7326-4483-a52b-b0da0be61c01"
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
        "type": "channel.custom_power_up_redemption.add",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "reward_id": "92af127c-7326-4483-a52b-b0da0be61c01" // optional; gets notifications for a specific Power-up
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2026-05-01T10:11:12.634234626Z"
    },
    "event": {
        "id": "17fa2df1-ad76-4804-bfa5-a40ef63efe63",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "user_id": "9001",
        "user_login": "cooler_user",
        "user_name": "Cooler_User",
        "user_input": "pogchamp",
        "status": "unfulfilled",
        "custom_power_up": {
            "id": "92af127c-7326-4483-a52b-b0da0be61c01",
            "title": "title",
            "bits": 100,
            "prompt": "Power-up prompt"
        },
        "redeemed_at": "2026-05-01T17:16:03.17106713Z"
    }
}
```

## Channel Follow {#channel-follow}

The `channel.follow` subscription type sends a notification when a specified channel receives a follow.

### Subscription

- Type: `channel.follow`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:followers** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:followers** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.follow`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get follow notifications for.
  - `condition.moderator_user_id` — String, **Required**. The ID of the moderator of the channel you want to get follow notifications for. If you have authorization from the broadcaster rather than a moderator, specify the broadcaster's user ID here.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get follow notifications for.
    - `subscription.condition.moderator_user_id` — String. The ID of the moderator of the channel you want to get follow notifications for. If you have authorization from the broadcaster rather than a moderator, specify the broadcaster's user ID here.
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
  - `event.user_id` — String. The user ID for the user now following the specified channel.
  - `event.user_login` — String. The user login for the user now following the specified channel.
  - `event.user_name` — String. The user display name for the user now following the specified channel.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.followed_at` — String. RFC3339 timestamp of when the follow occurred.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.follow",
  "version": "2",
  "condition": {
    "broadcaster_user_id": "1337",
    "moderator_user_id": "1337"
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
        "type": "channel.follow",
        "version": "2",
        "status": "enabled",
        "cost": 0,
        "condition": {
           "broadcaster_user_id": "1337",
           "moderator_user_id": "1337"
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
        "followed_at": "2020-07-15T18:16:11.17106713Z"
    }
}
```

## Channel Raid {#channel-raid}

The `channel.raid` subscription type sends a notification when a broadcaster raids another broadcaster's channel.

### Subscription

- Type: `channel.raid`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

No authorization required.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.raid`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Set either the *from_broadcaster_user_id* or *to_broadcaster_user_id* condition parameter but not both. If you pass both parameters, the subscription request fails.
  - `condition.from_broadcaster_user_id` — String. The broadcaster user ID that created the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster raids another broadcaster. The channel raid condition must include either *from_broadcaster_user_id* or *to_broadcaster_user_id*.
  - `condition.to_broadcaster_user_id` — String. The broadcaster user ID that received the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster is raided by another broadcaster. The channel raid condition must include either *from_broadcaster_user_id* or *to_broadcaster_user_id*.
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
    - `subscription.condition.from_broadcaster_user_id` — String. The broadcaster user ID that created the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster raids another broadcaster. The channel raid condition must include either *from_broadcaster_user_id* or *to_broadcaster_user_id*.
    - `subscription.condition.to_broadcaster_user_id` — String. The broadcaster user ID that received the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster is raided by another broadcaster. The channel raid condition must include either *from_broadcaster_user_id* or *to_broadcaster_user_id*.
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
  - `event.from_broadcaster_user_id` — String. The broadcaster ID that created the raid.
  - `event.from_broadcaster_user_login` — String. The broadcaster login that created the raid.
  - `event.from_broadcaster_user_name` — String. The broadcaster display name that created the raid.
  - `event.to_broadcaster_user_id` — String. The broadcaster ID that received the raid.
  - `event.to_broadcaster_user_login` — String. The broadcaster login that received the raid.
  - `event.to_broadcaster_user_name` — String. The broadcaster display name that received the raid.
  - `event.viewers` — Integer. The number of viewers in the raid.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.raid",
  "version": "1",
  "condition": {
    "to_broadcaster_user_id": "1337"
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
        "type": "channel.raid",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "to_broadcaster_user_id": "1337"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "from_broadcaster_user_id": "1234",
        "from_broadcaster_user_login": "cool_user",
        "from_broadcaster_user_name": "Cool_User",
        "to_broadcaster_user_id": "1337",
        "to_broadcaster_user_login": "cooler_user",
        "to_broadcaster_user_name": "Cooler_User",
        "viewers": 9001
    }
}
```

## Shoutout Create {#channel-shoutout-create}

Sends a notification when the specified broadcaster sends a Shoutout.

### Subscription

- Type: `channel.shoutout.create`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:shoutouts** or **moderator:manage:shoutouts** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:shoutouts** or **moderator:manage:shoutouts** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.shoutout.create**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when they send a Shoutout.
  - `condition.moderator_user_id` — String, **Required**. The ID of the broadcaster that gave the Shoutout or one of the broadcaster's moderators.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when they send a Shoutout.
    - `subscription.condition.moderator_user_id` — String. The ID of the broadcaster that gave the Shoutout or one of the broadcaster's moderators.
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
  - `event.broadcaster_user_id` — String. An ID that identifies the broadcaster that sent the Shoutout.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.to_broadcaster_user_id` — String. An ID that identifies the broadcaster that received the Shoutout.
  - `event.to_broadcaster_user_login` — String. The broadcaster's login name.
  - `event.to_broadcaster_user_name` — String. The broadcaster's display name.
  - `event.moderator_user_id` — String. An ID that identifies the moderator that sent the Shoutout. If the broadcaster sent the Shoutout, this ID is the same as the ID in `broadcaster_user_id`.
  - `event.moderator_user_login` — String. The moderator's login name.
  - `event.moderator_user_name` — String. The moderator's display name.
  - `event.viewer_count` — Integer. The number of users that were watching the broadcaster's stream at the time of the Shoutout.
  - `event.started_at` — String. The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.
  - `event.cooldown_ends_at` — String. The UTC timestamp (in RFC3339 format) of when the broadcaster may send a Shoutout to a different broadcaster.
  - `event.target_cooldown_ends_at` — String. The UTC timestamp (in RFC3339 format) of when the broadcaster may send another Shoutout to the broadcaster in `to_broadcaster_user_id`.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shoutout.create",
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
    "type": "channel.shoutout.create",
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
    "to_broadcaster_user_id": "626262",
    "to_broadcaster_user_name": "SandySanderman",
    "to_broadcaster_user_login": "sandysanderman",
    "started_at": "2022-07-26T17:00:03.17106713Z",
    "viewer_count": 860,
    "cooldown_ends_at": "2022-07-26T17:02:03.17106713Z",
    "target_cooldown_ends_at":"2022-07-26T18:00:03.17106713Z"
  }
}
```

## Shoutout Received {#channel-shoutout-receive}

Sends a notification when the specified broadcaster receives a Shoutout.

> **Note** This event is only sent if Twitch posts the Shoutout to the broadcaster's activity feed.

### Subscription

- Type: `channel.shoutout.receive`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:shoutouts** or **moderator:manage:shoutouts** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:shoutouts** or **moderator:manage:shoutouts** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.shoutout.receive**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when they receive a Shoutout.
  - `condition.moderator_user_id` — String, **Required**. The ID of the broadcaster that received the Shoutout or one of the broadcaster's moderators.
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
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when they receive a Shoutout.
    - `subscription.condition.moderator_user_id` — String. The ID of the broadcaster that received the Shoutout or one of the broadcaster's moderators.
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
  - `event.broadcaster_user_id` — String. An ID that identifies the broadcaster that received the Shoutout.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.from_broadcaster_user_id` — String. An ID that identifies the broadcaster that sent the Shoutout.
  - `event.from_broadcaster_user_login` — String. The broadcaster's login name.
  - `event.from_broadcaster_user_name` — String. The broadcaster's display name.
  - `event.viewer_count` — Integer. The number of users that were watching the from-broadcaster's stream at the time of the Shoutout.
  - `event.started_at` — String. The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.shoutout.receive",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "626262",
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
    "type": "channel.shoutout.receive",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "626262",
      "moderator_user_id": "98765"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.1236739Z"
  },
  "event": {
    "broadcaster_user_id": "626262",
    "broadcaster_user_name": "SandySanderman",
    "broadcaster_user_login": "sandysanderman",
    "from_broadcaster_user_id": "12345",
    "from_broadcaster_user_name": "SimplySimple",
    "from_broadcaster_user_login": "simplysimple",
    "viewer_count": 860,
    "started_at": "2022-07-26T17:00:03.17106713Z"
  }
}
```

## Channel Subscribe {#channel-subscribe}

The `channel.subscribe` subscription type sends a notification when a specified channel receives a subscriber. This does not include resubscribes.

### Subscription

- Type: `channel.subscribe`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:subscriptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:subscriptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.subscribe`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get subscribe notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get subscribe notifications for.
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
  - `event.user_id` — String. The user ID for the user who subscribed to the specified channel.
  - `event.user_login` — String. The user login for the user who subscribed to the specified channel.
  - `event.user_name` — String. The user display name for the user who subscribed to the specified channel.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.tier` — String. The tier of the subscription. Valid values are `1000`, `2000`, and `3000`.
  - `event.is_gift` — Boolean. Whether the subscription is a gift.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.subscribe",
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
        "type": "channel.subscribe",
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
        "tier": "1000",
        "is_gift": false
    }
}
```

## Channel Subscription End {#channel-subscription-end}

The `channel.subscription.end` subscription type sends a notification when a subscription to the specified channel expires.

### Subscription

- Type: `channel.subscription.end`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:subscriptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:subscriptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.subscription.end`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get subscription end notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get subscription end notifications for.
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
  - `event.user_id` — String. The user ID for the user whose subscription ended.
  - `event.user_login` — String. The user login for the user whose subscription ended.
  - `event.user_name` — String. The user display name for the user whose subscription ended.
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.tier` — String. The tier of the subscription that ended. Valid values are `1000`, `2000`, and `3000`.
  - `event.is_gift` — Boolean. Whether the subscription was a gift.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.subscription.end",
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
        "type": "channel.subscription.end",
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
        "tier": "1000",
        "is_gift": false
    }
}
```

## Channel Subscription Gift {#channel-subscription-gift}

The `channel.subscription.gift` subscription type sends a notification when a user gives one or more gifted subscriptions in a channel.

### Subscription

- Type: `channel.subscription.gift`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:subscriptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:subscriptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.subscription.gift`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get subscription gift notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get subscription gift notifications for.
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
  - `event.user_id` — String, Nullable. The user ID of the user who sent the subscription gift. Set to **null** if it was an anonymous subscription gift.
  - `event.user_login` — String, Nullable. The user login of the user who sent the gift. Set to **null** if it was an anonymous subscription gift.
  - `event.user_name` — String, Nullable. The user display name of the user who sent the gift. Set to **null** if it was an anonymous subscription gift.
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.total` — Integer. The number of subscriptions in the subscription gift.
  - `event.tier` — String. The tier of subscriptions in the subscription gift.
  - `event.cumulative_total` — Integer, Nullable. The number of subscriptions gifted by this user in the channel. This value is **null** for anonymous gifts or if the gifter has opted out of sharing this information.
  - `event.is_anonymous` — Boolean. Whether the subscription gift was anonymous.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.subscription.gift",
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
        "type": "channel.subscription.gift",
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
        "total": 2,
        "tier": "1000",
        "cumulative_total": 284, //null if anonymous or not shared by the user
        "is_anonymous": false
    }
}
```

## Channel Subscription Message {#channel-subscription-message}

The `channel.subscription.message` subscription type sends a notification when a user sends a resubscription chat message in a specific channel.

### Subscription

- Type: `channel.subscription.message`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:subscriptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:subscriptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.subscription.message`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get resubscription chat message notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get resubscription chat message notifications for.
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
  - `event.user_id` — String. The user ID of the user who sent a resubscription chat message.
  - `event.user_login` — String. The user login of the user who sent a resubscription chat message.
  - `event.user_name` — String. The user display name of the user who a resubscription chat message.
  - `event.broadcaster_user_id` — String. The broadcaster user ID.
  - `event.broadcaster_user_login` — String. The broadcaster login.
  - `event.broadcaster_user_name` — String. The broadcaster display name.
  - `event.tier` — String. The tier of the user's subscription.
  - `event.message` — Object. An object that contains the resubscription message and emote information needed to recreate the message.
    - `event.message.text` — String. The text of the resubscription chat message.
    - `event.message.emotes` — Object[]. An array that includes the emote ID and start and end positions for where the emote appears in the text.
      - `event.message.emotes.begin` — Integer. The index of where the Emote starts in the text.
      - `event.message.emotes.end` — Integer. The index of where the Emote ends in the text.
      - `event.message.emotes.id` — String. The emote ID.
  - `event.cumulative_months` — Integer. The total number of months the user has been subscribed to the channel.
  - `event.streak_months` — Integer, Nullable. The number of consecutive months the user's current subscription has been active. This value is **null** if the user has opted out of sharing this information.
  - `event.duration_months` — Integer. The month duration of the subscription.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.subscription.message",
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
        "type": "channel.subscription.message",
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
        "tier": "1000",
        "message": {
            "text": "Love the stream! FevziGG",
            "emotes": [
                {
                    "begin": 23,
                    "end": 30,
                    "id": "302976485"
                }
            ]
        },
        "cumulative_months": 15,
        "streak_months": 1, // null if not shared
        "duration_months": 6
    }
}
```

## Channel Update {#channel-update}

The `channel.update` subscription type sends notifications when a broadcaster updates the category, title, [content classification labels](https://safety.twitch.tv/s/article/Content-Classification-Guidelines), or broadcast language for their channel.

### Subscription

- Type: `channel.update`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

No authorization required.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.update`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Pass in the *broadcaster_user_id* for the channel you want updates for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to get updates for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to get updates for.
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
  - `event.broadcaster_user_id` — String. The broadcaster's user ID.
  - `event.broadcaster_user_login` — String. The broadcaster's user login.
  - `event.broadcaster_user_name` — String. The broadcaster's user display name.
  - `event.title` — String. The channel's stream title.
  - `event.language` — String. The channel's broadcast language.
  - `event.category_id` — String. The channel's category ID.
  - `event.category_name` — String. The category name.
  - `event.content_classification_labels` — String[]. Array of content classification label IDs currently applied on the Channel. To retrieve a list of all possible IDs, use the [Get Content Classification Labels](https://dev.twitch.tv/docs/api/reference/ccls.md#get-content-classification-labels) API endpoint.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.update",
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
        "type": "channel.update",
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
        "created_at": "2023-06-29T17:20:33.860897266Z"
    },
    "event": {
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "title": "Best Stream Ever",
        "language": "en",
        "category_id": "12453",
        "category_name": "Grand Theft Auto",
        "content_classification_labels": [ "MatureGame" ]
    }
}
```

## Channel VIP Add {#channel-vip-add}

The `channel.vip.add` subscription type sends a notification when a VIP is added to the channel.

### Subscription

- Type: `channel.vip.add`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:vips** or **channel:manage:vips** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:vips** or **channel:manage:vips** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.vip.add`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the broadcaster (channel) Maximum: 1
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
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the broadcaster (channel) Maximum: 1
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
  - `event.user_id` — String. The ID of the user who was added as a VIP.
  - `event.user_login` — String. The login of the user who was added as a VIP.
  - `event.user_name` — String. The display name of the user who was added as a VIP.
  - `event.broadcaster_user_id` — String. The ID of the broadcaster.
  - `event.broadcaster_user_login` — String. The login of the broadcaster.
  - `event.broadcaster_user_name` — String. The display name of the broadcaster.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.vip.add",
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
    "id": "7297f7eb-3bf5-461f-8ae6-7cd7781ebce3",
    "status": "enabled",
    "type": "channel.vip.add",
    "version": "1",
    "cost": 0,
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
    "user_id": "1234",
    "user_login": "mod_user",
    "user_name": "Mod_User",
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "cooler_user",
    "broadcaster_user_name": "Cooler_User"
  }
}
```

## Channel VIP Remove {#channel-vip-remove}

The `channel.vip.remove` subscription type sends a notification when a VIP is removed from the channel.

### Subscription

- Type: `channel.vip.remove`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:vips** or **channel:manage:vips** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:vips** or **channel:manage:vips** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.vip.remove`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The User ID of the broadcaster (channel) Maximum: 1
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
    - `subscription.condition.broadcaster_user_id` — String. The User ID of the broadcaster (channel) Maximum: 1
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
  - `event.user_id` — String. The ID of the user who was removed as a VIP.
  - `event.user_login` — String. The login of the user who was removed as a VIP.
  - `event.user_name` — String. The display name of the user who was removed as a VIP.
  - `event.broadcaster_user_id` — String. The ID of the broadcaster.
  - `event.broadcaster_user_login` — String. The login of the broadcaster.
  - `event.broadcaster_user_name` — String. The display name of the broadcaster.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.vip.remove",
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
    "id": "7297f7eb-3bf5-461f-8ae6-7cd7781ebce3",
    "status": "enabled",
    "type": "channel.vip.remove",
    "version": "1",
    "cost": 0,
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
    "user_id": "1234",
    "user_login": "mod_user",
    "user_name": "Mod_User",
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "cooler_user",
    "broadcaster_user_name": "Cooler_User"
  }
}
```
