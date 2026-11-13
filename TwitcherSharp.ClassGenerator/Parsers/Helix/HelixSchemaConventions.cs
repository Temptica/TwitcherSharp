namespace ClassGenerator.Parsers.Helix;

/// <summary>
/// Naming and shape conventions of the community OpenAPI spec (DmitryScaletta/twitch-api-swagger) that the
/// Twitcher GDScript plugin is generated from. TwitcherSharp loads Twitcher's generated scripts by name, so the
/// schemas built from the Markdown docs have to keep exactly these names.
/// </summary>
public static class HelixSchemaConventions
{
    public static readonly IReadOnlyDictionary<string, (string Path, string Name)[]> SharedResponseSchemas =
        new Dictionary<string, (string, string)[]>
        {
            ["get-extension-analytics"] = [("data[0]", "ExtensionAnalytics")],
            ["get-game-analytics"] = [("data[0]", "GameAnalytics")],
            ["get-bits-leaderboard"] = [("data[0]", "BitsLeaderboard")],
            ["get-cheermotes"] = [("data[0]", "Cheermote")],
            ["get-extension-transactions"] = [("data[0]", "ExtensionTransaction")],
            ["get-channel-information"] = [("data[0]", "ChannelInformation")],
            ["get-channel-editors"] = [("data[0]", "ChannelEditor")],
            ["create-custom-rewards"] = [("data[0]", "CustomReward")],
            ["get-custom-reward"] = [("data[0]", "CustomReward")],
            ["update-custom-reward"] = [("data[0]", "CustomReward")],
            ["get-custom-reward-redemption"] = [("data[0]", "CustomRewardRedemption")],
            ["update-redemption-status"] = [("data[0]", "CustomRewardRedemption")],
            ["get-charity-campaign"] = [("data[0]", "CharityCampaign")],
            ["get-charity-campaign-donations"] = [("data[0]", "CharityCampaignDonation")],
            ["get-chatters"] = [("data[0]", "Chatter")],
            ["get-channel-emotes"] = [("data[0]", "ChannelEmote")],
            ["get-global-emotes"] = [("data[0]", "GlobalEmote")],
            ["get-emote-sets"] = [("data[0]", "Emote")],
            ["get-channel-chat-badges"] = [("data[0]", "ChatBadge")],
            ["get-global-chat-badges"] = [("data[0]", "ChatBadge")],
            ["get-chat-settings"] = [("data[0]", "ChatSettings")],
            ["update-chat-settings"] = [("data[0]", "ChatSettingsUpdated")],
            ["get-user-chat-color"] = [("data[0]", "UserChatColor")],
            ["get-content-classification-labels"] = [("data[0]", "ContentClassificationLabel")],
            ["get-clips"] = [("data[0]", "Clip")],
            ["get-code-status"] = [("data[0]", "CodeStatus")],
            ["get-drops-entitlements"] = [("data[0]", "DropsEntitlement")],
            ["update-drops-entitlements"] = [("data[0]", "DropsEntitlementUpdated")],
            ["get-extension-configuration-segment"] = [("data[0]", "ExtensionConfigurationSegment")],
            ["get-extension-live-channels"] = [("data[0]", "ExtensionLiveChannel")],
            ["get-extension-secrets"] = [("data[0]", "ExtensionSecret")],
            ["create-extension-secret"] = [("data[0]", "ExtensionSecret")],
            ["get-extensions"] = [("data[0]", "Extension")],
            ["get-released-extensions"] = [("data[0]", "Extension")],
            ["get-extension-bits-products"] = [("data[0]", "ExtensionBitsProduct")],
            ["update-extension-bits-product"] = [("data[0]", "ExtensionBitsProduct")],
            ["create-eventsub-subscription"] = [("data[0]", "EventSubSubscription")],
            ["get-eventsub-subscriptions"] = [("data[0]", "EventSubSubscription")],
            ["get-top-games"] = [("data[0]", "Game")],
            ["get-games"] = [("data[0]", "Game")],
            ["get-creator-goals"] = [("data[0]", "CreatorGoal")],
            ["get-guest-star-session"] = [("data[0]", "GuestStarSession"), ("data[0].guests", "Guest")],
            ["create-guest-star-session"] = [("data[0]", "GuestStarSession"), ("data[0].guests", "Guest")],
            ["end-guest-star-session"] = [("data[0]", "GuestStarSession"), ("data[0].guests", "Guest")],
            ["get-guest-star-invites"] = [("data[0]", "GuestStarInvite")],
            ["get-hype-train-events"] = [("data[0]", "HypeTrainEvent")],
            ["check-automod-status"] = [("data[0]", "AutoModStatus")],
            ["get-automod-settings"] = [("data[0]", "AutoModSettings")],
            ["update-automod-settings"] = [("data[0]", "AutoModSettings")],
            ["get-banned-users"] = [("data[0]", "BannedUser")],
            ["get-blocked-terms"] = [("data[0]", "BlockedTerm")],
            ["add-blocked-term"] = [("data[0]", "BlockedTerm")],
            ["get-moderators"] = [("data[0]", "UserModerator")],
            ["get-vips"] = [("data[0]", "UserVip")],
            ["get-polls"] = [("data[0]", "Poll")],
            ["create-poll"] = [("data[0]", "Poll")],
            ["end-poll"] = [("data[0]", "Poll")],
            ["get-predictions"] = [("data[0]", "Prediction"), ("data[0].outcomes", "PredictionOutcome")],
            ["create-prediction"] = [("data[0]", "Prediction"), ("data[0].outcomes", "PredictionOutcome")],
            ["end-prediction"] = [("data[0]", "Prediction"), ("data[0].outcomes", "PredictionOutcome")],
            ["get-channel-stream-schedule"] = [("data.segments", "ChannelStreamScheduleSegment")],
            ["create-channel-stream-schedule-segment"] = [("data.segments", "ChannelStreamScheduleSegment")],
            ["update-channel-stream-schedule-segment"] = [("data.segments", "ChannelStreamScheduleSegment")],
            ["search-categories"] = [("data[0]", "Category")],
            ["search-channels"] = [("data[0]", "Channel")],
            ["get-streams"] = [("data[0]", "Stream")],
            ["get-followed-streams"] = [("data[0]", "Stream")],
            ["create-stream-marker"] = [("data[0]", "StreamMarkerCreated")],
            ["get-stream-markers"] = [("data[0]", "StreamMarkers")],
            ["get-broadcaster-subscriptions"] = [("data[0]", "BroadcasterSubscription")],
            ["check-user-subscription"] = [("data[0]", "UserSubscription")],
            ["get-channel-teams"] = [("data[0]", "ChannelTeam")],
            ["get-teams"] = [("data[0]", "Team")],
            ["get-users"] = [("data[0]", "User")],
            ["update-user"] = [("data[0]", "User")],
            ["get-user-block-list"] = [("data[0]", "UserBlockList")],
            ["get-user-extensions"] = [("data[0]", "UserExtension")],
            ["get-videos"] = [("data[0]", "Video")],
        };

    public static readonly IReadOnlySet<string> MutuallyExclusiveParameters =
        new HashSet<string> { "get-clips", "get-stream-markers", "get-teams", "get-videos", "get-games" };

    public static readonly IReadOnlySet<string> AlwaysOptionalResponseFields =
        new HashSet<string> { "pagination", "cursor" };

    public static readonly IReadOnlyDictionary<string, string[]> OptionalResponseFields =
        new Dictionary<string, string[]>
        {
            ["get-extension-configuration-segment"] = ["broadcaster_id"],
            ["create-eventsub-subscription"] = ["callback", "session_id", "connected_at", "disconnected_at"],
            ["get-eventsub-subscriptions"] = ["callback", "session_id", "connected_at", "disconnected_at"],
            ["update-user-extensions"] = ["id", "version", "name", "x", "y"],
        };

    public static readonly IReadOnlySet<string> AllResponseFieldsOptional =
        new HashSet<string> { "get-user-active-extensions" };

    public static readonly IReadOnlySet<string> UserExtensionEndpoints =
        new HashSet<string> { "get-user-active-extensions", "update-user-extensions" };

    public static readonly IReadOnlyDictionary<string, string> UserExtensionSchemas = new Dictionary<string, string>
    {
        ["panel"] = "UserExtensionPanel",
        ["overlay"] = "UserExtensionOverlay",
        ["component"] = "UserExtensionComponent",
    };

    public static readonly IReadOnlySet<string> ExtensionIconEndpoints =
        new HashSet<string> { "get-extensions", "get-released-extensions" };

    public const string CalendarEndpoint = "get-channel-icalendar";
    public const string CheermotesEndpoint = "get-cheermotes";

    public static string SchemaPrefix(string endpointName) =>
        string.Concat(endpointName.Replace('-', ' ')
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => char.ToUpperInvariant(w[0]) + w[1..]));
}
