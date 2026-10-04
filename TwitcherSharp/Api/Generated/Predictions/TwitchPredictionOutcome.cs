using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchPredictionOutcome : RefCounted, ITwitcherSharp<TwitchPredictionOutcome>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Users { get; set; }
    public int ChannelPoints { get; set; }
    public TwitchTopPredictors[] TopPredictors { get => field ??= _data.GetArray<TwitchTopPredictors>("top_predictors")!; set; } = null!;
    public string Color { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchPredictionOutcome object.
    /// </summary> 
    public static TwitchPredictionOutcome? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchPredictionOutcome
        {
            Id = data.Read("id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Users = data.Read("users", static v => v.AsInt32()),
            ChannelPoints = data.Read("channel_points", static v => v.AsInt32()),
            Color = data.Read("color", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_prediction_outcome.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("users", Users);
        request.SetValue("channel_points", ChannelPoints);
        if(TopPredictors != null) request.SetArray("top_predictors", TopPredictors);
        if(Color != null) request.SetValue("color", Color);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list of viewers who were the top predictors; otherwise, **null** if none. 
    /// </summary>
    public partial class TwitchTopPredictors : RefCounted, ITwitcherSharp<TwitchTopPredictors>
    {
        private Variant _data;
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                ChannelPointsUsed = data.Read("channel_points_used", static v => v.AsInt32()),
                ChannelPointsWon = data.Read("channel_points_won", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_prediction_outcome.gd", "TopPredictors");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            request.SetValue("channel_points_used", ChannelPointsUsed);
            request.SetValue("channel_points_won", ChannelPointsWon);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
