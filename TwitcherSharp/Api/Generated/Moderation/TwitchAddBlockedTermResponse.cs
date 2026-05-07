using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddBlockedTermResponse : RefCounted, ITwitcherSharp<TwitchAddBlockedTermResponse>
{
    private GodotObject _data;
    public TwitchBlockedTerm[] Data { get => field ??= _data?.GetArray<TwitchBlockedTerm>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAddBlockedTermResponse object.
    /// </summary> 
    public static TwitchAddBlockedTermResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchAddBlockedTermResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_blocked_term.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
