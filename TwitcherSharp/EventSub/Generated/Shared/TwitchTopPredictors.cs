using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchTopPredictors : RefCounted, ITwitcherSharpEventSub<TwitchTopPredictors>
{
    private Variant _data;
    
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
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            ChannelPointsWon = data.Read("channel_points_won", static v => v.AsInt32()),
            ChannelPointsUsed = data.Read("channel_points_used", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_top_predictors.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        request.SetValue("channel_points_won", ChannelPointsWon);
        request.SetValue("channel_points_used", ChannelPointsUsed);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
