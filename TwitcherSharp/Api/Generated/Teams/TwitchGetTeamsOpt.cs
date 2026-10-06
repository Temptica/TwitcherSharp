using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;


/// <summary> 
/// All optional parameters for TwitchAPI.GetTeams 
/// </summary>
public partial class TwitchGetTeamsOpt : RefCounted, ITwitcherSharp<TwitchGetTeamsOpt>
{
    private Variant _data;
    public string? Name { get; set; }
    public string? Id { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTeamsOpt object.
    /// </summary> 
    public static TwitchGetTeamsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetTeamsOpt
        {
            Name = data.Read("name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_teams.gd", "Opt");
        if(Name != null) request.SetValue("name", Name);
        if(Id != null) request.SetValue("id", Id);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
