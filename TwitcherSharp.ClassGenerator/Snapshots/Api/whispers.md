# Whispers

Send whispers on behalf of a Twitch user.

Source: https://dev.twitch.tv/docs/api/reference/whispers/

## Send Whisper {#send-whisper}

NOTE: The user sending the whisper must have a verified phone number (see the **Phone Number**
setting in your [Security and Privacy](https://www.twitch.tv/settings/security) settings).

NOTE: The API may silently drop whispers that it suspects of violating Twitch policies. (The API
does not indicate that it dropped the whisper; it returns a 204 status code as if it succeeded.)

**Rate Limits**: You may whisper to a maximum of 40 unique recipients per day. Within the per day
limit, you may whisper a maximum of 3 whispers per second and a maximum of 100 whispers per
minute.

### Endpoint

`POST https://api.twitch.tv/helix/whispers`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens) that includes the **user:manage:whispers** scope.

### Query Parameters

- `from_user_id` — String, **Required**. The ID of the user sending the whisper. This user must have a verified phone number. This ID must match the user ID in the user access token.
- `to_user_id` — String, **Required**. The ID of the user to receive the whisper.

### Request Body

- `message` — String, **Required**
  The whisper message to send. The message must not be empty.
  The maximum message lengths are:

  - 500 characters if the user you're sending the message to hasn't whispered you before.
  - 10,000 characters if the user you're sending the message to has whispered you before.

  Messages that exceed the maximum length are truncated.

### Response Codes

- **204 No Content** — Successfully sent the whisper message or the message was silently dropped.
- **400 Bad Request**
  - The ID in the *from_user_id* and *to_user_id* query parameters must be different.
  - The *message* field must not contain an empty string.
  - The message contains words that Twitch's moderation settings block.
  - The ID in the *from_user_id* query parameter is not valid.
  - The ID in the *to_user_id* query parameter is not valid.
- **401 Unauthorized**
  - The user in the *from_user_id* query parameter must have a verified phone number.
  - The Authorization header is required and must contain a user access token.
  - The user access token must include the **user:manage:whispers** scope.
  - The access token is not valid.
  - This ID in *from_user_id* must match the user ID in the user access token.
  - The client ID specified in the Client-Id header does not match the client ID specified in the access token.
- **403 Forbidden**
  - The user that you're sending the whisper to doesn't accept whispers from the sender. For example, the user turned off whispers, blocked the sender, or blocks whispers from strangers (see the **Block Whispers from Strangers** setting in your [Security and Privacy](https://www.twitch.tv/settings/security) settings).
  - Suspended users may not send whisper messages.
  - The account that's sending the message doesn't allow sending whispers.
  - The sender is restricted from sending whispers.
- **404 Not Found**
  - The ID in *to_user_id* was not found.
  - Whisper messages may not be sent to suspended users.
  - The ID in *from_user_id* was not found.
- **429 Too Many Requests**
  - The sending user exceeded the number of whisper requests that they may make. See Rate Limits for this endpoint above.

### Request Example

```bash
curl -X POST 'https://api.twitch.tv/helix/whispers?from_user_id=123&to_user_id=456' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID' \
  -H 'Content-Type: application/json' \
  -d '{"message":"hello"}'
```
