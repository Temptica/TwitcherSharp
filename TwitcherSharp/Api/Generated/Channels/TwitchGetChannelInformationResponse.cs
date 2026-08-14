using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchGetChannelInformationResponse : RefCounted, ITwitcherSharp<TwitchGetChannelInformationResponse>
{
    private GodotObject? _data;
    public TwitchChannelInformation[]? Data { get => field ??= _data?.GetArray<TwitchChannelInformation>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelInformationResponse object.
    /// </summary> 
    public static TwitchGetChannelInformationResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelInformationResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_information.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
