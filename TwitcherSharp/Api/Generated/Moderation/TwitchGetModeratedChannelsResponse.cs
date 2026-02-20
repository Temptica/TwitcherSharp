using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetModeratedChannelsResponse : Resource, ITwitcherSharp<TwitchGetModeratedChannelsResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetModeratedChannelsResponse object.
    /// </summary> 
    public static TwitchGetModeratedChannelsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetModeratedChannelsResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderated_channels.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
	
	/// <summary> 
	/// The list of channels that the user has moderator privileges in. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string BroadcasterId { get; set; }
		public string BroadcasterLogin { get; set; }
		public string BroadcasterName { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				BroadcasterId = data.Get("broadcaster_id").AsString(),
				BroadcasterLogin = data.Get("broadcaster_login").AsString(),
				BroadcasterName = data.Get("broadcaster_name").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("broadcaster_id", BroadcasterId);
			request.Set("broadcaster_login", BroadcasterLogin);
			request.Set("broadcaster_name", BroadcasterName);
			return request;
		}
	
	}

}
