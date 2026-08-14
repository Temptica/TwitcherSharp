using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSendExtensionChatMessageBody : RefCounted, ITwitcherSharp<TwitchSendExtensionChatMessageBody>
{
    private GodotObject? _data;
    public string? Text { get; set; }
    public string? ExtensionId { get; set; }
    public string? ExtensionVersion { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendExtensionChatMessageBody object.
    /// </summary> 
    public static TwitchSendExtensionChatMessageBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendExtensionChatMessageBody
        {
            Text = data.Get("text").AsString(),
            ExtensionId = data.Get("extension_id").AsString(),
            ExtensionVersion = data.Get("extension_version").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_extension_chat_message.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Text != null) request.Set("text", Text);
        if(ExtensionId != null) request.Set("extension_id", ExtensionId);
        if(ExtensionVersion != null) request.Set("extension_version", ExtensionVersion);
        return request;
    }

}
