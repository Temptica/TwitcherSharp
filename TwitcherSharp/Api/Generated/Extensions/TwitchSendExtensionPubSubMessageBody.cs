using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSendExtensionPubSubMessageBody : RefCounted, ITwitcherSharp<TwitchSendExtensionPubSubMessageBody>
{
    private Variant _data;
    public string[] Target { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public bool? IsGlobalBroadcast { get; set; }
    public string Message { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSendExtensionPubSubMessageBody object.
    /// </summary> 
    public static TwitchSendExtensionPubSubMessageBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendExtensionPubSubMessageBody
        {
            Target = data.Read("target", static v => v.AsStringArray()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            IsGlobalBroadcast = data.Read("is_global_broadcast", static v => v.AsBool()),
            Message = data.Read("message", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_extension_pub_sub_message.gd", "Body");
        if(Target != null) request.SetValue("target", new Godot.Collections.Array<string>(Target));
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(IsGlobalBroadcast.HasValue) request.SetValue("is_global_broadcast", IsGlobalBroadcast.Value);
        if(Message != null) request.SetValue("message", Message);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
