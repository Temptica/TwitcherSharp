using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class GetStreamKeyResponse : Resource, ITwitcherSharp<GetStreamKeyResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetStreamKeyResponse object.
    /// </summary> 
    public static GetStreamKeyResponse FromObject(GodotObject data)
    {
        return new GetStreamKeyResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_key_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
