# Bits

Get access to information involving Bits products and transactions.

Source: https://dev.twitch.tv/docs/api/reference/bits/

## Contents {#contents}

4 entries on this page:

- [Get Cheermotes](#get-cheermotes)
- [Get Custom Power-up](#get-custom-power-up)
- [Get Bits Leaderboard](#get-bits-leaderboard)
- [Get Extension Transactions](#get-extension-transactions)

## Get Cheermotes {#get-cheermotes}

Gets a list of Cheermotes that users can use to cheer Bits in any Bits-enabled channel's chat
room. Cheermotes are animated emotes that viewers can assign Bits to.

### Endpoint

`GET https://api.twitch.tv/helix/bits/cheermotes`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String
  The ID of the broadcaster whose custom Cheermotes you want to get. Specify the broadcaster's
  ID if you want to include the broadcaster's Cheermotes in the response (not all broadcasters
  upload Cheermotes). If not specified, the response contains only global Cheermotes.

  If the broadcaster uploaded Cheermotes, the `type` field in the response is set to
  **channel_custom**.

### Response Body

- `data` — Object[]. The list of Cheermotes. The list is in ascending order by the `order` field's value.
  - `data.prefix` — String. The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is "Cheer" and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
  - `data.tiers` — Object[]. A list of tier levels that the Cheermote supports. Each tier identifies the range of Bits that you can cheer at that tier level and an image that graphically identifies the tier level.
    - `data.tiers.min_bits` — Integer
      The minimum number of Bits that you must cheer at this tier level. The maximum
      number of Bits that you can cheer at this level is determined by the required
      minimum Bits of the next tier level minus 1. For example, if `min_bits` is 1 and
      `min_bits` for the next tier is 100, the Bits range for this tier level is 1 through
      99. The minimum Bits value of the last tier is the maximum number of Bits you can
      cheer using this Cheermote. For example, 10000.
    - `data.tiers.id` — String
      The tier level. Possible tiers are:

      - 1
      - 100
      - 500
      - 1000
      - 5000
      - 10000
      - 100000
    - `data.tiers.color` — String. The hex code of the color associated with this tier level (for example, #979797).
    - `data.tiers.images` — Object. The animated and static image sets for the Cheermote, keyed by theme, then format, then size.
      - `data.tiers.images.dark` — Object. The image sets to use on a dark background.
        - `data.tiers.images.dark.animated` — Object. The animated GIF image set, keyed by size.
          - `data.tiers.images.dark.animated.1` — String. The URL of the 1x image.
          - `data.tiers.images.dark.animated.1.5` — String. The URL of the 1.5x image.
          - `data.tiers.images.dark.animated.2` — String. The URL of the 2x image.
          - `data.tiers.images.dark.animated.3` — String. The URL of the 3x image.
          - `data.tiers.images.dark.animated.4` — String. The URL of the 4x image.
        - `data.tiers.images.dark.static` — Object. The static PNG image set, keyed by size.
          - `data.tiers.images.dark.static.1` — String. The URL of the 1x image.
          - `data.tiers.images.dark.static.1.5` — String. The URL of the 1.5x image.
          - `data.tiers.images.dark.static.2` — String. The URL of the 2x image.
          - `data.tiers.images.dark.static.3` — String. The URL of the 3x image.
          - `data.tiers.images.dark.static.4` — String. The URL of the 4x image.
      - `data.tiers.images.light` — Object. The image sets to use on a light background.
        - `data.tiers.images.light.animated` — Object. The animated GIF image set, keyed by size.
          - `data.tiers.images.light.animated.1` — String. The URL of the 1x image.
          - `data.tiers.images.light.animated.1.5` — String. The URL of the 1.5x image.
          - `data.tiers.images.light.animated.2` — String. The URL of the 2x image.
          - `data.tiers.images.light.animated.3` — String. The URL of the 3x image.
          - `data.tiers.images.light.animated.4` — String. The URL of the 4x image.
        - `data.tiers.images.light.static` — Object. The static PNG image set, keyed by size.
          - `data.tiers.images.light.static.1` — String. The URL of the 1x image.
          - `data.tiers.images.light.static.1.5` — String. The URL of the 1.5x image.
          - `data.tiers.images.light.static.2` — String. The URL of the 2x image.
          - `data.tiers.images.light.static.3` — String. The URL of the 3x image.
          - `data.tiers.images.light.static.4` — String. The URL of the 4x image.
    - `data.tiers.can_cheer` — Boolean. A Boolean value that determines whether users can cheer at this tier level.
    - `data.tiers.show_in_bits_card` — Boolean. A Boolean value that determines whether this tier level is shown in the Bits card. Is **true** if this tier level is shown in the Bits card.
  - `data.type` — String. The type of Cheermote.
    Possible values:
    - `global_first_party`: A Twitch-defined Cheermote that is shown in the Bits card.
    - `global_third_party`: A Twitch-defined Cheermote that is not shown in the Bits card.
    - `channel_custom`: A broadcaster-defined Cheermote.
    - `display_only`: Do not use; for internal use only.
    - `sponsored`: A sponsor-defined Cheermote. When used, the sponsor adds additional Bits to the
amount that the user cheered. For example, if the user cheered Terminator100, the
broadcaster might receive 110 Bits, which includes the sponsor's 10 Bits
contribution.
  - `data.order` — Integer. The order that the Cheermotes are shown in the Bits card. The numbers may not be consecutive. For example, the numbers may jump from 1 to 7 to 13. The order numbers are unique within a Cheermote type (for example, global_first_party) but may not be unique amongst all Cheermotes in the response.
  - `data.last_updated` — String. The date and time, in RFC3339 format, when this Cheermote was last updated.
  - `data.is_charitable` — Boolean. A Boolean value that indicates whether this Cheermote provides a charitable contribution match during charity campaigns.

### Response Codes

- **200 OK** — Successfully retrieved the Cheermotes.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/bits/cheermotes' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "prefix": "Cheer",
      "tiers": [
        {
          "min_bits": 1,
          "id": "1",
          "color": "#979797",
          "images": {
            "dark": {
              "animated": {
                "1": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/animated/1/1.gif",
                "1.5": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/animated/1/1.5.gif",
                "2": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/animated/1/2.gif",
                "3": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/animated/1/3.gif",
                "4": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/animated/1/4.gif"
              },
              "static": {
                "1": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/static/1/1.png",
                "1.5": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/static/1/1.5.png",
                "2": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/static/1/2.png",
                "3": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/static/1/3.png",
                "4": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/dark/static/1/4.png"
              }
            },
            "light": {
              "animated": {
                "1": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/animated/1/1.gif",
                "1.5": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/animated/1/1.5.gif",
                "2": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/animated/1/2.gif",
                "3": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/animated/1/3.gif",
                "4": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/animated/1/4.gif"
              },
              "static": {
                "1": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/static/1/1.png",
                "1.5": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/static/1/1.5.png",
                "2": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/static/1/2.png",
                "3": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/static/1/3.png",
                "4": "https://d3aqoihi2n8ty8.cloudfront.net/actions/cheer/light/static/1/4.png"
              }
            }
          },
          "can_cheer": true,
          "show_in_bits_card": true
        }
        ...
      ],
      "type": "global_first_party",
      "order": 1,
      "last_updated": "2018-05-22T00:06:04Z",
      "is_charitable": false
    },
    ...
  ]
}
```

## Get Custom Power-up {#get-custom-power-up}

Gets a list of custom Power-ups that the specified broadcaster created.

> **Note** A channel may offer a maximum of 50 custom Power-ups, which includes both enabled and disabled Power-ups.

### Endpoint

`GET https://api.twitch.tv/helix/bits/custom_power_ups`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **bits:read** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose custom Power-ups you want to get. This ID must match the user ID found in the OAuth token.
- `id` — String
  A list of IDs to filter the Power-ups by. To specify more than one ID, include this
  parameter for each Power-up you want to get. For example, 'id=1234&id=5678'. You may specify
  a maximum of 50 IDs.

  Duplicate IDs are ignored. The response contains only the IDs that were found. If none of
  the IDs were found, the response is 404 Not Found.

### Response Body

- `data` — Object[]. A list of custom Power-ups. The list is in ascending order by `id`. If the broadcaster hasn't created custom Power-ups, the list is empty.
  - `data.broadcaster_id` — String. The ID that uniquely identifies the broadcaster.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.id` — String. The ID that uniquely identifies this custom Power-up.
  - `data.title` — String. The title of the custom Power-up.
  - `data.prompt` — String. The prompt shown to the viewer when they redeem the custom Power-up if user input is required (see the `is_user_input_required` field).
  - `data.bits` — Integer. The amount of Bits for the custom Power-up.
  - `data.image` — Object, Nullable. A set of custom images for the custom Power-up. This field is **null** if the broadcaster didn't upload images.
    - `data.image.url_1x` — String. The URL to a small version of the image.
    - `data.image.url_2x` — String. The URL to a medium version of the image.
    - `data.image.url_4x` — String. The URL to a large version of the image.
  - `data.default_image` — Object. A set of default images for the custom Power-up.
    - `data.default_image.url_1x` — String. The URL to a small version of the image.
    - `data.default_image.url_2x` — String. The URL to a medium version of the image.
    - `data.default_image.url_4x` — String. The URL to a large version of the image.
  - `data.background_color` — String. The background color to use for the custom Power-up. The color is in Hex format (for example, #00E5CB).
  - `data.is_enabled` — Boolean. A Boolean value that determines whether the custom Power-up is enabled. Is **true** if enabled; otherwise, **false**. Disabled custom Power-ups aren't shown to the user.
  - `data.is_user_input_required` — Boolean. A Boolean value that determines whether the user must enter information when redeeming the custom Power-up. Is **true** if the user is prompted.
  - `data.max_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream.
    - `data.max_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the custom Power-up applies a limit on the number of redemptions allowed per live stream. Is **true** if the custom Power-up applies a limit.
    - `data.max_per_stream_setting.max_per_stream` — Int64. The maximum number of redemptions allowed per live stream.
  - `data.max_per_user_per_stream_setting` — Object. The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream.
    - `data.max_per_user_per_stream_setting.is_enabled` — Boolean. A Boolean value that determines whether the custom Power-up applies a limit on the number of redemptions allowed per user per live stream. Is **true** if the custom Power-up applies a limit.
    - `data.max_per_user_per_stream_setting.max_per_user_per_stream` — Int64. The maximum number of redemptions allowed per user per live stream.
  - `data.global_cooldown_setting` — Object. The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown.
    - `data.global_cooldown_setting.is_enabled` — Boolean. A Boolean value that determines whether to apply a cooldown period. Is **true** if a cooldown period is enabled.
    - `data.global_cooldown_setting.global_cooldown_seconds` — Int64. The cooldown period, in seconds.
  - `data.is_paused` — Boolean. A Boolean value that determines whether the custom Power-up is currently paused. Is **true** if the custom Power-up is paused. Viewers can't redeem paused custom Power-ups.
  - `data.is_in_stock` — Boolean. A Boolean value that determines whether the custom Power-up is currently in stock. Is **true** if the custom Power-up is in stock. Viewers can't redeem out of stock custom Power-ups.
  - `data.redemptions_redeemed_current_stream` — Integer, Nullable. The number of redemptions redeemed during the current live stream. The number counts against the `max_per_stream_setting` limit. This field is **null** if the broadcaster's stream isn't live or `max_per_stream_setting` isn't enabled.
  - `data.cooldown_expires_at` — String, Nullable. The timestamp of when the cooldown period expires. Is **null** if the custom Power-up isn't in a cooldown state. See the `global_cooldown_setting` field.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's list of custom Power-ups.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The request exceeds the maximum number of *id* query parameters that you may specify.
- **401 Unauthorized**
  - The ID in *broadcaster_id* must match the user ID in the user access token.
  - The Authorization header must specify a user access token.
  - The user access token must include the **bits:read** scope.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **403 Forbidden**
  - The broadcaster is not a partner or affiliate.
- **404 Not Found**
  - All of the custom Power-ups specified using the *id* query parameter were not found.
- **500 Internal Server Error** — An internal server error occurred. Please report this issue on [our issue tracker](https://github.com/twitchdev/issues/).

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/bits/custom_power_ups?broadcaster_id=274637212' \
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
      "id": "92af127c-7326-4483-a52b-b0da0be61c02",
      "image": null,
      "background_color": "#00FF00",
      "is_enabled": true,
      "bits": 100,
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
        "url_1x": "https://static-cdn.jtvnw.net/twilight-static-assets/Default-Power-up-Line-Lightshade-28x28.png",
        "url_2x": "https://static-cdn.jtvnw.net/twilight-static-assets/Default-Power-up-Line-Lightshade-56x56.png",
        "url_4x": "https://static-cdn.jtvnw.net/twilight-static-assets/Default-Power-up-Line-Lightshade-112x112.png"
      },
      "redemptions_redeemed_current_stream": null,
      "cooldown_expires_at": null
    },
    ...
  ]
}
```

## Get Bits Leaderboard {#get-bits-leaderboard}

Gets the Bits leaderboard for the authenticated broadcaster.

### Endpoint

`GET https://api.twitch.tv/helix/bits/leaderboard`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **bits:read** scope.

### Query Parameters

- `count` — Integer. The number of results to return. The minimum count is 1 and the maximum is 100. The default is 10.
- `period` — String. The time period over which data is aggregated (uses the PST time zone).
  Possible values:
  - `day`: A day spans from 00:00:00 on the day specified in *started_at* and runs through 00:00:00
of the next day.
  - `week`: A week spans from 00:00:00 on the Monday of the week specified in *started_at* and runs
through 00:00:00 of the next Monday.
  - `month`: A month spans from 00:00:00 on the first day of the month specified in *started_at* and
runs through 00:00:00 of the first day of the next month.
  - `year`: A year spans from 00:00:00 on the first day of the year specified in *started_at* and
runs through 00:00:00 of the first day of the next year.
  - `all`: Default. The lifetime of the broadcaster's channel.
- `started_at` — String
  The start date, in RFC3339 format, used for determining the aggregation period. Specify this
  parameter only if you specify the *period* query parameter. The start date is ignored if
  *period* is all.

  Note that the date is converted to PST before being used, so if you set the start time to
  `2022-01-01T00:00:00.0Z` and *period* to `month`, the actual reporting period is December
  2021, not January 2022. If you want the reporting period to be January 2022, you must set
  the start time to `2022-01-01T08:00:00.0Z` or `2022-01-01T00:00:00.0-08:00`.

  If your start date uses the '+' offset operator (for example,
  `2022-01-01T00:00:00.0+05:00`), you must URL encode the start date.
- `user_id` — String. An ID that identifies a user that cheered bits in the channel. If *count* is greater than 1, the response may include users ranked above and below the specified user. To get the leaderboard's top leaders, don't specify a user ID.

### Response Body

- `data` — Object[]. A list of leaderboard leaders. The leaders are returned in rank order by how much they've cheered. The array is empty if nobody has cheered bits.
  - `data.user_id` — String. An ID that identifies a user on the leaderboard.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.rank` — Integer. The user's position on the leaderboard.
  - `data.score` — Integer. The number of Bits the user has cheered.
- `date_range` — Object. The reporting window's start and end dates, in RFC3339 format. The dates are calculated by using the *started_at* and *period* query parameters. If you don't specify the *started_at* query parameter, the fields contain empty strings.
  - `date_range.started_at` — String. The reporting window's start date.
  - `date_range.ended_at` — String. The reporting window's end date.
- `total` — Integer. The number of ranked users in `data`. This is the value in the *count* query parameter or the total number of entries on the leaderboard, whichever is less.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's Bits leaderboard.
- **400 Bad Request**
  - The time period specified in the *period* query parameter is not valid.
  - The *started_at* query parameter is required if *period* is not set to *all*.
  - The value in the *count* query parameter is outside the range of allowed values.
- **401 Unauthorized**
  - The Authorization header is required and must specify a user access token.
  - The user access token must include the the **bits:read** scope.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/bits/leaderboard?count=2&period=week&started_at=2018-02-05T08%3A00%3A00Z' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "user_id": "158010205",
      "user_login": "tundracowboy",
      "user_name": "TundraCowboy",
      "rank": 1,
      "score": 12543
    },
    {
      "user_id": "7168163",
      "user_login": "topramens",
      "user_name": "Topramens",
      "rank": 2,
      "score": 6900
    }
  ],
  "date_range": {
    "started_at": "2018-02-05T08:00:00Z",
    "ended_at": "2018-02-12T08:00:00Z"
  },
  "total": 2
}
```

## Get Extension Transactions {#get-extension-transactions}

Gets an extension's list of transactions. A transaction records the exchange of a currency (for example, Bits) for a digital product.

### Endpoint

`GET https://api.twitch.tv/helix/extensions/transactions`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `extension_id` — String, **Required**. The ID of the extension whose list of transactions you want to get.
- `id` — String
  A transaction ID used to filter the list of transactions. Specify this parameter for each
  transaction you want to get. For example, 'id=1234&id=5678'. You may specify a maximum of
  100 IDs.

  The response contains only the transactions that were found; IDs that don't match a
  transaction are ignored. If you specify *id*, the *first* and *after* query parameters don't
  apply.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of transactions.
  - `data.id` — String. An ID that identifies the transaction.
  - `data.timestamp` — String. The UTC date and time (in RFC3339 format) of the transaction.
  - `data.broadcaster_id` — String. The ID of the broadcaster that owns the channel where the transaction occurred.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.user_id` — String. The ID of the user that purchased the digital product.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.product_type` — String. The type of transaction.
    Possible values:
    - `BITS_IN_EXTENSION`
  - `data.product_data` — Object. Contains details about the digital product.
    - `data.product_data.sku` — String. An ID that identifies the digital product.
    - `data.product_data.domain` — String. Set to **twitch.ext.** followed by the extension's ID.
    - `data.product_data.cost` — Object. Contains details about the digital product's cost.
      - `data.product_data.cost.amount` — Integer. The amount exchanged for the digital product.
      - `data.product_data.cost.type` — String. The type of currency exchanged.
        Possible values:
        - `bits`
    - `data.product_data.inDevelopment` — Boolean. A Boolean value that determines whether the product is in development. Is **true** if the digital product is in development and cannot be exchanged.
    - `data.product_data.displayName` — String. The name of the digital product.
    - `data.product_data.expiration` — String. This field is always empty since you may purchase only unexpired products.
    - `data.product_data.broadcast` — Boolean. A Boolean value that determines whether the data was broadcast to all instances of the extension. Is **true** if the data was broadcast to all instances.
- `pagination` — Object. Contains the information used to page through the list of results. The response doesn't include this object if there are no more pages left to page through or if you specify the *id* query parameter. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of transactions.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
  - The request specified too many *id* query parameters.
  - The pagination cursor is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token.
  - The access token is not valid.
  - The ID in the *extension_id* query parameter must match the client ID in the access token.
  - The ID in the Client-Id header must match the client ID in the access token.
- **404 Not Found**
  - A transaction specified in the *id* query parameter belongs to an extension other than the one in *extension_id*.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/extensions/transactions?extension_id=1234' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "74c52265-e214-48a6-91b9-23b6014e8041",
      "timestamp": "2019-01-28T04:15:53Z",
      "broadcaster_id": "439964613",
      "broadcaster_login": "chikuseuma",
      "broadcaster_name": "chikuseuma",
      "user_id": "424596340",
      "user_login": "quotrok",
      "user_name": "quotrok",
      "product_type": "BITS_IN_EXTENSION",
      "product_data": {
        "domain": "twitch.ext.uo6dggojyb8d6soh92zknwmi5ej1q2",
        "sku": "testSku100",
        "cost": {
          "amount": 100,
          "type": "bits"
        },
        "inDevelopment": false,
        "displayName": "Test Product 100",
        "expiration": "",
        "broadcast": false
      }
    },
    {
      "id": "8d303dc6-a460-4945-9f48-59c31d6735cb",
      "timestamp": "2019-01-18T09:10:13Z",
      "broadcaster_id": "439964613",
      "broadcaster_login": "chikuseuma",
      "broadcaster_name": "chikuseuma",
      "user_id": "439966926",
      "user_login": "liscuit",
      "user_name": "liscuit",
      "product_type": "BITS_IN_EXTENSION",
      "product_data": {
        "domain": "twitch.ext.uo6dggojyb8d6soh92zknwmi5ej1q2",
        "sku": "testSku200",
        "cost": {
          "amount": 200,
          "type": "bits"
        },
        "inDevelopment": false,
        "displayName": "Test Product 200",
        "expiration": "",
        "broadcast": false
      }
    },
    ...
  ],
  "pagination": {
    "cursor": "cursorString"
  }
}
```
