using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.DeleteChatMessages 
/// </summary>
public partial class TwitchDeleteChatMessagesOpt : RefCounted, ITwitcherSharp<TwitchDeleteChatMessagesOpt>
{
    private GodotObject? _data;
    public string? MessageId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDeleteChatMessagesOpt object.
    /// </summary> 
    public static TwitchDeleteChatMessagesOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDeleteChatMessagesOpt
        {
            MessageId = data.Get("message_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_chat_messages.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(MessageId != null) request.Set("message_id", MessageId);
        return request;
    }

}
