using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatMessageResponse : RefCounted, ITwitcherSharp<TwitchSendChatMessageResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatMessageResponse object.
    /// </summary> 
    public static TwitchSendChatMessageResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendChatMessageResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string MessageId { get; set; } = null!;
        public bool IsSent { get; set; }
        public TwitchResponseDropReason? DropReason { get => field ??= _data?.Get<TwitchResponseDropReason>("drop_reason"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                MessageId = data.Get("message_id").AsString(),
                IsSent = data.Get("is_sent").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(MessageId != null) request.Set("message_id", MessageId);
            request.Set("is_sent", IsSent);
            if(DropReason != null) request.Set("drop_reason", DropReason);
            return request;
        }
        
        /// <summary> 
        /// The reason the message was dropped, if any. 
        /// </summary>
        public partial class TwitchResponseDropReason : RefCounted, ITwitcherSharp<TwitchResponseDropReason>
        {
            private GodotObject? _data;
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
                    Code = data.Get("code").AsString(),
                    Message = data.Get("message").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
                var twitchResponseDropReasonClass = script.Get("ResponseDropReason").AsGodotObject();
                var request = twitchResponseDropReasonClass.Call("new").AsGodotObject();
                if(Code != null) request.Set("code", Code);
                if(Message != null) request.Set("message", Message);
                return request;
            }
        
        }
    
    }

}
