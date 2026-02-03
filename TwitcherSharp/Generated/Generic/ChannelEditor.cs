using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ChannelEditor : Resource, ITwitcherSharp<ChannelEditor>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserName { get; set; }
	public string CreatedAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ChannelEditor object.
    /// </summary> 
    public static ChannelEditor FromObject(GodotObject data)
    {
        return new ChannelEditor
        {

			UserId = data.Get("user_id").AsString(),
			UserName = data.Get("user_name").AsString(),
			CreatedAt = data.Get("created_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_editor.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_name", UserName);
		request.Set("created_at", CreatedAt);
		return request;
	}
}
