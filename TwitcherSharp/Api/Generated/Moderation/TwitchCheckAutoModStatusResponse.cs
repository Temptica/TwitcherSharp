using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchCheckAutoModStatusResponse : RefCounted, ITwitcherSharp<TwitchCheckAutoModStatusResponse>
{
    private GodotObject? _data;
    public TwitchAutoModStatus[] Data { get => field ??= _data?.GetArray<TwitchAutoModStatus>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusResponse object.
    /// </summary> 
    public static TwitchCheckAutoModStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheckAutoModStatusResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
