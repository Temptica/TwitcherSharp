using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSendExtensionChatMessageBody : RefCounted, ITwitcherSharp<TwitchSendExtensionChatMessageBody>
{
    private Variant _data;
    public string Text { get; set; } = null!;
    public string ExtensionId { get; set; } = null!;
    public string ExtensionVersion { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSendExtensionChatMessageBody object.
    /// </summary> 
    public static TwitchSendExtensionChatMessageBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendExtensionChatMessageBody
        {
            Text = data.Read("text", static v => v.AsString()),
            ExtensionId = data.Read("extension_id", static v => v.AsString()),
            ExtensionVersion = data.Read("extension_version", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_extension_chat_message.gd", "Body");
        if(Text != null) request.SetValue("text", Text);
        if(ExtensionId != null) request.SetValue("extension_id", ExtensionId);
        if(ExtensionVersion != null) request.SetValue("extension_version", ExtensionVersion);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
