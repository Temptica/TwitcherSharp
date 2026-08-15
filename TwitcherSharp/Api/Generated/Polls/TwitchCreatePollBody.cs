using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchCreatePollBody : RefCounted, ITwitcherSharp<TwitchCreatePollBody>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string Title { get; set; }
    public TwitchBodyChoices[] Choices { get => field ??= _data?.GetArray<TwitchBodyChoices>("choices"); set; }
    public int Duration { get; set; }
    public bool? ChannelPointsVotingEnabled { get; set; }
    public int? ChannelPointsPerVote { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePollBody object.
    /// </summary> 
    public static TwitchCreatePollBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatePollBody
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Title = data.Get("title").AsString(),
            Duration = data.Get("duration").AsInt32(),
            ChannelPointsVotingEnabled = data.Get("channel_points_voting_enabled").AsBool(),
            ChannelPointsPerVote = data.Get("channel_points_per_vote").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_poll.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("title", Title);
        if(Choices != null) request.SetArray("choices", Choices);
        request.Set("duration", Duration);
        if(ChannelPointsVotingEnabled.HasValue) request.Set("channel_points_voting_enabled", ChannelPointsVotingEnabled.Value);
        if(ChannelPointsPerVote.HasValue) request.Set("channel_points_per_vote", ChannelPointsPerVote.Value);
        return request;
    }
    
    /// <summary> 
    /// A list of choices that viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 5 choices. 
    /// </summary>
    public partial class TwitchBodyChoices : RefCounted, ITwitcherSharp<TwitchBodyChoices>
    {
        private GodotObject _data;
        public string Title { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyChoices object.
        /// </summary> 
        public static TwitchBodyChoices FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyChoices
            {
                Title = data.Get("title").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_poll.gd");
            var twitchBodyChoicesClass = script.Get("BodyChoices").AsGodotObject();
            var request = twitchBodyChoicesClass.Call("new").AsGodotObject();
            request.Set("title", Title);
            return request;
        }
    
    }

}
