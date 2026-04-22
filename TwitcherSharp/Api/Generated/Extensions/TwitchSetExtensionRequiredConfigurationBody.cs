using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSetExtensionRequiredConfigurationBody : RefCounted, ITwitcherSharp<TwitchSetExtensionRequiredConfigurationBody>
{
    private GodotObject _data;
    public string ExtensionId { get; set; }
    public string ExtensionVersion { get; set; }
    public string RequiredConfiguration { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSetExtensionRequiredConfigurationBody object.
    /// </summary> 
    public static TwitchSetExtensionRequiredConfigurationBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchSetExtensionRequiredConfigurationBody
        {
            ExtensionId = data.Get("extension_id").AsString(),
            ExtensionVersion = data.Get("extension_version").AsString(),
            RequiredConfiguration = data.Get("required_configuration").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_set_extension_required_configuration.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("extension_id", ExtensionId);
        request.Set("extension_version", ExtensionVersion);
        request.Set("required_configuration", RequiredConfiguration);
        return request;
    }

}
