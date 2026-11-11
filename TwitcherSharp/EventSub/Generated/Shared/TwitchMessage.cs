using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The contents of the message caught by AutoMod.
    /// </summary>
    public string? Text { get; set; }

    /// <summary> 
    /// Metadata surrounding the potential inappropriate fragments of the message.
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
        var request = script.New().AsGodotObject();
        if(Text != null) request.Set("text", Text);
        if(Fragments != null) request.Set("fragments", Fragments.ToGodotArray());
        return request;
    }


    public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// Message text within a fragment.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// Metadata pertaining to the emote.
        /// </summary>
        public TwitchEmote? Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
    
        /// <summary> 
        /// Metadata pertaining to the cheermote.
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
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
            var fragmentsClass = script.Get("Fragments").As<GDScript>();
            var request = fragmentsClass.New().AsGodotObject();
            if(Text != null) request.Set("text", Text);
            if(Emote != null) request.Set("emote", Emote.ToGodotObject());
            if(Cheermote != null) request.Set("cheermote", Cheermote.ToGodotObject());
            return request;
        }
    
    
        public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
        {
            private GodotObject? _data;
            
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
                    Id = data.Get("id").AsString(),
                    EmoteSetId = data.Get("emote_set_id").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
                var emoteClass = script.Get("Emote").As<GDScript>();
                var request = emoteClass.New().AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(EmoteSetId != null) request.Set("emote_set_id", EmoteSetId);
                return request;
            }
        }
    
        public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.
            /// 
            /// **For example**, if the prefix is "cheer" and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_message.gd");
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
