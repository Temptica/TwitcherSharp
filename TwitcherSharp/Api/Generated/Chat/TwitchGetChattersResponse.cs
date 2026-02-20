using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChattersResponse : Resource, ITwitcherSharp<TwitchGetChattersResponse>
{
    private GodotObject _data;
	public TwitchChatter[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
	public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChattersResponse object.
    /// </summary> 
    public static TwitchGetChattersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetChattersResponse
		{
			Data = dataArray.Select(TwitchChatter.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chatters.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		request.Set("total", Total);
		return request;
	}
	public partial class TwitchChatter : Resource, ITwitcherSharp<TwitchChatter>
	{
	    private GodotObject _data;
		public string UserId { get; set; }
		public string UserLogin { get; set; }
		public string UserName { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchChatter object.
	    /// </summary> 
	    public static TwitchChatter FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchChatter
			{
				UserId = data.Get("user_id").AsString(),
				UserLogin = data.Get("user_login").AsString(),
				UserName = data.Get("user_name").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chatter.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("user_id", UserId);
			request.Set("user_login", UserLogin);
			request.Set("user_name", UserName);
			return request;
		}
	
	}

}
