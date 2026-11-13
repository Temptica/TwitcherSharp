# Conduit

Events raised when a conduit's shards change state.

Source: https://dev.twitch.tv/docs/eventsub/reference/conduit/

## Conduit Shard Disabled {#conduit-shard-disabled}

The `conduit.shard.disabled` subscription type sends a notification when EventSub disables a shard due to the status of the underlying transport changing.

### Subscription

- Type: `conduit.shard.disabled`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The Client ID of the token used must match the Client ID in the condition. If *conduit_id* is specified, the client must be the owner of the conduit.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `conduit.shard.disabled`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Optionally pass in the conduit ID for the conduit you want to receive events for.
  - `condition.client_id` — String, **Required**. Your application's client id. The provided client_id must match the client ID in the application access token.
  - `condition.conduit_id` — String. The conduit ID to receive events for. If omitted, events for all of this client's conduits are sent.
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
    - `subscription.condition.client_id` — String. Your application's client id. The provided client_id must match the client ID in the application access token.
    - `subscription.condition.conduit_id` — String. The conduit ID to receive events for. If omitted, events for all of this client's conduits are sent.
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
  - `event.conduit_id` — String. The ID of the conduit.
  - `event.shard_id` — String. The ID of the disabled shard.
  - `event.status` — String. The new status of the transport.
  - `event.transport` — Object. The disabled transport.
    - `event.transport.method` — String. **websocket** or **webhook**
    - `event.transport.callback` — String, Nullable. Webhook callback URL. Null if `method` is set to **websocket**.
    - `event.transport.session_id` — String, Nullable. WebSocket session ID. Null if `method` is set to **webhook**.
    - `event.transport.connected_at` — String, Nullable. Time that the WebSocket session connected. Null if `method` is set to **webhook**.
    - `event.transport.disconnected_at` — String, Nullable. Time that the WebSocket session disconnected. Null if `method` is set to **webhook**.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "conduit.shard.disabled",
  "version": "1",
  "condition": {
    "client_id": "uo6dggojyb8d6soh92zknwmi5ej1q2"
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
        "type": "conduit.shard.disabled",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "client_id": "uo6dggojyb8d6soh92zknwmi5ej1q2"
        },
        "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2023-04-11T10:11:12.123Z"
    },
    "event": {
        "conduit_id": "bfcfc993-26b1-b876-44d9-afe75a379dac",
        "shard_id": "4",
        "status": "websocket_disconnected",
        "transport": {
            "method": "websocket",
            "session_id": "ad1c9fc3-0d99-4eb7-8a04-8608e8ff9ec9",
            "connected_at": "2020-11-10T14:32:18.730260295Z",
            "disconnected_at": "2020-11-11T14:32:18.730260295Z"
        }
    }
}
```
