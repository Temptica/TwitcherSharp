using System;

namespace TwitcherSharp.EventSub;

public enum TwitchEventSubDefinitionType
{
    AutomodMessageHold,
    AutomodMessageHoldV2,
    AutomodMessageUpdate,
    AutomodMessageUpdateV2,
    AutomodSettingsUpdate,
    AutomodTermsUpdate,
    ChannelBitsUse,
    ChannelUpdate,
    ChannelFollow,
    ChannelAdBreakBegin,
    ChannelChatClear,
    ChannelChatClearUserMessages,
    ChannelChatMessage,
    ChannelChatMessageDelete,
    ChannelChatNotification,
    ChannelChatSettingsUpdate,
    ChannelChatUserMessageHold,
    ChannelChatUserMessageUpdate,
    ChannelSubscribe,
    ChannelSubscriptionEnd,
    ChannelSubscriptionGift,
    ChannelSubscriptionMessage,
    ChannelCheer,
    ChannelRaid,
    ChannelBan,
    ChannelUnban,
    ChannelUnbanRequestCreate,
    ChannelUnbanRequestResolve,
    ChannelModerate,
    ChannelModerateV2,
    ChannelModeratorAdd,
    ChannelModeratorRemove,
    ChannelGuestStarSessionBegin,
    ChannelGuestStarSessionEnd,
    ChannelGuestStarGuestUpdate,
    ChannelGuestStarSettingsUpdate,
    ChannelChannelPointsAutomaticRewardRedemptionAdd,
    ChannelChannelPointsAutomaticRewardRedemptionAddV2,
    ChannelChannelPointsCustomRewardAdd,
    ChannelChannelPointsCustomRewardUpdate,
    ChannelChannelPointsCustomRewardRemove,
    ChannelChannelPointsCustomRewardRedemptionAdd,
    ChannelChannelPointsCustomRewardRedemptionUpdate,
    ChannelCustomPowerUpRedemptionAdd,
    ChannelPollBegin,
    ChannelPollProgress,
    ChannelPollEnd,
    ChannelPredictionBegin,
    ChannelPredictionProgress,
    ChannelPredictionLock,
    ChannelPredictionEnd,
    ChannelSuspiciousUserUpdate,
    ChannelSuspiciousUserMessage,
    ChannelVipAdd,
    ChannelVipRemove,
    ChannelWarningAcknowledge,
    ChannelWarningSend,
    ChannelHypeTrainBegin,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_hype_train_begin'. Use ChannelHypeTrainBegin instead.")]
    ChannelHypeTrainBeginLegacy,
    ChannelHypeTrainProgress,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_hype_train_progress'. Use ChannelHypeTrainProgress instead.")]
    ChannelHypeTrainProgressLegacy,
    ChannelHypeTrainEnd,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_hype_train_end'. Use ChannelHypeTrainEnd instead.")]
    ChannelHypeTrainEndLegacy,
    ChannelCharityCampaignDonate,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_charity_campaign_donate'. Use ChannelCharityCampaignDonate instead.")]
    ChannelCharityCampaignDonateLegacy,
    ChannelCharityCampaignStart,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_charity_campaign_start'. Use ChannelCharityCampaignStart instead.")]
    ChannelCharityCampaignStartLegacy,
    ChannelCharityCampaignProgress,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_charity_campaign_progress'. Use ChannelCharityCampaignProgress instead.")]
    ChannelCharityCampaignProgressLegacy,
    ChannelCharityCampaignStop,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_charity_campaign_stop'. Use ChannelCharityCampaignStop instead.")]
    ChannelCharityCampaignStopLegacy,
    ChannelSharedChatBegin,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shared_chat_begin'. Use ChannelSharedChatBegin instead.")]
    ChannelSharedChatBeginLegacy,
    ChannelSharedChatUpdate,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shared_chat_update'. Use ChannelSharedChatUpdate instead.")]
    ChannelSharedChatUpdateLegacy,
    ChannelSharedChatEnd,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shared_chat_end'. Use ChannelSharedChatEnd instead.")]
    ChannelSharedChatEndLegacy,
    ChannelShieldModeBegin,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shield_mode_begin'. Use ChannelShieldModeBegin instead.")]
    ChannelShieldModeBeginLegacy,
    ChannelShieldModeEnd,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shield_mode_end'. Use ChannelShieldModeEnd instead.")]
    ChannelShieldModeEndLegacy,
    ChannelShoutoutCreate,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shoutout_create'. Use ChannelShoutoutCreate instead.")]
    ChannelShoutoutCreateLegacy,
    ChannelShoutoutReceive,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_shoutout_receive'. Use ChannelShoutoutReceive instead.")]
    ChannelShoutoutReceiveLegacy,
    ConduitShardDisabled,
    DropEntitlementGrant,
    ExtensionBitsTransactionCreate,
    ChannelGoalBegin,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_goal_begin'. Use ChannelGoalBegin instead.")]
    ChannelGoalBeginLegacy,
    ChannelGoalProgress,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_goal_progress'. Use ChannelGoalProgress instead.")]
    ChannelGoalProgressLegacy,
    ChannelGoalEnd,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'channel_goal_end'. Use ChannelGoalEnd instead.")]
    ChannelGoalEndLegacy,
    StreamOnline,
    StreamOffline,
    UserAuthorizationGrant,
    UserAuthorizationRevoke,
    UserUpdate,
    UserWhisperMessage,
    [Obsolete("Kept for backwards compatibility - points at the pre-override script name 'user_whisper_message'. Use UserWhisperMessage instead.")]
    UserWhisperMessageLegacy
}
