using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheckAutoModStatusResponse : Resource, ITwitcherSharp<TwitchCheckAutoModStatusResponse>
{
    private GodotObject _data;
	public TwitchAutoModStatus[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusResponse object.
    /// </summary> 
    public static TwitchCheckAutoModStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCheckAutoModStatusResponse
		{
			Data = dataArray.Select(TwitchAutoModStatus.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
