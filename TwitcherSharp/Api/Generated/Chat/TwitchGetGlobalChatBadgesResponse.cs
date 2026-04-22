using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetGlobalChatBadgesResponse : RefCounted, ITwitcherSharp<TwitchGetGlobalChatBadgesResponse>
{
    private GodotObject _data;
    public TwitchChatBadge[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGlobalChatBadgesResponse object.
    /// </summary> 
    public static TwitchGetGlobalChatBadgesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetGlobalChatBadgesResponse
        {
            Data = dataArray.Select(TwitchChatBadge.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_global_chat_badges.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
