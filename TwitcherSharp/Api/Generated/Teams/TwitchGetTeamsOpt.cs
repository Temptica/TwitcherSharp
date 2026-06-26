using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;


/// <summary> 
/// All optional parameters for TwitchAPI.GetTeams 
/// </summary>
public partial class TwitchGetTeamsOpt : RefCounted, ITwitcherSharp<TwitchGetTeamsOpt>
{
    private GodotObject _data;
    public string Name { get; set; }
    public string Id { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTeamsOpt object.
    /// </summary> 
    public static TwitchGetTeamsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetTeamsOpt
        {
            Name = data.Get("name").AsString(),
            Id = data.Get("id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Name != null) request.Set("name", Name);
        if(Id != null) request.Set("id", Id);
        return request;
    }

}
