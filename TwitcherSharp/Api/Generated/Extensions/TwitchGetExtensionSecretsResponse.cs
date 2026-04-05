using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionSecretsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionSecretsResponse>
{
    private GodotObject _data;
    public TwitchExtensionSecret[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionSecretsResponse object.
    /// </summary> 
    public static TwitchGetExtensionSecretsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetExtensionSecretsResponse
        {
            Data = dataArray.Select(TwitchExtensionSecret.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_secrets.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
