using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;


/// <summary> 
/// All optional parameters for TwitchAPI.GetPolls 
/// </summary>
public partial class TwitchGetPollsOpt : Resource, ITwitcherSharp<TwitchGetPollsOpt>
{
    private GodotObject _data;
    public string[] Id { get; set; }
    public string First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPollsOpt object.
    /// </summary> 
    public static TwitchGetPollsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetPollsOpt
        {
            Id = data.Get("id").AsStringArray(),
            First = data.Get("first").AsString(),
            After = data.Get("after").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_polls.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(First != null) request.Set("first", First);
        if(After != null) request.Set("after", After);
        return request;
    }

}
