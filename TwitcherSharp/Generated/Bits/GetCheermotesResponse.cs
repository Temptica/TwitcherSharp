using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Bits;
 
/// <summary> 
///  
/// </summary>
public partial class GetCheermotesResponse : Resource, ITwitcherSharp<GetCheermotesResponse>
{
    private GodotObject _data;
	public Cheermote[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCheermotesResponse object.
    /// </summary> 
    public static GetCheermotesResponse FromObject(GodotObject data)
    {
        return new GetCheermotesResponse
        {

			Data = data.Get("data").As<Cheermote[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
