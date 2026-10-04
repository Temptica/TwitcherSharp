using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUnbanRequests 
/// </summary>
public partial class TwitchGetUnbanRequestsOpt : RefCounted, ITwitcherSharp<TwitchGetUnbanRequestsOpt>
{
    private Variant _data;
    public string? UserId { get; set; }
    public string? After { get; set; }
    public int? First { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUnbanRequestsOpt object.
    /// </summary> 
    public static TwitchGetUnbanRequestsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUnbanRequestsOpt
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_unban_requests.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(After != null) request.SetValue("after", After);
        if(First.HasValue) request.SetValue("first", First.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
