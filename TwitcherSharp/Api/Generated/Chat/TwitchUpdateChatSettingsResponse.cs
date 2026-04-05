using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchUpdateChatSettingsResponse : RefCounted, ITwitcherSharp<TwitchUpdateChatSettingsResponse>
{
    private GodotObject _data;
    public TwitchChatSettingsUpdated[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChatSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateChatSettingsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchUpdateChatSettingsResponse
        {
            Data = dataArray.Select(TwitchChatSettingsUpdated.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_chat_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
