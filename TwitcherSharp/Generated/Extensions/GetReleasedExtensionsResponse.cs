using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class GetReleasedExtensionsResponse : Resource, ITwitcherSharp<GetReleasedExtensionsResponse>
{
    private GodotObject _data;
	public Extension[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetReleasedExtensionsResponse object.
    /// </summary> 
    public static GetReleasedExtensionsResponse FromObject(GodotObject data)
    {
        return new GetReleasedExtensionsResponse
        {

			Data = data.Get("data").As<Extension[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_released_extensions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
