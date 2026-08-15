using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetCheermotesResponse : RefCounted, ITwitcherSharp<TwitchGetCheermotesResponse>
{
    private GodotObject _data;
    public TwitchCheermote[] Data { get => field ??= _data?.GetArray<TwitchCheermote>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesResponse object.
    /// </summary> 
    public static TwitchGetCheermotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCheermotesResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
