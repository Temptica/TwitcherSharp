# Predictions

Start, stop, and get information relating to predictions on a Twitch channel.

Source: https://dev.twitch.tv/docs/api/reference/predictions/

## Contents {#contents}

3 entries on this page:

- [Get Predictions](#get-predictions)
- [Create Prediction](#create-prediction)
- [End Prediction](#end-prediction)

## Get Predictions {#get-predictions}

Gets a list of Channel Points Predictions that the broadcaster created.

### Endpoint

`GET https://api.twitch.tv/helix/predictions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:predictions** or **channel:manage:predictions** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose predictions you want to get. This ID must match the user ID in the user access token.
- `id` — String. The ID of the prediction to get. To specify more than one ID, include this parameter for each prediction you want to get. For example, 'id=1234&id=5678'. You may specify a maximum of 25 IDs. The endpoint ignores duplicate IDs and those not owned by the broadcaster.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 25 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The broadcaster's list of Channel Points Predictions. The list is sorted in descending order by when the prediction began (the most recent prediction is first) unless you specify IDs in the request, in which case the predictions are in the same order as the IDs. The list is empty if the broadcaster hasn't created predictions.
  - `data.id` — String. An ID that identifies this prediction.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the prediction.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.title` — String. The question that the prediction asks. For example, *Will I finish this entire pizza?*
  - `data.winning_outcome_id` — String. The ID of the winning outcome. Is **null** unless `status` is RESOLVED.
  - `data.outcomes` — Object[]. The list of possible outcomes for the prediction.
    - `data.outcomes.id` — String. An ID that identifies this outcome.
    - `data.outcomes.title` — String. The outcome's text.
    - `data.outcomes.users` — Integer. The number of unique viewers that chose this outcome.
    - `data.outcomes.channel_points` — Integer. The number of Channel Points spent by viewers on this outcome.
    - `data.outcomes.top_predictors` — Object[]. A list of viewers who were the top predictors; otherwise, **null** if none.
      - `data.outcomes.top_predictors.user_id` — String. An ID that identifies the viewer.
      - `data.outcomes.top_predictors.user_name` — String. The viewer's display name.
      - `data.outcomes.top_predictors.user_login` — String. The viewer's login name.
      - `data.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points the viewer spent.
      - `data.outcomes.top_predictors.channel_points_won` — Integer. The number of Channel Points distributed to the viewer.
    - `data.outcomes.color` — String. The color that visually identifies this outcome in the UX.
      Possible values:
      - `BLUE`
      - `PINK`
  - `data.prediction_window` — Integer. The length of time (in seconds) that the prediction will run for.
  - `data.status` — String. The prediction's status.
    Possible values:
    - `ACTIVE`: The Prediction is running and viewers can make predictions.
    - `CANCELED`: The broadcaster canceled the Prediction and refunded the Channel Points to the
participants.
    - `LOCKED`: The broadcaster locked the Prediction, which means viewers can no longer make
predictions.
    - `RESOLVED`: The winning outcome was determined and the Channel Points were distributed to the
viewers who predicted the correct outcome.
  - `data.created_at` — String. The UTC date and time of when the Prediction began.
  - `data.ended_at` — String. The UTC date and time of when the Prediction ended. If `status` is ACTIVE, this is set to **null**.
  - `data.locked_at` — String. The UTC date and time of when the Prediction was locked. Is **null** if the Prediction hasn't been locked.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of predictions.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:predictions** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/predictions?broadcaster_id=55696719&id=d6676d5c-c86e-44d2-bfc4-100fb48f0656' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "d6676d5c-c86e-44d2-bfc4-100fb48f0656",
      "broadcaster_id": "55696719",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "title": "Will there be any leaks today?",
      "winning_outcome_id": null,
      "outcomes": [
        {
          "id": "021e9234-5893-49b4-982e-cfe9a0aaddd9",
          "title": "Yes",
          "users": 0,
          "channel_points": 0,
          "top_predictors": null,
          "color": "BLUE"
        },
        {
          "id": "ded84c26-13cb-4b48-8cb5-5bae3ec3a66e",
          "title": "No",
          "users": 0,
          "channel_points": 0,
          "top_predictors": null,
          "color": "PINK"
        }
      ],
      "prediction_window": 600,
      "status": "ACTIVE",
      "created_at": "2021-04-28T16:03:06.320848689Z",
      "ended_at": null,
      "locked_at": null
    }
  ],
  "pagination": {}
}
```

## Create Prediction {#create-prediction}

Creates a Channel Points Prediction.

With a Channel Points Prediction, the broadcaster poses a question and viewers try to predict the
outcome. The prediction runs as soon as it's created. The broadcaster may run only one prediction
at a time.

### Endpoint

`POST https://api.twitch.tv/helix/predictions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:predictions** scope.

### Request Body

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's running the prediction. This ID must match the user ID in the user access token.
- `title` — String, **Required**. The question that the broadcaster is asking. For example, *Will I finish this entire pizza?* The title is limited to a maximum of 45 characters.
- `outcomes` — Object[], **Required**. The list of possible outcomes that the viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 10 choices.
  - `outcomes.title` — String, **Required**. The text of one of the outcomes that the viewer may select. The title is limited to a maximum of 25 characters.
- `prediction_window` — Integer, **Required**. The length of time (in seconds) that the prediction will run for. The minimum is 1 second and the maximum is 1800 seconds (30 minutes).

### Response Body

- `data` — Object[]. A list that contains the single prediction that you created.
  - `data.id` — String. An ID that identifies this prediction.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the prediction.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.title` — String. The question that the prediction asks. For example, *Will I finish this entire pizza?*
  - `data.winning_outcome_id` — String. The ID of the winning outcome. Is **null** unless `status` is RESOLVED.
  - `data.outcomes` — Object[]. The list of possible outcomes for the prediction.
    - `data.outcomes.id` — String. An ID that identifies this outcome.
    - `data.outcomes.title` — String. The outcome's text.
    - `data.outcomes.users` — Integer. The number of unique viewers that chose this outcome.
    - `data.outcomes.channel_points` — Integer. The number of Channel Points spent by viewers on this outcome.
    - `data.outcomes.top_predictors` — Object[]. A list of viewers who were the top predictors; otherwise, **null** if none.
      - `data.outcomes.top_predictors.user_id` — String. An ID that identifies the viewer.
      - `data.outcomes.top_predictors.user_name` — String. The viewer's display name.
      - `data.outcomes.top_predictors.user_login` — String. The viewer's login name.
      - `data.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points the viewer spent.
      - `data.outcomes.top_predictors.channel_points_won` — Integer. The number of Channel Points distributed to the viewer.
    - `data.outcomes.color` — String. The color that visually identifies this outcome in the UX. If the prediction has two outcomes, the first outcome is BLUE and the second is PINK. If it has more than two outcomes, all of them are BLUE.
      Possible values:
      - `BLUE`
      - `PINK`
  - `data.prediction_window` — Integer. The length of time (in seconds) that the prediction will run for.
  - `data.status` — String. The prediction's status.
    Possible values:
    - `ACTIVE`: The Prediction is running and viewers can make predictions.
    - `CANCELED`: The broadcaster canceled the Prediction and refunded the Channel Points to the
participants.
    - `LOCKED`: The broadcaster locked the Prediction, which means viewers can no longer make
predictions.
    - `RESOLVED`: The winning outcome was determined and the Channel Points were distributed to the
viewers who predicted the correct outcome.
  - `data.created_at` — String. The UTC date and time of when the Prediction began.
  - `data.ended_at` — String. The UTC date and time of when the Prediction ended. If `status` is ACTIVE, this is set to **null**.
  - `data.locked_at` — String. The UTC date and time of when the Prediction was locked. Is **null** if the Prediction hasn't been locked.

### Response Codes

- **200 OK** — Successfully created the Channel Points Prediction.
- **400 Bad Request**
  - The _broadcaster\_id_ field is required.
  - The *title* field is required.
  - The *outcomes* field is required.
  - The *prediction_window* field is required.
  - The value in *prediction_window* is outside the allowed range of values.
  - The prediction's *title* is too long.
  - The outcome's *title* field is required.
  - The outcome's *title* is too long.
  - The outcome's *title* failed AutoMod checks.
  - The number of outcomes in the prediction may not be less than 2 or greater than 10.
  - The broadcaster must have Channel Points enabled.
  - The broadcaster already has a prediction that's running; you may not create another prediction until the current prediction is resolved or canceled.
- **401 Unauthorized**
  - The ID in _broadcaster\_id_ must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:predictions** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **429 Too Many Requests**

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/predictions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"broadcaster_id":"141981764","title":"Any leeks in the stream?","outcomes":[{"title":"Yes, give it time."},{"title":"Definitely not."}],"prediction_window":120}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "bc637af0-7766-4525-9308-4112f4cbf178",
      "broadcaster_id": "141981764",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "title": "Any leeks in the stream?",
      "winning_outcome_id": null,
      "outcomes": [
        {
          "id": "73085848-a94d-4040-9d21-2cb7a89374b7",
          "title": "Yes, give it time.",
          "users": 0,
          "channel_points": 0,
          "top_predictors": null,
          "color": "BLUE"
        },
        {
          "id": "906b70ba-1f12-47ea-9e95-e5f93d20e9cc",
          "title": "Definitely not.",
          "users": 0,
          "channel_points": 0,
          "top_predictors": null,
          "color": "PINK"
        }
      ],
      "prediction_window": 120,
      "status": "ACTIVE",
      "created_at": "2021-04-28T17:11:22.595914172Z",
      "ended_at": null,
      "locked_at": null
    }
  ]
}
```

## End Prediction {#end-prediction}

Locks, resolves, or cancels a Channel Points Prediction.

### Endpoint

`PATCH https://api.twitch.tv/helix/predictions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:predictions** scope.

### Request Body

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's running the prediction. This ID must match the user ID in the user access token.
- `id` — String, **Required**. The ID of the prediction to update.
- `status` — String, **Required**. The status to set the prediction to.
  Possible values:
  - `RESOLVED`: The winning outcome is determined and the Channel Points are distributed to the viewers
who predicted the correct outcome.
  - `CANCELED`: The broadcaster is canceling the prediction and sending refunds to the participants.
  - `LOCKED`: The broadcaster is locking the prediction, which means viewers may no longer make
predictions.
- `winning_outcome_id` — String. The ID of the winning outcome. You must set this parameter if you set *status* to RESOLVED.

### Response Body

- `data` — Object[]. A list that contains the single prediction that you updated.
  - `data.id` — String. An ID that identifies this prediction.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the prediction.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.title` — String. The question that the prediction asks. For example, *Will I finish this entire pizza?*
  - `data.winning_outcome_id` — String. The ID of the winning outcome. Is **null** unless `status` is RESOLVED.
  - `data.outcomes` — Object[]. The list of possible outcomes for the prediction.
    - `data.outcomes.id` — String. An ID that identifies this outcome.
    - `data.outcomes.title` — String. The outcome's text.
    - `data.outcomes.users` — Integer. The number of unique viewers that chose this outcome.
    - `data.outcomes.channel_points` — Integer. The number of Channel Points spent by viewers on this outcome.
    - `data.outcomes.top_predictors` — Object[]. A list of viewers who were the top predictors; otherwise, **null** if none.
      - `data.outcomes.top_predictors.user_id` — String. An ID that identifies the viewer.
      - `data.outcomes.top_predictors.user_name` — String. The viewer's display name.
      - `data.outcomes.top_predictors.user_login` — String. The viewer's login name.
      - `data.outcomes.top_predictors.channel_points_used` — Integer. The number of Channel Points the viewer spent.
      - `data.outcomes.top_predictors.channel_points_won` — Integer. The number of Channel Points distributed to the viewer.
    - `data.outcomes.color` — String. The color that visually identifies this outcome in the UX.
      Possible values:
      - `BLUE`
      - `PINK`
  - `data.prediction_window` — Integer. The length of time (in seconds) that the prediction will run for.
  - `data.status` — String. The prediction's status.
    Possible values:
    - `ACTIVE`: The Prediction is running and viewers can make predictions.
    - `CANCELED`: The broadcaster canceled the Prediction and refunded the Channel Points to the
participants.
    - `LOCKED`: The broadcaster locked the Prediction, which means viewers can no longer make
predictions.
    - `RESOLVED`: The winning outcome was determined and the Channel Points were distributed to the
viewers who predicted the correct outcome.
  - `data.created_at` — String. The UTC date and time of when the Prediction began.
  - `data.ended_at` — String. The UTC date and time of when the Prediction ended. If `status` is ACTIVE, this is set to **null**.
  - `data.locked_at` — String. The UTC date and time of when the Prediction was locked. Is **null** if the Prediction hasn't been locked.

### Response Codes

- **200 OK** — Successfully ended the prediction.
- **400 Bad Request**
  - The _broadcaster\_id_ field is required.
  - The *id* field is required.
  - The *status* field is required.
  - The *winning_outcome_id* field is required if *status* is RESOLVED.
  - The value in the *status* field is not valid.
  - To update the prediction's status to RESOLVED or CANCELED, its current status must be ACTIVE or LOCKED.
  - To update the prediction's status to LOCKED, its current status must be ACTIVE.
- **401 Unauthorized**
  - The ID in _broadcaster\_id_ must match the user ID in the OAuth token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:predictions** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The prediction in the *id* field belongs to another broadcaster.
- **404 Not Found**
  - The prediction in the *id* field was not found.
  - The outcome in the *winning_outcome_id* field was not found.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/predictions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"broadcaster_id":"141981764","id":"bc637af0-7766-4525-9308-4112f4cbf178","status":"RESOLVED","winning_outcome_id":"73085848-a94d-4040-9d21-2cb7a89374b7"}'
```

### Response Example

```json
{
  "data": [
    {
      "id": "bc637af0-7766-4525-9308-4112f4cbf178",
      "broadcaster_id": "141981764",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "title": "Will we win all the games?",
      "winning_outcome_id": "73085848-a94d-4040-9d21-2cb7a89374b7",
      "outcomes": [
        {
          "id": "73085848-a94d-4040-9d21-2cb7a89374b7",
          "title": "yes",
          "users": 0,
          "channel_points": 0,
          "top_predictors": null,
          "color": "BLUE"
        },
        {
          "id": "86010b2e-9764-4136-9359-fd1c9c5a8033",
          "title": "no",
          "users": 0,
          "channel_points": 0,
          "top_predictors": null,
          "color": "PINK"
        }
      ],
      "prediction_window": 120,
      "status": "RESOLVED",
      "created_at": "2021-04-28T21:48:19.480371331Z",
      "ended_at": "2021-04-28T21:54:24.026833954Z",
      "locked_at": "2021-04-28T21:48:34.636685705Z"
    }
  ]
}
```
