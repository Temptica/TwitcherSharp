using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreateConduitsResponse : Resource, ITwitcherSharp<TwitchCreateConduitsResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateConduitsResponse object.
    /// </summary> 
    public static TwitchCreateConduitsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateConduitsResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_conduits.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
