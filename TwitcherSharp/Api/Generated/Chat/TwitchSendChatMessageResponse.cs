using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatMessageResponse : RefCounted, ITwitcherSharp<TwitchSendChatMessageResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatMessageResponse object.
    /// </summary> 
    public static TwitchSendChatMessageResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchSendChatMessageResponse
        {
            Data = dataArray.Select(TwitchResponseData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string MessageId { get; set; }
        public bool IsSent { get; set; }
        public TwitchResponseDropReason DropReason { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                MessageId = data.Get("message_id").AsString(),
                IsSent = data.Get("is_sent").AsBool(),
                DropReason = data.Get("drop_reason").As<TwitchResponseDropReason>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("message_id", MessageId);
            request.Set("is_sent", IsSent);
            if(DropReason != null) request.Set("drop_reason", DropReason);
            return request;
        }
        
        /// <summary> 
        /// The reason the message was dropped, if any. 
        /// </summary>
        public partial class TwitchResponseDropReason : RefCounted, ITwitcherSharp<TwitchResponseDropReason>
        {
            private GodotObject _data;
            public string Code { get; set; }
            public string Message { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseDropReason object.
            /// </summary> 
            public static TwitchResponseDropReason FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchResponseDropReason
                {
                    Code = data.Get("code").AsString(),
                    Message = data.Get("message").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
                var twitchResponseDropReasonClass = script.Get("ResponseDropReason").AsGodotObject();
                var request = twitchResponseDropReasonClass.Call("new").AsGodotObject();
                request.Set("code", Code);
                request.Set("message", Message);
                return request;
            }
        
        }
    
    }

}
