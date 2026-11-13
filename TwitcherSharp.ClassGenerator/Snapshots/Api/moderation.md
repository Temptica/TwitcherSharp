# Moderation

Manage a Twitch channel's moderation settings, including banning and warning users.

Source: https://dev.twitch.tv/docs/api/reference/moderation/

## Contents {#contents}

25 entries on this page:

- [Get VIPs](#get-vips)
- [Add Channel VIP](#add-channel-vip)
- [Remove Channel VIP](#remove-channel-vip)
- [Manage Held AutoMod Messages](#manage-held-automod-messages)
- [Get AutoMod Settings](#get-automod-settings)
- [Update AutoMod Settings](#update-automod-settings)
- [Get Banned Users](#get-banned-users)
- [Ban User](#ban-user)
- [Unban User](#unban-user)
- [Get Blocked Terms](#get-blocked-terms)
- [Add Blocked Term](#add-blocked-term)
- [Remove Blocked Term](#remove-blocked-term)
- [Get Moderated Channels](#get-moderated-channels)
- [Delete Chat Messages](#delete-chat-messages)
- [Check AutoMod Status](#check-automod-status)
- [Get Moderators](#get-moderators)
- [Add Channel Moderator](#add-channel-moderator)
- [Remove Channel Moderator](#remove-channel-moderator)
- [Get Shield Mode Status](#get-shield-mode-status)
- [Update Shield Mode Status](#update-shield-mode-status)
- [Add Suspicious Status to Chat User](#add-suspicious-status-to-chat-user)
- [Remove Suspicious Status From Chat User](#remove-suspicious-status-from-chat-user)
- [Get Unban Requests](#get-unban-requests)
- [Resolve Unban Requests](#resolve-unban-requests)
- [Warn Chat User](#warn-chat-user)

## Get VIPs {#get-vips}

Gets a list of the broadcaster's VIPs.

### Endpoint

`GET https://api.twitch.tv/helix/channels/vips`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:vips** or **channel:manage:vips** scope.

### Query Parameters

- `user_id` — String. Filters the list for specific VIPs. To specify more than one user, include the *user_id* parameter for each user to get. For example, '&user_id=1234&user_id=5678'. The maximum number of IDs that you may specify is 100. Ignores the ID of those users in the list that aren't VIPs.
- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose list of VIPs you want to get. This ID must match the user ID in the access token.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100. The default is 20. Ignored if you specify *user_id*.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. Ignored if you specify *user_id*. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of VIPs. The list is empty if the broadcaster doesn't have VIP users.
  - `data.user_id` — String. An ID that uniquely identifies the VIP user.
  - `data.user_name` — String. The user's display name.
  - `data.user_login` — String. The user's login name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if the page contains no VIPs or you specified *user_id*. The last page of VIPs still contains a cursor; using it returns an empty page. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of VIPs.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The ID in the *user_id* query parameter is not valid.
  - The number of *user_id* query parameters exceeds the maximum allowed.
  - The *first* query parameter is outside the allowed range of values.
  - The pagination cursor is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:vips** or **channel:manage:vips** scope.
  - The OAuth token is not valid.
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channels/vips?broadcaster_id=123' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "11111",
      "user_name": "UserDisplayName",
      "user_login": "userloginname"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"
  }
}
```

## Add Channel VIP {#add-channel-vip}

Adds the specified user as a VIP in the broadcaster's channel.

**Rate Limits**: The broadcaster may add a maximum of 10 VIPs within a 10-second window.

### Endpoint

`POST https://api.twitch.tv/helix/channels/vips`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:vips** scope.

### Query Parameters

- `user_id` — String, **Required**. The ID of the user to give VIP status to.
- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's adding the user as a VIP. This ID must match the user ID in the access token.

### Response Codes

- **204 No Content** — Successfully added the VIP.
- **400 Bad Request**
  - The user in the *user_id* query parameter is banned from the broadcaster's channel.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:vips** scope.
  - The OAuth token is not valid.
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **404 Not Found**
  - The ID in *broadcaster_id* was not found.
  - The ID in *user_id* was not found.
- **409 Conflict** — The broadcaster doesn't have available VIP slots. [Read More](https://help.twitch.tv/s/article/Managing-Roles-for-your-Channel?language=en_US#types)
- **422 Unprocessable Entity**
  - The user in *user_id* is a moderator. To make them a VIP, you must first remove them as a moderator (see [Remove Channel Moderator](https://dev.twitch.tv/docs/api/reference/moderation.md#remove-channel-moderator)).
  - The user in the *user_id* query parameter is already a VIP.
- **429 Too Many Requests** — The broadcaster exceeded the number of VIP that they may add within a 10-second window. See Rate Limits for this endpoint above.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/channels/vips?broadcaster_id=123&user_id=456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Remove Channel VIP {#remove-channel-vip}

Removes the specified user as a VIP in the broadcaster's channel.

If the broadcaster is removing the user's VIP status, the ID in the *broadcaster_id* query
parameter must match the user ID in the access token; otherwise, if the user is removing their VIP
status themselves, the ID in the *user_id* query parameter must match the user ID in the access
token.

**Rate Limits**: The broadcaster may remove a maximum of 10 VIPs within a 10-second window.

### Endpoint

`DELETE https://api.twitch.tv/helix/channels/vips`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:vips** scope.

### Query Parameters

- `user_id` — String, **Required**. The ID of the user to remove VIP status from.
- `broadcaster_id` — String, **Required**. The ID of the broadcaster who owns the channel where the user has VIP status.

### Response Codes

- **204 No Content** — Successfully removed the VIP status from the user.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *user_id* query parameter is required.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:vips** scope.
  - The OAuth token is not valid.
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token, unless the user ID in the access token is removing themselves as a VIP.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **404 Not Found**
  - The ID in *broadcaster_id* was not found.
- **422 Unprocessable Entity**
  - The user in *user_id* is not a VIP in the broadcaster's channel.
- **429 Too Many Requests** — The broadcaster exceeded the number of VIPs that they may remove within a 10-second window. See Rate Limits for this endpoint above.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/channels/vips?broadcaster_id=123&user_id=456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Manage Held AutoMod Messages {#manage-held-automod-messages}

Allow or deny the message that AutoMod flagged for review.

For information about AutoMod, see [How to Use AutoMod](https://help.twitch.tv/s/article/how-to-use-automod).

### Endpoint

`POST https://api.twitch.tv/helix/moderation/automod/message`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod** scope for the user represented by the *user_id* body field.

### Request Body

- `user_id` — String, **Required**. The moderator who is approving or denying the held message. This ID must match the user ID in the access token.
- `msg_id` — String, **Required**. The ID of the message to allow or deny.
- `action` — String, **Required**. The action to take for the message. The value is case insensitive.
  Possible values:
  - `ALLOW`
  - `DENY`

### Response Codes

- **204 No Content** — Successfully approved or denied the message.
- **400 Bad Request**
  - The value in the *action* field is not valid.
  - The _user\_id_ field is required.
  - The *msg_id* field is required.
  - The *action* field is required.
  - The message was already allowed or denied, or it can't be allowed (for example, because it expired).
  - The message's status was changed by another request at the same time.
- **401 Unauthorized**
  - The ID in _user\_id_ must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:automod** scope.
  - If you use an app access token, the user in *user_id* must have authorized your app with the **moderator:manage:automod** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *user_id* is not one of the broadcaster's moderators.
- **404 Not Found**
  - The message specified in the *msg_id* field was not found.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/automod/message' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"user_id":"9327994","msg_id":"836013710","action":"ALLOW"}'
```

## Get AutoMod Settings {#get-automod-settings}

Gets the broadcaster's AutoMod settings. These settings are used to automatically block
inappropriate or harassing messages from appearing in the broadcaster's chat room.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/automod/settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:automod_settings** or **moderator:manage:automod_settings** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:automod_settings** or **moderator:manage:automod_settings** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose AutoMod settings you want to get.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Response Body

- `data` — Object[]. The list of AutoMod settings. The list contains a single object that contains all the AutoMod settings.
  - `data.broadcaster_id` — String. The broadcaster's ID.
  - `data.moderator_id` — String. The moderator's ID.
  - `data.overall_level` — Integer, Nullable. The default AutoMod level for the broadcaster. This field is **null** if the individual settings don't match one of the default levels, such as when the broadcaster has set one or more of the individual settings. It's also **null**, and every individual setting is 0, if the broadcaster hasn't configured AutoMod.
  - `data.disability` — Integer. The Automod level for discrimination against disability.
  - `data.aggression` — Integer. The Automod level for hostility involving aggression.
  - `data.sexuality_sex_or_gender` — Integer. The AutoMod level for discrimination based on sexuality, sex, or gender.
  - `data.misogyny` — Integer. The Automod level for discrimination against women.
  - `data.bullying` — Integer. The Automod level for hostility involving name calling or insults.
  - `data.swearing` — Integer. The Automod level for profanity.
  - `data.race_ethnicity_or_religion` — Integer. The Automod level for racial discrimination.
  - `data.sex_based_terms` — Integer. The Automod level for sexual content.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's AutoMod settings.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The IDs in *broadcaster_id* and *moderator_id* must be positive integers.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:read:automod_settings** or **moderator:manage:automod_settings** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:read:automod_settings** or **moderator:manage:automod_settings** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/automod/settings?broadcaster_id=1234&moderator_id=5678' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "1234",
      "moderator_id": "5678",
      "overall_level": null,
      "disability": 0,
      "aggression": 0,
      "sexuality_sex_or_gender": 0,
      "misogyny": 0,
      "bullying": 0,
      "swearing": 0,
      "race_ethnicity_or_religion": 0,
      "sex_based_terms": 0
    }
  ]
}
```

## Update AutoMod Settings {#update-automod-settings}

Updates the broadcaster's AutoMod settings.

The settings are used to automatically block inappropriate or harassing messages from appearing in the broadcaster's chat room.

Each setting, including *overall_level*, accepts a level from 0 through 4.

If you set individual settings, any individual setting that you don't include is set to 0. To
change only some settings, get the current settings with
[Get AutoMod Settings](https://dev.twitch.tv/docs/api/reference/moderation.md#get-automod-settings) and include all of them in
the request.

### Endpoint

`PUT https://api.twitch.tv/helix/moderation/automod/settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:automod_settings** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:automod_settings** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose AutoMod settings you want to update.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Request Body

- `aggression` — Integer. The Automod level for hostility involving aggression.
- `bullying` — Integer. The Automod level for hostility involving name calling or insults.
- `disability` — Integer. The Automod level for discrimination against disability.
- `misogyny` — Integer. The Automod level for discrimination against women.
- `overall_level` — Integer. The default AutoMod level for the broadcaster.
- `race_ethnicity_or_religion` — Integer. The Automod level for racial discrimination.
- `sex_based_terms` — Integer. The Automod level for sexual content.
- `sexuality_sex_or_gender` — Integer. The AutoMod level for discrimination based on sexuality, sex, or gender.
- `swearing` — Integer. The Automod level for profanity.

### Response Body

- `data` — Object[]. The list of AutoMod settings. The list contains a single object that contains all the AutoMod settings.
  - `data.broadcaster_id` — String. The broadcaster's ID.
  - `data.moderator_id` — String. The moderator's ID.
  - `data.overall_level` — Integer, Nullable. The default AutoMod level for the broadcaster. This field is **null** if the broadcaster has set one or more of the individual settings.
  - `data.disability` — Integer. The Automod level for discrimination against disability.
  - `data.aggression` — Integer. The Automod level for hostility involving aggression.
  - `data.sexuality_sex_or_gender` — Integer. The AutoMod level for discrimination based on sexuality, sex, or gender.
  - `data.misogyny` — Integer. The Automod level for discrimination against women.
  - `data.bullying` — Integer. The Automod level for hostility involving name calling or insults.
  - `data.swearing` — Integer. The Automod level for profanity.
  - `data.race_ethnicity_or_religion` — Integer. The Automod level for racial discrimination.
  - `data.sex_based_terms` — Integer. The Automod level for sexual content.

### Response Codes

- **200 Ok** — Successfully updated the broadcaster's AutoMod settings.
- **400 Bad Request**
  - The *broadcaster_id* is required.
  - The *moderator_id* is required.
  - The *overall_level* setting or one or more individual settings like *aggression* is required; the overall and individual settings are mutually exclusive, so don't set both.
  - The value of one or more AutoMod settings is not valid.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:automod_settings** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:automod_settings** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/moderation/automod/settings?broadcaster_id=1234&moderator_id=5678' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"overall_level":3}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "1234",
      "moderator_id": "5678",
      "overall_level": 3,
      "disability": 3,
      "aggression": 3,
      "sexuality_sex_or_gender": 3,
      "misogyny": 3,
      "bullying": 2,
      "swearing": 0,
      "race_ethnicity_or_religion": 3,
      "sex_based_terms": 3
    }
  ]
}
```

## Get Banned Users {#get-banned-users}

Gets all users that the broadcaster banned or put in a timeout.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/banned`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderation:read** or **moderator:manage:banned_users** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderation:read** or **moderator:manage:banned_users** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose list of banned users you want to get. This ID must match the user ID in the access token.
- `user_id` — String
  A list of user IDs used to filter the results. To specify more than one ID, include this
  parameter for each user you want to get. For example, 'user_id=1234&user_id=5678'. You may
  specify a maximum of 100 IDs.

  The returned list includes only those users that were banned or put in a timeout. If you
  specify this parameter, the *first* and *after* query parameters are ignored and the
  response's `pagination` object is empty.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of users that were banned or put in a timeout. The users in each page are in lexicographical order of user ID.
  - `data.user_id` — String. The ID of the banned user.
  - `data.user_login` — String. The banned user's login name.
  - `data.user_name` — String. The banned user's display name.
  - `data.expires_at` — String. The UTC date and time (in RFC3339 format) of when the timeout expires, or an empty string if the user is permanently banned.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) of when the user was banned.
  - `data.reason` — String. The reason the user was banned or put in a timeout if the moderator provided one.
  - `data.moderator_id` — String. The ID of the moderator that banned the user or put them in a timeout.
  - `data.moderator_login` — String. The moderator's login name.
  - `data.moderator_name` — String. The moderator's display name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of banned users.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The cursor specified in the *after* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
  - The request specified too many *user_id* query parameters.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderation:read** or **moderator:manage:banned_users** scope.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **moderation:read** or **moderator:manage:banned_users** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/banned?broadcaster_id=198704263' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "423374343",
      "user_login": "glowillig",
      "user_name": "glowillig",
      "expires_at": "2022-03-15T02:00:28Z",
      "created_at": "2022-03-15T01:30:28Z",
      "reason": "Does not like pineapple on pizza.",
      "moderator_id": "141981764",
      "moderator_login": "twitchdev",
      "moderator_name": "TwitchDev"
    },
    {
      "user_id": "424596340",
      "user_login": "quotrok",
      "user_name": "quotrok",
      "expires_at": "2022-08-07T02:07:55Z",
      "created_at": "2022-08-07T02:02:55Z",
      "reason": "Inappropriate words.",
      "moderator_id": "141981764",
      "moderator_login": "twitchdev",
      "moderator_name": "TwitchDev"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7IkN1cnNvciI6IjEwMDQ3MzA2NDo4NjQwNjU3MToxSVZCVDFKMnY5M1BTOXh3d1E0dUdXMkJOMFcifX0"
  }
}
```

## Ban User {#ban-user}

Bans a user from participating in the specified broadcaster's chat room or puts them in a timeout.

For information about banning or putting users in a timeout,
see [Ban a User](https://help.twitch.tv/s/article/how-to-manage-harassment-in-chat#TheBanFeature) and
[Timeout a User](https://help.twitch.tv/s/article/how-to-manage-harassment-in-chat#TheTimeoutFeature)

If the user is currently in a timeout, you can call this endpoint to change the duration of the
timeout or ban them altogether. If the user is currently banned, you cannot call this method to
put them in a timeout instead.

To remove a ban or end a timeout, see [Unban user](#unban-user).

### Endpoint

`POST https://api.twitch.tv/helix/moderation/bans`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:banned_users** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:banned_users**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose chat room the user is being banned from.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Request Body

- `data` — Object, **Required**. Identifies the user and type of ban.
  - `data.user_id` — String, **Required**. The ID of the user to ban or put in a timeout.
  - `data.duration` — Integer
    To ban a user indefinitely, don't include this field or set it to 0.

    To put a user in a timeout, include this field and specify the timeout period, in
    seconds. The minimum timeout is 1 second and the maximum is 1,209,600 seconds (2 weeks).

    To end a user's timeout early, set this field to 1, or use the [Unban user](#unban-user)
    endpoint.
  - `data.reason` — String. The reason the you're banning the user or putting them in a timeout. The text is user defined and is limited to a maximum of 500 characters.

### Response Body

- `data` — Object[]. A list that contains the user you successfully banned or put in a timeout.
  - `data.broadcaster_id` — String. The broadcaster whose chat room the user was banned from chatting in.
  - `data.moderator_id` — String. The moderator that banned or put the user in the timeout.
  - `data.user_id` — String. The user that was banned or put in a timeout.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) that the ban or timeout was placed.
  - `data.end_time` — String. The UTC date and time (in RFC3339 format) that the timeout will end. Is **null** if the user was banned instead of being put in a timeout.

### Response Codes

- **200 OK** — Successfully banned the user or placed them in a timeout.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The _user\_id_ field is required.
  - The text in the *reason* field is too long.
  - The text in the *reason* field doesn't meet Twitch's moderation standards.
  - The value in the *duration* field is not valid.
  - The user specified in the _user\_id_ field was not found.
  - The user specified in the _user\_id_ field may not be banned.
  - The user specified in the _user\_id_ field may not be put in a timeout.
  - The user specified in the _user\_id_ field is already banned.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:banned_users** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:banned_users** and **user:bot** scopes.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.
- **409 Conflict**
  - You may not update the user's ban state while someone else is updating the state. For example, someone else is currently banning the user or putting them in a timeout, moving the user from a timeout to a ban, or removing the user from a ban or timeout. Please retry your request.
- **429 Too Many Requests**
  - The app has exceeded the number of requests it may make per minute for this broadcaster.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/bans?broadcaster_id=1234&moderator_id=5678' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"data":{"user_id":"9876","reason":"no reason"}}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "1234",
      "moderator_id": "5678",
      "user_id": "9876",
      "created_at": "2021-09-28T18:22:31Z",
      "end_time": null
    }
  ]
}
```

## Unban User {#unban-user}

Removes the ban or timeout that was placed on the specified user. To ban a user, see [Ban user](#ban-user).

### Endpoint

`DELETE https://api.twitch.tv/helix/moderation/bans`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:banned_users** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:banned_users**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose chat room the user is banned from chatting in.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `user_id` — String, **Required**. The ID of the user to remove the ban or timeout from.

### Response Codes

- **204 No Content** — Successfully removed the ban or timeout.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The *user_id* query parameter is required.
  - The user specified in the *user_id* query parameter is not banned.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:banned_users** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:banned_users** and **user:bot** scopes.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.
- **409 Conflict**
  - You may not update the user's ban state while someone else is updating the state. For example, someone else is currently removing the ban or timeout, or they're moving the user from a timeout to a ban. Please retry your request.
- **429 Too Many Requests**
  - The app has exceeded the number of requests it may make per minute for this broadcaster.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/moderation/bans?broadcaster_id=1234&moderator_id=5678&user_id=5432' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Blocked Terms {#get-blocked-terms}

Gets the broadcaster's list of blocked words or phrases.
These are the terms that the broadcaster or moderator added manually or that were denied by AutoMod.

The list includes the broadcaster's private terms only if the ID in *moderator_id* is the
broadcaster's ID. The response doesn't indicate which terms are private.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/blocked_terms`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:blocked_terms** or **moderator:manage:blocked_terms** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:blocked_terms** or **moderator:manage:blocked_terms** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose blocked terms you're getting.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value.

### Response Body

- `data` — Object[]. The list of blocked terms. The list is in descending order of when they were created (see the `created_at` timestamp).
  - `data.broadcaster_id` — String. The broadcaster that owns the list of blocked terms.
  - `data.moderator_id` — String. The moderator that blocked the word or phrase from being used in the broadcaster's chat room.
  - `data.id` — String. An ID that identifies this blocked term.
  - `data.text` — String. The blocked word or phrase.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) that the term was blocked.
  - `data.updated_at` — String
    The UTC date and time (in RFC3339 format) that the term was updated.

    When the term is added, this timestamp is the same as `created_at`. The timestamp
    changes as AutoMod continues to deny the term.
  - `data.expires_at` — String
    The UTC date and time (in RFC3339 format) that the blocked term is set to expire. After
    the block expires, users may use the term in the broadcaster's chat room.

    This field is **null** if the term was added manually or was permanently blocked by
    AutoMod.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if the page contains fewer terms than the page size (see *first*). A full page includes a cursor even if no more terms remain, in which case the next page is empty. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of blocked terms.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:read:blocked_terms** or **moderator:manage:blocked_terms** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:read:blocked_terms** or **moderator:manage:blocked_terms** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/blocked_terms?broadcaster_id=1234&moderator_id=5678&first=10' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "1234",
      "moderator_id": "5678",
      "id": "520e4d4e-0cda-49c7-821e-e5ef4f88c2f2",
      "text": "A phrase I'm not fond of",
      "created_at": "2021-09-29T19:45:37Z",
      "updated_at": "2021-09-29T19:45:37Z",
      "expires_at": null
    },

    . . .

  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7IkN1cnNvciI6I..."
  }
}
```

## Add Blocked Term {#add-blocked-term}

Adds a word or phrase to the broadcaster's list of blocked terms. These are the terms that the broadcaster doesn't want used in their chat room.

### Endpoint

`POST https://api.twitch.tv/helix/moderation/blocked_terms`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:blocked_terms** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:blocked_terms** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the list of blocked terms.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Request Body

- `text` — String, **Required**
  The word or phrase to block from being used in the broadcaster's chat room. The term may
  contain up to a maximum of 500 characters. Not counting spaces and wildcard characters, the
  term must contain a minimum of 2 characters, or 3 characters if it includes a wildcard
  character.

  Terms may include a wildcard character (\*). The wildcard character must appear at the
  beginning or end of a word or set of characters. For example, \*foo or foo\*.

  If the blocked term already exists, the response contains the existing blocked term.

### Response Body

- `data` — Object[]. A list that contains the single blocked term that the broadcaster added.
  - `data.broadcaster_id` — String. The broadcaster that owns the list of blocked terms.
  - `data.moderator_id` — String. The moderator that blocked the word or phrase from being used in the broadcaster's chat room.
  - `data.id` — String. An ID that identifies this blocked term.
  - `data.text` — String. The blocked word or phrase.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) that the term was blocked.
  - `data.updated_at` — String
    The UTC date and time (in RFC3339 format) that the term was updated.

    When the term is added, this timestamp is the same as `created_at`. The timestamp
    changes as AutoMod continues to deny the term.
  - `data.expires_at` — String
    The UTC date and time (in RFC3339 format) that the blocked term is set to expire. After
    the block expires, users may use the term in the broadcaster's chat room.

    This field is **null** if the term was added manually or was permanently blocked by
    AutoMod.

### Response Codes

- **200 OK** — Successfully added the blocked term.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The *text* field is required.
  - The length of the term in the *text* field is either too short or too long.
  - The request conflicts with another pending change to the broadcaster's list of blocked terms. Please retry your request.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:blocked_terms** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:blocked_terms** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.
- **409 Conflict**
  - The blocked term is currently being updated. Please retry your request.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/blocked_terms?broadcaster_id=1234&moderator_id=5678' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"text":"A phrase I'm not fond of"}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "1234",
      "moderator_id": "5678",
      "id": "3bb6e5d3-afb1-416c-ad4e-21af970ccfe7",
      "text": "A phrase I'm not fond of",
      "created_at": "2021-09-29T15:36:45Z",
      "updated_at": "2021-09-29T15:36:45Z",
      "expires_at": null
    }
  ]
}
```

## Remove Blocked Term {#remove-blocked-term}

Removes the word or phrase from the broadcaster's list of blocked terms.

### Endpoint

`DELETE https://api.twitch.tv/helix/moderation/blocked_terms`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:blocked_terms** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:blocked_terms** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the list of blocked terms.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `id` — String, **Required**. The ID of the blocked term to remove from the broadcaster's list of blocked terms.

### Response Codes

- **204 No Content** — Successfully removed the blocked term. Also returned if the ID is not found.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The *id* query parameter is required.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:blocked_terms** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:blocked_terms** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/moderation/blocked_terms?broadcaster_id=1234&moderator_id=5678&id=c9fc79b8-0f63-4ef7-9d38-efd811e74ac2' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Moderated Channels {#get-moderated-channels}

Gets a list of channels that the specified user has moderator privileges in.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/channels`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:moderated_channels** scope. That includes the **user:read:moderated_channels**. The user ID associated with the token must match the _user\_id_ in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:read:moderated_channels** scope for the user represented by the *user_id* query parameter.

### Query Parameters

- `user_id` — String, **Required**. A user's ID. Returns the list of channels that this user has moderator privileges in. This ID must match the user ID in the user OAuth token
- `after` — String. The cursor used to get the next page of results. The Pagination object in the response contains the cursor's value.
- `first` — Integer. The maximum number of items to return per page in the response. Minimum page size is 1 item per page and the maximum is 100. The default is 20.

### Response Body

- `data` — Object[]. The list of channels that the user has moderator privileges in. The list doesn't include the user's own channel or channels that are deleted or suspended.
  - `data.broadcaster_id` — String. An ID that uniquely identifies the channel this user can moderate.
  - `data.broadcaster_login` — String. The channel's login name.
  - `data.broadcaster_name` — String. The channels' display name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through.
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's after query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of moderated channels.
- **400 Bad Request**
  - The *user_id* query parameter is required.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *user_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **user:read:moderated_channels** scope.
  - If you use an app access token, the user in *user_id* must have authorized your app with the **user:read:moderated_channels** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/channels?user_id=931931' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id" : "12345",
      "broadcaster_login" : "grateful_broadcaster",
      "broadcaster_name" : "Grateful_Broadcaster"
    },
    {
      "broadcaster_id" : "98765",
      "broadcaster_login" : "bashfulgamer",
      "broadcaster_name" : "BashfulGamer"
    },
    ...
  ],
  "pagination" : {
    "cursor" : "eyJiIjpudWxsLCJhIjp7IkN1cnNvciI6IjEwMDQ3MzA2NDo4NjQwNjU3MToxSVZCVDFKMnY5M1BTOXh3d1E0dUdXMkJOMFcifX0"
  }
}
```

## Delete Chat Messages {#delete-chat-messages}

Removes a single chat message or all chat messages from the broadcaster's chat room.

### Endpoint

`DELETE https://api.twitch.tv/helix/moderation/chat`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:chat_messages** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:chat_messages** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room to remove messages from.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `message_id` — String
  The ID of the message to remove. The `id` tag in the [PRIVMSG](https://dev.twitch.tv/docs/chat/irc.md#privmsg-tags) tag
  contains the message's ID. Restrictions:

  - The message must have been created within the last 6 hours.

  - The message must not belong to the broadcaster.

  - The message must not belong to another moderator.

  If you don't specify this parameter, the request removes all messages in the broadcaster's
  chat room.

### Response Codes

- **204 No Content** — Successfully removed the specified messages.
- **400 Bad Request**
  - You may not delete another moderator's messages.
  - You may not delete the broadcaster's messages.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token is missing the **moderator:manage:chat_messages** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:chat_messages** scope.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.
- **404 Not Found**
  - The ID in *broadcaster_id* was not found.
  - The ID in *message_id* was not found.
  - The user who sent the message in *message_id* was not found.
  - The specified message was created more than 6 hours ago.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/moderation/chat?broadcaster_id=11111&moderator_id=44444' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Check AutoMod Status {#check-automod-status}

Checks whether AutoMod would flag the specified message for review.

AutoMod is a moderation tool that holds inappropriate or harassing chat messages for moderators to
review. Moderators approve or deny the messages that AutoMod flags; only approved messages are
released to chat. AutoMod detects misspellings and evasive language automatically. For information
about AutoMod, see [How to Use AutoMod](https://help.twitch.tv/s/article/how-to-use-automod).

**Rate Limits**: Rates are limited per channel based on the account type rather than per access
token. Each message in the request counts toward the limits, and the request fails if checking
any one of the messages would exceed a limit.

| Account type | Limit per minute | Limit per hour |
| - | - | - |
| Normal | 5 | 50 | 
| Affiliate | 10 | 100 | 
| Partner | 30 | 300 |

The above limits are in addition to the standard [Twitch API rate
limits](https://dev.twitch.tv/docs/api/guide.md#twitch-rate-limits). The rate limit headers in the response represent the
Twitch rate limits and not the above limits.

### Endpoint

`POST https://api.twitch.tv/helix/moderation/enforcements/status`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderation:read** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderation:read** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose AutoMod settings and list of blocked terms are used to check the message. This ID must match the user ID in the access token.

### Request Body

- `data` — Object[], **Required**. The list of messages to check. The list must contain at least one message and may contain up to a maximum of 100 messages.
  - `data.msg_id` — String, **Required**. A caller-defined ID used to correlate this message with the same message in the response. Use a unique ID for each message; if messages share an ID, only the last of them is checked.
  - `data.msg_text` — String, **Required**. The message to check. The message may contain a maximum of 500 characters.

### Response Body

- `data` — Object[]. The list of messages and whether Twitch would approve them for chat. The list is in no particular order.
  - `data.msg_id` — String. The caller-defined ID passed in the request.
  - `data.is_permitted` — Boolean. A Boolean value that indicates whether Twitch would approve the message for chat or hold it for moderator review or block it from chat. Is **true** if Twitch would approve the message; otherwise, **false** if Twitch would hold the message for moderator review or block it from chat.

### Response Codes

- **200 OK** — Successfully checked the messages.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *data* field is required and the list must contain one or more messages to check.
  - The *msg_id* field is required.
  - The *msg_text* field is required.
  - The text in the *msg_text* field is too long.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderation:read** scope.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **moderation:read** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The ID in *broadcaster_id* must match the user ID in the user access token.
- **429 Too Many Requests**
  - The broadcaster exceeded the number of chat message checks that they may make. See the endpoint's rate limits.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/enforcements/status?broadcaster_id=12345' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"data":[{"msg_id":"123","msg_text":"Hello World!"},{"msg_id":"393","msg_text":"Boooooo!"}]}'
```

### Response Example

```json
{
  "data": [
    {
      "msg_id": "123",
      "is_permitted": true
    },
    {
      "msg_id": "393",
      "is_permitted": false
    }
  ]
}
```

## Get Moderators {#get-moderators}

Gets all users allowed to moderate the broadcaster's chat room.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/moderators`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderation:read** or **channel:manage:moderators** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose list of moderators you want to get. This ID must match the user ID in the access token.
- `user_id` — String
  A list of user IDs used to filter the results. To specify more than one ID, include this
  parameter for each moderator you want to get. For example, 'user_id=1234&user_id=5678'. You
  may specify a maximum of 100 IDs.

  The returned list includes only the users from the list who are moderators in the
  broadcaster's channel. The list is in no particular order, and duplicate IDs are ignored.
  If you specify this parameter, the *first* and *after* query parameters are ignored and the
  response's `pagination` object is empty.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of moderators.
  - `data.user_id` — String. The ID of the user that has permission to moderate the broadcaster's channel.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of moderators.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The IDs in *broadcaster_id* and *user_id* must be positive integers.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID found in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **moderation:read** or **channel:manage:moderators** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/moderators?broadcaster_id=198704263' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "424596340",
      "user_login": "quotrok",
      "user_name": "quotrok"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7IkN1cnNvciI6IjEwMDQ3MzA2NDo4NjQwNjU3MToxSVZCVDFKMnY5M1BTOXh3d1E0dUdXMkJOMFcifX0"
  }
}
```

## Add Channel Moderator {#add-channel-moderator}

Adds a moderator to the broadcaster's chat room.

**Rate Limits**: The broadcaster may add a maximum of 10 moderators within a 10-second window.

### Endpoint

`POST https://api.twitch.tv/helix/moderation/moderators`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:moderators** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room. This ID must match the user ID in the access token.
- `user_id` — String, **Required**. The ID of the user to add as a moderator in the broadcaster's chat room.

### Response Codes

- **204 No Content** — Successfully added the moderator.
- **400 Bad Request**
  - The ID in *broadcaster_id* was not found.
  - The ID in *user_id* was not found.
  - The user in *user_id* is already a moderator in the broadcaster's chat room.
  - The user in *user_id* cannot become a moderator because they're banned from the channel.
  - The user in *user_id* cannot become a moderator because they blocked the broadcaster or the broadcaster blocked them.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:moderators** scope.
  - The access token is not valid.
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **422 Unprocessable Entity**
  - The user in *user_id* is a VIP. To make them a moderator, you must first remove them as a VIP (see [Remove Channel VIP](https://dev.twitch.tv/docs/api/reference/moderation.md#remove-channel-vip)).
  - The broadcaster's channel has reached the maximum number of moderators.
- **429 Too Many Requests**
  - The broadcaster has exceeded the number of requests allowed within a 10-second window. See this endpoint's rate limits.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/moderators?broadcaster_id=11111&user_id=44444' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Remove Channel Moderator {#remove-channel-moderator}

Removes a moderator from the broadcaster's chat room.

**Rate Limits**: The broadcaster may remove a maximum of 10 moderators within a 10-second window.

### Endpoint

`DELETE https://api.twitch.tv/helix/moderation/moderators`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:moderators** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room. This ID must match the user ID in the access token, unless a moderator is removing themselves; in that case, the ID in *user_id* must match the user ID in the access token.
- `user_id` — String, **Required**. The ID of the user to remove as a moderator from the broadcaster's chat room.

### Response Codes

- **204 No Content** — Successfully removed the moderator.
- **400 Bad Request**
  - The ID in *broadcaster_id* was not found.
  - The ID in *user_id* was not found.
  - The user in *user_id* is not a moderator in the broadcaster's chat room.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:moderators** scope.
  - The access token is not valid.
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token, unless the user in the access token is removing themselves as a moderator.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **429 Too Many Requests**
  - The broadcaster has exceeded the number of requests allowed within a 10-second window. See this endpoint's rate limits.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/moderation/moderators?broadcaster_id=11111&user_id=44444' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Shield Mode Status {#get-shield-mode-status}

Gets the broadcaster's Shield Mode activation status.

To receive notification when the broadcaster activates and deactivates Shield Mode, subscribe to
the [channel.shield_mode.begin](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-shield-mode-begin) and
[channel.shield_mode.end](https://dev.twitch.tv/docs/eventsub/reference/channel-moderation.md#channel-shield-mode-end)
subscription types.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/shield_mode`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope. The user ID associated with the token must match the *moderator_id* in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose Shield Mode activation status you want to get.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that is one of the broadcaster's moderators. This ID must match the user ID in the access token.

### Response Body

- `data` — Object[]. A list that contains a single object with the broadcaster's Shield Mode status.
  - `data.is_active` — Boolean. A Boolean value that determines whether Shield Mode is active. Is **true** if the broadcaster activated Shield Mode; otherwise, **false**.
  - `data.moderator_id` — String. An ID that identifies the moderator that last activated Shield Mode. Is an empty string if Shield Mode hasn't been previously activated.
  - `data.moderator_login` — String. The moderator's login name. Is an empty string if Shield Mode hasn't been previously activated.
  - `data.moderator_name` — String. The moderator's display name. Is an empty string if Shield Mode hasn't been previously activated.
  - `data.last_activated_at` — String. The UTC timestamp (in RFC3339 format) of when Shield Mode was last activated. Is an empty string if Shield Mode hasn't been previously activated.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's Shield Mode activation status.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:read:shield_mode** or **moderator:manage:shield_mode** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/shield_mode?broadcaster_id=12345&moderator_id=98765' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "is_active": true,
      "moderator_id": "98765",
      "moderator_name": "SimplySimple",
      "moderator_login": "simplysimple",
      "last_activated_at": "2022-07-26T17:16:03Z"
    }
  ]
}
```

## Update Shield Mode Status {#update-shield-mode-status}

Activates or deactivates the broadcaster's Shield Mode.

Twitch's Shield Mode feature is like a panic button that broadcasters can push to protect
themselves from chat abuse coming from one or more accounts. When activated, Shield Mode applies
the overrides that the broadcaster configured in the Twitch UX. If the broadcaster hasn't
configured Shield Mode, it applies default overrides.

### Endpoint

`PUT https://api.twitch.tv/helix/moderation/shield_mode`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:shield_mode** scope. The user ID associated with the token must match the *moderator_id* in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:shield_mode** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose Shield Mode you want to activate or deactivate.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that is one of the broadcaster's moderators. This ID must match the user ID in the access token.

### Request Body

- `is_active` — Boolean, **Required**. A Boolean value that determines whether to activate Shield Mode. Set to **true** to activate Shield Mode; otherwise, **false** to deactivate Shield Mode.

### Response Body

- `data` — Object[]. A list that contains a single object with the broadcaster's updated Shield Mode status.
  - `data.is_active` — Boolean. A Boolean value that determines whether Shield Mode is active. Is **true** if Shield Mode is active; otherwise, **false**.
  - `data.moderator_id` — String. An ID that identifies the moderator that last activated Shield Mode. Is an empty string if Shield Mode hasn't been previously activated.
  - `data.moderator_login` — String. The moderator's login name. Is an empty string if Shield Mode hasn't been previously activated.
  - `data.moderator_name` — String. The moderator's display name. Is an empty string if Shield Mode hasn't been previously activated.
  - `data.last_activated_at` — String. The UTC timestamp (in RFC3339 format) of when Shield Mode was last activated. Is an empty string if Shield Mode hasn't been previously activated.

### Response Codes

- **200 OK** — Successfully updated the broadcaster's Shield Mode status.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *is_active* field is required.
  - The value in the *is_active* field is not valid.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:shield_mode** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:shield_mode** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/moderation/shield_mode?broadcaster_id=12345&moderator_id=98765' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"is_active":false}'
```

### Response Example

```json
{
  "data": [
    {
      "is_active": false,
      "moderator_id": "98765",
      "moderator_name": "SimplySimple",
      "moderator_login": "simplysimple",
      "last_activated_at": "2022-07-26T17:16:03Z"
    }
  ]
}
```

## Add Suspicious Status to Chat User {#add-suspicious-status-to-chat-user}

Adds a suspicious user status to a chatter on the broadcaster's channel.

### Endpoint

`POST https://api.twitch.tv/helix/moderation/suspicious_users`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:suspicious_users** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:suspicious_users** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The user ID of the broadcaster, indicating the channel where the status is being applied.
- `moderator_id` — String, **Required**. The user ID of the moderator who is applying the status. This ID must match the user ID in the user access token.

### Request Body

- `user_id` — String, **Required**. The ID of the user being given the suspicious status.
- `status` — String, **Required**. The type of suspicious status.
  Possible values:
  - `ACTIVE_MONITORING`
  - `RESTRICTED`

### Response Body

- `data` — Object[]. An array with one object containing information about the suspicious user action.
  - `data.user_id` — String. The ID of the user being given the suspicious status.
  - `data.broadcaster_id` — String. The user ID of the broadcaster indicating in which channel the status is being applied.
  - `data.moderator_id` — String. The user ID of the moderator who applied the last status.
  - `data.updated_at` — String. The UTC date and time (in RFC3339 format) of the last time this user's status was updated.
  - `data.status` — String. The type of suspicious status.
    Possible values:
    - `ACTIVE_MONITORING`
    - `RESTRICTED`
  - `data.types` — String[]. An array of strings representing the type(s) of suspicious user this is.
    Possible values:
    - `MANUALLY_ADDED`
    - `DETECTED_BAN_EVADER`
    - `DETECTED_SUS_CHATTER`
    - `BANNED_IN_SHARED_CHANNEL`
    - `UNKNOWN_TYPE`

### Response Codes

- **200 OK** — Successfully applied a suspicious user status.
- **400 Bad Request**
  - Validation errors: Missing required fields.
  - The IDs in *broadcaster_id* and *moderator_id* must be positive integers.
  - The status specified was invalid. Must either be ACTIVE_MONITORING or RESTRICTED
  - The status update is not allowed for this user. You may not apply a status to the broadcaster, to the user in *moderator_id*, or to one of the broadcaster's moderators, or apply a status that the user already has.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:suspicious_users** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:suspicious_users** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The user in the moderator_id query parameter is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/suspicious_users?broadcaster_id=141981764&moderator_id=12826' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"user_id":"9876","status":"RESTRICTED"}'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "9876",
      "broadcaster_id": "141981764",
      "moderator_id": "12826",
      "updated_at": "2025-12-01T23:08:18Z",
      "status": "RESTRICTED",
      "types": [
        "MANUALLY_ADDED"
      ]
    }
  ]
}
```

## Remove Suspicious Status From Chat User {#remove-suspicious-status-from-chat-user}

Remove a suspicious user status from a chatter on broadcaster's channel.

### Endpoint

`DELETE https://api.twitch.tv/helix/moderation/suspicious_users`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:suspicious_users** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:suspicious_users** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The user ID of the broadcaster, indicating the channel where the status is being removed.
- `moderator_id` — String, **Required**. The user ID of the moderator who is removing the status. This ID must match the user ID in the user access token.
- `user_id` — String, **Required**. The ID of the user having the suspicious status removed.

### Response Body

- `data` — Object[]. An array with one object containing information about the suspicious user action.
  - `data.user_id` — String. The ID of the user having the suspicious status removed.
  - `data.broadcaster_id` — String. The user ID of the broadcaster indicating in which channel the status is being removed.
  - `data.moderator_id` — String. The user ID of the moderator who modified the last status.
  - `data.updated_at` — String. The timestamp of the last time this user's status was updated.
  - `data.status` — String. The type of suspicious status.
    Possible values:
    - `NO_TREATMENT`
  - `data.types` — String[]. An array of strings representing the type(s) of suspicious user this is.
    Possible values:
    - `MANUALLY_ADDED`
    - `DETECTED_BAN_EVADER`
    - `DETECTED_SUS_CHATTER`
    - `BANNED_IN_SHARED_CHANNEL`
    - `UNKNOWN_TYPE`

### Response Codes

- **200 OK** — Successfully removed a suspicious user status.
- **400 Bad Request**
  - Validation errors: Missing required fields.
  - The status update is not allowed for this user.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:suspicious_users** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:suspicious_users** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The user in the moderator_id query parameter is not one of the broadcaster's moderators.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/moderation/suspicious_users?broadcaster_id=141981764&moderator_id=12826&user_id=9876' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "9876",
      "broadcaster_id": "141981764",
      "moderator_id": "12826",
      "updated_at": "2025-12-01T23:08:18Z",
      "status": "NO_TREATMENT",
      "types": [
        "MANUALLY_ADDED"
      ]
    } 
  ]
}
```

## Get Unban Requests {#get-unban-requests}

Gets a list of unban requests for a broadcaster's channel.

### Endpoint

`GET https://api.twitch.tv/helix/moderation/unban_requests`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:unban_requests** or **moderator:manage:unban_requests** scope. The User ID associated with the token must match the _moderator\_id_ in the query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose channel is receiving unban requests.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's unban requests. This ID must match the user ID in the user access token. To get your own unban requests, set this parameter and *user_id* to your user ID; the *moderator_id*, `moderator_login` and `moderator_name` fields in the response are then **null**.
- `status` — String, **Required**
  Filter by a status. The value is case sensitive.

  - pending
  - approved
  - denied
  - acknowledged
  - canceled
- `user_id` — String. The ID used to filter what unban requests are returned.
- `after` — String. Cursor used to get next page of results. Pagination object in response contains cursor value.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100. The default is 20.

### Response Body

- `data` — Object[]. A list that contains information about the channel's unban requests. The list is empty if the user in *moderator_id* doesn't have permission to view the broadcaster's unban requests. Requests from users whose accounts are deleted or suspended aren't included, so a page may contain fewer than *first* items.
  - `data.id` — String. Unban request ID.
  - `data.broadcaster_id` — String. User ID of broadcaster whose channel is receiving the unban request.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.moderator_id` — String, Nullable. User ID of moderator who approved/denied the request. If the request was canceled, this is the requesting user's ID.
  - `data.moderator_login` — String, Nullable. The moderator's login name.
  - `data.moderator_name` — String, Nullable. The moderator's display name.
  - `data.user_id` — String. User ID of the requestor who is asking for an unban.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.text` — String. Text of the request from the requesting user.
  - `data.status` — String
    Status of the request. One of:

    - pending
    - approved
    - denied
    - acknowledged
    - canceled
  - `data.created_at` — String. Timestamp of when the unban request was created.
  - `data.resolved_at` — String, Nullable. Timestamp of when moderator/broadcaster approved or denied the request.
  - `data.resolution_text` — String, Nullable. Text input by the resolver (moderator) of the unban request
- `pagination` — Object. Contains information used to page through a list of results. The object is empty if there are no more pages left to page through.
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's after query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of unban requests.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *moderator_id* query parameter is required.
  - The ID in the *moderator_id* query parameter is not valid.
  - The ID in the *user_id* query parameter is not valid.
  - The *status* query parameter is required.
  - The value in the *status* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
  - The pagination cursor is not valid.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **moderator:read:unban_requests** or **moderator:manage:unban_requests** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/moderation/unban_requests?broadcaster_id=274637212&moderator_id=141981764&status=pending' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "92af127c-7326-4483-a52b-b0da0be61c01",
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "moderator_id": null,
      "moderator_login": null,
      "moderator_name": null,
      "user_id": "424596340",
      "user_login": "quotrok",
      "user_name": "quotrok",
      "text": "Please unban me from the channel?",
      "status": "pending",
      "created_at": "2022-08-07T02:07:55Z",
      "resolved_at": null,
      "resolution_text": null
    }
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7IkN1cnNvciI6IjEwMDQ3MzA2NDo4NjQwNjU3MToxSVZCVDFKMnY5M1BTOXh3d1E0dUdXMkJOMFcifX0"
  }
}
```

## Resolve Unban Requests {#resolve-unban-requests}

Resolves an unban request by approving or denying it.

### Endpoint

`PATCH https://api.twitch.tv/helix/moderation/unban_requests`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:unban_requests** scope. The User ID associated with the token must match the _moderator\_id_ in the query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose channel is approving or denying the unban request. The request is identified by *unban_request_id* alone; the response's `broadcaster_id` echoes this ID, and `broadcaster_login` and `broadcaster_name` are empty strings if it isn't the request's broadcaster.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's unban requests. This ID must match the user ID in the user access token.
- `unban_request_id` — String, **Required**. The ID of the Unban Request to resolve.
- `status` — String, **Required**
  Resolution status. 

  - approved
  - denied
- `resolution_text` — String. Message supplied by the unban request resolver. The message is limited to a maximum of 500 characters.

### Response Body

- `data` — Object[]
  - `data.id` — String. Unban request ID.
  - `data.broadcaster_id` — String. User ID of broadcaster whose channel is receiving the unban request.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.moderator_id` — String, Nullable. User ID of moderator who approved/denied the request.
  - `data.moderator_login` — String, Nullable. The moderator's login name.
  - `data.moderator_name` — String, Nullable. The moderator's display name.
  - `data.user_id` — String. User ID of the requestor who is asking for an unban.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.text` — String. Text of the request from the requesting user.
  - `data.status` — String
    Status of the request. One of:

    - approved
    - denied
    - pending

    The status is **pending** if you approved the request but the user couldn't be unbanned.
    The request stays pending, and the `moderator_id`, `moderator_login`, `moderator_name`,
    `resolved_at` and `resolution_text` fields are **null**.
  - `data.created_at` — String. Timestamp of when the unban request was created.
  - `data.resolved_at` — String, Nullable. Timestamp of when moderator/broadcaster approved or denied the request.
  - `data.resolution_text` — String, Nullable. Text input by the resolver (moderator) of the unban request.

### Response Codes

- **200 OK** — Successfully resolved the unban request.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *moderator_id* query parameter is required.
  - The ID in the *moderator_id* query parameter is not valid.
  - The *unban_request_id* query parameter is required.
  - The *status* query parameter is required.
  - The value in the *status* query parameter is not valid.
  - Invalid requested update
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user in *moderator_id* is not the broadcaster or a moderator with permission to resolve the broadcaster's unban requests.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **moderator:manage:unban_requests** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found** — The unban request ID was not found.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/moderation/unban_requests?broadcaster_id=274637212&moderator_id=274637212&unban_request_id=92af127c-7326-4483-a52b-b0da0be61c01&status=approved' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "92af127c-7326-4483-a52b-b0da0be61c01",
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "moderator_id": "274637212",
      "moderator_login": "torpedo09",
      "moderator_name": "torpedo09",
      "user_id": "424596340",
      "user_login": "quotrok",
      "user_name": "quotrok",
      "text": "Please unban me from the channel?",
      "status": "approved",
      "created_at": "2022-08-07T02:07:55Z",
      "resolved_at": "2022-08-09T02:07:55Z",
      "resolution_text": ""
    }
  ]
}
```

## Warn Chat User {#warn-chat-user}

Warns a user in the specified broadcaster's chat room, preventing them from chat interaction until the warning is acknowledged.

New warnings can be issued to a user when they already have a warning in the channel (new warning will replace old warning).

### Endpoint

`POST https://api.twitch.tv/helix/moderation/warnings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:warnings** scope. The user ID associated with the token must match the *moderator_id* in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:warnings** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the channel in which the warning will take effect.
- `moderator_id` — String, **Required**. The ID of the twitch user who requested the warning.

### Request Body

- `data` — Object, **Required**. An object that contains information about the warning.
  - `data.user_id` — String, **Required**. The ID of the twitch user to be warned.
  - `data.reason` — String, **Required**. A custom reason for the warning. **Max 500 chars.**

### Response Body

- `data` — Object[]. A list that contains information about the warning.
  - `data.broadcaster_id` — String. The ID of the channel in which the warning will take effect.
  - `data.user_id` — String. The ID of the warned user.
  - `data.moderator_id` — String. The ID of the user who applied the warning.
  - `data.reason` — String. The reason provided for warning.

### Response Codes

- **200 OK** — Successfully warn a user.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The *user_id* field is required.
  - The *reason* field is required.
  - The text in the *reason* field is too long.
  - The text in the *reason* field fails moderation standards.
  - The ID in the *user_id* field is not valid.
  - The user specified in the *user_id* may not be warned.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:warnings** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:warnings** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden** — The user in *moderator_id* is not one of the broadcaster's moderators.
- **409 Conflict** — You may not update the user's warning state while someone else is updating the state. For example, someone else is currently warning the user or the user is acknowledging an existing warning. Please retry your request.
- **429 Too Many Requests** — The app has exceeded the number of requests it may make per minute for this broadcaster.
- **500 Internal Server Error** — Internal Server Error.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/moderation/warnings?broadcaster_id=404040&moderator_id=404041' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"data":{"user_id":"9876","reason":"stop doing that!"}}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "404040",
      "user_id": "9876",
      "moderator_id": "404041",
      "reason": "stop doing that!"
    }
  ]
}
```
