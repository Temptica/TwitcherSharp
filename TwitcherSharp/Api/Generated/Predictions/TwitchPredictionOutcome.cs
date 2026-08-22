using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchPredictionOutcome : RefCounted, ITwitcherSharp<TwitchPredictionOutcome>
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Users { get; set; }
    public int ChannelPoints { get; set; }
    public TwitchTopPredictors[] TopPredictors { get => field ??= _data?.GetArray<TwitchTopPredictors>("top_predictors")!; set; } = null!;
    public string Color { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchPredictionOutcome object.
    /// </summary> 
    public static TwitchPredictionOutcome? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchPredictionOutcome
        {
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            Users = data.Get("users").AsInt32(),
            ChannelPoints = data.Get("channel_points").AsInt32(),
            Color = data.Get("color").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction_outcome.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Title != null) request.Set("title", Title);
        request.Set("users", Users);
        request.Set("channel_points", ChannelPoints);
        if(TopPredictors != null) request.Set("top_predictors", TopPredictors.ToGodotArray());
        if(Color != null) request.Set("color", Color);
        return request;
    }
    
    /// <summary> 
    /// A list of viewers who were the top predictors; otherwise, **null** if none. 
    /// </summary>
    public partial class TwitchTopPredictors : RefCounted, ITwitcherSharp<TwitchTopPredictors>
    {
        private GodotObject? _data;
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public int ChannelPointsUsed { get; set; }
        public int ChannelPointsWon { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTopPredictors object.
        /// </summary> 
        public static TwitchTopPredictors? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchTopPredictors
            {
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                ChannelPointsUsed = data.Get("channel_points_used").AsInt32(),
                ChannelPointsWon = data.Get("channel_points_won").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction_outcome.gd");
            var twitchTopPredictorsClass = script.Get("TopPredictors").AsGodotObject();
            var request = twitchTopPredictorsClass.Call("new").AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserName != null) request.Set("user_name", UserName);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            request.Set("channel_points_used", ChannelPointsUsed);
            request.Set("channel_points_won", ChannelPointsWon);
            return request;
        }
    
    }

}
