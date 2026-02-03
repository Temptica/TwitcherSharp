using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchStream : Resource, ITwitcherSharp<TwitchStream>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public string GameId { get; set; }
	public string GameName { get; set; }
	public string Type { get; set; }
	public string Title { get; set; }
	public int ViewerCount { get; set; }
	public string StartedAt { get; set; }
	public string Language { get; set; }
	public string ThumbnailUrl { get; set; }
	public string[] TagIds { get; set; }
	public string[] Tags { get; set; }
	public bool IsMature { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchStream object.
    /// </summary> 
    public static TwitchStream FromObject(GodotObject data)
    {
        return new TwitchStream
        {

			Id = data.Get("id").AsString(),
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			GameId = data.Get("game_id").AsString(),
			GameName = data.Get("game_name").AsString(),
			Type = data.Get("type").AsString(),
			Title = data.Get("title").AsString(),
			ViewerCount = data.Get("viewer_count").AsInt32(),
			StartedAt = data.Get("started_at").AsString(),
			Language = data.Get("language").AsString(),
			ThumbnailUrl = data.Get("thumbnail_url").AsString(),
			TagIds = data.Get("tag_ids").AsStringArray(),
			Tags = data.Get("tags").AsStringArray(),
			IsMature = data.Get("is_mature").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_twitch_stream.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("game_id", GameId);
		request.Set("game_name", GameName);
		request.Set("type", Type);
		request.Set("title", Title);
		request.Set("viewer_count", ViewerCount);
		request.Set("started_at", StartedAt);
		request.Set("language", Language);
		request.Set("thumbnail_url", ThumbnailUrl);
		request.Set("tag_ids", TagIds);
		request.Set("tags", Tags);
		request.Set("is_mature", IsMature);
		return request;
	}
}
