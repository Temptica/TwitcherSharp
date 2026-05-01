using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventSubDefinition() : RefCounted, ITwitcherSharp<TwitchEventSubDefinition>
{
    private GodotObject _data;

    public TwitchEventSubDefinitionType Type { get; set; }
    public StringName Value { get; set; }
    public StringName Version { get; set; }
    public List<StringName> Conditions { get; set; }
    public List<StringName> Scopes { get; set; }
    public string DocumentationLink { get; set; }
    public string GetReadableName() => $"{Value} (v{Version})";
    public GDScript Script { get; set; }

    public static TwitchEventSubDefinition FromObject(GodotObject data)
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

        var conditions = new Godot.Collections.Array<StringName>(Conditions ?? []);
        var scopes = new Godot.Collections.Array<StringName>(Scopes ?? []);
        var data = script.New((int)Type, Value, Version, conditions, scopes, DocumentationLink, Script)
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
        TwitchEventSubDefinitionType.AutomodMessageHold,
        "automod.message.hold", "1", ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodmessagehold", "automod_message_hold");

    public static readonly TwitchEventSubDefinition AutomodMessageUpdate = new(
        TwitchEventSubDefinitionType.AutomodMessageUpdate,
        "automod.message.update", "1", ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodmessageupdate", "automod_message_update");

    public static readonly TwitchEventSubDefinition AutomodSettingsUpdate = new(
        TwitchEventSubDefinitionType.AutomodSettingsUpdate,
        "automod.settings.update", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:automod_settings"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodsettingsupdate",
        "automod_settings_update");

    public static readonly TwitchEventSubDefinition AutomodTermsUpdate = new(
        TwitchEventSubDefinitionType.AutomodTermsUpdate,
        "automod.terms.update", "1", ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodtermsupdate", "automod_terms_update");

    public static readonly TwitchEventSubDefinition ChannelUpdate = new(TwitchEventSubDefinitionType.ChannelUpdate,
        "channel.update",
        "2", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelupdate", "channel_update");

    public static readonly TwitchEventSubDefinition ChannelFollow = new(TwitchEventSubDefinitionType.ChannelFollow,
        "channel.follow",
        "2", ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:followers"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelfollow", "channel_follow");

    public static readonly TwitchEventSubDefinition ChannelAdBreakBegin = new(
        TwitchEventSubDefinitionType.ChannelAdBreakBegin,
        "channel.ad_break.begin", "1", ["broadcaster_user_id"], ["channel:read:ads"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelad_breakbegin",
        "channel_ad_break_begin");

    public static readonly TwitchEventSubDefinition ChannelChatClear = new(
        TwitchEventSubDefinitionType.ChannelChatClear,
        "channel.chat.clear", "1", ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatclear", "channel_chat_clear");

    public static readonly TwitchEventSubDefinition ChannelChatClearUserMessages = new(
        TwitchEventSubDefinitionType.ChannelChatClearUserMessages, "channel.chat.clear_user_messages", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatclear_user_messages",
        "channel_chat_clear_user_messages");

    public static readonly TwitchEventSubDefinition ChannelChatMessage = new(
        TwitchEventSubDefinitionType.ChannelChatMessage,
        "channel.chat.message", "1", ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatmessage", "channel_chat_message");

    public static readonly TwitchEventSubDefinition ChannelChatMessageDelete = new(
        TwitchEventSubDefinitionType.ChannelChatMessageDelete, "channel.chat.message_delete", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatmessage_delete",
        "channel_chat_message_delete");

    public static readonly TwitchEventSubDefinition ChannelChatNotification = new(
        TwitchEventSubDefinitionType.ChannelChatNotification, "channel.chat.notification", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatnotification",
        "channel_chat_notification");

    public static readonly TwitchEventSubDefinition ChannelChatSettingsUpdate = new(
        TwitchEventSubDefinitionType.ChannelChatSettingsUpdate, "channel.chat_settings.update", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchat_settingsupdate",
        "channel_chat_settings_update");

    public static readonly TwitchEventSubDefinition ChannelChatUserMessageHold = new(
        TwitchEventSubDefinitionType.ChannelChatUserMessageHold, "channel.chat.user_message_hold", "1",
        ["broadcaster_user_id", "user_id"], ["user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatuser_message_hold",
        "channel_chat_user_message_hold");

    public static readonly TwitchEventSubDefinition ChannelChatUserMessageUpdate = new(
        TwitchEventSubDefinitionType.ChannelChatUserMessageUpdate, "channel.chat.user_message_update", "1",
        ["broadcaster_user_id", "user_id"], ["user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatuser_message_update",
        "channel_chat_user_message_update");

    public static readonly TwitchEventSubDefinition ChannelSubscribe = new(
        TwitchEventSubDefinitionType.ChannelSubscribe,
        "channel.subscribe", "1", ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscribe", "channel_subscribe");

    public static readonly TwitchEventSubDefinition ChannelSubscriptionEnd = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionEnd, "channel.subscription.end", "1", ["broadcaster_user_id"],
        ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscriptionend",
        "channel_subscription_end");

    public static readonly TwitchEventSubDefinition ChannelSubscriptionGift = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionGift, "channel.subscription.gift", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscriptiongift",
        "channel_subscription_gift");

    public static readonly TwitchEventSubDefinition ChannelSubscriptionMessage = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionMessage, "channel.subscription.message", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscriptionmessage",
        "channel_subscription_message");

    public static readonly TwitchEventSubDefinition ChannelCheer = new(TwitchEventSubDefinitionType.ChannelCheer,
        "channel.cheer",
        "1", ["broadcaster_user_id"], ["bits:read"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcheer", "channel_cheer");

    public static readonly TwitchEventSubDefinition ChannelRaid = new(TwitchEventSubDefinitionType.ChannelRaid,
        "channel.raid",
        "1",
        ["to_broadcaster_user_id"], [], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelraid",
        "channel_raid");

    public static readonly TwitchEventSubDefinition ChannelBan = new(TwitchEventSubDefinitionType.ChannelBan,
        "channel.ban", "1",
        ["broadcaster_user_id"], ["channel:moderate"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelban", "channel_ban");

    public static readonly TwitchEventSubDefinition ChannelUnban = new(TwitchEventSubDefinitionType.ChannelUnban,
        "channel.unban",
        "1", ["broadcaster_user_id"], ["channel:moderate"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelunban", "channel_unban");

    public static readonly TwitchEventSubDefinition ChannelUnbanRequestCreate = new(
        TwitchEventSubDefinitionType.ChannelUnbanRequestCreate, "channel.unban_request.create", "1",
        ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:unban_requests", "moderator:manage:unban_requests"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelunban_requestcreate",
        "channel_unban_request_create");

    public static readonly TwitchEventSubDefinition ChannelUnbanRequestResolve = new(
        TwitchEventSubDefinitionType.ChannelUnbanRequestResolve, "channel.unban_request.resolve", "1",
        ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:unban_requests", "moderator:manage:unban_requests"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelunban_requestresolve",
        "channel_unban_request_resolve");

    public static readonly TwitchEventSubDefinition ChannelModerate = new(TwitchEventSubDefinitionType.ChannelModerate,
        "channel.moderate", "1", ["broadcaster_user_id", "moderator_user_id"],
        [
            "moderator:manage:banned_users", "moderator:manage:blocked_terms", "moderator:read:banned_users",
            "moderator:manage:chat_messages", "moderator:manage:unban_requests", "moderator:manage:chat_settings",
            "moderator:read:unban_requests", "moderator:read:chat_settings", "moderator:read:vips",
            "moderator:read:chat_messages", "moderator:read:blocked_terms", "moderator:read:moderators"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderate", "channel_moderate");

    public static readonly TwitchEventSubDefinition ChannelModerateV2 = new(
        TwitchEventSubDefinitionType.ChannelModerateV2,
        "channel.moderate", "2", ["broadcaster_user_id", "moderator_user_id"],
        [
            "moderator:manage:banned_users", "moderator:manage:blocked_terms", "moderator:read:banned_users",
            "moderator:manage:chat_messages", "moderator:manage:unban_requests", "moderator:manage:warnings",
            "moderator:manage:chat_settings", "moderator:read:unban_requests", "moderator:read:chat_settings",
            "moderator:read:vips", "moderator:read:warnings", "moderator:read:chat_messages",
            "moderator:read:blocked_terms", "moderator:read:moderators"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderate-v2", "channel_moderate");

    public static readonly TwitchEventSubDefinition ChannelModeratorAdd = new(
        TwitchEventSubDefinitionType.ChannelModeratorAdd,
        "channel.moderator.add", "1", ["broadcaster_user_id"], ["moderation:read"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderatoradd",
        "channel_moderator_add");

    public static readonly TwitchEventSubDefinition ChannelModeratorRemove = new(
        TwitchEventSubDefinitionType.ChannelModeratorRemove, "channel.moderator.remove", "1", ["broadcaster_user_id"],
        ["moderation:read"], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderatorremove",
        "channel_moderator_remove");

    public static readonly TwitchEventSubDefinition ChannelGuestStarSessionBegin = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSessionBegin, "channel.guest_star_session.begin", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_sessionbegin",
        "channel_guest_star_session_begin");

    public static readonly TwitchEventSubDefinition ChannelGuestStarSessionEnd = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSessionEnd, "channel.guest_star_session.end", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_sessionend",
        "channel_guest_star_session_end");

    public static readonly TwitchEventSubDefinition ChannelGuestStarGuestUpdate = new(
        TwitchEventSubDefinitionType.ChannelGuestStarGuestUpdate, "channel.guest_star_guest.update", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_guestupdate",
        "channel_guest_star_guest_update");

    public static readonly TwitchEventSubDefinition ChannelGuestStarSettingsUpdate = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSettingsUpdate, "channel.guest_star_settings.update", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_settingsupdate",
        "channel_guest_star_settings_update");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsAutomaticRewardRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsAutomaticRewardRedemptionAdd,
        "channel.channel_points_automatic_reward_redemption.add", "1", ["broadcaster_user_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_automatic_reward_redemptionadd",
        "channel_points_automatic_reward_redemption_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardAdd,
        "channel.channel_points_custom_reward.add", "1", ["broadcaster_user_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_rewardadd",
        "channel_points_custom_reward_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardUpdate = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardUpdate,
        "channel.channel_points_custom_reward.update", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_rewardupdate",
        "channel_points_custom_reward_update");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardRemove = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRemove,
        "channel.channel_points_custom_reward.remove", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_rewardremove",
        "channel_points_custom_reward_remove");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRedemptionAdd,
        "channel.channel_points_custom_reward_redemption.add", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_reward_redemptionadd",
        "channel_points_custom_reward_redemption_add");

    public static readonly TwitchEventSubDefinition ChannelChannelPointsCustomRewardRedemptionUpdate = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRedemptionUpdate,
        "channel.channel_points_custom_reward_redemption.update", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_reward_redemptionupdate",
        "channel_points_custom_reward_redemption_update");

    public static readonly TwitchEventSubDefinition ChannelPollBegin = new(
        TwitchEventSubDefinitionType.ChannelPollBegin,
        "channel.poll.begin", "1", ["broadcaster_user_id"], ["channel:manage:polls", "channel:read:polls"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpollbegin", "channel_poll_begin");

    public static readonly TwitchEventSubDefinition ChannelPollProgress = new(
        TwitchEventSubDefinitionType.ChannelPollProgress,
        "channel.poll.progress", "1", ["broadcaster_user_id"], ["channel:manage:polls", "channel:read:polls"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpollprogress",
        "channel_poll_progress");

    public static readonly TwitchEventSubDefinition ChannelPollEnd = new(TwitchEventSubDefinitionType.ChannelPollEnd,
        "channel.poll.end", "1", ["broadcaster_user_id"], ["channel:manage:polls", "channel:read:polls"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpollend", "channel_poll_end");

    public static readonly TwitchEventSubDefinition ChannelPredictionBegin = new(
        TwitchEventSubDefinitionType.ChannelPredictionBegin, "channel.prediction.begin", "1", ["broadcaster_user_id"],
        ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionbegin",
        "channel_prediction_begin");

    public static readonly TwitchEventSubDefinition ChannelPredictionProgress = new(
        TwitchEventSubDefinitionType.ChannelPredictionProgress, "channel.prediction.progress", "1",
        ["broadcaster_user_id"], ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionprogress",
        "channel_prediction_progress");

    public static readonly TwitchEventSubDefinition ChannelPredictionLock = new(
        TwitchEventSubDefinitionType.ChannelPredictionLock,
        "channel.prediction.lock", "1", ["broadcaster_user_id"],
        ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionlock",
        "channel_prediction_lock");

    public static readonly TwitchEventSubDefinition ChannelPredictionEnd = new(
        TwitchEventSubDefinitionType.ChannelPredictionEnd,
        "channel.prediction.end", "1", ["broadcaster_user_id"],
        ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionend",
        "channel_prediction_end");

    public static readonly TwitchEventSubDefinition ChannelSuspiciousUserUpdate = new(
        TwitchEventSubDefinitionType.ChannelSuspiciousUserUpdate, "channel.suspicious_user.update", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:suspicious_users"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsuspicious_userupdate",
        "channel_suspicious_user_update");

    public static readonly TwitchEventSubDefinition ChannelSuspiciousUserMessage = new(
        TwitchEventSubDefinitionType.ChannelSuspiciousUserMessage, "channel.suspicious_user.message", "1",
        ["moderator_user_id", "broadcaster_user_id"], ["moderator:read:suspicious_users"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsuspicious_usermessage",
        "channel_suspicious_user_message");

    public static readonly TwitchEventSubDefinition ChannelVipAdd = new(TwitchEventSubDefinitionType.ChannelVipAdd,
        "channel.vip.add", "1", ["broadcaster_user_id"], ["channel:manage:vips", "channel:read:vips"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelvipadd", "channel_vip_add");

    public static readonly TwitchEventSubDefinition ChannelVipRemove = new(
        TwitchEventSubDefinitionType.ChannelVipRemove,
        "channel.vip.remove", "1", ["broadcaster_user_id"], ["channel:manage:vips", "channel:read:vips"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelvipremove", "channel_vip_remove");

    public static readonly TwitchEventSubDefinition ChannelWarningAcknowledge = new(
        TwitchEventSubDefinitionType.ChannelWarningAcknowledge, "channel.warning.acknowledge", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:warnings", "moderator:read:warnings"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelwarningacknowledge",
        "channel_warning_acknowledge");

    public static readonly TwitchEventSubDefinition ChannelWarningSend = new(
        TwitchEventSubDefinitionType.ChannelWarningSend,
        "channel.warning.send", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:manage:warnings", "moderator:read:warnings"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelwarningsend", "channel_warning_send");

    public static readonly TwitchEventSubDefinition ChannelHypeTrainBegin = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainBegin, "channel.hype_train.begin", "2", ["broadcaster_user_id"],
        ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelhype_trainbegin",
        "hype_train_begin");

    public static readonly TwitchEventSubDefinition ChannelHypeTrainProgress = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainProgress, "channel.hype_train.progress", "2",
        ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelhype_trainprogress",
        "hype_train_progress");

    public static readonly TwitchEventSubDefinition ChannelHypeTrainEnd = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainEnd,
        "channel.hype_train.end", "2", ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelhype_trainend",
        "hype_train_end");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignDonate = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignDonate, "channel.charity_campaign.donate", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaigndonate",
        "charity_donation");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignStart = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignStart, "channel.charity_campaign.start", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaignstart",
        "charity_campaign_start");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignProgress = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignProgress, "channel.charity_campaign.progress", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaignprogress",
        "charity_campaign_progress");

    public static readonly TwitchEventSubDefinition ChannelCharityCampaignStop = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignStop, "channel.charity_campaign.stop", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaignstop",
        "charity_campaign_stop");

    public static readonly TwitchEventSubDefinition ChannelSharedChatBegin =
        new(TwitchEventSubDefinitionType.ChannelSharedChatBegin, "channel.shared_chat.begin", "beta",
            ["broadcaster_user_id"], [],
            "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshared_chatbegin",
            "channel_shared_chat_session_begin");

    public static readonly TwitchEventSubDefinition ChannelSharedChatUpdate = new(
        TwitchEventSubDefinitionType.ChannelSharedChatUpdate, "channel.shared_chat.update", "beta",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshared_chatupdate",
        "channel_shared_chat_session_update");

    public static readonly TwitchEventSubDefinition ChannelSharedChatEnd = new(
        TwitchEventSubDefinitionType.ChannelSharedChatEnd,
        "channel.shared_chat.end", "beta", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshared_chatend",
        "channel_shared_chat_session_end");

    public static readonly TwitchEventSubDefinition ChannelShieldModeBegin = new(
        TwitchEventSubDefinitionType.ChannelShieldModeBegin, "channel.shield_mode.begin", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shield_mode", "moderator:manage:shield_mode"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshield_modebegin",
        "shield_mode");

    public static readonly TwitchEventSubDefinition ChannelShieldModeEnd = new(
        TwitchEventSubDefinitionType.ChannelShieldModeEnd,
        "channel.shield_mode.end", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:shield_mode", "moderator:manage:shield_mode"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshield_modeend",
        "shield_mode");

    public static readonly TwitchEventSubDefinition ChannelShoutoutCreate = new(
        TwitchEventSubDefinitionType.ChannelShoutoutCreate,
        "channel.shoutout.create", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:shoutouts", "moderator:manage:shoutouts"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshoutoutcreate",
        "shoutout_create");

    public static readonly TwitchEventSubDefinition ChannelShoutoutReceive = new(
        TwitchEventSubDefinitionType.ChannelShoutoutReceive, "channel.shoutout.receive", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shoutouts", "moderator:manage:shoutouts"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshoutoutreceive",
        "shoutout_received");

    public static readonly TwitchEventSubDefinition ConduitShardDisabled = new(
        TwitchEventSubDefinitionType.ConduitShardDisabled,
        "conduit.shard.disabled", "1", ["client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#conduitsharddisabled",
        "conduit_shard_disabled");

    public static readonly TwitchEventSubDefinition DropEntitlementGrant = new(
        TwitchEventSubDefinitionType.DropEntitlementGrant,
        "drop.entitlement.grant", "1", ["organization_id", "category_id", "campaign_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#dropentitlementgrant",
        "drop_entitlement_grant");

    public static readonly TwitchEventSubDefinition ExtensionBitsTransactionCreate = new(
        TwitchEventSubDefinitionType.ExtensionBitsTransactionCreate, "extension.bits_transaction.create", "1",
        ["extension_client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#extensionbits_transactioncreate",
        "extension_bits_transaction_create");

    public static readonly TwitchEventSubDefinition ChannelGoalBegin = new(
        TwitchEventSubDefinitionType.ChannelGoalBegin,
        "channel.goal.begin", "1", ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelgoalbegin", "goals");

    public static readonly TwitchEventSubDefinition ChannelGoalProgress = new(
        TwitchEventSubDefinitionType.ChannelGoalProgress,
        "channel.goal.progress", "1", ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelgoalprogress",
        "goals");

    public static readonly TwitchEventSubDefinition ChannelGoalEnd = new(TwitchEventSubDefinitionType.ChannelGoalEnd,
        "channel.goal.end", "1", ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelgoalend", "goals");

    public static readonly TwitchEventSubDefinition StreamOnline = new(TwitchEventSubDefinitionType.StreamOnline,
        "stream.online",
        "1", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#streamonline", "stream_online");

    public static readonly TwitchEventSubDefinition StreamOffline = new(TwitchEventSubDefinitionType.StreamOffline,
        "stream.offline",
        "1", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#streamoffline", "stream_offline");

    public static readonly TwitchEventSubDefinition UserAuthorizationGrant =
        new(TwitchEventSubDefinitionType.UserAuthorizationGrant, "user.authorization.grant", "1", ["client_id"], [],
            "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userauthorizationgrant",
            "user_authorization_grant");

    public static readonly TwitchEventSubDefinition UserAuthorizationRevoke =
        new(TwitchEventSubDefinitionType.UserAuthorizationRevoke, "user.authorization.revoke", "1", ["client_id"], [],
            "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userauthorizationrevoke",
            "user_authorization_revoke");

    public static readonly TwitchEventSubDefinition UserUpdate = new(TwitchEventSubDefinitionType.UserUpdate,
        "user.update", "1",
        ["user_id"], ["user:read:email"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userupdate", "user_update");

    public static readonly TwitchEventSubDefinition UserWhisperMessage = new(
        TwitchEventSubDefinitionType.UserWhisperMessage,
        "user.whisper.message", "1", ["user_id"], ["user:manage:whispers", "user:read:whispers"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userwhispermessage", "whisper_received");

    #endregion

    public static readonly List<TwitchEventSubDefinition> All =
    [
        AutomodMessageHold, AutomodMessageUpdate, AutomodSettingsUpdate, AutomodTermsUpdate, ChannelUpdate,
        ChannelFollow, ChannelAdBreakBegin, ChannelChatClear, ChannelChatClearUserMessages, ChannelChatMessage,
        ChannelChatMessageDelete, ChannelChatNotification, ChannelChatSettingsUpdate, ChannelChatUserMessageHold,
        ChannelChatUserMessageUpdate, ChannelSubscribe, ChannelSharedChatEnd, ChannelSubscriptionGift,
        ChannelSubscriptionMessage, ChannelCheer, ChannelRaid, ChannelBan, ChannelUnban, ChannelUnbanRequestCreate,
        ChannelUnbanRequestResolve, ChannelModerate, ChannelModerateV2, ChannelModeratorAdd, ChannelModeratorRemove,
        ChannelGuestStarSessionBegin, ChannelGuestStarGuestUpdate,
        ChannelGuestStarSettingsUpdate, ChannelChannelPointsAutomaticRewardRedemptionAdd,
        ChannelChannelPointsCustomRewardAdd, ChannelChannelPointsCustomRewardUpdate,
        ChannelChannelPointsCustomRewardRemove, ChannelChannelPointsCustomRewardRedemptionAdd,
        ChannelChannelPointsCustomRewardRedemptionUpdate, ChannelPollBegin, ChannelPollProgress, ChannelPollEnd,
        ChannelPredictionBegin, ChannelPredictionProgress, ChannelPredictionEnd, ChannelSuspiciousUserUpdate,
        ChannelSuspiciousUserMessage, ChannelVipAdd, ChannelVipRemove, ChannelWarningAcknowledge, ChannelWarningSend,
        ChannelHypeTrainBegin, ChannelHypeTrainProgress, ChannelHypeTrainEnd, ChannelCharityCampaignDonate,
        ChannelCharityCampaignStart, ChannelCharityCampaignStop, ChannelSharedChatBegin, ChannelSharedChatUpdate,
        ChannelShieldModeBegin, ChannelShieldModeEnd, ChannelShoutoutCreate, ChannelShoutoutReceive,
        ConduitShardDisabled, DropEntitlementGrant, ExtensionBitsTransactionCreate, ChannelGoalBegin, ChannelGoalEnd,
        StreamOnline, StreamOffline, UserAuthorizationGrant, UserAuthorizationRevoke, UserUpdate, UserWhisperMessage,
        ChannelGoalProgress, ChannelCharityCampaignProgress, ChannelPredictionLock, ChannelGuestStarSessionEnd,
        ChannelSubscriptionEnd
    ];
}