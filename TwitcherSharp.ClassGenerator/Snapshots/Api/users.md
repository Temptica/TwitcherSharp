# Users

Get information related to users, and act on behalf of a Twitch user's account.

Source: https://dev.twitch.tv/docs/api/reference/users/

## Contents {#contents}

9 entries on this page:

- [Get Authorization By User](#get-authorization-by-user)
- [Get Users](#get-users)
- [Update User](#update-user)
- [Get User Block List](#get-user-block-list)
- [Block User](#block-user)
- [Unblock User](#unblock-user)
- [Get User Active Extensions](#get-user-active-extensions)
- [Update User Extensions](#update-user-extensions)
- [Get User Extensions](#get-user-extensions)

## Get Authorization By User {#get-authorization-by-user}

Gets the authorization scopes that the specified user(s) have granted the application.

### Endpoint

`GET https://api.twitch.tv/helix/authorization/users`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `user_id` — String, **Required**. The ID of the user(s) you want to check authorization for. To specify more than one user, include the user_id parameter for each user to get. For example, 'user_id=1234&user_id=5678'. The maximum number of IDs you may specify is 10.

### Response Body

- `data` — Object[]. List of users and their authorized scopes. The list is in the same order as the *user_id* query parameters and doesn't include IDs that don't match a user.
  - `data.user_id` — String. The user's ID.
  - `data.user_name` — String. The user's display name.
  - `data.user_login` — String. The user's login name.
  - `data.scopes` — String[]. An array of all the scopes the user has granted to the client ID.
  - `data.has_authorized` — Boolean. A boolean indicating whether or not the specified user has authorized this application.

### Response Codes

- **200 OK** — Successfully retrieved user authorization.
- **400 Bad Request** — Request is malformed - invalid parameters or missing parameters.
- **401 Unauthorized**
  - The access token is not valid.
  - Authorization header is required and must specify an app access token.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.
- **500 Internal Error** — Internal Server Error.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/authorization/users?user_id=197886470' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "197886470",
      "user_name": "TwitchRivals",
      "user_login": "twitchrivals",
      "scopes": [],
      "has_authorized": false
    }
  ]
}
```

## Get Users {#get-users}

Gets information about one or more users.

You may look up users using their user ID, login name, or both but the sum total of the number of
users you may look up is 100. For example, you may specify 50 IDs and 50 names or 100 IDs or
names, but you cannot specify 100 IDs and 100 names.<br><br> 

If you don't specify IDs or login names, the request returns information about the user in the
access token if you specify a user access token.<br><br> 

To include the user's verified email address in the response, you must use a user access token
that includes the **user:read:email** scope.

### Endpoint

`GET https://api.twitch.tv/helix/users`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `id` — String. The ID of the user to get. To specify more than one user, include the *id* parameter for each user to get. For example, 'id=1234&id=5678'. The maximum number of IDs you may specify is 100.
- `login` — String. The login name of the user to get. To specify more than one user, include the *login* parameter for each user to get. For example, 'login=foo&login=bar'. The maximum number of login names you may specify is 100.

### Response Body

- `data` — Object[]. The list of users. The list doesn't include deleted or suspended accounts.
  - `data.id` — String. An ID that identifies the user.
  - `data.login` — String. The user's login name.
  - `data.display_name` — String. The user's display name.
  - `data.type` — String. The type of user.
    Possible values:
    - `admin`: Twitch administrator
    - `global_mod`
    - `staff`: Twitch staff
    - `(empty string value provided in field)`: Normal user
  - `data.broadcaster_type` — String. The type of broadcaster.
    Possible values:
    - `affiliate`: An [affiliate
broadcaster](https://help.twitch.tv/s/article/joining-the-affiliate-program)
    - `partner`: [A partner broadcaster](https://help.twitch.tv/s/article/partner-program-overview)
    - `(empty string value provided in field)`: A normal broadcaster
  - `data.description` — String. The user's description of their channel.
  - `data.profile_image_url` — String. A URL to the user's profile image.
  - `data.offline_image_url` — String. A URL to the user's offline image.
  - `data.view_count` — Integer. The number of times the user's channel has been viewed. **NOTE**: This field has been deprecated (see [Get Users API endpoint – "view\_count" deprecation](https://discuss.dev.twitch.tv/t/get-users-api-endpoint-view-count-deprecation/37777)). Any data in this field is not valid and should not be used.
  - `data.email` — String. The user's verified email address. The object includes this field only for the user in the user access token, and only if the token includes the **user:read:email** scope and the user has verified their email address.
  - `data.created_at` — String. The UTC date and time that the user's account was created. The timestamp is in RFC3339 format.

### Response Codes

- **200 OK** — Successfully retrieved the specified users' information.
- **400 Bad Request**
  - The *id* or *login* query parameter is required unless the request uses a user access token.
  - The request exceeded the maximum allowed number of *id* and/or *login* query parameters.
  - An *id* or *login* value is malformed, for example, an ID that contains characters other than digits. One malformed value fails the whole request.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/users?id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "141981764",
      "login": "twitchdev",
      "display_name": "TwitchDev",
      "type": "",
      "broadcaster_type": "partner",
      "description": "Supporting third-party developers building Twitch integrations from chatbots to game\nintegrations.",
      "profile_image_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/8a6381c7-d0c0-4576-b179-38bd5ce1d6af-profile_image-300x300.png",
      "offline_image_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/3f13ab61-ec78-4fe6-8481-8682cb3b0ac2-channel_offline_image-1920x1080.png",
      "view_count": 0,
      "email": "not-real@email.com",
      "created_at": "2016-12-14T20:32:28Z"
    }
  ]
}
```

## Update User {#update-user}

Updates the specified user's information. The user ID in the OAuth token identifies the user whose
information you want to update.

To include the user's verified email address in the response, the user access token must also
include the **user:read:email** scope.

### Endpoint

`PUT https://api.twitch.tv/helix/users`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:edit** scope.

### Query Parameters

- `description` — String
  The string to update the channel's description to. The description is limited to a maximum
  of 300 characters. Before it checks the length and saves the description, the API removes
  line breaks and replaces each `<` and `>` with `&lt;` and `&gt;`.

  To remove the description, specify this parameter but don't set it's value (for example,
  '?description=').

### Response Body

- `data` — Object[]. A list contains the single user that you updated.
  - `data.id` — String. An ID that identifies the user.
  - `data.login` — String. The user's login name.
  - `data.display_name` — String. The user's display name.
  - `data.type` — String. The type of user.
    Possible values:
    - `admin`: Twitch administrator
    - `global_mod`
    - `staff`: Twitch staff
    - `(empty string value provided in field)`: Normal user
  - `data.broadcaster_type` — String. The type of broadcaster.
    Possible values:
    - `affiliate`: An [affiliate
broadcaster](https://help.twitch.tv/s/article/joining-the-affiliate-program)
    - `partner`: A [partner broadcaster](https://help.twitch.tv/s/article/partner-program-overview)
    - `(empty string value provided in field)`: A normal broadcaster
  - `data.description` — String. The user's description of their channel.
  - `data.profile_image_url` — String. A URL to the user's profile image.
  - `data.offline_image_url` — String. A URL to the user's offline image.
  - `data.view_count` — Integer
    The number of times the user's channel has been viewed.

    **NOTE**: This field has been deprecated (see [Get Users API endpoint – "view_count" deprecation](https://discuss.dev.twitch.tv/t/get-users-api-endpoint-view-count-deprecation/37777)).
    Any data in this field is not valid and should not be used.
  - `data.email` — String
    The user's verified email address. The object includes this field only if the user
    access token includes the **user:read:email** scope.

    If the request contains more than one user, only the user associated with the access
    token that provided consent will include an email address — the email address for all
    other users will be empty.
  - `data.created_at` — String. The UTC date and time that the user's account was created. The timestamp is in RFC3339 format.

### Response Codes

- **200 OK** — Successfully updated the specified user's information.
- **400 Bad Request**
  - The string in the *description* query parameter is too long.
  - The text in the *description* query parameter doesn't meet Twitch's moderation standards.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:edit** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.
- **429 Too Many Requests** — The app exceeded the number of requests that it may make.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/users?description=BaldAngel' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "44322889",
      "login": "dallas",
      "display_name": "dallas",
      "type": "staff",
      "broadcaster_type": "affiliate",
      "description": "BaldAngel",
      "profile_image_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/4d1f36cbf1f0072d-profile_image-300x300.png",
      "offline_image_url": "https://static-cdn.jtvnw.net/jtv_user_pictures/dallas-channel_offline_image-2e82c1df2a464df7-1920x1080.jpeg",
      "view_count": 0,
      "email": "not-real@email.com",
      "created_at": "2013-06-03T19:12:02Z"
    }
  ]
}
```

## Get User Block List {#get-user-block-list}

Gets the list of users that the broadcaster has blocked. [Read
More](https://help.twitch.tv/s/article/how-to-manage-harassment-in-chat?language=en_US#BlockWhispersandMessagesfromStrangers)

### Endpoint

`GET https://api.twitch.tv/helix/users/blocks`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:blocked_users** or **user:manage:blocked_users** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose list of blocked users you want to get.
- `user_id` — String
  A list of user IDs used to filter the results. To specify more than one ID, include this
  parameter for each user you want to check. For example, 'user_id=1234&user_id=5678'. You may
  specify a maximum of 100 IDs.

  The returned list includes only those users that the broadcaster has blocked. If you specify
  this parameter, the *first* and *after* query parameters are ignored, the response's
  `pagination` object is empty, and the list is in no particular order.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of blocked users. If the request doesn't specify *user_id*, the list is in descending order by when the user was blocked.
  - `data.user_id` — String. An ID that identifies the blocked user.
  - `data.user_login` — String. The blocked user's login name.
  - `data.display_name` — String. The blocked user's display name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of blocked users.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The request exceeds the maximum number of *user_id* query parameters that you may specify.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID found in the request's access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:read:blocked_users** or **user:manage:blocked_users** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/users/blocks?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "135093069",
      "user_login": "bluelava",
      "display_name": "BlueLava"
    },
    {
      "user_id": "27419011",
      "user_login": "travistyoj",
      "display_name": "TravistyOJ"
    }
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"
  }
}
```

## Block User {#block-user}

Blocks the specified user from interacting with or having contact with the broadcaster.
The User ID in the OAuth token identifies the broadcaster who is blocking the user.

To learn more about blocking users, see [Block Other Users on
Twitch](https://help.twitch.tv/s/article/how-to-manage-harassment-in-chat?language=en_US#BlockWhispersandMessagesfromStrangers).

### Endpoint

`PUT https://api.twitch.tv/helix/users/blocks`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:manage:blocked_users** scope.

### Query Parameters

- `target_user_id` — String, **Required**. The ID of the user to block. If the broadcaster has already blocked the user, the API replaces the existing block.
- `source_context` — String. The location where the harassment took place that is causing the brodcaster to block the user.
  Possible values:
  - `chat`
  - `whisper`
- `reason` — String. The reason that the broadcaster is blocking the user.
  Possible values:
  - `harassment`
  - `spam`
  - `other`

### Response Codes

- **204 No Content** — Successfully blocked the user.
- **400 Bad Request**
  - The *target_user_id* query parameter is required.
  - The ID in *target_user_id* cannot be the same as the user ID in the access token.
  - The value in *source_context* is not valid.
  - The value in *reason* is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:manage:blocked_users** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/users/blocks?target_user_id=198704263' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Unblock User {#unblock-user}

Removes the user from the broadcaster's list of blocked users. The user ID in the OAuth token identifies the broadcaster who's removing the block.

### Endpoint

`DELETE https://api.twitch.tv/helix/users/blocks`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:manage:blocked_users** scope.

### Query Parameters

- `target_user_id` — String, **Required**. The ID of the user to remove from the broadcaster's list of blocked users. The API ignores the request if the broadcaster hasn't blocked the user.

### Response Codes

- **204 No Content** — Successfully removed the block.
- **400 Bad Request**
  - The *target_user_id* query parameter is required.
  - The ID in *target_user_id* cannot be the same as the user ID in the access token.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:manage:blocked_users** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/users/blocks?target_user_id=198704263' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get User Active Extensions {#get-user-active-extensions}

Gets the active extensions that the broadcaster has installed for each configuration.

> **Note** An active extension version that isn't released (for example, one in Hosted Test) is included only
> if you specify a user access token and that user is on the version's Testing Account Allowlist.
> The account that created the version is on the allowlist automatically, and no scope is required.
> If the version isn't included, its slot contains only the `active` field, set to **false**.

### Endpoint

`GET https://api.twitch.tv/helix/users/extensions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `user_id` — String
  The ID of the broadcaster whose active extensions you want to get.

  This parameter is required if you specify an app access token and is optional if you specify
  a user access token. If you specify a user access token and don't specify this parameter,
  the API uses the user ID from the access token.

### Response Body

- `data` — Object. The active extensions that the broadcaster has installed.
  - `data.panel` — map[string]Object. A dictionary that contains the data for a panel extension. The dictionary always contains the keys 1, 2, and 3, one for each panel slot. The following fields contain the panel's data for each key.
    - `data.panel.active` — Boolean. A Boolean value that determines the extension's activation state. If **false**, the user has not configured this panel extension, and the object contains only this field.
    - `data.panel.id` — String. An ID that identifies the extension.
    - `data.panel.version` — String. The extension's version.
    - `data.panel.name` — String. The extension's name.
  - `data.overlay` — map[string]Object. A dictionary that contains the data for a video-overlay extension. The dictionary always contains the key 1, for the single overlay slot. The following fields contain the overlay's data for that key.
    - `data.overlay.active` — Boolean. A Boolean value that determines the extension's activation state. If **false**, the user has not configured this overlay extension, and the object contains only this field.
    - `data.overlay.id` — String. An ID that identifies the extension.
    - `data.overlay.version` — String. The extension's version.
    - `data.overlay.name` — String. The extension's name.
  - `data.component` — map[string]Object. A dictionary that contains the data for a video-component extension. The dictionary always contains the keys 1 and 2, one for each component slot. The following fields contain the component's data for each key.
    - `data.component.active` — Boolean. A Boolean value that determines the extension's activation state. If **false**, the user has not configured this component extension, and the object contains only this field.
    - `data.component.id` — String. An ID that identifies the extension.
    - `data.component.version` — String. The extension's version.
    - `data.component.name` — String. The extension's name.
    - `data.component.x` — Integer. The x-coordinate where the extension is placed.
    - `data.component.y` — Integer. The y-coordinate where the extension is placed.

### Response Codes

- **200 OK** — Successfully retrieved the user's active extensions.
- **400 Bad Request**
  - The *user_id* query parameter is required if you specify an app access token.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/users/extensions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": {
    "panel": {
      "1": {
        "active": true,
        "id": "rh6jq1q334hqc2rr1qlzqbvwlfl3x0",
        "version": "1.1.0",
        "name": "TopClip"
      },
      "2": {
        "active": true,
        "id": "wi08ebtatdc7oj83wtl9uxwz807l8b",
        "version": "1.1.8",
        "name": "Streamlabs Leaderboard"
      },
      "3": {
        "active": true,
        "id": "naty2zwfp7vecaivuve8ef1hohh6bo",
        "version": "1.0.9",
        "name": "Streamlabs Stream Schedule & Countdown"
      }
    },
    "overlay": {
      "1": {
        "active": true,
        "id": "zfh2irvx2jb4s60f02jq0ajm8vwgka",
        "version": "1.0.19",
        "name": "Streamlabs"
      }
    },
    "component": {
      "1": {
        "active": true,
        "id": "lqnf3zxk0rv0g7gq92mtmnirjz2cjj",
        "version": "0.0.1",
        "name": "Dev Experience Test",
        "x": 0,
        "y": 0
      },
      "2": {
        "active": false
      }
    }
  }
}
```

## Update User Extensions {#update-user-extensions}

Updates an installed extension's information. You can update the extension's activation state, ID, and version number.
The User ID in the access token identifies the broadcaster whose extensions you're updating.

> **Note** If you try to activate an extension under multiple extension types, the last write wins (and there is no guarantee of write order).

### Endpoint

`PUT https://api.twitch.tv/helix/users/extensions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:edit:broadcast** or **channel:manage:extensions** scope.

### Request Body

- `data` — Object, **Required**
  The extensions to update. The *data* field is a dictionary of extension types. The
  dictionary's possible keys are: panel, overlay, or component. The key's value is a
  dictionary of extensions.

  For the extension's dictionary, the key is a sequential number beginning with 1. For panel
  and overlay extensions, the key's value is an object that contains the following fields:
  `active` (true/false), `id` (the extension's ID), and `version` (the extension's version).

  For component extensions, the key's value includes the above fields plus the `x` and `y`
  fields, which identify the coordinate where the extension is placed.

### Response Body

- `data` — Object. The extensions that the broadcaster updated.
  - `data.panel` — map[string]Object. A dictionary that contains the data for a panel extension. The dictionary's key is a sequential number beginning with 1. The following fields contain the panel's data for each key.
    - `data.panel.active` — Boolean. A Boolean value that determines the extension's activation state. If **false**, the user has not configured a panel extension.
    - `data.panel.id` — String. An ID that identifies the extension.
    - `data.panel.version` — String. The extension's version.
    - `data.panel.name` — String. The extension's name.
  - `data.overlay` — map[string]Object. A dictionary that contains the data for a video-overlay extension. The dictionary's key is a sequential number beginning with 1. The following fields contain the overlay's data for each key.
    - `data.overlay.active` — Boolean. A Boolean value that determines the extension's activation state. If **false**, the user has not configured an overlay extension.
    - `data.overlay.id` — String. An ID that identifies the extension.
    - `data.overlay.version` — String. The extension's version.
    - `data.overlay.name` — String. The extension's name.
  - `data.component` — map[string]Object. A dictionary that contains the data for a video-component extension. The dictionary's key is a sequential number beginning with 1. The following fields contain the component's data for each key.
    - `data.component.active` — Boolean. A Boolean value that determines the extension's activation state. If **false**, the user has not configured a component extension.
    - `data.component.id` — String. An ID that identifies the extension.
    - `data.component.version` — String. The extension's version.
    - `data.component.name` — String. The extension's name.
    - `data.component.x` — Integer. The x-coordinate where the extension is placed.
    - `data.component.y` — Integer. The y-coordinate where the extension is placed.

### Response Codes

- **200 OK** — Successfully updated the active extensions.
- **400 Bad Request**
  - The JSON payload is malformed.
  - The value in an extension's `active` field is not a Boolean value.
  - The value in a component extension's `x` or `y` field is not an integer.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:edit:broadcast** or **channel:manage:extensions** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.
- **404 Not Found**
  - An extension with the specified `id` and `version` values was not found.
- **409 Conflict**
  - The extension that you're activating isn't installed on the broadcaster's channel.
- **422 Unprocessable Entity**
  - The extension can't be activated as the specified extension type (panel, overlay, or component).

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/users/extensions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"data":{"panel":{"1":{"active":true,"id":"rh6jq1q334hqc2rr1qlzqbvwlfl3x0","version":"1.1.0"},"2":{"active":true,"id":"wi08ebtatdc7oj83wtl9uxwz807l8b","version":"1.1.8"},"3":{"active":true,"id":"naty2zwfp7vecaivuve8ef1hohh6bo","version":"1.0.9"}},"overlay":{"1":{"active":true,"id":"zfh2irvx2jb4s60f02jq0ajm8vwgka","version":"1.0.19"}},"component":{"1":{"active":true,"id":"lqnf3zxk0rv0g7gq92mtmnirjz2cjj","version":"0.0.1","x":0,"y":0},"2":{"active":false}}}}'
```

### Response Example

```json
{
  "data": {
    "panel": {
      "1": {
        "active": true,
        "id": "rh6jq1q334hqc2rr1qlzqbvwlfl3x0",
        "version": "1.1.0",
        "name": "TopClip"
      },
      "2": {
        "active": true,
        "id": "wi08ebtatdc7oj83wtl9uxwz807l8b",
        "version": "1.1.8",
        "name": "Streamlabs Leaderboard"
      },
      "3": {
        "active": true,
        "id": "naty2zwfp7vecaivuve8ef1hohh6bo",
        "version": "1.0.9",
        "name": "Streamlabs Stream Schedule & Countdown"
      }
    },
    "overlay": {
      "1": {
        "active": true,
        "id": "zfh2irvx2jb4s60f02jq0ajm8vwgka",
        "version": "1.0.19",
        "name": "Streamlabs"
      }
    },
    "component": {
      "1": {
        "active": true,
        "id": "lqnf3zxk0rv0g7gq92mtmnirjz2cjj",
        "version": "0.0.1",
        "name": "Dev Experience Test",
        "x": 0,
        "y": 0
      },
      "2": {
        "active": false
      }
    }
  }
}
```

## Get User Extensions {#get-user-extensions}

Gets a list of all extensions (both active and inactive) that the broadcaster has installed.
The user ID in the access token identifies the broadcaster.

### Endpoint

`GET https://api.twitch.tv/helix/users/extensions/list`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:broadcast**, **user:edit:broadcast**, or **channel:manage:extensions** scope.

### Response Body

- `data` — Object[]. The list of extensions that the user has installed.
  - `data.id` — String. An ID that identifies the extension.
  - `data.version` — String. The extension's version.
  - `data.name` — String. The extension's name.
  - `data.can_activate` — Boolean. A Boolean value that determines whether the extension is configured and can be activated. Is **true** if the extension is configured and can be activated.
  - `data.type` — String[]. The extension types that you can activate for this extension.
    Possible values:
    - `component`
    - `mobile`
    - `overlay`
    - `panel`

### Response Codes

- **200 OK** — Successfully retrieved the user's installed extensions.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:read:broadcast**, **user:edit:broadcast**, or **channel:manage:extensions** scope.
  - The access token is not valid.
  - The ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/users/extensions/list' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "wi08ebtatdc7oj83wtl9uxwz807l8b",
      "version": "1.1.8",
      "name": "Streamlabs Leaderboard",
      "can_activate": true,
      "type": [
        "panel"
      ]
    },
    {
      "id": "d4uvtfdr04uq6raoenvj7m86gdk16v",
      "version": "2.0.2",
      "name": "Prime Subscription and Loot Reminder",
      "can_activate": true,
      "type": [
        "overlay"
      ]
    },
    {
      "id": "rh6jq1q334hqc2rr1qlzqbvwlfl3x0",
      "version": "1.1.0",
      "name": "TopClip",
      "can_activate": true,
      "type": [
        "mobile",
        "panel"
      ]
    },
    {
      "id": "zfh2irvx2jb4s60f02jq0ajm8vwgka",
      "version": "1.0.19",
      "name": "Streamlabs",
      "can_activate": true,
      "type": [
        "mobile",
        "overlay"
      ]
    },
    {
      "id": "lqnf3zxk0rv0g7gq92mtmnirjz2cjj",
      "version": "0.0.1",
      "name": "Dev Experience Test",
      "can_activate": true,
      "type": [
        "component",
        "mobile",
        "panel",
        "overlay"
      ]
    }
  ]
}
```
