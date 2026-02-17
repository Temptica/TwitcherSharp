using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

/// <summary> 
///  
/// </summary>
public partial class TwitchPoll : Resource, ITwitcherSharp<TwitchPoll>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string BroadcasterId { get; set; }
	public string BroadcasterName { get; set; }
	public string BroadcasterLogin { get; set; }
	public string Title { get; set; }
	public TwitchChoices[] Choices { get; set; }
	public bool BitsVotingEnabled { get; set; }
	public int BitsPerVote { get; set; }
	public bool ChannelPointsVotingEnabled { get; set; }
	public int ChannelPointsPerVote { get; set; }
	public string Status { get; set; }
	public int Duration { get; set; }
	public string StartedAt { get; set; }
	public string EndedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchPoll object.
    /// </summary> 
    public static TwitchPoll FromObject(GodotObject data)
    {
        if(data == null) return null;
		var choicesArray = data.Get("choices").AsGodotArray<GodotObject>();
		return new TwitchPoll
		{
			Id = data.Get("id").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			Title = data.Get("title").AsString(),
			Choices = choicesArray.Select(TwitchChoices.FromObject).ToArray(),
			BitsVotingEnabled = data.Get("bits_voting_enabled").AsBool(),
			BitsPerVote = data.Get("bits_per_vote").AsInt32(),
			ChannelPointsVotingEnabled = data.Get("channel_points_voting_enabled").AsBool(),
			ChannelPointsPerVote = data.Get("channel_points_per_vote").AsInt32(),
			Status = data.Get("status").AsString(),
			Duration = data.Get("duration").AsInt32(),
			StartedAt = data.Get("started_at").AsString(),
			EndedAt = data.Get("ended_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_poll.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("broadcaster_name", BroadcasterName);
		request.Set("broadcaster_login", BroadcasterLogin);
		request.Set("title", Title);
		request.Set("choices", Choices);
		request.Set("bits_voting_enabled", BitsVotingEnabled);
		request.Set("bits_per_vote", BitsPerVote);
		request.Set("channel_points_voting_enabled", ChannelPointsVotingEnabled);
		request.Set("channel_points_per_vote", ChannelPointsPerVote);
		request.Set("status", Status);
		request.Set("duration", Duration);
		request.Set("started_at", StartedAt);
		request.Set("ended_at", EndedAt);
		return request;
	}
	
	/// <summary> 
	/// A list of choices that viewers can choose from. The list will contain a minimum of two choices and up to a maximum of five choices. 
	/// </summary>
	public partial class TwitchChoices : Resource, ITwitcherSharp<TwitchChoices>
	{
	    private GodotObject _data;
		public string Id { get; set; }
		public string Title { get; set; }
		public int Votes { get; set; }
		public int ChannelPointsVotes { get; set; }
		public int BitsVotes { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchChoices object.
	    /// </summary> 
	    public static TwitchChoices FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchChoices
			{
				Id = data.Get("id").AsString(),
				Title = data.Get("title").AsString(),
				Votes = data.Get("votes").AsInt32(),
				ChannelPointsVotes = data.Get("channel_points_votes").AsInt32(),
				BitsVotes = data.Get("bits_votes").AsInt32(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_choices.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("id", Id);
			request.Set("title", Title);
			request.Set("votes", Votes);
			request.Set("channel_points_votes", ChannelPointsVotes);
			request.Set("bits_votes", BitsVotes);
			return request;
		}
	
	}

}
