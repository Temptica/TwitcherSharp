# AutoMod

Events raised when AutoMod holds, updates or reviews a message, and when a broadcaster changes their AutoMod settings or terms.

Source: https://dev.twitch.tv/docs/eventsub/reference/automod/

## Contents {#contents}

6 entries on this page:

- [AutoMod Message Hold](#automod-message-hold)
- [AutoMod Message Hold V2](#automod-message-hold-v2)
- [AutoMod Message Update](#automod-message-update)
- [AutoMod Message Update V2](#automod-message-update-v2)
- [AutoMod Settings Update](#automod-settings-update)
- [AutoMod Terms Update](#automod-terms-update)

## AutoMod Message Hold {#automod-message-hold}

Notifies a user if their chat message was caught by AutoMod for review.

### Subscription

- Type: `automod.message.hold`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod** scope. The User ID associated with the token must match the *moderator_user_id* in the event's condition.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name. Must be `automod.message.hold`.
- `version` — String, **Required**. The subscription type version. Must be `1`.
- `condition` — Object, **Required**. Subscription-specific parameters
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the broadcaster channel.
  - `condition.moderator_user_id` — String, **Required**. User ID of the moderator. This user must be have either moderator or broadcaster status for the channel specified in *broadcaster_user_id*.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the broadcaster channel.
    - `subscription.condition.moderator_user_id` — String. User ID of the moderator.
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
  - `event.broadcaster_user_id` — String. The ID of the broadcaster specified in the subscription condition.
  - `event.broadcaster_user_login` — String. The login of the broadcaster specified in the subscription condition.
  - `event.broadcaster_user_name` — String. The display name of the broadcaster specified in the subscription condition.
  - `event.user_id` — String. The message sender's User ID.
  - `event.user_login` — String. The message sender's login name.
  - `event.user_name` — String. The message sender's display name.
  - `event.message_id` — String. The ID of the message that was flagged by AutoMod.
  - `event.message` — Object. The body of the message.
    - `event.message.text` — String. The contents of the message caught by AutoMod.
    - `event.message.fragments` — Object[]. Metadata surrounding the potential inappropriate fragments of the message.
      - `event.message.fragments.text` — String. Message text within a fragment.
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to
          lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full
          Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch
          converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.
  - `event.category` — String. The category of the message.
  - `event.level` — Integer. The level of severity. Measured between 1 to 4.
  - `event.held_at` — String. The timestamp of when AutoMod saved the message.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "automod.message.hold",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "1337",
    "moderator_user_id": "9001"
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
    "type": "automod.message.hold",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "moderator_user_id": "9001"
    },
    "created_at": "2023-04-11T10:11:12.123Z",
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    }
  },
  "event": {
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "blahblah",
    "broadcaster_user_name": "blah",
    "user_id": "456789012",
    "user_login": "baduserbla",
    "user_name": "baduser",
    "message_id": "bad-message-id",
    "message": {
      "text": "This is a bad message badtextemote1 cheer100",
      "fragments": [
        {
          "text": "This is a bad message ",
          "emote": null,
          "cheermote": null
        },
        {
          "text": "badtextemote1",
          "emote": {
            "id": "emote-123",
            "emote_set_id": "set-emote-1"
          },
          "cheermote": null
        },
        {
          "text": " ",
          "emote": null,
          "cheermote": null
        },
        {
          "text": "cheer100",
          "emote": null,
          "cheermote": {
            "prefix": "cheer",
            "bits": 100,
            "tier": 1
          }
        }
      ]
    },
    "category": "aggressive",
    "level": 4,
    "held_at": "2022-12-02T15:00:00.00Z"
  }
}
```

## AutoMod Message Hold V2 {#automod-message-hold-v2}

The `automod.message.hold` subscription type notifies a user if a message was caught by AutoMod for review. Only public blocked terms trigger notifications, not private ones.

### Subscription

- Type: `automod.message.hold`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod** scope. The User ID associated with the token must match the *moderator_user_id* in the event's condition.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `automod.message.hold`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the broadcaster channel.
  - `condition.moderator_user_id` — String, **Required**. User ID of the moderator.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the broadcaster channel.
    - `subscription.condition.moderator_user_id` — String. User ID of the moderator.
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
  - `event.user_id` — String. The message sender's user ID.
  - `event.user_login` — String. The message sender's login name.
  - `event.user_name` — String. The message sender's display name.
  - `event.message_id` — String. The ID of the held message.
  - `event.message` — Object. The body of the message.
    - `event.message.text` — String. The contents of the message caught by automod.
    - `event.message.fragments` — Object[]. Metadata surrounding the potential inappropriate fragments of the message.
      - `event.message.fragments.type` — String
        Possible values:
        - `text`
        - `emote`
        - `cheermote`
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
  - `event.held_at` — String. The timestamp of when automod saved the message.
  - `event.reason` — String
    Possible values:
    - `automod`
    - `blocked_term`
    - `blocked_link`
  - `event.automod` — Object, Nullable. If the message was caught by automod, this will be populated.
    - `event.automod.category` — String. The category of the caught message.
    - `event.automod.level` — Integer. The level of severity (1-4).
    - `event.automod.boundaries` — Object[]. The bounds of the text that caused the message to be caught.
      - `event.automod.boundaries.start_pos` — Integer. Index in the message for the start of the problem (0 indexed, inclusive).
      - `event.automod.boundaries.end_pos` — Integer. Index in the message for the end of the problem (0 indexed, inclusive).
  - `event.blocked_term` — Object, Nullable. If the message was caught due to a blocked term or blocked link, this will be populated.
    - `event.blocked_term.terms_found` — Object[]. The list of blocked terms found in the message.
      - `event.blocked_term.terms_found.term_id` — String. The id of the blocked term found.
      - `event.blocked_term.terms_found.boundary` — Object. The bounds of the text that caused the message to be caught.
        - `event.blocked_term.terms_found.boundary.start_pos` — Integer. Index in the message for the start of the problem (0 indexed, inclusive).
        - `event.blocked_term.terms_found.boundary.end_pos` — Integer. Index in the message for the end of the problem (0 indexed, inclusive).
      - `event.blocked_term.terms_found.owner_broadcaster_user_id` — String. The id of the broadcaster that owns the blocked term.
      - `event.blocked_term.terms_found.owner_broadcaster_user_login` — String. The login of the broadcaster that owns the blocked term.
      - `event.blocked_term.terms_found.owner_broadcaster_user_name` — String. The username of the broadcaster that owns the blocked term.

### Subscription Request Body Example (Webhook)

```json
{
    "type": "automod.message.hold",
    "version": "2",
    "condition": {
        "broadcaster_user_id": "1337",
        "moderator_user_id": "9001"
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
   "type": "automod.message.hold",
   "version": "2",
   "status": "enabled",
   "cost": 0,
   "condition": {
     "broadcaster_user_id": "1337",
     "moderator_user_id": "9001"
   },
   "transport": {
     "method": "webhook",
     "callback": "https://example.com/webhooks/callback"
   },
   "created_at": "2023-04-11T10:11:12.123Z"
 },
 "event": {
   "broadcaster_user_id": "1337",
   "broadcaster_user_login": "blah",
   "broadcaster_user_name": "blahblah",
   "user_id": "4242",
   "user_login": "baduser",
   "user_name": "badbaduser",
   "message_id": "bad-message-id",
   "message": {
     "text": "This is a bad message… pogchamp",
     "fragments": [
       {
         "type": "text",
         "text": "This is a bad message… ",
         "cheermote": null,
         "emote": null
       },
       {
         "type": "cheermote",
         "text": "pogchamp",
         "cheermote": {
           "prefix": "pogchamp",
           "bits": 1000,
           "tier": 1
         },
         "emote": null
       }
     ]
   },
   "reason": "automod",
   "automod": {
     "category": "aggressive",
     "level": 1,
     "boundaries": [
       {
         "start_pos": 0,
         "end_pos": 10
       },
       {
         "start_pos": 20,
         "end_pos": 30
       }
     ]
   },
   "blocked_term": null,
   "held_at": "2022-12-02T15:00:00.00Z"
 }
}
```

## AutoMod Message Update {#automod-message-update}

The `automod.message.update` subscription type sends notification when a message in the AutoMod queue has its status changed.

### Subscription

- Type: `automod.message.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod** scope. The User ID associated with the token must match the *moderator_user_id* in the event's condition.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `automod.message.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the broadcaster (channel). Maximum:1.
  - `condition.moderator_user_id` — String, **Required**. User ID of the moderator.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the broadcaster (channel). Maximum:1.
    - `subscription.condition.moderator_user_id` — String. User ID of the moderator.
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
  - `event.user_id` — String. The message sender's user ID.
  - `event.user_login` — String. The message sender's login name.
  - `event.user_name` — String. The message sender's display name.
  - `event.moderator_user_id` — String. The ID of the moderator.
  - `event.moderator_user_name` — String. TThe moderator's user name.
  - `event.moderator_user_login` — String. The login of the moderator.
  - `event.message_id` — String. The ID of the message that was flagged by automod.
  - `event.message` — Object. The body of the message.
    - `event.message.text` — String. The contents of the message caught by automod.
    - `event.message.fragments` — Object[]. Metadata surrounding the potential inappropriate fragments of the message.
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
  - `event.category` — String. The category of the message.
  - `event.level` — Integer. The level of severity. Measured between 1 to 4.
  - `event.status` — String. The message's status.
    Possible values:
    - `Approved`
    - `Denied`
    - `Expired`
  - `event.held_at` — String. The timestamp of when automod saved the message.

### Subscription Request Body Example (Webhook)

```json
{
    "type": "automod.message.update",
    "version": "1",
    "condition": {
        "broadcaster_user_id": "1337",
        "moderator_user_id": "9001"
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
    "type": "automod.message.update",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "moderator_user_id": "9001"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2023-04-11T10:11:12.123Z"
  },
  "event": {
    "broadcaster_user_id": "1337",
    "broadcaster_user_name": "blah",
    "broadcaster_user_login": "blahblah",
    "user_id": "456789012",
    "user_name": "baduser",
    "user_login": "baduserbla",
    "moderator_user_id": "9001",
    "moderator_user_login": "the_mod",
    "moderator_user_name": "The_Mod",
    "message_id": "bad-message-id",
    "message": {
      "text": "This is a bad message badtextemote1 cheer100",
      "fragments": [
        {
          "text": "This is a bad message ",
          "emote": null,
          "cheermote": null
        },
        {
          "text": "badtextemote1",
          "emote": {
            "id": "emote-123",
            "emote_set_id": "set-emote-1"
          },
          "cheermote": null
        },
        {
          "text": " ",
          "emote": null,
          "cheermote": null
        },
        {
          "text": "cheer100",
          "emote": null,
          "cheermote": {
            "prefix": "cheer",
            "bits": 100,
            "tier": 1
          }
        }
      ]
    },
    "category": "aggressive",
    "level": 4,
    "status": "approved",
    "held_at": "2022-12-02T15:00:00.00Z"
  }
}
```

## AutoMod Message Update V2 {#automod-message-update-v2}

The `automod.message.update` subscription type sends notification when a message in the AutoMod queue has its status changed. Only public blocked terms trigger notifications, not private ones.

### Subscription

- Type: `automod.message.update`
- Version: `2`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod** scope. The User ID associated with the token must match the *moderator_user_id* in the event's condition.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `automod.message.update`.
- `version` — String, **Required**. The subscription type version: `2`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the broadcaster (channel). Maximum:1.
  - `condition.moderator_user_id` — String, **Required**. User ID of the moderator.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the broadcaster (channel). Maximum:1.
    - `subscription.condition.moderator_user_id` — String. User ID of the moderator.
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
  - `event.user_id` — String. The message sender's user ID.
  - `event.user_login` — String. The message sender's login name.
  - `event.user_name` — String. The message sender's display name.
  - `event.moderator_user_id` — String. The ID of the moderator.
  - `event.moderator_user_name` — String. TThe moderator's user name.
  - `event.moderator_user_login` — String. The login of the moderator.
  - `event.message_id` — String. The ID of the message that was flagged by automod.
  - `event.message` — Object. The body of the message.
    - `event.message.text` — String. The contents of the message caught by automod.
    - `event.message.fragments` — Object[]. Metadata surrounding the potential inappropriate fragments of the message.
      - `event.message.fragments.text` — String. Message text in a fragment.
      - `event.message.fragments.type` — String
        Possible values:
        - `text`
        - `emote`
        - `cheermote`
      - `event.message.fragments.emote` — Object, Nullable. Metadata pertaining to the emote.
        - `event.message.fragments.emote.id` — String. An ID that uniquely identifies this emote.
        - `event.message.fragments.emote.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
      - `event.message.fragments.cheermote` — Object, Nullable. Metadata pertaining to the cheermote.
        - `event.message.fragments.cheermote.prefix` — String
          The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.

          **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        - `event.message.fragments.cheermote.bits` — Integer. The amount of Bits cheered.
        - `event.message.fragments.cheermote.tier` — Integer. The tier level of the cheermote.
  - `event.status` — String. The message's status.
    Possible values:
    - `Approved`
    - `Denied`
    - `Expired`
  - `event.held_at` — String. The timestamp of when automod saved the message.
  - `event.reason` — String. The reason why the message was caught.
    Possible values:
    - `automod`
    - `blocked_term`
    - `blocked_link`
  - `event.automod` — Object, Nullable. If the message was caught by automod, this will be populated.
    - `event.automod.category` — String. The category of the caught message.
    - `event.automod.level` — Integer. The level of severity (1-4).
    - `event.automod.boundaries` — Object[]. The bounds of the text that caused the message to be caught.
      - `event.automod.boundaries.start_pos` — Integer. Index in the message for the start of the problem (Starting at 0).
      - `event.automod.boundaries.end_pos` — Integer. Index in the message for the end of the problem (Starting at 0).
  - `event.blocked_term` — Object, Nullable. If the message was caught due to a blocked term or a blocked link, this will be populated.
    - `event.blocked_term.terms_found` — Object[]. The list of blocked terms found in the message.
      - `event.blocked_term.terms_found.term_id` — String. The id of the blocked term found.
      - `event.blocked_term.terms_found.boundary` — Object. The bounds of the text that caused the message to be caught.
        - `event.blocked_term.terms_found.boundary.start_pos` — Integer. Index in the message for the start of the problem (0 indexed, inclusive).
        - `event.blocked_term.terms_found.boundary.end_pos` — Integer. Index in the message for the end of the problem (0 indexed, inclusive).
      - `event.blocked_term.terms_found.owner_broadcaster_user_id` — String. The id of the broadcaster that owns the blocked term.
      - `event.blocked_term.terms_found.owner_broadcaster_user_login` — String. The login of the broadcaster that owns the blocked term.
      - `event.blocked_term.terms_found.owner_broadcaster_user_name` — String. The username of the broadcaster that owns the blocked term.

### Subscription Request Body Example (Webhook)

```json
{
    "type": "automod.message.update",
    "version": "2",
    "condition": {
        "broadcaster_user_id": "1337",
        "moderator_user_id": "9001"
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
   "type": "automod.message.hold",
   "version": "2",
   "status": "enabled",
   "cost": 0,
   "condition": {
     "broadcaster_user_id": "1337",
     "moderator_user_id": "9001"
   },
   "transport": {
     "method": "webhook",
     "callback": "https://example.com/webhooks/callback"
   },
   "created_at": "2023-04-11T10:11:12.123Z"
 },
 "event": {
   "broadcaster_user_id": "1337",
   "broadcaster_user_login": "blah",
   "broadcaster_user_name": "blahblah",
   "moderator_user_id": "9001",
   "moderator_user_login": "the_mod",
   "moderator_user_name": "The_Mod",
   "user_id": "4242",
   "user_login": "baduser",
   "user_name": "badbaduser",
   "message_id": "bad-message-id",
   "message": {
     "text": "This is a bad message… pogchamp",
     "fragments": [
       {
         "type": "text",
         "text": "This is a bad message… ",
         "cheermote": null,
         "emote": null
       },
       {
         "type": "cheermote",
         "text": "pogchamp",
         "cheermote": {
           "prefix": "pogchamp",
           "bits": 1000,
           "tier": 1
         },
         "emote": null
       }
     ]
   },
   "reason": "automod",
   "automod": null,
   "blocked_term": {
     "terms_found": [
       {
         "term_id": "123",
         "owner_broadcaster_user_id": "1337",
         "owner_broadcaster_user_login": "blah",
         "owner_broadcaster_user_name": "blahblah",
         "boundary": {
           "start_pos": 0,
           "end_pos": 30
         }
       }
     ]
   },
   "status": "approved",
   "held_at": "2022-12-02T15:00:00.00Z"
 }
}
```

## AutoMod Settings Update {#automod-settings-update}

The `automod.settings.update` subscription type sends a notification when a broadcaster's AutoMod settings are updated.

### Subscription

- Type: `automod.settings.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod_settings** scope. The User ID associated with the token must match the *moderator_user_id* in the event's condition.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod_settings** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `automod.settings.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the broadcaster (channel). Maximum:1.
  - `condition.moderator_user_id` — String, **Required**. User ID of the moderator.
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the broadcaster (channel). Maximum:1.
    - `subscription.condition.moderator_user_id` — String. User ID of the moderator.
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
  - `event.moderator_user_id` — String. The ID of the moderator who changed the channel settings.
  - `event.moderator_user_login` — String. The moderator's login.
  - `event.moderator_user_name` — String. The moderator's user name.
  - `event.bullying` — Integer. The Automod level for hostility involving name calling or insults.
  - `event.overall_level` — Integer, Nullable. The default AutoMod level for the broadcaster. This field is null if the broadcaster has set one or more of the individual settings.
  - `event.disability` — Integer. The Automod level for discrimination against disability.
  - `event.race_ethnicity_or_religion` — Integer. The Automod level for racial discrimination.
  - `event.misogyny` — Integer. The Automod level for discrimination against women.
  - `event.sexuality_sex_or_gender` — Integer. The AutoMod level for discrimination based on sexuality, sex, or gender.
  - `event.aggression` — Integer. The Automod level for hostility involving aggression.
  - `event.sex_based_terms` — Integer. The Automod level for sexual content.
  - `event.swearing` — Integer. The Automod level for profanity.

### Subscription Request Body Example (Webhook)

```json
{
    "type": "automod.settings.update",
    "version": "1",
    "condition": {
        "broadcaster_user_id": "1337",
        "moderator_user_id": "9001"
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
    "type": "automod.settings.update",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "moderator_user_id": "9001"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2023-04-11T10:11:12.123Z"
  },
  "event": {
    "broadcaster_user_id": "1337",
    "broadcaster_user_login": "cooluser",
    "broadcaster_user_name": "CoolUser",
    "moderator_user_id": "9001",
    "moderator_user_login": "coolmod",
    "moderator_user_name": "CoolMod",
    "bullying": 3,
    "overall_level": null,
    "disability": 3,
    "race_ethnicity_or_religion": 3,
    "misogyny": 3,
    "sexuality_sex_or_gender": 3,
    "aggression": 3,
    "sex_based_terms": 3,
    "swearing": 0
  }
}
```

## AutoMod Terms Update {#automod-terms-update}

The `automod.terms.update` subscription type sends a notification when a broadcaster's AutoMod terms are updated. Changes to private terms are not sent.

### Subscription

- Type: `automod.terms.update`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod** scope. The User ID associated with the token must match the *moderator_user_id* in the event's condition.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod** scope for the user represented by the *moderator_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `automod.terms.update`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. User ID of the broadcaster (channel). Maximum:1.
  - `condition.moderator_user_id` — String, **Required**. User ID of the moderator creating the subscription. Maximum:1
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
    - `subscription.condition.broadcaster_user_id` — String. User ID of the broadcaster (channel). Maximum:1.
    - `subscription.condition.moderator_user_id` — String. User ID of the moderator creating the subscription. Maximum:1
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
  - `event.moderator_user_id` — String. The ID of the moderator who changed the channel settings.
  - `event.moderator_user_login` — String. The moderator's login.
  - `event.moderator_user_name` — String. The moderator's user name.
  - `event.action` — String. The status change applied to the terms.
    Possible values:
    - `add_permitted`
    - `remove_permitted`
    - `add_blocked`
    - `remove_blocked`
  - `event.from_automod` — Boolean. Indicates whether this term was added due to an Automod message approve/deny action.
  - `event.terms` — String[]. The list of terms that had a status change.

### Subscription Request Body Example (Webhook)

```json
{
    "type": "automod.terms.update",
    "version": "1",
    "condition": {
        "broadcaster_user_id": "1337",
        "moderator_user_id": "9001"
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
    "type": "automod.terms.update",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "1337",
      "moderator_user_id": "9001"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2023-04-11T10:11:12.123Z"
  },
  "event": {
    "broadcaster_user_id": "1337",
    "broadcaster_user_name": "blah",
    "broadcaster_user_login": "blahblah",
    "moderator_user_id": "9001",
    "moderator_user_login": "the_mod",
    "moderator_user_name": "The_Mod",
    "action": "bad-message-id",
    "from_automod": true,
    "terms": ["automodterm1", "automodterm2", "automodterm3"]
  }
}
```
