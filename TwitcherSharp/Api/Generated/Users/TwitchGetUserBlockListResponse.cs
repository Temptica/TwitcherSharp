using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserBlockListResponse : Resource, ITwitcherSharp<TwitchGetUserBlockListResponse>
{
    private GodotObject _data;
	public TwitchUserBlockList[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserBlockListResponse object.
    /// </summary> 
    public static TwitchGetUserBlockListResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetUserBlockListResponse
		{
			Data = dataArray.Select(TwitchUserBlockList.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_block_list.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
	public partial class TwitchUserBlockList : Resource, ITwitcherSharp<TwitchUserBlockList>
	{
	    private GodotObject _data;
		public string UserId { get; set; }
		public string UserLogin { get; set; }
		public string DisplayName { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchUserBlockList object.
	    /// </summary> 
	    public static TwitchUserBlockList FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchUserBlockList
			{
				UserId = data.Get("user_id").AsString(),
				UserLogin = data.Get("user_login").AsString(),
				DisplayName = data.Get("display_name").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_block_list.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("user_id", UserId);
			request.Set("user_login", UserLogin);
			request.Set("display_name", DisplayName);
			return request;
		}
	
	}

}
