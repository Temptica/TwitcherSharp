using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The event’s data. 
/// </summary>
public partial class TwitchEventData : Resource, ITwitcherSharp<TwitchEventData>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string CooldownEndTime { get; set; }
	public string ExpiresAt { get; set; }
	public int Goal { get; set; }
	public string Id { get; set; }
	public TwitchLastContribution LastContribution { get; set; }
	public int Level { get; set; }
	public string StartedAt { get; set; }
	public TwitchTopContributions[] TopContributions { get; set; }
	public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEventData object.
    /// </summary> 
    public static TwitchEventData FromObject(GodotObject data)
    {
        if(data == null) return null;
		var topContributionsArray = data.Get("top_contributions").AsGodotArray<GodotObject>();
		return new TwitchEventData
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			CooldownEndTime = data.Get("cooldown_end_time").AsString(),
			ExpiresAt = data.Get("expires_at").AsString(),
			Goal = data.Get("goal").AsInt32(),
			Id = data.Get("id").AsString(),
			LastContribution = data.Get("last_contribution").As<TwitchLastContribution>(),
			Level = data.Get("level").AsInt32(),
			StartedAt = data.Get("started_at").AsString(),
			TopContributions = topContributionsArray.Select(TwitchTopContributions.FromObject).ToArray(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_event_data.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("cooldown_end_time", CooldownEndTime);
		request.Set("expires_at", ExpiresAt);
		request.Set("goal", Goal);
		request.Set("id", Id);
		request.Set("last_contribution", LastContribution);
		request.Set("level", Level);
		request.Set("started_at", StartedAt);
		request.Set("top_contributions", TopContributions);
		request.Set("total", Total);
		return request;
	}
}
