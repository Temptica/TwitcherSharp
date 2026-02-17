using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

/// <summary> 
///  
/// </summary>
public partial class TwitchBanUserBody : Resource, ITwitcherSharp<TwitchBanUserBody>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserBody object.
    /// </summary> 
    public static TwitchBanUserBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchBanUserBody
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	/// Identifies the user and type of ban. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string UserId { get; set; }
		public int? Duration { get; set; }
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
				Duration = data.Get("duration").AsInt32(),
				Reason = data.Get("reason").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("user_id", UserId);
			if(Duration.HasValue) request.Set("duration", Duration.Value);
			if(Reason != null) request.Set("reason", Reason);
			return request;
		}
	
	}

}
