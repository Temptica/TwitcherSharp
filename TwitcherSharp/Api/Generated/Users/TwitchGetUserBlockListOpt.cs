using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUserBlockList 
/// </summary>
public partial class TwitchGetUserBlockListOpt : Resource, ITwitcherSharp<TwitchGetUserBlockListOpt>
{
    private GodotObject _data;
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserBlockListOpt object.
    /// </summary> 
    public static TwitchGetUserBlockListOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetUserBlockListOpt
        {
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_block_list.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
