# Hype Train

View information related a channel's ongoing Hype Train.

Source: https://dev.twitch.tv/docs/api/reference/hype-train/

## Get Hype Train Status {#get-hype-train-status}

Get the status of a Hype Train for the specified broadcaster.

### Endpoint

`GET https://api.twitch.tv/helix/hypetrain/status`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:hype_train** scope. The User ID associated with the token must match the _broadcaster\_id_ in the query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The User ID of the channel broadcaster.

### Response Body

- `data` — Object[]. A list that contains information related to the channel's Hype Train.
  - `data.current` — Object. An object describing the current Hype Train. Null if a Hype Train is not active.
    - `data.current.id` — String. The Hype Train ID.
    - `data.current.broadcaster_user_id` — String. The broadcaster ID.
    - `data.current.broadcaster_user_login` — String. The broadcaster login.
    - `data.current.broadcaster_user_name` — String. The broadcaster display name.
    - `data.current.level` — Integer. The current level of the Hype Train.
    - `data.current.total` — Integer. Total points contributed to the Hype Train.
    - `data.current.progress` — Integer. The number of points contributed to the Hype Train at the current level.
    - `data.current.goal` — Integer. The number of points required to reach the next level.
    - `data.current.top_contributions` — Object[]. The contributors with the most points contributed.
      - `data.current.top_contributions.user_id` — String. The ID of the user that made the contribution.
      - `data.current.top_contributions.user_login` — String. The user's login name.
      - `data.current.top_contributions.user_name` — String. The user's display name.
      - `data.current.top_contributions.type` — String. The contribution method used.
        Possible values:
        - `bits`: Cheering with Bits.
        - `subscription`: Subscription activity like subscribing or gifting subscriptions.
        - `other`: Covers other contribution methods not listed.
      - `data.current.top_contributions.total` — Integer. The total number of points contributed for the type.
    - `data.current.shared_train_participants` — Object[]. A list containing the broadcasters participating in the shared Hype Train. Null if the Hype Train is not shared.
      - `data.current.shared_train_participants.broadcaster_user_id` — String. The broadcaster ID.
      - `data.current.shared_train_participants.broadcaster_user_login` — String. The broadcaster login.
      - `data.current.shared_train_participants.broadcaster_user_name` — String. The broadcaster display name.
    - `data.current.started_at` — String. The time when the Hype Train started.
    - `data.current.expires_at` — String. The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
    - `data.current.type` — String. The type of the Hype Train.
      Possible values:
      - `treasure`
      - `golden_kappa`
      - `regular`
    - `data.current.is_shared_train` — Boolean. Indicates if the Hype Train is shared. When true, shared_train_participants will contain the list of broadcasters the train is shared with.
  - `data.all_time_high` — Object. An object with information about the channel's Hype Train records. Null if a Hype Train has not occurred.
    - `data.all_time_high.level` — Integer. The level of the record Hype Train.
    - `data.all_time_high.total` — Integer. Total points contributed to the record Hype Train.
    - `data.all_time_high.achieved_at` — String. The time when the record was achieved.
  - `data.shared_all_time_high` — Object. An object with information about the channel's shared Hype Train records. Null if the channel hasn't taken part in a shared Hype Train.
    - `data.shared_all_time_high.level` — Integer. The level of the record Hype Train.
    - `data.shared_all_time_high.total` — Integer. Total points contributed to the record Hype Train.
    - `data.shared_all_time_high.achieved_at` — String. The time when the record was achieved.

### Response Codes

- **200 OK** — Successfully retrieved the status object.
- **400 Bad Request** — The ID in the _broadcaster\_id_ query parameter is not valid.
- **401 Unauthorized**
  - The OAuth token is not valid.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:hype_train** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
- **500 Internal Error** — Internal Server Error.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/hypetrain/status?broadcaster_id=123' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "current": {
        "id": "1b0AsbInCHZW2SQFQkCzqN07Ib2",
        "broadcaster_user_id": "1337",
        "broadcaster_user_login": "cool_user",
        "broadcaster_user_name": "Cool_User",
        "level": 2,
        "total": 700,
        "progress": 200,
        "goal": 1000,
        "top_contributions": [
          {
            "user_id": "123",
            "user_login": "pogchamp",
            "user_name": "PogChamp",
            "type": "bits",
            "total": 50
          },
          {
            "user_id": "456",
            "user_login": "kappa",
            "user_name": "Kappa",
            "type": "subscription",
            "total": 45
          }
        ],
        "shared_train_participants": [
          {
            "broadcaster_user_id": "456",
            "broadcaster_user_login": "pogchamp",
            "broadcaster_user_name": "PogChamp"
          },
          {
            "broadcaster_user_id": "321",
            "broadcaster_user_login": "pogchamp",
            "broadcaster_user_name": "PogChamp"
          }
        ],
        "started_at": "2020-07-15T17:16:03.17106713Z",
        "expires_at": "2020-07-15T17:16:11.17106713Z",
        "type": "golden_kappa",
        "is_shared_train": true
      },
      "all_time_high": {
        "level": 6,
        "total": 2850,
        "achieved_at": "2020-04-24T20:12:21.003802269Z"
      },
      "shared_all_time_high": {
        "level": 16,
        "total": 23850,
        "achieved_at": "2020-04-27T20:12:21.003802269Z"
      }
    }
  ]
}
```
