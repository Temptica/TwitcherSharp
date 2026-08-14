using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionLiveChannels 
/// </summary>
public partial class TwitchGetExtensionLiveChannelsOpt : RefCounted, ITwitcherSharp<TwitchGetExtensionLiveChannelsOpt>
{
    private GodotObject? _data;
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionLiveChannelsOpt object.
    /// </summary> 
    public static TwitchGetExtensionLiveChannelsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionLiveChannelsOpt
        {
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
