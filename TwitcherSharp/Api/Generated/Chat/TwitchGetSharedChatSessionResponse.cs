using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetSharedChatSessionResponse : Resource, ITwitcherSharp<TwitchGetSharedChatSessionResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetSharedChatSessionResponse object.
    /// </summary> 
    public static TwitchGetSharedChatSessionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetSharedChatSessionResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string SessionId { get; set; }
		public string HostBroadcasterId { get; set; }
		public TwitchParticipants[] Participants { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			var participantsArray = data.Get("participants").AsGodotArray<GodotObject>();
			return new TwitchData
			{
				SessionId = data.Get("session_id").AsString(),
				HostBroadcasterId = data.Get("host_broadcaster_id").AsString(),
				Participants = participantsArray.Select(TwitchParticipants.FromObject).ToArray(),
				CreatedAt = data.Get("created_at").AsString(),
				UpdatedAt = data.Get("updated_at").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("session_id", SessionId);
			request.Set("host_broadcaster_id", HostBroadcasterId);
			request.Set("participants", Participants);
			request.Set("created_at", CreatedAt);
			request.Set("updated_at", UpdatedAt);
			return request;
		}
		
		/// <summary> 
		/// The list of participants in the session. 
		/// </summary>
		public partial class TwitchParticipants : Resource, ITwitcherSharp<TwitchParticipants>
		{
		    private GodotObject _data;
			public string BroadcasterId { get; set; }
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchParticipants object.
		    /// </summary> 
		    public static TwitchParticipants FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchParticipants
				{
					BroadcasterId = data.Get("broadcaster_id").AsString(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_participants.gd");
				var request = script.Call("new").AsGodotObject();
				request.Set("broadcaster_id", BroadcasterId);
				return request;
			}
		
		}
	
	}

}
