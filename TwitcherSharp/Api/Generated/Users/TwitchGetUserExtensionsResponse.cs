using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetUserExtensionsResponse>
{
    private GodotObject _data;
    public TwitchUserExtension[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetUserExtensionsResponse
        {
            Data = dataArray.Select(TwitchUserExtension.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
