# Charity

Manage charity campaign and donations made through Twitch's Charity Tool.

Source: https://dev.twitch.tv/docs/api/reference/charity/

## Contents {#contents}

2 entries on this page:

- [Get Charity Campaign](#get-charity-campaign)
- [Get Charity Campaign Donations](#get-charity-campaign-donations)

## Get Charity Campaign {#get-charity-campaign}

Gets information about the charity campaign that a broadcaster is running. For example, the
campaign's fundraising goal and the current amount of donations.

To receive events when progress is made towards the campaign's goal or the broadcaster changes the
fundraising goal, subscribe to the
[channel.charity_campaign.progress](https://dev.twitch.tv/docs/eventsub/reference/charity.md#channel-charity-campaign-progress)
subscription type.

### Endpoint

`GET https://api.twitch.tv/helix/charity/campaigns`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:charity** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's currently running a charity campaign. This ID must match the user ID in the access token.

### Response Body

- `data` — Object[]. A list that contains the charity campaign that the broadcaster is currently running. The list is empty if the broadcaster is not running a charity campaign; the campaign information is not available after the campaign ends.
  - `data.id` — String. An ID that identifies the charity campaign.
  - `data.broadcaster_id` — String. An ID that identifies the broadcaster that's running the campaign.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.charity_name` — String. The charity's name.
  - `data.charity_description` — String. A description of the charity.
  - `data.charity_logo` — String. A URL to an image of the charity's logo. The image's type is PNG and its size is 100px X 100px.
  - `data.charity_website` — String. A URL to the charity's website.
  - `data.current_amount` — Object. The current amount of donations that the campaign has received.
    - `data.current_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `data.current_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal
      places. Use this number to translate `value` from minor units to major units by
      using the formula:

      'value / 10^decimal_places'
    - `data.current_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
  - `data.target_amount` — Object. The campaign's fundraising goal. If the broadcaster has not defined a fundraising goal, `value` is 0.
    - `data.target_amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `data.target_amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal
      places. Use this number to translate `value` from minor units to major units by
      using the formula:

      'value / 10^decimal_places'
    - `data.target_amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.

### Response Codes

- **200 OK** — Successfully retrieved information about the broadcaster's active charity campaign.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:charity** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header must match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/charity/campaigns?broadcaster_id=123456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "123-abc-456-def",
      "broadcaster_id": "123456",
      "broadcaster_name": "SunnySideUp",
      "broadcaster_login": "sunnysideup",
      "charity_name": "Example name",
      "charity_description": "Example description",
      "charity_logo": "https://abc.cloudfront.net/ppgf/1000/100.png",
      "charity_website": "https://www.example.com",
      "current_amount": {
        "value": 86000,
        "decimal_places": 2,
        "currency": "USD"
      },
      "target_amount": {
        "value": 1500000,
        "decimal_places": 2,
        "currency": "USD"
      }
    }
  ]
}
```

## Get Charity Campaign Donations {#get-charity-campaign-donations}

Gets the list of donations that users have made to the broadcaster's active charity campaign.

To receive events as donations occur, subscribe to the
[channel.charity_campaign.donate](https://dev.twitch.tv/docs/eventsub/reference/charity.md#channel-charity-campaign-donate)
subscription type.

### Endpoint

`GET https://api.twitch.tv/helix/charity/donations`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:read:charity** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that's currently running a charity campaign. This ID must match the user ID in the access token.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 100. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object[]. A list that contains the donations that users have made to the broadcaster's charity campaign. The list is empty if the broadcaster is not currently running a charity campaign; the donation information is not available after the campaign ends.
  - `data.id` — String. An ID that identifies the donation. The ID is unique across campaigns.
  - `data.campaign_id` — String. An ID that identifies the charity campaign that the donation applies to.
  - `data.user_id` — String. An ID that identifies a user that donated money to the campaign.
  - `data.user_login` — String. The user's login name.
  - `data.user_name` — String. The user's display name.
  - `data.amount` — Object. An object that contains the amount of money that the user donated.
    - `data.amount.value` — Integer. The monetary amount. The amount is specified in the currency's minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, `value` is set to 550.
    - `data.amount.decimal_places` — Integer
      The number of decimal places used by the currency. For example, USD uses two decimal
      places. Use this number to translate `value` from minor units to major units by
      using the formula:

      `value / 10^decimal_places`
    - `data.amount.currency` — String. The ISO-4217 three-letter currency code that identifies the type of currency in `value`.
- `pagination` — Object. An object that contains the information used to page through the list of results. The object is empty if there are no more pages left to page through. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the list of donations that users contributed to the broadcaster's charity campaign.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The *first* query parameter is outside the allowed range of values.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID in the access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:read:charity** scope.
  - The access token is not valid.
  - The client ID specified in the Client-Id header must match the client ID specified in the access token.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/charity/donations?broadcaster_id=123456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "a1b2c3-aabb-4455-d1e2f3",
      "campaign_id": "123-abc-456-def",
      "user_id": "5678",
      "user_login": "cool_user",
      "user_name": "Cool_User",
      "amount": {
        "value": 500,
        "decimal_places": 2,
        "currency": "USD"
      }
    },
    {
      "id": "z1y2x3-ccdd-6677-d1e2f3",
      "campaign_id": "123-abc-456-def",
      "user_id": "8765",
      "user_login": "cool_user2",
      "user_name": "Cool_User2",
      "amount": {
        "value": 10000,
        "decimal_places": 2,
        "currency": "USD"
      }
    },
    . . .
  ],
  "pagination" : {
      "cursor" : "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"
  }
}
```
