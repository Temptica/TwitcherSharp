# Games

Get information about categories on Twitch.

Source: https://dev.twitch.tv/docs/api/reference/games/

## Contents {#contents}

2 entries on this page:

- [Get Games](#get-games)
- [Get Top Games](#get-top-games)

## Get Games {#get-games}

Gets information about specified categories or games.

You may get up to 100 categories or games by specifying their ID or name. You may specify all IDs,
all names, or a combination of IDs and names. If you specify a combination of IDs and names, the
total number of IDs and names must not exceed 100. You must specify at least one *id*, *name*, or
*igdb_id* query parameter.

### Endpoint

`GET https://api.twitch.tv/helix/games`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `id` — String. The ID of the category or game to get. Include this parameter for each category or game you want to get. For example, '&id=1234&id=5678'. You may specify a maximum of 100 IDs. The endpoint ignores duplicate and invalid IDs or IDs that weren't found.
- `name` — String. The name of the category or game to get. The name must exactly match the category's or game's title. Include this parameter for each category or game you want to get. For example, '&name=foo&name=bar'. You may specify a maximum of 100 names. The endpoint ignores duplicate names and names that weren't found.
- `igdb_id` — String. The [IGDB](https://www.igdb.com/) ID of the game to get. Include this parameter for each game you want to get. For example, '&igdb_id=1234&igdb_id=5678'. You may specify a maximum of 100 IDs. The endpoint ignores duplicate and invalid IDs or IDs that weren't found.

### Response Body

- `data` — Object[]. The list of categories and games. The list is empty if the specified categories and games weren't found.
  - `data.id` — String. An ID that identifies the category or game.
  - `data.name` — String. The category's or game's name.
  - `data.box_art_url` — String. A URL to the category's or game's box art. You must replace the '{width}x{height}' placeholder with the size of image you want.
  - `data.igdb_id` — String. The ID that [IGDB](https://www.igdb.com/)uses to identify this game. If the IGDB ID is not available to Twitch, this field is set to an empty string.

### Response Codes

- **200 OK** — Successfully retrieved the specified games.
- **400 Bad Request**
  - The request must specify the *id* or *name* or *igdb_id* query parameter.
  - The combined number of game IDs (*id* and *igdb_id*) and game names that you specify in the request must not exceed 100.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/games?id=33214' \
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
      "box_art_url": "https://static-cdn.jtvnw.net/ttv-boxart/33214-{width}x{height}.jpg",
      "igdb_id": "1905"
    }
  ]
}
```

## Get Top Games {#get-top-games}

Gets information about the categories and games that have the most viewers on Twitch.

### Endpoint

`GET https://api.twitch.tv/helix/games/top`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of categories and games. The list is sorted by the number of viewers, with the most popular first. A page may contain fewer than *first* items even if more pages remain.
  - `data.id` — String. An ID that identifies the category or game.
  - `data.name` — String. The category's or game's name.
  - `data.box_art_url` — String. A URL to the category's or game's box art. You must replace the '{width}x{height}' placeholder with the size of image you want.
  - `data.igdb_id` — String. The ID that [IGDB](https://www.igdb.com/)uses to identify this game. If the IGDB ID is not available to Twitch, this field is set to an empty string.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of categories and games.
- **400 Bad Request**
  - The value in the *first* query parameter is not valid.
  - The cursor in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **503 Service Unavailable** — The list of games is temporarily unavailable.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/games/top' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "493057",
      "name": "PUBG: BATTLEGROUNDS",
      "box_art_url": "https://static-cdn.jtvnw.net/ttv-boxart/493057-{width}x{height}.jpg",
      "igdb_id": "27789"
    },
    ...
  ],
  "pagination":{"cursor":"eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6MjB9fQ=="}
}
```
