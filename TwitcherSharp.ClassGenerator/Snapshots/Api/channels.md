# Channels

Get information and manage settings related to a user's Twitch channel.

Source: https://dev.twitch.tv/docs/api/reference/channels/

## Contents {#contents}

5 entries on this page:

- [Get Channel Information](#get-channel-information)
- [Modify Channel Information](#modify-channel-information)
- [Get Channel Editors](#get-channel-editors)
- [Get Followed Channels](#get-followed-channels)
- [Get Channel Followers](#get-channel-followers)

## Get Channel Information {#get-channel-information}

Gets information about one or more channels.

### Endpoint

`GET https://api.twitch.tv/helix/channels`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose channel you want to get. To specify more than one ID, include this parameter for each broadcaster you want to get. For example, 'broadcaster_id=1234&broadcaster_id=5678'. You may specify a maximum of 100 IDs. The API ignores duplicate IDs and IDs that are not found.

### Response Body

- `data` — Object[]. A list that contains information about the specified channels. The list is empty if the specified channels weren't found.
  - `data.broadcaster_id` — String. An ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_language` — String. The broadcaster's preferred language. The value is an ISO 639-1 two-letter language code (for example, *en* for English). The value is set to "other" if the language is not a Twitch supported language.
  - `data.game_name` — String. The name of the game that the broadcaster is playing or last played. The value is an empty string if the broadcaster has never played a game.
  - `data.game_id` — String. An ID that uniquely identifies the game that the broadcaster is playing or last played. The value is an empty string if the broadcaster has never played a game.
  - `data.title` — String. The title of the stream that the broadcaster is currently streaming or last streamed. The value is an empty string if the broadcaster has never streamed.
  - `data.delay` — Integer. The value of the broadcaster's stream delay setting, in seconds. This field's value defaults to zero unless 1) the request specifies a user access token, 2) the ID in the *broadcaster_id* query parameter matches the user ID in the access token, 3) the broadcaster has partner status and they set a non-zero stream delay value, and 4) the broadcaster's stream isn't disabled.
  - `data.tags` — String[]. The tags applied to the channel.
  - `data.content_classification_labels` — String[]. The CCLs applied to the channel.
  - `data.is_branded_content` — Boolean. Boolean flag indicating if the channel has branded content.

### Response Codes

- **200 OK** — Successfully retrieved the list of channels.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The broadcaster ID is not valid.
  - The number of *broadcaster_id* query parameters exceeds the maximum allowed.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **429 Too Many Requests**
  - The application exceeded the number of calls it may make per minute. For details, see [Rate Limits](https://dev.twitch.tv/docs/api/guide.md#twitch-rate-limits).
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channels?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "141981764",
      "broadcaster_login": "twitchdev",
      "broadcaster_name": "TwitchDev",
      "broadcaster_language": "en",
      "game_id": "509670",
      "game_name": "Science & Technology",
      "title": "TwitchDev Monthly Update // May 6, 2021",
      "delay": 0,
      "tags": [
        "DevsInTheKnow"
      ],
      "content_classification_labels": [
        "Gambling",
        "DrugsIntoxication",
        "MatureGame"
      ],
      "is_branded_content": false
    }
  ]
}
```

## Modify Channel Information {#modify-channel-information}

Updates a channel's properties.

### Endpoint

`PATCH https://api.twitch.tv/helix/channels`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:broadcast** or **user:edit:broadcast** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose channel you want to update. This ID must match the user ID in the user access token.

### Request Body

- `game_id` — String. The ID of the game that the user plays. The game is not updated if the ID isn't a game ID that Twitch recognizes. To unset this field, use "0" or "" (an empty string).
- `broadcaster_language` — String. The user's preferred language. Set the value to an ISO 639-1 two-letter language code (for example, *en* for English). Set to "other" if the user's preferred language is not a Twitch supported language. If the language code isn't a Twitch supported language, the request fails with a 400 Bad Request error.
- `title` — String. The title of the user's stream. You may not set this field to an empty string.
- `delay` — Integer. The number of seconds you want your broadcast buffered before streaming it live. The delay helps ensure fairness during competitive play. Only users with Partner status may set this field. The maximum delay is 900 seconds (15 minutes).
- `tags` — String[]
  A list of channel-defined tags to apply to the channel. To remove all tags from the channel,
  set tags to an empty array. Tags help identify the content that the channel streams. [Learn More](https://help.twitch.tv/s/article/guide-to-tags)

  A channel may specify a maximum of 10 tags. Each tag is limited to a maximum of 25
  characters and may not be an empty string or contain spaces or special characters.
- `content_classification_labels` — Object[]. List of labels that should be set as the Channel's CCLs. **Note:** To clear CCLs for a channel, set all *is_enabled* for all possible CCLs to **false**
  - `content_classification_labels.id` — String, **Required**. ID of the [Content Classification Labels](https://help.twitch.tv/s/article/content-classification-labels) that must be added/removed from the channel.
    Possible values:
    - `DebatedSocialIssuesAndPolitics`
    - `DrugsIntoxication`
    - `SexualThemes`
    - `ViolentGraphic`
    - `Gambling`
    - `ProfanityVulgarity`
  - `content_classification_labels.is_enabled` — Boolean, **Required**. Boolean flag indicating whether the label should be enabled (true) or disabled for the channel.
- `is_branded_content` — Boolean. Boolean flag indicating if the channel has branded content.

### Response Codes

- **204 No Content** — Successfully updated the channel's properties.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in *broadcaster_id* is not valid.
  - The request must update at least one property.
  - The *title* field may not contain an empty string.
  - The ID in *game_id* is not valid.
  - The ID in *game_id* identifies a game that can't be set.
  - The language code in *broadcaster_language* is not a supported language.
  - To update the *delay* field, the broadcaster must have partner status.
  - The *delay* field must be between 0 and 900 seconds.
  - The list in the *tags* field exceeds the maximum number of tags allowed.
  - A tag in the *tags* field exceeds the maximum length allowed.
  - A tag in the *tags* field is empty.
  - A tag in the *tags* field contains special characters or spaces.
  - One or more tags in the *tags* field failed AutoMod review.
  - The list in the *content_classification_labels* field contains more than 6 labels.
  - A label in the *content_classification_labels* field has an empty *id*.
  - A label in the *content_classification_labels* field isn't a supported label.
  - The *content_classification_labels* field includes MatureGame, which you can't set.
  - Game restricted for user's age and region
  - Title exceeds the 140 character limit.
- **401 Unauthorized**
  - User requests CCL for a channel they don't own
  - The ID in *broadcaster_id* must match the user ID found in the OAuth token.
  - The Authorization header is required and must specify a user access token.
  - The OAuth token must include the **channel:manage:broadcast** or **user:edit:broadcast** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **409 Conflict** — The *is_branded_content* field can't be changed at this time.
- **429 Too Many Requests** — The *is_branded_content* field was changed too frequently. Try again later.
- **500 Internal server error**

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/channels?broadcaster_id=41245072' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"game_id":"33214","title":"there are helicopters in the game? REASON TO PLAY FORTNITE found","broadcaster_language":"en","tags":["LevelingUp"]}'
```

## Get Channel Editors {#get-channel-editors}

Gets the broadcaster's list editors.

### Endpoint

`GET https://api.twitch.tv/helix/channels/editors`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:editors** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the channel. This ID must match the user ID in the access token.

### Response Body

- `data` — Object[]. A list of users that are editors for the specified broadcaster. The list is empty if the broadcaster doesn't have editors.
  - `data.user_id` — String. An ID that uniquely identifies a user with editor permissions.
  - `data.user_name` — String. The user's display name.
  - `data.created_at` — String. The date and time, in RFC3339 format, when the user became one of the broadcaster's editors.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of editors.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID found in the OAuth token.
  - The Authorization header is required and must specify a user access token.
  - The OAuth token must include the **channel:read:editors** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channels/editors?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "182891647",
      "user_name": "mauerbac",
      "created_at": "2019-02-15T21:19:50.380833Z"
    },
    {
      "user_id": "135093069",
      "user_name": "BlueLava",
      "created_at": "2018-03-07T16:28:29.872937Z"
    }
  ]
}
```

## Get Followed Channels {#get-followed-channels}

Gets a list of broadcasters that the specified user follows. You can also use this endpoint to see
whether a user follows a specific broadcaster.

### Endpoint

`GET https://api.twitch.tv/helix/channels/followed`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:follows** scope.

### Query Parameters

- `user_id` — String, **Required**. A user's ID. Returns the list of broadcasters that this user follows. This ID must match the user ID in the user OAuth token.
- `broadcaster_id` — String. A broadcaster's ID. Use this parameter to see whether the user follows this broadcaster. If specified, the response contains this broadcaster if the user follows them. If not specified, the response contains all broadcasters that the user follows.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read more](https://dev.twitch.tv/docs/api/guide.md#pagination).

### Response Body

- `data` — Object[]. The list of broadcasters that the user follows. The list is in descending order by `followed_at` (with the most recently followed broadcaster first). The list is empty if the user doesn't follow anyone.
  - `data.broadcaster_id` — String. An ID that uniquely identifies the broadcaster that this user is following.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.followed_at` — String. The UTC timestamp when the user started following the broadcaster.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.
- `total` — Integer. The total number of broadcasters that the user follows. As someone pages through the list, the number may change as the user follows or unfollows broadcasters.

### Response Codes

- **200 OK** — Successfully retrieved the list of broadcasters that the user follows.
- **400 Bad Request**
  - The *user_id* query parameter is required.
  - The ID in the *user_id* query parameter is not valid.
  - The ID in the *user_id* query parameter must match the user ID in the access token.
  - The *broadcaster_id* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token is missing the **user:read:follows** scope.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channels/followed?user_id=123456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "total": 8,
  "data": [
    {
      "broadcaster_id": "11111",
      "broadcaster_login": "userloginname",
      "broadcaster_name": "UserDisplayName",
      "followed_at": "2022-05-24T22:22:08Z"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"
  }
}
```

## Get Channel Followers {#get-channel-followers}

Gets a list of users that follow the specified broadcaster. You can also use this endpoint to see
whether a specific user follows the broadcaster.

> **Note** This endpoint will return specific follower information only if the **moderator:read:followers**
> scope is provided, and its User ID requirements are met. If the scope is not provided, or the
> user is not the broadcaster or a moderator for the specified channel, only the total follower
> count will be included in the response.

### Endpoint

`GET https://api.twitch.tv/helix/channels/followers`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:followers** scope. The User ID in the access token must comply with one of the following:  - The User ID in the access token must match the *broadcaster_id* in the query parameter. - The User ID in the access token must be a moderator on for the specified broadcaster.

### Query Parameters

- `user_id` — String
  A user's ID. Use this parameter to see whether the user follows this broadcaster. If
  specified, the response contains this user if they follow the broadcaster. If not specified,
  the response contains all users that follow the broadcaster.

  Using this parameter requires both a user access token with the **moderator:read:followers**
  scope and the user ID in the access token match the broadcaster_id or be the user ID for a
  moderator of the specified broadcaster.
- `broadcaster_id` — String, **Required**. The broadcaster's ID. Returns the list of users that follow this broadcaster.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read more](https://dev.twitch.tv/docs/api/guide.md#pagination).

### Response Body

- `data` — Object[]. The list of users that follow the specified broadcaster. The list is in descending order by `followed_at` (with the most recent follower first). The list is empty if nobody follows the broadcaster, the specified _user\_id_ isn't in the follower list, the user access token is missing the **moderator:read:followers** scope, or the user isn't the broadcaster or moderator for the channel.
  - `data.followed_at` — String. The UTC timestamp when the user started following the broadcaster.
  - `data.user_id` — String. An ID that uniquely identifies the user that's following the broadcaster.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.
- `total` — Integer. The total number of users that follow this broadcaster. As someone pages through the list, the number of users may change as users follow or unfollow the broadcaster.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of followers.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
  - The *user_id* parameter was specified but either the user access token is missing the **moderator:read:followers** scope or the user is not the broadcaster or moderator for the specified channel.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channels/followers?broadcaster_id=123456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "total": 8,
  "data": [
    {
      "user_id": "11111",
      "user_name": "UserDisplayName",
      "user_login": "userloginname",
      "followed_at": "2022-05-24T22:22:08Z"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"
  }
}
```
