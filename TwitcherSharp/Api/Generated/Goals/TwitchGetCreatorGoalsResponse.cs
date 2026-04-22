using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Goals;

public partial class TwitchGetCreatorGoalsResponse : RefCounted, ITwitcherSharp<TwitchGetCreatorGoalsResponse>
{
    private GodotObject _data;
    public TwitchCreatorGoal[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCreatorGoalsResponse object.
    /// </summary> 
    public static TwitchGetCreatorGoalsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetCreatorGoalsResponse
        {
            Data = dataArray.Select(TwitchCreatorGoal.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_creator_goals.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
