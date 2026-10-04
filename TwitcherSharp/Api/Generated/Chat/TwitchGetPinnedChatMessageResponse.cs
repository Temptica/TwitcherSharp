using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetPinnedChatMessageResponse : RefCounted, ITwitcherSharp<TwitchGetPinnedChatMessageResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPinnedChatMessageResponse object.
    /// </summary> 
    public static TwitchGetPinnedChatMessageResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetPinnedChatMessageResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// Pinned messages. Empty if none pinned. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string MessageId { get; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string SenderUserId { get; set; } = null!;
        public string SenderUserLogin { get; set; } = null!;
        public string SenderUserName { get; set; } = null!;
        public string PinnedByUserId { get; set; } = null!;
        public string PinnedByUserLogin { get; set; } = null!;
        public string PinnedByUserName { get; set; } = null!;
        public TwitchResponseMessage Message { get => field ??= _data.Get<TwitchResponseMessage>("message")!; set; } = null!;
        public string StartsAt { get; set; } = null!;
        public string EndsAt { get; set; } = null!;
        public string UpdatedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                MessageId = data.Read("message_id", static v => v.AsString()),
                BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                SenderUserId = data.Read("sender_user_id", static v => v.AsString()),
                SenderUserLogin = data.Read("sender_user_login", static v => v.AsString()),
                SenderUserName = data.Read("sender_user_name", static v => v.AsString()),
                PinnedByUserId = data.Read("pinned_by_user_id", static v => v.AsString()),
                PinnedByUserLogin = data.Read("pinned_by_user_login", static v => v.AsString()),
                PinnedByUserName = data.Read("pinned_by_user_name", static v => v.AsString()),
                StartsAt = data.Read("starts_at", static v => v.AsString()),
                EndsAt = data.Read("ends_at", static v => v.AsString()),
                UpdatedAt = data.Read("updated_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd", "ResponseData");
            if(MessageId != null) request.SetValue("message_id", MessageId);
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(SenderUserId != null) request.SetValue("sender_user_id", SenderUserId);
            if(SenderUserLogin != null) request.SetValue("sender_user_login", SenderUserLogin);
            if(SenderUserName != null) request.SetValue("sender_user_name", SenderUserName);
            if(PinnedByUserId != null) request.SetValue("pinned_by_user_id", PinnedByUserId);
            if(PinnedByUserLogin != null) request.SetValue("pinned_by_user_login", PinnedByUserLogin);
            if(PinnedByUserName != null) request.SetValue("pinned_by_user_name", PinnedByUserName);
            if(Message != null) request.SetObject("message", Message);
            if(StartsAt != null) request.SetValue("starts_at", StartsAt);
            if(EndsAt != null) request.SetValue("ends_at", EndsAt);
            if(UpdatedAt != null) request.SetValue("updated_at", UpdatedAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// The pinned message content. 
        /// </summary>
        public partial class TwitchResponseMessage : RefCounted, ITwitcherSharp<TwitchResponseMessage>
        {
            private Variant _data;
            public string Text { get; set; } = null!;
            public TwitchResponseFragments[] Fragments { get => field ??= _data.GetArray<TwitchResponseFragments>("fragments")!; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMessage object.
            /// </summary> 
            public static TwitchResponseMessage? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMessage
                {
                    Text = data.Read("text", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd", "ResponseMessage");
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
            
            /// <summary> 
            /// Ordered list of message fragments. 
            /// </summary>
            public partial class TwitchResponseFragments : RefCounted, ITwitcherSharp<TwitchResponseFragments>
            {
                private Variant _data;
                public string Type { get; set; } = null!;
                public string Text { get; set; } = null!;
                public Variant Cheermote { get; set; }
                public string Prefix { get; set; } = null!;
                public int Bits { get; set; }
                public int Tier { get; set; }
                public Variant Emote { get; set; }
                public string Id { get; set; } = null!;
                public string EmoteSetId { get; set; } = null!;
                public string OwnerId { get; set; } = null!;
                public string[] Format { get; set; } = null!;
                public Variant Mention { get; set; }
                public string UserId { get; set; } = null!;
                public string UserLogin { get; set; } = null!;
                public string UserName { get; set; } = null!;
            
                /// <summary> 
                /// Transforms the godot data into a TwitchResponseFragments object.
                /// </summary> 
                public static TwitchResponseFragments? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchResponseFragments
                    {
                        Type = data.Read("type", static v => v.AsString()),
                        Text = data.Read("text", static v => v.AsString()),
                        Cheermote = data.Read("cheermote", static v => v.As<Variant>()),
                        Prefix = data.Read("prefix", static v => v.AsString()),
                        Bits = data.Read("bits", static v => v.AsInt32()),
                        Tier = data.Read("tier", static v => v.AsInt32()),
                        Emote = data.Read("emote", static v => v.As<Variant>()),
                        Id = data.Read("id", static v => v.AsString()),
                        EmoteSetId = data.Read("emote_set_id", static v => v.AsString()),
                        OwnerId = data.Read("owner_id", static v => v.AsString()),
                        Format = data.Read("format", static v => v.AsStringArray()),
                        Mention = data.Read("mention", static v => v.As<Variant>()),
                        UserId = data.Read("user_id", static v => v.AsString()),
                        UserLogin = data.Read("user_login", static v => v.AsString()),
                        UserName = data.Read("user_name", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_pinned_chat_message.gd", "ResponseFragments");
                    if(Type != null) request.SetValue("type", Type);
                    if(Text != null) request.SetValue("text", Text);
                    request.SetValue("cheermote", Cheermote);
                    if(Prefix != null) request.SetValue("prefix", Prefix);
                    request.SetValue("bits", Bits);
                    request.SetValue("tier", Tier);
                    request.SetValue("emote", Emote);
                    if(Id != null) request.SetValue("id", Id);
                    if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
                    if(OwnerId != null) request.SetValue("owner_id", OwnerId);
                    if(Format != null) request.SetValue("format", new Godot.Collections.Array<string>(Format));
                    request.SetValue("mention", Mention);
                    if(UserId != null) request.SetValue("user_id", UserId);
                    if(UserLogin != null) request.SetValue("user_login", UserLogin);
                    if(UserName != null) request.SetValue("user_name", UserName);
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
