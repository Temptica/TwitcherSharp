using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchCheckAutoModStatusResponse : RefCounted, ITwitcherSharp<TwitchCheckAutoModStatusResponse>
{
    private GodotObject _data;
    public TwitchAutoModStatus[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusResponse object.
    /// </summary> 
    public static TwitchCheckAutoModStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCheckAutoModStatusResponse
        {
            Data = dataArray.Select(TwitchAutoModStatus.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
