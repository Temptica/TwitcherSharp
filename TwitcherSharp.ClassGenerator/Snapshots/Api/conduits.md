# Conduits

Create and manage conduits and their shards for sending EventSub notifications.

Source: https://dev.twitch.tv/docs/api/reference/conduits/

## Contents {#contents}

6 entries on this page:

- [Get Conduits](#get-conduits)
- [Create Conduits](#create-conduits)
- [Update Conduits](#update-conduits)
- [Delete Conduit](#delete-conduit)
- [Get Conduit Shards](#get-conduit-shards)
- [Update Conduit Shards](#update-conduit-shards)

## Get Conduits {#get-conduits}

Gets the [conduits](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md) for a client ID.

### Endpoint

`GET https://api.twitch.tv/helix/eventsub/conduits`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Response Body

- `data` — Object[]. List of information about the client's conduits.
  - `data.id` — String. Conduit ID.
  - `data.shard_count` — Integer. Number of shards associated with this conduit.

### Response Codes

- **200 OK** — Successfully retrieved conduits.
- **401 Unauthenticated** — Authorization header required with an app access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/eventsub/conduits' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "26b1c993-bfcf-44d9-b876-379dacafe75a",
      "shard_count": 15
    },
    {
      "id": "bfcfc993-26b1-b876-44d9-afe75a379dac",
      "shard_count": 5
    }
  ]
}
```

## Create Conduits {#create-conduits}

Creates a new [conduit](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md).

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/conduits`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Request Body

- `shard_count` — Integer, **Required**. The number of shards to create for this conduit. The minimum is 1 and the maximum is 20,000.

### Response Body

- `data` — Object[]. A list that contains the conduit that you created.
  - `data.id` — String. Conduit ID.
  - `data.shard_count` — Integer. Number of shards created for this conduit.

### Response Codes

- **200 OK** — Conduit created.
- **400 Bad Request**
  - The *shard_count* field is required.
  - The value in *shard_count* must be from 1 through 20,000.
- **401 Unauthenticated** — Authorization header required with an app access token.
- **429 Too Many Requests** — The client ID in the access token already has the maximum of 5 conduits.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/eventsub/conduits' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"shard_count":5}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "bfcfc993-26b1-b876-44d9-afe75a379dac",
      "shard_count": 5
    }
  ]
}
```

## Update Conduits {#update-conduits}

Updates a [conduit's](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md) shard count. To delete shards, update
the count to a lower number, and the shards above the count will be deleted. For example, if the
existing shard count is 100, by resetting shard count to 50, shards 50-99 are deleted.

### Endpoint

`PATCH https://api.twitch.tv/helix/eventsub/conduits`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Request Body

- `id` — String, **Required**. Conduit ID.
- `shard_count` — Integer, **Required**. The new number of shards for this conduit. The minimum is 1 and the maximum is 20,000.

### Response Body

- `data` — Object[]. A list that contains the updated conduit.
  - `data.id` — String. Conduit ID.
  - `data.shard_count` — Integer. Number of shards associated with this conduit after the update.

### Response Codes

- **200 OK** — Conduit updated.
- **400 Bad Request**
  - The *id* field is required.
  - The *shard_count* field is required.
  - The value in *shard_count* must be from 1 through 20,000.
- **401 Unauthenticated** — Authorization header required with an app access token.
- **404 Not Found**
  - Conduit not found.
  - Conduit's owner must match the client ID in the access token.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/eventsub/conduits' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"id":"bfcfc993-26b1-b876-44d9-afe75a379dac","shard_count":5}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "bfcfc993-26b1-b876-44d9-afe75a379dac",
      "shard_count": 5
    }
  ]
}
```

## Delete Conduit {#delete-conduit}

Deletes a specified [conduit](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md). Note
that it may take some time for Eventsub subscriptions on a deleted
[conduit](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md) to show as disabled when calling [Get Eventsub
Subscriptions](https://dev.twitch.tv/docs/api/reference/eventsub.md#get-eventsub-subscriptions).

### Endpoint

`DELETE https://api.twitch.tv/helix/eventsub/conduits`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `id` — String, **Required**. Conduit ID.

### Response Codes

- **204 No Content** — Successfully deleted the conduit.
- **400 Bad Request** — The id query parameter is required.
- **401 Unauthenticated** — Authorization header required with an app access token.
- **404 Not Found**
  - Conduit not found.
  - Conduit's owner must match the client ID in the access token.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/eventsub/conduits?id=bfcfc993-26b1-b876-44d9-afe75a379dac' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Conduit Shards {#get-conduit-shards}

Gets a list of shards for a [conduit](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md). The list includes only
shards that you've assigned a transport to using [Update Conduit
Shards](https://dev.twitch.tv/docs/api/reference/conduits.md#update-conduit-shards), so it's empty for a new conduit.

### Endpoint

`GET https://api.twitch.tv/helix/eventsub/conduits/shards`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `conduit_id` — String, **Required**. Conduit ID.
- `status` — String. Status to filter by.
  Possible values:
  - `enabled`: The shard is enabled.
  - `webhook_callback_verification_pending`: The shard is pending verification of the specified callback URL.
  - `webhook_callback_verification_failed`: The specified callback URL failed verification.
  - `notification_failures_exceeded`: The notification delivery failure rate was too high.
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
- `after` — String. The cursor used to get the next page of results. The pagination object in the response contains the cursor's value.

### Response Body

- `data` — Object[]. List of information about a conduit's shards.
  - `data.id` — String. Shard ID.
  - `data.status` — String. The shard status. The subscriber receives events only for enabled shards.
    Possible values:
    - `enabled`: The shard is enabled.
    - `webhook_callback_verification_pending`: The shard is pending verification of the specified callback URL.
    - `webhook_callback_verification_failed`: The specified callback URL failed verification.
    - `notification_failures_exceeded`: The notification delivery failure rate was too high.
    - `websocket_disconnected`: The client closed the connection.
    - `websocket_failed_ping_pong`: The client failed to respond to a ping message.
    - `websocket_received_inbound_traffic`: The client sent a non-pong message. Clients may only send pong messages (and only in response to a ping message).
    - `websocket_connection_unused`: The client failed to subscribe to events within the required time.
    - `websocket_internal_error`: The Twitch WebSocket server experienced an unexpected error.
    - `websocket_network_timeout`: The Twitch WebSocket server timed out writing the message to the client.
    - `websocket_network_error`: The Twitch WebSocket server experienced a network error writing the message to the client.
    - `websocket_failed_to_reconnect`: The client failed to reconnect to the Twitch WebSocket server within the required time after a Reconnect Message.
  - `data.transport` — Object. The transport details used to send the notifications.
    - `data.transport.method` — String. The transport method.
      Possible values:
      - `webhook`
      - `websocket`
    - `data.transport.callback` — String. The callback URL where the notifications are sent. Included only if method is set to webhook.
    - `data.transport.session_id` — String. An ID that identifies the WebSocket that notifications are sent to. Included only if method is set to websocket.
    - `data.transport.connected_at` — String. The UTC date and time that the WebSocket connection was established. Included only if method is set to websocket.
    - `data.transport.disconnected_at` — String. The UTC date and time that the WebSocket connection was lost. Included only if method is set to websocket.
- `pagination` — Object. Contains information used to page through a list of results. The object is empty if there are no more pages left to page through.
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's after query parameter.

### Response Codes

- **200 OK** — Successfully retrieved shards.
- **400 Bad Request**
  - The *conduit_id* query parameter is required.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthenticated** — Authorization header required with an app access token.
- **404 Not Found**
  - Conduit not found.
  - Conduit's owner must match the client ID in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/eventsub/conduits/shards?conduit_id=bfcfc993-26b1-b876-44d9-afe75a379dac' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "0",
      "status": "enabled",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback.com"
      }
    },
    {
      "id": "1",
      "status": "webhook_callback_verification_pending",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback-2.com"
      }
    },
    {
      "id": "2",
      "status": "enabled",
      "transport": {
        "method": "websocket",
        "session_id": "9fd5164a-a958-4c60-b7f4-6a7202506ca0",
        "connected_at": "2020-11-10T14:32:18Z"
      }
    },
    {
      "id": "3",
      "status": "enabled",
      "transport": {
        "method": "websocket",
        "session_id": "238b4b08-13f1-4b8f-8d31-56665a7a9d9f",
        "connected_at": "2020-11-10T14:32:18Z"
      }
    },
    {
      "id": "4",
      "status": "websocket_disconnected",
      "transport": {
        "method": "websocket",
        "session_id": "ad1c9fc3-0d99-4eb7-8a04-8608e8ff9ec9",
        "connected_at": "2020-11-10T14:32:18Z",
        "disconnected_at": "2020-11-11T14:32:18Z"
      }
    }
  ],
  "pagination": {}
}
```

## Update Conduit Shards {#update-conduit-shards}

Updates shard(s) for a [conduit](https://dev.twitch.tv/docs/eventsub/handling-conduit-events.md). You can update up to 100
shards in a single request.

> **Note** Shard IDs are indexed starting at 0, so a conduit with a `shard_count` of 5 will have shards with IDs 0 through 4.

### Endpoint

`PATCH https://api.twitch.tv/helix/eventsub/conduits/shards`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Request Body

- `conduit_id` — String, **Required**. Conduit ID.
- `shards` — Object[], **Required**. List of shards to update.
  - `shards.id` — String, **Required**. Shard ID.
  - `shards.transport` — Object, **Required**. The transport details that you want Twitch to use when sending you notifications.
    - `shards.transport.method` — String, **Required**. The transport method.
      Possible values:
      - `webhook`
      - `websocket`
    - `shards.transport.callback` — String. The callback URL where the notifications are sent. The URL must use the HTTPS protocol and port 443. See Processing an event. Specify this field only if method is set to webhook. **NOTE:** Redirects are not followed.
    - `shards.transport.secret` — String. The secret used to verify the signature. The secret must be an ASCII string that's a minimum of 10 characters long and a maximum of 100 characters long. For information about how the secret is used, see Verifying the event message. Specify this field only if method is set to webhook.
    - `shards.transport.session_id` — String. An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets, the server returns the ID in the Welcome message. Specify this field only if method is set to websocket.

### Response Body

- `data` — Object[]. List of successful shard updates.
  - `data.id` — String. Shard ID.
  - `data.status` — String. The shard status. The subscriber receives events only for enabled shards.
    Possible values:
    - `enabled`: The shard is enabled.
    - `webhook_callback_verification_pending`: The shard is pending verification of the specified callback URL.
    - `webhook_callback_verification_failed`: The specified callback URL failed verification.
    - `notification_failures_exceeded`: The notification delivery failure rate was too high.
    - `websocket_disconnected`: The client closed the connection.
    - `websocket_failed_ping_pong`: The client failed to respond to a ping message.
    - `websocket_received_inbound_traffic`: The client sent a non-pong message. Clients may only send pong messages (and only in
response to a ping message).
    - `websocket_internal_error`: The Twitch WebSocket server experienced an unexpected error.
    - `websocket_network_timeout`: The Twitch WebSocket server timed out writing the message to the client.
    - `websocket_network_error`: The Twitch WebSocket server experienced a network error writing the message to the
client.
    - `websocket_failed_to_reconnect`: The client failed to reconnect to the Twitch WebSocket server within the required
time after a Reconnect Message.
  - `data.transport` — Object. The transport details used to send the notifications.
    - `data.transport.method` — String. The transport method.
      Possible values:
      - `webhook`
      - `websocket`
    - `data.transport.callback` — String. The callback URL where the notifications are sent. Included only if method is set to webhook.
    - `data.transport.session_id` — String. An ID that identifies the WebSocket that notifications are sent to. Included only if method is set to websocket.
    - `data.transport.connected_at` — String. The UTC date and time that the WebSocket connection was established. Included only if method is set to websocket.
    - `data.transport.disconnected_at` — String. The UTC date and time that the WebSocket connection was lost. Included only if method is set to websocket.
- `errors` — Object[]. List of unsuccessful updates.
  - `errors.id` — String. Shard ID.
  - `errors.message` — String
    The error that occurred while updating the shard. Possible errors:

    - `invalid shard id, must be a number greater or equal to 0 and less than N` — The shard
    ID must be a number from 0 through N - 1, where N is the conduit's shard count.

    - `failed webhook transport validation: callback, must provide valid https callback with
    standard port in creation request` — The URL in the callback field must use the HTTPS
    protocol and port 443.

    - `failed webhook transport validation: secret, must be between 10 and 100 characters`

    - `failed websocket transport validation: session_id, websocket transport session does
    not exist or has already disconnected`

    - `Duplicate shards in request` — The request specifies the shard ID more than once.
    None of the entries for that shard are applied.

    - `Internal error` — An internal error occurred while updating the shard. Try again
    later.
  - `errors.code` — String. Error codes used to represent a specific error condition while attempting to update shards.
    Possible values:
    - `invalid_parameter`: The shard ID or transport isn't valid, or the request specifies the shard ID more
than once.
    - `internal_error`: An internal error occurred. Try again later.

### Response Codes

- **202 Accepted** — Successfully updated shards.
- **400 Bad Request**
  - The *conduit_id* field is required.
  - The *shards* field is required.
  - The *shards* field contains more than 100 shards.
  - The *shards* field contains more entries than the conduit's shard count.
  - The value specified in a shard's *method* field is not valid.
  - The *callback* field is required if you specify the webhook transport method.
  - The *session_id* field is required if you specify the websocket transport method.
  - Do not specify the *session_id* field if you specify the webhook transport method.
  - Do not specify the *callback* or *secret* fields if you specify the websocket transport method.
- **401 Unauthenticated** — Authorization header requires using an App Access Token for this request.
- **404 Not Found**
  - The specified *conduit_id* does not exist.
  - Conduit's owner must match the Client ID in the access token.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/eventsub/conduits/shards' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "0",
      "status": "webhook_callback_verification_pending",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback.com"
      }
    },
    {
      "id": "1",
      "status": "webhook_callback_verification_pending",
      "transport": {
        "method": "webhook",
        "callback": "https://this-is-a-callback-2.com"
      }
    }
  ],
  "errors": [
    {
      "id": "3",
      "message": "invalid shard id, must be a number greater or equal to 0 and less than 3",
      "code": "invalid_parameter"
    }
  ]
}
```
