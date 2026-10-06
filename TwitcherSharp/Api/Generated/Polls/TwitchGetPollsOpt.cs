using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;


/// <summary> 
/// All optional parameters for TwitchAPI.GetPolls 
/// </summary>
public partial class TwitchGetPollsOpt : RefCounted, ITwitcherSharp<TwitchGetPollsOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public string? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPollsOpt object.
    /// </summary> 
    public static TwitchGetPollsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetPollsOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
            First = data.Read("first", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_polls.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(First != null) request.SetValue("first", First);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
