using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUpdateUserResponse : RefCounted, ITwitcherSharp<TwitchUpdateUserResponse>
{
    private GodotObject _data;
    public TwitchUser[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserResponse object.
    /// </summary> 
    public static TwitchUpdateUserResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchUpdateUserResponse
        {
            Data = dataArray.Select(TwitchUser.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
