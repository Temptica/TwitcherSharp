using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Goals;

public partial class TwitchGetCreatorGoalsResponse : RefCounted, ITwitcherSharp<TwitchGetCreatorGoalsResponse>
{
    private Variant _data;
    public TwitchCreatorGoal[] Data { get => field ??= _data.GetArray<TwitchCreatorGoal>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCreatorGoalsResponse object.
    /// </summary> 
    public static TwitchGetCreatorGoalsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCreatorGoalsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_creator_goals.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
