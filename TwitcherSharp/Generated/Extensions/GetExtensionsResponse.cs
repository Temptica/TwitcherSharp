using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class GetExtensionsResponse : Resource, ITwitcherSharp<GetExtensionsResponse>
{
    private GodotObject _data;
	public Extension[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionsResponse object.
    /// </summary> 
    public static GetExtensionsResponse FromObject(GodotObject data)
    {
        return new GetExtensionsResponse
        {

			Data = data.Get("data").As<Extension[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extensions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
