using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetCheermotesResponse : Resource, ITwitcherSharp<TwitchGetCheermotesResponse>
{
    private GodotObject _data;
	public TwitchCheermote[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesResponse object.
    /// </summary> 
    public static TwitchGetCheermotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetCheermotesResponse
		{
			Data = dataArray.Select(TwitchCheermote.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
