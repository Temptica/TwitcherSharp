# Drop

Events raised when a Drop entitlement is granted.

Source: https://dev.twitch.tv/docs/eventsub/reference/drop/

## Drop Entitlement Grant {#drop-entitlement-grant}

The `drop.entitlement.grant` subscription type sends a notification when an entitlement for a Drop is granted to a user.

> **Note** This subscription type is only supported by Webhooks and Conduits, and cannot be used with WebSockets.

### Subscription

- Type: `drop.entitlement.grant`
- Version: `1`
- Transports: Webhook, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The Client ID associated with the access token must be owned by a user who is part of the specified organization.

### Subscription Request Body

- `type` — String, **Required**. The subscription type name: `drop.entitlement.grant`.
- `version` — String, **Required**. The subscription type version: `1`.
- `condition` — Object, **Required**. Subscription-specific parameters. Pass in the *organization_id* to subscribe to all drop entitlement grant notifications for that organization.
  - `condition.organization_id` — String, **Required**. The organization ID of the organization that owns the game on the developer portal.
  - `condition.category_id` — String. The category (or game) ID of the game for which entitlement notifications will be received.
  - `condition.campaign_id` — String. The campaign ID for a specific campaign for which entitlement notifications will be received.
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
- `is_batching_enabled` — Boolean, **Required**. Needs to be true for this subscription type.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.organization_id` — String. The organization ID of the organization that owns the game on the developer portal.
    - `subscription.condition.category_id` — String. The category (or game) ID of the game for which entitlement notifications will be received.
    - `subscription.condition.campaign_id` — String. The campaign ID for a specific campaign for which entitlement notifications will be received.
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
- `events` — Object[]. The entitlements granted in this notification. This type batches, so a notification carries one or more.
  - `events.id` — String. Individual event ID, as assigned by EventSub. Use this for de-duplicating messages.
  - `events.data` — Object. The granted entitlement.
    - `events.data.organization_id` — String. The ID of the organization that owns the game that has Drops enabled.
    - `events.data.category_id` — String. Twitch category ID of the game that was being played when this benefit was entitled.
    - `events.data.category_name` — String. The category name.
    - `events.data.campaign_id` — String. The campaign this entitlement is associated with.
    - `events.data.user_id` — String. Twitch user ID of the user who was granted the entitlement.
    - `events.data.user_name` — String. The user display name of the user who was granted the entitlement.
    - `events.data.user_login` — String. The user login of the user who was granted the entitlement.
    - `events.data.entitlement_id` — String. Unique identifier of the entitlement. Use this to de-duplicate entitlements.
    - `events.data.benefit_id` — String. Identifier of the Benefit.
    - `events.data.created_at` — String. UTC timestamp in ISO format when this entitlement was granted on Twitch.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "drop.entitlement.grant",
  "version": "1",
  "condition": {
    "organization_id": "9001",
    "category_id": "9002",
    "campaign_id": "9003"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  },
  "is_batching_enabled": true
}
```

### Event Payload Example

```json
{
    "subscription": {
        "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
        "type": "drop.entitlement.grant",
        "version": "1",
        "status": "enabled",
        "condition": {
           "organization_id": "9001",
            "category_id": "9002",
            "campaign_id": "9003" 
        },
         "transport": {
            "method": "webhook",
            "callback": "https://example.com/webhooks/callback"
        },
        "created_at": "2019-11-16T10:11:12.634234626Z"
    },
    "events": [
        {
            "id": "bf7c8577-e3e3-4881-a78a-e9446641d45d",
            "data": {
                "organization_id": "9001",
                "category_id": "9002",
                "category_name": "Fortnite",
                "campaign_id": "9003",
                "user_id": "1234",
                "user_name": "Cool_User",
                "user_login": "cool_user",
                "entitlement_id": "fb78259e-fb81-4d1b-8333-34a06ffc24c0",
                "benefit_id": "74c52265-e214-48a6-91b9-23b6014e8041",
                "created_at": "2019-01-28T04:17:53.325Z"
            }
        },
        {
            "id": "bf7c8577-e3e3-4881-a78a-e9446641d45c",
            "data": {
                "organization_id": "9001",
                "category_id": "9002",
                "category_name": "Fortnite",
                "campaign_id": "9003",
                "user_id": "12345",
                "user_name": "Cooler_User",
                "user_login": "cooler_user",
                "entitlement_id": "fb78259e-fb81-4d1b-8333-34a06ffc24c0",
                "benefit_id": "74c52265-e214-48a6-91b9-23b6014e8041",
                "created_at": "2019-01-28T04:17:53.325Z"
            }
        }
    ]
}
```
