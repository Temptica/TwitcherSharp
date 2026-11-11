# Videos

Get and manage and a broadcaster's Twitch VODs.

Source: https://dev.twitch.tv/docs/api/reference/videos/

## Contents {#contents}

2 entries on this page:

- [Get Videos](#get-videos)
- [Delete Videos](#delete-videos)

## Get Videos {#get-videos}

You may get videos by ID, by user, or by game/category.

You must specify exactly one of the *id*, *user_id* and *game_id* query parameters; the request
fails if you specify none of them or more than one.

You may apply several filters to get a subset of the videos. The filters are applied as an AND
operation to each video. For example, if *language* is set to **de** and *game\_id* is set to 21779,
the response includes only videos that show playing League of Legends by users that stream in
German. The filters apply only if you get videos by user ID or game ID.

### Endpoint

`GET https://api.twitch.tv/helix/videos`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `id` — String
  A list of IDs that identify the videos you want to get. To get more than one video, include
  this parameter for each video you want to get. For example, 'id=1234&id=5678'. You may
  specify a maximum of 100 IDs. The endpoint ignores duplicate IDs and IDs that weren't found.

  The *id*, *user_id*, and *game_id* parameters are mutually exclusive.
- `user_id` — String. The ID of the user whose list of videos you want to get. The *id*, *user_id*, and *game_id* parameters are mutually exclusive.
- `game_id` — String
  A category or game ID. The response contains a maximum of 500 videos that show this content.
  To get category/game IDs, use the [Search Categories](https://dev.twitch.tv/docs/api/reference/search.md#search-categories)
  endpoint.

  The *id*, *user_id*, and *game_id* parameters are mutually exclusive.
- `language` — String
  A filter used to filter the list of videos by the language that the video owner broadcasts
  in. For example, to get videos that were broadcast in German, set this parameter to the ISO
  639-1 two-letter code for German (i.e., DE). For a list of supported languages, see [Supported Stream
  Language](https://help.twitch.tv/s/article/languages-on-twitch#streamlang). If the language is not supported, use "other."
  To filter by more than one language, separate the codes with commas (for example, de,en).

  Specify this parameter only if you specify the *game_id* or *user_id* query parameter. If
  you specify *game_id* but not *language*, the API filters by the first language in the
  request's Accept-Language header, if the request includes one.
- `period` — String. A filter used to filter the list of videos by when they were created. For example, videos created in the last week. The default is *all*.
  Possible values:
  - `all`
  - `day`
  - `month`
  - `week`
- `sort` — String. The order to sort the returned videos in. The default is *time*.
  Possible values:
  - `time`: Sort the results in descending order by when they were created (i.e., latest video
first). If you specify *user_id*, the API sorts by when the videos were published, or
by when they were created if they weren't published.
  - `trending`: Sort the results in descending order by biggest gains in viewership (i.e., highest
trending video first).
  - `views`: Sort the results in descending order by most views (i.e., highest number of views
first).
- `type` — String. A filter used to filter the list of videos by the video's type. The default is *all*.
  Possible values:
  - `all`
  - `archive`: On-demand videos (VODs) of past streams.
  - `highlight`: Highlight reels of past streams.
  - `upload`: External videos that the broadcaster uploaded using the Video Producer.
- `first` — Integer
  The maximum number of items to return per page in the response. The minimum page size is 1
  item per page and the maximum is 100. The default is 20.

  Specify this parameter only if you specify the *game_id* or *user_id* query parameter.
- `after` — String
  The cursor used to get the next page of results. The **Pagination** object in the response
  contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

  Specify this parameter only if you specify the *game_id* or *user_id* query parameter.
- `before` — String
  The cursor used to get the previous page of results. The **Pagination** object in the
  response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

  Specify this parameter only if you specify the *game_id* or *user_id* query parameter.

### Response Body

- `data` — Object[]. The list of published videos that match the filter criteria. The list is always empty if the request comes from a region where videos aren't available.
  - `data.id` — String. An ID that identifies the video.
  - `data.stream_id` — String. The ID of the stream that the video originated from if the video's type is "archive;" otherwise, **null**.
  - `data.user_id` — String. The ID of the broadcaster that owns the video.
  - `data.user_login` — String. The broadcaster's login name.
  - `data.user_name` — String. The broadcaster's display name.
  - `data.title` — String. The video's title.
  - `data.description` — String. The video's description.
  - `data.created_at` — String. The date and time, in UTC, of when the video was created. The timestamp is in RFC3339 format.
  - `data.published_at` — String, Nullable. The date and time, in UTC, of when the video was published. The timestamp is in RFC3339 format.
  - `data.url` — String. The video's URL.
  - `data.thumbnail_url` — String. A URL to a thumbnail image of the video. Before using the URL, you must replace the '%{width}' and '%{height}' placeholders with the width and height of the thumbnail you want returned. Due to current limitations, '${width}' must be 320 and '${height}' must be 180.
  - `data.viewable` — String. The video's viewable state. Always set to **public**.
  - `data.view_count` — Integer. The number of times that users have watched the video.
  - `data.language` — String. The ISO 639-1 two-letter language code that the video was broadcast in. For example, the language code is DE if the video was broadcast in German. For a list of supported languages, see [Supported Stream Language](https://help.twitch.tv/s/article/languages-on-twitch#streamlang). The language value is "other" if the video was broadcast in a language not in the list of supported languages.
  - `data.type` — String. The video's type.
    Possible values:
    - `archive`: An on-demand video (VOD) of one of the broadcaster's past streams.
    - `highlight`: A highlight reel of one of the broadcaster's past streams. See [Creating
Highlights](https://help.twitch.tv/s/article/creating-highlights-and-stream-markers).
    - `upload`: A video that the broadcaster uploaded to their video library. See Upload under
[Video
Producer](https://help.twitch.tv/s/article/video-on-demand?language=en_US#videoproducer).
    - `past_premiere`: A past Premiere. Returned only when you get videos by *id*.
    - `premiere_upload`: A video uploaded for a Premiere. Returned only when you get videos by *id*.
  - `data.duration` — String. The video's length in hours (h), minutes (m), and seconds (s), with leading zero units left out. For example, 3m21s represents 3 minutes, 21 seconds, and 1h0m5s represents 1 hour, 5 seconds.
  - `data.muted_segments` — Object[], Nullable. The segments that Twitch Audio Recognition muted; otherwise, **null**. Always **null** if you use an app access token.
    - `data.muted_segments.duration` — Integer. The duration of the muted segment, in seconds.
    - `data.muted_segments.offset` — Integer. The offset, in seconds, from the beginning of the video to where the muted segment begins.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if the page has no videos, if you get videos by *id*, or if you specify *game_id* and reach the 500-video limit. The last page of results may still include a cursor; the page after it is empty. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* or *before* query parameter depending on whether you're paging forwards or backwards through the results.

### Response Codes

- **200 OK** — Successfully retrieved the list of videos.
- **400 Bad Request**
  - The request must specify either the *id* or *user_id* or *game_id* query parameter.
  - The *id*, *user_id*, and *game_id* query parameters are mutually exclusive; you must specify only one of them.
  - The value in the *id* query parameter is not valid.
  - The ID in the *game_id* query parameter is not valid.
  - The value in the *type* query parameter is not valid.
  - The value in the *period* query parameter is not valid.
  - The value in the *sort* query parameter is not valid.
  - The ID in the *user_id* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* or *before* query parameter is not valid.
  - The request may specify either the *after* or *before* query parameter but not both.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The ID in the *game_id* query parameter was not found.
- **503 Service Unavailable** — The API couldn't get the videos. Try the request again.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/videos?id=335921245' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "335921245",
      "stream_id": null,
      "user_id": "141981764",
      "user_login": "twitchdev",
      "user_name": "TwitchDev",
      "title": "Twitch Developers 101",
      "description": "Welcome to Twitch development! Here is a quick overview of our products and\ninformation to help you get started.",
      "created_at": "2018-11-14T21:30:18Z",
      "published_at": "2018-11-14T22:04:30Z",
      "url": "https://www.twitch.tv/videos/335921245",
      "thumbnail_url": "https://static-cdn.jtvnw.net/cf_vods/d2nvs31859zcd8/twitchdev/335921245/ce0f3a7f-57a3-4152-bc06-0c6610189fb3/thumb/index-0000000000-%{width}x%{height}.jpg",
      "viewable": "public",
      "view_count": 1863062,
      "language": "en",
      "type": "upload",
      "duration": "3m21s",
      "muted_segments": [
        {
          "duration": 30,
          "offset": 120
        }
      ]
    }
  ],
  "pagination": {}
}
```

## Delete Videos {#delete-videos}

You may delete past broadcasts, highlights, or uploads. The user in the access token must own the
videos or be an editor for the channel that owns them.

### Endpoint

`DELETE https://api.twitch.tv/helix/videos`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:videos** scope.

### Query Parameters

- `id` — String, **Required**
  The list of videos to delete. To specify more than one video, include the *id* parameter for
  each video to delete. For example, 'id=1234&id=5678'. You can delete a maximum of 5 videos
  per request.

  If any ID doesn't identify a video that the user has permission to delete, none of the
  videos are deleted.

### Response Body

- `data` — String[]. The list of IDs of the videos that were deleted.

### Response Codes

- **200 OK** — Successfully deleted the list of videos.
- **400 Bad Request**
  - The *id* query parameter is required.
  - The request exceeded the number of allowed *id* query parameters.
- **401 Unauthorized**
  - The caller is not authorized to delete one of the specified videos, or one of the IDs doesn't identify a video.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:videos** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/videos?id=9876' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    "9876"
  ]
}
```
