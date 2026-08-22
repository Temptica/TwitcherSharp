using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchBitsLeaderboard : RefCounted, ITwitcherSharp<TwitchBitsLeaderboard>
{
    private GodotObject? _data;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public int Rank { get; set; }
    public int Score { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBitsLeaderboard object.
    /// </summary> 
    public static TwitchBitsLeaderboard? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBitsLeaderboard
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Rank = data.Get("rank").AsInt32(),
            Score = data.Get("score").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_bits_leaderboard.gd");
        var request = script.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        request.Set("rank", Rank);
        request.Set("score", Score);
        return request;
    }

}
