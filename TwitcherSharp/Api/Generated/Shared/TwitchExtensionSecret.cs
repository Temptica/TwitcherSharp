using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchExtensionSecret : Resource, ITwitcherSharp<TwitchExtensionSecret>
{
    private GodotObject _data;
	public int FormatVersion { get; set; }
	public TwitchSecrets[] Secrets { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionSecret object.
    /// </summary> 
    public static TwitchExtensionSecret FromObject(GodotObject data)
    {
        if(data == null) return null;
		var secretsArray = data.Get("secrets").AsGodotArray<GodotObject>();
		return new TwitchExtensionSecret
		{
			FormatVersion = data.Get("format_version").AsInt32(),
			Secrets = secretsArray.Select(TwitchSecrets.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_secret.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("format_version", FormatVersion);
		request.Set("secrets", Secrets);
		return request;
	}
}
