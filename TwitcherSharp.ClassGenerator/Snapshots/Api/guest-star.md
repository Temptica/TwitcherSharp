# Guest Star

Manage and view information related to a broadcaster's Stream Together session.

Source: https://dev.twitch.tv/docs/api/reference/guest-star/

## Contents {#contents}

12 entries on this page:

- [Get Channel Guest Star Settings](#get-channel-guest-star-settings)
- [Update Channel Guest Star Settings](#update-channel-guest-star-settings)
- [Get Guest Star Invites](#get-guest-star-invites)
- [Send Guest Star Invite](#send-guest-star-invite)
- [Delete Guest Star Invite](#delete-guest-star-invite)
- [Get Guest Star Session](#get-guest-star-session)
- [Create Guest Star Session](#create-guest-star-session)
- [End Guest Star Session](#end-guest-star-session)
- [Assign Guest Star Slot](#assign-guest-star-slot)
- [Update Guest Star Slot](#update-guest-star-slot)
- [Delete Guest Star Slot](#delete-guest-star-slot)
- [Update Guest Star Slot Settings](#update-guest-star-slot-settings)

## Get Channel Guest Star Settings {#get-channel-guest-star-settings}

Gets the channel settings for configuration of the Guest Star feature for a particular host.

### Endpoint

`GET https://api.twitch.tv/helix/guest_star/channel_settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star** or **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:guest_star** or **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster you want to get guest star settings for.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Response Body

- `data` — Object[]. A list that contains the channel's Guest Star settings.
  - `data.is_moderator_send_live_enabled` — Boolean. Flag determining if Guest Star moderators have access to control whether a guest is live once assigned to a slot.
  - `data.slot_count` — Integer. Number of slots the Guest Star call interface will allow the host to add to a call. Required to be between 1 and 6.
  - `data.is_browser_source_audio_enabled` — Boolean. Flag determining if Browser Sources subscribed to sessions on this channel should output audio
  - `data.group_layout` — String. This setting determines how the guests within a session should be laid out within the browser source. Layouts other than the ones listed here are reported as "TILED".
    Possible values:
    - `TILED`: All live guests are tiled within the browser source with the same size.
    - `SCREENSHARE`: All live guests are tiled within the browser source with the same size. If there is an
active screen share, it is sized larger than the other guests.
  - `data.browser_source_token` — String, Nullable. View only token to generate browser source URLs. Is **null** if the user in *moderator_id* isn't the broadcaster.

### Response Codes

- **200 OK** — Successfully retrieved the Guest Star settings.
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:read:guest_star** or **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:read:guest_star** or **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden** — Insufficient authorization for viewing channel's Guest Star settings

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/guest_star/channel_settings' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "is_moderator_send_live_enabled": true,
      "slot_count": 4,
      "is_browser_source_audio_enabled": true,
      "group_layout": "TILED",
      "browser_source_token": "eihq8rew7q3hgierufhi3q"
    }
  ]
}
```

## Update Channel Guest Star Settings {#update-channel-guest-star-settings}

Mutates the channel settings for configuration of the Guest Star feature for a particular host.

> **Note** Query parameter _broadcaster\_id_ must match the `user_id` in the [User-Access
> token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens)

### Endpoint

`PATCH https://api.twitch.tv/helix/guest_star/channel_settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster you want to update Guest Star settings for.

### Request Body

- `is_moderator_send_live_enabled` — Boolean. Flag determining if Guest Star moderators have access to control whether a guest is live once assigned to a slot.
- `slot_count` — Integer. Number of slots the Guest Star call interface will allow the host to add to a call. Required to be between 1 and 6.
- `is_browser_source_audio_enabled` — Boolean. Flag determining if Browser Sources subscribed to sessions on this channel should output audio
- `group_layout` — String. This setting determines how the guests within a session should be laid out within the browser source.
  Possible values:
  - `TILED`: All live guests are tiled within the browser source with the same size.
  - `SCREENSHARE`: All live guests are tiled within the browser source with the same size. If there is an
active screen share, it is sized larger than the other guests.
- `regenerate_browser_sources` — Boolean. Flag determining if Guest Star should regenerate the auth token associated with the channel's browser sources. Providing a true value for this will immediately invalidate all browser sources previously configured in your streaming software.

### Response Codes

- **204 No Content** — Successfully updated channel settings
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Invalid *slot_count*
  - Invalid *group_layout*
  - The body includes no setting to update, and *regenerate_browser_sources* isn't **true**
- **401 Unauthorized** — The ID in *broadcaster_id* must match the user ID in the user access token.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/guest_star/channel_settings' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Guest Star Invites {#get-guest-star-invites}

Provides the caller with a list of pending invites to a Guest Star session.

> **Note** Query parameter _moderator\_id_ must match the `user_id` in the [User-Access
> token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens)

### Endpoint

`GET https://api.twitch.tv/helix/guest_star/invites`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star** or **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:guest_star** or **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the `user_id` in the user access token.
- `session_id` — String, **Required**. The session ID to query for invite status.

### Response Body

- `data` — Invite[]. A list of invite objects describing the invited users.
  - `data.user_id` — String. Twitch User ID corresponding to the invited guest
  - `data.invited_at` — String. Timestamp when the invite was created or last updated.
  - `data.status` — String. Status representing the invited user's join state. The list includes only users still in the "INVITED" state.
    Possible values:
    - `INVITED`: The user has been invited to the session but has not acknowledged it.
  - `data.is_video_enabled` — Boolean. Flag signaling that the invited user has chosen to disable their local video device. The user has hidden themselves, but they may choose to reveal their video feed upon joining the session.
  - `data.is_audio_enabled` — Boolean. Flag signaling that the invited user has chosen to disable their local audio device. The user has muted themselves, but they may choose to unmute their audio feed upon joining the session.
  - `data.is_video_available` — Boolean. Flag signaling that the invited user has a video device available for sharing.
  - `data.is_audio_available` — Boolean. Flag signaling that the invited user has an audio device available for sharing.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's Guest Star invites.
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
  - Missing *session_id*
  - Invalid *session_id*
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:read:guest_star** or **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:read:guest_star** or **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden** — The user specified in the *moderator_id* is not permitted to view the broadcaster's invites.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/guest_star/invites' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "144601104",
      "invited_at": "2023-01-02T04:16:53Z",
      "status": "INVITED",
      "is_audio_enabled": false,
      "is_video_enabled": true,
      "is_audio_available": true,
      "is_video_available": true
    }
  ]
}
```

## Send Guest Star Invite {#send-guest-star-invite}

Sends an invite to a specified guest on behalf of the broadcaster for a Guest Star session in progress.

### Endpoint

`POST https://api.twitch.tv/helix/guest_star/invites`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the `user_id` in the user access token.
- `session_id` — String, **Required**. The session ID for the invite to be sent on behalf of the broadcaster.
- `guest_id` — String, **Required**. Twitch User ID for the guest to invite to the Guest Star session.

### Response Codes

- **204 No Content** — Successfully sent the Guest Star invite
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
  - Missing *session_id*
  - Missing *guest_id*
  - Invalid *session_id*
  - Guest already invited, or already assigned a slot in the session
  - Session reached the limit of unaccepted invites
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden**
  - Unauthorized guest invited
  - Guest has a suspension on their account

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/guest_star/invites' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Delete Guest Star Invite {#delete-guest-star-invite}

Revokes a previously sent invite for a Guest Star
session.

### Endpoint

`DELETE https://api.twitch.tv/helix/guest_star/invites`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the `user_id` in the user access token.
- `session_id` — String, **Required**. The ID of the session for the invite to be revoked on behalf of the broadcaster.
- `guest_id` — String, **Required**. Twitch User ID for the guest to revoke the Guest Star session invite from.

### Response Codes

- **204 No Content** — Successfully deleted the Guest Star invite
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
  - Missing *session_id*
  - Missing *guest_id*
  - Invalid *session_id*
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden** — The user specified in *moderator_id* is not permitted to delete invites for the broadcaster.
- **404 Not Found** — No invite exists for specified _guest_id_

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/guest_star/invites' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Guest Star Session {#get-guest-star-session}

Gets information about an ongoing Guest Star session for a particular channel.

> **Note** Guests must be either invited or assigned a slot within the session

### Endpoint

`GET https://api.twitch.tv/helix/guest_star/session`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:guest_star** or **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:read:guest_star** or **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. ID for the user hosting the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.

### Response Body

- `data` — Session[]. Summary of the session details. The list is empty if the broadcaster has no active session, or if the user in *moderator_id* isn't the broadcaster, a guest or invited user in the session, or one of the broadcaster's Guest Star moderators.
  - `data.id` — String. ID uniquely representing the Guest Star session.
  - `data.guests` — Object[]. List of guests currently interacting with the Guest Star session.
    - `data.guests.slot_id` — String
      ID representing this guest's slot assignment. 

      - Host is in slot "0", except when the user in *moderator_id* holds a guest slot in
      the session. Slots are then numbered from that guest's point of view, with the guest
      in slot "0".

      - Guests are assigned the following consecutive IDs (e.g, "1", "2", "3", etc)

      - Screen Share is represented as a special guest with the ID "SCREENSHARE"

      - The identifier here matches the ID referenced in browser source links used in
      broadcasting software.
    - `data.guests.is_live` — Boolean. Flag determining whether or not the guest is visible in the browser source in the host's streaming software.
    - `data.guests.user_id` — String. User ID of the guest assigned to this slot.
    - `data.guests.volume` — Integer. Value from 0 to 100 representing the host's volume setting for this guest.
    - `data.guests.assigned_at` — String. Timestamp when this guest was assigned a slot in the session.
    - `data.guests.audio` — Object. Information about the guest's audio settings
      - `data.guests.audio.is_host_enabled` — Boolean. Flag determining whether the host is allowing the guest's audio to be seen or heard within the session.
      - `data.guests.audio.is_guest_enabled` — Boolean. Flag determining whether the guest is allowing their audio to be transmitted to the session.
      - `data.guests.audio.is_available` — Boolean. Flag determining whether the guest has an appropriate audio device available to be transmitted to the session.
    - `data.guests.video` — Object. Information about the guest's video settings
      - `data.guests.video.is_host_enabled` — Boolean. Flag determining whether the host is allowing the guest's video to be seen or heard within the session.
      - `data.guests.video.is_guest_enabled` — Boolean. Flag determining whether the guest is allowing their video to be transmitted to the session.
      - `data.guests.video.is_available` — Boolean. Flag determining whether the guest has an appropriate video device available to be transmitted to the session.

### Response Codes

- **200 OK** — Successfully retrieved the Guest Star session.
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
- **401 Unauthenticated**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:read:guest_star** or **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:read:guest_star** or **moderator:manage:guest_star** scope if it doesn't.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/guest_star/session' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
    "data": [
        {
            "id": "2KFRQbFtpmfyD3IevNRnCzOPRJI",
            "guests": [
                {
                    "slot_id": "0",
                    "user_id": "9321049",
                    "is_live": true,
                    "volume": 100,
                    "assigned_at": "2023-01-02T04:16:53Z",
                    "audio": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    },
                    "video": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    }
                },
                {
                    "slot_id": "1",
                    "user_id": "144601104",
                    "is_live": true,
                    "volume": 100,
                    "assigned_at": "2023-01-02T04:20:59Z",
                    "audio": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    },
                    "video": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    }
                }
            ]
        }
    ]
}
```

## Create Guest Star Session {#create-guest-star-session}

Requires the broadcaster to be present in the call interface. The session ends automatically when
no one in it is connected to the call interface, for example, if the broadcaster doesn't join
after creating the session. If guests are connected but the broadcaster isn't, the broadcaster is
removed from their slot and the session continues until the last participant leaves.

> **Note** Query parameter _broadcaster\_id_ must match the `user_id` in the [User-Access
> token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens)

### Endpoint

`POST https://api.twitch.tv/helix/guest_star/session`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster you want to create a Guest Star session for. Provided _broadcaster\_id_ must match the `user_id` in the authentication token.

### Response Body

- `data` — Session[]. Summary of the session details.
  - `data.id` — String. ID uniquely representing the Guest Star session.
  - `data.guests` — Object[]. List of guests currently interacting with the Guest Star session. On creation, the session will contain the broadcaster as a solo guest.
    - `data.guests.slot_id` — String
      ID representing this guest's slot assignment. 

      - Host is always in slot "0"

      - Guests are assigned the following consecutive IDs (e.g, "1", "2", "3", etc)

      - Screen Share is represented as a special guest with the ID "SCREENSHARE"

      - The identifier here matches the ID referenced in browser source links used in
      broadcasting software.
    - `data.guests.is_live` — Boolean. Flag determining whether or not the guest is visible in the browser source in the host's streaming software.
    - `data.guests.user_id` — String. User ID of the guest assigned to this slot.
    - `data.guests.volume` — Integer. Value from 0 to 100 representing the host's volume setting for this guest.
    - `data.guests.assigned_at` — String. Timestamp when this guest was assigned a slot in the session.
    - `data.guests.audio` — Object. Information about the guest's audio settings
      - `data.guests.audio.is_host_enabled` — Boolean. Flag determining whether the host is allowing the guest's audio to be seen or heard within the session.
      - `data.guests.audio.is_guest_enabled` — Boolean. Flag determining whether the guest is allowing their audio to be transmitted to the session.
      - `data.guests.audio.is_available` — Boolean. Flag determining whether the guest has an appropriate audio device available to be transmitted to the session.
    - `data.guests.video` — Object. Information about the guest's video settings
      - `data.guests.video.is_host_enabled` — Boolean. Flag determining whether the host is allowing the guest's video to be seen or heard within the session.
      - `data.guests.video.is_guest_enabled` — Boolean. Flag determining whether the guest is allowing their video to be transmitted to the session.
      - `data.guests.video.is_available` — Boolean. Flag determining whether the guest has an appropriate video device available to be transmitted to the session.

### Response Codes

- **200 OK** — Successfully started the Guest Star session.
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Session limit reached (1 active call)
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - Phone verification missing
- **403 Forbidden** — Insufficient authorization for creating session

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/guest_star/session' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
    "data": [
        {
            "id": "2KFRQbFtpmfyD3IevNRnCzOPRJI",
            "guests": [
                {
                    "slot_id": "0",
                    "user_id": "9321049",
                    "is_live": true,
                    "volume": 100,
                    "assigned_at": "2023-01-02T04:16:53Z",
                    "audio": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    },
                    "video": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    }
                }
            ]
        }
    ]
}
```

## End Guest Star Session {#end-guest-star-session}

Performs the same action as if the host clicked the "End Call" button in the Guest Star UI.
Programmatically ends a Guest Star session on behalf of the broadcaster.

> **Note** Query parameter _broadcaster\_id_ must match the `user_id` in the [User-Access
> token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens)

### Endpoint

`DELETE https://api.twitch.tv/helix/guest_star/session`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster you want to end a Guest Star session for. Provided _broadcaster\_id_ must match the `user_id` in the authentication token.
- `session_id` — String, **Required**. ID for the session to end on behalf of the broadcaster.

### Response Body

- `data` — Session[]. Summary of the session details when the session was ended.
  - `data.id` — String. ID uniquely representing the Guest Star session.
  - `data.guests` — Object[]. List of guests currently interacting with the Guest Star session.
    - `data.guests.slot_id` — String
      ID representing this guest's slot assignment. 

      - Host is always in slot "0"

      - Guests are assigned the following consecutive IDs (e.g, "1", "2", "3", etc)

      - Screen Share is represented as a special guest with the ID "SCREENSHARE"

      - The identifier here matches the ID referenced in browser source links used in
      broadcasting software.
    - `data.guests.is_live` — Boolean. Flag determining whether or not the guest is visible in the browser source in the host's streaming software.
    - `data.guests.user_id` — String. User ID of the guest assigned to this slot.
    - `data.guests.volume` — Integer. Value from 0 to 100 representing the host's volume setting for this guest.
    - `data.guests.assigned_at` — String. Timestamp when this guest was assigned a slot in the session.
    - `data.guests.audio` — Object. Information about the guest's audio settings
      - `data.guests.audio.is_host_enabled` — Boolean. Flag determining whether the host is allowing the guest's audio to be seen or heard within the session.
      - `data.guests.audio.is_guest_enabled` — Boolean. Flag determining whether the guest is allowing their audio to be transmitted to the session.
      - `data.guests.audio.is_available` — Boolean. Flag determining whether the guest has an appropriate audio device available to be transmitted to the session.
    - `data.guests.video` — Object. Information about the guest's video settings
      - `data.guests.video.is_host_enabled` — Boolean. Flag determining whether the host is allowing the guest's video to be seen or heard within the session.
      - `data.guests.video.is_guest_enabled` — Boolean. Flag determining whether the guest is allowing their video to be transmitted to the session.
      - `data.guests.video.is_available` — Boolean. Flag determining whether the guest has an appropriate video device available to be transmitted to the session.

### Response Codes

- **200 OK** — Successfully ended the Guest Star session.
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing or invalid *session_id*
  - Session has already been ended
- **401 Unauthorized** — The ID in *broadcaster_id* must match the user ID in the user access token.
- **403 Forbidden** — Insufficient authorization for ending session

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/guest_star/session' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
    "data": [
        {
            "id": "2KFRQbFtpmfyD3IevNRnCzOPRJI",
            "guests": [
                {
                    "slot_id": "0",
                    "user_id": "9321049",
                    "is_live": true,
                    "volume": 100,
                    "assigned_at": "2023-01-02T04:16:53Z",
                    "audio": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    },
                    "video": {
                        "is_available": true,
                        "is_host_enabled": true,
                        "is_guest_enabled": true
                    }
                }
            ]
        }
    ]
}
```

## Assign Guest Star Slot {#assign-guest-star-slot}

Allows a previously invited user to be assigned a slot
within the active Guest Star session, once that guest has indicated they are ready to join.

### Endpoint

`POST https://api.twitch.tv/helix/guest_star/slot`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the `user_id` in the user access token.
- `session_id` — String, **Required**. The ID of the Guest Star session in which to assign the slot.
- `guest_id` — String, **Required**. The Twitch User ID corresponding to the guest to assign a slot in the session. This user must already have an invite to this session, and have indicated that they are ready to join.
- `slot_id` — String, **Required**. The slot assignment to give to the user. Must be a numeric identifier between "1" and "N" where N is the max number of slots for the session. Max number of slots allowed for the session is reported by [Get Channel Guest Star Settings](#get-channel-guest-star-settings). If another guest already holds the slot, that guest is removed from the slot and replaced.

### Response Codes

- **204 No Content** — Successfuly assigned guest to slot
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
  - Missing *guest_id*
  - Missing or invalid *session_id*
  - Missing or invalid *slot_id*
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:manage:guest_star** scope if it doesn't.
  - _moderator_id_ is not a guest star moderator
  - Cannot assign host slot
- **403 Forbidden**
  - Guest not invited to session
  - Guest already assigned to slot
  - Guest is not ready to join

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/guest_star/slot' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Update Guest Star Slot {#update-guest-star-slot}

Allows a user to update the assigned slot for a particular user within the active Guest Star session.

### Endpoint

`PATCH https://api.twitch.tv/helix/guest_star/slot`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the `user_id` in the user access token.
- `session_id` — String, **Required**. The ID of the Guest Star session in which to update slot settings.
- `source_slot_id` — String, **Required**. The slot assignment previously assigned to a user.
- `destination_slot_id` — String, **Required**. The slot to move this user assignment to. If the destination slot is occupied, the user assigned will be swapped into *source_slot_id*.

### Response Codes

- **204 No Content** — Successfuly updated slot(s)
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *session_id*
  - Missing *source_slot_id*
  - Missing *destination_slot_id*
  - *source_slot_id* or *destination_slot_id* is not a guest slot ("1" through "5")
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden** — The user in *moderator_id* isn't in the session, and isn't the broadcaster or one of the broadcaster's Guest Star moderators
- **404 Not Found** — _session_id_ not found, or the session has ended

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/guest_star/slot' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Delete Guest Star Slot {#delete-guest-star-slot}

Allows a caller to remove a slot assignment from a user participating in an active Guest Star session.
This revokes their access to the session immediately and disables their access to publish or subscribe to media within the session.

### Endpoint

`DELETE https://api.twitch.tv/helix/guest_star/slot`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `session_id` — String, **Required**. The ID of the Guest Star session in which to remove the slot assignment.
- `guest_id` — String, **Required**. The Twitch User ID corresponding to the guest to remove from the session.
- `slot_id` — String, **Required**. The slot ID representing the slot assignment to remove from the session.
- `should_reinvite_guest` — Boolean. Flag signaling that the guest should be reinvited to the session, sending them back to the invite queue.

### Response Codes

- **204 No Content** — Successfuly removed user from slot
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
  - Missing or invalid *session_id*
  - Missing *guest_id*
  - Missing or invalid *slot_id*
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden**
  - *moderator_id* is not a Guest Star moderator
  - The request is attempting to modify a restricted slot
- **404 Not Found** — The user in _guest_id_ doesn't have a slot in the session

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/guest_star/slot' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Update Guest Star Slot Settings {#update-guest-star-slot-settings}

Allows a user to update slot settings for a particular
guest within a Guest Star session, such as allowing the user to share audio or video within the
call as a host. These settings will be broadcasted to all subscribers which control their view of
the guest in that slot. One or more of the optional parameters to this API can be specified at any
time.

### Endpoint

`PATCH https://api.twitch.tv/helix/guest_star/slot_settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:guest_star** scope. For requests by the broadcaster (*moderator_id* matches *broadcaster_id*).
- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **moderator:manage:guest_star** scope. For requests by a moderator (*moderator_id* doesn't match *broadcaster_id*).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster running the Guest Star session.
- `moderator_id` — String, **Required**. The ID of the broadcaster or a user that has permission to moderate the broadcaster's chat room. This ID must match the user ID in the user access token.
- `session_id` — String, **Required**. The ID of the Guest Star session in which to update a slot's settings.
- `slot_id` — String, **Required**. The slot assignment that has previously been assigned to a user.
- `is_audio_enabled` — Boolean. Flag indicating whether the slot is allowed to share their audio with the rest of the session. If false, the slot will be muted in any views containing the slot.
- `is_video_enabled` — Boolean. Flag indicating whether the slot is allowed to share their video with the rest of the session. If false, the slot will have no video shared in any views containing the slot.
- `is_live` — Boolean. Flag indicating whether the user assigned to this slot is visible/can be heard from any public subscriptions. Generally, this determines whether or not the slot is enabled in any broadcasting software integrations.

### Response Codes

- **204 No Content** — Successfuly updated slot settings
- **400 Bad Request**
  - Missing *broadcaster_id*
  - Missing *moderator_id*
  - Missing or invalid *session_id* <li>Missing or invalid *slot_id*
  - At least one of *is_audio_enabled*, *is_video_enabled*, or *is_live* is required
- **401 Unauthorized**
  - The ID in *moderator_id* must match the user ID in the user access token.
  - The user access token must include the **channel:manage:guest_star** scope if *moderator_id* matches *broadcaster_id*, or the **moderator:manage:guest_star** scope if it doesn't.
- **403 Forbidden**
  - *moderator_id* is not a Guest Star moderator
  - The request is attempting to modify a restricted slot
  - Moderators can't set *is_live* to **true** when the broadcaster's `is_moderator_send_live_enabled` setting is **false**

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/guest_star/slot_settings' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```
