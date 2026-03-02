using TwitcherSharp.Api.Generated.Shared;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchGetStreamsResponse : Resource, ITwitcherSharp<TwitchGetStreamsResponse>
{
    private GodotObject _data;
    public TwitchStream[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamsResponse object.
    /// </summary> 
    public static TwitchGetStreamsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetStreamsResponse
        {
            Data = dataArray.Select(TwitchStream.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_streams.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }

}
