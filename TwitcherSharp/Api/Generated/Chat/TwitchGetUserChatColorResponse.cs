using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetUserChatColorResponse : Resource, ITwitcherSharp<TwitchGetUserChatColorResponse>
{
    private GodotObject _data;
    public TwitchUserChatColor[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserChatColorResponse object.
    /// </summary> 
    public static TwitchGetUserChatColorResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetUserChatColorResponse
        {
            Data = dataArray.Select(TwitchUserChatColor.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_chat_color.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }
    public partial class TwitchUserChatColor : Resource, ITwitcherSharp<TwitchUserChatColor>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string Color { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUserChatColor object.
        /// </summary> 
        public static TwitchUserChatColor FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchUserChatColor
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Color = data.Get("color").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_chat_color.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("color", Color);
            return request;
        }
    
    }

}
