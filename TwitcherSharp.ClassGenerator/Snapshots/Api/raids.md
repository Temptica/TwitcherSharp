# Raids

Start and stop raids on a Twitch channel.

Source: https://dev.twitch.tv/docs/api/reference/raids/

## Contents {#contents}

2 entries on this page:

- [Start a raid](#start-a-raid)
- [Cancel a raid](#cancel-a-raid)

## Start a raid {#start-a-raid}

Raid another channel by sending the broadcaster's viewers to the targeted channel.

When you call the API from a chat bot or extension, the Twitch UX pops up a window at the top of
the chat room that identifies the number of viewers in the raid. The raid occurs when the
broadcaster clicks **Raid Now** or after the 90-second countdown expires.

To determine whether the raid successfully occurred, you must subscribe to the [Channel
Raid](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-raid) event. For more information, see [Get
notified when a raid begins](https://dev.twitch.tv/docs/api/raids.md#get-notified-when-a-raid-begins).

To cancel a pending raid, use the [Cancel a raid](#cancel-a-raid) endpoint.

**Rate Limit**: The limit is 10 requests within a 10-minute window.

### Endpoint

`POST https://api.twitch.tv/helix/raids`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:raids** scope.

### Query Parameters

- `from_broadcaster_id` — String, **Required**. The ID of the broadcaster that's sending the raiding party. This ID must match the user ID in the user access token.
- `to_broadcaster_id` — String, **Required**. The ID of the broadcaster to raid.

### Response Body

- `data` — Object[]. A list that contains a single object with information about the pending raid.
  - `data.created_at` — String. The UTC date and time, in RFC3339 format, of when the raid was requested.
  - `data.is_mature` — Boolean. **IMPORTANT** This field is deprecated and returns only **false**. A Boolean value that indicates whether the channel being raided contains mature content.

### Response Codes

- **200 OK** — Successfully requested to start a raid. To determine whether the raid successfully occurred (that is, the broadcaster clicked **Raid Now** or the countdown expired), you must subscribe to the [Channel Raid](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-raid) event.
- **400 Bad Request**
  - The raiding broadcaster is blocked from the targeted channel.
  - The targeted channel doesn't accept raids from this broadcaster.
  - There are too many viewers in the raiding party.
  - The IDs in *from_broadcaster_id* and *to_broadcaster_id* cannot be the same ID.
  - The ID in the *from_broadcaster_id* query parameter is not valid.
  - The ID in the *to_broadcaster_id* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *from_broadcaster_id* must match the user ID found in the request's OAuth token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:raids** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The targeted channel was not found.
- **409 Conflict**
  - The broadcaster is already in the process of raiding another channel.
- **429 Too Many Requests**
  - The broadcaster exceeded the number of raid requests that they may make. The limit is 10 requests within a 10-minute window.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/raids?from_broadcaster_id=12345678&to_broadcaster_id=87654321' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "created_at": "2022-02-18T07:20:50Z",
      "is_mature": false
    }
  ]
}
```

## Cancel a raid {#cancel-a-raid}

Cancel a pending raid.

You can cancel a raid at any point up until the broadcaster clicks **Raid Now** in the Twitch UX
or the 90-second countdown expires.

**Rate Limit**: The limit is 10 requests within a 10-minute window.

### Endpoint

`DELETE https://api.twitch.tv/helix/raids`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:raids** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that initiated the raid. This ID must match the user ID in the user access token.

### Response Codes

- **204 No Content** — The pending raid was successfully canceled.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID found in the request's OAuth token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:raids** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The broadcaster doesn't have a pending raid to cancel.
- **429 Too Many Requests**
  - The broadcaster exceeded the number of raid requests that they may make. The limit is 10 requests within a 10-minute window.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/raids?broadcaster_id=12345678' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```
