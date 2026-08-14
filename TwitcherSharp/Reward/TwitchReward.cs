using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Interfaces;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
namespace TwitcherSharp.Reward;

public partial class TwitchReward : RefCounted, ITwitcherSharp<TwitchReward>
{
    /// <summary>
    /// The ID that uniquely identifies this custom reward.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Owner of this reward
    /// </summary>
    public TwitchUser BroadcasterUser { get; set; }

    /// <summary>
    /// The title of the reward.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The prompt shown to the viewer when they redeem the reward.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The cost of the reward in Channel Points.
    /// </summary>
    public int Cost { get; set; } = 1;

    // Custom Images
    public Image Image1 { get; set; }
    public Image Image2 { get; set; }
    public Image Image4 { get; set; }

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
    public int MaxPerStream { get; set; }
    public bool IsMaxPerUserPerStreamEnabled { get; set; }
    public int MaxPerUserPerStream { get; set; }
    public bool IsGlobalCooldownEnabled { get; set; }
    public int GlobalCooldownSeconds { get; set; }

    #region Temporary

    public bool IsInStock { get; set; }

    public int RedemptionsRedeemedCurrentStream { get; set; }

    public string CooldownExpiresAt { get; set; }

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

    public static TwitchReward FromObject(GodotObject data)
    {
        return new TwitchReward
        {
            Id = data.Get("id").AsString(),
            BroadcasterUser = TwitchUser.FromObject(data.Get("broadcaster_user").AsGodotObject()),
            Title = data.Get("title").AsString(),
            Description = data.Get("description").AsString(),
            Cost = data.Get("cost").AsInt32(),
            Image1 = data.Get("image_1").As<Image>(),
            Image2 = data.Get("image_2").As<Image>(),
            Image4 = data.Get("image_4").As<Image>(),
            BackgroundColor = data.Get("background_color").AsColor(),
            IsEnabled = data.Get("is_enabled").AsBool(),
            IsUserInputRequired = data.Get("is_user_input_required").AsBool(),
            IsPaused = data.Get("is_paused").AsBool(),
            ShouldRedemptionsSkipRequestQueue = data.Get("should_redemptions_skip_request_queue").AsBool(),
            IsMaxPerStreamEnabled = data.Get("is_max_per_stream_enabled").AsBool(),
            MaxPerStream = data.Get("max_per_stream").AsInt32(),
            IsMaxPerUserPerStreamEnabled = data.Get("is_max_per_user_per_stream_enabled").AsBool(),
            MaxPerUserPerStream = data.Get("max_per_user_per_stream").AsInt32(),
            IsGlobalCooldownEnabled = data.Get("is_global_cooldown_enabled").AsBool(),
            GlobalCooldownSeconds = data.Get("global_cooldown_seconds").AsInt32(),
            IsInStock = data.Get("is_in_stock").AsBool(),
            RedemptionsRedeemedCurrentStream = data.Get("redemptions_redeemed_current_stream").AsInt32(),
            CooldownExpiresAt = data.Get("cooldown_expires_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/reward/twitch_reward.gd");
        var reward = script.New().AsGodotObject();
        reward.Set("id", Id);
        reward.Set("broadcaster_user", BroadcasterUser?.ToGodotObject() ?? new Variant());
        reward.Set("title", Title);
        reward.Set("description", Description);
        reward.Set("cost", Cost);
        reward.Set("image_1", Image1);
        reward.Set("image_2", Image2);
        reward.Set("image_4", Image4);
        reward.Set("background_color", BackgroundColor);
        reward.Set("is_enabled", IsEnabled);
        reward.Set("is_user_input_required", IsUserInputRequired);
        reward.Set("is_paused", IsPaused);
        reward.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        reward.Set("is_max_per_stream_enabled", IsMaxPerStreamEnabled);
        reward.Set("max_per_stream", MaxPerStream);
        reward.Set("is_max_per_user_per_stream_enabled", IsMaxPerUserPerStreamEnabled);
        reward.Set("max_per_user_per_stream", MaxPerUserPerStream);
        reward.Set("is_global_cooldown_enabled", IsGlobalCooldownEnabled);
        reward.Set("global_cooldown_seconds", GlobalCooldownSeconds);
        reward.Set("is_in_stock", IsInStock);
        reward.Set("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        reward.Set("cooldown_expires_at", CooldownExpiresAt);
        
        return reward;
    }
}