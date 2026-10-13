using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchGetChannelInformationResponse : RefCounted, ITwitcherSharp<TwitchGetChannelInformationResponse>
{
    private Variant _data;
    public TwitchChannelInformation[] Data { get => field ??= _data.GetArray<TwitchChannelInformation>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelInformationResponse object.
    /// </summary> 
    public static TwitchGetChannelInformationResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelInformationResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_information.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
