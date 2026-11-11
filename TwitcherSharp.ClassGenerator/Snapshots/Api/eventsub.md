# EventSub

Create, list, and delete EventSub subscriptions.

Source: https://dev.twitch.tv/docs/api/reference/eventsub/

## Contents {#contents}

3 entries on this page:

- [Get EventSub Subscriptions](#get-eventsub-subscriptions)
- [Create EventSub Subscription](#create-eventsub-subscription)
- [Delete EventSub Subscription](#delete-eventsub-subscription)

## Get EventSub Subscriptions {#get-eventsub-subscriptions}

Gets a list of EventSub subscriptions that the client in the access token created.

### Endpoint

`GET https://api.twitch.tv/helix/eventsub/subscriptions`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). Returns the subscriptions that use [webhooks](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md) or [conduits](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens). Returns the subscriptions that use [WebSockets](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md) and that the user created. The token may include any scopes.

### Query Parameters

- `status` — String. Filter subscriptions by its status.
  Possible values:
  - `enabled`: The subscription is enabled.
  - `webhook_callback_verification_pending`: The subscription is pending verification of the specified callback URL.
  - `webhook_callback_verification_failed`: The specified callback URL failed verification.
  - `notification_failures_exceeded`: The notification delivery failure rate was too high.
  - `authorization_revoked`: The authorization was revoked for one or more users specified in the Condition object.
  - `moderator_removed`: The moderator that authorized the subscription is no longer one of the broadcaster's
moderators.
  - `guest_star_moderator_removed`: The Guest Star moderator that authorized the subscription is no longer one of the
broadcaster's Guest Star moderators.
  - `user_removed`: One of the users specified in the Condition object was removed.
  - `chat_user_banned`: The user specified in the Condition object was banned from the broadcaster's chat.
  - `version_removed`: The subscription to subscription type and version is no longer supported.
  - `beta_maintenance`: The subscription to the beta subscription type was removed due to maintenance.
  - `websocket_disconnected`: The client closed the connection.
  - `websocket_failed_ping_pong`: The client failed to respond to a ping message.
  - `websocket_received_inbound_traffic`: The client sent a non-pong message. Clients may only send pong messages (and only in
response to a ping message).
  - `websocket_connection_unused`: The client failed to subscribe to events within the required time.
  - `websocket_internal_error`: The Twitch WebSocket server experienced an unexpected error.
  - `websocket_network_timeout`: The Twitch WebSocket server timed out writing the message to the client.
  - `websocket_network_error`: The Twitch WebSocket server experienced a network error writing the message to the
client.
  - `websocket_failed_to_reconnect`: The client failed to reconnect to the Twitch WebSocket server within the required time
after a Reconnect Message.
  - `conduit_deleted`: The conduit associated with the subscription was deleted.
- `type` — String. Filter subscriptions by subscription type. For a list of subscription types, see [Subscription Types](https://dev.twitch.tv/docs/eventsub/reference.md).
- `user_id` — String. Filter subscriptions by user ID. The response contains subscriptions where this ID matches a user ID that you specified in the **Condition** object when you [created the subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).
- `subscription_id` — String. Returns an array with the subscription matching the ID (as long as it is owned by the client making the request), or an empty array if there is no matching subscription.
- `conduit_id` — String. Filter subscriptions by [conduit](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md) ID.
- `after` — String. The cursor used to get the next page of results. The `pagination` object in the response contains the cursor's value.

### Response Body

- `data` — Object[]. The list of subscriptions. The list is ordered by the oldest subscription first. The list is empty if the client hasn't created subscriptions or there are no subscriptions that match the specified filter criteria.
  - `data.id` — String. An ID that identifies the subscription.
  - `data.status` — String. The subscription's status. The subscriber receives events only for **enabled** subscriptions.
    Possible values:
    - `enabled`: The subscription is enabled.
    - `webhook_callback_verification_pending`: The subscription is pending verification of the specified callback URL.
    - `webhook_callback_verification_failed`: The specified callback URL failed verification.
    - `notification_failures_exceeded`: The notification delivery failure rate was too high.
    - `authorization_revoked`: The authorization was revoked for one or more users specified in the Condition
object.
    - `moderator_removed`: The moderator that authorized the subscription is no longer one of the broadcaster's
moderators.
    - `guest_star_moderator_removed`: The Guest Star moderator that authorized the subscription is no longer one of the
broadcaster's Guest Star moderators.
    - `user_removed`: One of the users specified in the Condition object was removed.
    - `chat_user_banned`: The user specified in the Condition object was banned from the broadcaster's chat.
    - `version_removed`: The subscription to subscription type and version is no longer supported.
    - `beta_maintenance`: The subscription to the beta subscription type was removed due to maintenance.
    - `websocket_disconnected`: The client closed the connection.
    - `websocket_failed_ping_pong`: The client failed to respond to a ping message.
    - `websocket_received_inbound_traffic`: The client sent a non-pong message. Clients may only send pong messages (and only in
response to a ping message).
    - `websocket_connection_unused`: The client failed to subscribe to events within the required time.
    - `websocket_internal_error`: The Twitch WebSocket server experienced an unexpected error.
    - `websocket_network_timeout`: The Twitch WebSocket server timed out writing the message to the client.
    - `websocket_network_error`: The Twitch WebSocket server experienced a network error writing the message to the
client.
    - `websocket_failed_to_reconnect`: The client failed to reconnect to the Twitch WebSocket server within the required
time after a Reconnect Message.
    - `conduit_deleted`: The conduit associated with the subscription was deleted.
  - `data.type` — String. The subscription's type. See [Subscription Types](https://dev.twitch.tv/docs/eventsub/reference.md).
  - `data.version` — String. The version number that identifies this definition of the subscription's data.
  - `data.condition` — Object. The subscription's parameter values. This is a JSON object whose contents are determined by the subscription type.
  - `data.created_at` — String. The date and time (in RFC3339 format) of when the subscription was created.
  - `data.transport` — Object. The transport details used to send the notifications.
    - `data.transport.method` — String. The transport method.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `data.transport.callback` — String. The callback URL where the notifications are sent. Included only if `method` is set to **webhook**.
    - `data.transport.session_id` — String. An ID that identifies the WebSocket that notifications are sent to. Included only if `method` is set to **websocket**.
    - `data.transport.connected_at` — String. The UTC date and time that the WebSocket connection was established. Included only if `method` is set to **websocket**.
    - `data.transport.disconnected_at` — String. The UTC date and time that the WebSocket connection was lost. Included only if `method` is set to **websocket**.
    - `data.transport.conduit_id` — String. An ID that identifies the conduit that notifications are sent to. Included only if `method` is set to **conduit**.
  - `data.cost` — Integer. The amount that the subscription counts against your limit. [Learn More](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits)
  - `data.is_batching_enabled` — Boolean. Whether notifications are batched. Included only if **true**, which is the case for drop.entitlement.grant subscriptions.
- `total` — Integer. The total number of subscriptions that you've created. If you use a user access token, the count includes only the user's WebSocket subscriptions.
- `total_cost` — Integer. The sum of all of your subscription costs. [Learn More](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits)
- `max_total_cost` — Integer. The maximum total cost that you're allowed to incur for all subscriptions that you create. If you use a user access token, this is the WebSocket limit of 10.
- `pagination` — Object. An object that contains the cursor used to get the next page of subscriptions. The object is empty if there are no more pages to get. The number of subscriptions returned per page is undertermined.
  - `pagination.cursor` — String. The cursor value that you set the *after* query parameter to.

### Response Codes

- **200 OK** — Successfully retrieved the subscriptions.
- **400 Bad Request**
  - The request may specify only one filter query parameter. For example, either *type* or *status* or *user_id*.
  - The value in the *type* query parameter is not valid.
  - The value in the *status* query parameter is not valid.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token or an app access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/eventsub/subscriptions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "total": 2,
  "data": [
    {
      "id": "26b1c993-bfcf-44d9-b876-379dacafe75a",
      "status": "enabled",
      "type": "stream.online",
      "version": "1",
      "condition": {
        "broadcaster_user_id": "1234"
      },
      "created_at": "2020-11-10T20:08:33.12345678Z",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback.com"
      },
      "cost": 1
    },
    {
      "id": "35016908-41ff-33ce-7879-61b8dfc2ee16",
      "status": "webhook_callback_verification_pending",
      "type": "user.update",
      "version": "1",
      "condition": {
        "user_id": "1234"
      },
      "created_at": "2020-11-10T14:32:18.730260295Z",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback.com"
      },
      "cost": 0
    }
  ],
  "total_cost": 1,
  "max_total_cost": 10000,
  "pagination": {}
}
```

## Create EventSub Subscription {#create-eventsub-subscription}

Creates an EventSub subscription.

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). Required if you use [webhooks](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md) or [conduits](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md) to receive events. If the subscription type requires user authorization, the user must have granted your app (Client ID) permissions to receive those events before you subscribe to them. For example, to subscribe to [channel.subscribe](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-subscribe) events, your app must get a user access token that includes the **channel:read:subscriptions** scope, which adds the required permission to your App Access Token's Client ID.
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens). Required if you use [WebSockets](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md) to receive events. If the subscription type requires user authorization, the token must include the required scope. However, if the subscription type doesn't include user authorization, the token may include any scopes or no scopes.

### Request Body

- `type` — String, **Required**. The type of subscription to create. For a list of subscriptions that you can create, see [Subscription Types](https://dev.twitch.tv/docs/eventsub/reference.md).
- `version` — String, **Required**. The version number that identifies the definition of the subscription type that you want the response to use.
- `condition` — Object, **Required**. A JSON object that contains the parameter values that are specific to the specified subscription type. For the object's required and optional fields, see the subscription type's documentation.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending you notifications.
  - `transport.method` — String, **Required**. The transport method.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where the notifications are sent. The URL must use the HTTPS protocol
    and port 443. See [Processing an event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).
    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String. The secret used to verify the signature. The secret must be an ASCII string that's a minimum of 10 characters long and a maximum of 100 characters long. For information about how the secret is used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message). Specify this field only if *method* is set to **webhook**.
  - `transport.session_id` — String. An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets, the server returns the ID in the Welcome message. Specify this field only if *method* is set to **websocket**.
  - `transport.conduit_id` — String. An ID that identifies the conduit to send notifications to. When you create a conduit, the server returns the conduit ID. Specify this field only if *method* is set to **conduit**.
- `is_batching_enabled` — Boolean. Whether notifications are batched, so that a single notification can contain multiple events. Must be **true** for [drop.entitlement.grant](https://dev.twitch.tv/docs/eventsub/reference/drop.md#drop-entitlement-grant) subscriptions, and **false** or omitted for all other subscription types.

### Response Body

- `data` — Object[]. A list that contains the single subscription that you created.
  - `data.id` — String. An ID that identifies the subscription.
  - `data.status` — String. The subscription's status. The subscriber receives events only for enabled subscriptions.
    Possible values:
    - `enabled`: The subscription is enabled.
    - `webhook_callback_verification_pending`: The subscription is pending verification of the specified callback URL (see
[Responding to a challenge
request](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#responding-to-a-challenge-request)).
  - `data.type` — String. The subscription's type. See [Subscription Types](https://dev.twitch.tv/docs/eventsub/reference.md).
  - `data.version` — String. The version number that identifies this definition of the subscription's data.
  - `data.condition` — Object. The subscription's parameter values. This is a object whose contents are determined by the subscription type.
  - `data.created_at` — String. The date and time (in RFC3339 format) of when the subscription was created.
  - `data.transport` — Object. The transport details used to send the notifications.
    - `data.transport.method` — String. The transport method.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `data.transport.callback` — String. The callback URL where the notifications are sent. Included only if `method` is set to **webhook**.
    - `data.transport.session_id` — String. An ID that identifies the WebSocket that notifications are sent to. Included only if `method` is set to **websocket**.
    - `data.transport.connected_at` — String. The UTC date and time that the WebSocket connection was established. Included only if `method` is set to **websocket**.
    - `data.transport.conduit_id` — String. An ID that identifies the conduit to send notifications to. Included only if `method` is set to **conduit**.
  - `data.cost` — Integer. The amount that the subscription counts against your limit. [Learn More](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits)
  - `data.is_batching_enabled` — Boolean. Whether notifications are batched. Included only if **true**, which is the case for drop.entitlement.grant subscriptions.
- `total` — Integer. The total number of subscriptions you've created.
- `total_cost` — Integer. The sum of all of your subscription costs. [Learn More](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits)
- `max_total_cost` — Integer. The maximum total cost that you're allowed to incur for all subscriptions you create.

### Response Codes

- **202 Accepted** — Successfully accepted the subscription request.
- **400 Bad Request**
  - The *condition* field is required.
  - The user specified in the *condition* object does not exist.
  - The *condition* object is missing one or more required fields.
  - The combination of values in the *version* and *type* fields is not valid.
  - The length of the string in the *secret* field is not valid.
  - The URL in the transport's *callback* field is not valid. The URL must use the HTTPS protocol and the 443 port number.
  - The value specified in the *method* field is not valid.
  - The *callback* field is required if you specify the webhook transport method.
  - The *session_id* field is required if you specify the WebSocket transport method.
  - The combination of subscription type and version is not valid.
  - The *conduit_id* field is required if you specify the Conduit transport method.
  - Do not specify the *session_id* field if you specify the webhook transport method.
  - Do not specify the *callback* or *secret* fields if you specify the WebSocket transport method.
  - Do not specify the *callback*, *secret*, or *session_id* fields if you specify the Conduit transport method.
  - The subscription type and version combination is deprecated.
  - The *is_batching_enabled* field must be **true** for drop.entitlement.grant subscriptions and **false** or omitted for all other subscription types.
  - The request must use an app access token if the transport method is webhook or conduit.
  - The request must use a user access token if the transport method is WebSocket.
  - The WebSocket session doesn't exist or has already disconnected.
  - The WebSocket session already has subscriptions that a different user created.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token or an app access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **403 Forbidden**
  - The user access token doesn't meet the subscription type's authorization requirements, such as the required scope.
  - If you use an app access token, the user specified in the *condition* object must have authorized your app with the scope that the subscription type requires.
- **404 Not Found**
  - The conduit specified in the *conduit_id* field was not found.
  - The conduit's owner must match the client ID in the access token.
- **409 Conflict** — A subscription with the same *type* and *condition* values and the same callback URL, WebSocket session, or conduit already exists and is enabled or pending verification. The `message` field in the error response contains the existing subscription's ID.
- **410 Gone** — Version 1 of the [channel.follow](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-follow) subscription type is no longer available. Use version 2.
- **429 Too Many Requests**
  - The request exceeds the limit of 3 enabled or pending subscriptions with the same combination of *type* and *condition* values.
  - The subscription would exceed your `max_total_cost` or the maximum number of subscriptions that you may create.
  - The subscription would exceed the maximum of 3 WebSocket connections with enabled subscriptions.
  - The WebSocket connection already has the maximum of 300 subscriptions.
  - The subscription would exceed the WebSocket `max_total_cost` of 10.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/eventsub/subscriptions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"type":"user.update","version":"1","condition":{"user_id":"1234"},"transport":{"method":"webhook","callback":"https://this-is-a-callback.com","secret":"s3cre7s3cre7"}}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "26b1c993-bfcf-44d9-b876-379dacafe75a",
      "status": "webhook_callback_verification_pending",
      "type": "user.update",
      "version": "1",
      "condition": {
        "user_id": "1234"
      },
      "created_at": "2020-11-10T14:32:18.730260295Z",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback.com"
      },
      "cost": 1
    }
  ],
  "total": 1,
  "total_cost": 1,
  "max_total_cost": 10000
}
```

## Delete EventSub Subscription {#delete-eventsub-subscription}

Deletes an EventSub subscription.

### Endpoint

`DELETE https://api.twitch.tv/helix/eventsub/subscriptions`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). Required to delete subscriptions that use [webhooks](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md) or [conduits](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens). Required to delete subscriptions that use [WebSockets](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md). The token must be for the user who created the subscription, and may include any scopes.

### Query Parameters

- `id` — String, **Required**. The ID of the subscription to delete.

### Response Codes

- **204 No Content** — Successfully deleted the subscription.
- **400 Bad Request**
  - The *id* query parameter is required.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token or an app access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **404 Not Found**
  - The subscription was not found.
  - The subscription was created with a different type of access token or by a different user.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/eventsub/subscriptions?id=26b1c993-bfcf-44d9-b876-379dacafe75a' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```
