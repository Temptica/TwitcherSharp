using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class GetModeratedChannelsResponse : Resource, ITwitcherSharp<GetModeratedChannelsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetModeratedChannelsResponse object.
    /// </summary> 
    public static GetModeratedChannelsResponse FromObject(GodotObject data)
    {
        return new GetModeratedChannelsResponse
        {

			Data = data.Get("data").As<Data[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderated_channels_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
