using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetBlockedTermsResponse : Resource, ITwitcherSharp<TwitchGetBlockedTermsResponse>
{
    private GodotObject _data;
	public TwitchBlockedTerm[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetBlockedTermsResponse object.
    /// </summary> 
    public static TwitchGetBlockedTermsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetBlockedTermsResponse
		{
			Data = dataArray.Select(TwitchBlockedTerm.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_blocked_terms.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
