using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.DeleteChatMessages 
/// </summary>
public partial class TwitchDeleteChatMessagesOpt : RefCounted, ITwitcherSharp<TwitchDeleteChatMessagesOpt>
{
    private Variant _data;
    public string? MessageId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteChatMessagesOpt object.
    /// </summary> 
    public static TwitchDeleteChatMessagesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDeleteChatMessagesOpt
        {
            MessageId = data.Read("message_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_delete_chat_messages.gd", "Opt");
        if(MessageId != null) request.SetValue("message_id", MessageId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
