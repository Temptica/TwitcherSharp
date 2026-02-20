using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchCreatePollBody : Resource, ITwitcherSharp<TwitchCreatePollBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string Title { get; set; }
	public TwitchChoices[] Choices { get; set; }
	public int Duration { get; set; }
	public bool? ChannelPointsVotingEnabled { get; set; }
	public int? ChannelPointsPerVote { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePollBody object.
    /// </summary> 
    public static TwitchCreatePollBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		var choicesArray = data.Get("choices").AsGodotArray<GodotObject>();
		return new TwitchCreatePollBody
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Title = data.Get("title").AsString(),
			Choices = choicesArray.Select(TwitchChoices.FromObject).ToArray(),
			Duration = data.Get("duration").AsInt32(),
			ChannelPointsVotingEnabled = data.Get("channel_points_voting_enabled").AsBool(),
			ChannelPointsPerVote = data.Get("channel_points_per_vote").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_poll.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("title", Title);
		request.Set("choices", Choices);
		request.Set("duration", Duration);
		if(ChannelPointsVotingEnabled.HasValue) request.Set("channel_points_voting_enabled", ChannelPointsVotingEnabled.Value);
		if(ChannelPointsPerVote.HasValue) request.Set("channel_points_per_vote", ChannelPointsPerVote.Value);
		return request;
	}
	
	/// <summary> 
	/// A list of choices that viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 5 choices. 
	/// </summary>
	public partial class TwitchChoices : Resource, ITwitcherSharp<TwitchChoices>
	{
	    private GodotObject _data;
		public string Title { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchChoices object.
	    /// </summary> 
	    public static TwitchChoices FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchChoices
			{
				Title = data.Get("title").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_choices.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("title", Title);
			return request;
		}
	
	}

}
