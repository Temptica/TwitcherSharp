using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddEventV2>
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
    /// An object that contains the reward information.
    /// </summary>
    public TwitchRewardV2? Reward { get => field ??= _data?.Get<TwitchRewardV2>("reward"); set; }

    /// <summary> 
    /// An object that contains the user message and emote information needed to recreate the message.
    /// </summary>
    public TwitchMessageV2? Message { get => field ??= _data?.Get<TwitchMessageV2>("message"); set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the reward was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddEventV2 object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddEventV2? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsAutomaticRewardRedemptionAddEventV2
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
        var eventV2Class = script.Get("EventV2").As<GDScript>();
        var request = eventV2Class.New().AsGodotObject();
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


    public partial class TwitchRewardV2 : RefCounted, ITwitcherSharpEventSub<TwitchRewardV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The type of reward. Possible values:
        /// - `single_message_bypass_sub_mode`
        /// - `send_highlighted_message`
        /// - `random_sub_emote_unlock`
        /// - `chosen_sub_emote_unlock`
        /// - `chosen_modified_sub_emote_unlock`
        /// </summary>
        public string? Type { get; set; }
    
        /// <summary> 
        /// Number of channel points used.
        /// </summary>
        public int ChannelPoints { get; set; }
    
        /// <summary> 
        /// Emote associated with the reward.
        /// </summary>
        public TwitchEmoteV2? Emote { get => field ??= _data?.Get<TwitchEmoteV2>("emote"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchRewardV2 object.
        /// </summary> 
        public static TwitchRewardV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchRewardV2
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
            var rewardV2Class = script.Get("RewardV2").As<GDScript>();
            var request = rewardV2Class.New().AsGodotObject();
            if(Type != null) request.Set("type", Type);
            request.Set("channel_points", ChannelPoints);
            if(Emote != null) request.Set("emote", Emote.ToGodotObject());
            return request;
        }
    
    
        public partial class TwitchEmoteV2 : RefCounted, ITwitcherSharpEventSub<TwitchEmoteV2>
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
            /// Transforms the godot data into a TwitchEmoteV2 object.
            /// </summary> 
            public static TwitchEmoteV2? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchEmoteV2
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
                var emoteV2Class = script.Get("EmoteV2").As<GDScript>();
                var request = emoteV2Class.New().AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(Name != null) request.Set("name", Name);
                return request;
            }
        }
    }

    public partial class TwitchMessageV2 : RefCounted, ITwitcherSharpEventSub<TwitchMessageV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// The ordered list of chat message fragments.
        /// </summary>
        public TwitchFragmentsV2[]? Fragments { get => field ??= _data?.GetArray<TwitchFragmentsV2>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessageV2 object.
        /// </summary> 
        public static TwitchMessageV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMessageV2
            {
                Text = data.Get("text").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
            var messageV2Class = script.Get("MessageV2").As<GDScript>();
            var request = messageV2Class.New().AsGodotObject();
            if(Text != null) request.Set("text", Text);
            if(Fragments != null) request.Set("fragments", Fragments.ToGodotArray());
            return request;
        }
    
    
        public partial class TwitchFragmentsV2 : RefCounted, ITwitcherSharpEventSub<TwitchFragmentsV2>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// The message text in fragment.
            /// </summary>
            public string? Text { get; set; }
        
            /// <summary> 
            /// The type of message fragment. Possible values:
            /// - `text`
            /// - `emote`
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// The metadata pertaining to the emote.
            /// </summary>
            public TwitchEmoteV2? Emote { get => field ??= _data?.Get<TwitchEmoteV2>("emote"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragmentsV2 object.
            /// </summary> 
            public static TwitchFragmentsV2? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchFragmentsV2
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
                var fragmentsV2Class = script.Get("FragmentsV2").As<GDScript>();
                var request = fragmentsV2Class.New().AsGodotObject();
                if(Text != null) request.Set("text", Text);
                if(Type != null) request.Set("type", Type);
                if(Emote != null) request.Set("emote", Emote.ToGodotObject());
                return request;
            }
        
        
            public partial class TwitchEmoteV2 : RefCounted, ITwitcherSharpEventSub<TwitchEmoteV2>
            {
                private GodotObject? _data;
                
                /// <summary> 
                /// The ID that uniquely identifies this emote.
                /// </summary>
                public string? Id { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmoteV2 object.
                /// </summary> 
                public static TwitchEmoteV2? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchEmoteV2
                    {
                        Id = data.Get("id").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                    var emoteV2Class = script.Get("EmoteV2").As<GDScript>();
                    var request = emoteV2Class.New().AsGodotObject();
                    if(Id != null) request.Set("id", Id);
                    return request;
                }
            }
        }
    }
}
