using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddEvent>
{
    private Variant _data;
    
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
    public TwitchReward? Reward { get => field ??= _data.Get<TwitchReward>("reward"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The text of the chat message.
    /// </summary>
    public string? Text { get; set; }

    /// <summary> 
    /// An array that includes the emote ID and start and end positions for where the emote appears in the text.
    /// </summary>
    public TwitchEmotes[]? Emotes { get => field ??= _data.GetArray<TwitchEmotes>("emotes"); set; }

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
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            Id = data.ReadAsString("id"),
            Text = data.ReadAsString("text"),
            UserInput = data.ReadAsString("user_input"),
            RedeemedAt = data.ReadAsString("redeemed_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Id != null) request.SetValue("id", Id);
        if(Reward != null) request.SetObject("reward", Reward);
        if(Message != null) request.SetObject("message", Message);
        if(Text != null) request.SetValue("text", Text);
        if(Emotes != null) request.SetArray("emotes", Emotes);
        if(UserInput != null) request.SetValue("user_input", UserInput);
        if(RedeemedAt != null) request.SetValue("redeemed_at", RedeemedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchReward : RefCounted, ITwitcherSharpEventSub<TwitchReward>
    {
        private Variant _data;
        
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
        public TwitchUnlockedEmote? UnlockedEmote { get => field ??= _data.Get<TwitchUnlockedEmote>("unlocked_emote"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchReward
            {
                Type = data.ReadAsString("type"),
                Cost = data.ReadAsInt32("cost"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Reward");
            if(Type != null) request.SetValue("type", Type);
            request.SetValue("cost", Cost);
            if(UnlockedEmote != null) request.SetObject("unlocked_emote", UnlockedEmote);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchUnlockedEmote : RefCounted, ITwitcherSharpEventSub<TwitchUnlockedEmote>
        {
            private Variant _data;
            
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
                    Id = data.ReadAsString("id"),
                    Name = data.ReadAsString("name"),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "UnlockedEmote");
                if(Id != null) request.SetValue("id", Id);
                if(Name != null) request.SetValue("name", Name);
                return request;
            }
        
            /// <summary> Releases the twitcher object this instance was mapped from. </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing) _data.Dispose();
                base.Dispose(disposing);
            }
        }
    }

    public partial class TwitchEmotes : RefCounted, ITwitcherSharpEventSub<TwitchEmotes>
    {
        private Variant _data;
        
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
                Id = data.ReadAsString("id"),
                Begin = data.ReadAsInt32("begin"),
                End = data.ReadAsInt32("end"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Emotes");
            if(Id != null) request.SetValue("id", Id);
            request.SetValue("begin", Begin);
            request.SetValue("end", End);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }
}
