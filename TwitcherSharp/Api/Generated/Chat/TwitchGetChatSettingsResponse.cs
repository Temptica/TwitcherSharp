using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChatSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetChatSettingsResponse>
{
    private Variant _data;
    public TwitchChatSettings[] Data { get => field ??= _data.GetArray<TwitchChatSettings>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChatSettingsResponse object.
    /// </summary> 
    public static TwitchGetChatSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChatSettingsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_chat_settings.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
