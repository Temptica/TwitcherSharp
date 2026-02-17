using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetGameAnalyticsResponse : Resource, ITwitcherSharp<TwitchGetGameAnalyticsResponse>
{
    private GodotObject _data;
	public TwitchGameAnalytics[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGameAnalyticsResponse object.
    /// </summary> 
    public static TwitchGetGameAnalyticsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetGameAnalyticsResponse
		{
			Data = dataArray.Select(TwitchGameAnalytics.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_game_analytics.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchGameAnalytics : Resource, ITwitcherSharp<TwitchGameAnalytics>
	{
	    private GodotObject _data;
		public string GameId { get; set; }
		public string URL { get; set; }
		public string Type { get; set; }
		public TwitchDateRange DateRange { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchGameAnalytics object.
	    /// </summary> 
	    public static TwitchGameAnalytics FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchGameAnalytics
			{
				GameId = data.Get("game_id").AsString(),
				URL = data.Get("u_r_l").AsString(),
				Type = data.Get("type").AsString(),
				DateRange = data.Get("date_range").As<TwitchDateRange>(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("game_id", GameId);
			request.Set("u_r_l", URL);
			request.Set("type", Type);
			request.Set("date_range", DateRange);
			return request;
		}
		
		/// <summary> 
		/// The reporting window’s start and end dates, in RFC3339 format. 
		/// </summary>
		public partial class TwitchDateRange : Resource, ITwitcherSharp<TwitchDateRange>
		{
		    private GodotObject _data;
			public string StartedAt { get; set; }
			public string EndedAt { get; set; }
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchDateRange object.
		    /// </summary> 
		    public static TwitchDateRange FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchDateRange
				{
					StartedAt = data.Get("started_at").AsString(),
					EndedAt = data.Get("ended_at").AsString(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_date_range.gd");
				var request = script.Call("new").AsGodotObject();
				request.Set("started_at", StartedAt);
				request.Set("ended_at", EndedAt);
				return request;
			}
		
		}
	
	}

}
