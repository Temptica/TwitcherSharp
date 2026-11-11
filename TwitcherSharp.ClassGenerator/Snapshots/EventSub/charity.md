# Charity

Events raised as a broadcaster's charity campaign starts, receives donations, progresses and stops.

Source: https://dev.twitch.tv/docs/eventsub/reference/charity/

## Contents {#contents}

4 entries on this page:

- [Charity Donation](#channel-charity-campaign-donate)
- [Charity Campaign Progress](#channel-charity-campaign-progress)
- [Charity Campaign Start](#channel-charity-campaign-start)
- [Charity Campaign Stop](#channel-charity-campaign-stop)

## Charity Donation {#channel-charity-campaign-donate}

Sends a notification when a user donates to the broadcaster's charity campaign.

### Subscription

- Type: `channel.charity_campaign.donate`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:charity** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:charity** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.charity_campaign.donate**.
- `version` — String, **Required**. The subscription type version: `1`
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when users donate to their campaign.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending event notifications.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when users donate to their campaign.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.id` — String. An ID that identifies the donation. The ID is unique across campaigns.
  - `event.campaign_id` — String. An ID that identifies the charity campaign.
  - `event.broadcaster_user_id` — String. An ID that identifies the broadcaster that's running the campaign.
  - `event.broadcaster_user_login` — String. The broadcaster's login name.
  - `event.broadcaster_user_name` — String. The broadcaster's display name.
  - `event.user_id` — String. An ID that identifies the user that donated to the campaign.
  - `event.user_login` — String. The user's login name.
  - `event.user_name` — String. The user's display name.
  - `event.charity_name` — String. The charity's name.
  - `event.charity_description` — String. A description of the charity.
  - `event.charity_logo` — String. A URL to an image of the charity's logo. The image's type is PNG and its size is 100px X 100px.
  - `event.charity_website` — String. A URL to the charity's website.
  - `event.amount` — Object. An object that contains the amount of money that the user donated.
    - `event.amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.charity_campaign.donate",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "123456"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.charity_campaign.donate",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "123456"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.123Z"
  },
  "event": {
    "id": "a1b2c3-aabb-4455-d1e2f3",
    "campaign_id": "123-abc-456-def",
    "broadcaster_user_id": "123456",
    "broadcaster_user_name": "SunnySideUp",
    "broadcaster_user_login": "sunnysideup",
    "user_id": "654321",
    "user_login": "generoususer1",
    "user_name": "GenerousUser1",
    "charity_name": "Example name",
    "charity_description": "Example description",
    "charity_logo": "https://abc.cloudfront.net/ppgf/1000/100.png",
    "charity_website": "https://www.example.com",
    "amount": {
      "value": 10000,
      "decimal_places": 2,
      "currency": "USD"
    }
  }
}
```

## Charity Campaign Progress {#channel-charity-campaign-progress}

Sends notifications when progress is made towards the campaign's goal or when the broadcaster changes the fundraising goal.
It's possible to receive this event before the [Start](#channelcharity_campaignstart) event.
To get donation information, subscribe to the [channel.charity_campaign.donate](#channelcharity_campaigndonate) event.

### Subscription

- Type: `channel.charity_campaign.progress`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:charity** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:charity** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.charity_campaign.progress**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when their campaign makes progress or is updated.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending event notifications.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when their campaign makes progress or is updated.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.id` — String. An ID that identifies the charity campaign.
  - `event.broadcaster_id` — String. An ID that identifies the broadcaster that's running the campaign.
  - `event.broadcaster_login` — String. The broadcaster's login name.
  - `event.broadcaster_name` — String. The broadcaster's display name.
  - `event.charity_name` — String. The charity's name.
  - `event.charity_description` — String. A description of the charity.
  - `event.charity_logo` — String. A URL to an image of the charity's logo. The image's type is PNG and its size is 100px X 100px.
  - `event.charity_website` — String. A URL to the charity's website.
  - `event.current_amount` — Object. An object that contains the current amount of donations that the campaign has received.
    - `event.current_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.current_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.current_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
  - `event.target_amount` — Object. An object that contains the campaign's target fundraising goal.
    - `event.target_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.target_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.target_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.charity_campaign.progress",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "123456"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.charity_campaign.progress",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "123456"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.12339824Z"
  },
  "event": {
    "id": "123-abc-456-def",
    "broadcaster_id": "123456",
    "broadcaster_name": "SunnySideUp",
    "broadcaster_login": "sunnysideup",
    "charity_name": "Example name",
    "charity_description": "Example description",
    "charity_logo": "https://abc.cloudfront.net/ppgf/1000/100.png",
    "charity_website": "https://www.example.com",
    "current_amount": {
      "value": 260000,
      "decimal_places": 2,
      "currency": "USD"
    },
    "target_amount": {
      "value": 1500000,
      "decimal_places": 2,
      "currency": "USD"
    }
  }
}
```

## Charity Campaign Start {#channel-charity-campaign-start}

Sends a notification when the broadcaster starts a charity campaign.
It's possible to receive this event after the [Progress](#channelcharity_campaignprogress) event.

### Subscription

- Type: `channel.charity_campaign.start`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:charity** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:charity** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.charity_campaign.start**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when they start a charity campaign.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending event notifications.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when they start a charity campaign.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.id` — String. An ID that identifies the charity campaign.
  - `event.broadcaster_id` — String. An ID that identifies the broadcaster that's running the campaign.
  - `event.broadcaster_login` — String. The broadcaster's login name.
  - `event.broadcaster_name` — String. The broadcaster's display name.
  - `event.charity_name` — String. The charity's name.
  - `event.charity_description` — String. A description of the charity.
  - `event.charity_logo` — String. A URL to an image of the charity's logo. The image's type is PNG and its size is 100px X 100px.
  - `event.charity_website` — String. A URL to the charity's website.
  - `event.current_amount` — Object. An object that contains the current amount of donations that the campaign has received.
    - `event.current_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.current_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.current_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
  - `event.target_amount` — Object. An object that contains the campaign's target fundraising goal.
    - `event.target_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.target_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.target_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
  - `event.started_at` — String. The UTC timestamp (in RFC3339 format) of when the broadcaster started the campaign.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.charity_campaign.start",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "123456"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.charity_campaign.start",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "123456"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.12339824Z"
  },
  "event": {
    "id": "123-abc-456-def",
    "broadcaster_id": "123456",
    "broadcaster_name": "SunnySideUp",
    "broadcaster_login": "sunnysideup",
    "charity_name": "Example name",
    "charity_description": "Example description",
    "charity_logo": "https://abc.cloudfront.net/ppgf/1000/100.png",
    "charity_website": "https://www.example.com",
    "current_amount": {
      "value": 0,
      "decimal_places": 2,
      "currency": "USD"
    },
    "target_amount": {
      "value": 1500000,
      "decimal_places": 2,
      "currency": "USD"
    },
    "started_at": "2022-07-26T17:00:03.17106713Z"
  }
}
```

## Charity Campaign Stop {#channel-charity-campaign-stop}

Sends a notification when the broadcaster stops a charity campaign.

### Subscription

- Type: `channel.charity_campaign.stop`
- Version: `1`
- Transports: Webhook, WebSocket, Conduit

### Endpoint

`POST https://api.twitch.tv/helix/eventsub/subscriptions`

Webhook and Conduit subscriptions take an app access token; WebSocket subscriptions take a user access token. For the full request, see [Create EventSub Subscription](https://dev.twitch.tv/docs/api/reference/eventsub.md#create-eventsub-subscription).

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:charity** scope.
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).
  The application, through prior authorization, must have been granted:
  - The **channel:read:charity** scope for the user represented by the *broadcaster_user_id* event condition.

### Subscription Request Body

- `type` — String, **Required**. The event you want to receive notifications about. Must be set to **channel.charity_campaign.stop**.
- `version` — String, **Required**. The definition of the subscription request to use. Must be set to **1**.
- `condition` — Object, **Required**. An object that contains subscription-specific parameters.
  - `condition.broadcaster_user_id` — String, **Required**. The ID of the broadcaster that you want to receive notifications about when they stop a charity campaign.
- `transport` — Object, **Required**. The transport details that you want Twitch to use when sending event notifications.
  - `transport.method` — String, **Required**. The transport method for EventSub.
    Possible values:
    - `webhook`
    - `websocket`
    - `conduit`
  - `transport.callback` — String
    The callback URL where notifications are sent. The URL must use the HTTPS protocol and
    port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

    Specify this field only if *method* is set to **webhook**.

    **NOTE**: Redirects are not followed.
  - `transport.secret` — String
    The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
    10 characters long and a maximum of 100 characters long. For information about how the secret is
    used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

    Specify this field only if the *method* is set to **webhook**.
  - `transport.session_id` — String
    An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
    the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

    Specify this field only if the *method* is set to **websocket**.
  - `transport.conduit_id` — String
    An ID that identifies the conduit to send this notification to. When you create a conduit, the server
    returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

    Specify this field only if the *method* is set to **conduit**.

### Event Payload

- `subscription` — Object. Metadata about the subscription.
  - `subscription.id` — String. The Subscription ID of the subscription.
  - `subscription.type` — String. The notification's subscription type.
  - `subscription.version` — String. The version of the subscription.
  - `subscription.status` — String. The status of the subscription.
  - `subscription.cost` — Integer. How much the subscription counts against your limit. See [Subscription Limits](https://dev.twitch.tv/docs/eventsub/manage-subscriptions.md#subscription-limits) for more information.
  - `subscription.condition` — Object. Subscription-specific parameters.
    - `subscription.condition.broadcaster_user_id` — String. The ID of the broadcaster that you want to receive notifications about when they stop a charity campaign.
  - `subscription.created_at` — String. The time the notification was created.
  - `subscription.transport` — Object. Transport-specific parameters.
    - `subscription.transport.method` — String. The transport method for EventSub.
      Possible values:
      - `webhook`
      - `websocket`
      - `conduit`
    - `subscription.transport.callback` — String
      The callback URL where notifications are sent. The URL must use the HTTPS protocol and
      port 443. [See Processing an Event](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#processing-an-event).

      Specify this field only if *method* is set to **webhook**.

      **NOTE**: Redirects are not followed.
    - `subscription.transport.secret` — String
      The secret used to verify the signature. The secret must be an ASCII string that's a minimum of
      10 characters long and a maximum of 100 characters long. For information about how the secret is
      used, see [Verifying the event message](https://dev.twitch.tv/docs/eventsub/handling-webhook-events.md#verifying-the-event-message).

      Specify this field only if the *method* is set to **webhook**.
    - `subscription.transport.session_id` — String
      An ID that identifies the WebSocket to send notifications to. When you connect to EventSub using WebSockets,
      the server returns the ID in the [Welcome message](https://dev.twitch.tv/docs/eventsub/handling-websocket-events.md#welcome-message).

      Specify this field only if the *method* is set to **websocket**.
    - `subscription.transport.conduit_id` — String
      An ID that identifies the conduit to send this notification to. When you create a conduit, the server
      returns the ID in the [API response](https://dev.twitch.tv/docs/api/reference/conduits.md#create-conduits).

      Specify this field only if the *method* is set to **conduit**.
- `event` — Object. The event information.
  - `event.id` — String. An ID that identifies the charity campaign.
  - `event.broadcaster_id` — String. An ID that identifies the broadcaster that ran the campaign.
  - `event.broadcaster_login` — String. The broadcaster's login name.
  - `event.broadcaster_name` — String. The broadcaster's display name.
  - `event.charity_name` — String. The charity's name.
  - `event.charity_description` — String. A description of the charity.
  - `event.charity_logo` — String. A URL to an image of the charity's logo. The image's type is PNG and its size is 100px X 100px.
  - `event.charity_website` — String. A URL to the charity's website.
  - `event.current_amount` — Object. An object that contains the final amount of donations that the campaign received.
    - `event.current_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.current_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.current_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
  - `event.target_amount` — Object. An object that contains the campaign's target fundraising goal.
    - `event.target_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `event.target_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate `value` from minor units to major units by using the formula:

      `value / 10^decimal_places`
    - `event.target_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
  - `event.stopped_at` — String. The UTC timestamp (in RFC3339 format) of when the broadcaster stopped the campaign.

### Subscription Request Body Example (Webhook)

```json
{
  "type": "channel.charity_campaign.stop",
  "version": "1",
  "condition": {
    "broadcaster_user_id": "123456"
  },
  "transport": {
    "method": "webhook",
    "callback": "https://example.com/webhooks/callback",
    "secret": "s3cRe7"
  }
}
```

### Event Payload Example

```json
{
  "subscription": {
    "id": "f1c2a387-161a-49f9-a165-0f21d7a4e1c4",
    "type": "channel.charity_campaign.stop",
    "version": "1",
    "status": "enabled",
    "cost": 0,
    "condition": {
      "broadcaster_user_id": "123456"
    },
    "transport": {
      "method": "webhook",
      "callback": "https://example.com/webhooks/callback"
    },
    "created_at": "2022-07-25T10:11:12.12339824Z"
  },
  "event": {
    "id": "123-abc-456-def",
    "broadcaster_id": "123456",
    "broadcaster_name": "SunnySideUp",
    "broadcaster_login": "sunnysideup",
    "charity_name": "Example name",
    "charity_description": "Example description",
    "charity_logo": "https://abc.cloudfront.net/ppgf/1000/100.png",
    "charity_website": "https://www.example.com",
    "current_amount": {
      "value": 1450000,
      "decimal_places": 2,
      "currency": "USD"
    },
    "target_amount": {
      "value": 1500000,
      "decimal_places": 2,
      "currency": "USD"
    },
    "stopped_at": "2022-07-26T22:00:03.17106713Z"
  }
}
```
