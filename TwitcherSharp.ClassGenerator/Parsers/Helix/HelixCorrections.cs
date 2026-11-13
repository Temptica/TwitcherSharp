#nullable enable
using ClassGenerator.Markdown;

namespace ClassGenerator.Parsers.Helix;

/// <summary>
/// Where the Markdown API reference and the OpenAPI spec that twitcher is generated from
/// (DmitryScaletta/twitch-api-swagger) disagree. TwitcherSharp reads and writes twitcher's generated objects, so a field
/// has to keep twitcher's name, type and place even where the docs are right; each correction names the twitcher script
/// that shows its shape. Drop a correction once twitcher is generated with the docs' shape.
/// </summary>
public static class HelixCorrections
{
    public enum Section
    {
        Query,
        Request,
        Response,
    }

    private abstract record Correction(string Endpoint, Section Section, string Path, string Evidence);

    private record Rename(string Endpoint, Section Section, string Path, string NewName, string Evidence)
        : Correction(Endpoint, Section, Path, Evidence);

    private record SetType(string Endpoint, Section Section, string Path, string Type, string Evidence)
        : Correction(Endpoint, Section, Path, Evidence);

    private record Add(string Endpoint, Section Section, string Path, string Type, string Description, string After,
        string Evidence) : Correction(Endpoint, Section, Path, Evidence);

    private record SetRequired(string Endpoint, Section Section, string Path, bool IsRequired, string Evidence)
        : Correction(Endpoint, Section, Path, Evidence);

    private record Remove(string Endpoint, Section Section, string Path, string Evidence)
        : Correction(Endpoint, Section, Path, Evidence);

    /// <summary>
    /// Moves a field into another object; an empty target is the body itself.
    /// </summary>
    private record Move(string Endpoint, Section Section, string Path, string Target, string Evidence)
        : Correction(Endpoint, Section, Path, Evidence);

    /// <summary>
    /// Replaces an object field by its fields, as the body or a plain dictionary next to them.
    /// </summary>
    private record Flatten(string Endpoint, Section Section, string Path, bool KeepAsDictionary, string Evidence)
        : Correction(Endpoint, Section, Path, Evidence);

    private static readonly string[] GuestStarSessionEndpoints =
        ["get-guest-star-session", "create-guest-star-session", "end-guest-star-session"];

    private static readonly string[] ExtensionEndpoints = ["get-extensions", "get-released-extensions"];

    private static readonly string[] DeprecatedComponentFields =
        ["aspect_width", "aspect_height", "size", "zoom", "zoom_pixels"];

    private static readonly string[] PollEndpoints = ["get-polls", "create-poll", "end-poll"];

    private static readonly string[] EventSubSubscriptionEndpoints =
        ["create-eventsub-subscription", "get-eventsub-subscriptions"];

    private static readonly (string Endpoint, string Parameter)[] StringParameters =
    [
        ("get-moderators", "first"),
        ("get-polls", "first"),
        ("get-predictions", "first"),
        ("get-videos", "first"),
        ("get-stream-markers", "first"),
        ("get-broadcaster-subscriptions", "first"),
        ("get-channel-stream-schedule", "utc_offset"),
        ("delete-guest-star-slot", "should_reinvite_guest"),
    ];

    private static readonly (string Endpoint, string After)[] BeforeParameters =
    [
        ("get-clips", "first"),
        ("get-top-games", "after"),
        ("get-banned-users", "after"),
        ("get-stream-markers", "first"),
    ];

    private static readonly string[] HypeTrainContributionFields =
        ["shared_train_participants", "started_at", "expires_at", "is_shared_train"];

    private static readonly Correction[] Corrections =
    [
        ..new[] { "get-ad-schedule", "snooze-next-ad" }.SelectMany(endpoint => new Correction[]
        {
            new SetType(endpoint, Section.Response, "data.next_ad_at", "Int64", "Unix timestamps outgrow int32"),
            new SetType(endpoint, Section.Response, "data.snooze_refresh_at", "Int64", "Unix timestamps outgrow int32"),
        }),
        new SetType("get-ad-schedule", Section.Response, "data.last_ad_at", "Int64", "Unix timestamps outgrow int32"),
        new Flatten("get-channel-guest-star-settings", Section.Response, "data", false,
            "twitch_get_channel_guest_star_settings.gd"),
        ..GuestStarSessionEndpoints.SelectMany(endpoint => new Correction[]
        {
            new Add(endpoint, Section.Response, "data.guests.user_display_name", "String",
                "Display name of the guest assigned to this slot.", "user_id", "twitch_guest.gd"),
            new Add(endpoint, Section.Response, "data.guests.user_login", "String",
                "Login of the guest assigned to this slot.", "user_display_name", "twitch_guest.gd"),
            new Rename(endpoint, Section.Response, "data.guests.audio", "audio_settings", "twitch_guest.gd"),
            new Rename(endpoint, Section.Response, "data.guests.video", "video_settings", "twitch_guest.gd"),
        }),
        ..new[] { "create-channel-stream-schedule-segment", "update-channel-stream-schedule-segment" }.Select(endpoint =>
            new SetType(endpoint, Section.Request, "duration", "String", endpoint.Replace('-', '_') + ".gd")),
        new Rename("get-stream-markers", Section.Response, "data.videos.markers.URL", "url", "twitch_stream_markers.gd"),
        new Move("get-hype-train-status", Section.Response, "data.all_time_high", "", "twitch_get_hype_train_status.gd"),
        new Move("get-hype-train-status", Section.Response, "data.shared_all_time_high", "",
            "twitch_get_hype_train_status.gd"),
        ..HypeTrainContributionFields.Select(field => new Move("get-hype-train-status", Section.Response,
            "data.current." + field, "data.current.top_contributions", "twitch_get_hype_train_status.gd")),
        new Remove("get-hype-train-status", Section.Response, "data.current.type", "twitch_get_hype_train_status.gd"),
        ..new[] { "cheermote", "emote", "mention" }.Select(fragment => new Flatten("get-pinned-chat-message",
            Section.Response, "data.message.fragments." + fragment, true, "twitch_get_pinned_chat_message.gd")),
        ..ExtensionEndpoints.SelectMany(endpoint => DeprecatedComponentFields
            .Select(field => (Correction)new Remove(endpoint, Section.Response, "data.views.component." + field,
                "twitch_extension.gd"))
            .Append(new Remove(endpoint, Section.Response, "data.views.live_config", "twitch_extension.gd"))),
        ..StringParameters.Select(p => new SetType(p.Endpoint, Section.Query, p.Parameter, "String",
            "the Opt of " + p.Endpoint.Replace('-', '_') + ".gd")),
        ..BeforeParameters.Select(p => new Add(p.Endpoint, Section.Query, "before", "String",
            "The cursor used to get the previous page of results.", p.After,
            "the Opt of " + p.Endpoint.Replace('-', '_') + ".gd")),
        new Add("update-guest-star-slot-settings", Section.Query, "volume", "Integer",
            "Value from 0-100 that controls the audio volume for shared views.", "is_live",
            "the Opt of twitch_update_guest_star_slot_settings.gd"),
        new SetRequired("update-guest-star-slot", Section.Query, "destination_slot_id", false,
            "update_guest_star_slot in twitch_api.gd"),
        new SetRequired("start-a-raid", Section.Query, "from_broadcaster_id", false, "start_a_raid in twitch_api.gd"),
        new SetRequired("start-a-raid", Section.Query, "to_broadcaster_id", false, "start_a_raid in twitch_api.gd"),
        new SetType("get-extension-configuration-segment", Section.Query, "segment", "String",
            "get_extension_configuration_segment in twitch_api.gd"),
        new SetRequired("get-extension-configuration-segment", Section.Query, "segment", true,
            "get_extension_configuration_segment in twitch_api.gd"),
        new Remove("get-extension-secrets", Section.Query, "extension_id", "get_extension_secrets in twitch_api.gd"),
        new Remove("get-user-block-list", Section.Query, "user_id", "the Opt of twitch_get_user_block_list.gd"),
        new Move("get-channel-stream-schedule", Section.Response, "pagination", "data",
            "twitch_get_channel_stream_schedule.gd"),
        ..PollEndpoints.SelectMany(endpoint => new Correction[]
        {
            new Add(endpoint, Section.Response, "data.bits_voting_enabled", "Boolean",
                "Not used; will be set to **false**.", "choices", "twitch_poll.gd"),
            new Add(endpoint, Section.Response, "data.bits_per_vote", "Integer", "Not used; will be set to 0.",
                "bits_voting_enabled", "twitch_poll.gd"),
            new Add(endpoint, Section.Response, "data.choices.bits_votes", "Integer", "Not used; will be set to 0.",
                "channel_points_votes", "twitch_poll.gd"),
        }),
        new Remove("create-eventsub-subscription", Section.Request, "is_batching_enabled",
            "twitch_create_event_sub_subscription.gd"),
        new Add("create-eventsub-subscription", Section.Response, "data.transport.disconnected_at", "String",
            "The UTC date and time that the WebSocket connection was lost. Included only if `method` is set to **websocket**.",
            "connected_at", "twitch_event_sub_subscription.gd"),
        ..EventSubSubscriptionEndpoints.SelectMany(endpoint => new Correction[]
        {
            new Remove(endpoint, Section.Response, "data.transport.conduit_id", "twitch_event_sub_subscription.gd"),
            new Remove(endpoint, Section.Response, "data.is_batching_enabled", "twitch_event_sub_subscription.gd"),
        }),
    ];

    /// <summary>
    /// Applies the corrections to the parsed endpoints. A correction whose endpoint or field is gone throws, so a
    /// change of the docs is noticed.
    /// </summary>
    public static void Apply(IEnumerable<HelixEndpoint> endpoints)
    {
        var byId = endpoints.ToDictionary(e => e.Id);
        foreach (var correction in Corrections)
        {
            var endpoint = byId.GetValueOrDefault(correction.Endpoint)
                           ?? throw new InvalidOperationException($"No endpoint {correction.Endpoint} to correct");
            var body = correction.Section switch
            {
                Section.Query => endpoint.QueryParameters,
                Section.Request => endpoint.RequestBody,
                _ => endpoint.ResponseBody,
            };

            Apply(correction, body);
        }
    }

    private static void Apply(Correction correction, List<DocField> body)
    {
        var (siblings, name) = Locate(correction, body, correction.Path);

        if (correction is Add add)
        {
            if (siblings.Any(f => f.Name == name)) NoLongerNeeded(correction);
            var after = siblings.FindIndex(f => f.Name == add.After);
            if (after < 0) throw Missing(correction, add.After);
            siblings.Insert(after + 1,
                new DocField { Name = name, Path = correction.Path, Type = add.Type, Description = add.Description });
            return;
        }

        var field = siblings.FirstOrDefault(f => f.Name == name) ?? throw Missing(correction, correction.Path);
        switch (correction)
        {
            case Rename rename:
                field.Name = rename.NewName;
                break;
            case SetType setType:
                if (field.Type == setType.Type) NoLongerNeeded(correction);
                field.Type = setType.Type;
                break;
            case SetRequired setRequired:
                if (field.IsRequired == setRequired.IsRequired) NoLongerNeeded(correction);
                field.IsRequired = setRequired.IsRequired;
                break;
            case Remove:
                siblings.Remove(field);
                break;
            case Move move:
                siblings.Remove(field);
                Children(correction, body, move.Target).Add(field);
                break;
            case Flatten flatten:
                var index = siblings.IndexOf(field);
                siblings.InsertRange(index + 1, field.Children);
                if (flatten.KeepAsDictionary)
                {
                    field.Children.Clear();
                    field.Type = "Object";
                }
                else
                {
                    siblings.Remove(field);
                }

                break;
        }
    }

    private static (List<DocField> Siblings, string Name) Locate(Correction correction, List<DocField> body,
        string path)
    {
        var split = path.LastIndexOf('.');
        return split < 0
            ? (body, path)
            : (Children(correction, body, path[..split]), path[(split + 1)..]);
    }

    private static List<DocField> Children(Correction correction, List<DocField> body, string path)
    {
        var fields = body;
        if (path.Length == 0) return fields;

        foreach (var name in path.Split('.'))
        {
            fields = (fields.FirstOrDefault(f => f.Name == name) ?? throw Missing(correction, path)).Children;
        }

        return fields;
    }

    private static InvalidOperationException Missing(Correction correction, string path) =>
        new($"{correction.Endpoint} ({correction.Section}): {path} does not exist");

    private static void NoLongerNeeded(Correction correction) =>
        Console.WriteLine($"  correction no longer needed: {correction.Endpoint} {correction.Path} " +
                          $"({correction.Evidence})");
}
