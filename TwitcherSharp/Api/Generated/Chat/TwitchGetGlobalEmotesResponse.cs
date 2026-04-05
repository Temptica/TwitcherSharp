using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetGlobalEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetGlobalEmotesResponse>
{
    private GodotObject _data;
    public TwitchGlobalEmote[] Data { get; set; }
    public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGlobalEmotesResponse object.
    /// </summary> 
    public static TwitchGetGlobalEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetGlobalEmotesResponse
        {
            Data = dataArray.Select(TwitchGlobalEmote.FromObject).ToArray(),
            Template = data.Get("template").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_global_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        request.Set("template", Template);
        return request;
    }

}
