using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddBlockedTermResponse : RefCounted, ITwitcherSharp<TwitchAddBlockedTermResponse>
{
    private GodotObject _data;
    public TwitchBlockedTerm[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAddBlockedTermResponse object.
    /// </summary> 
    public static TwitchAddBlockedTermResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchAddBlockedTermResponse
        {
            Data = dataArray.Select(TwitchBlockedTerm.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_blocked_term.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
