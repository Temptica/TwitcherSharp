using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBitsUse;

public partial class TwitchChannelBitsUseEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelBitsUseEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The User ID of the channel where the Bits were redeemed.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the channel where the Bits were used.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the channel where the Bits were used.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The User ID of the redeeming user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The login name of the redeeming user.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The display name of the redeeming user.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The number of Bits used.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// Possible values are: cheerpower_upcustom_power_up
    /// </summary>
    public string? Type { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// Optional. Data about a default (i.e. built-in) Power-up.
    /// </summary>
    public TwitchPowerUp? PowerUp { get => field ??= _data?.Get<TwitchPowerUp>("power_up"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchCustomPowerUp? CustomPowerUp { get => field ??= _data?.Get<TwitchCustomPowerUp>("custom_power_up"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBitsUseEvent object.
    /// </summary> 
    public static TwitchChannelBitsUseEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelBitsUseEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Bits = data.Get("bits").AsInt32(),
            Type = data.Get("type").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        request.Set("bits", Bits);
        if(Type != null) request.Set("type", Type);
        if(Message != null) request.Set("message", Message.ToGodotObject());
        if(PowerUp != null) request.Set("power_up", PowerUp.ToGodotObject());
        if(CustomPowerUp != null) request.Set("custom_power_up", CustomPowerUp.ToGodotObject());
        return request;
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
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
            /// The type of message fragment. Possible values are: textcheermoteemote
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote? Cheermote { get => field ??= _data?.Get<TwitchCheermote>("cheermote"); set; }
        
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                var fragmentsClass = script.Get("Fragments").As<GDScript>();
                var request = fragmentsClass.New().AsGodotObject();
                if(Text != null) request.Set("text", Text);
                if(Type != null) request.Set("type", Type);
                if(Emote != null) request.Set("emote", Emote.ToGodotObject());
                if(Cheermote != null) request.Set("cheermote", Cheermote.ToGodotObject());
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
                /// The ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string? EmoteSetId { get; set; }
            
                /// <summary> 
                /// The ID of the broadcaster who owns the emote.
                /// </summary>
                public string? OwnerId { get; set; }
            
                /// <summary> 
                /// The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated. The possible formats are: animated - An animated GIF is available for this emote.static - A static PNG file is available for this emote.
                /// </summary>
                public string[]? Format { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                        OwnerId = data.Get("owner_id").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                    var emoteClass = script.Get("Emote").As<GDScript>();
                    var request = emoteClass.New().AsGodotObject();
                    if(Id != null) request.Set("id", Id);
                    if(EmoteSetId != null) request.Set("emote_set_id", EmoteSetId);
                    if(OwnerId != null) request.Set("owner_id", OwnerId);
                    if(Format != null) request.Set("format", new Godot.Collections.Array<string>(Format));
                    return request;
                }
            }
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                private GodotObject? _data;
                
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.For example, if the prefix is “cheer” and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public string? Prefix { get; set; }
            
                /// <summary> 
                /// The amount of Bits cheered.
                /// </summary>
                public int Bits { get; set; }
            
                /// <summary> 
                /// The tier level of the cheermote.
                /// </summary>
                public int Tier { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchCheermote object.
                /// </summary> 
                public static TwitchCheermote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                    var cheermoteClass = script.Get("Cheermote").As<GDScript>();
                    var request = cheermoteClass.New().AsGodotObject();
                    if(Prefix != null) request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            }
        }
    }

    public partial class TwitchPowerUp : RefCounted, ITwitcherSharpEventSub<TwitchPowerUp>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// Possible values: message_effectcelebrationgigantify_an_emote
        /// </summary>
        public string? Type { get; set; }
    
        /// <summary> 
        /// Optional. Emote associated with the reward.
        /// </summary>
        public TwitchEmote? Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
    
        /// <summary> 
        /// Optional. The ID of the message effect.
        /// </summary>
        public string? MessageEffectId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPowerUp object.
        /// </summary> 
        public static TwitchPowerUp? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchPowerUp
            {
                Type = data.Get("type").AsString(),
                MessageEffectId = data.Get("message_effect_id").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
            var powerUpClass = script.Get("PowerUp").As<GDScript>();
            var request = powerUpClass.New().AsGodotObject();
            if(Type != null) request.Set("type", Type);
            if(Emote != null) request.Set("emote", Emote.ToGodotObject());
            if(MessageEffectId != null) request.Set("message_effect_id", MessageEffectId);
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                var emoteClass = script.Get("Emote").As<GDScript>();
                var request = emoteClass.New().AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(Name != null) request.Set("name", Name);
                return request;
            }
        }
    }

    public partial class TwitchCustomPowerUp : RefCounted, ITwitcherSharpEventSub<TwitchCustomPowerUp>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The title of the custom Power-up.
        /// </summary>
        public string? Title { get; set; }
    
        /// <summary> 
        /// The ID of the custom Power-up.
        /// </summary>
        public string? RewardId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCustomPowerUp object.
        /// </summary> 
        public static TwitchCustomPowerUp? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCustomPowerUp
            {
                Title = data.Get("title").AsString(),
                RewardId = data.Get("reward_id").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
            var customPowerUpClass = script.Get("CustomPowerUp").As<GDScript>();
            var request = customPowerUpClass.New().AsGodotObject();
            if(Title != null) request.Set("title", Title);
            if(RewardId != null) request.Set("reward_id", RewardId);
            return request;
        }
    }
}
