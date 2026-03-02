using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Auth;

public partial class TwitchScopes(StringName val, string description, string category = "")
    : Resource, ITwitcherSharp<TwitchScopes>
{
    public StringName Value { get; set; } = val;
    public string Description { get; set; } = description;
    public string Category { get; set; } = category;

    public string GetCategory => string.IsNullOrEmpty(Category) ? Value.ToString().Split(':')[0] : Category;

    public static TwitchScopes FromObject(GodotObject data)
    {
        return new TwitchScopes(data.Get("value").AsStringName(), data.Get("description").AsStringName(),
            data.Get("category").AsStringName());
    }

    public override string ToString()
    {
        return Value;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }


    #region Instances

    public static readonly TwitchScopes AnalyticsReadExtensions = new("analytics:read:extensions",
        "View analytics data for the Twitch Extensions owned by the authenticated account.");

    public static readonly TwitchScopes AnalyticsReadGames = new("analytics:read:games",
        "View analytics data for the games owned by the authenticated account.");

    public static readonly TwitchScopes BitsRead = new("bits:read", "View Bits information for a channel.");

    public static readonly TwitchScopes ChannelBot = new("channel:bot",
        "Joins your channel’s chatroom as a bot user, and perform chat-related actions as that user.");

    public static readonly TwitchScopes ChannelManageAds =
        new("channel:manage:ads", "Manage ads schedule on a channel.");

    public static readonly TwitchScopes ChannelReadAds =
        new("channel:read:ads", "Read the ads schedule and details on your channel.");

    public static readonly TwitchScopes ChannelManageBroadcast = new("channel:manage:broadcast",
        "Manage a channel’s broadcast configuration, including updating channel configuration and managing stream markers and stream tags.");

    public static readonly TwitchScopes ChannelReadCharity = new("channel:read:charity",
        "Read charity campaign details and user donations on your channel.");

    public static readonly TwitchScopes ChannelEditCommercial =
        new("channel:edit:commercial", "Run commercials on a channel.");

    public static readonly TwitchScopes ChannelReadEditors =
        new("channel:read:editors", "View a list of users with the editor role for a channel.");

    public static readonly TwitchScopes ChannelManageExtensions = new("channel:manage:extensions",
        "Manage a channel’s Extension configuration, including activating Extensions.");

    public static readonly TwitchScopes ChannelReadGoals =
        new("channel:read:goals", "View Creator Goals for a channel.");

    public static readonly TwitchScopes ChannelReadGuestStar =
        new("channel:read:guest_star", "Read Guest Star details for your channel.");

    public static readonly TwitchScopes ChannelManageGuestStar =
        new("channel:manage:guest_star", "Manage Guest Star for your channel.");

    public static readonly TwitchScopes ChannelReadHypeTrain =
        new("channel:read:hype_train", "View Hype Train information for a channel.");

    public static readonly TwitchScopes ChannelManageModerators = new("channel:manage:moderators",
        "Add or remove the moderator role from users in your channel.");

    public static readonly TwitchScopes ChannelReadPolls = new("channel:read:polls", "View a channel’s polls.");
    public static readonly TwitchScopes ChannelManagePolls = new("channel:manage:polls", "Manage a channel’s polls.");

    public static readonly TwitchScopes ChannelReadPredictions =
        new("channel:read:predictions", "View a channel’s Channel Points Predictions.");

    public static readonly TwitchScopes ChannelManagePredictions =
        new("channel:manage:predictions", "Manage of channel’s Channel Points Predictions");

    public static readonly TwitchScopes ChannelManageRaids =
        new("channel:manage:raids", "Manage a channel raiding another channel.");

    public static readonly TwitchScopes ChannelReadRedemptions = new("channel:read:redemptions",
        "View Channel Points custom rewards and their redemptions on a channel.");

    public static readonly TwitchScopes ChannelManageRedemptions = new("channel:manage:redemptions",
        "Manage Channel Points custom rewards and their redemptions on a channel.");

    public static readonly TwitchScopes ChannelManageSchedule =
        new("channel:manage:schedule", "Manage a channel’s stream schedule.");

    public static readonly TwitchScopes ChannelReadStreamKey =
        new("channel:read:stream_key", "View an authorized user’s stream key.");

    public static readonly TwitchScopes ChannelReadSubscriptions = new("channel:read:subscriptions",
        "View a list of all subscribers to a channel and check if a user is subscribed to a channel.");

    public static readonly TwitchScopes ChannelManageVideos =
        new("channel:manage:videos", "Manage a channel’s videos, including deleting videos.");

    public static readonly TwitchScopes ChannelReadVips =
        new("channel:read:vips", "Read the list of VIPs in your channel.");

    public static readonly TwitchScopes ChannelManageVips =
        new("channel:manage:vips", "Add or remove the VIP role from users in your channel.");

    public static readonly TwitchScopes ClipsEdit = new("clips:edit", "Manage Clips for a channel.");

    public static readonly TwitchScopes ModerationRead = new("moderation:read",
        "View a channel’s moderation data including Moderators, Bans, Timeouts, and Automod settings.");

    public static readonly TwitchScopes ModeratorManageAnnouncements = new("moderator:manage:announcements",
        "Send announcements in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorManageAutomod = new("moderator:manage:automod",
        "Manage messages held for review by AutoMod in channels where you are a moderator.");

    public static readonly TwitchScopes ModeratorReadAutomodSettings =
        new("moderator:read:automod_settings", "View a broadcaster’s AutoMod settings.");

    public static readonly TwitchScopes ModeratorManageAutomodSettings =
        new("moderator:manage:automod_settings", "Manage a broadcaster’s AutoMod settings.");

    public static readonly TwitchScopes ModeratorReadBannedUsers = new("moderator:read:banned_users",
        "Read the list of bans or unbans in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorManageBannedUsers =
        new("moderator:manage:banned_users", "Ban and unban users.");

    public static readonly TwitchScopes ModeratorReadBlockedTerms =
        new("moderator:read:blocked_terms", "View a broadcaster’s list of blocked terms.");

    public static readonly TwitchScopes ModeratorReadChatMessages = new("moderator:read:chat_messages",
        "Read deleted chat messages in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorManageBlockedTerms =
        new("moderator:manage:blocked_terms", "Manage a broadcaster’s list of blocked terms.");

    public static readonly TwitchScopes ModeratorManageChatMessages = new("moderator:manage:chat_messages",
        "Delete chat messages in channels where you have the moderator role");

    public static readonly TwitchScopes ModeratorReadChatSettings =
        new("moderator:read:chat_settings", "View a broadcaster’s chat room settings.");

    public static readonly TwitchScopes ModeratorManageChatSettings =
        new("moderator:manage:chat_settings", "Manage a broadcaster’s chat room settings.");

    public static readonly TwitchScopes ModeratorReadChatters =
        new("moderator:read:chatters", "View the chatters in a broadcaster’s chat room.");

    public static readonly TwitchScopes ModeratorReadFollowers =
        new("moderator:read:followers", "Read the followers of a broadcaster.");

    public static readonly TwitchScopes ModeratorReadGuestStar = new("moderator:read:guest_star",
        "Read Guest Star details for channels where you are a Guest Star moderator.");

    public static readonly TwitchScopes ModeratorManageGuestStar = new("moderator:manage:guest_star",
        "Manage Guest Star for channels where you are a Guest Star moderator.");

    public static readonly TwitchScopes ModeratorReadModerators = new("moderator:read:moderators",
        "Read the list of moderators in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorReadShieldMode =
        new("moderator:read:shield_mode", "View a broadcaster’s Shield Mode status.");

    public static readonly TwitchScopes ModeratorManageShieldMode =
        new("moderator:manage:shield_mode", "Manage a broadcaster’s Shield Mode status.");

    public static readonly TwitchScopes ModeratorReadShoutouts =
        new("moderator:read:shoutouts", "View a broadcaster’s shoutouts.");

    public static readonly TwitchScopes ModeratorManageShoutouts =
        new("moderator:manage:shoutouts", "Manage a broadcaster’s shoutouts.");

    public static readonly TwitchScopes ModeratorReadSuspiciousUsers = new("moderator:read:suspicious_users",
        "Read chat messages from suspicious users and see users flagged as suspicious in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorReadUnbanRequests =
        new("moderator:read:unban_requests", "View a broadcaster’s unban requests.");

    public static readonly TwitchScopes ModeratorManageUnbanRequests =
        new("moderator:manage:unban_requests", "Manage a broadcaster’s unban requests.");

    public static readonly TwitchScopes ModeratorReadVips = new("moderator:read:vips",
        "Read the list of VIPs in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorReadWarnings = new("moderator:read:warnings",
        "Read warnings in channels where you have the moderator role.");

    public static readonly TwitchScopes ModeratorManageWarnings = new("moderator:manage:warnings",
        "Warn users in channels where you have the moderator role.");

    public static readonly TwitchScopes UserBot = new("user:bot",
        "Join a specified chat channel as your user and appear as a bot, and perform chat-related actions as your user.");

    public static readonly TwitchScopes UserEdit = new("user:edit", "Manage a user object.");

    public static readonly TwitchScopes UserEditBroadcast = new("user:edit:broadcast",
        "View and edit a user’s broadcasting configuration, including Extension configurations.");

    public static readonly TwitchScopes UserReadBlockedUsers =
        new("user:read:blocked_users", "View the block list of a user.");

    public static readonly TwitchScopes UserManageBlockedUsers =
        new("user:manage:blocked_users", "Manage the block list of a user.");

    public static readonly TwitchScopes UserReadBroadcast = new("user:read:broadcast",
        "View a user’s broadcasting configuration, including Extension configurations.");

    public static readonly TwitchScopes UserReadChat = new("user:read:chat",
        "Receive chatroom messages and informational notifications relating to a channel’s chatroom.");

    public static readonly TwitchScopes UserManageChatColor =
        new("user:manage:chat_color", "Update the color used for the user’s name in chat.");

    public static readonly TwitchScopes UserReadEmail = new("user:read:email", "View a user’s email address.");
    public static readonly TwitchScopes UserReadEmotes = new("user:read:emotes", "View emotes available to a user");

    public static readonly TwitchScopes UserReadFollows =
        new("user:read:follows", "View the list of channels a user follows.");

    public static readonly TwitchScopes UserReadModeratedChannels = new("user:read:moderated_channels",
        "Read the list of channels you have moderator privileges in.");

    public static readonly TwitchScopes UserReadSubscriptions = new("user:read:subscriptions",
        "View if an authorized user is subscribed to specific channels.");

    public static readonly TwitchScopes UserReadWhispers =
        new("user:read:whispers", "Receive whispers sent to your user.");

    public static readonly TwitchScopes UserManageWhispers = new("user:manage:whispers",
        "Receive whispers sent to your user, and send whispers on your user’s behalf.");

    public static readonly TwitchScopes UserWriteChat = new("user:write:chat", "Send chat messages to a chatroom.");

    public static readonly TwitchScopes ChatRead = new("chat:edit",
        "Send chat messages to a chatroom using an IRC connection.", "IRC");

    public static readonly TwitchScopes ChatEdit = new("chat:read",
        "View chat messages sent in a chatroom using an IRC connection.", "IRC");

    #endregion

    public static List<TwitchScopes> GetAllScopes() =>
    [
        AnalyticsReadExtensions,
        AnalyticsReadGames,
        BitsRead,
        ChannelBot,
        ChannelManageAds,
        ChannelReadAds,
        ChannelManageBroadcast,
        ChannelReadCharity,
        ChannelEditCommercial,
        ChannelReadEditors,
        ChannelManageExtensions,
        ChannelReadGoals,
        ChannelReadGuestStar,
        ChannelManageGuestStar,
        ChannelReadHypeTrain,
        ChannelManageModerators,
        ChannelReadPolls,
        ChannelManagePolls,
        ChannelReadPredictions,
        ChannelManagePredictions,
        ChannelManageRaids,
        ChannelReadRedemptions,
        ChannelManageRedemptions,
        ChannelManageSchedule,
        ChannelReadStreamKey,
        ChannelReadSubscriptions,
        ChannelManageVideos,
        ChannelReadVips,
        ChannelManageVips,
        ClipsEdit,
        ModerationRead,
        ModeratorManageAnnouncements,
        ModeratorManageAutomod,
        ModeratorReadAutomodSettings,
        ModeratorManageAutomodSettings,
        ModeratorReadBannedUsers,
        ModeratorManageBannedUsers,
        ModeratorReadBlockedTerms,
        ModeratorReadChatMessages,
        ModeratorManageBlockedTerms,
        ModeratorManageChatMessages,
        ModeratorReadChatSettings,
        ModeratorManageChatSettings,
        ModeratorReadChatters,
        ModeratorReadFollowers,
        ModeratorReadGuestStar,
        ModeratorManageGuestStar,
        ModeratorReadModerators,
        ModeratorReadShieldMode,
        ModeratorManageShieldMode,
        ModeratorReadShoutouts,
        ModeratorManageShoutouts,
        ModeratorReadSuspiciousUsers,
        ModeratorReadUnbanRequests,
        ModeratorManageUnbanRequests,
        ModeratorReadVips,
        ModeratorReadWarnings,
        ModeratorManageWarnings,
        UserBot,
        UserEdit,
        UserEditBroadcast,
        UserReadBlockedUsers,
        UserManageBlockedUsers,
        UserReadBroadcast,
        UserReadChat,
        UserManageChatColor,
        UserReadEmail,
        UserReadEmotes,
        UserReadFollows,
        UserReadModeratedChannels,
        UserReadSubscriptions,
        UserReadWhispers,
        UserManageWhispers,
        UserWriteChat,
        ChatRead,
        ChatEdit,
    ];
}