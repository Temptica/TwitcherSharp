# Ads

Start, stop, and get information about ads on Twitch.

Source: https://dev.twitch.tv/docs/api/reference/ads/

## Contents {#contents}

3 entries on this page:

- [Get Ad Schedule](#get-ad-schedule)
- [Snooze Next Ad](#snooze-next-ad)
- [Start Commercial](#start-commercial)

## Get Ad Schedule {#get-ad-schedule}

Returns ad schedule related information, including snooze, when the last ad was run,
when the next ad is scheduled, and if the channel is currently in pre-roll free time.

> **Note** After an ad starts, a new ad cannot be run until the cooldown period ends. The cooldown is 8
> minutes by default and is never shorter than the ad.

### Endpoint

`GET https://api.twitch.tv/helix/channels/ads`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:ads** scope. The User ID associated with the token must match the _broadcaster\_id_ in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:ads** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. Provided _broadcaster\_id_ must match the `user_id` in the authentication token.

### Response Body

- `data` — Object[]. A list that contains information related to the channel's ad schedule.
  - `data.snooze_count` — Integer. The number of snoozes available for the broadcaster.
  - `data.snooze_refresh_at` — Integer. The time when the broadcaster will gain an additional snooze, as a Unix timestamp in seconds. Is 0 if the broadcaster already has the maximum number of snoozes.
  - `data.next_ad_at` — Integer. The time of the broadcaster's next scheduled ad, as a Unix timestamp in seconds. Is 0 if the channel has no ad scheduled or is not live.
  - `data.duration` — Integer. The length in seconds of the scheduled upcoming ad break.
  - `data.last_ad_at` — Integer. The time of the broadcaster's last ad-break, as a Unix timestamp in seconds. Is 0 if the channel has not run an ad or is not live.
  - `data.preroll_free_time` — Integer. The amount of pre-roll free time remaining for the channel in seconds. Returns 0 if they are currently not pre-roll free.

### Response Codes

- **200 OK** — Returns the ad schedule information for the channel.
- **400 Bad Request** — The broadcaster ID is not valid.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **channel:read:ads** scope.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:read:ads** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The ID in *broadcaster_id* was not found.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channels/ads?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "next_ad_at": 1690931298,
      "last_ad_at": 1690930398,
      "duration": 60,
      "preroll_free_time": 90,
      "snooze_count": 1,
      "snooze_refresh_at": 1690932198
    }
  ]
}
```

## Snooze Next Ad {#snooze-next-ad}

If available, pushes back the timestamp of the upcoming automatic mid-roll ad by 5 minutes. This
endpoint duplicates the snooze functionality in the creator dashboard's Ads Manager.

### Endpoint

`POST https://api.twitch.tv/helix/channels/ads/schedule/snooze`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:ads** scope. The user ID associated with the token must match the _broadcaster\_id_ in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:manage:ads** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. Provided _broadcaster\_id_ must match the `user_id` in the authentication token.

### Response Body

- `data` — Object[]. A list that contains information about the channel's snoozes and next upcoming ad after successfully snoozing.
  - `data.snooze_count` — Integer. The number of snoozes available for the broadcaster.
  - `data.snooze_refresh_at` — Integer. The time when the broadcaster will gain an additional snooze, as a Unix timestamp in seconds.
  - `data.next_ad_at` — Integer. The time of the broadcaster's next scheduled ad, as a Unix timestamp in seconds.

### Response Codes

- **200 OK** — User's next ad is successfully snoozed. Their _snooze_count_ is decremented and _snooze_refresh_at_ and _next_ad_at_ are both updated.
- **400 Bad Request**
  - The channel is not currently live.
  - The broadcaster ID is not valid.
  - Channel does not have an upcoming scheduled ad break.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **channel:manage:ads** scope.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:manage:ads** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The ID in *broadcaster_id* was not found.
- **429 Too Many Requests**
  - Channel has no snoozes left.
  - Another ad or snooze request for the channel is in progress. Try again shortly.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/channels/ads/schedule/snooze?broadcaster_id=123' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "snooze_count": 1,
      "snooze_refresh_at": 1690932198,
      "next_ad_at": 1690931298
    }
  ]
}
```

## Start Commercial {#start-commercial}

Starts a commercial on the specified channel.

> **Note** Only partners and affiliates may run commercials and they must be streaming live at the time.

> **Note** Only the broadcaster may start a commercial; the broadcaster's editors and moderators may not start commercials on behalf of the broadcaster.

### Endpoint

`POST https://api.twitch.tv/helix/channels/commercial`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:edit:commercial** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:edit:commercial** scope for the user represented by the *broadcaster_id* body field.

### Request Body

- `broadcaster_id` — String, **Required**. The ID of the partner or affiliate broadcaster that wants to run the commercial. This ID must match the user ID found in the OAuth token.
- `length` — Integer, **Required**. The length of the commercial to run, in seconds. Twitch tries to serve a commercial that's the requested length, but it may be shorter or longer. If you request a commercial that's longer than the channel's maximum ad break length, the API uses the maximum. For most channels, the maximum is 180 seconds.

### Response Body

- `data` — Object[]. An array that contains a single object with the status of your start commercial request.
  - `data.length` — Integer. The length of the commercial, in seconds. If you requested a commercial that's longer than the channel's maximum ad break length, this is the maximum length.
  - `data.message` — String. A message that indicates whether Twitch was able to serve an ad.
  - `data.retry_after` — Integer. The number of seconds you must wait before running another commercial.

### Response Codes

- **200 OK** — Successfully started the commercial.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *length* query parameter is required.
  - The ID in *broadcaster_id* is not valid.
  - To start a commercial, the broadcaster must be streaming live.
- **401 Unauthorized**
  - The ID in _broadcaster\_id_ must match the user ID found in the request's OAuth token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **channel:edit:commercial** scope.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:edit:commercial** scope.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **404 Not Found**
  - The ID in _broadcaster\_id_ was not found.
- **429 Too Many Requests**
  - The broadcaster may not run another commercial until the cooldown period expires. The `retry_after` field in the previous start commercial response specifies the amount of time the broadcaster must wait between running commercials.
  - Another ad or snooze request for the channel is in progress. Try again shortly.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/channels/commercial' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"broadcaster_id":"141981764","length":60}'
```

### Response Example

```json
{
  "data": [
    {
      "length": 60,
      "message": "Starting commercial break. Keep in mind you are still live and not all viewers will receive a commercial.",
      "retry_after": 480
    }
  ]
}
```
