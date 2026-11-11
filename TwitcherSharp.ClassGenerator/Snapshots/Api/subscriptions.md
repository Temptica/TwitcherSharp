# Subscriptions

Get information related to subscriptions on a Twitch channel.

Source: https://dev.twitch.tv/docs/api/reference/subscriptions/

## Contents {#contents}

2 entries on this page:

- [Get Broadcaster Subscriptions](#get-broadcaster-subscriptions)
- [Check User Subscription](#check-user-subscription)

## Get Broadcaster Subscriptions {#get-broadcaster-subscriptions}

Gets a list of users that subscribe to the specified broadcaster.

### Endpoint

`GET https://api.twitch.tv/helix/subscriptions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:subscriptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). Only accessible to Twitch Extensions. The broadcaster must have granted the **channel:read:subscriptions** scope from within the Twitch Extensions manager.

### Query Parameters

- `broadcaster_id` — String, **Required**. The broadcaster's ID. This ID must match the user ID in the access token.
- `user_id` — String. Filters the list to include only the specified subscribers. To specify more than one subscriber, include this parameter for each subscriber. For example, '&user_id=1234&user_id=5678'. You may specify a maximum of 100 subscribers.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. Do not specify if you set the *user_id* query parameter. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
- `before` — String. The cursor used to get the previous page of results. Do not specify if you set the *user_id* query parameter. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of users that subscribe to the broadcaster. The list is empty if the broadcaster has no subscribers. Some subscriptions aren't included, such as those from users whose accounts no longer exist, so a page may contain fewer than *first* items, or none, and still contain a cursor.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.gifter_id` — String. The ID of the user that gifted the subscription to the user. Is an empty string if `is_gift` is **false**. For an anonymous gift, the ID is 274598607, which identifies the ananonymousgifter account.
  - `data.gifter_login` — String. The gifter's login name. Is an empty string if `is_gift` is **false**.
  - `data.gifter_name` — String. The gifter's display name. Is an empty string if `is_gift` is **false**.
  - `data.is_gift` — Boolean. A Boolean value that determines whether the subscription is a gift subscription. Is **true** if the subscription was gifted.
  - `data.plan_name` — String. The name of the subscription.
  - `data.tier` — String. The type of subscription.
    Possible values:
    - `1000`: Tier 1
    - `2000`: Tier 2
    - `3000`: Tier 3
  - `data.user_id` — String. An ID that identifies the subscribing user.
  - `data.user_name` — String. The user's display name.
  - `data.user_login` — String. The user's login name.
- `pagination` — Object. Contains the information used to page through the list of results. The object contains a cursor even on the last page of subscriptions; using that cursor returns no subscriptions and an empty object. The response doesn't include this object if you specify the *user_id* query parameter. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next or previous page of results. Use the cursor to set the request's *after* or *before* query parameter depending on whether you're paging forwards or backwards.
- `points` — Integer
  The current number of subscriber points earned by this broadcaster. Points are based on the
  subscription tier of each user that subscribes to this broadcaster. For example, a Tier 1
  subscription is worth 1 point, Tier 2 is worth 2 points, and Tier 3 is worth 6 points. The
  number of points determines the number of emote slots that are unlocked for the broadcaster
  (see [Subscriber Emote Slots](https://help.twitch.tv/s/article/subscriber-emote-guide#emoteslots)).

  The response doesn't include this field if you specify the *user_id* query parameter.
- `total` — Integer. The total number of users that subscribe to this broadcaster. The response doesn't include this field if you specify the *user_id* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of subscribers.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The request may specify either the *before* or *after* query parameter but not both.
  - The cursor specified in the *before* or *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID found in the request's OAuth token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:subscriptions** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/subscriptions?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "141981764",
      "broadcaster_login": "twitchdev",
      "broadcaster_name": "TwitchDev",
      "gifter_id": "12826",
      "gifter_login": "twitch",
      "gifter_name": "Twitch",
      "is_gift": true,
      "tier": "1000",
      "plan_name": "Channel Subscription (twitchdev)",
      "user_id": "527115020",
      "user_name": "twitchgaming",
      "user_login": "twitchgaming"
    },
    ...
  ],
  "pagination": {
    "cursor": "xxxx"
  },
  "total": 13,
  "points": 13
}
```

## Check User Subscription {#check-user-subscription}

Checks whether the user subscribes to the broadcaster's channel.

### Endpoint

`GET https://api.twitch.tv/helix/subscriptions/user`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:subscriptions** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:subscriptions** scope for the user represented by the *user_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of a partner or affiliate broadcaster.
- `user_id` — String, **Required**. The ID of the user that you're checking to see whether they subscribe to the broadcaster in *broadcaster_id*. If you use a user access token, this ID must match the user ID in the token.

### Response Body

- `data` — Object[]. A list that contains a single object with information about the user's subscription.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.gifter_id` — String. The ID of the user that gifted the subscription. The object includes this field only if `is_gift` is **true**. For an anonymous gift, the ID is 274598607, which identifies the ananonymousgifter account.
  - `data.gifter_login` — String. The gifter's login name. The object includes this field only if `is_gift` is **true**.
  - `data.gifter_name` — String. The gifter's display name. The object includes this field only if `is_gift` is **true**.
  - `data.is_gift` — Boolean. A Boolean value that determines whether the subscription is a gift subscription. Is **true** if the subscription was gifted.
  - `data.tier` — String. The type of subscription.
    Possible values:
    - `1000`: Tier 1
    - `2000`: Tier 2
    - `3000`: Tier 3

### Response Codes

- **200 OK** — The user subscribes to the broadcaster.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *user_id* query parameter is required.
- **401 Unauthorized**
  - The ID in *user_id* must match the user ID found in the request's OAuth token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **user:read:subscriptions** scope.
  - If you use an app access token, the user in *user_id* must have authorized your app with the **user:read:subscriptions** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - Access to this subscription is blocked. Some Twitch subscription products aren't available through the API.
- **404 Not Found**
  - The user in *user_id* does not subscribe to the broadcaster in *broadcaster_id*.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/subscriptions/user?broadcaster_id=149747285&user_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "149747285",
      "broadcaster_name": "TwitchPresents",
      "broadcaster_login": "twitchpresents",
      "is_gift": false,
      "tier": "1000"
    }
  ]
}
```
