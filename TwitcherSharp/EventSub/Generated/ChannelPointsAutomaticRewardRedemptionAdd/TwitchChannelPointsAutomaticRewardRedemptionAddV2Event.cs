using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddV2Event : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddV2Event>
{
    /// <summary> 
    /// The ID of the channel where the reward was redeemed.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the channel where the reward was redeemed.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the channel where the reward was redeemed.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the redeeming user.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The login of the redeeming user.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The display name of the redeeming user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The ID of the Redemption.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// An object that contains the reward information.
    /// </summary>
    public TwitchReward Reward { get; set; }

    /// <summary> 
    /// Optional. An object that contains the user message and emote information needed to recreate the message.
    /// </summary>
    public TwitchMessage Message { get; set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the reward was redeemed.
    /// </summary>
    public string RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsAutomaticRewardRedemptionAddV2Event object.
    /// </summary> 
    public static TwitchChannelPointsAutomaticRewardRedemptionAddV2Event FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPointsAutomaticRewardRedemptionAddV2Event
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Id = data.Get("id").AsString(),
            Reward = data.Get("reward").As<TwitchReward>(),
            Message = data.Get("message").As<TwitchMessage>(),
            RedeemedAt = data.Get("redeemed_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
        var eventV2Class = script.Get("EventV2").AsGodotObject();
        var request = eventV2Class.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("id", Id);
        request.Set("reward", Reward);
        request.Set("message", Message);
        request.Set("redeemed_at", RedeemedAt);
        return request;
    }

    public partial class TwitchReward : RefCounted, ITwitcherSharpEventSub<TwitchReward>
    {
        /// <summary> 
        /// The type of reward. One of:  single_message_bypass_sub_modesend_highlighted_messagerandom_sub_emote_unlockchosen_sub_emote_unlockchosen_modified_sub_emote_unlock
        /// </summary>
        public string Type { get; set; }
    
        /// <summary> 
        /// Number of channel points used.
        /// </summary>
        public int ChannelPoints { get; set; }
    
        /// <summary> 
        /// Optional. Emote associated with the reward.
        /// </summary>
        public TwitchEmote Emote { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchReward
            {
                Type = data.Get("type").AsString(),
                ChannelPoints = data.Get("channel_points").AsInt32(),
                Emote = data.Get("emote").As<TwitchEmote>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
            var rewardClass = script.Get("Reward").AsGodotObject();
            var request = rewardClass.Call("new").AsGodotObject();
            request.Set("type", Type);
            request.Set("channel_points", ChannelPoints);
            request.Set("emote", Emote);
            return request;
        }
    
        public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
        {
            /// <summary> 
            /// The emote ID.
            /// </summary>
            public string Id { get; set; }
        
            /// <summary> 
            /// The human readable emote token.
            /// </summary>
            public string Name { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchEmote object.
            /// </summary> 
            public static TwitchEmote FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchEmote
                {
                    Id = data.Get("id").AsString(),
                    Name = data.Get("name").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                var emoteClass = script.Get("Emote").AsGodotObject();
                var request = emoteClass.Call("new").AsGodotObject();
                request.Set("id", Id);
                request.Set("name", Name);
                return request;
            }
        }
    }

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string Text { get; set; }
    
        /// <summary> 
        /// The ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[] Fragments { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage FromObject(GodotObject data)
        {
            if(data == null) return null;
            var fragmentsArray = data.Get("fragments").AsGodotArray<GodotObject>();
            return new TwitchMessage
            {
                Text = data.Get("text").AsString(),
                Fragments = fragmentsArray.Select(TwitchFragments.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
            var messageClass = script.Get("Message").AsGodotObject();
            var request = messageClass.Call("new").AsGodotObject();
            request.Set("text", Text);
            request.Set("fragments", Fragments);
            return request;
        }
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            /// <summary> 
            /// The message text in fragment.
            /// </summary>
            public string Text { get; set; }
        
            /// <summary> 
            /// The type of message fragment. Possible values are: textemote
            /// </summary>
            public string Type { get; set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote Emote { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchFragments
                {
                    Text = data.Get("text").AsString(),
                    Type = data.Get("type").AsString(),
                    Emote = data.Get("emote").As<TwitchEmote>(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                var fragmentsClass = script.Get("Fragments").AsGodotObject();
                var request = fragmentsClass.Call("new").AsGodotObject();
                request.Set("text", Text);
                request.Set("type", Type);
                request.Set("emote", Emote);
                return request;
            }
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                /// <summary> 
                /// The ID that uniquely identifies this emote.
                /// </summary>
                public string Id { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd");
                    var emoteClass = script.Get("Emote").AsGodotObject();
                    var request = emoteClass.Call("new").AsGodotObject();
                    request.Set("id", Id);
                    return request;
                }
            }
        }
    }
}
