# Analytics

Get access to analytics on your Extension and games on Twitch.

Source: https://dev.twitch.tv/docs/api/reference/analytics/

## Contents {#contents}

2 entries on this page:

- [Get Extension Analytics](#get-extension-analytics)
- [Get Game Analytics](#get-game-analytics)

## Get Extension Analytics {#get-extension-analytics}

Gets an analytics report for one or more extensions. The response contains the URLs used to download the reports (CSV files). [Learn More](https://dev.twitch.tv/docs/insights.md)

### Endpoint

`GET https://api.twitch.tv/helix/analytics/extensions`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **analytics:read:extensions** scope.

### Query Parameters

- `extension_id` — String. The extension's client ID. If specified, the response contains a report for the specified extension. If not specified, the response includes a report for each extension that the authenticated user owns.
- `type` — String. The type of analytics report to get.
  Possible values:
  - `overview_v2`
- `started_at` — String
  The reporting window's start date, in RFC3339 format. Set the time portion to zeroes (for
  example, `2021-10-22T00:00:00Z`).

  The start date must be on or after January 31, 2018. If you specify an earlier date, the API
  ignores it and uses January 31, 2018. If you specify a start date, you must specify an end
  date. If you don't specify a start and end date, the report includes all available data
  since January 31, 2018.

  The report contains one row of data for each day in the reporting window.
- `ended_at` — String
  The reporting window's end date, in RFC3339 format. Set the time portion to zeroes (for
  example, `2021-10-27T00:00:00Z`). The report is inclusive of the end date.

  Specify an end date only if you provide a start date. Because it can take up to two days for
  the data to be available, you should specify an end date that's earlier than today minus one
  to two days. If you specify an end date that's later than yesterday (UTC), the API ignores
  it and uses yesterday's date.
- `first` — Integer
  The maximum number of report URLs to return per page in the response. The minimum page size
  is 1 URL per page and the maximum is 100 URLs per page. The default is 20.

  **NOTE**: While you may specify a maximum value of 100, the response will contain at most 20
  URLs per page.
- `after` — String
  The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

  This parameter is ignored if the *extension_id* parameter is set, but the cursor must still
  be valid.

### Response Body

- `data` — Object[]
  A list of reports. The reports are returned in no particular order; however, the data within
  each report is in ascending order by date (newest first). The report contains one row of
  data per day of the reporting window; the report contains rows for only those days that the
  extension was used. The array is empty if there are no reports.

  Extensions that have no data in the reporting window are left out, so a page may contain
  fewer than *first* reports, or none, and still contain a cursor.
  - `data.extension_id` — String. An ID that identifies the extension that the report was generated for.
  - `data.URL` — String. The URL that you use to download the report. The URL is valid for 5 minutes.
  - `data.type` — String. The type of report.
  - `data.date_range` — Object. The earliest and latest dates that the report contains data for, in RFC3339 format. These dates can differ from the reporting window that you requested.
    - `data.date_range.started_at` — String. The earliest date that the report contains data for.
    - `data.date_range.ended_at` — String. The latest date that the report contains data for.
- `pagination` — Object. Contains the information used to page through the list of results. The response doesn't include this object if there are no more pages left to page through or if you specify the *extension_id* query parameter. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's analytics reports.
- **400 Bad Request**
  - The start and end dates are optional but if you specify one, you must specify the other.
  - The end date must be equal to or later than the start date.
  - The *started_at* and *ended_at* query parameters must be in RFC3339 format.
  - The cursor specified in the *after* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **analytics:read:extensions** scope.
  - The OAuth token is not valid.
  - The Client-Id header is required.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **403 Forbidden**
  - The extension specified in the *extension_id* query parameter was not found.
  - The user in the access token doesn't have permission to view the analytics of the extension specified in the *extension_id* query parameter.
- **404 Not Found**
  - The extension specified in the *extension_id* query parameter has no analytics data for the reporting window.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/analytics/extensions' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
   "data": [
      {
         "extension_id": "efgh",
         "URL": "https://twitch-piper-reports.s3-us-west-2.amazonaws.com/dynamic/LoL%20ADC...",
         "type": "overview_v2",
         "date_range": {
            "started_at": "2018-03-01T00:00:00Z",
            "ended_at": "2018-06-01T00:00:00Z"
         }
      },
      ...
   ],
   "pagination": {"cursor": "eyJiIjpudWxsLCJhIjp7Ik9mZnNldCI6NX19"}
}
```

## Get Game Analytics {#get-game-analytics}

Gets an analytics report for one or more games. The response contains the URLs used to download the reports (CSV files). [Learn more](https://dev.twitch.tv/docs/insights.md)

### Endpoint

`GET https://api.twitch.tv/helix/analytics/games`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **analytics:read:games** scope.

### Query Parameters

- `game_id` — String. The game's ID, which is numeric. If specified, the response contains a report for the specified game. If not specified, the response includes a report for each of the authenticated user's games.
- `type` — String. The type of analytics report to get.
  Possible values:
  - `overview_v2`
- `started_at` — String
  The reporting window's start date, in RFC3339 format. Set the time portion to zeroes (for
  example, `2021-10-22T00:00:00Z`). If you specify a start date, you must specify an end date.

  The start date must be within one year of today's date. If you specify an earlier date, the
  API ignores it and uses a date that's one year prior to today's date. If you don't specify a
  start and end date, the report includes all available data for the last 365 days from today.

  The report contains one row of data for each day in the reporting window.
- `ended_at` — String
  The reporting window's end date, in RFC3339 format. Set the time portion to zeroes (for
  example, `2021-10-22T00:00:00Z`). The report is inclusive of the end date.

  Specify an end date only if you provide a start date. Because it can take up to two days for
  the data to be available, you should specify an end date that's earlier than today minus one
  to two days. If you specify an end date that's later than yesterday (UTC), the API ignores
  it and uses yesterday's date.
- `first` — Integer
  The maximum number of report URLs to return per page in the response. The minimum page size
  is 1 URL per page and the maximum is 100 URLs per page. The default is 20.

  **NOTE**: While you may specify a maximum value of 100, the response will contain at most 20
  URLs per page.
- `after` — String
  The cursor used to get the next page of results. The **Pagination** object in the response
  contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

  This parameter is ignored if *game_id* parameter is set, but the cursor must still be valid.

### Response Body

- `data` — Object[]
  A list of reports. The reports are returned in no particular order; however, the data within
  each report is in ascending order by date (newest first). The report contains one row of
  data per day of the reporting window; the report contains rows for only those days that the
  game was used. A report is available only if the game was broadcast for at least 5 hours
  over the reporting period. The array is empty if there are no reports.

  Games that have no data in the reporting window, or whose analytics aren't available, are
  left out, so a page may contain fewer than *first* reports, or none, and still contain a
  cursor.
  - `data.game_id` — String. An ID that identifies the game that the report was generated for.
  - `data.URL` — String. The URL that you use to download the report. The URL is valid for 5 minutes.
  - `data.type` — String. The type of report.
  - `data.date_range` — Object. The earliest and latest dates that the report contains data for, in RFC3339 format. These dates can differ from the reporting window that you requested.
    - `data.date_range.started_at` — String. The earliest date that the report contains data for.
    - `data.date_range.ended_at` — String. The latest date that the report contains data for.
- `pagination` — Object. Contains the information used to page through the list of results. The response doesn't include this object if there are no more pages left to page through or if you specify the *game_id* query parameter. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)
  - `pagination.cursor` — String. The cursor used to get the next page of results. Use the cursor to set the request's *after* query parameter.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's analytics reports.
- **400 Bad Request**
  - The start and end dates are optional but if you specify one, you must specify the other.
  - The end date must be equal to or later than the start date.
  - The *started_at* and *ended_at* query parameters must be in RFC3339 format.
  - The ID in the *game_id* query parameter must be numeric.
  - The cursor specified in the *after* query parameter is not valid.
  - The *first* query parameter is outside the allowed range of values.
- **401 Unauthorized**
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **analytics:read:games** scope.
  - The OAuth token is not valid.
  - The Client-Id header is required.
  - The client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.
- **403 Forbidden**
  - The user in the access token doesn't have permission to view the analytics of the game specified in the *game_id* query parameter.
  - Analytics aren't available for the game specified in the *game_id* query parameter.
- **404 Not Found**
  - The game specified in the *game_id* query parameter was not found.
  - The game specified in the *game_id* query parameter has no analytics data for the reporting window.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/analytics/games?game_id=493057&started_at=2018-01-01T00%3A00%3A00Z&ended_at=2018-03-01T00%3A00%3A00Z' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "game_id": "493057",
      "URL": "https://twitch-piper-reports.s3-us-west-2.amazonaws.com/games/66170/overview/15183...",
      "type": "overview_v2",
      "date_range": {
        "started_at": "2018-01-01T00:00:00Z",
        "ended_at": "2018-03-01T00:00:00Z"
      }
    }
  ]
}
```
