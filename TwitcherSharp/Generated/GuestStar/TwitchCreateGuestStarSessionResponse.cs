using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreateGuestStarSessionResponse : Resource, ITwitcherSharp<TwitchCreateGuestStarSessionResponse>
{
    private GodotObject _data;
	public TwitchGuestStarSession[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateGuestStarSessionResponse object.
    /// </summary> 
    public static TwitchCreateGuestStarSessionResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateGuestStarSessionResponse
		{
			Data = dataArray.Select(TwitchGuestStarSession.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_guest_star_session.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
