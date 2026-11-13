using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetCheermotesResponse : RefCounted, ITwitcherSharp<TwitchGetCheermotesResponse>
{
    private Variant _data;
    public TwitchCheermote[] Data { get => field ??= _data.GetArray<TwitchCheermote>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesResponse object.
    /// </summary> 
    public static TwitchGetCheermotesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCheermotesResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_cheermotes.gd", "Response");
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
