using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

/// <summary> 
///  
/// </summary>
public partial class TwitchSendChatMessageResponse : Resource, ITwitcherSharp<TwitchSendChatMessageResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatMessageResponse object.
    /// </summary> 
    public static TwitchSendChatMessageResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchSendChatMessageResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string MessageId { get; set; }
		public bool IsSent { get; set; }
		public TwitchDropReason DropReason { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				MessageId = data.Get("message_id").AsString(),
				IsSent = data.Get("is_sent").AsBool(),
				DropReason = data.Get("drop_reason").As<TwitchDropReason>(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("message_id", MessageId);
			request.Set("is_sent", IsSent);
			if(DropReason != null) request.Set("drop_reason", DropReason);
			return request;
		}
		
		/// <summary> 
		/// The reason the message was dropped, if any. 
		/// </summary>
		public partial class TwitchDropReason : Resource, ITwitcherSharp<TwitchDropReason>
		{
		    private GodotObject _data;
			public string Code { get; set; }
			public string Message { get; set; }
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchDropReason object.
		    /// </summary> 
		    public static TwitchDropReason FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchDropReason
				{
					Code = data.Get("code").AsString(),
					Message = data.Get("message").AsString(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drop_reason.gd");
				var request = script.Call("new").AsGodotObject();
				request.Set("code", Code);
				request.Set("message", Message);
				return request;
			}
		
		}
	
	}

}
