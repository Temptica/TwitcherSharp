using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchCheckAutoModStatusResponse : RefCounted, ITwitcherSharp<TwitchCheckAutoModStatusResponse>
{
    private Variant _data;
    public TwitchAutoModStatus[] Data { get => field ??= _data.GetArray<TwitchAutoModStatus>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusResponse object.
    /// </summary> 
    public static TwitchCheckAutoModStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheckAutoModStatusResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd", "Response");
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
