using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatMessageResponse : RefCounted, ITwitcherSharp<TwitchSendChatMessageResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatMessageResponse object.
    /// </summary> 
    public static TwitchSendChatMessageResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendChatMessageResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_chat_message.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string MessageId { get; set; } = null!;
        public bool IsSent { get; set; }
        public TwitchResponseDropReason? DropReason { get => field ??= _data.Get<TwitchResponseDropReason>("drop_reason"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                MessageId = data.Read("message_id", static v => v.AsString()),
                IsSent = data.Read("is_sent", static v => v.AsBool()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_chat_message.gd", "ResponseData");
            if(MessageId != null) request.SetValue("message_id", MessageId);
            request.SetValue("is_sent", IsSent);
            if(DropReason != null) request.SetValue("drop_reason", DropReason);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// The reason the message was dropped, if any. 
        /// </summary>
        public partial class TwitchResponseDropReason : RefCounted, ITwitcherSharp<TwitchResponseDropReason>
        {
            private Variant _data;
            public string Code { get; set; } = null!;
            public string Message { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseDropReason object.
            /// </summary> 
            public static TwitchResponseDropReason? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseDropReason
                {
                    Code = data.Read("code", static v => v.AsString()),
                    Message = data.Read("message", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_chat_message.gd", "ResponseDropReason");
                if(Code != null) request.SetValue("code", Code);
                if(Message != null) request.SetValue("message", Message);
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
