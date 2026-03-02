using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUsersResponse : Resource, ITwitcherSharp<TwitchGetUsersResponse>
{
    private GodotObject _data;
    public TwitchUser[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUsersResponse object.
    /// </summary> 
    public static TwitchGetUsersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetUsersResponse
        {
            Data = dataArray.Select(TwitchUser.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }

}
