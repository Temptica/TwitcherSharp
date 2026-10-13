using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetGlobalChatBadgesResponse : RefCounted, ITwitcherSharp<TwitchGetGlobalChatBadgesResponse>
{
    private Variant _data;
    public TwitchChatBadge[] Data { get => field ??= _data.GetArray<TwitchChatBadge>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGlobalChatBadgesResponse object.
    /// </summary> 
    public static TwitchGetGlobalChatBadgesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGlobalChatBadgesResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_global_chat_badges.gd", "Response");
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
