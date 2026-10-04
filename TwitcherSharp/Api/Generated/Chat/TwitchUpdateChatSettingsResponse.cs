using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchUpdateChatSettingsResponse : RefCounted, ITwitcherSharp<TwitchUpdateChatSettingsResponse>
{
    private Variant _data;
    public TwitchChatSettingsUpdated[] Data { get => field ??= _data.GetArray<TwitchChatSettingsUpdated>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChatSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateChatSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChatSettingsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_chat_settings.gd", "Response");
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
