# Goals

View information related to a creator's goals.

Source: https://dev.twitch.tv/docs/api/reference/goals/

## Get Creator Goals {#get-creator-goals}

Gets the broadcaster's list of active goals. Use this endpoint to get the current progress of each goal.

Instead of polling for the progress of a goal, consider
[subscribing](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md) to receive notifications when a goal makes progress
using the [channel.goal.progress](https://dev.twitch.tv/docs/eventsub/reference/goal.md#channel-goal-progress)
subscription type. [Read More](https://dev.twitch.tv/docs/api/goals.md#requesting-event-notifications)

### Endpoint

`GET https://api.twitch.tv/helix/goals`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:goals** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that created the goals. This ID must match the user ID in the user access token.

### Response Body

- `data` — Object[]. The list of goals. The list is empty if the broadcaster hasn't created goals.
  - `data.id` — String. An ID that identifies this goal.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that created the goal.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.type` — String. The type of goal.
    Possible values:
    - `follower`: The goal is to increase followers.
    - `subscription`: The goal is to increase subscriptions. This type shows the net increase or decrease
in tier points associated with the subscriptions.
    - `subscription_count`: The goal is to increase subscriptions. This type shows the net increase or decrease
in the number of subscriptions.
    - `new_subscription`: The goal is to increase subscriptions. This type shows only the net increase in tier
points associated with the subscriptions (it does not account for users that
unsubscribed since the goal started).
    - `new_subscription_count`: The goal is to increase subscriptions. This type shows only the net increase in the
number of subscriptions (it does not account for users that unsubscribed since the
goal started).
    - `new_bit`: The goal is to increase the amount of Bits used on the channel.
    - `new_cheerer`: The goal is to increase the amount of unique Cheerers on to Cheer on the channel.
  - `data.description` — String. A description of the goal. Is an empty string if not specified.
  - `data.current_amount` — Integer
    The goal's current value.

    The goal's `type` determines how this value is increased or decreased. 

    - If `type` is follower, this field is set to the broadcaster's current number of
    followers. This number increases with new followers and decreases when users unfollow
    the broadcaster.

    - If `type` is subscription, this field is increased and decreased by the points value
    associated with the subscription tier. For example, if a tier-two subscription is worth
    2 points, this field is increased or decreased by 2, not 1.

    - If `type` is subscription_count, this field is increased by 1 for each new
    subscription and decreased by 1 for each user that unsubscribes.

    - If `type` is new_subscription, this field is increased by the points value associated
    with the subscription tier. For example, if a tier-two subscription is worth 2 points,
    this field is increased by 2, not 1.

    - If `type` is new_subscription_count, this field is increased by 1 for each new
    subscription.

    - If `type` is new_bit, this field is increased by the number of Bits used on the
    channel.

    - If `type` is new_cheerer, this field is increased by 1 the first time each user Cheers
    on the channel after the goal starts. Other ways of using Bits don't count.
  - `data.target_amount` — Integer. The goal's target value. For example, if the broadcaster has 200 followers before creating the goal, and their goal is to double that number, this field is set to 400.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) that the broadcaster created the goal.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's goals.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:goals** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/goals?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "1woowvbkiNv8BRxEWSqmQz6Zk92",
      "broadcaster_id": "141981764",
      "broadcaster_name": "TwitchDev",
      "broadcaster_login": "twitchdev",
      "type": "follower",
      "description": "Follow goal for Helix testing",
      "current_amount": 27062,
      "target_amount": 30000,
      "created_at": "2021-08-16T17:22:23Z"
    }
  ]
}
```
