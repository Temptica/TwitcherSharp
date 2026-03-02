using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.GetBannedUsers 
/// </summary>
public partial class TwitchGetBannedUsersOpt : Resource, ITwitcherSharp<TwitchGetBannedUsersOpt>
{
    private GodotObject _data;
    public string[] UserId { get; set; }
    public int? First { get; set; }
    public string After { get; set; }
    public string Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBannedUsersOpt object.
    /// </summary> 
    public static TwitchGetBannedUsersOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetBannedUsersOpt
        {
            UserId = data.Get("user_id").AsStringArray(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
            Before = data.Get("before").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_banned_users.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        if(Before != null) request.Set("before", Before);
        return request;
    }

}
