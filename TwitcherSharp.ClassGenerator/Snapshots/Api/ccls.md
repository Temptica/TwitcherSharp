# CCLs

Get the Content Classification Labels a broadcaster can apply to their channel.

Source: https://dev.twitch.tv/docs/api/reference/ccls/

## Get Content Classification Labels {#get-content-classification-labels}

Gets information about Twitch content classification labels.

### Endpoint

`GET https://api.twitch.tv/helix/content_classification_labels`

### Authorization

Requires one of the following:

- A [user access token](https://dev.twitch.tv/docs/authentication.md#user-access-tokens).
- An [app access token](https://dev.twitch.tv/docs/authentication.md#app-access-tokens).

### Query Parameters

- `locale` — String
  Locale for the Content Classification Labels. You may specify a maximum of 1 locale.
  Default: '"en-US"'

  Supported locales: '"ar-SA", "bg-BG", "cs-CZ", "da-DK", "de-DE", "el-GR", "en-GB", "en-US",
  "es-ES", "es-MX", "fi-FI", "fr-FR", "hu-HU", "it-IT", "ja-JP", "ko-KR", "nl-NL", "no-NO",
  "pl-PL", "pt-BR", "pt-PT", "ro-RO", "ru-RU", "sk-SK", "sv-SE", "th-TH", "tr-TR", "uk-UA",
  "vi-VN", "zh-CN", "zh-TW"'

  If the locale isn't supported, the closest supported locale is used, or en-US if none is
  close.

### Response Body

- `data` — Object[]. A list that contains information about the available content classification labels.
  - `data.id` — String. Unique identifier for the CCL.
  - `data.description` — String. Localized description of the CCL.
  - `data.name` — String. Localized name of the CCL.

### Request Example

```bash
curl -X GET 'https://api.twitch.tv/helix/content_classification_labels' \
  -H 'Authorization: Bearer YOUR_ACCESS_TOKEN' \
  -H 'Client-Id: YOUR_CLIENT_ID'
```

### Response Example

```json
{
  "data": [
    {
      "id": "DebatedSocialIssuesAndPolitics",
      "description": "Discussions or debates about politics or sensitive social issues such as elections,\ncivic integrity, military conflict, and civil rights in a polarizing manner.",
      "name": "Politics and Sensitive Social Issues"
    },
    {
      "id": "DrugsIntoxication",
      "description": "Excessive tobacco glorification or promotion, any marijuana consumption/use, legal\ndrug and alcohol induced intoxication, discussions of illegal drugs.",
      "name": "Drugs, Intoxication, or Excessive Tobacco Use"
    },
    {
      "id": "Gambling",
      "description": "Participating in online or in-person gambling, poker or fantasy sports, that involve\nthe exchange of real money.",
      "name": "Gambling"
    },
    {
      "id": "MatureGame",
      "description": "Games that are rated Mature or less suitable for a younger audience.",
      "name": "Mature-rated game"
    },
    {
      "id": "ProfanityVulgarity",
      "description": "Prolonged, and repeated use of obscenities, profanities, and vulgarities, especially\nas a regular part of speech.",
      "name": "Significant Profanity or Vulgarity"
    },
    {
      "id": "SexualThemes",
      "description": "Content that focuses on sexualized physical attributes and activities, sexual topics,\nor experiences.",
      "name": "Sexual Themes"
    },
    {
      "id": "ViolentGraphic",
      "description": "Simulations and/or depictions of realistic violence, gore, extreme injury, or death.",
      "name": "Violent and Graphic Depictions"
    }
  ]
}
```
