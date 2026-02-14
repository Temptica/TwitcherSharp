using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetEmoteSetsResponse : Resource, ITwitcherSharp<TwitchGetEmoteSetsResponse>
{
    private GodotObject _data;
	public TwitchEmote[] Data { get; set; }
	public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEmoteSetsResponse object.
    /// </summary> 
    public static TwitchGetEmoteSetsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetEmoteSetsResponse
		{
			Data = dataArray.Select(TwitchEmote.FromObject).ToArray(),
			Template = data.Get("template").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_emote_sets.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		return request;
	}
}
