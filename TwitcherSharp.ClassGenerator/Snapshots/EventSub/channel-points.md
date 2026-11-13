# Channel Points

Events raised when a broadcaster manages their Channel Points rewards, and when a viewer redeems an automatic or custom reward.

Source: https://dev.twitch.tv/docs/eventsub/reference/channel-points/

## Contents {#contents}

7 entries on this page:

- [Channel Points Automatic Reward Redemption Add](#channel-channel-points-automatic-reward-redemption-add)
- [Channel Points Automatic Reward Redemption Add V2](#channel-channel-points-automatic-reward-redemption-add-v2)
- [Channel Points Custom Reward Redemption Add](#channel-channel-points-custom-reward-redemption-add)
- [Channel Points Custom Reward Redemption Update](#channel-channel-points-custom-reward-redemption-update)
- [Channel Points Custom Reward Add](#channel-channel-points-custom-reward-add)
- [Channel Points Custom Reward Remove](#channel-channel-points-custom-reward-remove)
- [Channel Points Custom Reward Update](#channel-channel-points-custom-reward-update)

## Channel Points Automatic Reward Redemption Add {#channel-channel-points-automatic-reward-redemption-add}

The `channel.channel_points_automatic_reward_redemption.add` subscription type sends a notification when a viewer has redeemed an automatic channel points reward on the specified channel.

### Subscription

- Type: `channel.channel_points_automatic_reward_redemption.add`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_automatic_reward_redemption.add`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
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
  - `event.broadcaster_user_id` — String. The ID of the channel where the reward was redeemed.
  - `event.broadcaster_user_login` — String. The login of the channel where the reward was redeemed.
  - `event.broadcaster_user_name` — String. The display name of the channel where the reward was redeemed.
  - `event.user_id` — String. The ID of the redeeming user.
  - `event.user_login` — String. The login of the redeeming user.
  - `event.user_name` — String. The display name of the redeeming user.
  - `event.id` — String. The ID of the Redemption.
  - `event.reward` — Object. An object that contains the reward information.
    - `event.reward.type` — String. The type of reward.
      Possible values:
      - `single_message_bypass_sub_mode`
      - `send_highlighted_message`
      - `random_sub_emote_unlock`
      - `chosen_sub_emote_unlock`
      - `chosen_modified_sub_emote_unlock`
      - `message_effect`
      - `gigantify_an_emote`
      - `celebration`
    - `event.reward.cost` — Integer. The reward cost.
    - `event.reward.unlocked_emote` — Object, Nullable. Emote that was unlocked.
      - `event.reward.unlocked_emote.id` — String. The emote ID.
      - `event.reward.unlocked_emote.name` — String. The human readable emote token.
  - `event.message` — Object. An object that contains the user message and emote information needed to recreate the message.
    - `event.message.text` — String. The text of the chat message.
    - `event.message.emotes` — Object[]. An array that includes the emote ID and start and end positions for where the emote appears in the text.
      - `event.message.emotes.begin` — Integer. The index of where the Emote starts in the text.
      - `event.message.emotes.end` — Integer. The index of where the Emote ends in the text.
      - `event.message.emotes.id` — String. The emote ID.
  - `event.user_input` — String, Nullable. A string that the user entered if the reward requires input.
  - `event.redeemed_at` — String. The UTC date and time (in RFC3339 format) of when the reward was redeemed.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_automatic_reward_redemption.add",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "12826"
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
    "type": "channel.channel_points_automatic_reward_redemption.add",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "12826"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2024-02-23T21:12:33.771005262Z",
    "cost": 0
  },
  "event": {
    "broadcaster_user_id": "12826",
    "broadcaster_user_name": "Twitch",
    "broadcaster_user_login": "twitch",
    "user_id": "141981764",
    "user_name": "TwitchDev",
    "user_login": "twitchdev",
    "id": "f024099a-e0fe-4339-9a0a-a706fb59f353",
    "reward": {
      "type": "send_highlighted_message",
      "cost": 100,
      "unlocked_emote": null
    },
    "message": {
      "text": "Hello world! VoHiYo",
      "emotes": [
        {
          "id": "81274",
          "begin": 13,
          "end": 18
        }
      ]
    },
    "user_input": "Hello world! VoHiYo ",
    "redeemed_at": "2024-02-23T21:14:34.260398045Z"
  }
}
```

## Channel Points Automatic Reward Redemption Add V2 {#channel-channel-points-automatic-reward-redemption-add-v2}

The `channel.channel_points_automatic_reward_redemption.add` subscription type sends a notification when a viewer has redeemed an automatic channel points reward on the specified channel.

### Subscription

- Type: `channel.channel_points_automatic_reward_redemption.add`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_automatic_reward_redemption.add`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points reward add notifications for.
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
  - `event.broadcaster_user_id` — String. The ID of the channel where the reward was redeemed.
  - `event.broadcaster_user_login` — String. The login of the channel where the reward was redeemed.
  - `event.broadcaster_user_name` — String. The display name of the channel where the reward was redeemed.
  - `event.user_id` — String. The ID of the redeeming user.
  - `event.user_login` — String. The login of the redeeming user.
  - `event.user_name` — String. The display name of the redeeming user.
  - `event.id` — String. The ID of the Redemption.
  - `event.reward` — Object. An object that contains the reward information.
    - `event.reward.type` — String. The type of reward.
      Possible values:
      - `single_message_bypass_sub_mode`
      - `send_highlighted_message`
      - `random_sub_emote_unlock`
      - `chosen_sub_emote_unlock`
      - `chosen_modified_sub_emote_unlock`
    - `event.reward.channel_points` — Integer. Number of channel points used.
    - `event.reward.emote` — Object, Nullable. Emote associated with the reward.
      - `event.reward.emote.id` — String. The emote ID.
      - `event.reward.emote.name` — String. The human readable emote token.
  - `event.message` — Object, Nullable. An object that contains the user message and emote information needed to recreate the message.
    - `event.message.text` — String. The chat message in plain text.
    - `event.message.fragments` — Object[]. The ordered list of chat message fragments.
      - `event.message.fragments.text` — String. The message text in fragment.
      - `event.message.fragments.type` — String. The type of message fragment.
        Possible values:
        - `text`
        - `emote`
      - `event.message.fragments.emote` — Object, Nullable. The metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. The ID that uniquely identifies this emote.
  - `event.redeemed_at` — String. The UTC date and time (in RFC3339 format) of when the reward was redeemed.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_automatic_reward_redemption.add",
  "version": "2",
  "condition": {
    "broadcaster_user_id": "12826"
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
    "type": "channel.channel_points_automatic_reward_redemption.add",
    "version": "2",
    "condition": {
      "broadcaster_user_id": "12826"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2024-02-23T21:12:33.771005262Z",
    "cost": 0
  },
  "event": {
    "broadcaster_user_id": "12826",
    "broadcaster_user_name": "Twitch",
    "broadcaster_user_login": "twitch",
    "user_id": "141981764",
    "user_name": "TwitchDev",
    "user_login": "twitchdev",
    "id": "f024099a-e0fe-4339-9a0a-a706fb59f353",
    "reward": {
      "type": "send_highlighted_message",
      "channel_points": 100,
      "emote": null
    },
    "message": {
      "text": "Hello world! VoHiYo",
      "fragments": [
        {
          "type": "text",
          "text": "Hello world! ",
          "emote": null
        },
        {
          "type": "emote",
          "text": "VoHiYo",
          "emote": {
            "id": "81274"
          }
        }
      ]
    },
    "redeemed_at": "2024-08-12T21:14:34.260398045Z"
  }
}
```

## Channel Points Custom Reward Redemption Add {#channel-channel-points-custom-reward-redemption-add}

The `channel.channel_points_custom_reward_redemption.add` subscription type sends a notification when a viewer has redeemed a custom channel points reward on the specified channel.

### Subscription

- Type: `channel.channel_points_custom_reward_redemption.add`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_custom_reward_redemption.add`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive channel points custom reward redemption notifications for. You can optionally pass in a reward id to only receive notifications for a specific reward.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points custom reward redemption add notifications for.
  - `condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points custom reward redemption add notifications for.
    - `subscription.condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
  - `event.user_id` — String. User ID of the user that redeemed the reward.
  - `event.user_login` — String. Login of the user that redeemed the reward.
  - `event.user_name` — String. Display name of the user that redeemed the reward.
  - `event.user_input` — String. The user input provided. Empty string if not provided.
  - `event.status` — String. Defaults to **unfulfilled**. Possible values are **unknown**, **unfulfilled**, **fulfilled**, and **canceled**.
  - `event.redeemed_at` — String. RFC3339 timestamp of when the reward was redeemed.
  - `event.reward` — Object. Basic information about the reward that was redeemed, at the time it was redeemed.
    - `event.reward.id` — String. The reward identifier.
    - `event.reward.title` — String. The reward name.
    - `event.reward.cost` — Integer. The reward cost.
    - `event.reward.prompt` — String. The reward description.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_custom_reward_redemption.add",
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
        "type": "channel.channel_points_custom_reward_redemption.add",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "reward_id": "92af127c-7326-4483-a52b-b0da0be61c01" // optional; gets notifications for a specific reward
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
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
        "reward": {
            "id": "92af127c-7326-4483-a52b-b0da0be61c01",
            "title": "title",
            "cost": 100,
            "prompt": "reward prompt"
        },
        "redeemed_at": "2020-07-15T17:16:03.17106713Z"
    }
}
```

## Channel Points Custom Reward Redemption Update {#channel-channel-points-custom-reward-redemption-update}

The `channel.channel_points_custom_reward_redemption.update` subscription type sends a notification when a redemption of a channel points custom reward has been updated for the specified channel.

### Subscription

- Type: `channel.channel_points_custom_reward_redemption.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_custom_reward_redemption.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive channel points custom reward redemption update notifications for. You can optionally pass in a reward id to only receive notifications for a specific reward.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points custom reward redemption update notifications for.
  - `condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points custom reward redemption update notifications for.
    - `subscription.condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
  - `event.user_id` — String. User ID of the user that redeemed the reward.
  - `event.user_login` — String. Login of the user that redeemed the reward.
  - `event.user_name` — String. Display name of the user that redeemed the reward.
  - `event.user_input` — String. The user input provided. Empty string if not provided.
  - `event.status` — String. Will be **fulfilled** or **canceled**. Possible values are **unknown**, **unfulfilled**, **fulfilled**, and **canceled**.
  - `event.reward` — Object. Basic information about the reward that was redeemed, at the time it was redeemed.
    - `event.reward.id` — String. The reward identifier.
    - `event.reward.title` — String. The reward name.
    - `event.reward.cost` — Integer. The reward cost.
    - `event.reward.prompt` — String. The reward description.
  - `event.redeemed_at` — String. RFC3339 timestamp of when the reward was redeemed.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_custom_reward_redemption.update",
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
        "type": "channel.channel_points_custom_reward_redemption.update",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "reward_id": "92af127c-7326-4483-a52b-b0da0be61c01" // optional; gets notifications for a specific reward
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
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
        "status": "fulfilled",  // Either fulfilled or cancelled
        "reward": {
            "id": "92af127c-7326-4483-a52b-b0da0be61c01",
            "title": "title",
            "cost": 100,
            "prompt": "reward prompt"
        },
        "redeemed_at": "2020-07-15T17:16:03.17106713Z"
    }
}
```

## Channel Points Custom Reward Add {#channel-channel-points-custom-reward-add}

The `channel.channel_points_custom_reward.add` subscription type sends a notification when a custom channel points reward has been created for the specified channel.

### Subscription

- Type: `channel.channel_points_custom_reward.add`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_custom_reward.add`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive channel points customer reward add notifications for.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points custom reward add notifications for.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points custom reward add notifications for.
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
  - `event.id` — String. The reward identifier.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.is_enabled` — Boolean. Is the reward currently enabled. If false, the reward won't show up to viewers.
  - `event.is_paused` — Boolean. Is the reward currently paused. If true, viewers can't redeem.
  - `event.is_in_stock` — Boolean. Is the reward currently in stock. If false, viewers can't redeem.
  - `event.title` — String. The reward title.
  - `event.cost` — Integer. The reward cost.
  - `event.prompt` — String. The reward description.
  - `event.is_user_input_required` — Boolean. Does the viewer need to enter information when redeeming the reward.
  - `event.should_redemptions_skip_request_queue` — Boolean. Should redemptions be set to **fulfilled** status immediately when redeemed and skip the request queue instead of the normal **unfulfilled** status.
  - `event.max_per_stream` — Object. Whether a maximum per stream is enabled and what the maximum is.
    - `event.max_per_stream.is_enabled` — Boolean. Is the setting enabled.
    - `event.max_per_stream.value` — Integer. The max per stream limit.
  - `event.max_per_user_per_stream` — Object. Whether a maximum per user per stream is enabled and what the maximum is.
    - `event.max_per_user_per_stream.is_enabled` — Boolean. Is the setting enabled.
    - `event.max_per_user_per_stream.value` — Integer. The max per user per stream limit.
  - `event.background_color` — String. Custom background color for the reward. Format: Hex with \# prefix. Example: `#FA1ED2`.
  - `event.image` — Object. Set of custom images of 1x, 2x and 4x sizes for the reward. Can be **null** if no images have been uploaded.
    - `event.image.url_1x` — String. URL for the image at 1x size.
    - `event.image.url_2x` — String. URL for the image at 2x size.
    - `event.image.url_4x` — String. URL for the image at 4x size.
  - `event.default_image` — Object. Set of default images of 1x, 2x and 4x sizes for the reward.
    - `event.default_image.url_1x` — String. URL for the image at 1x size.
    - `event.default_image.url_2x` — String. URL for the image at 2x size.
    - `event.default_image.url_4x` — String. URL for the image at 4x size.
  - `event.global_cooldown` — Object. Whether a cooldown is enabled and what the cooldown is in seconds.
    - `event.global_cooldown.is_enabled` — Boolean. Is the setting enabled.
    - `event.global_cooldown.seconds` — Integer. The cooldown in seconds.
  - `event.cooldown_expires_at` — String, Nullable. Timestamp of the cooldown expiration. **null** if the reward isn't on cooldown.
  - `event.redemptions_redeemed_current_stream` — Integer, Nullable. The number of redemptions redeemed during the current live stream. Counts against the `max_per_stream` limit. **null** if the broadcasters stream isn't live or `max_per_stream` isn't enabled.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_custom_reward.add",
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
        "type": "channel.channel_points_custom_reward.add",
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
        "id": "9001",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "is_enabled": true,
        "is_paused": false,
        "is_in_stock": true,
        "title": "Cool Reward",
        "cost": 100,
        "prompt": "reward prompt",
        "is_user_input_required": true,
        "should_redemptions_skip_request_queue": false,
        "cooldown_expires_at": null,
        "redemptions_redeemed_current_stream": null,
        "max_per_stream": {
            "is_enabled": true,
            "value": 1000
        },
        "max_per_user_per_stream": {
            "is_enabled": true,
            "value": 1000
        },
        "global_cooldown": {
            "is_enabled": true,
            "seconds": 1000
        },
        "background_color": "#FA1ED2",
        "image": {
            "url_1x": "https://static-cdn.jtvnw.net/image-1.png",
            "url_2x": "https://static-cdn.jtvnw.net/image-2.png",
            "url_4x": "https://static-cdn.jtvnw.net/image-4.png"
        },
        "default_image": {
            "url_1x": "https://static-cdn.jtvnw.net/default-1.png",
            "url_2x": "https://static-cdn.jtvnw.net/default-2.png",
            "url_4x": "https://static-cdn.jtvnw.net/default-4.png"
        }
    }
}
```

## Channel Points Custom Reward Remove {#channel-channel-points-custom-reward-remove}

The `channel.channel_points_custom_reward.remove` subscription type sends a notification when a custom channel points reward has been removed from the specified channel.

### Subscription

- Type: `channel.channel_points_custom_reward.remove`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_custom_reward.remove`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive channel points custom reward remove notifications for. You can optionally pass in a reward ID to only receive notifications for a specific reward.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points custom reward remove notifications for.
  - `condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points custom reward remove notifications for.
    - `subscription.condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
  - `event.id` — String. The reward identifier.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.is_enabled` — Boolean. Is the reward currently enabled. If false, the reward won't show up to viewers.
  - `event.is_paused` — Boolean. Is the reward currently paused. If true, viewers can't redeem.
  - `event.is_in_stock` — Boolean. Is the reward currently in stock. If false, viewers can't redeem.
  - `event.title` — String. The reward title.
  - `event.cost` — Integer. The reward cost.
  - `event.prompt` — String. The reward description.
  - `event.is_user_input_required` — Boolean. Does the viewer need to enter information when redeeming the reward.
  - `event.should_redemptions_skip_request_queue` — Boolean. Should redemptions be set to **fulfilled** status immediately when redeemed and skip the request queue instead of the normal **unfulfilled** status.
  - `event.max_per_stream` — Object. Whether a maximum per stream is enabled and what the maximum is.
    - `event.max_per_stream.is_enabled` — Boolean. Is the setting enabled.
    - `event.max_per_stream.value` — Integer. The max per stream limit.
  - `event.max_per_user_per_stream` — Object. Whether a maximum per user per stream is enabled and what the maximum is.
    - `event.max_per_user_per_stream.is_enabled` — Boolean. Is the setting enabled.
    - `event.max_per_user_per_stream.value` — Integer. The max per user per stream limit.
  - `event.background_color` — String. Custom background color for the reward. Format: Hex with \# prefix. Example: `#FA1ED2`.
  - `event.image` — Object. Set of custom images of 1x, 2x and 4x sizes for the reward. Can be **null** if no images have been uploaded.
    - `event.image.url_1x` — String. URL for the image at 1x size.
    - `event.image.url_2x` — String. URL for the image at 2x size.
    - `event.image.url_4x` — String. URL for the image at 4x size.
  - `event.default_image` — Object. Set of default images of 1x, 2x and 4x sizes for the reward.
    - `event.default_image.url_1x` — String. URL for the image at 1x size.
    - `event.default_image.url_2x` — String. URL for the image at 2x size.
    - `event.default_image.url_4x` — String. URL for the image at 4x size.
  - `event.global_cooldown` — Object. Whether a cooldown is enabled and what the cooldown is in seconds.
    - `event.global_cooldown.is_enabled` — Boolean. Is the setting enabled.
    - `event.global_cooldown.seconds` — Integer. The cooldown in seconds.
  - `event.cooldown_expires_at` — String, Nullable. Timestamp of the cooldown expiration. **null** if the reward isn't on cooldown.
  - `event.redemptions_redeemed_current_stream` — Integer, Nullable. The number of redemptions redeemed during the current live stream. Counts against the `max_per_stream` limit. **null** if the broadcasters stream isn't live or `max_per_stream` isn't enabled.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_custom_reward.remove",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "reward_id": "9001"
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
        "type": "channel.channel_points_custom_reward.remove",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "broadcaster_user_id": "1337",
            "reward_id": "12345"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "id": "9001",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "is_enabled": true,
        "is_paused": false,
        "is_in_stock": true,
        "title": "Cool Reward",
        "cost": 100,
        "prompt": "reward prompt",
        "is_user_input_required": true,
        "should_redemptions_skip_request_queue": false,
        "cooldown_expires_at": "2019-11-16T10:11:12.123Z",
        "redemptions_redeemed_current_stream": 123,
        "max_per_stream": {
            "is_enabled": true,
            "value": 1000
        },
        "max_per_user_per_stream": {
            "is_enabled": true,
            "value": 1000
        },
        "global_cooldown": {
            "is_enabled": true,
            "seconds": 1000
        },
        "background_color": "#FA1ED2",
        "image": {
            "url_1x": "https://static-cdn.jtvnw.net/image-1.png",
            "url_2x": "https://static-cdn.jtvnw.net/image-2.png",
            "url_4x": "https://static-cdn.jtvnw.net/image-4.png"
        },
        "default_image": {
            "url_1x": "https://static-cdn.jtvnw.net/default-1.png",
            "url_2x": "https://static-cdn.jtvnw.net/default-2.png",
            "url_4x": "https://static-cdn.jtvnw.net/default-4.png"
        }
    }
}
```

## Channel Points Custom Reward Update {#channel-channel-points-custom-reward-update}

The `channel.channel_points_custom_reward.update` subscription type sends a notification when a custom channel points reward has been updated for the specified channel.

### Subscription

- Type: `channel.channel_points_custom_reward.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:redemptions** or **channel:manage:redemptions** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `channel.channel_points_custom_reward.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the broadcaster user ID for the channel you want to receive channel points custom reward update notifications for. You can optionally pass in a reward id to only receive notifications for a specific reward.
  - `condition.broadcaster_user_id` — String, **Required**. The broadcaster user ID for the channel you want to receive channel points custom reward update notifications for.
  - `condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
    - `subscription.condition.broadcaster_user_id` — String. The broadcaster user ID for the channel you want to receive channel points custom reward update notifications for.
    - `subscription.condition.reward_id` — String, Nullable. Specify a reward id to only receive notifications for a specific reward.
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
  - `event.id` — String. The reward identifier.
  - `event.broadcaster_user_id` — String. The requested broadcaster ID.
  - `event.broadcaster_user_login` — String. The requested broadcaster login.
  - `event.broadcaster_user_name` — String. The requested broadcaster display name.
  - `event.is_enabled` — Boolean. Is the reward currently enabled. If false, the reward won't show up to viewers.
  - `event.is_paused` — Boolean. Is the reward currently paused. If true, viewers can't redeem.
  - `event.is_in_stock` — Boolean. Is the reward currently in stock. If false, viewers can't redeem.
  - `event.title` — String. The reward title.
  - `event.cost` — Integer. The reward cost.
  - `event.prompt` — String. The reward description.
  - `event.is_user_input_required` — Boolean. Does the viewer need to enter information when redeeming the reward.
  - `event.should_redemptions_skip_request_queue` — Boolean. Should redemptions be set to **fulfilled** status immediately when redeemed and skip the request queue instead of the normal **unfulfilled** status.
  - `event.max_per_stream` — Object. Whether a maximum per stream is enabled and what the maximum is.
    - `event.max_per_stream.is_enabled` — Boolean. Is the setting enabled.
    - `event.max_per_stream.value` — Integer. The max per stream limit.
  - `event.max_per_user_per_stream` — Object. Whether a maximum per user per stream is enabled and what the maximum is.
    - `event.max_per_user_per_stream.is_enabled` — Boolean. Is the setting enabled.
    - `event.max_per_user_per_stream.value` — Integer. The max per user per stream limit.
  - `event.background_color` — String. Custom background color for the reward. Format: Hex with \# prefix. Example: `#FA1ED2`.
  - `event.image` — Object. Set of custom images of 1x, 2x and 4x sizes for the reward. Can be **null** if no images have been uploaded.
    - `event.image.url_1x` — String. URL for the image at 1x size.
    - `event.image.url_2x` — String. URL for the image at 2x size.
    - `event.image.url_4x` — String. URL for the image at 4x size.
  - `event.default_image` — Object. Set of default images of 1x, 2x and 4x sizes for the reward.
    - `event.default_image.url_1x` — String. URL for the image at 1x size.
    - `event.default_image.url_2x` — String. URL for the image at 2x size.
    - `event.default_image.url_4x` — String. URL for the image at 4x size.
  - `event.global_cooldown` — Object. Whether a cooldown is enabled and what the cooldown is in seconds.
    - `event.global_cooldown.is_enabled` — Boolean. Is the setting enabled.
    - `event.global_cooldown.seconds` — Integer. The cooldown in seconds.
  - `event.cooldown_expires_at` — String, Nullable. Timestamp of the cooldown expiration. **null** if the reward isn't on cooldown.
  - `event.redemptions_redeemed_current_stream` — Integer, Nullable. The number of redemptions redeemed during the current live stream. Counts against the `max_per_stream` limit. **null** if the broadcasters stream isn't live or `max_per_stream` isn't enabled.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.channel_points_custom_reward.update",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "reward_id": "9001"
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
        "type": "channel.channel_points_custom_reward.update",
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
        "id": "9001",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "is_enabled": true,
        "is_paused": false,
        "is_in_stock": true,
        "title": "Cool Reward",
        "cost": 100,
        "prompt": "reward prompt",
        "is_user_input_required": true,
        "should_redemptions_skip_request_queue": false,
        "cooldown_expires_at": "2019-11-16T10:11:12.634234626Z",
        "redemptions_redeemed_current_stream": 123,
        "max_per_stream": {
            "is_enabled": true,
            "value": 1000
        },
        "max_per_user_per_stream": {
            "is_enabled": true,
            "value": 1000
        },
        "global_cooldown": {
            "is_enabled": true,
            "seconds": 1000
        },
        "background_color": "#FA1ED2",
        "image": {
            "url_1x": "https://static-cdn.jtvnw.net/image-1.png",
            "url_2x": "https://static-cdn.jtvnw.net/image-2.png",
            "url_4x": "https://static-cdn.jtvnw.net/image-4.png"
        },
        "default_image": {
            "url_1x": "https://static-cdn.jtvnw.net/default-1.png",
            "url_2x": "https://static-cdn.jtvnw.net/default-2.png",
            "url_4x": "https://static-cdn.jtvnw.net/default-4.png"
        }
    }
}
```
