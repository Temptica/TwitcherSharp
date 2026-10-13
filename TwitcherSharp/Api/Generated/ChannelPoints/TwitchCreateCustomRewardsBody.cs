using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCreateCustomRewardsBody : RefCounted, ITwitcherSharp<TwitchCreateCustomRewardsBody>
{
    private Variant _data;
    public string Title { get; set; } = null!;
    public long Cost { get; set; }
    public string? Prompt { get; set; }
    public bool? IsEnabled { get; set; }
    public string? BackgroundColor { get; set; }
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
    public static TwitchCreateCustomRewardsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateCustomRewardsBody
        {
            Title = data.ReadAsString("title"),
            Cost = data.ReadAsInt64("cost"),
            Prompt = data.ReadAsString("prompt"),
            IsEnabled = data.ReadAsBool("is_enabled"),
            BackgroundColor = data.ReadAsString("background_color"),
            IsUserInputRequired = data.ReadAsBool("is_user_input_required"),
            IsMaxPerStreamEnabled = data.ReadAsBool("is_max_per_stream_enabled"),
            MaxPerStream = data.ReadAsInt32("max_per_stream"),
            IsMaxPerUserPerStreamEnabled = data.ReadAsBool("is_max_per_user_per_stream_enabled"),
            MaxPerUserPerStream = data.ReadAsInt32("max_per_user_per_stream"),
            IsGlobalCooldownEnabled = data.ReadAsBool("is_global_cooldown_enabled"),
            GlobalCooldownSeconds = data.ReadAsInt32("global_cooldown_seconds"),
            ShouldRedemptionsSkipRequestQueue = data.ReadAsBool("should_redemptions_skip_request_queue"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_custom_rewards.gd", "Body");
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("cost", Cost);
        if(Prompt != null) request.SetValue("prompt", Prompt);
        if(IsEnabled.HasValue) request.SetValue("is_enabled", IsEnabled.Value);
        if(BackgroundColor != null) request.SetValue("background_color", BackgroundColor);
        if(IsUserInputRequired.HasValue) request.SetValue("is_user_input_required", IsUserInputRequired.Value);
        if(IsMaxPerStreamEnabled.HasValue) request.SetValue("is_max_per_stream_enabled", IsMaxPerStreamEnabled.Value);
        if(MaxPerStream.HasValue) request.SetValue("max_per_stream", MaxPerStream.Value);
        if(IsMaxPerUserPerStreamEnabled.HasValue) request.SetValue("is_max_per_user_per_stream_enabled", IsMaxPerUserPerStreamEnabled.Value);
        if(MaxPerUserPerStream.HasValue) request.SetValue("max_per_user_per_stream", MaxPerUserPerStream.Value);
        if(IsGlobalCooldownEnabled.HasValue) request.SetValue("is_global_cooldown_enabled", IsGlobalCooldownEnabled.Value);
        if(GlobalCooldownSeconds.HasValue) request.SetValue("global_cooldown_seconds", GlobalCooldownSeconds.Value);
        if(ShouldRedemptionsSkipRequestQueue.HasValue) request.SetValue("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
