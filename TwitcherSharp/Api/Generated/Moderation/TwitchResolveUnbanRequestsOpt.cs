using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.ResolveUnbanRequests 
/// </summary>
public partial class TwitchResolveUnbanRequestsOpt : RefCounted, ITwitcherSharp<TwitchResolveUnbanRequestsOpt>
{
    private GodotObject _data;
    public string ResolutionText { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchResolveUnbanRequestsOpt object.
    /// </summary> 
    public static TwitchResolveUnbanRequestsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchResolveUnbanRequestsOpt
        {
            ResolutionText = data.Get("resolution_text").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(ResolutionText != null) request.Set("resolution_text", ResolutionText);
        return request;
    }

}
