using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class GetBlockedTermsResponse : Resource, ITwitcherSharp<GetBlockedTermsResponse>
{
    private GodotObject _data;
	public BlockedTerm[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetBlockedTermsResponse object.
    /// </summary> 
    public static GetBlockedTermsResponse FromObject(GodotObject data)
    {
        return new GetBlockedTermsResponse
        {

			Data = data.Get("data").As<BlockedTerm[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_blocked_terms_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
