using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionLiveChannels 
/// </summary>
public partial class TwitchGetExtensionLiveChannelsOpt : Resource, ITwitcherSharp<TwitchGetExtensionLiveChannelsOpt>
{
    private GodotObject _data;
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionLiveChannelsOpt object.
    /// </summary> 
    public static TwitchGetExtensionLiveChannelsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetExtensionLiveChannelsOpt
        {
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
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
