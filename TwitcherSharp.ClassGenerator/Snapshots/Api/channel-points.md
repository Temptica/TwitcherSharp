# Channel Points

Get, remove, and manage Channel Points rewards and Redemptions.

Source: https://dev.twitch.tv/docs/api/reference/channel-points/

## Contents {#contents}

6 entries on this page:

- [Get Custom Reward](#get-custom-reward)
- [Create Custom Rewards](#create-custom-rewards)
- [Update Custom Reward](#update-custom-reward)
- [Delete Custom Reward](#delete-custom-reward)
- [Get Custom Reward Redemption](#get-custom-reward-redemption)
- [Update Redemption Status](#update-redemption-status)

## Get Custom Reward {#get-custom-reward}

Gets a list of custom rewards that the specified broadcaster created.

> **Note** A channel may offer a maximum of 50 rewards, which includes both enabled and disabled rewards.

### Endpoint

`GET https://api.twitch.tv/helix/channel_points/custom_rewards`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose custom rewards you want to get. This ID must match the user ID found in the OAuth token.
- `id` — String
  A list of IDs to filter the rewards by. To specify more than one ID, include this parameter
  for each reward you want to get. For example, 'id=1234&id=5678'. You may specify a maximum
  of 50 IDs.

  Duplicate IDs are ignored. The response contains only the IDs that were found. If none of
  the IDs were found, the response is 404 Not Found.
- `only_manageable_rewards` — Boolean. A Boolean value that determines whether the response contains only the custom rewards that the app may manage (the app is identified by the ID in the Client-Id header). Set to **true** to get only the custom rewards that the app may manage. The default is **false**.

### Response Body

- `data` — Object[]. A list of custom rewards. The list is in ascending order by `id`. If the broadcaster hasn't created custom rewards, the list is empty.
  - `data.broadcaster_id` — String. The ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.id` — String. The ID that uniquely identifies this custom reward.
  - `data.title` — String. The title of the reward.
  - `data.prompt` — String. The prompt shown to the viewer when they redeem the reward if user input is required (see the `is_user_input_required` field).
  - `data.cost` — Integer. The cost of the reward in Channel Points.
  - `data.image` — Object. A set of custom images for the reward. This field is **null** if the broadcaster didn't upload images.
    - `data.image.url_1x` — String. The URL to a small version of the image.
    - `data.image.url_2x` — String. The URL to a medium version of the image.
    - `data.image.url_4x` — String. The URL to a large version of the image.
  - `data.default_image` — Object. A set of default images for the reward.
    - `data.default_image.url_1x` — String. The URL to a small version of the image.
    - `data.default_image.url_2x` — String. The URL to a medium version of the image.
    - `data.default_image.url_4x` — String. The URL to a large version of the image.
  - `data.background_color` — String. The background color to use for the reward. The color is in Hex format (for example, #00E5CB).
  - `data.is_enabled` — Boolean. A Boolean value that determines whether the reward is enabled. Is **true** if enabled; otherwise, **false**. Disabled rewards aren't shown to the user.
  - `data.is_user_input_required` — Boolean. A Boolean value that determines whether the user must enter information when redeeming the reward. Is **true** if the user is prompted.
  - `data.max_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream.
    - `data.max_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the reward applies a limit on the number of redemptions allowed per live stream. Is **true** if the reward applies a limit.
    - `data.max_per_stream_setting.max_per_stream` — Int64. The maximum number of redemptions allowed per live stream.
  - `data.max_per_user_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream.
    - `data.max_per_user_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the reward applies a limit on the number of redemptions allowed per user per live stream. Is **true** if the reward applies a limit.
    - `data.max_per_user_per_stream_setting.max_per_user_per_stream` — Int64. The maximum number of redemptions allowed per user per live stream.
  - `data.global_cooldown_setting` — Object. The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown.
    - `data.global_cooldown_setting.is_enabled` — Boolean. A Boolean value that determines whether to apply a cooldown period. Is **true** if a cooldown period is enabled.
    - `data.global_cooldown_setting.global_cooldown_seconds` — Int64. The cooldown period, in seconds.
  - `data.is_paused` — Boolean. A Boolean value that determines whether the reward is currently paused. Is **true** if the reward is paused. Viewers can't redeem paused rewards.
  - `data.is_in_stock` — Boolean. A Boolean value that determines whether the reward is currently in stock. Is **true** if the reward is in stock. Viewers can't redeem out of stock rewards.
  - `data.should_redemptions_skip_request_queue` — Boolean. A Boolean value that determines whether redemptions should be set to FULFILLED status immediately when a reward is redeemed. If **false**, status is set to UNFULFILLED and follows the normal request queue process.
  - `data.redemptions_redeemed_current_stream` — Integer. The number of redemptions redeemed during the current live stream. The number counts against the `max_per_stream_setting` limit. This field is **null** if the broadcaster's stream isn't live or `max_per_stream_setting` isn't enabled.
  - `data.cooldown_expires_at` — String. The timestamp of when the cooldown period expires. Is **null** if the reward isn't in a cooldown state. See the `global_cooldown_setting` field.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of custom rewards.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The request exceeds the maximum number of *id* query parameters that you may specify.
- **401 Unauthorized**
  - The Authorization header must specify a user access token.
  - The user access token must include the **channel:read:redemptions** or **channel:manage:redemptions** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The broadcaster is not a partner or affiliate.
- **404 Not Found**
  - All of the custom rewards specified using the *id* query parameter were not found.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channel_points/custom_rewards?broadcaster_id=274637212' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "id": "92af127c-7326-4483-a52b-b0da0be61c01",
      "image": null,
      "background_color": "#00E5CB",
      "is_enabled": true,
      "cost": 50000,
      "title": "game analysis",
      "prompt": "",
      "is_user_input_required": false,
      "max_per_stream_setting": {
        "is_enabled": false,
        "max_per_stream": 0
      },
      "max_per_user_per_stream_setting": {
        "is_enabled": false,
        "max_per_user_per_stream": 0
      },
      "global_cooldown_setting": {
        "is_enabled": false,
        "global_cooldown_seconds": 0
      },
      "is_paused": false,
      "is_in_stock": true,
      "default_image": {
        "url_1x": "https://static-cdn.jtvnw.net/custom-reward-images/default-1.png",
        "url_2x": "https://static-cdn.jtvnw.net/custom-reward-images/default-2.png",
        "url_4x": "https://static-cdn.jtvnw.net/custom-reward-images/default-4.png"
      },
      "should_redemptions_skip_request_queue": false,
      "redemptions_redeemed_current_stream": null,
      "cooldown_expires_at": null
    }
  ]
}
```

## Create Custom Rewards {#create-custom-rewards}

Creates a Custom Reward in the broadcaster's channel.

The maximum number of custom rewards per channel is 50, which includes both enabled and disabled rewards.

### Endpoint

`POST https://api.twitch.tv/helix/channel_points/custom_rewards`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:redemptions** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster to add the custom reward to. This ID must match the user ID found in the OAuth token.

### Request Body

- `title` — String, **Required**. The custom reward's title. The title may contain a maximum of 45 characters and it must be unique (case-insensitive) amongst all of the broadcaster's custom rewards.
- `cost` — Int64, **Required**. The cost of the reward, in Channel Points. The minimum is 1 point and the maximum is 1,000,000,000 points.
- `prompt` — String. The prompt shown to the viewer when they redeem the reward. Specify a prompt if *is_user_input_required* is **true**.
- `is_enabled` — Boolean. A Boolean value that determines whether the reward is enabled. Viewers see only enabled rewards. The default is **true**.
- `background_color` — String. The background color to use for the reward. Specify the color using Hex format (for example, #9147FF). If you omit it or set it to an empty string, the reward gets a randomly chosen color.
- `is_user_input_required` — Boolean. A Boolean value that determines whether the user needs to enter information when redeeming the reward. See the *prompt* field. The default is **false**.
- `is_max_per_stream_enabled` — Boolean. A Boolean value that determines whether to limit the maximum number of redemptions allowed per live stream (see the *max_per_stream* field). The default is **false**.
- `max_per_stream` — Integer. The maximum number of redemptions allowed per live stream. Applied only if *is_max_per_stream_enabled* is **true**. The minimum value is 1.
- `is_max_per_user_per_stream_enabled` — Boolean. A Boolean value that determines whether to limit the maximum number of redemptions allowed per user per stream (see the *max_per_user_per_stream* field). The default is **false**.
- `max_per_user_per_stream` — Integer. The maximum number of redemptions allowed per user per stream. Applied only if *is_max_per_user_per_stream_enabled* is **true**. The minimum value is 1.
- `is_global_cooldown_enabled` — Boolean. A Boolean value that determines whether to apply a cooldown period between redemptions (see the *global_cooldown_seconds* field for the duration of the cooldown period). The default is **false**.
- `global_cooldown_seconds` — Integer. The cooldown period, in seconds. Applied only if the *is_global_cooldown_enabled* field is **true**. The minimum value is 1; however, the minimum value is 60 for it to be shown in the Twitch UX.
- `should_redemptions_skip_request_queue` — Boolean. A Boolean value that determines whether redemptions should be set to FULFILLED status immediately when a reward is redeemed. If **false**, status is set to UNFULFILLED and follows the normal request queue process. The default is **false**.

### Response Body

- `data` — Object[]. A list that contains the single custom reward you created.
  - `data.broadcaster_id` — String. The ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.id` — String. The ID that uniquely identifies this custom reward.
  - `data.title` — String. The title of the reward.
  - `data.prompt` — String. The prompt shown to the viewer when they redeem the reward if user input is required (see the `is_user_input_required` field).
  - `data.cost` — Integer. The cost of the reward in Channel Points.
  - `data.image` — Object. A set of custom images for the reward. This field is set to **null** if the broadcaster didn't upload images.
    - `data.image.url_1x` — String. The URL to a small version of the image.
    - `data.image.url_2x` — String. The URL to a medium version of the image.
    - `data.image.url_4x` — String. The URL to a large version of the image.
  - `data.default_image` — Object. A set of default images for the reward.
    - `data.default_image.url_1x` — String. The URL to a small version of the image.
    - `data.default_image.url_2x` — String. The URL to a medium version of the image.
    - `data.default_image.url_4x` — String. The URL to a large version of the image.
  - `data.background_color` — String. The background color to use for the reward. The color is in Hex format (for example, #00E5CB).
  - `data.is_enabled` — Boolean. A Boolean value that determines whether the reward is enabled. Is **true** if enabled; otherwise, **false**. Disabled rewards aren't shown to the user.
  - `data.is_user_input_required` — Boolean. A Boolean value that determines whether the user must enter information when redeeming the reward. Is **true** if the reward requires user input.
  - `data.max_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number to the redemptions allowed per live stream.
    - `data.max_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the reward applies a limit on the number of redemptions allowed per live stream. Is **true** if the reward applies a limit.
    - `data.max_per_stream_setting.max_per_stream` — Int64. The maximum number of redemptions allowed per live stream.
  - `data.max_per_user_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream.
    - `data.max_per_user_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the reward applies a limit on the number of redemptions allowed per user per live stream. Is **true** if the reward applies a limit.
    - `data.max_per_user_per_stream_setting.max_per_user_per_stream` — Int64. The maximum number of redemptions allowed per user per live stream.
  - `data.global_cooldown_setting` — Object. The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown.
    - `data.global_cooldown_setting.is_enabled` — Boolean. A Boolean value that determines whether to apply a cooldown period. Is **true** if a cooldown period is enabled.
    - `data.global_cooldown_setting.global_cooldown_seconds` — Int64. The cooldown period, in seconds.
  - `data.is_paused` — Boolean. A Boolean value that determines whether the reward is currently paused. Is **true** if the reward is paused. Viewers can't redeem paused rewards.
  - `data.is_in_stock` — Boolean. A Boolean value that determines whether the reward is currently in stock. Is **true** if the reward is in stock. Viewers can't redeem out of stock rewards.
  - `data.should_redemptions_skip_request_queue` — Boolean. A Boolean value that determines whether redemptions should be set to FULFILLED status immediately when a reward is redeemed. If **false**, status is UNFULFILLED and follows the normal request queue process.
  - `data.redemptions_redeemed_current_stream` — Integer. The number of redemptions redeemed during the current live stream. The number counts against the `max_per_stream_setting` limit. This field is **null** if the broadcaster's stream isn't live or `max_per_stream_setting` isn't enabled.
  - `data.cooldown_expires_at` — String. The timestamp of when the cooldown period expires. Is **null** if the reward isn't in a cooldown state (see the `global_cooldown_setting` field).

### Response Codes

- **200 OK** — Successfully created the custom reward.
- **400 Bad Request**
  - The request exceeds the maximum number of rewards allowed per channel.
  - The *broadcaster_id* query parameter is required.
  - The *title* field is required.
  - The *title* must contain a minimum of 1 character and a maximum of 45 characters.
  - The *title* must be unique (case-insensitive) amongst all of the broadcaster's custom rewards.
  - The *cost* field is required.
  - The *cost* field must contain a minimum of 1 point and a maximum of 1,000,000,000 points.
  - The *background_color* must be in Hex format (for example, #9147FF).
  - AutoMod rejected the content in the *title* or *prompt* field.
  - If *is_max_per_stream_enabled* is **true**, the minimum value for *max_per_stream* is 1.
  - If *is_max_per_user_per_stream_enabled* is **true**, the minimum value for *max_per_user_per_stream* is 1.
  - If *is_global_cooldown_enabled* is **true**, the minimum value for *global_cooldown_seconds* is 1.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token.
  - The user access token is missing the **channel:manage:redemptions** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The broadcaster is not a partner or affiliate.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/channel_points/custom_rewards?broadcaster_id=274637212' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"title":"game analysis 1v1","cost":50000}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "id": "afaa7e34-6b17-49f0-a19a-d1e76eaaf673",
      "image": null,
      "background_color": "#00E5CB",
      "is_enabled": true,
      "cost": 50000,
      "title": "game analysis 1v1",
      "prompt": "",
      "is_user_input_required": false,
      "max_per_stream_setting": {
        "is_enabled": false,
        "max_per_stream": 0
      },
      "max_per_user_per_stream_setting": {
        "is_enabled": false,
        "max_per_user_per_stream": 0
      },
      "global_cooldown_setting": {
        "is_enabled": false,
        "global_cooldown_seconds": 0
      },
      "is_paused": false,
      "is_in_stock": true,
      "default_image": {
        "url_1x": "https://static-cdn.jtvnw.net/custom-reward-images/default-1.png",
        "url_2x": "https://static-cdn.jtvnw.net/custom-reward-images/default-2.png",
        "url_4x": "https://static-cdn.jtvnw.net/custom-reward-images/default-4.png"
      },
      "should_redemptions_skip_request_queue": false,
      "redemptions_redeemed_current_stream": null,
      "cooldown_expires_at": null
    }
  ]
}
```

## Update Custom Reward {#update-custom-reward}

Updates a custom reward. The app used to create the reward is the only app that may update the reward.

> **Note** Each limit setting is updated as a pair: *is_max_per_stream_enabled* with *max_per_stream*,
> *is_max_per_user_per_stream_enabled* with *max_per_user_per_stream*, and
> *is_global_cooldown_enabled* with *global_cooldown_seconds*. If you specify one field of a
> pair, also specify the other; the field you omit is set to **false** or 0. For example,
> specifying only *max_per_stream* turns off the per-stream limit.

### Endpoint

`PATCH https://api.twitch.tv/helix/channel_points/custom_rewards`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:redemptions** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's updating the reward. This ID must match the user ID found in the OAuth token.
- `id` — String, **Required**. The ID of the reward to update.

### Request Body

- `title` — String. The reward's title. The title may contain a maximum of 45 characters and it must be unique (case-insensitive) amongst all of the broadcaster's custom rewards.
- `prompt` — String. The prompt shown to the viewer when they redeem the reward. Specify a prompt if *is_user_input_required* is **true**. If the prompt is empty or contains only whitespace, the reward's current prompt isn't changed.
- `cost` — Int64. The cost of the reward, in channel points. The minimum is 1 point and the maximum is 1,000,000,000 points.
- `background_color` — String. The background color to use for the reward. Specify the color using Hex format (for example, \\#00E5CB).
- `is_enabled` — Boolean. A Boolean value that indicates whether the reward is enabled. Set to **true** to enable the reward. Viewers see only enabled rewards.
- `is_user_input_required` — Boolean. A Boolean value that determines whether users must enter information to redeem the reward. Set to **true** if user input is required. See the *prompt* field.
- `is_max_per_stream_enabled` — Boolean. A Boolean value that determines whether to limit the maximum number of redemptions allowed per live stream (see the *max_per_stream* field). Set to **true** to limit redemptions.
- `max_per_stream` — Int64. The maximum number of redemptions allowed per live stream. Applied only if *is_max_per_stream_enabled* is **true**. The minimum value is 1.
- `is_max_per_user_per_stream_enabled` — Boolean. A Boolean value that determines whether to limit the maximum number of redemptions allowed per user per stream (see *max_per_user_per_stream*). Set to **true** to limit redemptions.
- `max_per_user_per_stream` — Int64. The maximum number of redemptions allowed per user per stream. Applied only if *is_max_per_user_per_stream_enabled* is **true**. The minimum value is 1.
- `is_global_cooldown_enabled` — Boolean. A Boolean value that determines whether to apply a cooldown period between redemptions. Set to **true** to apply a cooldown period. For the duration of the cooldown period, see *global_cooldown_seconds*.
- `global_cooldown_seconds` — Int64. The cooldown period, in seconds. Applied only if *is_global_cooldown_enabled* is **true**. The minimum value is 1; however, for it to be shown in the Twitch UX, the minimum value is 60.
- `is_paused` — Boolean. A Boolean value that determines whether to pause the reward. Set to **true** to pause the reward. Viewers can't redeem paused rewards..
- `should_redemptions_skip_request_queue` — Boolean. A Boolean value that determines whether redemptions should be set to FULFILLED status immediately when a reward is redeemed. If **false**, status is set to UNFULFILLED and follows the normal request queue process.

### Response Body

- `data` — Object[]. The list contains the single reward that you updated.
  - `data.broadcaster_id` — String. The ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.id` — String. The ID that uniquely identifies this custom reward.
  - `data.title` — String. The title of the reward.
  - `data.prompt` — String. The prompt shown to the viewer when they redeem the reward if user input is required. See the `is_user_input_required` field.
  - `data.cost` — Int64. The cost of the reward in Channel Points.
  - `data.image` — Object. A set of custom images for the reward. This field is **null** if the broadcaster didn't upload images.
    - `data.image.url_1x` — String. The URL to a small version of the image.
    - `data.image.url_2x` — String. The URL to a medium version of the image.
    - `data.image.url_4x` — String. The URL to a large version of the image.
  - `data.default_image` — Object. A set of default images for the reward.
    - `data.default_image.url_1x` — String. The URL to a small version of the image.
    - `data.default_image.url_2x` — String. The URL to a medium version of the image.
    - `data.default_image.url_4x` — String. The URL to a large version of the image.
  - `data.background_color` — String. The background color to use for the reward. The color is in Hex format (for example, #00E5CB).
  - `data.is_enabled` — Boolean. A Boolean value that determines whether the reward is enabled. Is **true** if enabled; otherwise, **false**. Disabled rewards aren't shown to the user.
  - `data.is_user_input_required` — Boolean. A Boolean value that determines whether the user must enter information when they redeem the reward. Is **true** if the user is prompted.
  - `data.max_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream.
    - `data.max_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the reward applies a limit on the number of redemptions allowed per live stream. Is **true** if the reward applies a limit.
    - `data.max_per_stream_setting.max_per_stream` — Int64. The maximum number of redemptions allowed per live stream.
  - `data.max_per_user_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream.
    - `data.max_per_user_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the reward applies a limit on the number of redemptions allowed per user per live stream. Is **true** if the reward applies a limit.
    - `data.max_per_user_per_stream_setting.max_per_user_per_stream` — Int64. The maximum number of redemptions allowed per user per live stream.
  - `data.global_cooldown_setting` — Object. The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown.
    - `data.global_cooldown_setting.is_enabled` — Boolean. A Boolean value that determines whether to apply a cooldown period. Is **true** if a cooldown period is enabled.
    - `data.global_cooldown_setting.global_cooldown_seconds` — Int64. The cooldown period, in seconds.
  - `data.is_paused` — Boolean. A Boolean value that determines whether the reward is currently paused. Is **true** if the reward is paused. Viewers can't redeem paused rewards.
  - `data.is_in_stock` — Boolean. A Boolean value that determines whether the reward is currently in stock. Is **true** if the reward is in stock. Viewers can't redeem out of stock rewards.
  - `data.should_redemptions_skip_request_queue` — Boolean. A Boolean value that determines whether redemptions should be set to FULFILLED status immediately when a reward is redeemed. If **false**, status is set to UNFULFILLED and follows the normal request queue process.
  - `data.redemptions_redeemed_current_stream` — Integer. The number of redemptions redeemed during the current live stream. The number counts against the `max_per_stream_setting` limit. This field is **null** if the broadcaster's stream isn't live or `max_per_stream_setting` isn't enabled.
  - `data.cooldown_expires_at` — String. The timestamp of when the cooldown period expires. Is **null** if the reward isn't in a cooldown state. See the `global_cooldown_setting` field.

### Response Codes

- **200 OK** — Successfully updated the custom reward.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *id* query parameter is required.
  - The *title* must contain a minimum of 1 character and a maximum of 45 characters.
  - The *title* must be unique (case-insensitive) amongst all of the broadcaster's custom rewards.
  - The *cost* field must contain a minimum of 1 point and a maximum of 1,000,000,000 points.
  - The *background_color* must be in Hex format (for example, #00E5CB).
  - AutoMod rejected the content in the *title* or *prompt* field.
  - If *is_max_per_stream_enabled* is **true**, the minimum value for *max_per_stream* is 1.
  - If *is_max_per_user_per_stream_enabled* is **true**, the minimum value for *max_per_user_per_stream* is 1.
  - If *is_global_cooldown_enabled* is **true**, the minimum value for *global_cooldown_seconds* is 1.
  - The *max_per_stream* field is required if *is_max_per_stream_enabled* is **true**.
  - The *max_per_user_per_stream* field is required if *is_max_per_user_per_stream_enabled* is **true**.
  - The *global_cooldown_seconds* field is required if *is_global_cooldown_enabled* is **true**.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token.
  - The user access token must include the **channel:manage:redemptions** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The OAuth token is not valide.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The ID in the Client-Id header must match the client ID used to create the custom reward.
  - The broadcaster is not a partner or affiliate.
- **404 Not Found**
  - The custom reward specified in the *id* query parameter was not found.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/channel_points/custom_rewards?broadcaster_id=274637212&id=92af127c-7326-4483-a52b-b0da0be61c01' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"is_enabled":false}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "id": "92af127c-7326-4483-a52b-b0da0be61c01",
      "image": null,
      "background_color": "#00E5CB",
      "is_enabled": false,
      "cost": 30000,
      "title": "game analysis 2v2",
      "prompt": "",
      "is_user_input_required": false,
      "max_per_stream_setting": {
        "is_enabled": true,
        "max_per_stream": 60
      },
      "max_per_user_per_stream_setting": {
        "is_enabled": false,
        "max_per_user_per_stream": 0
      },
      "global_cooldown_setting": {
        "is_enabled": false,
        "global_cooldown_seconds": 0
      },
      "is_paused": false,
      "is_in_stock": false,
      "default_image": {
        "url_1x": "https://static-cdn.jtvnw.net/custom-reward-images/default-1.png",
        "url_2x": "https://static-cdn.jtvnw.net/custom-reward-images/default-2.png",
        "url_4x": "https://static-cdn.jtvnw.net/custom-reward-images/default-4.png"
      },
      "should_redemptions_skip_request_queue": true,
      "redemptions_redeemed_current_stream": 60,
      "cooldown_expires_at": null
    }
  ]
}
```

## Delete Custom Reward {#delete-custom-reward}

Deletes a custom reward that the broadcaster created.

The app used to create the reward is the only app that may delete it. Deleting the reward starts
an asynchronous update that marks the reward's UNFULFILLED redemptions as FULFILLED. The update
doesn't start if a bulk update of the channel's redemptions, or of this reward's redemptions, is
already in progress, but the reward is still deleted.

### Endpoint

`DELETE https://api.twitch.tv/helix/channel_points/custom_rewards`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:redemptions** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that created the custom reward. This ID must match the user ID found in the OAuth token.
- `id` — String, **Required**. The ID of the custom reward to delete.

### Response Codes

- **204 No Content** — Successfully deleted the custom reward.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *id* query parameter is required.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token.
  - The user access token must include the **channel:manage:redemptions** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The ID in the Client-Id header must match the client ID used to create the custom reward.
  - The broadcaster is not a partner or affiliate.
- **404 Not Found**
  - The custom reward specified in the *id* query parameter was not found.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/channel_points/custom_rewards?broadcaster_id=274637212&id=b045196d-9ce7-4a27-a9b9-279ed341ab28' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Get Custom Reward Redemption {#get-custom-reward-redemption}

Gets a list of redemptions for the specified custom reward. The app used to create the reward is
the only app that may get the redemptions.

### Endpoint

`GET https://api.twitch.tv/helix/channel_points/custom_rewards/redemptions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:redemptions** or **channel:manage:redemptions** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the custom reward. This ID must match the user ID found in the user OAuth token.
- `reward_id` — String, **Required**. The ID that identifies the custom reward whose redemptions you want to get.
- `status` — String. The status of the redemptions to return. The possible values are case-sensitive. This parameter is required if you don't specify the *id* query parameter; if you specify *id*, it's ignored.
  Possible values:
  - `CANCELED`
  - `FULFILLED`
  - `UNFULFILLED`
- `id` — String
  A list of IDs to filter the redemptions by. To specify more than one ID, include this
  parameter for each redemption you want to get. For example, 'id=1234&id=5678'. You may
  specify a maximum of 50 IDs.

  Duplicate IDs are ignored. The response contains only the IDs that were found. If none of
  the IDs were found, the response is 404 Not Found.

  If you specify *id*, the *status*, *sort*, *first*, and *after* query parameters don't
  apply: the response contains the redemptions regardless of their status, and it doesn't
  include the `pagination` object.
- `sort` — String. The order to sort redemptions by. The possible values are case-sensitive. The default is OLDEST.
  Possible values:
  - `OLDEST`
  - `NEWEST`
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read more](https://dev.twitch.tv/docs/api/guide.md#pagination)
- `first` — Integer. The maximum number of redemptions to return per page in the response. The minimum page size is 1 redemption per page and the maximum is 50. The default is 20.

### Response Body

- `data` — Object[]. The list of redemptions for the specified reward. The list is empty if there are no redemptions that match the redemption criteria.
  - `data.broadcaster_id` — String. The ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.id` — String. The ID that uniquely identifies this redemption.
  - `data.user_login` — String. The user's login name.
  - `data.user_id` — String. The ID that uniquely identifies the user that redeemed the reward.
  - `data.user_name` — String. The user's display name.
  - `data.user_input` — String. The text the user entered at the prompt when they redeemed the reward; otherwise, an empty string if user input was not required.
  - `data.status` — String. The state of the redemption.
    Possible values:
    - `CANCELED`
    - `FULFILLED`
    - `UNFULFILLED`
  - `data.redeemed_at` — String. The date and time of when the reward was redeemed, in RFC3339 format.
  - `data.reward` — Object. The reward that the user redeemed.
    - `data.reward.id` — String. The ID that uniquely identifies the redeemed reward.
    - `data.reward.title` — String. The reward's title.
    - `data.reward.prompt` — String. The prompt displayed to the viewer if user input is required.
    - `data.reward.cost` — Int64. The reward's cost, in Channel Points.
- `pagination` — Object. Contains the information used to page through the list of results. The object contains a cursor whenever the page contains redemptions, even if it's the last page; it's empty if the page contains no redemptions. The response doesn't include this object if you specify the *id* query parameter. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 Ok** — Successfully retrieved the list of redeemed custom rewards.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *reward_id* query parameter is required.
  - The *status* query parameter is required if you didn't specify the *id* query parameter.
  - The value in the *status* query parameter is not valid.
  - The value in the *sort* query parameter is not valid.
  - The value in the *first* query parameter is greater than 50.
  - The request exceeds the maximum number of *id* query parameters that you may specify.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token.
  - The user access token must include the **channel:read:redemptions** or **channel:manage:redemptions** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The ID in the Client-Id header must match the client ID used to create the custom reward.
  - The broadcaster is not a partner or affiliate.
- **404 Not Found**
  - The custom reward specified in the *reward_id* query parameter was not found.
  - All of the redemptions specified using the *id* query parameter were not found.
- **500 Internal Server Error**

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/channel_points/custom_rewards/redemptions?broadcaster_id=274637212&reward_id=92af127c-7326-4483-a52b-b0da0be61c01&status=CANCELED' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "id": "17fa2df1-ad76-4804-bfa5-a40ef63efe63",
      "user_login": "torpedo09",
      "user_id": "274637212",
      "user_name": "torpedo09",
      "user_input": "",
      "status": "CANCELED",
      "redeemed_at": "2020-07-01T18:37:32Z",
      "reward": {
        "id": "92af127c-7326-4483-a52b-b0da0be61c01",
        "title": "game analysis",
        "prompt": "",
        "cost": 50000
      }
    }
  ],
  "pagination": {
    "cursor": "eyJiIjpudWxsLCJhIjp7IkN1cnNvciI6Ik1UZG1ZVEprWmpFdFlXUTNOaTAwT0RBMExXSm1ZVFV0WVRRd1pXWTJNMlZtWlRZelgxOHlNREl3TFRBM0xUQXhWREU0T2pNM09qTXlMakl6TXpFeU56RTFOMW89In19"
  }
}
```

## Update Redemption Status {#update-redemption-status}

Updates a redemption's status.

You may update a redemption only if its status is UNFULFILLED. The app used to create the reward is the only app that may update the redemption.

### Endpoint

`PATCH https://api.twitch.tv/helix/channel_points/custom_rewards/redemptions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:redemptions** scope.

### Query Parameters

- `id` — String, **Required**. A list of IDs that identify the redemptions to update. To specify more than one ID, include this parameter for each redemption you want to update. For example, 'id=1234&id=5678'. You may specify a maximum of 50 IDs.
- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's updating the redemption. This ID must match the user ID in the user access token.
- `reward_id` — String, **Required**. The ID that identifies the reward that's been redeemed.

### Request Body

- `status` — String, **Required**. The status to set the redemption to.
  Possible values:
  - `CANCELED`
  - `FULFILLED`

### Response Body

- `data` — Object[]. The list of redemptions that you updated. The list doesn't include redemptions that weren't found, weren't UNFULFILLED, or belong to a different reward.
  - `data.broadcaster_id` — String. The ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.id` — String. The ID that uniquely identifies this redemption..
  - `data.user_id` — String. The ID of the user that redeemed the reward.
  - `data.user_name` — String. The user's display name.
  - `data.user_login` — String. The user's login name.
  - `data.reward` — Object. An object that describes the reward that the user redeemed.
    - `data.reward.id` — String. The ID that uniquely identifies the reward.
    - `data.reward.title` — String. The reward's title.
    - `data.reward.prompt` — String. The prompt displayed to the viewer if user input is required.
    - `data.reward.cost` — Int64. The reward's cost, in Channel Points.
  - `data.user_input` — String. The text that the user entered at the prompt when they redeemed the reward; otherwise, an empty string if user input was not required.
  - `data.status` — String. The state of the redemption.
    Possible values:
    - `CANCELED`
    - `FULFILLED`
    - `UNFULFILLED`
  - `data.redeemed_at` — String. The date and time of when the reward was redeemed, in RFC3339 format.

### Response Codes

- **200 OK** — Successfully updated the redemption's status.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *reward_id* query parameter is required.
  - The *id* query parameter is required and must contain at least one non-empty value.
  - The *status* field is required and must be CANCELED or FULFILLED.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token.
  - The user access token must include the **channel:manage:redemptions** scope.
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The ID in the Client-Id header must match the client ID used to create the custom reward.
  - The broadcaster is not a partner or affiliate.
- **404 Not Found**
  - The custom reward specified in the *reward_id* query parameter was not found.
  - None of the redemptions specified using the *id* query parameter were found among the reward's UNFULFILLED redemptions.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/channel_points/custom_rewards/redemptions?broadcaster_id=274637212&reward_id=92af127c-7326-4483-a52b-b0da0be61c01&id=17fa2df1-ad76-4804-bfa5-a40ef63efe63' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"status":"CANCELED"}'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_name": "torpedo09",
      "broadcaster_login": "torpedo09",
      "broadcaster_id": "274637212",
      "id": "17fa2df1-ad76-4804-bfa5-a40ef63efe63",
      "user_id": "274637212",
      "user_name": "torpedo09",
      "user_login": "torpedo09",
      "user_input": "",
      "status": "CANCELED",
      "redeemed_at": "2020-07-01T18:37:32Z",
      "reward": {
        "id": "92af127c-7326-4483-a52b-b0da0be61c01",
        "title": "game analysis",
        "prompt": "",
        "cost": 50000
      }
    }
  ]
}
```
