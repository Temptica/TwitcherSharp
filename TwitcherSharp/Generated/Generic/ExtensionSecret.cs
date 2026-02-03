using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ExtensionSecret : Resource, ITwitcherSharp<ExtensionSecret>
{
    private GodotObject _data;
	public int FormatVersion { get; set; }
	public Secrets[] Secrets { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ExtensionSecret object.
    /// </summary> 
    public static ExtensionSecret FromObject(GodotObject data)
    {
        return new ExtensionSecret
        {

			FormatVersion = data.Get("format_version").AsInt32(),
			Secrets = data.Get("secrets").As<Secrets[]>(),
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
