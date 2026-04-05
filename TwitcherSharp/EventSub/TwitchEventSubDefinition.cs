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
        var data = script.New((int)Type, Value, Version, conditions, scopes, DocumentationLink)
            .AsGodotObject();
        return data;
    }

    public TwitchEventSubDefinition(TwitchEventSubDefinitionType type, string value, string version,
        List<StringName> conditions, List<StringName> scopes, string documentationLink) : this()
    {
        Type = type;
        Value = value;
        Version = version;
        Conditions = conditions;
        Scopes = scopes;
        DocumentationLink = documentationLink;
    }

    #region Static Definitions

    public static TwitchEventSubDefinition AutomodMessageHold = new(TwitchEventSubDefinitionType.AutomodMessageHold,
        "automod.message.hold", "1", ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodmessagehold");

    public static TwitchEventSubDefinition AutomodMessageUpdate = new(TwitchEventSubDefinitionType.AutomodMessageUpdate,
        "automod.message.update", "1", ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodmessageupdate");

    public static TwitchEventSubDefinition AutomodSettingsUpdate = new(
        TwitchEventSubDefinitionType.AutomodSettingsUpdate,
        "automod.settings.update", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:automod_settings"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodsettingsupdate");

    public static TwitchEventSubDefinition AutomodTermsUpdate = new(TwitchEventSubDefinitionType.AutomodTermsUpdate,
        "automod.terms.update", "1", ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:automod"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#automodtermsupdate");

    public static TwitchEventSubDefinition ChannelUpdate = new(TwitchEventSubDefinitionType.ChannelUpdate,
        "channel.update",
        "2", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelupdate");

    public static TwitchEventSubDefinition ChannelFollow = new(TwitchEventSubDefinitionType.ChannelFollow,
        "channel.follow",
        "2", ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:followers"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelfollow");

    public static TwitchEventSubDefinition ChannelAdBreakBegin = new(TwitchEventSubDefinitionType.ChannelAdBreakBegin,
        "channel.ad_break.begin", "1", ["broadcaster_user_id"], ["channel:read:ads"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelad_breakbegin");

    public static TwitchEventSubDefinition ChannelChatClear = new(TwitchEventSubDefinitionType.ChannelChatClear,
        "channel.chat.clear", "1", ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatclear");

    public static TwitchEventSubDefinition ChannelChatClearUserMessages = new(
        TwitchEventSubDefinitionType.ChannelChatClearUserMessages, "channel.chat.clear_user_messages", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatclear_user_messages");

    public static TwitchEventSubDefinition ChannelChatMessage = new(TwitchEventSubDefinitionType.ChannelChatMessage,
        "channel.chat.message", "1", ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatmessage");

    public static TwitchEventSubDefinition ChannelChatMessageDelete = new(
        TwitchEventSubDefinitionType.ChannelChatMessageDelete, "channel.chat.message_delete", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatmessage_delete");

    public static TwitchEventSubDefinition ChannelChatNotification = new(
        TwitchEventSubDefinitionType.ChannelChatNotification, "channel.chat.notification", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatnotification");

    public static TwitchEventSubDefinition ChannelChatSettingsUpdate = new(
        TwitchEventSubDefinitionType.ChannelChatSettingsUpdate, "channel.chat_settings.update", "1",
        ["broadcaster_user_id", "user_id"], ["channel:bot", "user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchat_settingsupdate");

    public static TwitchEventSubDefinition ChannelChatUserMessageHold = new(
        TwitchEventSubDefinitionType.ChannelChatUserMessageHold, "channel.chat.user_message_hold", "1",
        ["broadcaster_user_id", "user_id"], ["user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatuser_message_hold");

    public static TwitchEventSubDefinition ChannelChatUserMessageUpdate = new(
        TwitchEventSubDefinitionType.ChannelChatUserMessageUpdate, "channel.chat.user_message_update", "1",
        ["broadcaster_user_id", "user_id"], ["user:bot", "user:read:chat"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchatuser_message_update");

    public static TwitchEventSubDefinition ChannelSubscribe = new(TwitchEventSubDefinitionType.ChannelSubscribe,
        "channel.subscribe", "1", ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscribe");

    public static TwitchEventSubDefinition ChannelSubscriptionEnd = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionEnd, "channel.subscription.end", "1", ["broadcaster_user_id"],
        ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscriptionend");

    public static TwitchEventSubDefinition ChannelSubscriptionGift = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionGift, "channel.subscription.gift", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscriptiongift");

    public static TwitchEventSubDefinition ChannelSubscriptionMessage = new(
        TwitchEventSubDefinitionType.ChannelSubscriptionMessage, "channel.subscription.message", "1",
        ["broadcaster_user_id"], ["channel:read:subscriptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsubscriptionmessage");

    public static TwitchEventSubDefinition ChannelCheer = new(TwitchEventSubDefinitionType.ChannelCheer,
        "channel.cheer",
        "1", ["broadcaster_user_id"], ["bits:read"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcheer");

    public static TwitchEventSubDefinition ChannelRaid = new(TwitchEventSubDefinitionType.ChannelRaid, "channel.raid",
        "1",
        ["to_broadcaster_user_id"], [], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelraid");

    public static TwitchEventSubDefinition ChannelBan = new(TwitchEventSubDefinitionType.ChannelBan, "channel.ban", "1",
        ["broadcaster_user_id"], ["channel:moderate"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelban");

    public static TwitchEventSubDefinition ChannelUnban = new(TwitchEventSubDefinitionType.ChannelUnban,
        "channel.unban",
        "1", ["broadcaster_user_id"], ["channel:moderate"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelunban");

    public static TwitchEventSubDefinition ChannelUnbanRequestCreate = new(
        TwitchEventSubDefinitionType.ChannelUnbanRequestCreate, "channel.unban_request.create", "1",
        ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:unban_requests", "moderator:manage:unban_requests"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelunban_requestcreate");

    public static TwitchEventSubDefinition ChannelUnbanRequestResolve = new(
        TwitchEventSubDefinitionType.ChannelUnbanRequestResolve, "channel.unban_request.resolve", "1",
        ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:unban_requests", "moderator:manage:unban_requests"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelunban_requestresolve");

    public static TwitchEventSubDefinition ChannelModerate = new(TwitchEventSubDefinitionType.ChannelModerate,
        "channel.moderate", "1", ["broadcaster_user_id", "moderator_user_id"],
        [
            "moderator:manage:banned_users", "moderator:manage:blocked_terms", "moderator:read:banned_users",
            "moderator:manage:chat_messages", "moderator:manage:unban_requests", "moderator:manage:chat_settings",
            "moderator:read:unban_requests", "moderator:read:chat_settings", "moderator:read:vips",
            "moderator:read:chat_messages", "moderator:read:blocked_terms", "moderator:read:moderators"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderate");

    public static TwitchEventSubDefinition ChannelModerateV2 = new(TwitchEventSubDefinitionType.ChannelModerateV2,
        "channel.moderate", "2", ["broadcaster_user_id", "moderator_user_id"],
        [
            "moderator:manage:banned_users", "moderator:manage:blocked_terms", "moderator:read:banned_users",
            "moderator:manage:chat_messages", "moderator:manage:unban_requests", "moderator:manage:warnings",
            "moderator:manage:chat_settings", "moderator:read:unban_requests", "moderator:read:chat_settings",
            "moderator:read:vips", "moderator:read:warnings", "moderator:read:chat_messages",
            "moderator:read:blocked_terms", "moderator:read:moderators"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderate-v2");

    public static TwitchEventSubDefinition ChannelModeratorAdd = new(TwitchEventSubDefinitionType.ChannelModeratorAdd,
        "channel.moderator.add", "1", ["broadcaster_user_id"], ["moderation:read"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderatoradd");

    public static TwitchEventSubDefinition ChannelModeratorRemove = new(
        TwitchEventSubDefinitionType.ChannelModeratorRemove, "channel.moderator.remove", "1", ["broadcaster_user_id"],
        ["moderation:read"], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelmoderatorremove");

    public static TwitchEventSubDefinition ChannelGuestStarSessionBegin = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSessionBegin, "channel.guest_star_session.begin", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_sessionbegin");

    public static TwitchEventSubDefinition ChannelGuestStarSessionEnd = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSessionEnd, "channel.guest_star_session.end", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_sessionend");

    public static TwitchEventSubDefinition ChannelGuestStarGuestUpdate = new(
        TwitchEventSubDefinitionType.ChannelGuestStarGuestUpdate, "channel.guest_star_guest.update", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_guestupdate");

    public static TwitchEventSubDefinition ChannelGuestStarSettingsUpdate = new(
        TwitchEventSubDefinitionType.ChannelGuestStarSettingsUpdate, "channel.guest_star_settings.update", "beta",
        ["broadcaster_user_id", "moderator_user_id"],
        [
            "channel:read:guest_star", "moderator:manage:guest_star", "moderator:read:guest_star",
            "channel:manage:guest_star"
        ], "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelguest_star_settingsupdate");

    public static TwitchEventSubDefinition ChannelChannelPointsAutomaticRewardRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsAutomaticRewardRedemptionAdd,
        "channel.channel_points_automatic_reward_redemption.add", "1", ["broadcaster_user_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_automatic_reward_redemptionadd");

    public static TwitchEventSubDefinition ChannelChannelPointsCustomRewardAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardAdd,
        "channel.channel_points_custom_reward.add", "1", ["broadcaster_user_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_rewardadd");

    public static TwitchEventSubDefinition ChannelChannelPointsCustomRewardUpdate = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardUpdate,
        "channel.channel_points_custom_reward.update", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_rewardupdate");

    public static TwitchEventSubDefinition ChannelChannelPointsCustomRewardRemove = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRemove,
        "channel.channel_points_custom_reward.remove", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_rewardremove");

    public static TwitchEventSubDefinition ChannelChannelPointsCustomRewardRedemptionAdd = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRedemptionAdd,
        "channel.channel_points_custom_reward_redemption.add", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_reward_redemptionadd");

    public static TwitchEventSubDefinition ChannelChannelPointsCustomRewardRedemptionUpdate = new(
        TwitchEventSubDefinitionType.ChannelChannelPointsCustomRewardRedemptionUpdate,
        "channel.channel_points_custom_reward_redemption.update", "1", ["broadcaster_user_id", "reward_id"],
        ["channel:read:redemptions", "channel:manage:redemptions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelchannel_points_custom_reward_redemptionupdate");

    public static TwitchEventSubDefinition ChannelPollBegin = new(TwitchEventSubDefinitionType.ChannelPollBegin,
        "channel.poll.begin", "1", ["broadcaster_user_id"], ["channel:manage:polls", "channel:read:polls"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpollbegin");

    public static TwitchEventSubDefinition ChannelPollProgress = new(TwitchEventSubDefinitionType.ChannelPollProgress,
        "channel.poll.progress", "1", ["broadcaster_user_id"], ["channel:manage:polls", "channel:read:polls"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpollprogress");

    public static TwitchEventSubDefinition ChannelPollEnd = new(TwitchEventSubDefinitionType.ChannelPollEnd,
        "channel.poll.end", "1", ["broadcaster_user_id"], ["channel:manage:polls", "channel:read:polls"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpollend");

    public static TwitchEventSubDefinition ChannelPredictionBegin = new(
        TwitchEventSubDefinitionType.ChannelPredictionBegin, "channel.prediction.begin", "1", ["broadcaster_user_id"],
        ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionbegin");

    public static TwitchEventSubDefinition ChannelPredictionProgress = new(
        TwitchEventSubDefinitionType.ChannelPredictionProgress, "channel.prediction.progress", "1",
        ["broadcaster_user_id"], ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionprogress");

    public static TwitchEventSubDefinition ChannelPredictionLock = new(
        TwitchEventSubDefinitionType.ChannelPredictionLock,
        "channel.prediction.lock", "1", ["broadcaster_user_id"],
        ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionlock");

    public static TwitchEventSubDefinition ChannelPredictionEnd = new(TwitchEventSubDefinitionType.ChannelPredictionEnd,
        "channel.prediction.end", "1", ["broadcaster_user_id"],
        ["channel:manage:predictions", "channel:read:predictions"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelpredictionend");

    public static TwitchEventSubDefinition ChannelSuspiciousUserUpdate = new(
        TwitchEventSubDefinitionType.ChannelSuspiciousUserUpdate, "channel.suspicious_user.update", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:suspicious_users"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsuspicious_userupdate");

    public static TwitchEventSubDefinition ChannelSuspiciousUserMessage = new(
        TwitchEventSubDefinitionType.ChannelSuspiciousUserMessage, "channel.suspicious_user.message", "1",
        ["moderator_user_id", "broadcaster_user_id"], ["moderator:read:suspicious_users"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelsuspicious_usermessage");

    public static TwitchEventSubDefinition ChannelVipAdd = new(TwitchEventSubDefinitionType.ChannelVipAdd,
        "channel.vip.add", "1", ["broadcaster_user_id"], ["channel:manage:vips", "channel:read:vips"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelvipadd");

    public static TwitchEventSubDefinition ChannelVipRemove = new(TwitchEventSubDefinitionType.ChannelVipRemove,
        "channel.vip.remove", "1", ["broadcaster_user_id"], ["channel:manage:vips", "channel:read:vips"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelvipremove");

    public static TwitchEventSubDefinition ChannelWarningAcknowledge = new(
        TwitchEventSubDefinitionType.ChannelWarningAcknowledge, "channel.warning.acknowledge", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:manage:warnings", "moderator:read:warnings"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelwarningacknowledge");

    public static TwitchEventSubDefinition ChannelWarningSend = new(TwitchEventSubDefinitionType.ChannelWarningSend,
        "channel.warning.send", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:manage:warnings", "moderator:read:warnings"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelwarningsend");

    public static TwitchEventSubDefinition ChannelHypeTrainBegin = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainBegin, "channel.hype_train.begin", "2", ["broadcaster_user_id"],
        ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelhype_trainbegin");

    public static TwitchEventSubDefinition ChannelHypeTrainProgress = new(
        TwitchEventSubDefinitionType.ChannelHypeTrainProgress, "channel.hype_train.progress", "2",
        ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelhype_trainprogress");

    public static TwitchEventSubDefinition ChannelHypeTrainEnd = new(TwitchEventSubDefinitionType.ChannelHypeTrainEnd,
        "channel.hype_train.end", "2", ["broadcaster_user_id"], ["channel:read:hype_train"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelhype_trainend");

    public static TwitchEventSubDefinition ChannelCharityCampaignDonate = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignDonate, "channel.charity_campaign.donate", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaigndonate");

    public static TwitchEventSubDefinition ChannelCharityCampaignStart = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignStart, "channel.charity_campaign.start", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaignstart");

    public static TwitchEventSubDefinition ChannelCharityCampaignProgress = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignProgress, "channel.charity_campaign.progress", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaignprogress");

    public static TwitchEventSubDefinition ChannelCharityCampaignStop = new(
        TwitchEventSubDefinitionType.ChannelCharityCampaignStop, "channel.charity_campaign.stop", "1",
        ["broadcaster_user_id"], ["channel:read:charity"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelcharity_campaignstop");

    public static TwitchEventSubDefinition ChannelSharedChatBegin =
        new(TwitchEventSubDefinitionType.ChannelSharedChatBegin, "channel.shared_chat.begin", "beta",
            ["broadcaster_user_id"], [],
            "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshared_chatbegin");

    public static TwitchEventSubDefinition ChannelSharedChatUpdate = new(
        TwitchEventSubDefinitionType.ChannelSharedChatUpdate, "channel.shared_chat.update", "beta",
        ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshared_chatupdate");

    public static TwitchEventSubDefinition ChannelSharedChatEnd = new(TwitchEventSubDefinitionType.ChannelSharedChatEnd,
        "channel.shared_chat.end", "beta", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshared_chatend");

    public static TwitchEventSubDefinition ChannelShieldModeBegin = new(
        TwitchEventSubDefinitionType.ChannelShieldModeBegin, "channel.shield_mode.begin", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shield_mode", "moderator:manage:shield_mode"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshield_modebegin");

    public static TwitchEventSubDefinition ChannelShieldModeEnd = new(TwitchEventSubDefinitionType.ChannelShieldModeEnd,
        "channel.shield_mode.end", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:shield_mode", "moderator:manage:shield_mode"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshield_modeend");

    public static TwitchEventSubDefinition ChannelShoutoutCreate = new(
        TwitchEventSubDefinitionType.ChannelShoutoutCreate,
        "channel.shoutout.create", "1", ["broadcaster_user_id", "moderator_user_id"],
        ["moderator:read:shoutouts", "moderator:manage:shoutouts"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshoutoutcreate");

    public static TwitchEventSubDefinition ChannelShoutoutReceive = new(
        TwitchEventSubDefinitionType.ChannelShoutoutReceive, "channel.shoutout.receive", "1",
        ["broadcaster_user_id", "moderator_user_id"], ["moderator:read:shoutouts", "moderator:manage:shoutouts"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelshoutoutreceive");

    public static TwitchEventSubDefinition ConduitShardDisabled = new(TwitchEventSubDefinitionType.ConduitShardDisabled,
        "conduit.shard.disabled", "1", ["client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#conduitsharddisabled");

    public static TwitchEventSubDefinition DropEntitlementGrant = new(TwitchEventSubDefinitionType.DropEntitlementGrant,
        "drop.entitlement.grant", "1", ["organization_id", "category_id", "campaign_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#dropentitlementgrant");

    public static TwitchEventSubDefinition ExtensionBitsTransactionCreate = new(
        TwitchEventSubDefinitionType.ExtensionBitsTransactionCreate, "extension.bits_transaction.create", "1",
        ["extension_client_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#extensionbits_transactioncreate");

    public static TwitchEventSubDefinition ChannelGoalBegin = new(TwitchEventSubDefinitionType.ChannelGoalBegin,
        "channel.goal.begin", "1", ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelgoalbegin");

    public static TwitchEventSubDefinition ChannelGoalProgress = new(TwitchEventSubDefinitionType.ChannelGoalProgress,
        "channel.goal.progress", "1", ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelgoalprogress");

    public static TwitchEventSubDefinition ChannelGoalEnd = new(TwitchEventSubDefinitionType.ChannelGoalEnd,
        "channel.goal.end", "1", ["broadcaster_user_id"], ["channel:read:goals"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#channelgoalend");

    public static TwitchEventSubDefinition StreamOnline = new(TwitchEventSubDefinitionType.StreamOnline,
        "stream.online",
        "1", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#streamonline");

    public static TwitchEventSubDefinition StreamOffline = new(TwitchEventSubDefinitionType.StreamOffline,
        "stream.offline",
        "1", ["broadcaster_user_id"], [],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#streamoffline");

    public static TwitchEventSubDefinition UserAuthorizationGrant =
        new(TwitchEventSubDefinitionType.UserAuthorizationGrant, "user.authorization.grant", "1", ["client_id"], [],
            "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userauthorizationgrant");

    public static TwitchEventSubDefinition UserAuthorizationRevoke =
        new(TwitchEventSubDefinitionType.UserAuthorizationRevoke, "user.authorization.revoke", "1", ["client_id"], [],
            "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userauthorizationrevoke");

    public static TwitchEventSubDefinition UserUpdate = new(TwitchEventSubDefinitionType.UserUpdate, "user.update", "1",
        ["user_id"], ["user:read:email"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userupdate");

    public static TwitchEventSubDefinition UserWhisperMessage = new(TwitchEventSubDefinitionType.UserWhisperMessage,
        "user.whisper.message", "1", ["user_id"], ["user:manage:whispers", "user:read:whispers"],
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#userwhispermessage");

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