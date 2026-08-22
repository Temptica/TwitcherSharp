using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddV2Event : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddV2Event>
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
    /// The UTC date and time (in RFC3339 format) of when the reward was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddV2Event object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddV2Event? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsAutomaticRewardRedemptionAddV2Event
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Id = data.Get("id").AsString(),
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
        if(RedeemedAt != null) request.Set("redeemed_at", RedeemedAt);
        return request;
    }


    public partial class TwitchReward : RefCounted, ITwitcherSharpEventSub<TwitchReward>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The type of reward. One of:  single_message_bypass_sub_modesend_highlighted_messagerandom_sub_emote_unlockchosen_sub_emote_unlockchosen_modified_sub_emote_unlock
        /// </summary>
        public string? Type { get; set; }
    
        /// <summary> 
        /// Number of channel points used.
        /// </summary>
        public int ChannelPoints { get; set; }
    
        /// <summary> 
        /// Optional. Emote associated with the reward.
        /// </summary>
        public TwitchEmote? Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchReward
            {
                Type = data.Get("type").AsString(),
                ChannelPoints = data.Get("channel_points").AsInt32(),
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
            request.Set("channel_points", ChannelPoints);
            if(Emote != null) request.Set("emote", Emote.ToGodotObject());
            return request;
        }
    
    
        public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
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
            /// Transforms the godot data into a TwitchEmote object.
            /// </summary> 
            public static TwitchEmote? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchEmote
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
                var emoteClass = script.Get("Emote").As<GDScript>();
                var request = emoteClass.New().AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(Name != null) request.Set("name", Name);
                return request;
            }
        }
    }

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// The ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[]? Fragments { get => field ??= _data?.GetArray<TwitchFragments>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMessage
            {
                Text = data.Get("text").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
            var messageClass = script.Get("Message").As<GDScript>();
            var request = messageClass.New().AsGodotObject();
            if(Text != null) request.Set("text", Text);
            if(Fragments != null) request.Set("fragments", Fragments.ToGodotArray());
            return request;
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// The message text in fragment.
            /// </summary>
            public string? Text { get; set; }
        
            /// <summary> 
            /// The type of message fragment. Possible values are: textemote
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchFragments
                {
                    Text = data.Get("text").AsString(),
                    Type = data.Get("type").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                var fragmentsClass = script.Get("Fragments").As<GDScript>();
                var request = fragmentsClass.New().AsGodotObject();
                if(Text != null) request.Set("text", Text);
                if(Type != null) request.Set("type", Type);
                if(Emote != null) request.Set("emote", Emote.ToGodotObject());
                return request;
            }
        
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                private GodotObject? _data;
                
                /// <summary> 
                /// The ID that uniquely identifies this emote.
                /// </summary>
                public string? Id { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                    var emoteClass = script.Get("Emote").As<GDScript>();
                    var request = emoteClass.New().AsGodotObject();
                    if(Id != null) request.Set("id", Id);
                    return request;
                }
            }
        }
    }
}
