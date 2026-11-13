# Extensions

Manage and interact on behalf of your Twitch Extensions.

Source: https://dev.twitch.tv/docs/api/reference/extensions/

## Contents {#contents}

12 entries on this page:

- [Get Extension Bits Products](#get-extension-bits-products)
- [Update Extension Bits Product](#update-extension-bits-product)
- [Get Extensions](#get-extensions)
- [Send Extension Chat Message](#send-extension-chat-message)
- [Get Extension Configuration Segment](#get-extension-configuration-segment)
- [Set Extension Configuration Segment](#set-extension-configuration-segment)
- [Get Extension Secrets](#get-extension-secrets)
- [Create Extension Secret](#create-extension-secret)
- [Get Extension Live Channels](#get-extension-live-channels)
- [Send Extension PubSub Message](#send-extension-pubsub-message)
- [Get Released Extensions](#get-released-extensions)
- [Set Extension Required Configuration](#set-extension-required-configuration)

## Get Extension Bits Products {#get-extension-bits-products}

Gets the list of Bits products that belongs to the extension. The Client ID in the App Access Token identifies the extension.

### Endpoint

`GET https://api.twitch.tv/helix/bits/extensions`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The client ID in the app access token must be the extension's client ID.

### Query Parameters

- `should_include_all` — Boolean. A Boolean value that determines whether to include disabled or expired Bits products in the response. The default is **false**.

### Response Body

- `data` — Object[]. A list of Bits products that the extension created. The list is in ascending SKU order. The list is empty if the extension hasn't created any products or they're all expired or disabled.
  - `data.sku` — String. The product's SKU. The SKU is unique across an extension's products.
  - `data.cost` — Object, Nullable. An object that contains the product's cost information. Is **null** if the product doesn't have a cost.
    - `data.cost.amount` — Integer. The product's price.
    - `data.cost.type` — String. The type of currency.
      Possible values:
      - `bits`
  - `data.in_development` — Boolean. A Boolean value that indicates whether the product is in development. If **true**, the product is not available for public use.
  - `data.display_name` — String. The product's name as displayed in the extension.
  - `data.expiration` — String, Nullable. The date and time, in RFC3339 format, when the product expires. Is **null** if the product doesn't expire.
  - `data.is_broadcast` — Boolean. A Boolean value that determines whether Bits product purchase events are broadcast to all instances of an extension on a channel. The events are broadcast via the 'onTransactionComplete' helper callback. Is **true** if the event is broadcast to all instances.

### Response Codes

- **200 OK** — Successfully retrieved the list of products.
- **400 Bad Request**
  - The ID in the Client-Id header must belong to an extension.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token; you may not specify a user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/bits/extensions?should_include_all=true' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "sku": "1010",
      "cost": {
        "amount": 990,
        "type": "bits"
      },
      "in_development": true,
      "display_name": "Rusty Crate 2",
      "expiration": "2021-05-18T09:10:13Z",
      "is_broadcast": false
    }
  ]
}
```

## Update Extension Bits Product {#update-extension-bits-product}

Adds or updates a Bits product that the extension created. If the SKU doesn't exist,
the product is added. You may update all fields except the *sku* field.

### Endpoint

`PUT https://api.twitch.tv/helix/bits/extensions`

### Authorization

Requires one of the following:

- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens). The client ID in the app access token must match the extension's client ID.

### Request Body

- `sku` — String, **Required**. The product's SKU. The SKU must be unique within an extension. The product's SKU cannot be changed. The SKU may contain only alphanumeric characters, dashes (-), underscores (_), and periods (.) and is limited to a maximum of 255 characters. No spaces.
- `cost` — Object, **Required**. An object that contains the product's cost information.
  - `cost.amount` — Integer, **Required**. The product's price.
  - `cost.type` — String, **Required**. The type of currency.
    Possible values:
    - `bits`: The minimum price is 1 and the maximum is 10000.
- `display_name` — String, **Required**. The product's name as displayed in the extension. The name must be valid UTF-8 and may contain a maximum of 255 bytes.
- `in_development` — Boolean. A Boolean value that indicates whether the product is in development. Set to **true** if the product is in development and not available for public use. The default is **false**.
- `expiration` — String. The date and time, in RFC3339 format, when the product expires. If not set, the product does not expire. To disable the product, set the expiration date to a date in the past.
- `is_broadcast` — Boolean. A Boolean value that determines whether Bits product purchase events are broadcast to all instances of the extension on a channel. The events are broadcast via the 'onTransactionComplete' helper callback. The default is **false**.

### Response Body

- `data` — Object[]. A list that contains the product that you added or updated.
  - `data.sku` — String. The product's SKU. The SKU is unique across an extension's products.
  - `data.cost` — Object. An object that contains the product's cost information.
    - `data.cost.amount` — Integer. The product's price.
    - `data.cost.type` — String. The type of currency.
      Possible values:
      - `bits`
  - `data.in_development` — Boolean. A Boolean value that indicates whether the product is in development. If **true**, the product is not available for public use.
  - `data.display_name` — String. The product's name as displayed in the extension.
  - `data.expiration` — String, Nullable. The date and time, in RFC3339 format, when the product expires. Is **null** if the product doesn't expire.
  - `data.is_broadcast` — Boolean. A Boolean value that determines whether Bits product purchase events are broadcast to all instances of an extension on a channel. The events are broadcast via the 'onTransactionComplete' helper callback. Is **true** if the event is broadcast to all instances.

### Response Codes

- **200 OK** — Successfully created the product.
- **400 Bad Request**
  - The *sku* field is required.
  - The value in the *sku* field is not valid. The SKU may contain only alphanumeric characters, dashes (-), underscores (_), and periods (.).
  - The *cost* object's *amount* field is required.
  - The value in the *cost* object's *amount* field is not valid.
  - The *cost* object's *type* field is required.
  - The value in the *cost* object's *type* field is not valid.
  - The *display_name* field is required.
  - The value in the *display_name* field is not valid. The name must be valid UTF-8 and may contain a maximum of 255 bytes.
  - The value in the *expiration* field is not valid. The date and time must be in RFC3339 format.
  - The ID in the Client-Id header must belong to the extension.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token; you may not specify a user access token.
  - The OAuth token is not valid.
  - The ID in the Client-Id header must match the Client ID in the OAuth token.
- **429 Too Many Requests**
  - The extension already has the maximum amount of products. You may update the existing products, but you may not add new ones.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/bits/extensions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "sku": "1010",
      "cost": {
        "amount": 990,
        "type": "bits"
      },
      "in_development": true,
      "display_name": "Rusty Crate 2",
      "expiration": "2021-05-18T09:10:13Z",
      "is_broadcast": true
    }
  ]
}
```

## Get Extensions {#get-extensions}

Gets information about an extension.

### Endpoint

`GET https://api.twitch.tv/helix/extensions`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)), and the `role` field must be set to *external*. To get a version that isn't released, the user in `user_id` must own the extension or be on the version's testing allowlist.

### Query Parameters

- `extension_id` — String, **Required**. The ID of the extension to get.
- `extension_version` — String. The version of the extension to get. If not specified, it returns the released version. If the extension doesn't have a released version, you must specify a version; otherwise, the request fails with 404 Not Found.

### Response Body

- `data` — Object[]. A list that contains the specified extension.
  - `data.author_name` — String. The name of the user or organization that owns the extension.
  - `data.bits_enabled` — Boolean. A Boolean value that determines whether the extension has features that use Bits. Is **true** if the extension has features that use Bits.
  - `data.can_install` — Boolean
    A Boolean value that determines whether a user can install the extension on their
    channel. Is **true** if a user can install the extension.

    Typically, this is set to **false** if the extension is currently in testing mode and
    requires users to be allowlisted (the allowlist is configured on Twitch's [developer
    site](https://dev.twitch.tv/console/extensions) under the **Extensions** ->
    **Extension** -> **Version** -> **Access**).
  - `data.configuration_location` — String. The location of where the extension's configuration is stored.
    Possible values:
    - `hosted`: The Extensions Configuration Service hosts the configuration.
    - `custom`: The Extension Backend Service (EBS) hosts the configuration.
    - `none`: The extension doesn't require configuration.
  - `data.description` — String. A longer description of the extension. It appears on the details page.
  - `data.eula_tos_url` — String. A URL to the extension's Terms of Service.
  - `data.has_chat_support` — Boolean. A Boolean value that determines whether the extension can communicate with the installed channel's chat. Is **true** if the extension can communicate with the channel's chat room.
  - `data.icon_url` — String. A URL to the default icon that's displayed in the Extensions directory.
  - `data.icon_urls` — map[string]string. A dictionary that contains URLs to different sizes of the default icon. The dictionary's key identifies the icon's size (for example, 24x24), and the dictionary's value contains the URL to the icon.
  - `data.id` — String. The extension's ID.
  - `data.name` — String. The extension's name.
  - `data.privacy_policy_url` — String. A URL to the extension's privacy policy.
  - `data.request_identity_link` — Boolean. A Boolean value that determines whether the extension wants to explicitly ask viewers to link their Twitch identity.
  - `data.screenshot_urls` — String[]. A list of URLs to screenshots that are shown in the Extensions marketplace.
  - `data.state` — String. The extension's state.
    Possible values:
    - `Approved`
    - `Assets Uploaded`
    - `Deleted`
    - `Deprecated`
    - `In Review`
    - `Pending Action`
    - `Rejected`
    - `Released`
    - `Testing`
  - `data.subscriptions_support_level` — String. Indicates whether the extension can view the user's subscription level on the channel that the extension is installed on.
    Possible values:
    - `none`: The extension can't view the user's subscription level.
    - `optional`: The extension can view the user's subscription level.
  - `data.summary` — String. A short description of the extension that streamers see when hovering over the discovery splash screen in the Extensions manager.
  - `data.support_email` — String. The email address that users use to get support for the extension.
  - `data.version` — String. The extension's version number.
  - `data.viewer_summary` — String. A brief description displayed on the channel to explain how the extension works.
  - `data.views` — Object. Describes all views-related information such as how the extension is displayed on mobile devices. The object includes only the views that the extension supports.
    - `data.views.mobile` — Object. Describes how the extension is displayed on mobile devices.
      - `data.views.mobile.viewer_url` — String. The HTML file that is shown to viewers on mobile devices. This page is presented to viewers as a panel behind the chat area of the mobile app.
    - `data.views.panel` — Object. Describes how the extension is rendered if the extension may be activated as a panel extension.
      - `data.views.panel.viewer_url` — String. The HTML file that is shown to viewers on the channel page when the extension is activated in a Panel slot.
      - `data.views.panel.height` — Integer. The height, in pixels, of the panel component that the extension is rendered in.
      - `data.views.panel.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.video_overlay` — Object. Describes how the extension is rendered if the extension may be activated as a video-overlay extension.
      - `data.views.video_overlay.viewer_url` — String. The HTML file that is shown to viewers on the channel page when the extension is activated on the Video - Overlay slot.
      - `data.views.video_overlay.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.component` — Object. Describes how the extension is rendered if the extension may be activated as a video-component extension.
      - `data.views.component.viewer_url` — String. The HTML file that is shown to viewers on the channel page when the extension is activated in a Video - Component slot.
      - `data.views.component.aspect_width` — Integer. Deprecated.
      - `data.views.component.aspect_height` — Integer. Deprecated.
      - `data.views.component.aspect_ratio_x` — Integer. The width value of the ratio (width : height) which determines the extension's width, and how the extension's iframe will resize in different video player environments.
      - `data.views.component.aspect_ratio_y` — Integer. The height value of the ratio (width : height) which determines the extension's height, and how the extension's iframe will resize in different video player environments.
      - `data.views.component.autoscale` — Boolean. A Boolean value that determines whether to apply CSS zoom. If **true**, a CSS zoom is applied such that the size of the extension is variable but the inner dimensions are fixed based on Scale Pixels. This allows your extension to render as if it is of fixed width and height. If **false**, the inner dimensions of the extension iframe are variable, meaning your extension must implement responsiveness.
      - `data.views.component.scale_pixels` — Integer. The base width, in pixels, of the extension to use when scaling (see `autoscale`). This value is ignored if `autoscale` is **false**.
      - `data.views.component.target_height` — Integer. The height as a percent of the maximum height of a video component extension. Values are between 1% - 100%.
      - `data.views.component.size` — Float. Deprecated.
      - `data.views.component.zoom` — Boolean. Deprecated.
      - `data.views.component.zoom_pixels` — Integer. Deprecated.
      - `data.views.component.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.config` — Object. Describes the view that is shown to broadcasters while they are configuring your extension within the Extension Manager.
      - `data.views.config.viewer_url` — String. The HTML file shown to broadcasters while they are configuring your extension within the Extension Manager.
      - `data.views.config.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.live_config` — Object. Describes the view that is shown to broadcasters in the Live module of the dashboard.
      - `data.views.live_config.viewer_url` — String. The HTML file that is shown to broadcasters in the Live module of the dashboard. It's used for actions that broadcasters take while the extension is active, such as creating a new poll.
      - `data.views.live_config.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
  - `data.allowlisted_config_urls` — String[]. Allowlisted configuration URLs for displaying the extension (the allowlist is configured on Twitch's [developer site](https://dev.twitch.tv/console/extensions) under the **Extensions** -> **Extension** -> **Version** -> **Capabilities**).
  - `data.allowlisted_panel_urls` — String[]. Allowlisted panel URLs for displaying the extension (the allowlist is configured on Twitch's [developer site](https://dev.twitch.tv/console/extensions) under the **Extensions** -> **Extension** -> **Version** -> **Capabilities**).

### Response Codes

- **200 OK** — Successfully retrieved the list of extensions.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
- **401 Unauthorized**
  - The request must specify the Authorization header.
  - The Authorization header is required and must specify a JWT token.
  - The JWT token is not valid.
  - The version in *extension_version* isn't released, and the user in the JWT's `user_id` field isn't allowed to get it.
  - The request must specify the Client-Id header.
- **404 Not Found**
  - The extension in the *extension_id* query parameter was not found.
  - The *extension_version* query parameter isn't specified, and the extension doesn't have a released version.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/extensions?extension_id=uo6dggojyb8d6soh92zknwmi5ej1q2&extension_version=0.0.9' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "author_name": "Twitch Developers",
      "bits_enabled": true,
      "can_install": false,
      "configuration_location": "hosted",
      "description": "An extension for testing all the features that we add to extensions",
      "eula_tos_url": "",
      "has_chat_support": true,
      "icon_url": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/logob6c995d8-8b45-48cc-a748-b256e92ac1cd",
      "icon_urls": {
        "100x100": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/logob6c995d8-8b45-48cc-a748-b256e92ac1cd",
        "24x24": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/taskbar905b19da-e7e5-4d8f-beb7-f543a861ac1e",
        "300x200": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/discoveryd9545b2c-5474-46d7-a523-1c3835d862ce"
      },
      "id": "pgn0bjv51epi7eaekt53tovjnc82qo",
      "name": "Official Developers Demo",
      "privacy_policy_url": "",
      "request_identity_link": true,
      "screenshot_urls": [
        "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/screenshotbdec475d-3d2f-4378-b334-941dfddc897a"
      ],
      "state": "Released",
      "subscriptions_support_level": "optional",
      "summary": "Test ALL the extensions features!",
      "support_email": "dx-extensions-test-dev@justin.tv",
      "version": "0.0.9",
      "viewer_summary": "Test ALL the extensions features!",
      "views": {
        "mobile": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html"
        },
        "panel": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html",
          "height": 300,
          "can_link_external_content": false
        },
        "video_overlay": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html",
          "can_link_external_content": false
        },
        "component": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html",
          "aspect_width": 0,
          "aspect_height": 0,
          "aspect_ratio_x": 48000,
          "aspect_ratio_y": 36000,
          "autoscale": true,
          "scale_pixels": 1024,
          "target_height": 5333,
          "size": 0,
          "zoom": false,
          "zoom_pixels": 0,
          "can_link_external_content": false
        }
      },
      "allowlisted_config_urls": [],
      "allowlisted_panel_urls": []
    }
  ]
}
```

## Send Extension Chat Message {#send-extension-chat-message}

Sends a message to the specified broadcaster's chat room.

The extension's name is used as the username for the message in the chat room. To send a chat
message, your extension must enable **Chat Capabilities** (under your extension's **Capabilities**
tab).

**Rate Limits**: You may send a maximum of 12 messages per minute per combination of broadcaster
ID, extension ID, and extension version.

### Endpoint

`POST https://api.twitch.tv/helix/extensions/chat`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). The `role` field must be set to *external* or *broadcaster*, and the `user_id` field must contain the ID of the user that owns the extension or the ID in *broadcaster_id*.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that has activated the extension.

### Request Body

- `text` — String, **Required**. The message. The message may contain a maximum of 280 characters.
- `extension_id` — String, **Required**. The ID of the extension that's sending the chat message.
- `extension_version` — String, **Required**. The extension's version number.

### Response Codes

- **204 No Content** — Successfully sent the chat message.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *extension_id* field in the request's body is required.
  - The *extension_version* field in the request's body is required.
  - The *text* field in the request's body is required.
  - The *text* field in the request's body must contain non-whitespace characters.
  - The message is too long.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The `user_id` field in the JWT must contain the ID of the user that owns the extension or the ID in *broadcaster_id*.
  - The extension must be active on the broadcaster's channel with chat enabled.
  - The JWT token is not valid.
  - The Client-Id header is required.
- **404 Not Found**
  - The extension version in the *extension_version* field isn't installed on the broadcaster's channel.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/extensions/chat?broadcaster_id=237757755' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"text":"Hello","extension_id":"uo6dggojyb8d6soh92zknwmi5ej1q2","extension_version":"0.0.9"}'
```

## Get Extension Configuration Segment {#get-extension-configuration-segment}

**Rate Limits**: You may make a maximum of 20 requests per minute per combination of extension
client ID and broadcaster ID, regardless of which segments you request. Requests that don't
specify a broadcaster ID share a single limit per extension client ID.

### Endpoint

`GET https://api.twitch.tv/helix/extensions/configurations`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). The `role` field must be set to *external*.

### Query Parameters

- `broadcaster_id` — String. The ID of the broadcaster that installed the extension. This parameter is required if you set the *segment* parameter to broadcaster or developer. Do not specify this parameter if you set *segment* to global.
- `extension_id` — String, **Required**. The ID of the extension that contains the configuration segment you want to get.
- `segment` — String[]. The type of configuration segment to get. To get more than one segment, include this parameter for each segment, for example, `segment=broadcaster&segment=developer`. If you don't specify a segment, the list in the response is empty.
  Possible values:
  - `broadcaster`
  - `developer`
  - `global`

### Response Body

- `data` — Object[]. The list of requested configuration segments. The list is returned in the same order that you specified the list of segments in the request. Segments that haven't been set aren't included in the list.
  - `data.segment` — String. The type of segment.
    Possible values:
    - `broadcaster`
    - `developer`
    - `global`
  - `data.broadcaster_id` — String. The ID of the broadcaster that installed the extension. Is an empty string if `segment` is global.
  - `data.content` — String. The contents of the segment. This string may be a plain-text string or a string-encoded JSON object.
  - `data.version` — String. The version number that identifies this definition of the segment's data.

### Response Codes

- **200 OK** — Successfully retrieved the configurations.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
  - The value in the *segment* query parameter is not valid.
  - The *broadcaster_id* query parameter is required if the *segment* query parameter is set to broadcaster or developer.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The JWT token is not valid.
  - The Client-Id header is required.
- **429 Too many requests**
  - The app exceeded the number of requests that it may make per minute. See Rate Limits above.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/extensions/configurations?extension_id=%3Cyour%20extension%20id%3E&segment=global' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "segment": "global",
      "broadcaster_id": "",
      "content": "hello config!",
      "version": "0.0.1"
    }
  ]
}
```

## Set Extension Configuration Segment {#set-extension-configuration-segment}

Updates an Extension configuration segment.

The segment is limited to 5 KB. Extensions that are active on a channel do not receive the updated
configuration.

**Rate Limits**: You may update the configuration a maximum of 20 times per minute.

### Endpoint

`PUT https://api.twitch.tv/helix/extensions/configurations`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). Set the `role` field to *external* and the `user_id` field to the ID of the user that owns the extension. To update the broadcaster segment, you may instead set `user_id` to the ID in _broadcaster\_id_.

### Request Body

- `extension_id` — String, **Required**. The ID of the extension to update.
- `segment` — String, **Required**. The configuration segment to update.
  Possible values:
  - `broadcaster`
  - `developer`
  - `global`
- `broadcaster_id` — String. The ID of the broadcaster that installed the extension. Include this field only if the *segment* is set to developer or broadcaster.
- `content` — String. The contents of the segment. This string may be a plain-text string or a string-encoded JSON object.
- `version` — String. The version number that identifies this definition of the segment's data. If not specified, the segment is saved with an empty version string.

### Response Codes

- **204 No Content** — Successfully updated the configuration.
- **400 Bad Request**
  - The _extension\_id_ field is required.
  - The *segment* field is required and must be set to broadcaster, developer, or global.
  - The _broadcaster\_id_ field is required if *segment* is set to developer or broadcaster.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The JWT token is not valid.
  - The `user_id` field in the JWT must contain the ID of the user that owns the extension, or, for the broadcaster segment, the ID in _broadcaster\_id_.
  - The Client-Id header is required.
- **422 Unprocessable Entity**
  - The segment's content is larger than 5 KB.
  - The _broadcaster\_id_ field may not be set if *segment* is set to global.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/extensions/configurations' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"extension_id":"uo6dggojyb8d6soh92zknwmi5ej1q2","segment":"global","version":"0.0.1","content":"hello config!"}'
```

## Get Extension Secrets {#get-extension-secrets}

Gets an extension's list of shared secrets.

### Endpoint

`GET https://api.twitch.tv/helix/extensions/jwt/secrets`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). Set the `role` field to *external* and the `user_id` field to the ID of the user that owns the extension.

### Query Parameters

- `extension_id` — String, **Required**. The ID of the extension whose shared secrets you want to get.

### Response Body

- `data` — Object[]. The list of shared secrets that the extension created.
  - `data.format_version` — Integer. The version number that identifies this definition of the secret's data.
  - `data.secrets` — Object[]. The list of secrets.
    - `data.secrets.content` — String. The secret, base64-encoded. Decode it to get the key that you use to sign and verify JWTs.
    - `data.secrets.active_at` — String. The UTC date and time (in RFC3339 format) that you may begin using this secret to sign a JWT.
    - `data.secrets.expires_at` — String. The UTC date and time (in RFC3339 format) that you must stop using this secret to decode a JWT.

### Response Codes

- **200 OK** — Successfully retrieved the list of secrets.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The JWT token is not valid.
  - The `user_id` field in the JWT must contain the ID of the user that owns the extension.
  - The Client-Id header is required.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/extensions/jwt/secrets?extension_id=uo6dggojyb8d6soh92zknwmi5ej1q2' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "format_version": 1,
      "secrets": [
        {
          "content": "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=",
          "active_at": "2021-03-29T06:58:40.858343036Z",
          "expires_at": "2121-03-05T06:58:40.858343036Z"
        }
      ]
    }
  ]
}
```

## Create Extension Secret {#create-extension-secret}

Creates a shared secret used to sign and verify JWT tokens.

Creating a new secret removes the current secrets from service. Use this function only when you are ready to use the new secret it returns.

### Endpoint

`POST https://api.twitch.tv/helix/extensions/jwt/secrets`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). Set the `role` field to *external* and the `user_id` field to the ID of the user that owns the extension.

### Query Parameters

- `extension_id` — String, **Required**. The ID of the extension to apply the shared secret to.
- `delay` — Integer. The amount of time, in seconds, to delay activating the secret. The delay should provide enough time for instances of the extension to gracefully switch over to the new secret. The minimum delay is 300 seconds (5 minutes). The default is 300 seconds.

### Response Body

- `data` — Object[]. A list that contains the newly added secrets.
  - `data.format_version` — Integer. The version number that identifies this definition of the secret's data.
  - `data.secrets` — Object[]. The list of secrets.
    - `data.secrets.content` — String. The secret, base64-encoded. Decode it to get the key that you use to sign and verify JWTs.
    - `data.secrets.active_at` — String. The UTC date and time (in RFC3339 format) that you may begin using this secret to sign a JWT.
    - `data.secrets.expires_at` — String. The UTC date and time (in RFC3339 format) that you must stop using this secret to decode a JWT.

### Response Codes

- **200 OK** — Successfully created the new secret.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
  - The delay specified in the *delay* query parameter is too short.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The JWT token is not valid.
  - The `user_id` field in the JWT must contain the ID of the user that owns the extension.
  - The Client-Id header is required.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/extensions/jwt/secrets?extension_id=uo6dggojyb8d6soh92zknwmi5ej1q2&delay=600' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "format_version": 1,
      "secrets": [
        {
          "content": "XYZd6uBvvTT+nOhI8+X8Q2jy9hKxiu9H8p8hZFY6AUA=",
          "active_at": "2021-03-29T06:58:40.858343036Z",
          "expires_at": "2021-04-22T05:21:54.99261682Z"
        },
        {
          "content": "/Je7UoYfzzKNCnq+IB+WMrhwPkNmVjSPbRs5j0LpLDk=",
          "active_at": "2021-04-22T04:16:54.996365329Z",
          "expires_at": "2121-03-29T04:16:54.996365329Z"
        }
      ]
    }
  ]
}
```

## Get Extension Live Channels {#get-extension-live-channels}

Gets a list of broadcasters that are streaming live and have installed or activated the extension.

It may take a few minutes for the list to include or remove broadcasters that have recently gone
live or stopped broadcasting.

If the extension requires configuration through the configuration service, the list includes
only broadcasters whose broadcaster and developer configuration segments have the required
versions.

### Endpoint

`GET https://api.twitch.tv/helix/extensions/live`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `extension_id` — String, **Required**. The ID of the extension to get. Returns the list of broadcasters that are live and that have installed or activated this extension.
- `first` — Integer. The specific maximum number of items per page in the response. The minimum page size is 1 item per page and the maximum is 100 items per page. The default is 20. The actual number returned may be less than this limit. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
- `after` — String. The cursor used to get the next page of results. The `pagination` field in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. The list of broadcasters that are streaming live and that have installed or activated the extension.
  - `data.broadcaster_id` — String. The ID of the broadcaster that is streaming live and has installed or activated the extension.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.game_name` — String. The name of the category or game being streamed.
  - `data.game_id` — String. The ID of the category or game being streamed. May be an empty string if the category can't be identified.
  - `data.title` — String. The title of the broadcaster's stream. May be an empty string if not specified.
- `pagination` — String. This field contains the cursor used to page through the results. The field is empty if there are no more pages left to page through. Note that this field is a string compared to other endpoints that use a **Pagination** object. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Codes

- **200 OK** — Successfully retrieved the list of broadcasters. The list is empty if no broadcasters that use the extension are streaming live.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
  - The *first* query parameter is outside the allowed range of values.
  - The pagination cursor is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify an app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **404 Not Found**
  - The extension specified in the *extension_id* query parameter was not found or hasn't been released.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/extensions/live?extension_id=uo6dggojyb8d6soh92zknwmi5ej1q2' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "broadcaster_id": "252766116",
      "broadcaster_name": "swoosh_xii",
      "game_name": "Tom Clancy's Rainbow Six Siege",
      "game_id": "460630",
      "title": "[PS4] ITA/ENG UNRANKED CHILLIN' (SUB 1/15) - !instagram !donation !sens !team !youtube"
    },
    {
      "broadcaster_id": "264525686",
      "broadcaster_name": "gaddem_",
      "game_name": "For Honor",
      "game_id": "490382",
      "title": "any Kätzchen ? - 680 Rep + > Kompetitive Kitten"
    },
    {
      "broadcaster_id": "264787895",
      "broadcaster_name": "LenhadorGameplay",
      "game_name": "For Honor",
      "game_id": "490382",
      "title": "Vazou o novo personagem! *Triste*"
    }
  ],
  "pagination": "YVc1emRHRnNiQ015TmpJek5qazVOVHBoYWpKbGRIZDFaR0Z5YjNCMGN6UTJNMkZ1TUdwM2FHWnBZbm8yYW5rNjoy"
}
```

## Send Extension PubSub Message {#send-extension-pubsub-message}

Sends a message to one or more viewers.

You can send messages to a specific channel or to all channels where your extension is active.
This endpoint uses the same mechanism as the [send](https://dev.twitch.tv/docs/extensions/reference.md#send) JavaScript helper
function used to send messages.

**Rate Limits**: You may send a maximum of 100 messages per minute per combination of extension
client ID and broadcaster ID.

### Endpoint

`POST https://api.twitch.tv/helix/extensions/pubsub`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `exp`, `channel_id`, and `pubsub_perms` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). Your EBS should set the `role` field to *external*.  To send the message to a specific channel, set the `channel_id` field in the JWT to the channel's ID and set the `pubsub_perms.send` array to *broadcast*.  ~~~json  {  "exp": 1503343947,  "user_id": "27419011",  "role": "external",  "channel_id": "27419011",  "pubsub_perms": {  "send":[  "broadcast"  ]  } }  ~~~  To send the message to all channels on which your extension is active, set the `channel_id` field to *all* and set the `pubsub_perms.send` array to *global*.  ~~~json  {  "exp": 1503343947,  "user_id": "27419011",  "role": "external",  "channel_id": "all",  "pubsub_perms": {  "send":[  "global"  ]  } }  ~~~

### Request Body

- `target` — String[], **Required**. The target of the message.
  Possible values:
  - `broadcast`
  - `global`
  - `whisper-<user-id>`
- `broadcaster_id` — String. The ID of the broadcaster to send the message to. This field is required if *is_global_broadcast* is **false**. Don't include this field if *is_global_broadcast* is set to **true**.
- `is_global_broadcast` — Boolean. A Boolean value that determines whether the message should be sent to all channels where your extension is active. Set to **true** if the message should be sent to all channels. The default is **false**.
- `message` — String, **Required**. The message to send. The message can be a plain-text string or a string-encoded JSON object. The message is limited to a maximum of 5 KB.

### Response Codes

- **204 No Content** — Successfully sent the message.
- **400 Bad Request**
  - The _broadcaster\_id_ field in the request's body may only be set if the *is_global_broadcast* field is set to **false**.
  - The _broadcaster\_id_ field in the request's body is required if the *is_global_broadcast* field is set to **false**.
  - The *message* field in the request's body is required.
  - The *target* field in the request's body is required.
  - The JWT must include the `pubsub_perms` field.
  - The `role` field in the JWT is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The Client-Id header is required.
- **403 Forbidden**
  - The `channel_id` field in the JWT must match the ID in _broadcaster\_id_, or must be set to *all* if *is_global_broadcast* is **true**.
  - JWT could not be verified
  - The JWT has expired.
  - The `pubsub_perms.send` field in the JWT must allow every target in the *target* field.
- **404 Not Found**
  - The extension in the Client-Id header was not found.
- **422 Unprocessable Entity**
  - The message is too large.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/extensions/pubsub' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"message":"hello world!","broadcaster_id":"141981764","target":["broadcast"]}'
```

## Get Released Extensions {#get-released-extensions}

Returns the extension if its `state` is Released.

### Endpoint

`GET https://api.twitch.tv/helix/extensions/released`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `extension_id` — String, **Required**. The ID of the extension to get.
- `extension_version` — String. The version of the extension to get. If not specified, it returns the released version.

### Response Body

- `data` — Object[]. A list that contains the specified extension.
  - `data.author_name` — String. The name of the user or organization that owns the extension.
  - `data.bits_enabled` — Boolean. A Boolean value that determines whether the extension has features that use Bits. Is **true** if the extension has features that use Bits.
  - `data.can_install` — Boolean
    A Boolean value that determines whether a user can install the extension on their
    channel. Is **true** if a user can install the extension.

    Typically, this is set to **false** if the extension is currently in testing mode and
    requires users to be allowlisted (the allowlist is configured on Twitch's [developer
    site](https://dev.twitch.tv/console/extensions) under the **Extensions** ->
    **Extension** -> **Version** -> **Access**).
  - `data.configuration_location` — String. The location of where the extension's configuration is stored.
    Possible values:
    - `hosted`: The Extensions Configuration Service hosts the configuration.
    - `custom`: The Extension Backend Service (EBS) hosts the configuration.
    - `none`: The extension doesn't require configuration.
  - `data.description` — String. A longer description of the extension. It appears on the details page.
  - `data.eula_tos_url` — String. A URL to the extension's Terms of Service.
  - `data.has_chat_support` — Boolean. A Boolean value that determines whether the extension can communicate with the installed channel's chat. Is **true** if the extension can communicate with the channel's chat room.
  - `data.icon_url` — String. A URL to the default icon that's displayed in the Extensions directory.
  - `data.icon_urls` — map[string]string. A dictionary that contains URLs to different sizes of the default icon. The dictionary's key identifies the icon's size (for example, 24x24), and the dictionary's value contains the URL to the icon.
  - `data.id` — String. The extension's ID.
  - `data.name` — String. The extension's name.
  - `data.privacy_policy_url` — String. A URL to the extension's privacy policy.
  - `data.request_identity_link` — Boolean. A Boolean value that determines whether the extension wants to explicitly ask viewers to link their Twitch identity.
  - `data.screenshot_urls` — String[]. A list of URLs to screenshots that are shown in the Extensions marketplace.
  - `data.state` — String. The extension's state. This endpoint returns only released extensions.
    Possible values:
    - `Released`
  - `data.subscriptions_support_level` — String. Indicates whether the extension can view the user's subscription level on the channel that the extension is installed on.
    Possible values:
    - `none`: The extension can't view the user's subscription level.
    - `optional`: The extension can view the user's subscription level.
  - `data.summary` — String. A short description of the extension that streamers see when hovering over the discovery splash screen in the Extensions manager.
  - `data.support_email` — String. The email address that users use to get support for the extension.
  - `data.version` — String. The extension's version number.
  - `data.viewer_summary` — String. A brief description displayed on the channel to explain how the extension works.
  - `data.views` — Object. Describes all views-related information such as how the extension is displayed on mobile devices. The object includes only the views that the extension supports.
    - `data.views.mobile` — Object. Describes how the extension is displayed on mobile devices.
      - `data.views.mobile.viewer_url` — String. The HTML file that is shown to viewers on mobile devices. This page is presented to viewers as a panel behind the chat area of the mobile app.
    - `data.views.panel` — Object. Describes how the extension is rendered if the extension may be activated as a panel extension.
      - `data.views.panel.viewer_url` — String. The HTML file that is shown to viewers on the channel page when the extension is activated in a Panel slot.
      - `data.views.panel.height` — Integer. The height, in pixels, of the panel component that the extension is rendered in.
      - `data.views.panel.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.video_overlay` — Object. Describes how the extension is rendered if the extension may be activated as a video-overlay extension.
      - `data.views.video_overlay.viewer_url` — String. The HTML file that is shown to viewers on the channel page when the extension is activated on the Video - Overlay slot.
      - `data.views.video_overlay.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.component` — Object. Describes how the extension is rendered if the extension may be activated as a video-component extension.
      - `data.views.component.viewer_url` — String. The HTML file that is shown to viewers on the channel page when the extension is activated in a Video - Component slot.
      - `data.views.component.aspect_width` — Integer. Deprecated.
      - `data.views.component.aspect_height` — Integer. Deprecated.
      - `data.views.component.aspect_ratio_x` — Integer. The width value of the ratio (width : height) which determines the extension's width, and how the extension's iframe will resize in different video player environments.
      - `data.views.component.aspect_ratio_y` — Integer. The height value of the ratio (width : height) which determines the extension's height, and how the extension's iframe will resize in different video player environments.
      - `data.views.component.autoscale` — Boolean. A Boolean value that determines whether to apply CSS zoom. If **true**, a CSS zoom is applied such that the size of the extension is variable but the inner dimensions are fixed based on Scale Pixels. This allows your extension to render as if it is of fixed width and height. If **false**, the inner dimensions of the extension iframe are variable, meaning your extension must implement responsiveness.
      - `data.views.component.scale_pixels` — Integer. The base width, in pixels, of the extension to use when scaling (see `autoscale`). This value is ignored if `autoscale` is **false**.
      - `data.views.component.target_height` — Integer. The height as a percent of the maximum height of a video component extension. Values are between 1% - 100%.
      - `data.views.component.size` — Float. Deprecated.
      - `data.views.component.zoom` — Boolean. Deprecated.
      - `data.views.component.zoom_pixels` — Integer. Deprecated.
      - `data.views.component.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.config` — Object. Describes the view that is shown to broadcasters while they are configuring your extension within the Extension Manager.
      - `data.views.config.viewer_url` — String. The HTML file shown to broadcasters while they are configuring your extension within the Extension Manager.
      - `data.views.config.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
    - `data.views.live_config` — Object. Describes the view that is shown to broadcasters in the Live module of the dashboard.
      - `data.views.live_config.viewer_url` — String. The HTML file that is shown to broadcasters in the Live module of the dashboard. It's used for actions that broadcasters take while the extension is active, such as creating a new poll.
      - `data.views.live_config.can_link_external_content` — Boolean. A Boolean value that determines whether the extension can link to non-Twitch domains.
  - `data.allowlisted_config_urls` — String[]. Allowlisted configuration URLs for displaying the extension (the allowlist is configured on Twitch's [developer site](https://dev.twitch.tv/console/extensions) under the **Extensions** -> **Extension** -> **Version** -> **Capabilities**).
  - `data.allowlisted_panel_urls` — String[]. Allowlisted panel URLs for displaying the extension (the allowlist is configured on Twitch's [developer site](https://dev.twitch.tv/console/extensions) under the **Extensions** -> **Extension** -> **Version** -> **Capabilities**).

### Response Codes

- **200 OK** — Successfully retrieved the extension.
- **400 Bad Request**
  - The *extension_id* query parameter is required.
- **401 Unauthorized**
  - The Authorization header must specify an app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
  - The version specified in the *extension_version* query parameter isn't released.
- **404 Not Found**
  - The extension specified in the *extension_id* query parameter was not found or doesn't have a released version.
  - The version specified in the *extension_version* query parameter was not found or was deleted.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/extensions/released?extension_version=0.0.9&extension_id=uo6dggojyb8d6soh92zknwmi5ej1q2' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "author_name": "Twitch Developer Experience",
      "bits_enabled": true,
      "can_install": false,
      "configuration_location": "hosted",
      "description": "An extension for testing all the features that we add to extensions",
      "eula_tos_url": "",
      "has_chat_support": true,
      "icon_url": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/logob6c995d8-8b45-48cc-a748-b256e92ac1cd",
      "icon_urls": {
        "100x100": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/logob6c995d8-8b45-48cc-a748-b256e92ac1cd",
        "24x24": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/taskbar905b19da-e7e5-4d8f-beb7-f543a861ac1e",
        "300x200": "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/discoveryd9545b2c-5474-46d7-a523-1c3835d862ce"
      },
      "id": "pgn0bjv51epi7eaekt53tovjnc82qo",
      "name": "Official Developer Experience Demo",
      "privacy_policy_url": "",
      "request_identity_link": true,
      "screenshot_urls": [
        "https://extensions-discovery-images.twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.8/screenshotbdec475d-3d2f-4378-b334-941dfddc897a"
      ],
      "state": "Released",
      "subscriptions_support_level": "optional",
      "summary": "Test ALL the extensions features!",
      "support_email": "dx-extensions-test-dev@justin.tv",
      "version": "0.0.9",
      "viewer_summary": "Test ALL the extensions features!",
      "views": {
        "mobile": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html"
        },
        "panel": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html",
          "height": 300,
          "can_link_external_content": false
        },
        "video_overlay": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html",
          "can_link_external_content": false
        },
        "component": {
          "viewer_url": "https://pgn0bjv51epi7eaekt53tovjnc82qo.ext-twitch.tv/pgn0bjv51epi7eaekt53tovjnc82qo/0.0.9/f9a0d8aae0f9dd0b2d6ef3416b96bc79/index.html",
          "aspect_width": 0,
          "aspect_height": 0,
          "aspect_ratio_x": 48000,
          "aspect_ratio_y": 36000,
          "autoscale": true,
          "scale_pixels": 1024,
          "target_height": 5333,
          "size": 0,
          "zoom": false,
          "zoom_pixels": 0,
          "can_link_external_content": false
        }
      },
      "allowlisted_config_urls": [],
      "allowlisted_panel_urls": []
    }
  ]
}
```

## Set Extension Required Configuration {#set-extension-required-configuration}

Updates the extension's _required_configuration_ string.

Use this endpoint if your extension requires the broadcaster to configure the extension before
activating it (to require configuration, you must select **Custom/My Own Service** in Extension
[Capabilities](https://dev.twitch.tv/docs/extensions/life-cycle.md#capabilities)). For more information, see [Required
Configurations](https://dev.twitch.tv/docs/extensions/building.md#required-configurations) and [Setting Required
Configuration](https://dev.twitch.tv/docs/extensions/building.md#setting-required-configuration-with-the-configuration-service-optional).

### Endpoint

`PUT https://api.twitch.tv/helix/extensions/required_configuration`

### Authorization

Requires one of the following:

- A [signed JSON Web Token (JWT)](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). Requires a signed JSON Web Token (JWT) created by an EBS. For signing requirements, see [Signing the JWT](https://dev.twitch.tv/docs/extensions/building.md#signing-the-jwt). The signed JWT must include the `role`, `user_id`, and `exp` fields (see [JWT Schema](https://dev.twitch.tv/docs/extensions/reference.md#jwt-schema)). Set the `role` field to *external* and the `user_id` field to the ID of the user that owns the extension.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that installed the extension on their channel.

### Request Body

- `extension_id` — String, **Required**. The ID of the extension to update.
- `extension_version` — String, **Required**. The version of the extension to update.
- `required_configuration` — String, **Required**. The required_configuration string to use with the extension.

### Response Codes

- **204 No Content** — Successfully updated the extension's required_configuration string.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *extension_id* field is required.
  - The *extension_version* field is required.
  - The *required_configuration* field is required.
- **401 Unauthorized**
  - The Authorization header is required and must specify a JWT token.
  - The JWT token is not valid.
  - The Client-Id header is required.
  - The user in the JWT's `user_id` field isn't allowed to manage the extension specified in the *extension_id* field.
- **404 Not Found**
  - The extension version specified in the *extension_version* field was not found.

### Request Example

```bash
curl -X PUT 'https://api.twitch.tv/helix/extensions/required_configuration?broadcaster_id=274637212' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"required_configuration":"RCS","extension_id":"uo6dggojyb8d6soh92zknwmi5ej1q2","extension_version":"0.0.1"}'
```
