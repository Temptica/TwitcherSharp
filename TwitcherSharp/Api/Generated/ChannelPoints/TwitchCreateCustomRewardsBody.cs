using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

/// <summary> 
///  
/// </summary>
public partial class TwitchCreateCustomRewardsBody : Resource, ITwitcherSharp<TwitchCreateCustomRewardsBody>
{
    private GodotObject _data;
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Prompt { get; set; }
	public bool? IsEnabled { get; set; }
	public string BackgroundColor { get; set; }
	public bool? IsUserInputRequired { get; set; }
	public bool? IsMaxPerStreamEnabled { get; set; }
	public int? MaxPerStream { get; set; }
	public bool? IsMaxPerUserPerStreamEnabled { get; set; }
	public int? MaxPerUserPerStream { get; set; }
	public bool? IsGlobalCooldownEnabled { get; set; }
	public int? GlobalCooldownSeconds { get; set; }
	public bool? ShouldRedemptionsSkipRequestQueue { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateCustomRewardsBody object.
    /// </summary> 
    public static TwitchCreateCustomRewardsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCreateCustomRewardsBody
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_custom_rewards.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("title", Title);
		request.Set("cost", Cost);
		if(Prompt != null) request.Set("prompt", Prompt);
		if(IsEnabled.HasValue) request.Set("is_enabled", IsEnabled.Value);
		if(BackgroundColor != null) request.Set("background_color", BackgroundColor);
		if(IsUserInputRequired.HasValue) request.Set("is_user_input_required", IsUserInputRequired.Value);
		if(IsMaxPerStreamEnabled.HasValue) request.Set("is_max_per_stream_enabled", IsMaxPerStreamEnabled.Value);
		if(MaxPerStream.HasValue) request.Set("max_per_stream", MaxPerStream.Value);
		if(IsMaxPerUserPerStreamEnabled.HasValue) request.Set("is_max_per_user_per_stream_enabled", IsMaxPerUserPerStreamEnabled.Value);
		if(MaxPerUserPerStream.HasValue) request.Set("max_per_user_per_stream", MaxPerUserPerStream.Value);
		if(IsGlobalCooldownEnabled.HasValue) request.Set("is_global_cooldown_enabled", IsGlobalCooldownEnabled.Value);
		if(GlobalCooldownSeconds.HasValue) request.Set("global_cooldown_seconds", GlobalCooldownSeconds.Value);
		if(ShouldRedemptionsSkipRequestQueue.HasValue) request.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue.Value);
		return request;
	}

}
