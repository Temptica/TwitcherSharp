using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetPinnedChatMessageResponse : RefCounted, ITwitcherSharp<TwitchGetPinnedChatMessageResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPinnedChatMessageResponse object.
    /// </summary> 
    public static TwitchGetPinnedChatMessageResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetPinnedChatMessageResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// Pinned messages. Empty if none pinned. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string MessageId { get; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string SenderUserId { get; set; } = null!;
        public string SenderUserLogin { get; set; } = null!;
        public string SenderUserName { get; set; } = null!;
        public string PinnedByUserId { get; set; } = null!;
        public string PinnedByUserLogin { get; set; } = null!;
        public string PinnedByUserName { get; set; } = null!;
        public TwitchResponseMessage? Message { get => field ??= _data?.Get<TwitchResponseMessage>("message"); set; }
        public string StartsAt { get; set; } = null!;
        public string? EndsAt { get; set; }
        public string UpdatedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                MessageId = data.Get("message_id").AsString(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                SenderUserId = data.Get("sender_user_id").AsString(),
                SenderUserLogin = data.Get("sender_user_login").AsString(),
                SenderUserName = data.Get("sender_user_name").AsString(),
                PinnedByUserId = data.Get("pinned_by_user_id").AsString(),
                PinnedByUserLogin = data.Get("pinned_by_user_login").AsString(),
                PinnedByUserName = data.Get("pinned_by_user_name").AsString(),
                StartsAt = data.Get("starts_at").AsString(),
                EndsAt = data.Get("ends_at").AsString(),
                UpdatedAt = data.Get("updated_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(MessageId != null) request.Set("message_id", MessageId);
            if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
            if(SenderUserId != null) request.Set("sender_user_id", SenderUserId);
            if(SenderUserLogin != null) request.Set("sender_user_login", SenderUserLogin);
            if(SenderUserName != null) request.Set("sender_user_name", SenderUserName);
            if(PinnedByUserId != null) request.Set("pinned_by_user_id", PinnedByUserId);
            if(PinnedByUserLogin != null) request.Set("pinned_by_user_login", PinnedByUserLogin);
            if(PinnedByUserName != null) request.Set("pinned_by_user_name", PinnedByUserName);
            if(Message != null) request.Set("message", Message.ToGodotObject());
            if(StartsAt != null) request.Set("starts_at", StartsAt);
            if(EndsAt != null) request.Set("ends_at", EndsAt);
            if(UpdatedAt != null) request.Set("updated_at", UpdatedAt);
            return request;
        }
        
        /// <summary> 
        /// The pinned message content. Null if the content isn't available. 
        /// </summary>
        public partial class TwitchResponseMessage : RefCounted, ITwitcherSharp<TwitchResponseMessage>
        {
            private GodotObject? _data;
            public string Text { get; set; } = null!;
            public TwitchResponseFragments[] Fragments { get => field ??= _data?.GetArray<TwitchResponseFragments>("fragments")!; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMessage object.
            /// </summary> 
            public static TwitchResponseMessage? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMessage
                {
                    Text = data.Get("text").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
                var twitchResponseMessageClass = script.Get("ResponseMessage").AsGodotObject();
                var request = twitchResponseMessageClass.Call("new").AsGodotObject();
                if(Text != null) request.Set("text", Text);
                if(Fragments != null) request.Set("fragments", Fragments.ToGodotArray());
                return request;
            }
            
            /// <summary> 
            /// Ordered list of message fragments. 
            /// </summary>
            public partial class TwitchResponseFragments : RefCounted, ITwitcherSharp<TwitchResponseFragments>
            {
                private GodotObject? _data;
                public string Type { get; set; } = null!;
                public string Text { get; set; } = null!;
                public TwitchResponseCheermote? Cheermote { get => field ??= _data?.Get<TwitchResponseCheermote>("cheermote"); set; }
                public TwitchResponseEmote? Emote { get => field ??= _data?.Get<TwitchResponseEmote>("emote"); set; }
                public TwitchResponseMention? Mention { get => field ??= _data?.Get<TwitchResponseMention>("mention"); set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchResponseFragments object.
                /// </summary> 
                public static TwitchResponseFragments? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchResponseFragments
                    {
                        Type = data.Get("type").AsString(),
                        Text = data.Get("text").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
                    var twitchResponseFragmentsClass = script.Get("ResponseFragments").AsGodotObject();
                    var request = twitchResponseFragmentsClass.Call("new").AsGodotObject();
                    if(Type != null) request.Set("type", Type);
                    if(Text != null) request.Set("text", Text);
                    if(Cheermote != null) request.Set("cheermote", Cheermote.ToGodotObject());
                    if(Emote != null) request.Set("emote", Emote.ToGodotObject());
                    if(Mention != null) request.Set("mention", Mention.ToGodotObject());
                    return request;
                }
                
                /// <summary> 
                /// Cheermote metadata. Null if not a cheermote fragment. 
                /// </summary>
                public partial class TwitchResponseCheermote : RefCounted, ITwitcherSharp<TwitchResponseCheermote>
                {
                    private GodotObject? _data;
                    public string Prefix { get; set; } = null!;
                    public int Bits { get; set; }
                    public int Tier { get; set; }
                
                    /// <summary> 
                    /// Transforms the godot data into a TwitchResponseCheermote object.
                    /// </summary> 
                    public static TwitchResponseCheermote? FromObject(GodotObject? data)
                    {
                        if(data == null) return null;
                        var instance = new TwitchResponseCheermote
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
                        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
                        var twitchResponseCheermoteClass = script.Get("ResponseCheermote").AsGodotObject();
                        var request = twitchResponseCheermoteClass.Call("new").AsGodotObject();
                        if(Prefix != null) request.Set("prefix", Prefix);
                        request.Set("bits", Bits);
                        request.Set("tier", Tier);
                        return request;
                    }
                
                }
                
                /// <summary> 
                /// Emote metadata. Null if not an emote fragment. 
                /// </summary>
                public partial class TwitchResponseEmote : RefCounted, ITwitcherSharp<TwitchResponseEmote>
                {
                    private GodotObject? _data;
                    public string Id { get; set; } = null!;
                    public string EmoteSetId { get; set; } = null!;
                    public string OwnerId { get; set; } = null!;
                    public string[] Format { get; set; } = null!;
                
                    /// <summary> 
                    /// Transforms the godot data into a TwitchResponseEmote object.
                    /// </summary> 
                    public static TwitchResponseEmote? FromObject(GodotObject? data)
                    {
                        if(data == null) return null;
                        var instance = new TwitchResponseEmote
                        {
                            Id = data.Get("id").AsString(),
                            EmoteSetId = data.Get("emote_set_id").AsString(),
                            OwnerId = data.Get("owner_id").AsString(),
                            Format = data.Get("format").AsStringArray(),
                        };
                        
                        instance._data = data;
                        return instance;
                    }
                
                    public GodotObject ToGodotObject()
                    {
                        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
                        var twitchResponseEmoteClass = script.Get("ResponseEmote").AsGodotObject();
                        var request = twitchResponseEmoteClass.Call("new").AsGodotObject();
                        if(Id != null) request.Set("id", Id);
                        if(EmoteSetId != null) request.Set("emote_set_id", EmoteSetId);
                        if(OwnerId != null) request.Set("owner_id", OwnerId);
                        if(Format != null) request.Set("format", new Godot.Collections.Array<string>(Format));
                        return request;
                    }
                
                }
                
                /// <summary> 
                /// Mention metadata. Null if not a mention fragment. 
                /// </summary>
                public partial class TwitchResponseMention : RefCounted, ITwitcherSharp<TwitchResponseMention>
                {
                    private GodotObject? _data;
                    public string UserId { get; set; } = null!;
                    public string UserLogin { get; set; } = null!;
                    public string UserName { get; set; } = null!;
                
                    /// <summary> 
                    /// Transforms the godot data into a TwitchResponseMention object.
                    /// </summary> 
                    public static TwitchResponseMention? FromObject(GodotObject? data)
                    {
                        if(data == null) return null;
                        var instance = new TwitchResponseMention
                        {
                            UserId = data.Get("user_id").AsString(),
                            UserLogin = data.Get("user_login").AsString(),
                            UserName = data.Get("user_name").AsString(),
                        };
                        
                        instance._data = data;
                        return instance;
                    }
                
                    public GodotObject ToGodotObject()
                    {
                        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd");
                        var twitchResponseMentionClass = script.Get("ResponseMention").AsGodotObject();
                        var request = twitchResponseMentionClass.Call("new").AsGodotObject();
                        if(UserId != null) request.Set("user_id", UserId);
                        if(UserLogin != null) request.Set("user_login", UserLogin);
                        if(UserName != null) request.Set("user_name", UserName);
                        return request;
                    }
                
                }
            
            }
        
        }
    
    }

}
