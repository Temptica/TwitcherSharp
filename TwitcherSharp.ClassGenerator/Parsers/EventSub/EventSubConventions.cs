namespace ClassGenerator.Parsers.EventSub;

/// <summary>
/// Where the EventSub classes come from, so they keep the names twitcher's scripts and earlier TwitchSharp releases use.
/// </summary>
public static class EventSubConventions
{
    /// <summary>
    /// The objects twitcher generates as twitch_es_&lt;name&gt;.gd scripts, and the event field each one is read from.
    /// An object used inside another one comes first.
    /// </summary>
    public static readonly (string Name, (string Type, string Path) Source)[] SharedObjectSources =
    [
        ("emotes", ("channel.subscription.message", "message.emotes")),
        ("message", ("channel.subscription.message", "message")),
        ("top_predictors", ("channel.prediction.end", "outcomes.top_predictors")),
        ("outcomes", ("channel.prediction.end", "outcomes")),
        ("bits_voting", ("channel.poll.begin", "bits_voting")),
        ("channel_points_voting", ("channel.poll.begin", "channel_points_voting")),
        ("choices", ("channel.poll.end", "choices")),
        ("custom_power_up", ("channel.custom_power_up_redemption.add", "custom_power_up")),
        ("global_cooldown", ("channel.channel_points_custom_reward.add", "global_cooldown")),
        ("image", ("channel.channel_points_custom_reward.add", "image")),
        ("max_per_stream", ("channel.channel_points_custom_reward.add", "max_per_stream")),
        ("max_per_user_per_stream", ("channel.channel_points_custom_reward.add", "max_per_user_per_stream")),
        ("product", ("extension.bits_transaction.create", "product")),
        ("reward", ("channel.channel_points_custom_reward_redemption.add", "reward")),
        ("top_contributions", ("channel.hype_train.progress", "top_contributions")),
        ("transport", ("conduit.shard.disabled", "transport")),
    ];

    /// <summary>
    /// Fields that twitcher types as a shared object of another name.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, string> SharedObjectAliases =
        new Dictionary<string, string> { ["default_image"] = "image" };

    /// <summary>
    /// Class names that keep an acronym, where PascalCase of the script name would not.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, string> ClassNameOverrides = new Dictionary<string, string>
    {
        ["channel_vip_add"] = "ChannelVIPAdd",
        ["channel_vip_remove"] = "ChannelVIPRemove",
    };

    /// <summary>
    /// Scripts whose whole event twitcher keeps as a shared object, without a condition.
    /// </summary>
    public static readonly IReadOnlySet<string> SharedEvents =
        new HashSet<string> { "shield_mode", "shoutout_create", "shoutout_received" };

    /// <summary>
    /// The class name ending of a later version's event, where it isn't EventV2.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, string> LaterVersionEventSuffixes =
        new Dictionary<string, string> { ["channel_points_automatic_reward_redemption_add"] = "V2Event" };

    /// <summary>
    /// Scripts whose later version has a condition class of its own, even with the same fields.
    /// </summary>
    public static readonly IReadOnlySet<string> OwnLaterVersionConditions =
        new HashSet<string> { "channel_moderate", "channel_points_automatic_reward_redemption_add" };

    public const string SharedChatPrefix = "shared_chat_";
}
