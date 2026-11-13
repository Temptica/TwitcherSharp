# Schedule

Manage and get information related to a broadcaster's stream schedule.

Source: https://dev.twitch.tv/docs/api/reference/schedule/

## Contents {#contents}

6 entries on this page:

- [Get Channel Stream Schedule](#get-channel-stream-schedule)
- [Get Channel iCalendar](#get-channel-icalendar)
- [Create Channel Stream Schedule Segment](#create-channel-stream-schedule-segment)
- [Update Channel Stream Schedule Segment](#update-channel-stream-schedule-segment)
- [Delete Channel Stream Schedule Segment](#delete-channel-stream-schedule-segment)
- [Update Channel Stream Schedule](#update-channel-stream-schedule)

## Get Channel Stream Schedule {#get-channel-stream-schedule}

Gets the broadcaster's streaming schedule.
You can get the entire schedule or specific segments of the schedule. [Learn More](https://help.twitch.tv/s/article/channel-page-setup#Schedule)

### Endpoint

`GET https://api.twitch.tv/helix/schedule`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the streaming schedule you want to get.
- `id` — String
  The ID of the scheduled segment to return. To specify more than one segment, include the ID
  of each segment you want to get. For example, 'id=1234&id=5678'. You may specify a maximum
  of 100 IDs. The response omits IDs that don't match a segment.

  If you specify *id*, the request ignores the *first* and *after* query parameters, and the
  response doesn't include a cursor.
- `start_time` — String. The UTC date and time that identifies when in the broadcaster's schedule to start returning segments. The response includes the segments that end after this time, including a segment that's in progress. If not specified, the request uses the current UTC date and time. Specify the date and time in RFC3339 format (for example, '2022-09-01T00:00:00Z').
- `utc_offset` — Integer. Not supported.
- `first` — Integer. The maximum number of items to return per page in the response. The minimum page size is 1 item per page and the maximum is 25 items per page. The default is 20.
- `after` — String. The cursor used to get the next page of results. The **Pagination** object in the response contains the cursor's value. [Read More](https://dev.twitch.tv/docs/api/guide.md#pagination)

### Response Body

- `data` — Object. The broadcaster's streaming schedule.
  - `data.segments` — Object[]. The list of broadcasts in the broadcaster's streaming schedule.
    - `data.segments.id` — String. An ID that identifies this broadcast segment.
    - `data.segments.start_time` — String. The UTC date and time (in RFC3339 format) of when the broadcast starts.
    - `data.segments.end_time` — String, Nullable. The UTC date and time (in RFC3339 format) of when the broadcast ends. Is **null** if the segment doesn't have a duration.
    - `data.segments.title` — String. The broadcast segment's title.
    - `data.segments.canceled_until` — String. Indicates whether the broadcaster canceled this segment of a recurring broadcast. If the broadcaster canceled this segment, this field is set to the same value that's in the `end_time` field; otherwise, it's set to **null**.
    - `data.segments.category` — Object. The type of content that the broadcaster plans to stream or **null** if not specified.
      - `data.segments.category.id` — String. An ID that identifies the category that best represents the content that the broadcaster plans to stream. For example, the game's ID if the broadcaster will play a game or the Just Chatting ID if the broadcaster will host a talk show.
      - `data.segments.category.name` — String. The name of the category. For example, the game's title if the broadcaster will playing a game or Just Chatting if the broadcaster will host a talk show.
    - `data.segments.is_recurring` — Boolean. A Boolean value that determines whether the broadcast is part of a recurring series that streams at the same time each week or is a one-time broadcast. Is **true** if the broadcast is part of a recurring series.
  - `data.broadcaster_id` — String. The ID of the broadcaster that owns the broadcast schedule.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.vacation` — Object. The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled.
    - `data.vacation.start_time` — String. The UTC date and time (in RFC3339 format) of when the broadcaster's vacation starts.
    - `data.vacation.end_time` — String. The UTC date and time (in RFC3339 format) of when the broadcaster's vacation ends.
- `pagination` — Object. The information used to page through a list of results. The object is empty if there are no more pages left to page through. [Read more](https://dev.twitch.tv/docs/api/guide.md#pagination).
  - `pagination.cursor` — String. The cursor used to get the next page of results. Set the request's *after* query parameter to this value.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's streaming schedule.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The ID in the *id* query parameter is not valid.
  - The format of the date and time in the *start_time* query parameter is not valid.
  - The cursor specified in the *after* query parameter is not valid.
- **401 Unauthorized**
  - The Authorization header is required and must specify a valid app access token or user access token.
  - The access token is not valid.
  - The ID in the Client-Id header must match the Client ID in the access token.
- **404 Not Found**
  - The broadcaster has not created a streaming schedule.
  - The broadcaster's streaming schedule doesn't contain any broadcast segments.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/schedule?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": {
    "segments": [
      {
        "id": "eyJzZWdtZW50SUQiOiJlNGFjYzcyNC0zNzFmLTQwMmMtODFjYS0yM2FkYTc5NzU5ZDQiLCJpc29ZZWFyIjoyMDIxLCJpc29XZWVrIjoyNn0=",
        "start_time": "2021-07-01T18:00:00Z",
        "end_time": "2021-07-01T19:00:00Z",
        "title": "TwitchDev Monthly Update // July 1, 2021",
        "canceled_until": null,
        "category": {
            "id": "509670",
            "name": "Science & Technology"
        },
        "is_recurring": false
      },
      ...
    ],
    "broadcaster_id": "141981764",
    "broadcaster_name": "TwitchDev",
    "broadcaster_login": "twitchdev",
    "vacation": null
  },
  "pagination": {}
}
```

## Get Channel iCalendar {#get-channel-icalendar}

Gets the broadcaster's streaming schedule as an [iCalendar](https://datatracker.ietf.org/doc/html/rfc5545).

> **Note** The Client-Id and Authorization headers are not required.

### Endpoint

`GET https://api.twitch.tv/helix/schedule/icalendar`

### Authorization

No authorization required.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the streaming schedule you want to get.

### Response Codes

- **200 OK** — Successfully retrieved the broadcaster's schedule as an iCalendar.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/schedule/icalendar?broadcaster_id=141981764'
```

### Response Example

```
BEGIN:VCALENDAR
PRODID:-//twitch.tv//StreamSchedule//1.0
VERSION:2.0
CALSCALE:GREGORIAN
REFRESH-INTERVAL;VALUE=DURATION:PT6H
X-PUBLISHED-TTL:PT6H
NAME:TwitchDev
X-WR-CALNAME:TwitchDev
BEGIN:VEVENT
UID:e4acc724-371f-402c-81ca-23ada79759d4
DTSTAMP:20210323T040131Z
DTSTART;TZID=/America/New_York:20210701T140000
DTEND;TZID=/America/New_York:20210701T150000
SUMMARY:TwitchDev Monthly Update // July 1, 2021
DESCRIPTION:Science & Technology.
CATEGORIES:Science & Technology
END:VEVENT
END:VCALENDAR
```

## Create Channel Stream Schedule Segment {#create-channel-stream-schedule-segment}

Adds a single or recurring broadcast to the broadcaster's streaming schedule.

For information about scheduling broadcasts, see [Stream Schedule](https://help.twitch.tv/s/article/channel-page-setup#Schedule).

### Endpoint

`POST https://api.twitch.tv/helix/schedule/segment`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:schedule** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the schedule to add the broadcast segment to. This ID must match the user ID in the user access token.

### Request Body

- `start_time` — String, **Required**. The date and time that the broadcast segment starts. Specify the date and time in RFC3339 format (for example, 2021-07-01T18:00:00Z).
- `timezone` — String, **Required**. The time zone where the broadcast takes place. Specify the time zone using [IANA time zone database](https://www.iana.org/time-zones)format (for example, America/New_York).
- `duration` — Integer, **Required**. The length of time, in minutes, that the broadcast is scheduled to run. The duration must be in the range 30 through 1380 (23 hours).
- `is_recurring` — Boolean. A Boolean value that determines whether the broadcast recurs weekly. Is **true** if the broadcast recurs weekly. The default is **false**. Only partners and affiliates may add non-recurring broadcasts.
- `category_id` — String. The ID of the category that best represents the broadcast's content. To get the category ID, use the [Search Categories](https://dev.twitch.tv/docs/api/reference/search.md#search-categories) endpoint.
- `title` — String. The broadcast's title. The title may contain a maximum of 140 characters.

### Response Body

- `data` — Object. The broadcaster's streaming scheduled.
  - `data.segments` — Object[]. A list that contains the single broadcast segment that you added.
    - `data.segments.id` — String. An ID that identifies this broadcast segment.
    - `data.segments.start_time` — String. The UTC date and time (in RFC3339 format) of when the broadcast starts.
    - `data.segments.end_time` — String. The UTC date and time (in RFC3339 format) of when the broadcast ends.
    - `data.segments.title` — String. The broadcast segment's title.
    - `data.segments.canceled_until` — String. Indicates whether the broadcaster canceled this segment of a recurring broadcast. If the broadcaster canceled this segment, this field is set to the same value that's in the `end_time` field; otherwise, it's set to **null**.
    - `data.segments.category` — Object. The type of content that the broadcaster plans to stream or **null** if not specified.
      - `data.segments.category.id` — String. An ID that identifies the category that best represents the content that the broadcaster plans to stream. For example, the game's ID if the broadcaster will play a game or the Just Chatting ID if the broadcaster will host a talk show.
      - `data.segments.category.name` — String. The name of the category. For example, the game's title if the broadcaster will play a game or Just Chatting if the broadcaster will host a talk show.
    - `data.segments.is_recurring` — Boolean. A Boolean value that determines whether the broadcast is part of a recurring series that streams at the same time each week or is a one-time broadcast. Is **true** if the broadcast is part of a recurring series.
  - `data.broadcaster_id` — String. The ID of the broadcaster that owns the broadcast schedule.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.vacation` — Object. The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled.
    - `data.vacation.start_time` — String. The UTC date and time (in RFC3339 format) of when the broadcaster's vacation starts.
    - `data.vacation.end_time` — String. The UTC date and time (in RFC3339 format) of when the broadcaster's vacation ends.

### Response Codes

- **200 Ok** — Successfully added the broadcast segment.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The format of the date and time in the *start_time* field is not valid.
  - The date and time in the *start_time* field is in the past.
  - The value in the *timezone* field is not valid.
  - The value in the *duration* field is not valid.
  - The ID in the *category_id* field is not valid.
  - The string in the *title* field is too long.
  - The *title* field failed AutoMod checks.
  - The broadcast segment overlaps another segment in the broadcaster's schedule.
  - The broadcaster's schedule already contains the maximum of 365 segments.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:schedule** scope.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **403 Forbidden**
  - Only partners and affiliates may add non-recurring broadcast segments.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/schedule/segment?broadcaster_id=141981764' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"start_time":"2021-07-01T18:00:00Z","timezone":"America/New_York","is_recurring":false,"duration":60,"category_id":"509670","title":"TwitchDev Monthly Update // July 1, 2021"}'
```

### Response Example

```json
{
  "data": {
    "segments": [
      {
        "id": "eyJzZWdtZW50SUQiOiJlNGFjYzcyNC0zNzFmLTQwMmMtODFjYS0yM2FkYTc5NzU5ZDQiLCJpc29ZZWFyIjoyMDIxLCJpc29XZWVrIjoyNn0=",
        "start_time": "2021-07-01T18:00:00Z",
        "end_time": "2021-07-01T19:00:00Z",
        "title": "TwitchDev Monthly Update // July 1, 2021",
        "canceled_until": null,
        "category": {
          "id": "509670",
          "name": "Science & Technology"
        },
        "is_recurring": false
      }
    ],
    "broadcaster_id": "141981764",
    "broadcaster_name": "TwitchDev",
    "broadcaster_login": "twitchdev",
    "vacation": null
  }
}
```

## Update Channel Stream Schedule Segment {#update-channel-stream-schedule-segment}

Updates a scheduled broadcast segment.
For recurring segments, updating a segment's title, category, duration, and timezone, changes all
segments in the recurring schedule, not just the specified segment.

### Endpoint

`PATCH https://api.twitch.tv/helix/schedule/segment`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:schedule** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster who owns the broadcast segment to update. This ID must match the user ID in the user access token.
- `id` — String, **Required**. The ID of the broadcast segment to update.

### Request Body

- `start_time` — String
  The date and time that the broadcast segment starts. Specify the date and time in RFC3339
  format (for example, 2022-08-02T06:00:00Z).

  **NOTE**: Only partners and affiliates may update a broadcast's start time and only for
  non-recurring segments.
- `duration` — Integer. The length of time, in minutes, that the broadcast is scheduled to run. The duration must be in the range 30 through 1380 (23 hours).
- `category_id` — String. The ID of the category that best represents the broadcast's content. To get the category ID, use the [Search Categories](https://dev.twitch.tv/docs/api/reference/search.md#search-categories) endpoint. To remove the segment's category, set this field to an empty string.
- `title` — String. The broadcast's title. The title may contain a maximum of 140 characters.
- `is_canceled` — Boolean
  A Boolean value that indicates whether the broadcast is canceled. Set to **true** to cancel
  the segment.

  **NOTE**: For recurring segments, the API cancels the first segment after the current UTC
  date and time and not the specified segment (unless the specified segment is the next
  segment after the current UTC date and time).
- `timezone` — String. The time zone where the broadcast takes place. Specify the time zone using [IANA time zone database](https://www.iana.org/time-zones) format (for example, America/New_York).

### Response Body

- `data` — Object. The broadcaster's streaming scheduled.
  - `data.segments` — Object[]. A list that contains the single broadcast segment that you updated.
    - `data.segments.id` — String. An ID that identifies this broadcast segment.
    - `data.segments.start_time` — String. The UTC date and time (in RFC3339 format) of when the broadcast starts.
    - `data.segments.end_time` — String. The UTC date and time (in RFC3339 format) of when the broadcast ends.
    - `data.segments.title` — String. The broadcast segment's title.
    - `data.segments.canceled_until` — String. Indicates whether the broadcaster canceled this segment of a recurring broadcast. If the broadcaster canceled this segment, this field is set to the same value that's in the `end_time` field; otherwise, it's set to **null**.
    - `data.segments.category` — Object. The type of content that the broadcaster plans to stream or **null** if not specified.
      - `data.segments.category.id` — String. An ID that identifies the category that best represents the content that the broadcaster plans to stream. For example, the game's ID if the broadcaster will play a game or the Just Chatting ID if the broadcaster will host a talk show.
      - `data.segments.category.name` — String. The name of the category. For example, the game's title if the broadcaster will play a game or Just Chatting if the broadcaster will host a talk show.
    - `data.segments.is_recurring` — Boolean. A Boolean value that determines whether the broadcast is part of a recurring series that streams at the same time each week or is a one-time broadcast. Is **true** if the broadcast is part of a recurring series.
  - `data.broadcaster_id` — String. The ID of the broadcaster that owns the broadcast schedule.
  - `data.broadcaster_name` — String. The broadcaster's display name.
  - `data.broadcaster_login` — String. The broadcaster's login name.
  - `data.vacation` — Object. The dates when the broadcaster is on vacation and not streaming. Is set to **null** if vacation mode is not enabled.
    - `data.vacation.start_time` — String. The UTC date and time (in RFC3339 format) of when the broadcaster's vacation starts.
    - `data.vacation.end_time` — String. The UTC date and time (in RFC3339 format) of when the broadcaster's vacation ends.

### Response Codes

- **200 OK** — Successfully updated the broadcast segment.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *id* query parameter is required.
  - The ID in the *id* query parameter is not valid.
  - The request body doesn't contain any fields to update.
  - The format of the date and time in the *start_time* field is not valid.
  - The date and time in the *start_time* field is in the past.
  - The *start_time* field may not be set for a recurring segment.
  - The *start_time* field may not be set for a non-recurring segment that has already started.
  - The value in the *timezone* field is not valid.
  - The value in the *duration* field is not valid.
  - The ID in the *category_id* field is not valid.
  - The string in the *title* field is too long.
  - The *title* field failed AutoMod checks.
  - The updated broadcast segment overlaps another segment in the broadcaster's schedule.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:schedule** scope.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **404 Not Found**
  - The specified broadcast segment was not found.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/schedule/segment?broadcaster_id=141981764&id=eyJzZWdtZW50SUQiOiJlNGFjYzcyNC0zNzFmLTQwMmMtODFjYS0yM2FkYTc5NzU5ZDQiLCJpc29ZZWFyIjoyMDIxLCJpc29XZWVrIjoyNn0' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"duration":120}'
```

### Response Example

```json
{
  "data": {
    "segments": [
      {
        "id": "eyJzZWdtZW50SUQiOiJlNGFjYzcyNC0zNzFmLTQwMmMtODFjYS0yM2FkYTc5NzU5ZDQiLCJpc29ZZWFyIjoyMDIxLCJpc29XZWVrIjoyNn0=",
        "start_time": "2021-07-01T18:00:00Z",
        "end_time": "2021-07-01T20:00:00Z",
        "title": "TwitchDev Monthly Update // July 1, 2021",
        "canceled_until": null,
        "category": {
          "id": "509670",
          "name": "Science & Technology"
        },
        "is_recurring": false
      }
    ],
    "broadcaster_id": "141981764",
    "broadcaster_name": "TwitchDev",
    "broadcaster_login": "twitchdev",
    "vacation": null
  }
}
```

## Delete Channel Stream Schedule Segment {#delete-channel-stream-schedule-segment}

Removes a broadcast segment from the broadcaster's streaming schedule.

> **Note** For recurring segments, removing a segment removes all segments in the recurring schedule.

### Endpoint

`DELETE https://api.twitch.tv/helix/schedule/segment`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:schedule** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster that owns the streaming schedule. This ID must match the user ID in the user access token.
- `id` — String, **Required**. The ID of the broadcast segment to remove.

### Response Codes

- **204 No Content** — Successfully removed the broadcast segment.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *id* query parameter is required.
  - The ID in the *id* query parameter is not valid.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:schedule** scope.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the OAuth token.
- **404 Not Found**
  - The broadcaster has not created a streaming schedule.
  - The specified broadcast segment was not found.

### Request Example

```bash
curl -X DELETE 'https://api.twitch.tv/helix/schedule/segment?broadcaster_id=141981764&id=eyJzZWdtZW50SUQiOiI4Y2EwN2E2NC0xYTZkLTRjYWItYWE5Ni0xNjIyYzNjYWUzZDkiLCJpc29ZZWFyIjoyMDIxLCJpc29XZWVrIjoyMX0' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

## Update Channel Stream Schedule {#update-channel-stream-schedule}

Updates the broadcaster's schedule settings, such as scheduling a vacation.

### Endpoint

`PATCH https://api.twitch.tv/helix/schedule/settings`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **channel:manage:schedule** scope.

### Query Parameters

- `broadcaster_id` — String, **Required**. The ID of the broadcaster whose schedule settings you want to update. The ID must match the user ID in the user access token.
- `is_vacation_enabled` — Boolean. A Boolean value that indicates whether the broadcaster has scheduled a vacation. Set to **true** to enable Vacation Mode and add vacation dates, or **false** to cancel a previously scheduled vacation. If you omit this parameter, the request ignores the other vacation parameters and doesn't change the schedule settings.
- `vacation_start_time` — String. The UTC date and time of when the broadcaster's vacation starts. Specify the date and time in RFC3339 format (for example, 2021-05-16T00:00:00Z). Required if *is_vacation_enabled* is **true**.
- `vacation_end_time` — String. The UTC date and time of when the broadcaster's vacation ends. Specify the date and time in RFC3339 format (for example, 2021-05-30T23:59:59Z). The vacation may end no more than 5 years in the future. Required if *is_vacation_enabled* is **true**.
- `timezone` — String. The time zone that the broadcaster broadcasts from. Specify the time zone using [IANA time zone database](https://www.iana.org/time-zones) format (for example, America/New_York). Required if *is_vacation_enabled* is **true**.

### Response Codes

- **204 No Content** — Successfully updated the broadcaster's schedule settings.
- **400 Bad Request**
  - The *broadcaster_id* query parameter is required.
  - The ID in the *broadcaster_id* query parameter is not valid.
  - The *vacation_start_time* and *vacation_end_time* query parameters are required if *is_vacation_enabled* is **true**.
  - The *timezone* query parameter is required if *is_vacation_enabled* is **true**.
  - The format of the string in *vacation_start_time* is not valid.
  - The format of the string in *vacation_end_time* is not valid.
  - The date in *vacation_end_time* must be later than the date in *vacation_start_time*.
  - The date in *vacation_end_time* is more than 5 years in the future.
  - The time zone in *timezone* is not valid.
- **401 Unauthorized**
  - The ID in the *broadcaster_id* query parameter must match the user ID in the user access token.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **channel:manage:schedule** scope.
  - The access token is not valid.
  - The ID in the Client-Id header must match the client ID in the access token.
- **404 Not Found**
  - The broadcaster's schedule was not found.

### Request Example

```bash
curl -X PATCH 'https://api.twitch.tv/helix/schedule/settings?broadcaster_id=141981764&is_vacation_enabled=true&vacation_start_time=2021-05-16T00%3A00%3A00Z&vacation_end_time=2021-05-23T00%3A00%3A00Z&timezone=America%2FNew_York' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```
