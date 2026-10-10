using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSetExtensionRequiredConfigurationBody : RefCounted, ITwitcherSharp<TwitchSetExtensionRequiredConfigurationBody>
{
    private Variant _data;
    public string ExtensionId { get; set; } = null!;
    public string ExtensionVersion { get; set; } = null!;
    public string RequiredConfiguration { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSetExtensionRequiredConfigurationBody object.
    /// </summary> 
    public static TwitchSetExtensionRequiredConfigurationBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSetExtensionRequiredConfigurationBody
        {
            ExtensionId = data.ReadAsString("extension_id"),
            ExtensionVersion = data.ReadAsString("extension_version"),
            RequiredConfiguration = data.ReadAsString("required_configuration"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_set_extension_required_configuration.gd", "Body");
        if(ExtensionId != null) request.SetValue("extension_id", ExtensionId);
        if(ExtensionVersion != null) request.SetValue("extension_version", ExtensionVersion);
        if(RequiredConfiguration != null) request.SetValue("required_configuration", RequiredConfiguration);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
