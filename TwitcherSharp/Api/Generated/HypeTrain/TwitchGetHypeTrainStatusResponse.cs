using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetHypeTrainStatusResponse : Resource, ITwitcherSharp<TwitchGetHypeTrainStatusResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchAllTimeHigh AllTimeHigh { get; set; }
	public TwitchSharedAllTimeHigh SharedAllTimeHigh { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainStatusResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetHypeTrainStatusResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			AllTimeHigh = data.Get("all_time_high").As<TwitchAllTimeHigh>(),
			SharedAllTimeHigh = data.Get("shared_all_time_high").As<TwitchSharedAllTimeHigh>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("all_time_high", AllTimeHigh);
		request.Set("shared_all_time_high", SharedAllTimeHigh);
		return request;
	}
	
	/// <summary> 
	/// A list that contains information related to the channel’s Hype Train. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public TwitchCurrent Current { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				Current = data.Get("current").As<TwitchCurrent>(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("current", Current);
			return request;
		}
		
		/// <summary> 
		/// An object describing the current Hype Train. Null if a Hype Train is not active. 
		/// </summary>
		public partial class TwitchCurrent : Resource, ITwitcherSharp<TwitchCurrent>
		{
		    private GodotObject _data;
			public string Id { get; set; }
			public string BroadcasterUserId { get; set; }
			public string BroadcasterUserLogin { get; set; }
			public string BroadcasterUserName { get; set; }
			public int Level { get; set; }
			public int Total { get; set; }
			public int Progress { get; set; }
			public int Goal { get; set; }
			public TwitchTopContributions[] TopContributions { get; set; }
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchCurrent object.
		    /// </summary> 
		    public static TwitchCurrent FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				var topContributionsArray = data.Get("top_contributions").AsGodotArray<GodotObject>();
				return new TwitchCurrent
				{
					Id = data.Get("id").AsString(),
					BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
					BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
					BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
					Level = data.Get("level").AsInt32(),
					Total = data.Get("total").AsInt32(),
					Progress = data.Get("progress").AsInt32(),
					Goal = data.Get("goal").AsInt32(),
					TopContributions = topContributionsArray.Select(TwitchTopContributions.FromObject).ToArray(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_current.gd");
				var request = script.Call("new").AsGodotObject();
				request.Set("id", Id);
				request.Set("broadcaster_user_id", BroadcasterUserId);
				request.Set("broadcaster_user_login", BroadcasterUserLogin);
				request.Set("broadcaster_user_name", BroadcasterUserName);
				request.Set("level", Level);
				request.Set("total", Total);
				request.Set("progress", Progress);
				request.Set("goal", Goal);
				request.Set("top_contributions", TopContributions);
				return request;
			}
			
			/// <summary> 
			/// The contributors with the most points contributed. 
			/// </summary>
			public partial class TwitchTopContributions : Resource, ITwitcherSharp<TwitchTopContributions>
			{
			    private GodotObject _data;
				public string UserId { get; set; }
				public string UserLogin { get; set; }
				public string UserName { get; set; }
				public string Type { get; set; }
				public int Total { get; set; }
				public TwitchSharedTrainParticipants[] SharedTrainParticipants { get; set; }
				public string StartedAt { get; set; }
				public string ExpiresAt { get; set; }
				public bool IsSharedTrain { get; set; }
			
			    /// <summary> 
			    /// Transforms the godot data into a TwitchTopContributions object.
			    /// </summary> 
			    public static TwitchTopContributions FromObject(GodotObject data)
			    {
			        if(data == null) return null;
					var sharedTrainParticipantsArray = data.Get("shared_train_participants").AsGodotArray<GodotObject>();
					return new TwitchTopContributions
					{
						UserId = data.Get("user_id").AsString(),
						UserLogin = data.Get("user_login").AsString(),
						UserName = data.Get("user_name").AsString(),
						Type = data.Get("type").AsString(),
						Total = data.Get("total").AsInt32(),
						SharedTrainParticipants = sharedTrainParticipantsArray.Select(TwitchSharedTrainParticipants.FromObject).ToArray(),
						StartedAt = data.Get("started_at").AsString(),
						ExpiresAt = data.Get("expires_at").AsString(),
						IsSharedTrain = data.Get("is_shared_train").AsBool(),
					};
				}
			
				public GodotObject ToGodotObject()
				{
					var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_top_contributions.gd");
					var request = script.Call("new").AsGodotObject();
					request.Set("user_id", UserId);
					request.Set("user_login", UserLogin);
					request.Set("user_name", UserName);
					request.Set("type", Type);
					request.Set("total", Total);
					request.Set("shared_train_participants", SharedTrainParticipants);
					request.Set("started_at", StartedAt);
					request.Set("expires_at", ExpiresAt);
					request.Set("is_shared_train", IsSharedTrain);
					return request;
				}
				
				/// <summary> 
				/// A list containing the broadcasters participating in the shared Hype Train. Null if the Hype Train is not shared. 
				/// </summary>
				public partial class TwitchSharedTrainParticipants : Resource, ITwitcherSharp<TwitchSharedTrainParticipants>
				{
				    private GodotObject _data;
					public string BroadcasterUserId { get; set; }
					public string BroadcasterUserLogin { get; set; }
					public string BroadcasterUserName { get; set; }
				
				    /// <summary> 
				    /// Transforms the godot data into a TwitchSharedTrainParticipants object.
				    /// </summary> 
				    public static TwitchSharedTrainParticipants FromObject(GodotObject data)
				    {
				        if(data == null) return null;
						return new TwitchSharedTrainParticipants
						{
							BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
							BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
							BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
						};
					}
				
					public GodotObject ToGodotObject()
					{
						var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_shared_train_participants.gd");
						var request = script.Call("new").AsGodotObject();
						request.Set("broadcaster_user_id", BroadcasterUserId);
						request.Set("broadcaster_user_login", BroadcasterUserLogin);
						request.Set("broadcaster_user_name", BroadcasterUserName);
						return request;
					}
				
				}
			
			}
		
		}
	
	}
	
	/// <summary> 
	/// An object with information about the channel’s Hype Train records. Null if a Hype Train has not occurred. 
	/// </summary>
	public partial class TwitchAllTimeHigh : Resource, ITwitcherSharp<TwitchAllTimeHigh>
	{
	    private GodotObject _data;
		public int Level { get; set; }
		public int Total { get; set; }
		public string AchievedAt { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchAllTimeHigh object.
	    /// </summary> 
	    public static TwitchAllTimeHigh FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchAllTimeHigh
			{
				Level = data.Get("level").AsInt32(),
				Total = data.Get("total").AsInt32(),
				AchievedAt = data.Get("achieved_at").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_all_time_high.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("level", Level);
			request.Set("total", Total);
			request.Set("achieved_at", AchievedAt);
			return request;
		}
	
	}
	
	/// <summary> 
	/// An object with information about the channel’s shared Hype Train records. Null if a Hype Train has not occurred. 
	/// </summary>
	public partial class TwitchSharedAllTimeHigh : Resource, ITwitcherSharp<TwitchSharedAllTimeHigh>
	{
	    private GodotObject _data;
		public int Level { get; set; }
		public int Total { get; set; }
		public string AchievedAt { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchSharedAllTimeHigh object.
	    /// </summary> 
	    public static TwitchSharedAllTimeHigh FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchSharedAllTimeHigh
			{
				Level = data.Get("level").AsInt32(),
				Total = data.Get("total").AsInt32(),
				AchievedAt = data.Get("achieved_at").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_shared_all_time_high.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("level", Level);
			request.Set("total", Total);
			request.Set("achieved_at", AchievedAt);
			return request;
		}
	
	}

}
