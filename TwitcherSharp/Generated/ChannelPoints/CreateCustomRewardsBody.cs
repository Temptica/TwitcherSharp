using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class CreateCustomRewardsBody : Resource, ITwitcherSharp<CreateCustomRewardsBody>
{
    private GodotObject _data;
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Prompt { get; set; }
	public bool IsEnabled { get; set; }
	public string BackgroundColor { get; set; }
	public bool IsUserInputRequired { get; set; }
	public bool IsMaxPerStreamEnabled { get; set; }
	public int MaxPerStream { get; set; }
	public bool IsMaxPerUserPerStreamEnabled { get; set; }
	public int MaxPerUserPerStream { get; set; }
	public bool IsGlobalCooldownEnabled { get; set; }
	public int GlobalCooldownSeconds { get; set; }
	public bool ShouldRedemptionsSkipRequestQueue { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateCustomRewardsBody object.
    /// </summary> 
    public static CreateCustomRewardsBody FromObject(GodotObject data)
    {
        return new CreateCustomRewardsBody
        {

			Title = data.Get("title").AsString(),
			Cost = data.Get("cost").AsInt32(),
			Prompt = data.Get("prompt").AsString(),
			IsEnabled = data.Get("is_enabled").AsBool(),
			BackgroundColor = data.Get("background_color").AsString(),
			IsUserInputRequired = data.Get("is_user_input_required").AsBool(),
			IsMaxPerStreamEnabled = data.Get("is_max_per_stream_enabled").AsBool(),
			MaxPerStream = data.Get("max_per_stream").AsInt32(),
			IsMaxPerUserPerStreamEnabled = data.Get("is_max_per_user_per_stream_enabled").AsBool(),
			MaxPerUserPerStream = data.Get("max_per_user_per_stream").AsInt32(),
			IsGlobalCooldownEnabled = data.Get("is_global_cooldown_enabled").AsBool(),
			GlobalCooldownSeconds = data.Get("global_cooldown_seconds").AsInt32(),
			ShouldRedemptionsSkipRequestQueue = data.Get("should_redemptions_skip_request_queue").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_custom_rewards_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("title", Title);
		request.Set("cost", Cost);
		request.Set("prompt", Prompt);
		request.Set("is_enabled", IsEnabled);
		request.Set("background_color", BackgroundColor);
		request.Set("is_user_input_required", IsUserInputRequired);
		request.Set("is_max_per_stream_enabled", IsMaxPerStreamEnabled);
		request.Set("max_per_stream", MaxPerStream);
		request.Set("is_max_per_user_per_stream_enabled", IsMaxPerUserPerStreamEnabled);
		request.Set("max_per_user_per_stream", MaxPerUserPerStream);
		request.Set("is_global_cooldown_enabled", IsGlobalCooldownEnabled);
		request.Set("global_cooldown_seconds", GlobalCooldownSeconds);
		request.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
		return request;
	}
}
