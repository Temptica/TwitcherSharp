# Teams

Get information related to Twitch Teams.

Source: https://dev.twitch.tv/docs/api/reference/teams/

## Contents {#contents}

2 entries on this page:

- [Get Teams](#get-teams)
- [Get Channel Teams](#get-channel-teams)

## Get Teams {#get-teams}

Gets information about the specified Twitch team. [Read More](https://help.twitch.tv/s/article/twitch-teams)

You must specify exactly one of the *name* and *id* query parameters; the request fails if you
specify none of them or more than one.

### Endpoint

`GET https://api.twitch.tv/helix/teams`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `name` — String. The name of the team to get. This parameter and the *id* parameter are mutually exclusive; you must specify the team's name or ID but not both.
- `id` — String. The ID of the team to get. This parameter and the *name* parameter are mutually exclusive; you must specify the team's name or ID but not both.

### Response Body

- `data` — Object[]. A list that contains the single team that you requested.
  - `data.users` — Object[]. The list of team members. This field is omitted if the team has no members.
    - `data.users.user_id` — String. An ID that identifies the team member.
    - `data.users.user_login` — String. The team member's login name.
    - `data.users.user_name` — String. The team member's display name.
  - `data.background_image_url` — String, Nullable. A URL to the team's background image. This field is **null** if the team does not have a background image set.
  - `data.banner` — String, Nullable. A URL to the team's banner. This field is **null** if the team does not have a banner image set.
  - `data.created_at` — String, Nullable. The UTC date and time (in RFC3339 format) of when the team was created.
  - `data.updated_at` — String, Nullable. The UTC date and time (in RFC3339 format) of the last time the team was updated.
  - `data.info` — String. The team's description. The description may contain formatting such as Markdown, HTML, newline (\\n) characters, etc.
  - `data.thumbnail_url` — String, Nullable. A URL to a thumbnail image of the team's logo. This field is **null** if the team does not have a logo set.
  - `data.team_name` — String. The team's name.
  - `data.team_display_name` — String. The team's display name.
  - `data.id` — String. An ID that identifies the team.

### Response Codes

- **200 OK** — Successfully retrieved the team's information.
- **400 Bad Request**
  - The *name* or *id* query parameter is required.
  - Specify either the *name* or *id* query parameter but not both.
  - The ID in the *id* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header must contain an app access token or user access token.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The specified team was not found.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/teams?id=6358' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "users": [
        {
          "user_id": "278217731",
          "user_name": "mastermndio",
          "user_login": "mastermndio"
        },
        {
          "user_id": "41284990",
          "user_name": "jenninexus",
          "user_login": "jenninexus"
        },
        ...
      ],
      "background_image_url": null,
      "banner": null,
      "created_at": "2019-02-11T12:09:22Z",
      "updated_at": "2020-11-18T15:56:41Z",
      "info": "<p>An outgoing and enthusiastic group of friendly channels that write code, teach about technology, and promote the technical community.</p>",
      "thumbnail_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/team-livecoders-team_logo_image-bf1d9a87ca81432687de60e24ad9593d-600x600.png",
      "team_name": "livecoders",
      "team_display_name": "Live Coders",
      "id": "6358"
    }
  ]
}
```

## Get Channel Teams {#get-channel-teams}

Gets the list of Twitch teams that the broadcaster is a member of.

### Endpoint

`GET https://api.twitch.tv/helix/teams/channel`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose teams you want to get.

### Response Body

- `data` — Object[]. The list of teams that the broadcaster is a member of. Returns an empty array if the broadcaster is not a member of a team.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.background_image_url` — String, Nullable. A URL to the team's background image. This field is **null** if the team does not have a background image set.
  - `data.banner` — String, Nullable. A URL to the team's banner. This field is **null** if the team does not have a banner set.
  - `data.created_at` — String, Nullable. The UTC date and time (in RFC3339 format) of when the team was created.
  - `data.updated_at` — String, Nullable. The UTC date and time (in RFC3339 format) of the last time the team was updated.
  - `data.info` — String. The team's description. The description may contain formatting such as Markdown, HTML, newline (\\n) characters, etc.
  - `data.thumbnail_url` — String, Nullable. A URL to a thumbnail image of the team's logo. This field is **null** if the team does not have a logo set.
  - `data.team_name` — String. The team's name.
  - `data.team_display_name` — String. The team's display name.
  - `data.id` — String. An ID that identifies the team.

### Response Codes

- **200 OK** — Successfully retrieved the list of teams.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is missing or invalid.
- **401 Unauthorized**
  - The Authorization header must contain an app access token or user access token.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - The broadcaster was not found.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/teams/channel?broadcaster_id=96909659' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "96909659",
      "broadcaster_name": "CSharpFritz",
      "broadcaster_login": "csharpfritz",
      "background_image_url": null,
      "banner": null,
      "created_at": "2019-02-11T12:09:22Z",
      "updated_at": "2020-11-18T15:56:41Z",
      "info": "<p>An outgoing and enthusiastic group of friendly channels that write code, teach\nabout technology, and promote the technical community.</p>",
      "thumbnail_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/team-livecoders-team_logo_image-bf1d9a87ca81432687de60e24ad9593d-600x600.png",
      "team_name": "livecoders",
      "team_display_name": "Live Coders",
      "id": "6358"
    }
  ]
}
```
