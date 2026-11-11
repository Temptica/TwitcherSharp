# Entitlements

Manage your game's Twitch Drops system using the Twitch API.

Source: https://dev.twitch.tv/docs/api/reference/entitlements/

## Contents {#contents}

2 entries on this page:

- [Get Drops Entitlements](#get-drops-entitlements)
- [Update Drops Entitlements](#update-drops-entitlements)

## Get Drops Entitlements {#get-drops-entitlements}

Gets an organization's list of entitlements that have been granted to a game, a user, or both.

The following table identifies the request parameters that you may specify based on the type of
access token used.

| Access token type | Parameter | Description |
| --- | --- | --- |
| App | None | If you don't specify request parameters, the request returns all entitlements that your organization owns. |
| App | user_id | The request returns all entitlements for any game that the organization granted to the specified user. |
| App | user_id, game_id | The request returns all entitlements that the specified game granted to the specified user. |
| App | game_id | The request returns all entitlements that the specified game granted to all entitled users. |
| User | None | If you don't specify request parameters, the request returns all entitlements for any game that the organization granted to the user identified in the access token. |
| User | user_id | The ID must match the user identified in the access token. The request returns the same entitlements as specifying no parameters. |
| User | user_id, game_id | The user ID must match the user identified in the access token. The request returns the same entitlements as specifying only game_id. |
| User | game_id | The request returns all entitlements that the specified game granted to the user identified in the access token. |

Except when you specify *id*, or both a user and a game (*user_id* and *game_id*, or *game_id*
with a user access token), the response includes only entitlements granted in the last 6 months.

> **Note** Entitlements returned in the response body data are not guaranteed to be sorted by any field returned by the API.
> To retrieve **CLAIMED** or **FULFILLED** entitlements, use the *fulfillment_status* query parameter to filter results.
> To retrieve entitlements for a specific game, use the *game_id* query parameter to filter results.

### Endpoint

`GET https://api.twitch.tv/helix/entitlements/drops`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens). The Client ID associated with the access token must be owned by a user who is a member of the [organization](https://dev.twitch.tv/docs/companies.md) that holds ownership of the game.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The Client ID associated with the access token must be owned by a user who is a member of the [organization](https://dev.twitch.tv/docs/companies.md) that holds ownership of the game.

### Query Parameters

- `id` — String
  An ID that identifies the entitlement to get. Include this parameter for each entitlement
  you want to get. For example, 'id=1234&id=5678'. You may specify a maximum of 100 IDs.

  If you specify *id*, the *user_id*, *game_id*, and *fulfillment_status* filters don't apply.
- `user_id` — String. An ID that identifies a user that was granted entitlements.
- `game_id` — String. An ID that identifies a game that offered entitlements.
- `fulfillment_status` — String. The entitlement's fulfillment status. Used to filter the list to only those with the specified status. The value is case-insensitive.
  Possible values:
  - `CLAIMED`
  - `FULFILLED`
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
- `first` — Integer. The maximum number of entitlements to return per page in the response. The minimum page size is 1 entitlement per page and the maximum is 1000. The default is 20.

### Response Body

- `data` — Object[]. The list of entitlements.
  - `data.id` — String. An ID that identifies the entitlement.
  - `data.benefit_id` — String. An ID that identifies the benefit (reward).
  - `data.timestamp` — String. The UTC date and time (in RFC3339 format) of when the entitlement was granted.
  - `data.user_id` — String. An ID that identifies the user who was granted the entitlement.
  - `data.game_id` — String. An ID that identifies the game the user was playing when the reward was entitled.
  - `data.fulfillment_status` — String. The entitlement's fulfillment status.
    Possible values:
    - `CLAIMED`
    - `FULFILLED`
  - `data.last_updated` — String. The UTC date and time (in RFC3339 format) of when the entitlement was last updated.
- `pagination` — Object. The information used to page through the list of results. The response doesn't include this object if there are no more pages left to page through, or if you specify *id*. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Set the request's *after* query parameter to this value to page forward through the results.

### Response Codes

- **200 OK** — Successfully retrieved the entitlements.
- **400 Bad Request**
  - The value in the *fulfillment_status* query parameter is not valid.
  - The ID in the *user_id* query parameter must match the user ID in the user access token.
  - The client in the access token is not associated with a known organization.
  - The owner of the client in the access token is not a member of the organization.
  - The *first* query parameter is outside the allowed range of values.
  - The request exceeds the maximum number of *id* query parameters that you may specify.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in the Client-Id header must match the Client ID in the access token.
  - The Authorization header is required and must specify an app access token or user access token.
  - The access token is not valid.
- **403 Forbidden**
  - The organization associated with the client in the access token must own the game specified in the *game_id* query parameter.
  - The organization associated with the client in the access token must own the entitlements specified in the *id* query parameter.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/entitlements/drops?user_id=25009227&game_id=33214' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "fb78259e-fb81-4d1b-8333-34a06ffc24c0",
      "benefit_id": "74c52265-e214-48a6-91b9-23b6014e8041",
      "timestamp": "2019-01-28T04:17:53.325Z",
      "user_id": "25009227",
      "game_id": "33214",
      "fulfillment_status": "CLAIMED",
      "last_updated": "2019-01-28T04:17:53.325Z"
    },
    {
      "id": "862750a5-265e-4ab6-9f0a-c64df3d54dd0",
      "benefit_id": "74c52265-e214-48a6-91b9-23b6014e8041",
      "timestamp": "2019-01-28T04:16:53.325Z",
      "user_id": "25009227",
      "game_id": "33214",
      "fulfillment_status": "CLAIMED",
      "last_updated": "2021-06-15T04:16:53.325Z"
    },
    {
      "id": "d8879baa-3966-4d10-8856-15fdd62cce02",
      "benefit_id": "cdfdc5c3-65a2-43bc-8767-fde06eb4ab2c",
      "timestamp": "2019-01-28T04:15:53.325Z",
      "user_id": "25009227",
      "game_id": "33214",
      "fulfillment_status": "FULFILLED",
      "last_updated": "2019-01-28T04:17:53.325Z"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudW..."
  }
}
```

## Update Drops Entitlements {#update-drops-entitlements}

Updates the Drop entitlement's fulfillment status.

The following table identifies which entitlements are updated based on the type of access token used.

| Access token type | Data that's updated |
| --- | --- |
| App | Updates all entitlements with benefits owned by the organization in the access token. |
| User | Updates all entitlements owned by the user in the access token and where the benefits are owned by the organization in the access token. |

### Endpoint

`PATCH https://api.twitch.tv/helix/entitlements/drops`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens). The Client ID associated with the access token must be owned by a user who is a member of the [organization](https://dev.twitch.tv/docs/companies.md) that holds ownership of the game.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The Client ID associated with the access token must be owned by a user who is a member of the [organization](https://dev.twitch.tv/docs/companies.md) that holds ownership of the game.

### Request Body

- `entitlement_ids` — String[], **Required**. A list of IDs that identify the entitlements to update. You may specify a maximum of 100 IDs.
- `fulfillment_status` — String, **Required**. The fulfillment status to set the entitlements to. The value is case-insensitive.
  Possible values:
  - `CLAIMED`: The user claimed the benefit.
  - `FULFILLED`: The developer granted the benefit that the user claimed.

### Response Body

- `data` — Object[]. A list that indicates which entitlements were successfully updated and those that weren't.
  - `data.status` — String. A string that indicates whether the status of the entitlements in the `ids` field were successfully updated.
    Possible values:
    - `INVALID_ID`: The entitlement IDs in the `ids` field are not valid.
    - `NOT_FOUND`: The entitlement IDs in the `ids` field were not found.
    - `SUCCESS`: The status of the entitlements in the `ids` field were successfully updated.
    - `UNAUTHORIZED`: The user or organization identified by the user access token is not authorized to
update the entitlements.
    - `UPDATE_FAILED`: The update failed. Attempting to change a FULFILLED entitlement back to CLAIMED using a User
Access Token will always fail. Any other failure should be retried later, or reported on our
[Issue Tracker](http://github.com/twitchdev/issues/).
  - `data.ids` — String[]. The list of entitlements that the status in the `status` field applies to.

### Response Codes

- **200 OK** — Successfully requested the updates. Check the response to determine which updates succeeded.
- **400 Bad Request**
  - The *entitlement_ids* field is required and can only contain a maximum of 100 IDs.
  - The value in the *fulfillment_status* field is not valid.
  - The client in the access token is not associated with a known organization.
  - The owner of the client in the access token is not a member of the organization.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the Client ID in the access token.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/entitlements/drops' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"fulfillment_status":"FULFILLED","entitlement_ids":["fb78259e-fb81-4d1b-8333-34a06ffc24c0","862750a5-265e-4ab6-9f0a-c64df3d54dd0","d8879baa-3966-4d10-8856-15fdd62cce02","9a290126-7e3b-4f66-a9ae-551537893b65"]}'
```

### Response Example

```json
{
  "data": [
    {
      "status": "SUCCESS",
      "ids": [
        "fb78259e-fb81-4d1b-8333-34a06ffc24c0",
        "862750a5-265e-4ab6-9f0a-c64df3d54dd0"
      ]
    },
    {
      "status": "UNAUTHORIZED",
      "ids": [
        "d8879baa-3966-4d10-8856-15fdd62cce02"
      ]
    },
    {
      "status": "UPDATE_FAILED",
      "ids": [
        "9a290126-7e3b-4f66-a9ae-551537893b65"
      ]
    }
  ]
}
```
