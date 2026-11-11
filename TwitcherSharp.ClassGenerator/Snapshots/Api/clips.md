# Clips

Create and manage clips on Twitch

Source: https://dev.twitch.tv/docs/api/reference/clips/

## Contents {#contents}

4 entries on this page:

- [Get Clips](#get-clips)
- [Create Clip](#create-clip)
- [Get Clips Download](#get-clips-download)
- [Create Clip From VOD](#create-clip-from-vod)

## Get Clips {#get-clips}

Gets one or more video clips that were captured from streams. For information about clips, see
[How to use clips](https://help.twitch.tv/s/article/how-to-use-clips).

You must specify exactly one of the *broadcaster_id*, *game_id* and *id* query parameters; the
request fails if you specify none of them or more than one.

When using pagination for clips, note that the maximum number of results returned over multiple
requests will be approximately 1,000. If additional results are necessary, paginate over different
query parameters such as multiple *started_at* and *ended_at* timeframes to refine the search.

### Endpoint

`GET https://api.twitch.tv/helix/clips`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String. An ID that identifies the broadcaster whose video clips you want to get. Use this parameter to get clips that were captured from the broadcaster's streams.
- `game_id` — String. An ID that identifies the game whose clips you want to get. Use this parameter to get clips that were captured from streams that were playing this game.
- `id` — String
  An ID that identifies the clip to get. To specify more than one ID, include this parameter
  for each clip you want to get. For example, 'id=foo&id=bar'. You may specify a maximum of
  100 IDs. The API ignores duplicate IDs and IDs that aren't found.

  If you specify *id*, the API ignores the *started_at*, *ended_at*, *is_featured*, *first*,
  and *after* query parameters, and the response doesn't include a cursor.
- `started_at` — String. The start date used to filter clips. The API returns only clips within the start and end date window. Specify the date and time in RFC3339 format. The API truncates the start and end times to the minute.
- `ended_at` — String. The end date used to filter clips. If not specified, the time window is the start date plus one week. Specify the date and time in RFC3339 format. The API ignores this parameter if you don't specify *started_at*.
- `first` — Integer. The maximum number of clips to return per page in the response. The minimum page size is 1 clip per page and the maximum is 100. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
- `is_featured` — Boolean. A Boolean value that determines whether the response includes featured clips. If **true**, returns only clips that are featured. If **false**, returns only clips that aren't featured. All clips are returned if this parameter is not present.

### Response Body

- `data` — Object[]. The list of video clips. For clips returned by *game\_id* or *broadcaster\_id*, the list is in descending order by view count. For lists returned by *id*, the order isn't guaranteed to match the order of the input IDs. The list is always empty if the request comes from a region where videos aren't available.
  - `data.id` — String. An ID that uniquely identifies the clip.
  - `data.url` — String. A URL to the clip.
  - `data.embed_url` — String. A URL that you can use in an iframe to embed the clip (see [Embedding Video and Clips](https://dev.twitch.tv/docs/embed/video-and-clips.md)).
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that the video was clipped from.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.creator_id` — String. An ID that identifies the user that created the clip.
  - `data.creator_name` — String. The user's display name.
  - `data.video_id` — String. An ID that identifies the video that the clip came from. This field contains an empty string if the video is not available.
  - `data.game_id` — String. The ID of the game that was being played when the clip was created.
  - `data.language` — String. The ISO 639-1 two-letter language code that the broadcaster broadcasts in. For example, *en* for English. The value is *other* if the broadcaster uses a language that Twitch doesn't support.
  - `data.title` — String. The title of the clip.
  - `data.view_count` — Integer. The number of times the clip has been viewed.
  - `data.created_at` — String. The date and time of when the clip was created. The date and time is in RFC3339 format.
  - `data.thumbnail_url` — String. A URL to a thumbnail image of the clip.
  - `data.duration` — Float. The length of the clip, in seconds. Precision is 0.1.
  - `data.vod_offset` — Integer, Nullable
    The zero-based offset, in seconds, to where the clip starts in the video (VOD). Is
    **null** if the video is not available or hasn't been created yet from the live stream
    (see `video_id`).

    Note that there's a delay between when a clip is created during a broadcast and when the
    offset is set. During the delay period, `vod_offset` is **null**. The delay is
    indeterminant but is typically minutes long.
  - `data.is_featured` — Boolean. A Boolean value that indicates if the clip is featured or not.
- `pagination` — Object. The information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Set the request's *after* query parameter to this value.

### Response Codes

- **200 OK** — Successfully retrieved the list of video clips.
- **400 Bad Request**
  - The *id* or *game_id* or *broadcaster_id* query parameter is required.
  - The *id*, *game_id*, and *broadcaster_id* query parameters are mutually exclusive; you may specify only one of them.
  - Every *id* query parameter is an empty string.
  - The number of *id* query parameters exceeds the maximum allowed.
  - The ID in *game_id* is not valid.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
  - The *started_at* or *ended_at* query parameter isn't in RFC3339 format.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **404 Not Found**
  - The ID in *game_id* was not found.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/clips?id=AwkwardHelplessSalamanderSwiftRage' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "AwkwardHelplessSalamanderSwiftRage",
      "url": "https://clips.twitch.tv/AwkwardHelplessSalamanderSwiftRage",
      "embed_url": "https://clips.twitch.tv/embed?clip=AwkwardHelplessSalamanderSwiftRage",
      "broadcaster_id": "67955580",
      "broadcaster_name": "ChewieMelodies",
      "creator_id": "53834192",
      "creator_name": "BlackNova03",
      "video_id": "205586603",
      "game_id": "488191",
      "language": "en",
      "title": "babymetal",
      "view_count": 10,
      "created_at": "2017-11-30T22:34:18Z",
      "thumbnail_url": "https://clips-media-assets.twitch.tv/157589949-preview-480x272.jpg",
      "duration": 60,
      "vod_offset": 480,
      "is_featured": false
    }
  ]
}
```

## Create Clip {#create-clip}

Creates a clip from the broadcaster's stream.

This API captures up to 90 seconds of the broadcaster's stream. The 90 seconds spans the point in
the stream from when you called the API. For example, if you call the API at the 4:00 minute mark,
the API captures from approximately the 2:35 mark to approximately the 4:05 minute mark. Twitch
tries its best to capture 90 seconds of the stream, but the actual length may be less. This may
occur if you begin capturing the clip near the beginning or end of the stream.

By default, Twitch publishes up to the last 30 seconds of the 90 seconds window and provides a
default title for the clip. To specify the title and the portion of the 90 seconds window that's
used for the clip, use the URL in the response's `edit_url` field. You can specify a clip that's
from 5 seconds to 60 seconds in length. The URL is valid for up to 24 hours or until the clip is
published, whichever comes first.

Creating a clip is an asynchronous process that can take a short amount of time to complete. To
determine whether the clip was successfully created, call [Get Clips](#get-clips) using the clip
ID that this request returned. If Get Clips returns the clip, the clip was successfully created.
If after 60 seconds Get Clips hasn't returned the clip, assume it failed.

### Endpoint

`POST https://api.twitch.tv/helix/clips`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **clips:edit** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose stream you want to create a clip from.
- `title` — String. The title of the clip.
- `duration` — Float. The length of the clip in seconds. Possible values range from 5 to 60 inclusively with a precision of 0.1. The default is 30.

### Response Body

- `data` — Object[]. A list containing the created clip.
  - `data.id` — String. An ID that uniquely identifies the clip.
  - `data.edit_url` — String
    A URL that you can use to edit the clip's title, identify the part of the clip to
    publish, and publish the clip. [Learn
    More](https://help.twitch.tv/s/article/how-to-use-clips)

    The URL is valid for up to 24 hours or until the clip is published, whichever comes
    first.

### Response Codes

- **202 Accepted** — Successfully started the clip process.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The category is not clippable.
  - The title did not pass AutoMod checks.
- **401 Unauthorized**
  - The Authorization header is required and must specify user access token.
  - The user access token must include the **clips:edit** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The broadcaster has restricted the ability to capture clips to followers and/or subscribers only.
  - The specified broadcaster has not enabled clips on their channel.
  - The user is banned or timed out from the broadcaster's channel.
- **404 Not Found**
  - The broadcaster in the *broadcaster_id* query parameter must be broadcasting live. This error is also returned if *broadcaster_id* doesn't identify an existing broadcaster.
  - The broadcaster is banned.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/clips?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "FiveWordsForClipSlug",
      "edit_url": "https://www.twitch.tv/twitchdev/clip/FiveWordsForClipSlug"
    }
  ]
}
```

## Get Clips Download {#get-clips-download}

Provides URLs to download the video file(s) for the specified clips.

For information about clips, see [How to use clips](https://help.twitch.tv/s/article/how-to-use-clips).
These links are temporary and should have a long-term expectation to expire.

**Rate Limits**: Limited to 100 requests per minute.

### Endpoint

`GET https://api.twitch.tv/helix/clips/downloads`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **editor:manage:clips** or **channel:manage:clips** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **editor:manage:clips** or **channel:manage:clips** scope for the user represented by the *editor_id* query parameter.

### Query Parameters

- `editor_id` — String, **Required**. The User ID of the editor for the channel you want to download a clip for. If using the broadcaster's auth token, this is the same as _broadcaster\_id_. This must match the `user_id` in the user access token.
- `broadcaster_id` — String, **Required**. The ID of the broadcaster you want to download clips for.
- `clip_id` — String, **Required**. The ID that identifies the clip you want to download. Include this parameter for each clip you want to download, up to a maximum of 10 clips. For example, 'clip_id=SleepyGiftedPeppermintNerfRedBlaster-KbkBXYt3lOk3jy8-&clip_id=WimpyAltruisticKleeKeyboardCat-EiY5yMrEwZ4i4gwC'.

### Response Body

- `data` — Object[]. List of clips and their download URLs. Clips that weren't found, that the editor may not access, or that belong to a different broadcaster are left out of the list.
  - `data.clip_id` — String. An ID that uniquely identifies the clip.
  - `data.landscape_download_url` — String, Nullable. The landscape URL to download the clip. This field is **null** if the URL is not available.
  - `data.portrait_download_url` — String, Nullable. The portrait URL to download the clip. This field is **null** if the URL is not available.

### Response Codes

- **200 OK** — Successfully retrieved the clip download URL(s).
- **400 Bad Request**
  - The *editor_id* query parameter is required.
  - The *broadcaster_id* query parameter is required.
  - The request must include from 1 through 10 *clip_id* query parameters.
  - The ID in *editor_id* must match the user ID in the user access token.
- **401 Unauthorized**
  - The OAuth token is not valid.
  - The Authorization header is required and must contain a user access token or app access token.
  - The user access token must include the **editor:manage:clips** or **channel:manage:clips** scope.
  - If you use an app access token, the user in *editor_id* must have authorized your app with the **editor:manage:clips** or **channel:manage:clips** scope.
  - The access token is not valid
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden** — The user is not an editor for the specified broadcaster.
- **500 Internal Error** — Internal Server Error.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/clips/downloads?broadcaster_id=141981764&editor_id=141981764&clip_id=SpinelessCloudyLeopardMcaT' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "clip_id": "SpinelessCloudyLeopardMcaT",
      "landscape_download_url": "https://production.assets.clips.twitchcdn.net/542j...",
      "portrait_download_url": null
    }
  ]
}
```

## Create Clip From VOD {#create-clip-from-vod}

Creates a clip from the broadcaster's VOD.

Creates a clip from a broadcaster's VOD on behalf of the
broadcaster or an editor of the channel. Since a live stream is actively creating a VOD, this
endpoint can also be used to create a clip from earlier in the current stream.

The duration of a clip can be from 5 seconds to 60 seconds in length, with a default of 30 seconds
if not specified.

*vod_offset* indicates where the clip will end. In other words, the clip will start at
(*vod_offset* - *duration*) and end at *vod_offset*. This means that the value of *vod_offset*
must greater than or equal to the value of *duration*.

The URL in the response's `edit_url` field allows you to edit the clip's title, feature the clip,
create a portrait version of the clip, download the clip media, and share the clip directly to
social platforms.

### Endpoint

`POST https://api.twitch.tv/helix/videos/clips`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **editor:manage:clips** or **channel:manage:clips** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **editor:manage:clips** or **channel:manage:clips** scope for the user represented by the *editor_id* query parameter.

### Query Parameters

- `editor_id` — String, **Required**. The user ID of the editor for the channel you want to create a clip for. If using the broadcaster's auth token, this is the same as broadcaster\_id. This must match the user_id in the user access token.
- `broadcaster_id` — String, **Required**. The user ID for the channel you want to create a clip for.
- `vod_id` — String, **Required**. ID of the VOD the user wants to clip.
- `vod_offset` — Integer, **Required**. The zero-based offset, in seconds, to where the clip should end in the video (VOD). See this endpoint's description for more information on how to use this parameter.
- `duration` — Float. The length of the clip, in seconds. Precision is 0.1. Defaults to 30. Min: 5 seconds, Max: 60 seconds.
- `title` — String, **Required**. The title of the clip.

### Response Body

- `data` — Object[]. A list containing the created clip.
  - `data.id` — String. An ID that uniquely identifies the clip.
  - `data.edit_url` — String. A URL you can use to edit the clip's title, feature the clip, create a portrait version of the clip, download the clip media, and share the clip directly to third-party platforms.

### Response Codes

- **202 Accepted** — Successfully started the clip process.
- **400 Bad Request**
  - Validation errors: Invalid source type, missing required fields.
  - The broadcaster_id query parameter is required.
  - The category is not clippable.
  - The title did not pass AutoMod checks.
  - The value of *vod_offset* must be greater than or equal to the value of *duration*.
  - The VOD in *vod_id* was not found, or it doesn't belong to the broadcaster in *broadcaster_id*.
- **401 Unauthorized**
  - The ID in *editor_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **editor:manage:clips** or **channel:manage:clips** scope.
  - If you use an app access token, the user in *editor_id* must have authorized your app with the **editor:manage:clips** or **channel:manage:clips** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The broadcaster has restricted the ability to capture clips to followers and/or subscribers only.
  - The specified broadcaster has not enabled clips on their channel.
  - The user defined by the *editor_id* is not authorized to create Clips.
  - The user is banned or timed out from the broadcaster's channel.
- **404 Not Found**
  - The VOD is not found.
  - The broadcaster is banned.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/videos/clips?broadcaster_id=141981764&editor_id=12826&vod_id=2277656159&vod_offset=434&title=Standard%20Output' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "FiveWordsForClipSlug",
      "edit_url": "https://www.twitch.tv/twitchdev/clip/FiveWordsForClipSlug"
    }
  ]
}
```
