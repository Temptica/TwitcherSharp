using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPointsAutomaticRewardRedemptionAdd;

public partial class TwitchChannelPointsAutomaticRewardRedemptionAddV2Event : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsAutomaticRewardRedemptionAddV2Event>
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
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            RedeemedAt = data.Read("redeemed_at", static v => v.AsString()),
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
        public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchReward
            {
                Type = data.Read("type", static v => v.AsString()),
                ChannelPoints = data.Read("channel_points", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Reward");
            if(Type != null) request.SetValue("type", Type);
            request.SetValue("channel_points", ChannelPoints);
            if(Emote != null) request.SetObject("emote", Emote);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
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
            /// Transforms the godot data into a TwitchEmote object.
            /// </summary> 
            public static TwitchEmote? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchEmote
                {
                    Id = data.Read("id", static v => v.AsString()),
                    Name = data.Read("name", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Emote");
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

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private Variant _data;
        
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// The ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[]? Fragments { get => field ??= _data.GetArray<TwitchFragments>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMessage
            {
                Text = data.Read("text", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Message");
            if(Text != null) request.SetValue("text", Text);
            if(Fragments != null) request.SetArray("fragments", Fragments);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            private Variant _data;
            
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
            public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchFragments
                {
                    Text = data.Read("text", static v => v.AsString()),
                    Type = data.Read("type", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Fragments");
                if(Text != null) request.SetValue("text", Text);
                if(Type != null) request.SetValue("type", Type);
                if(Emote != null) request.SetObject("emote", Emote);
                return request;
            }
        
            /// <summary> Releases the twitcher object this instance was mapped from. </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing) _data.Dispose();
                base.Dispose(disposing);
            }
        
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                private Variant _data;
                
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
                        Id = data.Read("id", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_automatic_reward_redemption_add.gd", "Emote");
                    if(Id != null) request.SetValue("id", Id);
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
    }
}
