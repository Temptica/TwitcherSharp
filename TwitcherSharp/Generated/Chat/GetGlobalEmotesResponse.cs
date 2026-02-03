using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetGlobalEmotesResponse : Resource, ITwitcherSharp<GetGlobalEmotesResponse>
{
    private GodotObject _data;
	public GlobalEmote[] Data { get; set; }
	public string Template { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGlobalEmotesResponse object.
    /// </summary> 
    public static GetGlobalEmotesResponse FromObject(GodotObject data)
    {
        return new GetGlobalEmotesResponse
        {

			Data = data.Get("data").As<GlobalEmote[]>(),
			Template = data.Get("template").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_global_emotes_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		return request;
	}
}
