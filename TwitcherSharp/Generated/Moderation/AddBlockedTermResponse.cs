using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class AddBlockedTermResponse : Resource, ITwitcherSharp<AddBlockedTermResponse>
{
    private GodotObject _data;
	public BlockedTerm[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a AddBlockedTermResponse object.
    /// </summary> 
    public static AddBlockedTermResponse FromObject(GodotObject data)
    {
        return new AddBlockedTermResponse
        {

			Data = data.Get("data").As<BlockedTerm[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_blocked_term_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
