using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchCreatePollBody : RefCounted, ITwitcherSharp<TwitchCreatePollBody>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public TwitchBodyChoices[] Choices { get => field ??= _data.GetArray<TwitchBodyChoices>("choices")!; set; } = null!;
    public int Duration { get; set; }
    public bool? ChannelPointsVotingEnabled { get; set; }
    public int? ChannelPointsPerVote { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePollBody object.
    /// </summary> 
    public static TwitchCreatePollBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatePollBody
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Duration = data.Read("duration", static v => v.AsInt32()),
            ChannelPointsVotingEnabled = data.Read("channel_points_voting_enabled", static v => v.AsBool()),
            ChannelPointsPerVote = data.Read("channel_points_per_vote", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_poll.gd", "Body");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(Title != null) request.SetValue("title", Title);
        if(Choices != null) request.SetArray("choices", Choices);
        request.SetValue("duration", Duration);
        if(ChannelPointsVotingEnabled.HasValue) request.SetValue("channel_points_voting_enabled", ChannelPointsVotingEnabled.Value);
        if(ChannelPointsPerVote.HasValue) request.SetValue("channel_points_per_vote", ChannelPointsPerVote.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list of choices that viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 5 choices. 
    /// </summary>
    public partial class TwitchBodyChoices : RefCounted, ITwitcherSharp<TwitchBodyChoices>
    {
        private Variant _data;
        public string Title { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyChoices object.
        /// </summary> 
        public static TwitchBodyChoices? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyChoices
            {
                Title = data.Read("title", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_poll.gd", "BodyChoices");
            if(Title != null) request.SetValue("title", Title);
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
