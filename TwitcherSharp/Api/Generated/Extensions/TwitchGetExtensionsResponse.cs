using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetExtensionsResponse : Resource, ITwitcherSharp<TwitchGetExtensionsResponse>
{
    private GodotObject _data;
	public TwitchExtension[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionsResponse object.
    /// </summary> 
    public static TwitchGetExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetExtensionsResponse
		{
			Data = dataArray.Select(TwitchExtension.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extensions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}

}
