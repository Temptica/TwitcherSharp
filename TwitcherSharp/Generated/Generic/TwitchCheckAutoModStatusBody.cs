using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheckAutoModStatusBody : Resource, ITwitcherSharp<TwitchCheckAutoModStatusBody>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusBody object.
    /// </summary> 
    public static TwitchCheckAutoModStatusBody FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCheckAutoModStatusBody
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
