namespace ClassGenerator.Parsers.EventSub;

/// <summary>
/// Names the Twitcher GDScript plugin uses for its EventSub scripts. TwitcherSharp loads those scripts by name,
/// so the generated classes keep matching them.
/// </summary>
public static class EventSubConventions
{
    public const string SharedNameSpace = "Shared";

    /// <summary>Objects Twitcher generates as standalone <c>twitch_es_&lt;name&gt;.gd</c> scripts.</summary>
    public static readonly IReadOnlySet<string> SharedObjects = new HashSet<string>
    {
        "bits_voting", "channel_points_voting", "choices", "emotes", "global_cooldown", "image", "last_contribution",
        "max_per_stream", "max_per_user_per_stream", "message", "outcomes", "product", "reward", "top_contributions",
        "top_predictors",
    };

    public static readonly IReadOnlyDictionary<string, string> NameSpaceOverrides = new Dictionary<string, string>
    {
        ["channel.vip.add"] = "ChannelVIPAdd",
        ["channel.vip.remove"] = "ChannelVIPRemove",
    };

    public const string SharedChatPrefix = "shared_chat_";
}
