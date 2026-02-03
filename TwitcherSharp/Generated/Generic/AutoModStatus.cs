using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class AutoModStatus : Resource, ITwitcherSharp<AutoModStatus>
{
    private GodotObject _data;
	public string MsgId { get; set; }
	public bool IsPermitted { get; set; }
    /// <summary> 
    /// Transforms the godot data into a AutoModStatus object.
    /// </summary> 
    public static AutoModStatus FromObject(GodotObject data)
    {
        return new AutoModStatus
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
