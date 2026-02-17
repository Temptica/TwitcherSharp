using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetVIPsResponse : Resource, ITwitcherSharp<TwitchGetVIPsResponse>
{
    private GodotObject _data;
	public TwitchUserVip[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetVIPsResponse object.
    /// </summary> 
    public static TwitchGetVIPsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetVIPsResponse
		{
			Data = dataArray.Select(TwitchUserVip.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_v_i_ps.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchUserVip : Resource, ITwitcherSharp<TwitchUserVip>
	{
	    private GodotObject _data;
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string UserLogin { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchUserVip object.
	    /// </summary> 
	    public static TwitchUserVip FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchUserVip
			{
				UserId = data.Get("user_id").AsString(),
				UserName = data.Get("user_name").AsString(),
				UserLogin = data.Get("user_login").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_vip.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("user_id", UserId);
			request.Set("user_name", UserName);
			request.Set("user_login", UserLogin);
			return request;
		}
	
	}

}
