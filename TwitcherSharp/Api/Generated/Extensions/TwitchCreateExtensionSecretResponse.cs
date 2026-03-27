using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchCreateExtensionSecretResponse : RefCounted, ITwitcherSharp<TwitchCreateExtensionSecretResponse>
{
    private GodotObject _data;
    public TwitchExtensionSecret[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateExtensionSecretResponse object.
    /// </summary> 
    public static TwitchCreateExtensionSecretResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCreateExtensionSecretResponse
        {
            Data = dataArray.Select(TwitchExtensionSecret.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_extension_secret.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
