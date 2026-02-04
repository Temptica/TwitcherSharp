using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// List of unsuccessful updates. 
/// </summary>
public partial class TwitchErrors : Resource, ITwitcherSharp<TwitchErrors>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Message { get; set; }
	public string Code { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchErrors object.
    /// </summary> 
    public static TwitchErrors FromObject(GodotObject data)
    {
		return new TwitchErrors
		{
			Id = data.Get("id").AsString(),
			Message = data.Get("message").AsString(),
			Code = data.Get("code").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_errors.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("message", Message);
		request.Set("code", Code);
		return request;
	}
}
