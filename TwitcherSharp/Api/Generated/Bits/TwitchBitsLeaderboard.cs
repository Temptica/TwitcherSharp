using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchBitsLeaderboard : RefCounted, ITwitcherSharp<TwitchBitsLeaderboard>
{
    private Variant _data;
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
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            Rank = data.ReadAsInt32("rank"),
            Score = data.ReadAsInt32("score"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_bits_leaderboard.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        request.SetValue("rank", Rank);
        request.SetValue("score", Score);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
