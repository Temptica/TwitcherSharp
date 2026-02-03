using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetEmoteSetsResponse : Resource, ITwitcherSharp<GetEmoteSetsResponse>
{
    private GodotObject _data;
	public Emote[] Data { get; set; }
	public string Template { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetEmoteSetsResponse object.
    /// </summary> 
    public static GetEmoteSetsResponse FromObject(GodotObject data)
    {
        return new GetEmoteSetsResponse
        {

			Data = data.Get("data").As<Emote[]>(),
			Template = data.Get("template").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_emote_sets_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		return request;
	}
}
