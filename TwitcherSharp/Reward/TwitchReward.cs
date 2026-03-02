using Godot;
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
    public int Cost { get; set; }

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
        if (Image1 != null) return ImageTexture.CreateFromImage(Image1);
        return DefaultImage1;
    }

    public Texture2D GetImage2()
    {
        if (Image2 != null) return ImageTexture.CreateFromImage(Image2);
        return DefaultImage2;
    }

    public Texture2D GetImage4()
    {
        if (Image4 != null) return ImageTexture.CreateFromImage(Image4);
        return DefaultImage4;
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
        throw new NotImplementedException();
    }

    public GodotObject ToObject()
    {
        var path = GD.Load<GodotObject>("res://addons/twitcher/reward/twitch_reward.gd");
        
        path.Set("id", Id);
        // path.Set("broadcaster_user_id", BroadcasterUser.);
        
        return path;
    }
}