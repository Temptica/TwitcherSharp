using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetUserChatColorResponse : RefCounted, ITwitcherSharp<TwitchGetUserChatColorResponse>
{
    private Variant _data;
    public TwitchUserChatColor[] Data { get => field ??= _data.GetArray<TwitchUserChatColor>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserChatColorResponse object.
    /// </summary> 
    public static TwitchGetUserChatColorResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserChatColorResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_chat_color.gd", "Response");
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
