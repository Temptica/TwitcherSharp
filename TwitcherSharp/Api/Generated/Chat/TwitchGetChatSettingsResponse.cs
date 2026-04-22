using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChatSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetChatSettingsResponse>
{
    private GodotObject _data;
    public TwitchChatSettings[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChatSettingsResponse object.
    /// </summary> 
    public static TwitchGetChatSettingsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChatSettingsResponse
        {
            Data = dataArray.Select(TwitchChatSettings.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chat_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
