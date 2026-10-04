using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.ResolveUnbanRequests 
/// </summary>
public partial class TwitchResolveUnbanRequestsOpt : RefCounted, ITwitcherSharp<TwitchResolveUnbanRequestsOpt>
{
    private Variant _data;
    public string? ResolutionText { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchResolveUnbanRequestsOpt object.
    /// </summary> 
    public static TwitchResolveUnbanRequestsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchResolveUnbanRequestsOpt
        {
            ResolutionText = data.Read("resolution_text", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd", "Opt");
        if(ResolutionText != null) request.SetValue("resolution_text", ResolutionText);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
