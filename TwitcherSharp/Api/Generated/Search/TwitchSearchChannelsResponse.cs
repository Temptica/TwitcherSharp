using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchSearchChannelsResponse : Resource, ITwitcherSharp<TwitchSearchChannelsResponse>
{
    private GodotObject _data;
	public TwitchChannel[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSearchChannelsResponse object.
    /// </summary> 
    public static TwitchSearchChannelsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchSearchChannelsResponse
		{
			Data = dataArray.Select(TwitchChannel.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_channels.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
	public partial class TwitchChannel : Resource, ITwitcherSharp<TwitchChannel>
	{
	    private GodotObject _data;
		public string BroadcasterLanguage { get; set; }
		public string BroadcasterLogin { get; set; }
		public string DisplayName { get; set; }
		public string GameId { get; set; }
		public string GameName { get; set; }
		public string Id { get; set; }
		public bool IsLive { get; set; }
		public string[] TagIds { get; set; }
		public string[] Tags { get; set; }
		public string ThumbnailUrl { get; set; }
		public string Title { get; set; }
		public string StartedAt { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchChannel object.
	    /// </summary> 
	    public static TwitchChannel FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchChannel
			{
				BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
				BroadcasterLogin = data.Get("broadcaster_login").AsString(),
				DisplayName = data.Get("display_name").AsString(),
				GameId = data.Get("game_id").AsString(),
				GameName = data.Get("game_name").AsString(),
				Id = data.Get("id").AsString(),
				IsLive = data.Get("is_live").AsBool(),
				TagIds = data.Get("tag_ids").AsStringArray(),
				Tags = data.Get("tags").AsStringArray(),
				ThumbnailUrl = data.Get("thumbnail_url").AsString(),
				Title = data.Get("title").AsString(),
				StartedAt = data.Get("started_at").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("broadcaster_language", BroadcasterLanguage);
			request.Set("broadcaster_login", BroadcasterLogin);
			request.Set("display_name", DisplayName);
			request.Set("game_id", GameId);
			request.Set("game_name", GameName);
			request.Set("id", Id);
			request.Set("is_live", IsLive);
			request.Set("tag_ids", TagIds);
			request.Set("tags", Tags);
			request.Set("thumbnail_url", ThumbnailUrl);
			request.Set("title", Title);
			request.Set("started_at", StartedAt);
			return request;
		}
	
	}

}
