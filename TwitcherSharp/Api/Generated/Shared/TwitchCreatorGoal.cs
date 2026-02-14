using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreatorGoal : Resource, ITwitcherSharp<TwitchCreatorGoal>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string BroadcasterId { get; set; }
	public string BroadcasterName { get; set; }
	public string BroadcasterLogin { get; set; }
	public string Type { get; set; }
	public string Description { get; set; }
	public int CurrentAmount { get; set; }
	public int TargetAmount { get; set; }
	public string CreatedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatorGoal object.
    /// </summary> 
    public static TwitchCreatorGoal FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCreatorGoal
		{
			Id = data.Get("id").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			Type = data.Get("type").AsString(),
			Description = data.Get("description").AsString(),
			CurrentAmount = data.Get("current_amount").AsInt32(),
			TargetAmount = data.Get("target_amount").AsInt32(),
			CreatedAt = data.Get("created_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_creator_goal.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("broadcaster_name", BroadcasterName);
		request.Set("broadcaster_login", BroadcasterLogin);
		request.Set("type", Type);
		request.Set("description", Description);
		request.Set("current_amount", CurrentAmount);
		request.Set("target_amount", TargetAmount);
		request.Set("created_at", CreatedAt);
		return request;
	}
}
