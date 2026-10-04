using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;


/// <summary> 
/// All optional parameters for TwitchAPI.GetChatSettings 
/// </summary>
public partial class TwitchGetChatSettingsOpt : RefCounted, ITwitcherSharp<TwitchGetChatSettingsOpt>
{
    private Variant _data;
    public string? ModeratorId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChatSettingsOpt object.
    /// </summary> 
    public static TwitchGetChatSettingsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChatSettingsOpt
        {
            ModeratorId = data.Read("moderator_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_chat_settings.gd", "Opt");
        if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
