using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

/// <summary> 
///  
/// </summary>
public partial class TwitchWarnChatUserBody : Resource, ITwitcherSharp<TwitchWarnChatUserBody>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWarnChatUserBody object.
    /// </summary> 
    public static TwitchWarnChatUserBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchWarnChatUserBody
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	/// A list that contains information about the warning. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string UserId { get; set; }
		public string Reason { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				UserId = data.Get("user_id").AsString(),
				Reason = data.Get("reason").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("user_id", UserId);
			request.Set("reason", Reason);
			return request;
		}
	
	}

}
