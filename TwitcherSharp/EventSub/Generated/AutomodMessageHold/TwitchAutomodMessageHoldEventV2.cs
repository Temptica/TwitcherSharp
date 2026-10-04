using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodMessageHoldEventV2>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The message sender’s user ID.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The message sender’s login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The message sender’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The ID of the held message.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The timestamp of when automod saved the message.
    /// </summary>
    public string? HeldAt { get; set; }

    /// <summary> 
    /// Possible values are: automodblocked_term
    /// </summary>
    public string? Reason { get; set; }

    /// <summary> 
    /// Optional. If the message was caught by automod, this will be populated.
    /// </summary>
    public TwitchAutomodV2? AutomodV2 { get => field ??= _data.Get<TwitchAutomodV2>("automod"); set; }

    /// <summary> 
    /// Optional. If the message was caught due to a blocked term, this will be populated.
    /// </summary>
    public TwitchBlockedTermV2? BlockedTermV2 { get => field ??= _data.Get<TwitchBlockedTermV2>("blocked_term"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageHoldEventV2 object.
    /// </summary> 
    public static TwitchAutomodMessageHoldEventV2? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodMessageHoldEventV2
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            MessageId = data.Read("message_id", static v => v.AsString()),
            HeldAt = data.Read("held_at", static v => v.AsString()),
            Reason = data.Read("reason", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "EventV2");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(MessageId != null) request.SetValue("message_id", MessageId);
        if(Message != null) request.SetObject("message", Message);
        if(HeldAt != null) request.SetValue("held_at", HeldAt);
        if(Reason != null) request.SetValue("reason", Reason);
        if(AutomodV2 != null) request.SetObject("automod", AutomodV2);
        if(BlockedTermV2 != null) request.SetObject("blocked_term", BlockedTermV2);
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
        /// The contents of the message caught by automod.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// Metadata surrounding the potential inappropriate fragments of the message.
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "MessageV2");
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
            /// One of three options:textemotecheermote
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// Message text in a fragment.
            /// </summary>
            public string? Text { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
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
                    Type = data.Read("type", static v => v.AsString()),
                    Text = data.Read("text", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "FragmentsV2");
                if(Type != null) request.SetValue("type", Type);
                if(Text != null) request.SetValue("text", Text);
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
                /// An ID that uniquely identifies this emote.
                /// </summary>
                public string? Id { get; set; }
            
                /// <summary> 
                /// An ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string? EmoteSetId { get; set; }
            
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
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "EmoteV2");
                    if(Id != null) request.SetValue("id", Id);
                    if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
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
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "CheermoteV2");
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

    public partial class TwitchAutomodV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodV2>
    {
        private Variant _data;
        
        /// <summary> 
        /// The category of the caught message.
        /// </summary>
        public string? Category { get; set; }
    
        /// <summary> 
        /// The level of severity (1-4).
        /// </summary>
        public int Level { get; set; }
    
        /// <summary> 
        /// The bounds of the text that caused the message to be caught.
        /// </summary>
        public TwitchBoundariesV2[]? Boundaries { get => field ??= _data.GetArray<TwitchBoundariesV2>("boundaries"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAutomodV2 object.
        /// </summary> 
        public static TwitchAutomodV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAutomodV2
            {
                Category = data.Read("category", static v => v.AsString()),
                Level = data.Read("level", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "AutomodV2");
            if(Category != null) request.SetValue("category", Category);
            request.SetValue("level", Level);
            if(Boundaries != null) request.SetArray("boundaries", Boundaries);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchBoundariesV2 : RefCounted, ITwitcherSharpEventSub<TwitchBoundariesV2>
        {
            private Variant _data;
            
            /// <summary> 
            /// Index in the message for the start of the problem (0 indexed, inclusive).
            /// </summary>
            public int StartPos { get; set; }
        
            /// <summary> 
            /// Index in the message for the end of the problem (0 indexed, inclusive).
            /// </summary>
            public int EndPos { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchBoundariesV2 object.
            /// </summary> 
            public static TwitchBoundariesV2? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchBoundariesV2
                {
                    StartPos = data.Read("start_pos", static v => v.AsInt32()),
                    EndPos = data.Read("end_pos", static v => v.AsInt32()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "BoundariesV2");
                request.SetValue("start_pos", StartPos);
                request.SetValue("end_pos", EndPos);
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

    public partial class TwitchBlockedTermV2 : RefCounted, ITwitcherSharpEventSub<TwitchBlockedTermV2>
    {
        private Variant _data;
        
        /// <summary> 
        /// The list of blocked terms found in the message.
        /// </summary>
        public TwitchTermsFoundV2[]? TermsFound { get => field ??= _data.GetArray<TwitchTermsFoundV2>("terms_found"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBlockedTermV2 object.
        /// </summary> 
        public static TwitchBlockedTermV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBlockedTermV2
            {
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "BlockedTermV2");
            if(TermsFound != null) request.SetArray("terms_found", TermsFound);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchTermsFoundV2 : RefCounted, ITwitcherSharpEventSub<TwitchTermsFoundV2>
        {
            private Variant _data;
            
            /// <summary> 
            /// The id of the blocked term found.
            /// </summary>
            public string? TermId { get; set; }
        
            /// <summary> 
            /// The bounds of the text that caused the message to be caught.
            /// </summary>
            public TwitchBoundaryV2? BoundaryV2 { get => field ??= _data.Get<TwitchBoundaryV2>("boundary"); set; }
        
            /// <summary> 
            /// The id of the broadcaster that owns the blocked term.
            /// </summary>
            public string? OwnerBroadcasterUserId { get; set; }
        
            /// <summary> 
            /// The login of the broadcaster that owns the blocked term.
            /// </summary>
            public string? OwnerBroadcasterUserLogin { get; set; }
        
            /// <summary> 
            /// The username of the broadcaster that owns the blocked term.
            /// </summary>
            public string? OwnerBroadcasterUserName { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchTermsFoundV2 object.
            /// </summary> 
            public static TwitchTermsFoundV2? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchTermsFoundV2
                {
                    TermId = data.Read("term_id", static v => v.AsString()),
                    OwnerBroadcasterUserId = data.Read("owner_broadcaster_user_id", static v => v.AsString()),
                    OwnerBroadcasterUserLogin = data.Read("owner_broadcaster_user_login", static v => v.AsString()),
                    OwnerBroadcasterUserName = data.Read("owner_broadcaster_user_name", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "TermsFoundV2");
                if(TermId != null) request.SetValue("term_id", TermId);
                if(BoundaryV2 != null) request.SetObject("boundary", BoundaryV2);
                if(OwnerBroadcasterUserId != null) request.SetValue("owner_broadcaster_user_id", OwnerBroadcasterUserId);
                if(OwnerBroadcasterUserLogin != null) request.SetValue("owner_broadcaster_user_login", OwnerBroadcasterUserLogin);
                if(OwnerBroadcasterUserName != null) request.SetValue("owner_broadcaster_user_name", OwnerBroadcasterUserName);
                return request;
            }
        
            /// <summary> Releases the twitcher object this instance was mapped from. </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing) _data.Dispose();
                base.Dispose(disposing);
            }
        
        
            public partial class TwitchBoundaryV2 : RefCounted, ITwitcherSharpEventSub<TwitchBoundaryV2>
            {
                private Variant _data;
                
                /// <summary> 
                /// Index in the message for the start of the problem (0 indexed, inclusive).
                /// </summary>
                public int StartPos { get; set; }
            
                /// <summary> 
                /// Index in the message for the end of the problem (0 indexed, inclusive).
                /// </summary>
                public int EndPos { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchBoundaryV2 object.
                /// </summary> 
                public static TwitchBoundaryV2? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchBoundaryV2
                    {
                        StartPos = data.Read("start_pos", static v => v.AsInt32()),
                        EndPos = data.Read("end_pos", static v => v.AsInt32()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd", "BoundaryV2");
                    request.SetValue("start_pos", StartPos);
                    request.SetValue("end_pos", EndPos);
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
