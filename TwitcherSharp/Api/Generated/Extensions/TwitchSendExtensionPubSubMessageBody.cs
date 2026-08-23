using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSendExtensionPubSubMessageBody : RefCounted, ITwitcherSharp<TwitchSendExtensionPubSubMessageBody>
{
    private GodotObject? _data;
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
            Target = data.Get("target").AsStringArray(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            IsGlobalBroadcast = data.Get("is_global_broadcast").AsBool(),
            Message = data.Get("message").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_extension_pub_sub_message.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Target != null) request.Set("target", new Godot.Collections.Array<string>(Target));
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(IsGlobalBroadcast.HasValue) request.Set("is_global_broadcast", IsGlobalBroadcast.Value);
        if(Message != null) request.Set("message", Message);
        return request;
    }

}
