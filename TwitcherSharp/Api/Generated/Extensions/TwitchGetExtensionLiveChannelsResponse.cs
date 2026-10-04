using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionLiveChannelsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionLiveChannelsResponse>
{
    private Variant _data;
    public TwitchExtensionLiveChannel[] Data { get => field ??= _data.GetArray<TwitchExtensionLiveChannel>("data")!; set; } = null!;
    public string? Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionLiveChannelsResponse object.
    /// </summary> 
    public static TwitchGetExtensionLiveChannelsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionLiveChannelsResponse
        {
            Pagination = data.Read("pagination", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_extension_live_channels.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Pagination != null) request.SetValue("pagination", Pagination);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
