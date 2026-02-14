using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchAutoModStatus : Resource, ITwitcherSharp<TwitchAutoModStatus>
{
    private GodotObject _data;
	public string MsgId { get; set; }
	public bool IsPermitted { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutoModStatus object.
    /// </summary> 
    public static TwitchAutoModStatus FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchAutoModStatus
		{
			MsgId = data.Get("msg_id").AsString(),
			IsPermitted = data.Get("is_permitted").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_auto_mod_status.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("msg_id", MsgId);
		request.Set("is_permitted", IsPermitted);
		return request;
	}
}
