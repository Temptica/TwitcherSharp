using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchPrediction : Resource, ITwitcherSharp<TwitchPrediction>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string BroadcasterId { get; set; }
    public string BroadcasterName { get; set; }
    public string BroadcasterLogin { get; set; }
    public string Title { get; set; }
    public string WinningOutcomeId { get; set; }
    public TwitchPredictionOutcome[] Outcomes { get; set; }
    public int PredictionWindow { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
    public string EndedAt { get; set; }
    public string LockedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchPrediction object.
    /// </summary> 
    public static TwitchPrediction FromObject(GodotObject data)
    {
        if(data == null) return null;
        var outcomesArray = data.Get("outcomes").AsGodotArray<GodotObject>();
        return new TwitchPrediction
        {
            Id = data.Get("id").AsString(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            Title = data.Get("title").AsString(),
            WinningOutcomeId = data.Get("winning_outcome_id").AsString(),
            Outcomes = outcomesArray.Select(TwitchPredictionOutcome.FromObject).ToArray(),
            PredictionWindow = data.Get("prediction_window").AsInt32(),
            Status = data.Get("status").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
            LockedAt = data.Get("locked_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("broadcaster_name", BroadcasterName);
        request.Set("broadcaster_login", BroadcasterLogin);
        request.Set("title", Title);
        request.Set("winning_outcome_id", WinningOutcomeId);
        request.Set("outcomes", Outcomes);
        request.Set("prediction_window", PredictionWindow);
        request.Set("status", Status);
        request.Set("created_at", CreatedAt);
        request.Set("ended_at", EndedAt);
        request.Set("locked_at", LockedAt);
        return request;
    }
    public partial class TwitchPredictionOutcome : Resource, ITwitcherSharp<TwitchPredictionOutcome>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Title { get; set; }
        public int Users { get; set; }
        public int ChannelPoints { get; set; }
        public TwitchTopPredictors[] TopPredictors { get; set; }
        public string Color { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPredictionOutcome object.
        /// </summary> 
        public static TwitchPredictionOutcome FromObject(GodotObject data)
        {
            if(data == null) return null;
            var topPredictorsArray = data.Get("top_predictors").AsGodotArray<GodotObject>();
            return new TwitchPredictionOutcome
            {
                Id = data.Get("id").AsString(),
                Title = data.Get("title").AsString(),
                Users = data.Get("users").AsInt32(),
                ChannelPoints = data.Get("channel_points").AsInt32(),
                TopPredictors = topPredictorsArray.Select(TwitchTopPredictors.FromObject).ToArray(),
                Color = data.Get("color").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction_outcome.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("title", Title);
            request.Set("users", Users);
            request.Set("channel_points", ChannelPoints);
            request.Set("top_predictors", TopPredictors);
            request.Set("color", Color);
            return request;
        }
        
        /// <summary> 
        /// A list of viewers who were the top predictors; otherwise, **null** if none. 
        /// </summary>
        public partial class TwitchTopPredictors : Resource, ITwitcherSharp<TwitchTopPredictors>
        {
            private GodotObject _data;
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string UserLogin { get; set; }
            public int ChannelPointsUsed { get; set; }
            public int ChannelPointsWon { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchTopPredictors object.
            /// </summary> 
            public static TwitchTopPredictors FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchTopPredictors
                {
                    UserId = data.Get("user_id").AsString(),
                    UserName = data.Get("user_name").AsString(),
                    UserLogin = data.Get("user_login").AsString(),
                    ChannelPointsUsed = data.Get("channel_points_used").AsInt32(),
                    ChannelPointsWon = data.Get("channel_points_won").AsInt32(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_top_predictors.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("user_id", UserId);
                request.Set("user_name", UserName);
                request.Set("user_login", UserLogin);
                request.Set("channel_points_used", ChannelPointsUsed);
                request.Set("channel_points_won", ChannelPointsWon);
                return request;
            }
        
        }
    
    }

}
