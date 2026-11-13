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
            Id = data.ReadAsString("id"),
            BroadcasterId = data.ReadAsString("broadcaster_id"),
            BroadcasterName = data.ReadAsString("broadcaster_name"),
            BroadcasterLogin = data.ReadAsString("broadcaster_login"),
            Title = data.ReadAsString("title"),
            BitsVotingEnabled = data.ReadAsBool("bits_voting_enabled"),
            BitsPerVote = data.ReadAsInt32("bits_per_vote"),
            ChannelPointsVotingEnabled = data.ReadAsBool("channel_points_voting_enabled"),
            ChannelPointsPerVote = data.ReadAsInt32("channel_points_per_vote"),
            Status = data.ReadAsString("status"),
            Duration = data.ReadAsInt32("duration"),
            StartedAt = data.ReadAsString("started_at"),
            EndedAt = data.ReadAsString("ended_at"),
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
                Id = data.ReadAsString("id"),
                Title = data.ReadAsString("title"),
                Votes = data.ReadAsInt32("votes"),
                ChannelPointsVotes = data.ReadAsInt32("channel_points_votes"),
                BitsVotes = data.ReadAsInt32("bits_votes"),
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
