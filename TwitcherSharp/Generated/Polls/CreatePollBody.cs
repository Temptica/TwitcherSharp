using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Polls;
 
/// <summary> 
///  
/// </summary>
public partial class CreatePollBody : Resource, ITwitcherSharp<CreatePollBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string Title { get; set; }
	public Choices[] Choices { get; set; }
	public int Duration { get; set; }
	public bool ChannelPointsVotingEnabled { get; set; }
	public int ChannelPointsPerVote { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreatePollBody object.
    /// </summary> 
    public static CreatePollBody FromObject(GodotObject data)
    {
        return new CreatePollBody
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Title = data.Get("title").AsString(),
			Choices = data.Get("choices").As<Choices[]>(),
			Duration = data.Get("duration").AsInt32(),
			ChannelPointsVotingEnabled = data.Get("channel_points_voting_enabled").AsBool(),
			ChannelPointsPerVote = data.Get("channel_points_per_vote").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_poll_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("title", Title);
		request.Set("choices", Choices);
		request.Set("duration", Duration);
		request.Set("channel_points_voting_enabled", ChannelPointsVotingEnabled);
		request.Set("channel_points_per_vote", ChannelPointsPerVote);
		return request;
	}
}
