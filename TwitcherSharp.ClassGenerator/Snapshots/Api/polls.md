# Polls

Start, stop, and get information relating to polls on a Twitch channel.

Source: https://dev.twitch.tv/docs/api/reference/polls/

## Contents {#contents}

3 entries on this page:

- [Get Polls](#get-polls)
- [Create Poll](#create-poll)
- [End Poll](#end-poll)

## Get Polls {#get-polls}

Polls are available for 90 days after they're created.

### Endpoint

`GET https://api.twitch.tv/helix/polls`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:polls** or **channel:manage:polls** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that created the polls. This ID must match the user ID in the user access token.
- `id` — String
  A list of IDs that identify the polls to return. To specify more than one ID, include this
  parameter for each poll you want to get. For example, 'id=1234&id=5678'. You may specify a
  maximum of 20 IDs.

  Specify this parameter only if you want to filter the list that the request returns. The
  endpoint ignores duplicate IDs and those not owned by this broadcaster.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 20 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. A list of polls. The polls are returned in descending order of start time unless you specify IDs in the request, in which case they're returned in the same order as you passed them in the request. The list is empty if the broadcaster hasn't created polls.
  - `data.id` — String. An ID that identifies the poll.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the poll.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.title` — String. The question that viewers are voting on. For example, *What game should I play next?* The title may contain a maximum of 60 characters.
  - `data.choices` — Object[]. A list of choices that viewers can choose from. The list will contain a minimum of two choices and up to a maximum of five choices.
    - `data.choices.id` — String. An ID that identifies this choice.
    - `data.choices.title` — String. The choice's title. The title may contain a maximum of 25 characters.
    - `data.choices.votes` — Integer. The total number of votes cast for this choice.
    - `data.choices.channel_points_votes` — Integer. The number of votes cast using Channel Points.
  - `data.channel_points_voting_enabled` — Boolean. A Boolean value that indicates whether viewers may cast additional votes using Channel Points. For information about Channel Points, see [Channel Points Guide](https://help.twitch.tv/s/article/channel-points-guide).
  - `data.channel_points_per_vote` — Integer. The number of points the viewer must spend to cast one additional vote.
  - `data.status` — String. The poll's status.
    Possible values:
    - `ACTIVE`: The poll is running.
    - `COMPLETED`: The poll ended on schedule (see the `duration` field).
    - `TERMINATED`: The poll was terminated before its scheduled end.
    - `ARCHIVED`: The poll has been archived and is no longer visible on the channel.
    - `INVALID`: Something went wrong while determining the state.
  - `data.duration` — Integer. The length of time (in seconds) that the poll will run for.
  - `data.started_at` — String. The UTC date and time (in RFC3339 format) of when the poll began.
  - `data.ended_at` — String. The UTC date and time (in RFC3339 format) of when the poll ended. If `status` is ACTIVE, the object doesn't include this field.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's polls.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token is missing the **channel:read:polls** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header must match the client ID specified in the access token.
- **404 Not Found**
  - None of the IDs in the *id* query parameters were found.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/polls?broadcaster_id=141981764&id=ed961efd-8a3f-4cf5-a9d0-e616c590cd2a' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "ed961efd-8a3f-4cf5-a9d0-e616c590cd2a",
      "broadcaster_id": "141981764",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "title": "Heads or Tails?",
      "choices": [
        {
          "id": "4c123012-1351-4f33-84b7-43856e7a0f47",
          "title": "Heads",
          "votes": 0,
          "channel_points_votes": 0
        },
        {
          "id": "279087e3-54a7-467e-bcd0-c1393fcea4f0",
          "title": "Tails",
          "votes": 0,
          "channel_points_votes": 0
        }
      ],
      "channel_points_voting_enabled": false,
      "channel_points_per_vote": 0,
      "status": "ACTIVE",
      "duration": 1800,
      "started_at": "2021-03-19T06:08:33.871278372Z"
    }
  ],
  "pagination": {}
}
```

## Create Poll {#create-poll}

Creates a poll that viewers in the broadcaster's channel can vote on. The poll begins as soon as it's created. You may run only one poll at a time.

### Endpoint

`POST https://api.twitch.tv/helix/polls`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:polls** scope.

### Request Body

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's running the poll. This ID must match the user ID in the user access token.
- `title` — String, **Required**. The question that viewers will vote on. For example, *What game should I play next?* The question may contain a maximum of 60 characters.
- `choices` — Object[], **Required**. A list of choices that viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 5 choices.
  - `choices.title` — String, **Required**. One of the choices the viewer may select. The choice may contain a maximum of 25 characters.
- `duration` — Integer, **Required**. The length of time (in seconds) that the poll will run for. The minimum is 15 seconds and the maximum is 1800 seconds (30 minutes).
- `channel_points_voting_enabled` — Boolean. A Boolean value that indicates whether viewers may cast additional votes using Channel Points. If **true**, the viewer may cast more than one vote but each additional vote costs the number of Channel Points specified in *channel_points_per_vote*. The default is **false** (viewers may cast only one vote). For information about Channel Points, see [Channel Points Guide](https://help.twitch.tv/s/article/channel-points-guide).
- `channel_points_per_vote` — Integer. The number of points that the viewer must spend to cast one additional vote. The minimum is 1 and the maximum is 1000000. Set only if *channel_points_voting_enabled* is **true**.

### Response Body

- `data` — Object[]. A list that contains the single poll that you created.
  - `data.id` — String. An ID that identifies the poll.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the poll.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.title` — String. The question that viewers are voting on. For example, *What game should I play next?* The title may contain a maximum of 60 characters.
  - `data.choices` — Object[]. A list of choices that viewers can choose from. The list will contain a minimum of two choices and up to a maximum of five choices.
    - `data.choices.id` — String. An ID that identifies this choice.
    - `data.choices.title` — String. The choice's title. The title may contain a maximum of 25 characters.
    - `data.choices.votes` — Integer. The total number of votes cast for this choice.
    - `data.choices.channel_points_votes` — Integer. The number of votes cast using Channel Points.
  - `data.channel_points_voting_enabled` — Boolean. A Boolean value that indicates whether viewers may cast additional votes using Channel Points. For information about Channel Points, see [Channel Points Guide](https://help.twitch.tv/s/article/channel-points-guide).
  - `data.channel_points_per_vote` — Integer. The number of points the viewer must spend to cast one additional vote.
  - `data.status` — String. The poll's status.
    Possible values:
    - `ACTIVE`: The poll is running.
    - `COMPLETED`: The poll ended on schedule (see the `duration` field).
    - `TERMINATED`: The poll was terminated before its scheduled end.
    - `ARCHIVED`: The poll has been archived and is no longer visible on the channel.
    - `MODERATED`: The poll was deleted.
    - `INVALID`: Something went wrong while determining the state.
  - `data.duration` — Integer. The length of time (in seconds) that the poll will run for.
  - `data.started_at` — String. The UTC date and time (in RFC3339 format) of when the poll began.
  - `data.ended_at` — String. The UTC date and time (in RFC3339 format) of when the poll ended. If `status` is ACTIVE, the object doesn't include this field.

### Response Codes

- **200 OK** — Successfully created the poll.
- **400 Bad Request**
  - The _broadcaster\_id_ field is required.
  - The *title* field is required.
  - The *choices* field is required.
  - The *duration* field is required.
  - The value in *duration* is outside the allowed range of values.
  - The value in *channel_points_per_vote* is outside the allowed range of values.
  - The *channel_points_voting_enabled* field is **true**, but the broadcaster doesn't have Channel Points enabled.
  - The poll's *title* is too long.
  - The choice's *title* is too long.
  - The choice's *title* failed AutoMod checks.
  - The number of choices in the poll may not be less than 2 or greater that 5.
  - The broadcaster already has a poll that's running; you may not create another poll until the current poll completes.
- **401 Unauthorized**
  - The ID in _broadcaster\_id_ must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token is missing the **channel:manage:polls** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The broadcaster is not a partner or affiliate.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/polls' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"broadcaster_id":"141981764","title":"Heads or Tails?","choices":[{"title":"Heads"},{"title":"Tails"}],"channel_points_voting_enabled":true,"channel_points_per_vote":100,"duration":1800}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "ed961efd-8a3f-4cf5-a9d0-e616c590cd2a",
      "broadcaster_id": "141981764",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "title": "Heads or Tails?",
      "choices": [
        {
          "id": "4c123012-1351-4f33-84b7-43856e7a0f47",
          "title": "Heads",
          "votes": 0,
          "channel_points_votes": 0
        },
        {
          "id": "279087e3-54a7-467e-bcd0-c1393fcea4f0",
          "title": "Tails",
          "votes": 0,
          "channel_points_votes": 0
        }
      ],
      "channel_points_voting_enabled": true,
      "channel_points_per_vote": 100,
      "status": "ACTIVE",
      "duration": 1800,
      "started_at": "2021-03-19T06:08:33.871278372Z"
    }
  ]
}
```

## End Poll {#end-poll}

Ends an active poll. You have the option to end it or end it and archive it.

### Endpoint

`PATCH https://api.twitch.tv/helix/polls`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:polls** scope.

### Request Body

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's running the poll. This ID must match the user ID in the user access token.
- `id` — String, **Required**. The ID of the poll to update.
- `status` — String, **Required**. The status to set the poll to.
  Possible values:
  - `TERMINATED`: Ends the poll before the poll is scheduled to end. The poll remains publicly visible.
  - `ARCHIVED`: Ends the poll before the poll is scheduled to end, and then archives it so it's no
longer publicly visible.

### Response Body

- `data` — Object[]. A list that contains the poll that you ended.
  - `data.id` — String. An ID that identifies the poll.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the poll.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.title` — String. The question that viewers are voting on. For example, *What game should I play next?* The title may contain a maximum of 60 characters.
  - `data.choices` — Object[]. A list of choices that viewers can choose from. The list will contain a minimum of two choices and up to a maximum of five choices.
    - `data.choices.id` — String. An ID that identifies this choice.
    - `data.choices.title` — String. The choice's title. The title may contain a maximum of 25 characters.
    - `data.choices.votes` — Integer. The total number of votes cast for this choice.
    - `data.choices.channel_points_votes` — Integer. The number of votes cast using Channel Points.
  - `data.channel_points_voting_enabled` — Boolean. A Boolean value that indicates whether viewers may cast additional votes using Channel Points. For information about Channel Points, see [Channel Points Guide](https://help.twitch.tv/s/article/channel-points-guide).
  - `data.channel_points_per_vote` — Integer. The number of points the viewer must spend to cast one additional vote.
  - `data.status` — String. The poll's status.
    Possible values:
    - `ACTIVE`: The poll is running.
    - `COMPLETED`: The poll ended on schedule (see the `duration` field).
    - `TERMINATED`: The poll was terminated before its scheduled end.
    - `ARCHIVED`: The poll has been archived and is no longer visible on the channel.
    - `MODERATED`: The poll was deleted.
    - `INVALID`: Something went wrong while determining the state.
  - `data.duration` — Integer. The length of time (in seconds) that the poll will run for.
  - `data.started_at` — String. The UTC date and time (in RFC3339 format) of when the poll began.
  - `data.ended_at` — String. The UTC date and time (in RFC3339 format) of when the poll ended. If `status` is ACTIVE, the object doesn't include this field.

### Response Codes

- **200 OK** — Successfully ended the poll.
- **400 Bad Request**
  - The _broadcaster\_id_ field is required.
  - The *id* field is required.
  - The *status* field is required.
  - The value in the *status* field is not valid.
  - To terminate the poll, its status must be ACTIVE.
  - To archive the poll, its status must be ACTIVE, COMPLETED, or TERMINATED.
- **401 Unauthorized**
  - The ID in _broadcaster\_id_ must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:polls** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header must match the client ID specified in the access token.
- **403 Forbidden**
  - The poll in the *id* field belongs to another broadcaster.
  - The poll in the *id* field was deleted (its status is MODERATED).
- **404 Not Found**
  - The poll in the *id* field was not found.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/polls' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"broadcaster_id":"141981764","id":"ed961efd-8a3f-4cf5-a9d0-e616c590cd2a","status":"TERMINATED"}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "ed961efd-8a3f-4cf5-a9d0-e616c590cd2a",
      "broadcaster_id": "141981764",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "title": "Heads or Tails?",
      "choices": [
        {
          "id": "4c123012-1351-4f33-84b7-43856e7a0f47",
          "title": "Heads",
          "votes": 0,
          "channel_points_votes": 0
        },
        {
          "id": "279087e3-54a7-467e-bcd0-c1393fcea4f0",
          "title": "Tails",
          "votes": 0,
          "channel_points_votes": 0
        }
      ],
      "channel_points_voting_enabled": true,
      "channel_points_per_vote": 100,
      "status": "TERMINATED",
      "duration": 1800,
      "started_at": "2021-03-19T06:08:33.871278372Z",
      "ended_at": "2021-03-19T06:11:26.746889614Z"
    }
  ]
}
```
