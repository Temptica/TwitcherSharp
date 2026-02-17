using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetUserEmotesResponse : Resource, ITwitcherSharp<TwitchGetUserEmotesResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public string Template { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesResponse object.
    /// </summary> 
    public static TwitchGetUserEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetUserEmotesResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Template = data.Get("template").AsString(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string Id { get; set; }
		public string Name { get; set; }
		public string EmoteType { get; set; }
		public string EmoteSetId { get; set; }
		public string OwnerId { get; set; }
		public string[] Format { get; set; }
		public string[] Scale { get; set; }
		public string[] ThemeMode { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				Id = data.Get("id").AsString(),
				Name = data.Get("name").AsString(),
				EmoteType = data.Get("emote_type").AsString(),
				EmoteSetId = data.Get("emote_set_id").AsString(),
				OwnerId = data.Get("owner_id").AsString(),
				Format = data.Get("format").AsStringArray(),
				Scale = data.Get("scale").AsStringArray(),
				ThemeMode = data.Get("theme_mode").AsStringArray(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("id", Id);
			request.Set("name", Name);
			request.Set("emote_type", EmoteType);
			request.Set("emote_set_id", EmoteSetId);
			request.Set("owner_id", OwnerId);
			request.Set("format", Format);
			request.Set("scale", Scale);
			request.Set("theme_mode", ThemeMode);
			return request;
		}
	
	}

}
