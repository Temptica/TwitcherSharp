using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetPinnedChatMessageResponse : RefCounted, ITwitcherSharp<TwitchGetPinnedChatMessageResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPinnedChatMessageResponse object.
    /// </summary> 
    public static TwitchGetPinnedChatMessageResponse FromObject(GodotObject data)
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
        if(Data != null) request.SetArray("data", Data);
        return request;
    }
    
    /// <summary> 
    /// Pinned messages. Empty if none pinned. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string MessageId { get; set; }
        public string BroadcasterId { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUserLogin { get; set; }
        public string SenderUserName { get; set; }
        public string PinnedByUserId { get; set; }
        public string PinnedByUserLogin { get; set; }
        public string PinnedByUserName { get; set; }
        public TwitchResponseMessage Message { get => field ??= _data?.Get<TwitchResponseMessage>("message"); set; }
        public string StartsAt { get; set; }
        public string EndsAt { get; set; }
        public string UpdatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
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
            request.Set("message_id", MessageId);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("sender_user_id", SenderUserId);
            request.Set("sender_user_login", SenderUserLogin);
            request.Set("sender_user_name", SenderUserName);
            request.Set("pinned_by_user_id", PinnedByUserId);
            request.Set("pinned_by_user_login", PinnedByUserLogin);
            request.Set("pinned_by_user_name", PinnedByUserName);
            request.Set("message", Message?.ToGodotObject());
            request.Set("starts_at", StartsAt);
            request.Set("ends_at", EndsAt);
            request.Set("updated_at", UpdatedAt);
            return request;
        }
        
        /// <summary> 
        /// The pinned message content. 
        /// </summary>
        public partial class TwitchResponseMessage : RefCounted, ITwitcherSharp<TwitchResponseMessage>
        {
            private GodotObject _data;
            public string Text { get; set; }
            public TwitchResponseFragments[] Fragments { get => field ??= _data?.GetArray<TwitchResponseFragments>("fragments"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMessage object.
            /// </summary> 
            public static TwitchResponseMessage FromObject(GodotObject data)
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
                request.Set("text", Text);
                if(Fragments != null) request.SetArray("fragments", Fragments);
                return request;
            }
            
            /// <summary> 
            /// Ordered list of message fragments. 
            /// </summary>
            public partial class TwitchResponseFragments : RefCounted, ITwitcherSharp<TwitchResponseFragments>
            {
                private GodotObject _data;
                public string Type { get; set; }
                public string Text { get; set; }
                public Variant Cheermote { get; set; }
                public string Prefix { get; set; }
                public int Bits { get; set; }
                public int Tier { get; set; }
                public Variant Emote { get; set; }
                public string Id { get; set; }
                public string EmoteSetId { get; set; }
                public string OwnerId { get; set; }
                public string[] Format { get; set; }
                public Variant Mention { get; set; }
                public string UserId { get; set; }
                public string UserLogin { get; set; }
                public string UserName { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchResponseFragments object.
                /// </summary> 
                public static TwitchResponseFragments FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    var instance = new TwitchResponseFragments
                    {
                        Type = data.Get("type").AsString(),
                        Text = data.Get("text").AsString(),
                        Cheermote = data.Get("cheermote").As<Variant>(),
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                        Emote = data.Get("emote").As<Variant>(),
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                        OwnerId = data.Get("owner_id").AsString(),
                        Format = data.Get("format").AsStringArray(),
                        Mention = data.Get("mention").As<Variant>(),
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
                    var twitchResponseFragmentsClass = script.Get("ResponseFragments").AsGodotObject();
                    var request = twitchResponseFragmentsClass.Call("new").AsGodotObject();
                    request.Set("type", Type);
                    request.Set("text", Text);
                    request.Set("cheermote", Cheermote);
                    request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    request.Set("emote", Emote);
                    request.Set("id", Id);
                    request.Set("emote_set_id", EmoteSetId);
                    request.Set("owner_id", OwnerId);
                    if(Format != null) request.Set("format", new Godot.Collections.Array<string>(Format));
                    request.Set("mention", Mention);
                    request.Set("user_id", UserId);
                    request.Set("user_login", UserLogin);
                    request.Set("user_name", UserName);
                    return request;
                }
            
            }
        
        }
    
    }

}
