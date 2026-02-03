using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class SetExtensionRequiredConfigurationBody : Resource, ITwitcherSharp<SetExtensionRequiredConfigurationBody>
{
    private GodotObject _data;
	public string ExtensionId { get; set; }
	public string ExtensionVersion { get; set; }
	public string RequiredConfiguration { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SetExtensionRequiredConfigurationBody object.
    /// </summary> 
    public static SetExtensionRequiredConfigurationBody FromObject(GodotObject data)
    {
        return new SetExtensionRequiredConfigurationBody
        {

			ExtensionId = data.Get("extension_id").AsString(),
			ExtensionVersion = data.Get("extension_version").AsString(),
			RequiredConfiguration = data.Get("required_configuration").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_set_extension_required_configuration_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("extension_id", ExtensionId);
		request.Set("extension_version", ExtensionVersion);
		request.Set("required_configuration", RequiredConfiguration);
		return request;
	}
}
