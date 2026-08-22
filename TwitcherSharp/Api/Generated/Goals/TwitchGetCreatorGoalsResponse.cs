using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Goals;

public partial class TwitchGetCreatorGoalsResponse : RefCounted, ITwitcherSharp<TwitchGetCreatorGoalsResponse>
{
    private GodotObject? _data;
    public TwitchCreatorGoal[] Data { get => field ??= _data?.GetArray<TwitchCreatorGoal>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCreatorGoalsResponse object.
    /// </summary> 
    public static TwitchGetCreatorGoalsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCreatorGoalsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_creator_goals.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
