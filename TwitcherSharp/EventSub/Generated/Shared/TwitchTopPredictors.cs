using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTopPredictors : RefCounted, ITwitcherSharpEventSub<TwitchTopPredictors>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The login of the user.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The display name of the user.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The number of Channel Points won. This value is always null in the event payload for Prediction progress and Prediction lock. This value is 0 if the outcome did not win or if the Prediction was canceled and Channel Points were refunded.
    /// </summary>
    public int ChannelPointsWon { get; set; }

    /// <summary> 
    /// The number of Channel Points used to participate in the Prediction.
    /// </summary>
    public int ChannelPointsUsed { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchTopPredictors object.
    /// </summary> 
    public static TwitchTopPredictors? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchTopPredictors
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            ChannelPointsWon = data.Get("channel_points_won").AsInt32(),
            ChannelPointsUsed = data.Get("channel_points_used").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_top_predictors.gd");
        var request = script.New().AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        request.Set("channel_points_won", ChannelPointsWon);
        request.Set("channel_points_used", ChannelPointsUsed);
        return request;
    }
}
