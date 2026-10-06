using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchPoll : RefCounted, ITwitcherSharp<TwitchPoll>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string Title { get; set; } = null!;
    public TwitchChoices[] Choices { get => field ??= _data.GetArray<TwitchChoices>("choices")!; set; } = null!;
    public bool BitsVotingEnabled { get; set; }
    public int BitsPerVote { get; set; }
    public bool ChannelPointsVotingEnabled { get; set; }
    public int ChannelPointsPerVote { get; set; }
    public string Status { get; set; } = null!;
    public int Duration { get; set; }
    public string StartedAt { get; set; } = null!;
    public string EndedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchPoll object.
    /// </summary> 
    public static TwitchPoll? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchPoll
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            BitsVotingEnabled = data.Read("bits_voting_enabled", static v => v.AsBool()),
            BitsPerVote = data.Read("bits_per_vote", static v => v.AsInt32()),
            ChannelPointsVotingEnabled = data.Read("channel_points_voting_enabled", static v => v.AsBool()),
            ChannelPointsPerVote = data.Read("channel_points_per_vote", static v => v.AsInt32()),
            Status = data.Read("status", static v => v.AsString()),
            Duration = data.Read("duration", static v => v.AsInt32()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            EndedAt = data.Read("ended_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_poll.gd");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(Title != null) request.SetValue("title", Title);
        if(Choices != null) request.SetArray("choices", Choices);
        request.SetValue("bits_voting_enabled", BitsVotingEnabled);
        request.SetValue("bits_per_vote", BitsPerVote);
        request.SetValue("channel_points_voting_enabled", ChannelPointsVotingEnabled);
        request.SetValue("channel_points_per_vote", ChannelPointsPerVote);
        if(Status != null) request.SetValue("status", Status);
        request.SetValue("duration", Duration);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list of choices that viewers can choose from. The list will contain a minimum of two choices and up to a maximum of five choices. 
    /// </summary>
    public partial class TwitchChoices : RefCounted, ITwitcherSharp<TwitchChoices>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int Votes { get; set; }
        public int ChannelPointsVotes { get; set; }
        public int BitsVotes { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchChoices object.
        /// </summary> 
        public static TwitchChoices? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchChoices
            {
                Id = data.Read("id", static v => v.AsString()),
                Title = data.Read("title", static v => v.AsString()),
                Votes = data.Read("votes", static v => v.AsInt32()),
                ChannelPointsVotes = data.Read("channel_points_votes", static v => v.AsInt32()),
                BitsVotes = data.Read("bits_votes", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_poll.gd", "Choices");
            if(Id != null) request.SetValue("id", Id);
            if(Title != null) request.SetValue("title", Title);
            request.SetValue("votes", Votes);
            request.SetValue("channel_points_votes", ChannelPointsVotes);
            request.SetValue("bits_votes", BitsVotes);
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
