# Search

Search for categories and channels on Twitch.

Source: https://dev.twitch.tv/docs/api/reference/search/

## Contents {#contents}

2 entries on this page:

- [Search Categories](#search-categories)
- [Search Channels](#search-channels)

## Search Categories {#search-categories}

Gets the games or categories that match the specified query.

A category matches if its name or one of its alternative names begins with the query string, if
any word in its name begins with the query string, or if each word in the query string matches the
beginning of a word in its name. For example, if the query string is *love computer*, the response
includes any category whose name contains words that begin with love and computer. The comparison
is case insensitive, and close misspellings can also match.

### Endpoint

`GET https://api.twitch.tv/helix/search/categories`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `query` — String, **Required**. The URI-encoded search string. For example, encode *#archery* as '%23archery' and search strings like *angel of death* as 'angel%20of%20death'.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of games or categories that match the query. The list is empty if there are no matches.
  - `data.box_art_url` — String. A URL to an image of the game's box art or streaming category.
  - `data.name` — String. The name of the game or category.
  - `data.id` — String. An ID that uniquely identifies the game or category.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of category names that matched the specified query string.
- **400 Bad Request**
  - The *query* query parameter is required.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/search/categories?query=fort' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "33214",
      "name": "Fortnite",
      "box_art_url": "https://static-cdn.jtvnw.net/ttv-boxart/33214-52x72.jpg"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7IkN"
  }
}
```

## Search Channels {#search-channels}

Gets the channels that match the specified query.

The fields that the API uses for comparison depends on the value that the *live_only* query
parameter is set to. If *live_only* is **false**, the API matches on the broadcaster's login name
and display name. However, if *live_only* is **true**, the API matches on the broadcaster's login
name, display name, and the name of the category they're streaming.

If *live_only* is **false**, the broadcaster's login name or display name must begin with the
query string. If *live_only* is **true**, the query string can also match the beginning of any
word in those names or in the category name, and a phrase matches if each of its words does. The
comparison is case insensitive, and close misspellings can also match. For example, the query
string *angel of death* can match names that begin with angelofdeath or angel_of_death.

By default, the results include both live and offline channels. To get only live channels set the
*live_only* query parameter to **true**.

### Endpoint

`GET https://api.twitch.tv/helix/search/channels`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `query` — String, **Required**. The URI-encoded search string. For example, encode search strings like *angel of death* as 'angel%20of%20death'.
- `live_only` — Boolean. A Boolean value that determines whether the response includes only channels that are currently streaming live. Set to **true** to get only channels that are streaming live; otherwise, **false** to get live and offline channels. The default is **false**.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of channels that match the query. The list is empty if there are no matches.
  - `data.broadcaster_language` — String. The ISO 639-1 two-letter language code of the language used by the broadcaster. For example, *en* for English. If the broadcaster uses a language not in the list of [supported stream languages](https://help.twitch.tv/s/article/languages-on-twitch#streamlang), the value is *other*.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.display_name` — String. The broadcaster's display name.
  - `data.game_id` — String. The ID of the game that the broadcaster is playing or last played.
  - `data.game_name` — String. The name of the game that the broadcaster is playing or last played.
  - `data.id` — String. An ID that uniquely identifies the channel (this is the broadcaster's ID).
  - `data.is_live` — Boolean. A Boolean value that determines whether the broadcaster is streaming live. Is **true** if the broadcaster is streaming live; otherwise, **false**.
  - `data.tag_ids` — String[]
    **IMPORTANT** As of February 28, 2023, this field is deprecated and returns only an empty
    array. If you use this field, please update your code to use the `tags` field.

    The list of tags that apply to the stream. The list contains IDs only when the channel is
    steaming live. For a list of possible tags, see [List of All
    Tags](https://www.twitch.tv/directory/all/tags). The list doesn't include Category Tags.
  - `data.tags` — String[]. The tags applied to the channel.
  - `data.thumbnail_url` — String. A URL to a thumbnail of the broadcaster's profile image.
  - `data.title` — String. The stream's title. Is an empty string if the broadcaster didn't set it.
  - `data.started_at` — String. The UTC date and time (in RFC3339 format) of when the broadcaster started streaming. The string is empty if the broadcaster is not streaming live.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of channels that matched the specified query string.
- **400 Bad Request**
  - The *query* query parameter is required.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **503 Service Unavailable** — The API couldn't get the details of the matching channels. Try the request again.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/search/channels?query=twitchdev' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_language": "en",
      "broadcaster_login": "twitchdev",
      "display_name": "TwitchDev",
      "game_id": "1469308723",
      "game_name": "Software and Game Development",
      "id": "141981764",
      "is_live": false,
      "tag_ids": [],
      "tags": [
        "WebDevelopment",
        "GameDevelopment",
        "SoftwareDevelopment",
        "English"
      ],
      "thumbnail_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/8a6381c7-d0c0-4576-b179-38bd5ce1d6af-profile_image-300x300.png",
      "title": "Standard Output",
      "started_at": ""
    },
    ...
  ],
  "pagination": {
    "cursor": "Mg=="
  }
}
```
