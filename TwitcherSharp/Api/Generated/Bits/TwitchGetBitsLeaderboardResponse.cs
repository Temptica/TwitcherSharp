using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetBitsLeaderboardResponse : RefCounted, ITwitcherSharp<TwitchGetBitsLeaderboardResponse>
{
    private GodotObject _data;
    public TwitchBitsLeaderboard[] Data { get; set; }
    public TwitchDateRange DateRange { get; set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBitsLeaderboardResponse object.
    /// </summary> 
    public static TwitchGetBitsLeaderboardResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetBitsLeaderboardResponse
        {
            Data = dataArray.Select(TwitchBitsLeaderboard.FromObject).ToArray(),
            DateRange = data.Get("date_range").As<TwitchDateRange>(),
            Total = data.Get("total").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_bits_leaderboard.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        request.Set("date_range", DateRange?.ToGodotObject());
        request.Set("total", Total);
        return request;
    }
    
    /// <summary> 
    /// The reporting window’s start and end dates, in RFC3339 format. The dates are calculated by using the _started\_at_ and _period_ query parameters. If you don’t specify the _started\_at_ query parameter, the fields contain empty strings. 
    /// </summary>
    public partial class TwitchDateRange : RefCounted, ITwitcherSharp<TwitchDateRange>
    {
        private GodotObject _data;
        public string StartedAt { get; set; }
        public string EndedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDateRange object.
        /// </summary> 
        public static TwitchDateRange FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchDateRange
            {
                StartedAt = data.Get("started_at").AsString(),
                EndedAt = data.Get("ended_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_date_range.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("started_at", StartedAt);
            request.Set("ended_at", EndedAt);
            return request;
        }
    
    }

}
