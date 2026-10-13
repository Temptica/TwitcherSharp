using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Interfaces;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
namespace TwitcherSharp.Reward;

public partial class TwitchReward : Resource, ITwitcherSharp<TwitchReward>
{
    /// <summary>
    /// The ID that uniquely identifies this custom reward.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Owner of this reward
    /// </summary>
    public TwitchUser BroadcasterUser { get; set; } = null!;

    /// <summary>
    /// The title of the reward.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// The prompt shown to the viewer when they redeem the reward.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// The cost of the reward in Channel Points.
    /// </summary>
    public long Cost { get; set; } = 1;

    // Custom Images
    public Image? Image1 { get; set; }
    public Image? Image2 { get; set; }
    public Image? Image4 { get; set; }

    // Default Images (Loading them via GD.Load to mimic preload)
    public CompressedTexture2D DefaultImage1 { get; set; } =
        GD.Load<CompressedTexture2D>("res://addons/twitcher/assets/default-1.png");

    public CompressedTexture2D DefaultImage2 { get; set; } =
        GD.Load<CompressedTexture2D>("res://addons/twitcher/assets/default-2.png");

    public CompressedTexture2D DefaultImage4 { get; set; } =
        GD.Load<CompressedTexture2D>("res://addons/twitcher/assets/default-4.png");

    public Color BackgroundColor { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsUserInputRequired { get; set; }
    public bool IsPaused { get; set; }

    public bool ShouldRedemptionsSkipRequestQueue { get; set; }

    public bool IsMaxPerStreamEnabled { get; set; }
    public long MaxPerStream { get; set; }
    public bool IsMaxPerUserPerStreamEnabled { get; set; }
    public long MaxPerUserPerStream { get; set; }
    public bool IsGlobalCooldownEnabled { get; set; }
    public long GlobalCooldownSeconds { get; set; }

    #region Temporary

    public bool IsInStock { get; set; }

    public long RedemptionsRedeemedCurrentStream { get; set; }

    public string? CooldownExpiresAt { get; set; }

    #endregion

    public Texture2D GetImage1()
    {
        return Image1 != null ? ImageTexture.CreateFromImage(Image1) : DefaultImage1;
    }

    public Texture2D GetImage2()
    {
        return Image2 != null ? ImageTexture.CreateFromImage(Image2) : DefaultImage2;
    }

    public Texture2D GetImage4()
    {
        return Image4 != null ? ImageTexture.CreateFromImage(Image4) : DefaultImage4;
    }

    public static TwitchReward? FromObject(GodotObject? data)
    {
        if (data == null) return null;

        var reward = new TwitchReward();
        reward.ReadFrom(data);
        return reward;
    }

    /// <summary>
    /// Copies the fields of a twitcher TwitchReward into this reward, e.g. after twitcher changed it in place.
    /// </summary>
    internal void ReadFrom(GodotObject data)
    {
        Id = data.ReadAsString("id");
        BroadcasterUser = data.Get<TwitchUser>("broadcaster_user")!;
        Title = data.ReadAsString("title");
        Description = data.ReadAsString("description");
        Cost = data.ReadAsInt64("cost");
        Image1 = data.Read("image_1", static v => v.As<Image>());
        Image2 = data.Read("image_2", static v => v.As<Image>());
        Image4 = data.Read("image_4", static v => v.As<Image>());
        BackgroundColor = data.Read("background_color", static v => v.AsColor());
        IsEnabled = data.ReadAsBool("is_enabled");
        IsUserInputRequired = data.ReadAsBool("is_user_input_required");
        IsPaused = data.ReadAsBool("is_paused");
        ShouldRedemptionsSkipRequestQueue = data.ReadAsBool("should_redemptions_skip_request_queue");
        IsMaxPerStreamEnabled = data.ReadAsBool("is_max_per_stream_enabled");
        MaxPerStream = data.ReadAsInt64("max_per_stream");
        IsMaxPerUserPerStreamEnabled = data.ReadAsBool("is_max_per_user_per_stream_enabled");
        MaxPerUserPerStream = data.ReadAsInt64("max_per_user_per_stream");
        IsGlobalCooldownEnabled = data.ReadAsBool("is_global_cooldown_enabled");
        GlobalCooldownSeconds = data.ReadAsInt64("global_cooldown_seconds");
        IsInStock = data.ReadAsBool("is_in_stock");
        RedemptionsRedeemedCurrentStream = data.ReadAsInt64("redemptions_redeemed_current_stream");
        CooldownExpiresAt = data.ReadAsString("cooldown_expires_at");
    }

    public GodotObject ToGodotObject()
    {
        var reward = InteropExtension.NewObject("res://addons/twitcher/reward/twitch_reward.gd");
        reward.SetValue("id", Id);
        reward.SetObject("broadcaster_user", BroadcasterUser);
        reward.SetValue("title", Title);
        reward.SetValue("description", Description);
        reward.SetValue("cost", Cost);
        if (Image1 != null) reward.SetValue("image_1", Image1);
        if (Image2 != null) reward.SetValue("image_2", Image2);
        if (Image4 != null) reward.SetValue("image_4", Image4);
        reward.SetValue("background_color", BackgroundColor);
        reward.SetValue("is_enabled", IsEnabled);
        reward.SetValue("is_user_input_required", IsUserInputRequired);
        reward.SetValue("is_paused", IsPaused);
        reward.SetValue("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        reward.SetValue("is_max_per_stream_enabled", IsMaxPerStreamEnabled);
        reward.SetValue("max_per_stream", MaxPerStream);
        reward.SetValue("is_max_per_user_per_stream_enabled", IsMaxPerUserPerStreamEnabled);
        reward.SetValue("max_per_user_per_stream", MaxPerUserPerStream);
        reward.SetValue("is_global_cooldown_enabled", IsGlobalCooldownEnabled);
        reward.SetValue("global_cooldown_seconds", GlobalCooldownSeconds);
        reward.SetValue("is_in_stock", IsInStock);
        reward.SetValue("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        if (CooldownExpiresAt != null) reward.SetValue("cooldown_expires_at", CooldownExpiresAt);
        
        return reward;
    }
}