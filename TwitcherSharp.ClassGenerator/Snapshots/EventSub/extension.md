# Extension

Events raised when a viewer completes a Bits transaction in an extension.

Source: https://dev.twitch.tv/docs/eventsub/reference/extension/

## Extension Bits Transaction Create {#extension-bits-transaction-create}

The `extension.bits_transaction.create` subscription type sends a notification when a new transaction is created for a Twitch Extension.

> **Note** This subscription type is only supported by Webhooks and Conduits, and cannot be used with WebSockets.

### Subscription

- Type: `extension.bits_transaction.create`
- Version: `1`
- Transports: Webhook, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The OAuth token Client ID must match the Extension Client ID.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `extension.bits_transaction.create`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the Extension client ID you want to receive Bits transaction notifications for.
  - `condition.extension_client_id` — String, **Required**. The client ID of the extension.
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
    - `subscription.condition.extension_client_id` — String. The client ID of the extension.
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
  - `event.extension_client_id` — String. Client ID of the extension.
  - `event.id` — String. Transaction ID.
  - `event.broadcaster_user_id` — String. The transaction's broadcaster ID.
  - `event.broadcaster_user_login` — String. The transaction's broadcaster login.
  - `event.broadcaster_user_name` — String. The transaction's broadcaster display name.
  - `event.user_id` — String. The transaction's user ID.
  - `event.user_login` — String. The transaction's user login.
  - `event.user_name` — String. The transaction's user display name.
  - `event.product` — Object. Additional extension product information.
    - `event.product.name` — String. Product name.
    - `event.product.bits` — Integer. Bits involved in the transaction.
    - `event.product.sku` — String. Unique identifier for the product acquired.
    - `event.product.in_development` — Boolean. Flag indicating if the product is in development. If `in_development` is true, `bits` will be 0.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "extension.bits_transaction.create",
  "version": "1",
  "condition": {
    "extension_client_id": "deadbeef"
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
        "type": "extension.bits_transaction.create",
        "version": "1",
        "status": "enabled",
        "cost": 0,
        "condition": {
            "extension_client_id": "deadbeef"
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "event": {
        "id": "bits-tx-id",
        "extension_client_id": "deadbeef",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "user_name": "Coolest_User",
        "user_login": "coolest_user",
        "user_id": "1236",
        "product": {
            "name": "great_product",
            "sku": "skuskusku",
            "bits": 1234,
            "in_development": false
        }
    }
}
```
