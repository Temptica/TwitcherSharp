# Chat

Manage and interact with Twitch Chat.

Source: https://dev.twitch.tv/docs/api/reference/chat/

## Contents {#contents}

19 entries on this page:

- [Send Chat Announcement](#send-chat-announcement)
- [Get Channel Chat Badges](#get-channel-chat-badges)
- [Get Global Chat Badges](#get-global-chat-badges)
- [Get Chatters](#get-chatters)
- [Get User Chat Color](#get-user-chat-color)
- [Update User Chat Color](#update-user-chat-color)
- [Get Channel Emotes](#get-channel-emotes)
- [Get Global Emotes](#get-global-emotes)
- [Get Emote Sets](#get-emote-sets)
- [Get User Emotes](#get-user-emotes)
- [Send Chat Message](#send-chat-message)
- [Get Pinned Chat Message](#get-pinned-chat-message)
- [Pin Chat Message](#pin-chat-message)
- [Update Pinned Chat Message](#update-pinned-chat-message)
- [Unpin Chat Message](#unpin-chat-message)
- [Get Chat Settings](#get-chat-settings)
- [Update Chat Settings](#update-chat-settings)
- [Send a Shoutout](#send-a-shoutout)
- [Get Shared Chat Session](#get-shared-chat-session)

## Send Chat Announcement {#send-chat-announcement}

Sends an announcement to the broadcaster's chat room.

**Rate Limits**: One announcement may be sent every 2 seconds.

**NOTE:** When sending announcements during a Shared Chat session, behaviors differ depending on
your authentication token type:

- When using an *App Access Token*, announcements will only be sent to the source channel (defined
by the _broadcaster\_id_ parameter) by default. Announcements can be sent to all channels by using
the *for_source_only* parameter and setting it to `false`.

- When using a *User Access Token*, announcements will be sent to all channels in the shared chat
session, including the source channel. This behavior cannot be changed with this token type.

### Endpoint

`POST https://api.twitch.tv/helix/chat/announcements`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:announcements** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:announcements**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.
  - The **channel:bot** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room to send the announcement to.
- `moderator_id` — String, **Required**. The ID of a user who has permission to moderate the broadcaster's chat room, or the broadcaster's ID if they're sending the announcement. This ID must match the user ID in the user access token.

### Request Body

- `message` — String, **Required**. The announcement to make in the broadcaster's chat room. Announcements are limited to a maximum of 500 characters; announcements longer than 500 characters are truncated.
- `color` — String. The color used to highlight the announcement.
  Possible values:
  - `blue`
  - `green`
  - `orange`
  - `purple`
  - `primary`: This is the default value.
- `for_source_only` — Boolean
  **NOTE:** This parameter can only be set when utilizing an App Access Token. It cannot be
  specified when a User Access Token is used, and will instead result in an HTTP 400 error.

  Determines if the chat announcement is sent only to the source channel (defined by
  *broadcaster_id*) during a shared chat session. This has no effect if the announcement is
  not sent during a shared chat session.

  The default value when using an App Access Token is **true**. If you prefer to send an
  announcement to all channels in a shared chat session, set this parameter to **false**.

### Response Codes

- **204 No Content** — Twitch accepted the announcement, though it may still be dropped before it appears in chat (for example, if AutoMod blocks it).
- **400 Bad Request**
  - The *message* field in the request's body is required.
  - The *message* field may not contain an empty string.
  - The string in the *message* field failed review.
  - The specified color is not valid.
  - Cannot set *for_source_only* if User Access Token is used.
- **401 Unauthorized**
  - The Authorization header is required and must contain an access token.
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token is missing the **moderator:manage:announcements** scope.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
  - The sender must have authorized the app with the **moderator:manage:announcements** and **user:bot** scopes.
  - The broadcaster must have authorized the app with the **channel:bot** scope.
- **403 Forbidden** — The user in *moderator_id* does not have permission to send announcements in the broadcaster's chat room.
- **429 Too Many Requests** — The broadcaster's chat room exceeded the number of announcements it may receive within a given window, no matter who sent them.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/chat/announcements?broadcaster_id=11111&moderator_id=44444' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"message":"Hello chat!","color":"purple"}'
```

## Get Channel Chat Badges {#get-channel-chat-badges}

Gets the broadcaster's list of custom chat badges.

The list is empty if the broadcaster hasn't created custom chat badges. For information about
custom badges, see [subscriber badges](https://help.twitch.tv/s/article/subscriber-badge-guide)
and [Bits badges](https://help.twitch.tv/s/article/custom-bit-badges-guide).

### Endpoint

`GET https://api.twitch.tv/helix/chat/badges`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose chat badges you want to get.

### Response Body

- `data` — Object[]. The list of chat badges. The list is sorted in ascending order by `set_id`, and within a set, the list is sorted in ascending order by `id`. The IDs are compared as strings, not as numbers, so '10000' sorts before '5000'.
  - `data.set_id` — String. An ID that identifies this set of chat badges. For example, Bits or Subscriber.
  - `data.versions` — Object[]. The list of chat badges in this set.
    - `data.versions.id` — String. An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
    - `data.versions.image_url_1x` — String. A URL to the small version (18px x 18px) of the badge.
    - `data.versions.image_url_2x` — String. A URL to the medium version (36px x 36px) of the badge.
    - `data.versions.image_url_4x` — String. A URL to the large version (72px x 72px) of the badge.
    - `data.versions.title` — String. The title of the badge.
    - `data.versions.description` — String. The description of the badge.
    - `data.versions.click_action` — String, Nullable. The action to take when clicking on the badge. Set to **null** if no action is specified.
    - `data.versions.click_url` — String, Nullable. The URL to navigate to when clicking on the badge. Set to **null** if no URL is specified.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's custom chat badges.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/badges?broadcaster_id=135093069' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "set_id": "bits",
      "versions": [
        {
          "id": "1",
          "image_url_1x": "https://static-cdn.jtvnw.net/badges/v1/743a0f3b-84b3-450b-96a0-503d7f4a9764/1",
          "image_url_2x": "https://static-cdn.jtvnw.net/badges/v1/743a0f3b-84b3-450b-96a0-503d7f4a9764/2",
          "image_url_4x": "https://static-cdn.jtvnw.net/badges/v1/743a0f3b-84b3-450b-96a0-503d7f4a9764/3",
          "title": "cheer 1",
          "description": "cheer 1",
          "click_action": "visit_url",
          "click_url": "https://bits.twitch.tv"
        }
      ]
    },
    {
      "set_id": "subscriber",
      "versions": [
        {
          "id": "0",
          "image_url_1x": "https://static-cdn.jtvnw.net/badges/v1/eb4a8a4c-eacd-4f5e-b9f2-394348310442/1",
          "image_url_2x": "https://static-cdn.jtvnw.net/badges/v1/eb4a8a4c-eacd-4f5e-b9f2-394348310442/2",
          "image_url_4x": "https://static-cdn.jtvnw.net/badges/v1/eb4a8a4c-eacd-4f5e-b9f2-394348310442/3",
          "title": "Subscriber",
          "description": "Subscriber",
          "click_action": "subscribe_to_channel",
          "click_url": null
        }
      ]
    }
  ]
}
```

## Get Global Chat Badges {#get-global-chat-badges}

Gets Twitch's list of chat badges, which users may use in any channel's chat room. For information
about chat badges, see [Twitch Chat Badges
Guide](https://help.twitch.tv/s/article/twitch-chat-badges-guide).

### Endpoint

`GET https://api.twitch.tv/helix/chat/badges/global`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Response Body

- `data` — Object[]. The list of chat badges. The list is sorted in ascending order by `set_id`, and within a set, the list is sorted in ascending order by `id`. The IDs are compared as strings, not as numbers, so '10000' sorts before '5000'.
  - `data.set_id` — String. An ID that identifies this set of chat badges. For example, Bits or Subscriber.
  - `data.versions` — Object[]. The list of chat badges in this set.
    - `data.versions.id` — String. An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
    - `data.versions.image_url_1x` — String. A URL to the small version (18px x 18px) of the badge.
    - `data.versions.image_url_2x` — String. A URL to the medium version (36px x 36px) of the badge.
    - `data.versions.image_url_4x` — String. A URL to the large version (72px x 72px) of the badge.
    - `data.versions.title` — String. The title of the badge.
    - `data.versions.description` — String. The description of the badge.
    - `data.versions.click_action` — String, Nullable. The action to take when clicking on the badge. Set to **null** if no action is specified.
    - `data.versions.click_url` — String, Nullable. The URL to navigate to when clicking on the badge. Set to **null** if no URL is specified.

### Response Codes

- **200 OK** — Successfully retrieved the list of global chat badges.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/badges/global' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    ...
    {
      "set_id": "vip",
      "versions": [
        {
          "id": "1",
          "image_url_1x": "https://static-cdn.jtvnw.net/badges/v1/b817aba4-fad8-49e2-b88a-7cc744dfa6ec/1",
          "image_url_2x": "https://static-cdn.jtvnw.net/badges/v1/b817aba4-fad8-49e2-b88a-7cc744dfa6ec/2",
          "image_url_4x": "https://static-cdn.jtvnw.net/badges/v1/b817aba4-fad8-49e2-b88a-7cc744dfa6ec/3",
          "title": "VIP",
          "description": "VIP",
          "click_action": "visit_url",
          "click_url": "https://help.twitch.tv/customer/en/portal/articles/659115-twitch-chat-badges-guide"
        }
      ]
    },
    ...
  ]
}
```

## Get Chatters {#get-chatters}

Gets the list of users that are connected to the broadcaster's chat session.

To determine whether a user is a moderator or VIP, use the [Get Moderators](https://dev.twitch.tv/docs/api/reference/moderation.md#get-moderators)
and [Get VIPs](https://dev.twitch.tv/docs/api/reference/moderation.md#get-vips) endpoints. You can check the roles of up to 100 users.

> **Note** There is a delay between when users join and leave a chat and when the list is updated accordingly.

### Endpoint

`GET https://api.twitch.tv/helix/chat/chatters`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:chatters** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:read:chatters** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose list of chatters you want to get.
- `moderator_id` — String, **Required**. The ID of the broadcaster or one of the broadcaster's moderators. This ID must match the user ID in the user access token.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 1,000. The default is 100.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of users that are connected to the broadcaster's chat room. The list is empty if no users are connected to the chat room.
  - `data.user_id` — String. The ID of a user that's connected to the broadcaster's chat room.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.
- `total` — Integer. The total number of users that are connected to the broadcaster's chat room. As you page through the list, the number of users may change as users join and leave the chat room.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of chatters.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *moderator_id* query parameter is required.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
  - The cursor specified in the *after* query parameter is past the end of the list, which can happen if users left the chat room after you got the cursor.
- **401 Unauthorized**
  - The ID in the *moderator_id* query parameter must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:read:chatters** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:read:chatters** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in the *moderator_id* query parameter is not one of the broadcaster's moderators.
- **404 Not Found**
  - The ID in the *broadcaster_id* query parameter was not found.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/chatters?broadcaster_id=123456&moderator_id=654321' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "128393656",
      "user_login": "smittysmithers",
      "user_name": "smittysmithers"
    },
    ...
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"
  },
  "total": 8
}
```

## Get User Chat Color {#get-user-chat-color}

Gets the color used for the user's name in chat.

### Endpoint

`GET https://api.twitch.tv/helix/chat/color`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `user_id` — String, **Required**
  The ID of the user whose username color you want to get. To specify more than one user,
  include the *user_id* parameter for each user to get. For example,
  '&user_id=1234&user_id=5678'. The maximum number of IDs that you may specify is 100.

  The API ignores duplicate IDs and IDs that weren't found, but duplicate IDs count toward the
  maximum.

### Response Body

- `data` — Object[], Nullable. The list of users and the color code they use for their name. Is **null** if none of the specified users were found.
  - `data.user_id` — String. An ID that uniquely identifies the user.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.color` — String. The Hex color code that the user uses in chat for their name. If the user hasn't specified a color in their settings, the string is empty.

### Response Codes

- **200 OK** — Successfully retrieved the chat color used by the specified users.
- **400 Bad Request**
  - The *user_id* query parameter is required.
  - The ID in the *user_id* query parameter is not valid.
  - The number of *user_id* query parameters exceeds the maximum allowed.
- **401 Unauthorized**
  - The Authorization header is required and must contain an app access token or user access token.
  - The OAuth token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/color?user_id=11111' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "11111",
      "user_name": "SpeedySpeedster1",
      "user_login": "speedyspeedster1",
      "color": "#9146FF"
    }
  ]
}
```

## Update User Chat Color {#update-user-chat-color}

Updates the color used for the user's name in chat.

### Endpoint

`PUT https://api.twitch.tv/helix/chat/color`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:manage:chat_color** scope.

### Query Parameters

- `user_id` — String, **Required**. The ID of the user whose chat color you want to update. This ID must match the user ID in the access token.
- `color` — String, **Required**. The color to use for the user's name in chat. All users may specify one of the following named color values.
  Possible values:
  - `(any hex code)`: Turbo and Prime users may specify a named color or a Hex color code such as \#9146FF. If you use a Hex color code, remember to URL encode it.
  - `blue`
  - `blue_violet`
  - `cadet_blue`
  - `chocolate`
  - `coral`
  - `dodger_blue`
  - `firebrick`
  - `golden_rod`
  - `green`
  - `hot_pink`
  - `orange_red`
  - `red`
  - `sea_green`
  - `spring_green`
  - `yellow_green`

### Response Codes

- **204 No Content** — Successfully updated the user's chat color.
- **400 Bad Request**
  - The ID in the *user_id* query parameter is not valid.
  - The *color* query parameter is required.
  - The named color in the *color* query parameter is not valid.
  - To specify a Hex color code, the user must be a Turbo or Prime user.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:manage:chat_color** scope.
  - The OAuth token is not valid.
  - The ID in the *user_id* query parameter must match the user ID in the access token.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/chat/color?user_id=123&color=blue' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Channel Emotes {#get-channel-emotes}

Gets the broadcaster's list of custom emotes.

Broadcasters create these custom emotes for users who subscribe to or follow the channel or cheer
Bits in the channel's chat window. [Learn More](https://dev.twitch.tv/docs/chat/irc.md)

For information about the custom emotes, see [subscriber emotes](https://help.twitch.tv/s/article/subscriber-emote-guide),
[Bits tier emotes](https://help.twitch.tv/s/article/custom-bit-badges-guide?language=bg#slots),
and [follower emotes](https://blog.twitch.tv/en/2021/06/04/kicking-off-10-years-with-our-biggest-emote-update-ever/).

**NOTE:** With the exception of custom follower emotes, users may use custom emotes in any Twitch chat.

### Endpoint

`GET https://api.twitch.tv/helix/chat/emotes`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. An ID that identifies the broadcaster whose emotes you want to get.

### Response Body

- `data` — Object[]. The list of emotes that the specified broadcaster created. If the broadcaster hasn't created custom emotes, the list is empty.
  - `data.id` — String. An ID that identifies this emote.
  - `data.name` — String. The name of the emote. This is the name that viewers type in the chat window to get the emote to appear.
  - `data.images` — Object. The image URLs for the emote. These image URLs always provide a static, non-animated emote image with a light background. **NOTE:** You should use the templated URL in the `template` field to fetch the image instead of using these URLs.
    - `data.images.url_1x` — String. A URL to the small version (28px x 28px) of the emote.
    - `data.images.url_2x` — String. A URL to the medium version (56px x 56px) of the emote.
    - `data.images.url_4x` — String. A URL to the large version (112px x 112px) of the emote.
  - `data.tier` — String. The subscriber tier at which the emote is unlocked. This field contains the tier information only if `emote_type` is set to **subscriptions**, otherwise, it's an empty string.
  - `data.emote_type` — String. The type of emote.
    Possible values:
    - `none`: No emote type was assigned to this emote.
    - `bitstier`: A custom Bits tier emote.
    - `follower`: A custom follower emote.
    - `subscriptions`: A custom subscriber emote.
    - `channelpoints`: An emote granted by using channel points.
    - `rewards`: An emote granted to the user through a special event.
    - `hypetrain`: An emote granted for participation in a Hype Train.
    - `prime`: An emote granted for linking an Amazon Prime account.
    - `turbo`: An emote granted for having Twitch Turbo.
    - `smilies`: Emoticons supported by Twitch.
    - `globals`: An emote accessible by everyone.
    - `owl2019`: Emotes related to Overwatch League 2019.
    - `twofactor`: Emotes granted by enabling two-factor authentication on an account.
    - `limitedtime`: Emotes that were granted for only a limited time.
  - `data.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
  - `data.format` — String[]
    The formats that the emote is available in. For example, if the emote is available only
    as a static PNG, the array contains only **static**. But if the emote is available as a
    static PNG and an animated GIF, the array contains **static** and **animated**. The possible
    formats are:

    - animated — An animated GIF is available for this emote.

    - static — A static PNG file is available for this emote.
  - `data.scale` — String[]
    The sizes that the emote is available in. For example, if the emote is available in
    small and medium sizes, the array contains 1.0 and 2.0. Possible sizes are:

    - 1.0 — A small version (28px x 28px) is available.

    - 2.0 — A medium version (56px x 56px) is available.

    - 3.0 — A large version (112px x 112px) is available.
  - `data.theme_mode` — String[]
    The background themes that the emote is available in. Possible themes are:

    - dark
    - light
- `template` — String. A templated URL. Use the values from the `id`, `format`, `scale`, and `theme_mode` fields to replace the like-named placeholder strings in the templated URL to create a CDN (content delivery network) URL that you use to fetch the emote. For information about what the template looks like and how to use it to fetch emotes, see [Emote CDN URL format](https://dev.twitch.tv/docs/chat/send-receive-messages.md#handling-emotes). You should use this template instead of using the URLs in the `images` object.

### Response Codes

- **200 OK** — Successfully retrieved broadcaster's list of custom emotes.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/emotes?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "304456832",
      "name": "twitchdevPitchfork",
      "images": {
        "url_1x": "https://static-cdn.jtvnw.net/emoticons/v2/304456832/static/light/1.0",
        "url_2x": "https://static-cdn.jtvnw.net/emoticons/v2/304456832/static/light/2.0",
        "url_4x": "https://static-cdn.jtvnw.net/emoticons/v2/304456832/static/light/3.0"
      },
      "tier": "1000",
      "emote_type": "subscriptions",
      "emote_set_id": "301590448",
      "format": [
        "static"
      ],
      "scale": [
        "1.0",
        "2.0",
        "3.0"
      ],
      "theme_mode": [
        "light",
        "dark"
      ]
    },
    ...
    {
      "id": "emotesv2_4c3b4ed516de493bbcd2df2f5d450f49",
      "name": "twitchdevHyperPitchfork",
      "images": {
        "url_1x": "https://static-cdn.jtvnw.net/emoticons/v2/emotesv2_4c3b4ed516de493bbcd2df2f5d450f49/static/light/1.0",
        "url_2x": "https://static-cdn.jtvnw.net/emoticons/v2/emotesv2_4c3b4ed516de493bbcd2df2f5d450f49/static/light/2.0",
        "url_4x": "https://static-cdn.jtvnw.net/emoticons/v2/emotesv2_4c3b4ed516de493bbcd2df2f5d450f49/static/light/3.0"
      },
      "tier": "1000",
      "emote_type": "subscriptions",
      "emote_set_id": "318939165",
      "format": [
        "static",
        "animated"
      ],
      "scale": [
        "1.0",
        "2.0",
        "3.0"
      ],
      "theme_mode": [
        "light",
        "dark"
      ]
    }
  ],
  "template": "https://static-cdn.jtvnw.net/emoticons/v2/{{id}}/{{format}}/{{theme_mode}}/{{scale}}"
}
```

## Get Global Emotes {#get-global-emotes}

Gets the list of [global emotes](https://www.twitch.tv/creatorcamp/en/learn-the-basics/emotes/).
Global emotes are Twitch-created emotes that users can use in any Twitch chat.

[Learn More](https://dev.twitch.tv/docs/chat/irc.md)

### Endpoint

`GET https://api.twitch.tv/helix/chat/emotes/global`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Response Body

- `data` — Object[]. The list of global emotes.
  - `data.id` — String. An ID that identifies this emote.
  - `data.name` — String. The name of the emote. This is the name that viewers type in the chat window to get the emote to appear.
  - `data.images` — Object
    The image URLs for the emote. These image URLs always provide a static, non-animated
    emote image with a light background.

    **NOTE:** You should use the templated URL in the `template` field to fetch the image
    instead of using these URLs.
    - `data.images.url_1x` — String. A URL to the small version (28px x 28px) of the emote.
    - `data.images.url_2x` — String. A URL to the medium version (56px x 56px) of the emote.
    - `data.images.url_4x` — String. A URL to the large version (112px x 112px) of the emote.
  - `data.format` — String[]
    The formats that the emote is available in. For example, if the emote is available only
    as a static PNG, the array contains only **static**. But if the emote is available as a
    static PNG and an animated GIF, the array contains **static** and **animated**. The possible
    formats are:

    - animated — An animated GIF is available for this emote.

    - static — A static PNG file is available for this emote.
  - `data.scale` — String[]
    The sizes that the emote is available in. For example, if the emote is available in
    small and medium sizes, the array contains 1.0 and 2.0. Possible sizes are:

    - 1.0 — A small version (28px x 28px) is available.

    - 2.0 — A medium version (56px x 56px) is available.

    - 3.0 — A large version (112px x 112px) is available.
  - `data.theme_mode` — String[]
    The background themes that the emote is available in. Possible themes are:

    - dark
    - light
- `template` — String. A templated URL. Use the values from the `id`, `format`, `scale`, and `theme_mode` fields to replace the like-named placeholder strings in the templated URL to create a CDN (content delivery network) URL that you use to fetch the emote. For information about what the template looks like and how to use it to fetch emotes, see [Emote CDN URL format](https://dev.twitch.tv/docs/chat/send-receive-messages.md#handling-emotes). You should use this template instead of using the URLs in the `images` object.

### Response Codes

- **200 OK** — Successfully retrieved Twitch's list of global emotes.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/emotes/global' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "196892",
      "name": "TwitchUnity",
      "images": {
        "url_1x": "https://static-cdn.jtvnw.net/emoticons/v2/196892/static/light/1.0",
        "url_2x": "https://static-cdn.jtvnw.net/emoticons/v2/196892/static/light/2.0",
        "url_4x": "https://static-cdn.jtvnw.net/emoticons/v2/196892/static/light/3.0"
      },
      "format": [
        "static"
      ],
      "scale": [
        "1.0",
        "2.0",
        "3.0"
      ],
      "theme_mode": [
        "light",
        "dark"
      ]
    },
    ...
  ],
  "template": "https://static-cdn.jtvnw.net/emoticons/v2/{{id}}/{{format}}/{{theme_mode}}/{{scale}}"
}
```

## Get Emote Sets {#get-emote-sets}

Gets emotes for one or more specified emote sets.

An emote set groups emotes that have a similar context. For example, Twitch places all the
subscriber emotes that a broadcaster uploads for their channel in the same emote set.

[Learn More](https://dev.twitch.tv/docs/chat/irc.md)

### Endpoint

`GET https://api.twitch.tv/helix/chat/emotes/set`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `emote_set_id` — String, **Required**
  An ID that identifies the emote set to get. Include this parameter for each emote set you
  want to get. For example, 'emote_set_id=1234&emote_set_id=5678'. You may specify a maximum
  of 25 IDs. The response contains only the IDs that were found and ignores duplicate IDs.

  To get emote set IDs, use the [Get Channel Emotes](#get-channel-emotes) API.

### Response Body

- `data` — Object[]. The list of emotes found in the specified emote sets. The list is empty if none of the IDs were found. Emotes from the same set are listed together, but the sets aren't in any particular order and may not match the order of the IDs in the request. Each set contains one or more emoticons.
  - `data.id` — String. An ID that uniquely identifies this emote.
  - `data.name` — String. The name of the emote. This is the name that viewers type in the chat window to get the emote to appear.
  - `data.images` — Object
    The image URLs for the emote. These image URLs always provide a static, non-animated
    emote image with a light background.

    **NOTE:** You should use the templated URL in the `template` field to fetch the image
    instead of using these URLs.
    - `data.images.url_1x` — String. A URL to the small version (28px x 28px) of the emote.
    - `data.images.url_2x` — String. A URL to the medium version (56px x 56px) of the emote.
    - `data.images.url_4x` — String. A URL to the large version (112px x 112px) of the emote.
  - `data.emote_type` — String. The type of emote.
    Possible values:
    - `none`: No emote type was assigned to this emote.
    - `bitstier`: A Bits tier emote.
    - `follower`: A follower emote.
    - `subscriptions`: A subscriber emote.
    - `channelpoints`: An emote granted by using channel points.
    - `rewards`: An emote granted to the user through a special event.
    - `hypetrain`: An emote granted for participation in a Hype Train.
    - `prime`: An emote granted for linking an Amazon Prime account.
    - `turbo`: An emote granted for having Twitch Turbo.
    - `smilies`: Emoticons supported by Twitch.
    - `globals`: An emote accessible by everyone.
    - `owl2019`: Emotes related to Overwatch League 2019.
    - `twofactor`: Emotes granted by enabling two-factor authentication on an account.
    - `limitedtime`: Emotes that were granted for only a limited time.
  - `data.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to.
  - `data.owner_id` — String. The ID of the broadcaster who owns the emote.
  - `data.format` — String[]
    The formats that the emote is available in. For example, if the emote is available only
    as a static PNG, the array contains only **static**. But if the emote is available as a
    static PNG and an animated GIF, the array contains **static** and **animated**. The possible
    formats are: 

    - animated &mdash; An animated GIF is available for this emote.

    - static &mdash; A static PNG file is available for this emote.
  - `data.scale` — String[]
    The sizes that the emote is available in. For example, if the emote is available in
    small and medium sizes, the array contains 1.0 and 2.0. Possible sizes are:

    - 1.0 &mdash; A small version (28px x 28px) is available.

    - 2.0 &mdash; A medium version (56px x 56px) is available.

    - 3.0 &mdash; A large version (112px x 112px) is available.
  - `data.theme_mode` — String[]
    The background themes that the emote is available in. Possible themes are:

    - dark

    - light
- `template` — String. A templated URL. Use the values from the `id`, `format`, `scale`, and `theme_mode` fields to replace the like-named placeholder strings in the templated URL to create a CDN (content delivery network) URL that you use to fetch the emote. For information about what the template looks like and how to use it to fetch emotes, see [Emote CDN URL format](https://dev.twitch.tv/docs/chat/send-receive-messages.md#handling-emotes). You should use this template instead of using the URLs in the `images` object.

### Response Codes

- **200 OK** — Successfully retrieved the emotes for the specified emote sets.
- **400 Bad Request**
  - The *emote_set_id* query parameter is required.
  - The number of *emote_set_id* query parameters exceeds the maximum allowed.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/emotes/set?emote_set_id=301590448' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "304456832",
      "name": "twitchdevPitchfork",
      "images": {
        "url_1x": "https://static-cdn.jtvnw.net/emoticons/v2/304456832/static/light/1.0",
        "url_2x": "https://static-cdn.jtvnw.net/emoticons/v2/304456832/static/light/2.0",
        "url_4x": "https://static-cdn.jtvnw.net/emoticons/v2/304456832/static/light/3.0"
      },
      "emote_type": "subscriptions",
      "emote_set_id": "301590448",
      "owner_id": "141981764",
      "format": [
        "static"
      ],
      "scale": [
        "1.0",
        "2.0",
        "3.0"
      ],
      "theme_mode": [
        "light",
        "dark"
      ]
    },
    ...
  ],
  "template": "https://static-cdn.jtvnw.net/emoticons/v2/{{id}}/{{format}}/{{theme_mode}}/{{scale}}"
}
```

## Get User Emotes {#get-user-emotes}

Retrieves emotes available to the user across all channels.

### Endpoint

`GET https://api.twitch.tv/helix/chat/emotes/user`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:read:emotes** scope. The User ID associated with the token must match the *user_id* in the query parameter.

### Query Parameters

- `user_id` — String, **Required**. The ID of the user. This ID must match the user ID in the user access token.
- `after` — String. The cursor used to get the next page of results. The Pagination object in the response contains the cursor's value.
- `broadcaster_id` — String
  The User ID of a broadcaster you wish to get follower emotes of. Using this query parameter
  adds the broadcaster's follower emotes to the first page of results, if the user has access
  to them, for example, because the user follows the broadcaster.

  **Note:** The response includes a broadcaster's follower emotes only if you specify that
  broadcaster in this parameter. Subscribing to the broadcaster doesn't add them.

### Response Body

- `data` — Object[]
  - `data.id` — String. An ID that uniquely identifies this emote.
  - `data.name` — String. The case-sensitive name of the emote. This is the name that viewers type in the chat window to get the emote to appear.
  - `data.emote_type` — String. The type of emote. If the emote's type is not one of the following values, this field is an empty string.
    Possible values:
    - `none`: No emote type was assigned to this emote.
    - `bitstier`: A Bits tier emote.
    - `follower`: A follower emote.
    - `subscriptions`: A subscriber emote.
    - `channelpoints`: An emote granted by using channel points.
    - `rewards`: An emote granted to the user through a special event.
    - `hypetrain`: An emote granted for participation in a Hype Train.
    - `prime`: An emote granted for linking an Amazon Prime account.
    - `turbo`: An emote granted for having Twitch Turbo.
    - `smilies`: Emoticons supported by Twitch.
    - `globals`: An emote accessible by everyone.
    - `owl2019`: Emotes related to Overwatch League 2019.
    - `twofactor`: Emotes granted by enabling two-factor authentication on an account.
    - `limitedtime`: Emotes that were granted for only a limited time.
  - `data.emote_set_id` — String. An ID that identifies the emote set that the emote belongs to. If the emote does not belong to a set, this field will be an empty string.
  - `data.owner_id` — String. The ID of the broadcaster who owns the emote. If this emote does not have an owner, this field will be an empty string.
  - `data.format` — String[]
    The formats that the emote is available in. For example, if the emote is available only
    as a static PNG, the array contains only static. But if the emote is available as a
    static PNG and an animated GIF, the array contains static and animated. 

    - **animated** — An animated GIF is available for this emote.

    - **static** — A static PNG file is available for this emote.
  - `data.scale` — String[]
    The sizes that the emote is available in. The array always contains all three sizes.

    - **1.0** — A small version (28px x 28px) is available.

    - **2.0** — A medium version (56px x 56px) is available.

    - **3.0** — A large version (112px x 112px) is available.
  - `data.theme_mode` — String[]
    The background themes that the emote is available in. The array always contains both
    themes.

    - **dark**
    - **light**
- `template` — String. A templated URL. Uses the values from the `id`, `format`, `scale`, and `theme_mode` fields to replace the like-named placeholder strings in the templated URL to create a CDN (content delivery network) URL that you use to fetch the emote. For information about what the template looks like and how to use it to fetch emotes, see [Emote CDN URL](https://dev.twitch.tv/docs/chat/send-receive-messages.md#handling-emotes) format.
- `pagination` — Object. Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. For more information about pagination support, see [Twitch API Guide - Pagination](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's after query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the emotes.
- **400 Bad Request**
  - The *user_id* query parameter is required.
  - The ID in the *user_id* query parameter is not valid.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in *user_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:read:emotes** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/emotes/user?user_id=123456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "emote_set_id": "",
      "emote_type": "hypetrain",
      "format": [
        "static"
      ],
      "id": "304420818",
      "name": "HypeLol",
      "owner_id": "477339272",
      "scale": [
        "1.0",
        "2.0",
        "3.0"
      ],
      "theme_mode": [
        "light",
        "dark"
      ]
    }
  ],
  "template": "https://static-cdn.jtvnw.net/emoticons/v2/{{id}}/{{format}}/{{theme_mode}}/{{scale}}",
  "pagination": {
    "cursor": "eyJiIjpudWxsLJxhIjoiIn0gf5"
  }
}
```

## Send Chat Message {#send-chat-message}

Sends a message to the broadcaster's chat room.

**NOTE:** When sending messages to a Shared Chat session, behaviors differ depending on your
authentication token type:

- When using an *App Access Token*, messages will only be sent to the source channel (defined by
the _broadcaster\_id_ parameter) by default starting on May 19, 2025. Messages can be sent to all
channels by using the *for_source_only* parameter and setting it to `false`.

- When using a *User Access Token*, messages will be sent to all channels in the shared chat
session, including the source channel. This behavior cannot be changed with this token type.

### Endpoint

`POST https://api.twitch.tv/helix/chat/messages`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:write:chat** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **user:write:chat**, **user:bot** scopes for the user represented by the *sender_id* body field.
  - The **channel:bot** scope for the user represented by the *broadcaster_id* body field.
    Not required if the user in *sender_id* is the broadcaster or already has moderator status.

### Request Body

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose chat room the message will be sent to.
- `sender_id` — String, **Required**. The ID of the user sending the message. This ID must match the user ID in the user access token.
- `message` — String, **Required**. The message to send. The message is limited to a maximum of 500 characters. Chat messages can also include emoticons. To include emoticons, use the name of the emote. The names are case sensitive. Don't include colons around the name (e.g., :bleedPurple:). If Twitch recognizes the name, Twitch converts the name to the emote before writing the chat message to the chat room
- `reply_parent_message_id` — String. The ID of the chat message being replied to.
- `for_source_only` — Boolean
  **NOTE:** This parameter can only be set when utilizing an App Access Token. It cannot be
  specified when a User Access Token is used, and will instead result in an HTTP 400 error.

  Determines if the chat message is sent only to the source channel (defined by
  *broadcaster_id*) during a shared chat session. This has no effect if the message is not
  sent during a shared chat session.

  If this parameter is not set, the default value when using an App Access Token is **true**.
  If you prefer to send a chat message to all channels in a shared chat session, set this
  parameter to **false**.
- `pin` — Boolean. NEW If true, the message will be sent and immediately pinned. Default: false. Cannot be combined with *reply_parent_message_id* or *for_source_only*. When *pin* is true, additionally requires the **moderator:manage:chat_messages** scope and the sender must be the broadcaster or a moderator. Messages pinned via this endpoint are always pinned for 20 minutes. If the pin fails, the message is not sent.

### Response Body

- `data` — Object[]
  - `data.message_id` — String. The message id for the message that was sent.
  - `data.is_sent` — Boolean. If the message passed all checks and was sent.
  - `data.drop_reason` — Object, Nullable. The reason the message was dropped, if any. Is **null** if the message was sent.
    - `data.drop_reason.code` — String. Code for why the message was dropped.
      Possible values:
      - `msg_duplicate`: The message is identical to the previous message the sender sent less than 30
seconds ago.
      - `user_banned`: The sender is permanently banned from the chat room.
      - `user_warned`: The sender has a warning they must acknowledge before they can chat.
      - `user_timed_out`: The sender is timed out in the chat room.
      - `emote_only_mode`: The chat room is in emote-only mode.
      - `slow_mode`: The chat room is in slow mode and the sender is sending messages too quickly.
      - `followers_only_mode`: The chat room is in followers-only mode.
      - `subs_only_mode`: The chat room is in subscribers-only mode.
      - `unique_mode`: The chat room is in unique-chat mode and the message is not unique.
      - `verified_account`: The chat room requires a verified account to chat.
      - `channel_settings`: The message conflicts with the channel's moderation settings.
      - `automod_held`: AutoMod is holding the message for review.
      - `msg_rejected`: The message could not be sent. See `message` for details.
      - `msg_bad_characters`: The message contains too many characters that cannot be processed.
      - `banned_email_alias`: The sender's email address is banned from the channel.
      - `banned_phone_alias`: The sender's phone number is banned from the channel.
      - `verified_phone_number`: The chat room requires a verified phone number to chat.
      - `channel_suspended`: The channel does not exist or is suspended.
    - `data.drop_reason.message` — String. Message for why the message was dropped.

### Response Codes

- **200 OK** — Successfully sent the specified broadcaster a message.
- **400 Bad Request**
  - The *broadcaster_id* field is required.
  - The ID in the *broadcaster_id* field is not valid.
  - The *sender_id* field is required.
  - The ID in the *sender_id* field is not valid.
  - The *message* field is required.
  - The ID in the *reply_parent_message_id* field is not valid.
  - Cannot set *for_source_only* if User Access Token is used.
  - The *reply_parent_message_id* parameter is not supported when *pin* is true.
  - The *for_source_only* parameter is not supported when *pin* is true.
  - If *pin* is true, a message that would otherwise be dropped returns this error instead of a `drop_reason`.
- **401 Unauthorized**
  - The ID in *sender_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the user:write:chat scope.
  - Pinning requires the **moderator:manage:chat_messages** scope.
  - If you use an app access token, the user in *sender_id* must have authorized your app with the **user:write:chat** and **user:bot** scopes, and also the **moderator:manage:chat_messages** scope if *pin* is true.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:bot** scope, unless the user in *sender_id* is the broadcaster or has moderator status.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden** — The sender is not permitted to send chat messages to the broadcaster's chat room.
- **422 Unprocessable Entity** — The message is too large.
- **429 Too Many Requests** — The rate limit has been exceeded.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/chat/messages' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"broadcaster_id":"12826","sender_id":"141981764","message":"Hello, world! twitchdevHype","for_source_only":true}'
```

### Response Example

```json
{
  "data": [
    {
      "message_id": "abc-123-def",
      "is_sent": true,
      "drop_reason": null
    }
  ]
}
```

## Get Pinned Chat Message {#get-pinned-chat-message}

Gets the currently pinned message for the specified broadcaster's chat room, including message fragments.
Only one mod-pinned message can be active per channel at a time.

### Endpoint

`GET https://api.twitch.tv/helix/chat/pins`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:chat_messages** or **moderator:read:chat_messages** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - All of the following, for the user represented by the *moderator_id* query parameter:
    - **moderator:manage:chat_messages** or **moderator:read:chat_messages**
    - **user:bot**
  - The **channel:bot** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Response Body

- `data` — Object[]. Pinned messages. Empty if none pinned.
  - `data.message_id` — String. The ID of the pinned chat message.
  - `data.broadcaster_id` — String. The ID of the broadcaster.
  - `data.sender_user_id` — String. The ID of the user who sent the pinned message.
  - `data.sender_user_login` — String. The login of the user who sent the pinned message.
  - `data.sender_user_name` — String. The display name of the user who sent the pinned message.
  - `data.pinned_by_user_id` — String. The ID of the user who pinned the message.
  - `data.pinned_by_user_login` — String. The login of the user who pinned the message.
  - `data.pinned_by_user_name` — String. The display name of the user who pinned the message.
  - `data.message` — Object, Nullable. The pinned message content. Null if the content isn't available.
    - `data.message.text` — String. Plain text of the message.
    - `data.message.fragments` — Object[]. Ordered list of message fragments.
      - `data.message.fragments.type` — String. The fragment type.
        Possible values:
        - `text`
        - `emote`
        - `cheermote`
        - `mention`
      - `data.message.fragments.text` — String. Fragment text.
      - `data.message.fragments.cheermote` — Object, Nullable. Cheermote metadata. Null if not a cheermote fragment.
        - `data.message.fragments.cheermote.prefix` — String. The cheermote prefix.
        - `data.message.fragments.cheermote.bits` — Integer. The number of bits cheered.
        - `data.message.fragments.cheermote.tier` — Integer. The cheermote tier.
      - `data.message.fragments.emote` — Object, Nullable. Emote metadata. Null if not an emote fragment.
        - `data.message.fragments.emote.id` — String. The emote ID.
        - `data.message.fragments.emote.emote_set_id` — String. The emote set ID.
        - `data.message.fragments.emote.owner_id` — String. The ID of the emote owner.
        - `data.message.fragments.emote.format` — String[]. The emote's format, as a single-item list: **animated** if the emote is animated; otherwise, **static**.
      - `data.message.fragments.mention` — Object, Nullable. Mention metadata. Null if not a mention fragment.
        - `data.message.fragments.mention.user_id` — String. The mentioned user's ID.
        - `data.message.fragments.mention.user_login` — String. The mentioned user's login.
        - `data.message.fragments.mention.user_name` — String. The mentioned user's display name.
  - `data.starts_at` — String. RFC3339 timestamp of when the message was pinned.
  - `data.ends_at` — String, Nullable. RFC3339 expiry timestamp. Null if pinned until stream ends.
  - `data.updated_at` — String. RFC3339 timestamp of last update.

### Response Codes

- **200 OK** — Successfully retrieved pinned message(s).
- **400 Bad Request** — A required query parameter is missing.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token or app access token.
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **moderator:manage:chat_messages** or **moderator:read:chat_messages** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **user:bot** scope and either the **moderator:manage:chat_messages** or **moderator:read:chat_messages** scope.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:bot** scope.
- **403 Forbidden** — The user in *moderator_id* doesn't have permission to pin messages in the broadcaster's chat room.
- **500 Internal Server Error** — An unexpected error occurred.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/pins?broadcaster_id=197886470&moderator_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "message_id": "abc-def-123-456",
      "broadcaster_id": "197886470",
      "sender_user_id": "12826",
      "sender_user_login": "twitch",
      "sender_user_name": "Twitch",
      "pinned_by_user_id": "141981764",
      "pinned_by_user_login": "twitchdev",
      "pinned_by_user_name": "TwitchDev",
      "message": {
        "text": "Welcome! bleedPurple Type !rules",
        "fragments": [
          {
            "type": "text",
            "text": "Welcome! ",
            "cheermote": null,
            "emote": null,
            "mention": null
          },
          {
            "type": "emote",
            "text": "bleedPurple",
            "cheermote": null,
            "emote": {
              "id": "62835",
              "emote_set_id": "0",
              "owner_id": "0",
              "format": [
                "static"
              ]
            },
            "mention": null
          },
          {
            "type": "text",
            "text": " Type !rules",
            "cheermote": null,
            "emote": null,
            "mention": null
          }
        ]
      },
      "starts_at": "2026-05-06T12:30:00Z",
      "ends_at": "2026-05-06T12:35:00Z",
      "updated_at": "2026-05-06T12:30:00Z"
    }
  ]
}
```

## Pin Chat Message {#pin-chat-message}

Pins a chat message to the top of the specified
broadcaster's chat room. Only one mod-pinned message can be active per channel at a time. If a
mod-pinned message already exists, it is automatically replaced.

### Endpoint

`PUT https://api.twitch.tv/helix/chat/pins`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:chat_messages** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:chat_messages**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.
  - The **channel:bot** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `message_id` — String, **Required**. The ID of the message to pin.
- `duration_seconds` — Integer. The number of seconds the message should be pinned for. Minimum: 30. Maximum: 1800. If not specified, the message will be pinned until the stream ends.

### Response Codes

- **204 No Content** — Successfully pinned the message.
- **400 Bad Request**
  - A required query parameter is missing or invalid.
  - The *duration_seconds* value is invalid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token or app access token.
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **moderator:manage:chat_messages** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:chat_messages** and **user:bot** scopes.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:bot** scope.
- **403 Forbidden** — The user does not have permission to pin messages in this channel.
- **404 Not Found** — The specified message was not found.
- **409 Conflict** — The message is already pinned.
- **429 Too Many Requests** — The rate limit for pinning messages has been exceeded.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/chat/pins?broadcaster_id=197886470&moderator_id=141981764&message_id=4f2b6c1e-8a3d-4b7e-9c5f-2d1a0e3b7c9f&duration_seconds=300' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```
204 No Content
```

## Update Pinned Chat Message {#update-pinned-chat-message}

Updates the duration of an existing pinned chat message.

### Endpoint

`PATCH https://api.twitch.tv/helix/chat/pins`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:chat_messages** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:chat_messages**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.
  - The **channel:bot** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `message_id` — String, **Required**. The ID of the pinned message to update.
- `duration_seconds` — Integer. The new number of seconds the message should remain pinned, starting from now. Minimum: 30. Maximum: 1800. If not specified, the message will be pinned until the stream ends.

### Response Codes

- **204 No Content** — Successfully updated the pinned message.
- **400 Bad Request**
  - A required query parameter is missing or invalid.
  - The *duration_seconds* value is invalid.
  - The specified message must have been pinned by the broadcaster or a moderator.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token or app access token.
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **moderator:manage:chat_messages** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:chat_messages** and **user:bot** scopes.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:bot** scope.
- **403 Forbidden** — The user does not have permission to update pinned messages in this channel.
- **404 Not Found** — The specified pinned message was not found.
- **429 Too Many Requests** — The rate limit for updating pinned messages has been exceeded.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/chat/pins?broadcaster_id=197886470&moderator_id=141981764&message_id=4f2b6c1e-8a3d-4b7e-9c5f-2d1a0e3b7c9f&duration_seconds=600' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```
204 No Content
```

## Unpin Chat Message {#unpin-chat-message}

Unpins a pinned chat message from the specified broadcaster's chat room.

### Endpoint

`DELETE https://api.twitch.tv/helix/chat/pins`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:chat_messages** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:chat_messages**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.
  - The **channel:bot** scope for the user represented by the *broadcaster_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the chat room.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `message_id` — String, **Required**. The ID of the message to unpin.

### Response Codes

- **204 No Content** — Successfully unpinned the message.
- **400 Bad Request** — A required query parameter is missing.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token or app access token.
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **moderator:manage:chat_messages** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:chat_messages** and **user:bot** scopes.
  - If you use an app access token, the user in *broadcaster_id* must have authorized your app with the **channel:bot** scope.
- **403 Forbidden** — The user does not have permission to unpin messages in this channel.
- **404 Not Found** — The specified pinned message was not found.
- **429 Too Many Requests** — The rate limit for unpinning messages has been exceeded.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/chat/pins?broadcaster_id=197886470&moderator_id=141981764&message_id=4f2b6c1e-8a3d-4b7e-9c5f-2d1a0e3b7c9f' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```
204 No Content
```

## Get Chat Settings {#get-chat-settings}

Gets the broadcaster's chat settings.

For an overview of chat settings, see [Chat Commands for Broadcasters and Moderators](https://help.twitch.tv/s/article/chat-commands#AllMods)
and [Moderator Preferences](https://help.twitch.tv/s/article/setting-up-moderation-for-your-twitch-channel#modpreferences).

### Endpoint

`GET https://api.twitch.tv/helix/chat/settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose chat settings you want to get.
- `moderator_id` — String
  The ID of the broadcaster or one of the broadcaster's moderators.

  This field is required only if you want to include the `non_moderator_chat_delay` and
  `non_moderator_chat_delay_duration` settings in the response.

  To get these settings, this ID must match the user ID in the user access token. If it
  doesn't, or if you use an app access token, the request still succeeds but the response
  doesn't include these settings.

### Response Body

- `data` — Object[]. The list of chat settings. The list contains a single object with all the settings.
  - `data.broadcaster_id` — String. The ID of the broadcaster specified in the request.
  - `data.emote_mode` — Boolean. A Boolean value that determines whether chat messages must contain only emotes. Is **true** if chat messages may contain only emotes; otherwise, **false**.
  - `data.follower_mode` — Boolean
    A Boolean value that determines whether the broadcaster restricts the chat room to
    followers only.

    Is **true** if the broadcaster restricts the chat room to followers only; otherwise,
    **false**.

    See the `follower_mode_duration` field for how long users must follow the broadcaster
    before being able to participate in the chat room.
  - `data.follower_mode_duration` — Integer, Nullable. The length of time, in minutes, that users must follow the broadcaster before being able to participate in the chat room. Is **null** if `follower_mode` is **false**.
  - `data.moderator_id` — String. The moderator's ID. The response includes this field only if it also includes the `non_moderator_chat_delay` and `non_moderator_chat_delay_duration` fields.
  - `data.non_moderator_chat_delay` — Boolean
    A Boolean value that determines whether the broadcaster adds a short delay before chat
    messages appear in the chat room. This gives chat moderators and bots a chance to remove
    them before viewers can see the message. See the `non_moderator_chat_delay_duration`
    field for the length of the delay. Is **true** if the broadcaster applies a delay;
    otherwise, **false**.

    The response includes this field only if the request specifies a user access token that
    includes the **moderator:read:chat_settings** or **moderator:manage:chat_settings**
    scope, the ID in the *moderator_id* query parameter matches the user ID in the token,
    and that user is the broadcaster or a moderator with permission to view the chat delay
    settings.
  - `data.non_moderator_chat_delay_duration` — Integer, Nullable
    The amount of time, in seconds, that messages are delayed before appearing in chat. Is
    **null** if `non_moderator_chat_delay` is **false**.

    The response includes this field only if the request specifies a user access token that
    includes the **moderator:read:chat_settings** or **moderator:manage:chat_settings**
    scope, the ID in the *moderator_id* query parameter matches the user ID in the token,
    and that user is the broadcaster or a moderator with permission to view the chat delay
    settings.
  - `data.slow_mode` — Boolean
    A Boolean value that determines whether the broadcaster limits how often users in the
    chat room are allowed to send messages.

    Is **true** if the broadcaster applies a delay; otherwise, **false**.

    See the `slow_mode_wait_time` field for the delay.
  - `data.slow_mode_wait_time` — Integer, Nullable. The amount of time, in seconds, that users must wait between sending messages. Is **null** if slow_mode is **false**.
  - `data.subscriber_mode` — Boolean
    A Boolean value that determines whether only users that subscribe to the broadcaster's
    channel may talk in the chat room.

    Is **true** if the broadcaster restricts the chat room to subscribers only; otherwise,
    **false**.
  - `data.unique_chat_mode` — Boolean
    A Boolean value that determines whether the broadcaster requires users to post only
    unique messages in the chat room.

    Is **true** if the broadcaster requires unique messages only; otherwise, **false**.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's chat settings.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/chat/settings?broadcaster_id=1234&moderator_id=5678' \
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
      "slow_mode": false,
      "slow_mode_wait_time": null,
      "follower_mode": true,
      "follower_mode_duration": 0,
      "subscriber_mode": false,
      "emote_mode": false,
      "unique_chat_mode": false,
      "non_moderator_chat_delay": true,
      "non_moderator_chat_delay_duration": 4
    }
  ]
}
```

## Update Chat Settings {#update-chat-settings}

Updates the broadcaster's chat settings.

### Endpoint

`PATCH https://api.twitch.tv/helix/chat/settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:chat_settings** scope. The User ID associated with the token must match the *moderator_id* in the query parameter.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:chat_settings** scope for the user represented by the *moderator_id* query parameter.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose chat settings you want to update.
- `moderator_id` — String, **Required**. The ID of a user that has permission to moderate the broadcaster's chat room, or the broadcaster's ID if they're making the update. This ID must match the user ID in the user access token.

### Request Body

- `emote_mode` — Boolean. A Boolean value that determines whether chat messages must contain only emotes. Set to **true** if only emotes are allowed; otherwise, **false**. The default is **false**.
- `follower_mode` — Boolean
  A Boolean value that determines whether the broadcaster restricts the chat room to followers
  only.

  Set to **true** if the broadcaster restricts the chat room to followers only; otherwise,
  **false**. The default is **false**.

  To specify how long users must follow the broadcaster before being able to participate in
  the chat room, see the *follower_mode_duration* field.
- `follower_mode_duration` — Integer. The length of time, in minutes, that users must follow the broadcaster before being able to participate in the chat room. Set only if *follower_mode* is **true**. Possible values are: **0** (no restriction) through **129600** (3 months). The default is 0.
- `non_moderator_chat_delay` — Boolean
  A Boolean value that determines whether the broadcaster adds a short delay before chat
  messages appear in the chat room. This gives chat moderators and bots a chance to remove
  them before viewers can see the message.

  Set to **true** if the broadcaster applies a delay; otherwise, **false**. The default is
  **false**.

  To specify the length of the delay, see the *non_moderator_chat_delay_duration* field.
- `non_moderator_chat_delay_duration` — Integer. The amount of time, in seconds, that messages are delayed before appearing in chat. Set only if *non_moderator_chat_delay* is **true**.
  Possible values:
  - `2`: 2 second delay (recommended)
  - `4`: 4 second delay
  - `6`: 6 second delay
- `slow_mode` — Boolean
  A Boolean value that determines whether the broadcaster limits how often users in the chat
  room are allowed to send messages. Set to **true** if the broadcaster applies a wait period
  between messages; otherwise, **false**. The default is **false**.

  To specify the delay, see the *slow_mode_wait_time* field.
- `slow_mode_wait_time` — Integer
  The amount of time, in seconds, that users must wait between sending messages. Set only if
  *slow_mode* is **true**.

  Possible values are **3** (3 second delay) through **120** (2 minute delay). The default is 30 seconds.
- `subscriber_mode` — Boolean
  A Boolean value that determines whether only users that subscribe to the broadcaster's
  channel may talk in the chat room.

  Set to **true** if the broadcaster restricts the chat room to subscribers only; otherwise,
  **false**. The default is **false**.
- `unique_chat_mode` — Boolean
  A Boolean value that determines whether the broadcaster requires users to post only unique
  messages in the chat room.

  Set to **true** if the broadcaster allows only unique messages; otherwise, **false**. The
  default is **false**.

### Response Body

- `data` — Object[]. The list of chat settings. The list contains a single object with all the settings.
  - `data.broadcaster_id` — String. The ID of the broadcaster specified in the request.
  - `data.emote_mode` — Boolean. A Boolean value that determines whether chat messages must contain only emotes. Is **true** if chat messages may contain only emotes; otherwise, **false**.
  - `data.follower_mode` — Boolean
    A Boolean value that determines whether the broadcaster restricts the chat room to
    followers only.

    Is **true** if the broadcaster restricts the chat room to followers only; otherwise,
    **false**.

    See the `follower_mode_duration` field for how long users must follow the broadcaster
    before being able to participate in the chat room.
  - `data.follower_mode_duration` — Integer. The length of time, in minutes, that users must follow the broadcaster before being able to participate in the chat room. Is **null** if `follower_mode` is **false**.
  - `data.moderator_id` — String. The ID of the moderator specified in the request.
  - `data.non_moderator_chat_delay` — Boolean. A Boolean value that determines whether the broadcaster adds a short delay before chat messages appear in the chat room. This gives chat moderators and bots a chance to remove them before viewers can see the message. See the `non_moderator_chat_delay_duration` field for the length of the delay. Is **true** if the broadcaster applies a delay; otherwise, **false**.
  - `data.non_moderator_chat_delay_duration` — Integer. The amount of time, in seconds, that messages are delayed before appearing in chat. Is **null** if `non_moderator_chat_delay` is **false**.
  - `data.slow_mode` — Boolean
    A Boolean value that determines whether the broadcaster limits how often users in the
    chat room are allowed to send messages.

    Is **true** if the broadcaster applies a delay; otherwise, **false**.

    See the `slow_mode_wait_time` field for the delay.
  - `data.slow_mode_wait_time` — Integer. The amount of time, in seconds, that users must wait between sending messages. Is **null** if slow_mode is **false**.
  - `data.subscriber_mode` — Boolean
    A Boolean value that determines whether only users that subscribe to the broadcaster's
    channel may talk in the chat room.

    Is **true** if the broadcaster restricts the chat room to subscribers only; otherwise,
    **false**.
  - `data.unique_chat_mode` — Boolean
    A Boolean value that determines whether the broadcaster requires users to post only
    unique messages in the chat room.

    Is **true** if the broadcaster requires unique messages only; otherwise, **false**.

### Response Codes

- **200 OK** — Successfully updated the broadcaster's chat settings.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *moderator_id* query parameter is required.
  - The ID in the *moderator_id* query parameter is not valid.
  - If *slow_mode* is **true** and the request includes *slow_mode_wait_time*, its value must be in the range 3 through 120.
  - If *follower_mode* is **true** and the request includes *follower_mode_duration*, its value must be in the range 0 through 129600.
  - If *non_moderator_chat_delay* is **true**, the *non_moderator_chat_delay_duration* field must be set to a valid value.
  - If the request includes *slow_mode_wait_time*, it must also include *slow_mode*.
  - If the request includes *follower_mode_duration*, it must also include *follower_mode*.
  - If the request includes *non_moderator_chat_delay_duration*, it must also include *non_moderator_chat_delay*.
- **401 Unauthorized**
  - The ID in the *moderator_id* query parameter must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:chat_settings** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:chat_settings** scope.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **403 Forbidden**
  - The user in the *moderator_id* query parameter must have moderator privileges in the broadcaster's channel.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/chat/settings?broadcaster_id=1234&moderator_id=5678' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"follower_mode":false}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "1234",
      "moderator_id": "5678",
      "slow_mode": true,
      "slow_mode_wait_time": 10,
      "follower_mode": false,
      "follower_mode_duration": null,
      "subscriber_mode": false,
      "emote_mode": false,
      "unique_chat_mode": false,
      "non_moderator_chat_delay": false,
      "non_moderator_chat_delay_duration": null
    }
  ]
}
```

## Send a Shoutout {#send-a-shoutout}

Sends a Shoutout to the specified broadcaster.

Typically, you send Shoutouts when you or one of your moderators notice another broadcaster in
your chat, the other broadcaster is coming up in conversation, or after they raid your broadcast.

Twitch's Shoutout feature is a great way for you to show support for other broadcasters and help
them grow. Viewers who do not follow the other broadcaster will see a pop-up Follow button in your
chat that they can click to follow the other broadcaster. [Learn
More](https://help.twitch.tv/s/article/shoutouts)

**Rate Limits**: The broadcaster may send a Shoutout once every 2 minutes. They may send the same
broadcaster a Shoutout once every 60 minutes.

To receive notifications when a Shoutout is sent or received, subscribe to the
[channel.shoutout.create](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-shoutout-create) and
[channel.shoutout.receive](https://dev.twitch.tv/docs/eventsub/reference/channel.md#channel-shoutout-receive)
subscription types. The **channel.shoutout.create** event includes cooldown periods that indicate
when the broadcaster may send another Shoutout without exceeding the endpoint's rate limit.

### Endpoint

`POST https://api.twitch.tv/helix/chat/shoutouts`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:shoutouts** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **moderator:manage:shoutouts**, **user:bot** scopes for the user represented by the *moderator_id* query parameter.
  - The **channel:bot** scope for the user represented by the *from_broadcaster_id* query parameter.

### Query Parameters

- `from_broadcaster_id` — String, **Required**. The ID of the broadcaster that's sending the Shoutout.
- `to_broadcaster_id` — String, **Required**. The ID of the broadcaster that's receiving the Shoutout.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that is one of the broadcaster's moderators. This ID must match the user ID in the access token.

### Response Codes

- **204 No Content** — Successfully sent the specified broadcaster a Shoutout.
- **400 Bad Request**
  - The *from_broadcaster_id* query parameter is required.
  - The ID in the *from_broadcaster_id* query parameter is not valid.
  - The *to_broadcaster_id* query parameter is required.
  - The ID in the *to_broadcaster_id* query parameter is not valid.
  - The broadcaster may not give themselves a Shoutout.
  - The broadcaster is not streaming live.
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token or an app access token.
  - The user access token must include the **moderator:manage:shoutouts** scope.
  - If you use an app access token, the user in *moderator_id* must have authorized your app with the **moderator:manage:shoutouts** and **user:bot** scopes.
  - If you use an app access token, the user in *from_broadcaster_id* must have authorized your app with the **channel:bot** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user in *moderator_id* is not one of the broadcaster's moderators.
  - The broadcaster may not send the specified broadcaster a Shoutout.
- **429 Too Many Requests**
  - The broadcaster exceeded the number of Shoutouts they may send within a given window. See the endpoint's Rate Limits.
  - The broadcaster exceeded the number of Shoutouts they may send the same broadcaster within a given window. See the endpoint's Rate Limits.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/chat/shoutouts?from_broadcaster_id=12345&to_broadcaster_id=626262&moderator_id=98765' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Shared Chat Session {#get-shared-chat-session}

Retrieves the active shared chat session for a channel.

### Endpoint

`GET https://api.twitch.tv/helix/shared_chat/session`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. The User ID of the channel broadcaster.

### Response Body

- `data` — Object[]
  - `data.session_id` — String. The unique identifier for the shared chat session.
  - `data.host_broadcaster_id` — String. The User ID of the host channel.
  - `data.participants` — Object[]. The list of channels that are active participants in the session. Channels that were invited but haven't joined, or that left the session, aren't included.
    - `data.participants.broadcaster_id` — String. The User ID of the participant channel.
  - `data.created_at` — String. The UTC date and time (in RFC3339 format) for when the session was created. The timestamp may include fractional seconds.
  - `data.updated_at` — String. The UTC date and time (in RFC3339 format) for when the session was last updated. The timestamp may include fractional seconds.

### Response Codes

- **200 OK** — Successfully retrieved the shared chat session. Returns an empty array if the broadcaster_id in the request isn't in an active shared chat session.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
- **401 Unauthorized**
  - The OAuth token is not valid.
  - The Authorization header is required and must contain a user access token.
- **500 Internal Error** — Internal Server Error.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/shared_chat/session?broadcaster_id=198704263' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "session_id": "359bce59-fa4e-41a5-bd6f-9bc0c8360485",
      "host_broadcaster_id": "198704263",
      "participants": [{
          "broadcaster_id": "198704263"
      }, {
          "broadcaster_id": "487263401"
      }],
      "created_at": "2024-09-29T19:45:37Z",
      "updated_at": "2024-09-29T19:45:37Z"
    }
  ]
}
```
