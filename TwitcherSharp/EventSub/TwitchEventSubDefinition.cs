using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventSubDefinition() : RefCounted, ITwitcherSharp<TwitchEventSubDefinition>
{
    private GodotObject? _data;

    public TwitchEventSubDefinitionType Type { get; set; }
    public StringName Value { get; set; } = null!;
    public StringName Version { get; set; } = null!;
    public List<StringName> Conditions { get; set; } = null!;
    public List<StringName> Scopes { get; set; } = null!;
    public string DocumentationLink { get; set; } = null!;
    public string GetReadableName() => $"{Value} (v{Version})";

    /// <summary>
    /// Only set for the static, generated definitions (via the parameterized constructor) - never populated
    /// by <see cref="FromObject"/>, since a plain godot definition object carries no script reference.
    /// </summary>
    public GDScript? Script { get; set; }

    public static TwitchEventSubDefinition? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var definition = new TwitchEventSubDefinition();
        definition._data = data;
        definition.Type = (TwitchEventSubDefinitionType)data.Get("type").AsInt32();
        definition.Value = data.Get("value").AsStringName();
        definition.Version = data.Get("version").AsStringName();
        definition.Conditions = data.Get("conditions").AsSystemArrayOfStringName().ToList();
        definition.Scopes = data.Get("scopes").AsSystemArrayOfStringName().ToList();
        definition.DocumentationLink = data.Get("documentation_link").AsString();
        return definition;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/eventsub/twitch_eventsub_definition.gd");

        var conditions = new Godot.Collections.Array<StringName>(Conditions);
        var scopes = new Godot.Collections.Array<StringName>(Scopes);
        var data = script.New((int)Type, Value, Version, conditions, scopes, DocumentationLink, Script!)
            .AsGodotObject();
        return data;
    }

    private const string basePath = "res://addons/twitcher/generated_eventsub/twitch_es_";

    public TwitchEventSubDefinition(TwitchEventSubDefinitionType type, string value, string version,
        List<StringName> conditions, List<StringName> scopes, string documentationLink, string name) : this()
    {
        Type = type;
        Value = value;
        Version = version;
        Conditions = conditions;
        Scopes = scopes;
        DocumentationLink = documentationLink;
        Script = GD.Load<GDScript>($"{basePath}{name}.gd");
    }

    #region Static Definitions

    public static readonly TwitchEventSubDefinition AutomodMessageHold = new(
        TwitchEventSubDefinitionType.AutomodMessageHold, "automod.message.hold", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/reference/automod/#automod-message-hold",
        "automod_message_hold");

    public static readonly TwitchEventSubDefinition AutomodMessageHoldV2 = new(
        TwitchEventSubDefinitionType.AutomodMessageHoldV2, "automod.message.hold", "2",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/reference/automod/#automod-message-hold-v2",
        "automod_message_hold");

    public static readonly TwitchEventSubDefinition AutomodMessageUpdate = new(
        TwitchEventSubDefinitionType.AutomodMessageUpdate, "automod.message.update", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/reference/automod/#automod-message-update",
        "automod_message_update");

    public static readonly TwitchEventSubDefinition AutomodMessageUpdateV2 = new(
        TwitchEventSubDefinitionType.AutomodMessageUpdateV2, "automod.message.update", "2",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/reference/automod/#automod-message-update-v2",
        "automod_message_update");

    public static readonly TwitchEventSubDefinition AutomodSettingsUpdate = new(
        TwitchEventSubDefinitionType.AutomodSettingsUpdate, "automod.settings.update", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod_settings"],
        "https://dev.twitch.tv/docs/eventsub/reference/automod/#automod-settings-update",
        "automod_settings_update");

    public static readonly TwitchEventSubDefinition AutomodTermsUpdate = new(
        TwitchEventSubDefinitionType.AutomodTermsUpdate, "automod.terms.update", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/reference/automod/#automod-terms-update",
        "automod_terms_update");

    public static readonly TwitchEventSubDefinition ChannelAdBreakBegin = new(
        TwitchEventSubDefinitionType.ChannelAdBreakBegin, "channel.ad_break.begin", "1",
        ["broadcaster_user_id"], ["channel:read:ads"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-ad-break-begin",
        "channel_ad_break_begin");

    public static readonly TwitchEventSubDefinition ChannelBan = new(
        TwitchEventSubDefinitionType.ChannelBan, "channel.ban", "1",
        ["broadcaster_user_id"], ["channel:moderate"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-ban",
        "channel_ban");

    public static readonly TwitchEventSubDefinition ChannelBitsUse = new(
        TwitchEventSubDefinitionType.ChannelBitsUse, "channel.bits.use", "1",
        ["broadcaster_user_id"], ["bits:read"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-bits-use",
        "channel_bits_use");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsAutomaticRewardRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsAutomaticRewardRedemptionAdd, "channel.channel_points_automatic_reward_redemption.add", "1",
        ["broadcaster_user_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-automatic-reward-redemption-add",
        "channel_points_automatic_reward_redemption_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsAutomaticRewardRedemptionAddV2 = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsAutomaticRewardRedemptionAddV2, "channel.channel_points_automatic_reward_redemption.add", "2",
        ["broadcaster_user_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-automatic-reward-redemption-add-v2",
        "channel_points_automatic_reward_redemption_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardAdd, "channel.channel_points_custom_reward.add", "1",
        ["broadcaster_user_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-custom-reward-add",
        "channel_points_custom_reward_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardRemove = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRemove, "channel.channel_points_custom_reward.remove", "1",
        ["broadcaster_user_id", "reward_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-custom-reward-remove",
        "channel_points_custom_reward_remove");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardUpdate = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardUpdate, "channel.channel_points_custom_reward.update", "1",
        ["broadcaster_user_id", "reward_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-custom-reward-update",
        "channel_points_custom_reward_update");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRedemptionAdd, "channel.channel_points_custom_reward_redemption.add", "1",
        ["broadcaster_user_id", "reward_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-custom-reward-redemption-add",
        "channel_points_custom_reward_redemption_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardRedemptionUpdate = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRedemptionUpdate, "channel.channel_points_custom_reward_redemption.update", "1",
        ["broadcaster_user_id", "reward_id"], ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-points/#channel-channel-points-custom-reward-redemption-update",
        "channel_points_custom_reward_redemption_update");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignDonate = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignDonate, "channel.charity_campaign.donate", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/reference/charity/#channel-charity-campaign-donate",
        "charity_donation");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignProgress = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignProgress, "channel.charity_campaign.progress", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/reference/charity/#channel-charity-campaign-progress",
        "charity_campaign_progress");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignStart = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignStart, "channel.charity_campaign.start", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/reference/charity/#channel-charity-campaign-start",
        "charity_campaign_start");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignStop = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignStop, "channel.charity_campaign.stop", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/reference/charity/#channel-charity-campaign-stop",
        "charity_campaign_stop");

    public static readonly TwitchEventSubDefinition ChannelChatClear = new(
        TwitchEventSubDefinitionType.ChannelChatClear, "channel.chat.clear", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot", "channel:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-clear",
        "channel_chat_clear");

    public static readonly TwitchEventSubDefinition ChannelChatClearUserMessages = new(
        TwitchEventSubDefinitionType.ChannelChatClearUserMessages, "channel.chat.clear_user_messages", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot", "channel:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-clear-user-messages",
        "channel_chat_clear_user_messages");

    public static readonly TwitchEventSubDefinition ChannelChatMessage = new(
        TwitchEventSubDefinitionType.ChannelChatMessage, "channel.chat.message", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot", "channel:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-message",
        "channel_chat_message");

    public static readonly TwitchEventSubDefinition ChannelChatMessageDelete = new(
        TwitchEventSubDefinitionType.ChannelChatMessageDelete, "channel.chat.message_delete", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot", "channel:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-message-delete",
        "channel_chat_message_delete");

    public static readonly TwitchEventSubDefinition ChannelChatNotification = new(
        TwitchEventSubDefinitionType.ChannelChatNotification, "channel.chat.notification", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot", "channel:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-notification",
        "channel_chat_notification");

    public static readonly TwitchEventSubDefinition ChannelChatUserMessageHold = new(
        TwitchEventSubDefinitionType.ChannelChatUserMessageHold, "channel.chat.user_message_hold", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-user-message-hold",
        "channel_chat_user_message_hold");

    public static readonly TwitchEventSubDefinition ChannelChatUserMessageUpdate = new(
        TwitchEventSubDefinitionType.ChannelChatUserMessageUpdate, "channel.chat.user_message_update", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-user-message-update",
        "channel_chat_user_message_update");

    public static readonly TwitchEventSubDefinition ChannelChatSettingsUpdate = new(
        TwitchEventSubDefinitionType.ChannelChatSettingsUpdate, "channel.chat_settings.update", "1",
        ["broadcaster_user_id", "user_id"], ["user:read:chat", "user:bot", "channel:bot"],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-chat-settings-update",
        "channel_chat_settings_update");

    public static readonly TwitchEventSubDefinition ChannelCheer = new(
        TwitchEventSubDefinitionType.ChannelCheer, "channel.cheer", "1",
        ["broadcaster_user_id"], ["bits:read"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-cheer",
        "channel_cheer");

    public static readonly TwitchEventSubDefinition ChannelCustomPowerUpRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelCustomPowerUpRedemptionAdd, "channel.custom_power_up_redemption.add", "1",
        ["broadcaster_user_id", "reward_id"], ["bits:read"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-custom-power-up-redemption-add",
        "channel_custom_power_up_redemption_add");

    public static readonly TwitchEventSubDefinition ChannelFollow = new(
        TwitchEventSubDefinitionType.ChannelFollow, "channel.follow", "2",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:followers"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-follow",
        "channel_follow");

    public static readonly TwitchEventSubDefinition ChannelGoalBegin = new(
        TwitchEventSubDefinitionType.ChannelGoalBegin, "channel.goal.begin", "1",
        ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/reference/goal/#channel-goal-begin",
        "goals");

    public static readonly TwitchEventSubDefinition ChannelGoalEnd = new(
        TwitchEventSubDefinitionType.ChannelGoalEnd, "channel.goal.end", "1",
        ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/reference/goal/#channel-goal-end",
        "goals");

    public static readonly TwitchEventSubDefinition ChannelGoalProgress = new(
        TwitchEventSubDefinitionType.ChannelGoalProgress, "channel.goal.progress", "1",
        ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/reference/goal/#channel-goal-progress",
        "goals");

    public static readonly TwitchEventSubDefinition ChannelGuestStarGuestUpdate = new(
        TwitchEventSubDefinitionType.ChannelGuestStarGuestUpdate, "channel.guest_star_guest.update", "beta",
        ["broadcaster_user_id", "moderator_user_id"], ["channel:read:guest_star", "channel:manage:guest_star", "moderator:read:guest_star", "moderator:manage:guest_star"],
        "https://dev.twitch.tv/docs/eventsub/reference/guest-star/#channel-guest-star-guest-update",
        "channel_guest_star_guest_update");

    public static readonly TwitchEventSubDefinition ChannelGuestStarSessionBegin = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSessionBegin, "channel.guest_star_session.begin", "beta",
        ["broadcaster_user_id", "moderator_user_id"], ["channel:read:guest_star", "channel:manage:guest_star", "moderator:read:guest_star", "moderator:manage:guest_star"],
        "https://dev.twitch.tv/docs/eventsub/reference/guest-star/#channel-guest-star-session-begin",
        "channel_guest_star_session_begin");

    public static readonly TwitchEventSubDefinition ChannelGuestStarSessionEnd = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSessionEnd, "channel.guest_star_session.end", "beta",
        ["broadcaster_user_id", "moderator_user_id"], ["channel:read:guest_star", "channel:manage:guest_star", "moderator:read:guest_star", "moderator:manage:guest_star"],
        "https://dev.twitch.tv/docs/eventsub/reference/guest-star/#channel-guest-star-session-end",
        "channel_guest_star_session_end");

    public static readonly TwitchEventSubDefinition ChannelGuestStarSettingsUpdate = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSettingsUpdate, "channel.guest_star_settings.update", "beta",
        ["broadcaster_user_id", "moderator_user_id"], ["channel:read:guest_star", "channel:manage:guest_star", "moderator:read:guest_star", "moderator:manage:guest_star"],
        "https://dev.twitch.tv/docs/eventsub/reference/guest-star/#channel-guest-star-settings-update",
        "channel_guest_star_settings_update");

    public static readonly TwitchEventSubDefinition ChannelHypeTrainBegin = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainBegin, "channel.hype_train.begin", "2",
        ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/reference/hype-train/#channel-hype-train-begin",
        "hype_train_begin");

    public static readonly TwitchEventSubDefinition ChannelHypeTrainEnd = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainEnd, "channel.hype_train.end", "2",
        ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/reference/hype-train/#channel-hype-train-end",
        "hype_train_end");

    public static readonly TwitchEventSubDefinition ChannelHypeTrainProgress = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainProgress, "channel.hype_train.progress", "2",
        ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/reference/hype-train/#channel-hype-train-progress",
        "hype_train_progress");

    public static readonly TwitchEventSubDefinition ChannelModerate = new(
        TwitchEventSubDefinitionType.ChannelModerate, "channel.moderate", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:blocked_terms", "moderator:manage:blocked_terms", "moderator:read:chat_settings", "moderator:manage:chat_settings", "moderator:read:unban_requests", "moderator:manage:unban_requests", "moderator:read:banned_users", "moderator:manage:banned_users", "moderator:read:chat_messages", "moderator:manage:chat_messages", "moderator:read:warnings", "moderator:manage:warnings", "moderator:read:moderators", "moderator:read:vips"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-moderate",
        "channel_moderate");

    public static readonly TwitchEventSubDefinition ChannelModerateV2 = new(
        TwitchEventSubDefinitionType.ChannelModerateV2, "channel.moderate", "2",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:blocked_terms", "moderator:manage:blocked_terms", "moderator:read:chat_settings", "moderator:manage:chat_settings", "moderator:read:unban_requests", "moderator:manage:unban_requests", "moderator:read:banned_users", "moderator:manage:banned_users", "moderator:read:chat_messages", "moderator:manage:chat_messages", "moderator:read:warnings", "moderator:manage:warnings", "moderator:read:moderators", "moderator:read:vips"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-moderate-v2",
        "channel_moderate");

    public static readonly TwitchEventSubDefinition ChannelModeratorAdd = new(
        TwitchEventSubDefinitionType.ChannelModeratorAdd, "channel.moderator.add", "1",
        ["broadcaster_user_id"], ["moderation:read"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-moderator-add",
        "channel_moderator_add");

    public static readonly TwitchEventSubDefinition ChannelModeratorRemove = new(
        TwitchEventSubDefinitionType.ChannelModeratorRemove, "channel.moderator.remove", "1",
        ["broadcaster_user_id"], ["moderation:read"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-moderator-remove",
        "channel_moderator_remove");

    public static readonly TwitchEventSubDefinition ChannelPollBegin = new(
        TwitchEventSubDefinitionType.ChannelPollBegin, "channel.poll.begin", "1",
        ["broadcaster_user_id"], ["channel:read:polls", "channel:manage:polls"],
        "https://dev.twitch.tv/docs/eventsub/reference/poll/#channel-poll-begin",
        "channel_poll_begin");

    public static readonly TwitchEventSubDefinition ChannelPollEnd = new(
        TwitchEventSubDefinitionType.ChannelPollEnd, "channel.poll.end", "1",
        ["broadcaster_user_id"], ["channel:read:polls", "channel:manage:polls"],
        "https://dev.twitch.tv/docs/eventsub/reference/poll/#channel-poll-end",
        "channel_poll_end");

    public static readonly TwitchEventSubDefinition ChannelPollProgress = new(
        TwitchEventSubDefinitionType.ChannelPollProgress, "channel.poll.progress", "1",
        ["broadcaster_user_id"], ["channel:read:polls", "channel:manage:polls"],
        "https://dev.twitch.tv/docs/eventsub/reference/poll/#channel-poll-progress",
        "channel_poll_progress");

    public static readonly TwitchEventSubDefinition ChannelPredictionBegin = new(
        TwitchEventSubDefinitionType.ChannelPredictionBegin, "channel.prediction.begin", "1",
        ["broadcaster_user_id"], ["channel:read:predictions", "channel:manage:predictions"],
        "https://dev.twitch.tv/docs/eventsub/reference/prediction/#channel-prediction-begin",
        "channel_prediction_begin");

    public static readonly TwitchEventSubDefinition ChannelPredictionEnd = new(
        TwitchEventSubDefinitionType.ChannelPredictionEnd, "channel.prediction.end", "1",
        ["broadcaster_user_id"], ["channel:read:predictions", "channel:manage:predictions"],
        "https://dev.twitch.tv/docs/eventsub/reference/prediction/#channel-prediction-end",
        "channel_prediction_end");

    public static readonly TwitchEventSubDefinition ChannelPredictionLock = new(
        TwitchEventSubDefinitionType.ChannelPredictionLock, "channel.prediction.lock", "1",
        ["broadcaster_user_id"], ["channel:read:predictions", "channel:manage:predictions"],
        "https://dev.twitch.tv/docs/eventsub/reference/prediction/#channel-prediction-lock",
        "channel_prediction_lock");

    public static readonly TwitchEventSubDefinition ChannelPredictionProgress = new(
        TwitchEventSubDefinitionType.ChannelPredictionProgress, "channel.prediction.progress", "1",
        ["broadcaster_user_id"], ["channel:read:predictions", "channel:manage:predictions"],
        "https://dev.twitch.tv/docs/eventsub/reference/prediction/#channel-prediction-progress",
        "channel_prediction_progress");

    public static readonly TwitchEventSubDefinition ChannelRaid = new(
        TwitchEventSubDefinitionType.ChannelRaid, "channel.raid", "1",
        ["from_broadcaster_user_id", "to_broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-raid",
        "channel_raid");

    public static readonly TwitchEventSubDefinition ChannelSharedChatBegin = new(
        TwitchEventSubDefinitionType.ChannelSharedChatBegin, "channel.shared_chat.begin", "1",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-shared-chat-begin",
        "channel_shared_chat_session_begin");

    public static readonly TwitchEventSubDefinition ChannelSharedChatEnd = new(
        TwitchEventSubDefinitionType.ChannelSharedChatEnd, "channel.shared_chat.end", "1",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-shared-chat-end",
        "channel_shared_chat_session_end");

    public static readonly TwitchEventSubDefinition ChannelSharedChatUpdate = new(
        TwitchEventSubDefinitionType.ChannelSharedChatUpdate, "channel.shared_chat.update", "1",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/chat/#channel-shared-chat-update",
        "channel_shared_chat_session_update");

    public static readonly TwitchEventSubDefinition ChannelShieldModeBegin = new(
        TwitchEventSubDefinitionType.ChannelShieldModeBegin, "channel.shield_mode.begin", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shield_mode", "moderator:manage:shield_mode"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-shield-mode-begin",
        "shield_mode");

    public static readonly TwitchEventSubDefinition ChannelShieldModeEnd = new(
        TwitchEventSubDefinitionType.ChannelShieldModeEnd, "channel.shield_mode.end", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shield_mode", "moderator:manage:shield_mode"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-shield-mode-end",
        "shield_mode");

    public static readonly TwitchEventSubDefinition ChannelShoutoutCreate = new(
        TwitchEventSubDefinitionType.ChannelShoutoutCreate, "channel.shoutout.create", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shoutouts", "moderator:manage:shoutouts"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-shoutout-create",
        "shoutout_create");

    public static readonly TwitchEventSubDefinition ChannelShoutoutReceive = new(
        TwitchEventSubDefinitionType.ChannelShoutoutReceive, "channel.shoutout.receive", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shoutouts", "moderator:manage:shoutouts"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-shoutout-receive",
        "shoutout_received");

    public static readonly TwitchEventSubDefinition ChannelSubscribe = new(
        TwitchEventSubDefinitionType.ChannelSubscribe, "channel.subscribe", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-subscribe",
        "channel_subscribe");

    public static readonly TwitchEventSubDefinition ChannelSubscriptionEnd = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionEnd, "channel.subscription.end", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-subscription-end",
        "channel_subscription_end");

    public static readonly TwitchEventSubDefinition ChannelSubscriptionGift = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionGift, "channel.subscription.gift", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-subscription-gift",
        "channel_subscription_gift");

    public static readonly TwitchEventSubDefinition ChannelSubscriptionMessage = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionMessage, "channel.subscription.message", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-subscription-message",
        "channel_subscription_message");

    public static readonly TwitchEventSubDefinition ChannelSuspiciousUserMessage = new(
        TwitchEventSubDefinitionType.ChannelSuspiciousUserMessage, "channel.suspicious_user.message", "1",
        ["moderator_user_id", "broadcaster_user_id"], ["moderator:read:suspicious_users"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-suspicious-user-message",
        "channel_suspicious_user_message");

    public static readonly TwitchEventSubDefinition ChannelSuspiciousUserUpdate = new(
        TwitchEventSubDefinitionType.ChannelSuspiciousUserUpdate, "channel.suspicious_user.update", "1",
        ["moderator_user_id", "broadcaster_user_id"], ["moderator:read:suspicious_users"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-suspicious-user-update",
        "channel_suspicious_user_update");

    public static readonly TwitchEventSubDefinition ChannelUnban = new(
        TwitchEventSubDefinitionType.ChannelUnban, "channel.unban", "1",
        ["broadcaster_user_id"], ["channel:moderate"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-unban",
        "channel_unban");

    public static readonly TwitchEventSubDefinition ChannelUnbanRequestCreate = new(
        TwitchEventSubDefinitionType.ChannelUnbanRequestCreate, "channel.unban_request.create", "1",
        ["moderator_user_id", "broadcaster_user_id"], ["moderator:read:unban_requests", "moderator:manage:unban_requests"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-unban-request-create",
        "channel_unban_request_create");

    public static readonly TwitchEventSubDefinition ChannelUnbanRequestResolve = new(
        TwitchEventSubDefinitionType.ChannelUnbanRequestResolve, "channel.unban_request.resolve", "1",
        ["moderator_user_id", "broadcaster_user_id"], ["moderator:read:unban_requests", "moderator:manage:unban_requests"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-unban-request-resolve",
        "channel_unban_request_resolve");

    public static readonly TwitchEventSubDefinition ChannelUpdate = new(
        TwitchEventSubDefinitionType.ChannelUpdate, "channel.update", "2",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-update",
        "channel_update");

    public static readonly TwitchEventSubDefinition ChannelVipAdd = new(
        TwitchEventSubDefinitionType.ChannelVipAdd, "channel.vip.add", "1",
        ["broadcaster_user_id"], ["channel:read:vips", "channel:manage:vips"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-vip-add",
        "channel_vip_add");

    public static readonly TwitchEventSubDefinition ChannelVipRemove = new(
        TwitchEventSubDefinitionType.ChannelVipRemove, "channel.vip.remove", "1",
        ["broadcaster_user_id"], ["channel:read:vips", "channel:manage:vips"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel/#channel-vip-remove",
        "channel_vip_remove");

    public static readonly TwitchEventSubDefinition ChannelWarningAcknowledge = new(
        TwitchEventSubDefinitionType.ChannelWarningAcknowledge, "channel.warning.acknowledge", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:warnings", "moderator:manage:warnings"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-warning-acknowledge",
        "channel_warning_acknowledge");

    public static readonly TwitchEventSubDefinition ChannelWarningSend = new(
        TwitchEventSubDefinitionType.ChannelWarningSend, "channel.warning.send", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:warnings", "moderator:manage:warnings"],
        "https://dev.twitch.tv/docs/eventsub/reference/channel-moderation/#channel-warning-send",
        "channel_warning_send");

    public static readonly TwitchEventSubDefinition ConduitShardDisabled = new(
        TwitchEventSubDefinitionType.ConduitShardDisabled, "conduit.shard.disabled", "1",
        ["client_id", "conduit_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/conduit/#conduit-shard-disabled",
        "conduit_shard_disabled");

    public static readonly TwitchEventSubDefinition DropEntitlementGrant = new(
        TwitchEventSubDefinitionType.DropEntitlementGrant, "drop.entitlement.grant", "1",
        ["organization_id", "category_id", "campaign_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/drop/#drop-entitlement-grant",
        "drop_entitlement_grant");

    public static readonly TwitchEventSubDefinition ExtensionBitsTransactionCreate = new(
        TwitchEventSubDefinitionType.ExtensionBitsTransactionCreate, "extension.bits_transaction.create", "1",
        ["extension_client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/extension/#extension-bits-transaction-create",
        "extension_bits_transaction_create");

    public static readonly TwitchEventSubDefinition StreamOffline = new(
        TwitchEventSubDefinitionType.StreamOffline, "stream.offline", "1",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/stream/#stream-offline",
        "stream_offline");

    public static readonly TwitchEventSubDefinition StreamOnline = new(
        TwitchEventSubDefinitionType.StreamOnline, "stream.online", "1",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/stream/#stream-online",
        "stream_online");

    public static readonly TwitchEventSubDefinition UserAuthorizationGrant = new(
        TwitchEventSubDefinitionType.UserAuthorizationGrant, "user.authorization.grant", "1",
        ["client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/user/#user-authorization-grant",
        "user_authorization_grant");

    public static readonly TwitchEventSubDefinition UserAuthorizationRevoke = new(
        TwitchEventSubDefinitionType.UserAuthorizationRevoke, "user.authorization.revoke", "1",
        ["client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/user/#user-authorization-revoke",
        "user_authorization_revoke");

    public static readonly TwitchEventSubDefinition UserUpdate = new(
        TwitchEventSubDefinitionType.UserUpdate, "user.update", "1",
        ["user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/reference/user/#user-update",
        "user_update");

    public static readonly TwitchEventSubDefinition UserWhisperMessage = new(
        TwitchEventSubDefinitionType.UserWhisperMessage, "user.whisper.message", "1",
        ["user_id"], ["user:read:whispers", "user:manage:whispers"],
        "https://dev.twitch.tv/docs/eventsub/reference/user/#user-whisper-message",
        "whisper_received");

    #endregion

    public static readonly List<TwitchEventSubDefinition> All =
    [
        AutomodMessageHold, AutomodMessageHoldV2, AutomodMessageUpdate, AutomodMessageUpdateV2, AutomodSettingsUpdate,
        AutomodTermsUpdate, ChannelAdBreakBegin, ChannelBan, ChannelBitsUse,
        ChannelChannelPointsAutomaticRewardRedemptionAdd, ChannelChannelPointsAutomaticRewardRedemptionAddV2,
        ChannelChannelPointsCustomRewardAdd, ChannelChannelPointsCustomRewardRemove,
        ChannelChannelPointsCustomRewardUpdate, ChannelChannelPointsCustomRewardRedemptionAdd,
        ChannelChannelPointsCustomRewardRedemptionUpdate, ChannelCharityCampaignDonate, ChannelCharityCampaignProgress,
        ChannelCharityCampaignStart, ChannelCharityCampaignStop, ChannelChatClear, ChannelChatClearUserMessages,
        ChannelChatMessage, ChannelChatMessageDelete, ChannelChatNotification, ChannelChatUserMessageHold,
        ChannelChatUserMessageUpdate, ChannelChatSettingsUpdate, ChannelCheer, ChannelCustomPowerUpRedemptionAdd,
        ChannelFollow, ChannelGoalBegin, ChannelGoalEnd, ChannelGoalProgress, ChannelGuestStarGuestUpdate,
        ChannelGuestStarSessionBegin, ChannelGuestStarSessionEnd, ChannelGuestStarSettingsUpdate, ChannelHypeTrainBegin,
        ChannelHypeTrainEnd, ChannelHypeTrainProgress, ChannelModerate, ChannelModerateV2, ChannelModeratorAdd,
        ChannelModeratorRemove, ChannelPollBegin, ChannelPollEnd, ChannelPollProgress, ChannelPredictionBegin,
        ChannelPredictionEnd, ChannelPredictionLock, ChannelPredictionProgress, ChannelRaid, ChannelSharedChatBegin,
        ChannelSharedChatEnd, ChannelSharedChatUpdate, ChannelShieldModeBegin, ChannelShieldModeEnd,
        ChannelShoutoutCreate, ChannelShoutoutReceive, ChannelSubscribe, ChannelSubscriptionEnd, ChannelSubscriptionGift,
        ChannelSubscriptionMessage, ChannelSuspiciousUserMessage, ChannelSuspiciousUserUpdate, ChannelUnban,
        ChannelUnbanRequestCreate, ChannelUnbanRequestResolve, ChannelUpdate, ChannelVipAdd, ChannelVipRemove,
        ChannelWarningAcknowledge, ChannelWarningSend, ConduitShardDisabled, DropEntitlementGrant,
        ExtensionBitsTransactionCreate, StreamOffline, StreamOnline, UserAuthorizationGrant, UserAuthorizationRevoke,
        UserUpdate, UserWhisperMessage
    ];
}
