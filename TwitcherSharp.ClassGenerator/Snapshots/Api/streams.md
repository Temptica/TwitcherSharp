# Streams

Get and manage information relating to a stream, or the ability to stream.

Source: https://dev.twitch.tv/docs/api/reference/streams/

## Contents {#contents}

5 entries on this page:

- [Get Streams](#get-streams)
- [Get Followed Streams](#get-followed-streams)
- [Get Stream Key](#get-stream-key)
- [Get Stream Markers](#get-stream-markers)
- [Create Stream Marker](#create-stream-marker)

## Get Streams {#get-streams}

Gets a list of all streams. The list is in descending order by the number of viewers watching the stream. Because viewers come
and go during a stream, it's possible to find duplicate or missing streams in the list as you page
through the results.

### Endpoint

`GET https://api.twitch.tv/helix/streams`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `user_id` — String. A user ID used to filter the list of streams. Returns only the streams of those users that are broadcasting. You may specify a maximum of 100 IDs. To specify multiple IDs, include the *user_id* parameter for each user. For example, '&user_id=1234&user_id=5678'.
- `user_login` — String. A user login name used to filter the list of streams. Returns only the streams of those users that are broadcasting. You may specify a maximum of 100 login names. To specify multiple names, include the *user_login* parameter for each user. For example, '&user_login=foo&user_login=bar'.
- `game_id` — String. A game (category) ID used to filter the list of streams. Returns only the streams that are broadcasting the game (category). You may specify a maximum of 100 IDs. To specify multiple IDs, include the *game_id* parameter for each game. For example, '&game_id=9876&game_id=5432'.
- `type` — String. The type of stream to filter the list of streams by. The default is *all*. Both values return only live streams.
  Possible values:
  - `all`
  - `live`
- `language` — String
  A language code used to filter the list of streams. Returns only streams that broadcast in
  the specified language. Specify the language using an ISO 639-1 two-letter language code or
  *other* if the broadcast uses a language not in the list of [supported stream
  languages](https://help.twitch.tv/s/article/languages-on-twitch#streamlang).

  You may specify a maximum of 100 language codes. To specify multiple languages, include the
  *language* parameter for each language. For example, '&language=de&language=fr'.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20. If you specify *user_id* or *user_login*, the response contains all of the matching streams, regardless of this value.
- `before` — String. The cursor used to get the previous page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of streams. Streams that Twitch restricts from discovery aren't included, except the user's own stream if you use a user access token, so a page may contain fewer than *first* items even if more pages remain.
  - `data.id` — String. An ID that identifies the stream. You can use this ID later to look up the video on demand (VOD).
  - `data.user_id` — String. The ID of the user that's broadcasting the stream.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.game_id` — String. The ID of the category or game being streamed. If no category is set on the channel, this will be set to an empty string.
  - `data.game_name` — String. The name of the category or game being streamed. If no category is set on the channel, this will be set to an empty string.
  - `data.type` — String. The type of stream.
    Possible values:
    - `live`
  - `data.title` — String. The stream's title. Is an empty string if not set.
  - `data.tags` — String[], Nullable. The tags applied to the stream. Is **null** if the stream has no tags.
  - `data.viewer_count` — Integer. The number of users watching the stream.
  - `data.started_at` — String. The UTC date and time (in RFC3339 format) of when the broadcast began.
  - `data.language` — String. The language that the stream uses. This is an ISO 639-1 two-letter language code or *other* if the stream uses a language not in the list of [supported stream languages](https://help.twitch.tv/s/article/languages-on-twitch#streamlang).
  - `data.thumbnail_url` — String. A URL to an image of a frame from the last 5 minutes of the stream. Replace the width and height placeholders in the URL ('{width}x{height}') with the size of the image you want, in pixels.
  - `data.tag_ids` — String[]
    **IMPORTANT** As of February 28, 2023, this field is deprecated and returns only an
    empty array. If you use this field, please update your code to use the `tags` field.

    The list of tags that apply to the stream. The list contains IDs only when the channel
    is steaming live. For a list of possible tags, see [List of All
    Tags](https://www.twitch.tv/directory/all/tags). The list doesn't include Category Tags.
  - `data.is_mature` — Boolean. **IMPORTANT** This field is deprecated and returns only **false**. A Boolean value that indicates whether the stream is meant for mature audiences.
- `pagination` — Object. The information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Set the request's *after* or *before* query parameter to this value depending on whether you're paging forwards or backwards.

### Response Codes

- **200 OK** — Successfully retrieved the list of streams.
- **400 Bad Request**
  - The value in the *type* query parameter is not valid.
  - The request may specify the *before* or *after* query parameter, but not both.
  - The cursor specified in the *before* or *after* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
  - The request specified too many *user_id*, *user_login*, *game_id*, or *language* query parameters.
  - A *user_id*, *user_login*, or *game_id* query parameter contains a comma-separated list. To specify multiple values, repeat the parameter (for example, 'user_id=1234&user_id=5678').
  - A *user_id*, *user_login*, or *game_id* query parameter contains an empty string.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the Client ID in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/streams' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "123456789",
      "user_id": "98765",
      "user_login": "sandysanderman",
      "user_name": "SandySanderman",
      "game_id": "494131",
      "game_name": "Little Nightmares",
      "type": "live",
      "title": "hablamos y le damos a Little Nightmares 1",
      "tags": ["Español"],
      "viewer_count": 78365,
      "started_at": "2021-03-10T15:04:21Z",
      "language": "es",
      "thumbnail_url": "https://static-cdn.jtvnw.net/previews-ttv/live_user_auronplay-{width}x{height}.jpg",
      "tag_ids": [],
      "is_mature": false
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjp7IkN1cnNvciI6ImV5SnpJam8zT0RNMk5TNDBORFF4TlRjMU1UY3hOU3dpWkNJNlptRnNjMlVzSW5RaU9uUnlkV1Y5In0sImEiOnsiQ3Vyc29yIjoiZXlKeklqb3hOVGs0TkM0MU56RXhNekExTVRZNU1ESXNJbVFpT21aaGJITmxMQ0owSWpwMGNuVmxmUT09In19"
  }
}
```

## Get Followed Streams {#get-followed-streams}

Gets the list of broadcasters that the user follows and that are streaming live.

### Endpoint

`GET https://api.twitch.tv/helix/streams/followed`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:follows** scope.

### Query Parameters

- `user_id` — String, **Required**. The ID of the user whose list of followed streams you want to get. This ID must match the user ID in the access token.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 100.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of live streams of broadcasters that the specified user follows. The list is in descending order by the number of viewers watching the stream. Because viewers come and go during a stream, it's possible to find duplicate or missing streams in the list as you page through the results. The list is empty if none of the followed broadcasters are streaming live. If the user follows more than 2,000 broadcasters, the list includes only streams from the first 2,000 broadcasters that the user followed.
  - `data.id` — String. An ID that identifies the stream. You can use this ID later to look up the video on demand (VOD).
  - `data.user_id` — String. The ID of the user that's broadcasting the stream.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.game_id` — String. The ID of the category or game being played.
  - `data.game_name` — String. The name of the category or game being played.
  - `data.type` — String. The type of stream.
    Possible values:
    - `live`
  - `data.title` — String. The stream's title. Is an empty string if not set.
  - `data.viewer_count` — Integer. The number of users watching the stream.
  - `data.started_at` — String. The UTC date and time (in RFC3339 format) of when the broadcast began.
  - `data.language` — String. The language that the stream uses. This is an ISO 639-1 two-letter language code or *other* if the stream uses a language not in the list of [supported stream languages](https://help.twitch.tv/s/article/languages-on-twitch#streamlang)
  - `data.thumbnail_url` — String. A URL to an image of a frame from the last 5 minutes of the stream. Replace the width and height placeholders in the URL ('{width}x{height}') with the size of the image you want, in pixels.
  - `data.tag_ids` — String[]
    **IMPORTANT** As of February 28, 2023, this field is deprecated and returns only an
    empty array. If you use this field, please update your code to use the `tags` field.

    The list of tags that apply to the stream. The list contains IDs only when the channel
    is steaming live. For a list of possible tags, see [List of All
    Tags](https://www.twitch.tv/directory/all/tags). The list doesn't include Category Tags.
  - `data.tags` — String[], Nullable. The tags applied to the stream. Is **null** if the stream has no tags.
  - `data.is_mature` — Boolean. **IMPORTANT** This field is deprecated and returns only **false**. A Boolean value that indicates whether the stream is meant for mature audiences.
- `pagination` — Object. The information used to page through the list of results. The object is empty if the page contains fewer streams than the page size (see *first*). A full page includes a cursor even if no more streams remain, in which case the next page is empty. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Set the request's *after* query parameter to this value.

### Response Codes

- **200 OK** — Successfully retrieved the list of broadcasters that the user follows and that are streaming live.
- **400 Bad Request**
  - The *user_id* query parameter is required.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *user_id* must match the user ID found in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:read:follows** scope.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/streams/followed?user_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "42170724654",
      "user_id": "132954738",
      "user_login": "aws",
      "user_name": "AWS",
      "game_id": "417752",
      "game_name": "Talk Shows & Podcasts",
      "type": "live",
      "title": "AWS Howdy Partner! Y'all welcome ExtraHop to the show!",
      "viewer_count": 20,
      "started_at": "2021-03-31T20:57:26Z",
      "language": "en",
      "thumbnail_url": "https://static-cdn.jtvnw.net/previews-ttv/live_user_aws-{width}x{height}.jpg",
      "tag_ids": [],
      "tags": ["English"]
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjp7IkN1cnNvciI6ImV5SnpJam8zT0RNMk5TNDBORFF4TlRjMU1UY3hOU3dpWkNJNlptRnNjMlVzSW5RaU9uUnlkV1Y5In0sImEiOnsiQ3Vyc29yIjoiZXlKeklqb3hOVGs0TkM0MU56RXhNekExTVRZNU1ESXNJbVFpT21aaGJITmxMQ0owSWpwMGNuVmxmUT09In19"
  }
}
```

## Get Stream Key {#get-stream-key}

Gets the channel's stream key.

### Endpoint

`GET https://api.twitch.tv/helix/streams/key`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:stream_key** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the channel. The ID must match the user ID in the access token.

### Response Body

- `data` — Object[]. A list that contains the channel's stream key.
  - `data.stream_key` — String. The channel's stream key.

### Response Codes

- **200 OK** — Successfully retrieved the stream's key.
- **400 Bad Request**
  - The *broadcaster_id* field is required.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:stream_key** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header must match the client ID specified in the access token.
- **403 Forbidden**
  - The user must complete additional steps in order to stream. Present the user with the returned error message.
  - The user is not permitted to get a stream key.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/streams/key?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "stream_key": "live_44322889_a34ub37c8ajv98a0"
    }
  ]
}
```

## Get Stream Markers {#get-stream-markers}

Gets a list of markers from the user's most recent stream or from the specified VOD/video.
A marker is an arbitrary point in a live stream that the broadcaster or editor marked, so they can
return to that spot later to create video highlights. For more information on these features, see
[Creating Highlights and Stream
Markers](https://help.twitch.tv/s/article/creating-highlights-and-stream-markers).

You must specify exactly one of the *user_id* and *video_id* query parameters; the request fails
if you specify none of them or more than one.

### Endpoint

`GET https://api.twitch.tv/helix/streams/markers`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:broadcast** or **channel:manage:broadcast** scope.

### Query Parameters

- `user_id` — String
  A user ID. The request returns the markers from this user's most recent past broadcast (a
  video of type *archive*); highlights and uploads aren't considered. This ID must match the
  user ID in the access token or the user in the access token must be one of the broadcaster's
  editors.

  This parameter and the *video_id* query parameter are mutually exclusive.
- `video_id` — String
  A video on demand (VOD)/video ID. The request returns the markers from this VOD/video. The
  user in the access token must own the video or the user must be one of the broadcaster's
  editors.

  This parameter and the *user_id* query parameter are mutually exclusive.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of markers grouped by the user that created the marks.
  - `data.user_id` — String. The ID of the user that created the marker.
  - `data.user_name` — String. The user's display name.
  - `data.user_login` — String. The user's login name.
  - `data.videos` — Object[]. A list of videos that contain markers. The list contains a single video.
    - `data.videos.video_id` — String. An ID that identifies this video.
    - `data.videos.markers` — Object[]. The list of markers in this video. The list is in ascending order by the marker's position in the video (see `position_seconds`).
      - `data.videos.markers.id` — String. An ID that identifies this marker.
      - `data.videos.markers.created_at` — String. The UTC date and time (in RFC3339 format) of when the user created the marker.
      - `data.videos.markers.description` — String. The description that the user gave the marker to help them remember why they marked the location. Is an empty string if the user didn't provide one.
      - `data.videos.markers.position_seconds` — Integer. The relative offset (in seconds) of the marker from the beginning of the stream.
      - `data.videos.markers.URL` — String. A URL that opens the video in Twitch Highlighter.
- `pagination` — Object. The information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Set the request's *after* query parameter to this value.

### Response Codes

- **200 OK** — Successfully retrieved the list of markers.
- **400 Bad Request**
  - The request must specify either the *user_id* or *video_id* query parameter, but not both.
  - The ID in the *video_id* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:read:broadcast** or **channel:manage:broadcast** scope.
  - The access token is not valid.
  - The Client ID specified in the Client-Id header does not match the Client ID specified in the access token.
- **403 Forbidden**
  - The user in the access token is not authorized to get the video's markers. The user in the access token must own the video or be one of the broadcaster's editors.
- **404 Not Found**
  - The user specified in the *user_id* query parameter doesn't have any past broadcasts.
  - The video specified in the *video_id* query parameter was not found.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/streams/markers?user_id=123&first=5' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "123",
      "user_name": "TwitchName",
      "user_login": "twitchname",
      "videos": [
        {
          "video_id": "456",
          "markers": [
            {
              "id": "106b8d6243a4f883d25ad75e6cdffdc4",
              "created_at": "2018-08-20T20:10:03Z",
              "description": "hello, this is a marker!",
              "position_seconds": 244,
              "URL": "https://twitch.tv/twitchname/manager/highlighter/456?t=0h4m06s"
            },
            ...
          ]
        }
      ]
    }
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjoiMjk1MjA0Mzk3OjI1Mzpib29rbWFyazoxMDZiOGQ1Y"
  }
}
```

## Create Stream Marker {#create-stream-marker}

Adds a marker to a live stream.

A marker is an arbitrary point in a live stream that the broadcaster or editor wants to mark, so
they can return to that spot later to create video highlights. For more information on these
features, see [Creating Highlights and Stream
Markers](https://help.twitch.tv/s/article/creating-highlights-and-stream-markers).

You may not add markers:

- If the stream is not live.
- If the stream has not enabled video on demand (VOD).
- If the stream is a rerun of a past broadcast.
- If the stream is a premiere.

### Endpoint

`POST https://api.twitch.tv/helix/streams/markers`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:broadcast** or **user:edit:broadcast** scope.

### Request Body

- `user_id` — String, **Required**. The ID of the broadcaster that's streaming content. This ID must match the user ID in the access token or the user in the access token must be one of the broadcaster's editors.
- `description` — String. A short description of the marker to help the user remember why they marked the location. The maximum length of the description is 140 characters.

### Response Body

- `data` — Object[]. A list that contains the single marker that you added.
  - `data.id` — String. An ID that identifies this marker.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) of when the user created the marker.
  - `data.position_seconds` — Integer. The relative offset (in seconds) of the marker from the beginning of the stream.
  - `data.description` — String. A description that the user gave the marker to help them remember why they marked the location.

### Response Codes

- **200 OK** — Successfully created the marker.
- **400 Bad Request**
  - The _user\_id_ field is required.
  - The length of the string in the *description* field is too long.
  - The broadcaster is streaming a rerun or a premiere.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:broadcast** or **user:edit:broadcast** scope.
  - The access token is not valid.
  - The Client ID specified in the Client-Id header does not match the Client ID specified in the access token.
- **403 Forbidden**
  - The user in the access token is not authorized to create video markers for the user in the _user\_id_ field. The user in the access token must own the video or they must be one of the broadcaster's editors.
- **404 Not Found**
  - The user in the _user\_id_ field is not streaming live.
  - The ID in the _user\_id_ field is not valid.
  - The user hasn't enabled video on demand (VOD).
  - Markers aren't available during the first few seconds of a stream. Wait a few seconds and try again.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/streams/markers' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"user_id":"123","description":"hello, this is a marker!"}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "123",
      "created_at": "2018-08-20T20:10:03Z",
      "description": "hello, this is a marker!",
      "position_seconds": 244
    }
  ]
}
```
