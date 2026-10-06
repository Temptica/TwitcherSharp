using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetBitsLeaderboardResponse : RefCounted, ITwitcherSharp<TwitchGetBitsLeaderboardResponse>
{
    private Variant _data;
    public TwitchBitsLeaderboard[] Data { get => field ??= _data.GetArray<TwitchBitsLeaderboard>("data")!; set; } = null!;
    public TwitchResponseDateRange DateRange { get => field ??= _data.Get<TwitchResponseDateRange>("date_range")!; set; } = null!;
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBitsLeaderboardResponse object.
    /// </summary> 
    public static TwitchGetBitsLeaderboardResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetBitsLeaderboardResponse
        {
            Total = data.Read("total", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_bits_leaderboard.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(DateRange != null) request.SetObject("date_range", DateRange);
        request.SetValue("total", Total);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The reporting window’s start and end dates, in RFC3339 format. The dates are calculated by using the _started\_at_ and _period_ query parameters. If you don’t specify the _started\_at_ query parameter, the fields contain empty strings. 
    /// </summary>
    public partial class TwitchResponseDateRange : RefCounted, ITwitcherSharp<TwitchResponseDateRange>
    {
        private Variant _data;
        public string StartedAt { get; set; } = null!;
        public string EndedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseDateRange object.
        /// </summary> 
        public static TwitchResponseDateRange? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseDateRange
            {
                StartedAt = data.Read("started_at", static v => v.AsString()),
                EndedAt = data.Read("ended_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_bits_leaderboard.gd", "ResponseDateRange");
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
    
    }

}
