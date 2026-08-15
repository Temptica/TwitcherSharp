using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionLiveChannelsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionLiveChannelsResponse>
{
    private GodotObject _data;
    public TwitchExtensionLiveChannel[] Data { get => field ??= _data?.GetArray<TwitchExtensionLiveChannel>("data"); set; }
    public string Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionLiveChannelsResponse object.
    /// </summary> 
    public static TwitchGetExtensionLiveChannelsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionLiveChannelsResponse
        {
            Pagination = data.Get("pagination").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }

}
