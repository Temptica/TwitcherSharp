using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBitsUse;

public partial class TwitchChannelBitsUseEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelBitsUseEvent>
{
    private Variant _data;
    
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
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// Optional. Data about a default (i.e. built-in) Power-up.
    /// </summary>
    public TwitchPowerUp? PowerUp { get => field ??= _data.Get<TwitchPowerUp>("power_up"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchCustomPowerUp? CustomPowerUp { get => field ??= _data.Get<TwitchCustomPowerUp>("custom_power_up"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBitsUseEvent object.
    /// </summary> 
    public static TwitchChannelBitsUseEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelBitsUseEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            Bits = data.Read("bits", static v => v.AsInt32()),
            Type = data.Read("type", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        request.SetValue("bits", Bits);
        if(Type != null) request.SetValue("type", Type);
        if(Message != null) request.SetObject("message", Message);
        if(PowerUp != null) request.SetObject("power_up", PowerUp);
        if(CustomPowerUp != null) request.SetObject("custom_power_up", CustomPowerUp);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "Message");
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
            /// The type of message fragment. Possible values are: textcheermoteemote
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Optional. The metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote? Cheermote { get => field ??= _data.Get<TwitchCheermote>("cheermote"); set; }
        
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
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "Fragments");
                if(Text != null) request.SetValue("text", Text);
                if(Type != null) request.SetValue("type", Type);
                if(Emote != null) request.SetObject("emote", Emote);
                if(Cheermote != null) request.SetObject("cheermote", Cheermote);
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
                        Id = data.Read("id", static v => v.AsString()),
                        EmoteSetId = data.Read("emote_set_id", static v => v.AsString()),
                        OwnerId = data.Read("owner_id", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "Emote");
                    if(Id != null) request.SetValue("id", Id);
                    if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
                    if(OwnerId != null) request.SetValue("owner_id", OwnerId);
                    if(Format != null) request.SetValue("format", new Godot.Collections.Array<string>(Format));
                    return request;
                }
            
                /// <summary> Releases the twitcher object this instance was mapped from. </summary>
                protected override void Dispose(bool disposing)
                {
                    if (disposing) _data.Dispose();
                    base.Dispose(disposing);
                }
            }
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                private Variant _data;
                
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
                        Prefix = data.Read("prefix", static v => v.AsString()),
                        Bits = data.Read("bits", static v => v.AsInt32()),
                        Tier = data.Read("tier", static v => v.AsInt32()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "Cheermote");
                    if(Prefix != null) request.SetValue("prefix", Prefix);
                    request.SetValue("bits", Bits);
                    request.SetValue("tier", Tier);
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

    public partial class TwitchPowerUp : RefCounted, ITwitcherSharpEventSub<TwitchPowerUp>
    {
        private Variant _data;
        
        /// <summary> 
        /// Possible values: message_effectcelebrationgigantify_an_emote
        /// </summary>
        public string? Type { get; set; }
    
        /// <summary> 
        /// Optional. Emote associated with the reward.
        /// </summary>
        public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
    
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
                Type = data.Read("type", static v => v.AsString()),
                MessageEffectId = data.Read("message_effect_id", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "PowerUp");
            if(Type != null) request.SetValue("type", Type);
            if(Emote != null) request.SetObject("emote", Emote);
            if(MessageEffectId != null) request.SetValue("message_effect_id", MessageEffectId);
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
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "Emote");
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

    public partial class TwitchCustomPowerUp : RefCounted, ITwitcherSharpEventSub<TwitchCustomPowerUp>
    {
        private Variant _data;
        
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
                Title = data.Read("title", static v => v.AsString()),
                RewardId = data.Read("reward_id", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_bits_use.gd", "CustomPowerUp");
            if(Title != null) request.SetValue("title", Title);
            if(RewardId != null) request.SetValue("reward_id", RewardId);
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
