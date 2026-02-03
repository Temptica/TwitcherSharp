using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class GetModeratorsResponse : Resource, ITwitcherSharp<GetModeratorsResponse>
{
    private GodotObject _data;
	public UserModerator[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetModeratorsResponse object.
    /// </summary> 
    public static GetModeratorsResponse FromObject(GodotObject data)
    {
        return new GetModeratorsResponse
        {

			Data = data.Get("data").As<UserModerator[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderators_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
