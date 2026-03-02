using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBitsUse;

public partial class TwitchChannelBitsUseEvent : Resource, ITwitcherSharpEventSub<TwitchChannelBitsUseEvent>
{
    /// <summary> 
    /// The User ID of the channel where the Bits were redeemed.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the channel where the Bits were used.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the channel where the Bits were used.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The User ID of the redeeming user.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The login name of the redeeming user.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The display name of the redeeming user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The number of Bits used.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// Possible values are: cheerpower_up
    /// </summary>
    public string Type { get; set; }

    /// <summary> 
    /// Optional. An object that contains the user message and emote information needed to recreate the message.
    /// </summary>
    public TwitchMessage Message { get; set; }

    /// <summary> 
    /// Optional. Data about Power-up.
    /// </summary>
    public TwitchPowerUp PowerUp { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBitsUseEvent object.
    /// </summary> 
    public static TwitchChannelBitsUseEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelBitsUseEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Bits = data.Get("bits").AsInt32(),
            Type = data.Get("type").AsString(),
            Message = data.Get("message").As<TwitchMessage>(),
            PowerUp = data.Get("power_up").As<TwitchPowerUp>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("bits", Bits);
        request.Set("type", Type);
        request.Set("message", Message);
        request.Set("power_up", PowerUp);
        return request;
    }

    public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
            var messageClass = script.Get("Message").AsGodotObject();
            var request = messageClass.Call("new").AsGodotObject();
            request.Set("text", Text);
            request.Set("fragments", Fragments);
            return request;
        }
    
        public partial class TwitchFragments : Resource, ITwitcherSharpEventSub<TwitchFragments>
        {
            /// <summary> 
            /// The message text in fragment.
            /// </summary>
            public string Text { get; set; }
        
            /// <summary> 
            /// The type of message fragment. Possible values are: textcheermoteemote
            /// </summary>
            public string Type { get; set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote Emote { get; set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote Cheermote { get; set; }
        
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
                    Cheermote = data.Get("cheermote").As<TwitchCheermote>(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                var fragmentsClass = script.Get("Fragments").AsGodotObject();
                var request = fragmentsClass.Call("new").AsGodotObject();
                request.Set("text", Text);
                request.Set("type", Type);
                request.Set("emote", Emote);
                request.Set("cheermote", Cheermote);
                return request;
            }
        
            public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
            {
                /// <summary> 
                /// The ID that uniquely identifies this emote.
                /// </summary>
                public string Id { get; set; }
            
                /// <summary> 
                /// The ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string EmoteSetId { get; set; }
            
                /// <summary> 
                /// The ID of the broadcaster who owns the emote.
                /// </summary>
                public string OwnerId { get; set; }
            
                /// <summary> 
                /// The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated. The possible formats are: animated - An animated GIF is available for this emote.static - A static PNG file is available for this emote.
                /// </summary>
                public string[] Format { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                        OwnerId = data.Get("owner_id").AsString(),
                        Format = data.Get("format").AsStringArray(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                    var emoteClass = script.Get("Emote").AsGodotObject();
                    var request = emoteClass.Call("new").AsGodotObject();
                    request.Set("id", Id);
                    request.Set("emote_set_id", EmoteSetId);
                    request.Set("owner_id", OwnerId);
                    request.Set("format", Format);
                    return request;
                }
            }
        
            public partial class TwitchCheermote : Resource, ITwitcherSharpEventSub<TwitchCheermote>
            {
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public string Prefix { get; set; }
            
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
                public static TwitchCheermote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                    var cheermoteClass = script.Get("Cheermote").AsGodotObject();
                    var request = cheermoteClass.Call("new").AsGodotObject();
                    request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            }
        }
    }

    public partial class TwitchPowerUp : Resource, ITwitcherSharpEventSub<TwitchPowerUp>
    {
        /// <summary> 
        /// Possible values: message_effectcelebrationgigantify_an_emote
        /// </summary>
        public string Type { get; set; }
    
        /// <summary> 
        /// Optional. Emote associated with the reward.
        /// </summary>
        public TwitchEmote Emote { get; set; }
    
        /// <summary> 
        /// Optional. The ID of the message effect.
        /// </summary>
        public string MessageEffectId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPowerUp object.
        /// </summary> 
        public static TwitchPowerUp FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchPowerUp
            {
                Type = data.Get("type").AsString(),
                Emote = data.Get("emote").As<TwitchEmote>(),
                MessageEffectId = data.Get("message_effect_id").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
            var powerUpClass = script.Get("PowerUp").AsGodotObject();
            var request = powerUpClass.Call("new").AsGodotObject();
            request.Set("type", Type);
            request.Set("emote", Emote);
            request.Set("message_effect_id", MessageEffectId);
            return request;
        }
    
        public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
        {
            /// <summary> 
            /// The ID that uniquely identifies this emote.
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd");
                var emoteClass = script.Get("Emote").AsGodotObject();
                var request = emoteClass.Call("new").AsGodotObject();
                request.Set("id", Id);
                request.Set("name", Name);
                return request;
            }
        }
    }
}
