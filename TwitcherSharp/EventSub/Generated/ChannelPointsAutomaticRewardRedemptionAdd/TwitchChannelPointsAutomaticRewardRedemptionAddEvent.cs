using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the channel where the reward was redeemed.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the channel where the reward was redeemed.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the channel where the reward was redeemed.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the redeeming user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The login of the redeeming user.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The display name of the redeeming user.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The ID of the Redemption.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchReward? Reward { get => field ??= _data?.Get<TwitchReward>("reward"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The text of the chat message.
    /// </summary>
    public string? Text { get; set; }

    /// <summary> 
    /// An array that includes the emote ID and start and end positions for where the emote appears in the text.
    /// </summary>
    public TwitchEmotes[]? Emotes { get => field ??= _data?.GetArray<TwitchEmotes>("emotes"); set; }

    /// <summary> 
    /// Optional. A string that the user entered if the reward requires input.
    /// </summary>
    public string? UserInput { get; set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the reward was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddEvent object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsAutomaticRewardRedemptionAddEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Id = data.Get("id").AsString(),
            Text = data.Get("text").AsString(),
            UserInput = data.Get("user_input").AsString(),
            RedeemedAt = data.Get("redeemed_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(Id != null) request.Set("id", Id);
        if(Reward != null) request.Set("reward", Reward.ToGodotObject());
        if(Message != null) request.Set("message", Message.ToGodotObject());
        if(Text != null) request.Set("text", Text);
        if(Emotes != null) request.Set("emotes", Emotes.ToGodotArray());
        if(UserInput != null) request.Set("user_input", UserInput);
        if(RedeemedAt != null) request.Set("redeemed_at", RedeemedAt);
        return request;
    }


    public partial class TwitchReward : RefCounted, ITwitcherSharpEventSub<TwitchReward>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The type of reward. One of: single_message_bypass_sub_modesend_highlighted_messagerandom_sub_emote_unlockchosen_sub_emote_unlockchosen_modified_sub_emote_unlockmessage_effectgigantify_an_emotecelebration
        /// </summary>
        public string? Type { get; set; }
    
        /// <summary> 
        /// The reward cost.
        /// </summary>
        public int Cost { get; set; }
    
        /// <summary> 
        /// Optional. Emote that was unlocked.
        /// </summary>
        public TwitchUnlockedEmote? UnlockedEmote { get => field ??= _data?.Get<TwitchUnlockedEmote>("unlocked_emote"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchReward
            {
                Type = data.Get("type").AsString(),
                Cost = data.Get("cost").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
            var rewardClass = script.Get("Reward").As<GDScript>();
            var request = rewardClass.New().AsGodotObject();
            if(Type != null) request.Set("type", Type);
            request.Set("cost", Cost);
            if(UnlockedEmote != null) request.Set("unlocked_emote", UnlockedEmote.ToGodotObject());
            return request;
        }
    
    
        public partial class TwitchUnlockedEmote : RefCounted, ITwitcherSharpEventSub<TwitchUnlockedEmote>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// The emote ID.
            /// </summary>
            public string? Id { get; set; }
        
            /// <summary> 
            /// The human readable emote token.
            /// </summary>
            public string? Name { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchUnlockedEmote object.
            /// </summary> 
            public static TwitchUnlockedEmote? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchUnlockedEmote
                {
                    Id = data.Get("id").AsString(),
                    Name = data.Get("name").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                var unlockedEmoteClass = script.Get("UnlockedEmote").As<GDScript>();
                var request = unlockedEmoteClass.New().AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(Name != null) request.Set("name", Name);
                return request;
            }
        }
    }

    public partial class TwitchEmotes : RefCounted, ITwitcherSharpEventSub<TwitchEmotes>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The emote ID.
        /// </summary>
        public string? Id { get; set; }
    
        /// <summary> 
        /// The index of where the Emote starts in the text.
        /// </summary>
        public int Begin { get; set; }
    
        /// <summary> 
        /// The index of where the Emote ends in the text.
        /// </summary>
        public int End { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchEmotes object.
        /// </summary> 
        public static TwitchEmotes? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchEmotes
            {
                Id = data.Get("id").AsString(),
                Begin = data.Get("begin").AsInt32(),
                End = data.Get("end").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
            var emotesClass = script.Get("Emotes").As<GDScript>();
            var request = emotesClass.New().AsGodotObject();
            if(Id != null) request.Set("id", Id);
            request.Set("begin", Begin);
            request.Set("end", End);
            return request;
        }
    }
}
