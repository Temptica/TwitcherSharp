using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUserBlockList : Resource, ITwitcherSharp<TwitchUserBlockList>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string DisplayName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserBlockList object.
    /// </summary> 
    public static TwitchUserBlockList FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUserBlockList
		{
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			DisplayName = data.Get("display_name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_block_list.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("display_name", DisplayName);
		return request;
	}
}
