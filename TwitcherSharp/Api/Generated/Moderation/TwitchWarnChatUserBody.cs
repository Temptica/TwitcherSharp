using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchWarnChatUserBody : RefCounted, ITwitcherSharp<TwitchWarnChatUserBody>
{
    private GodotObject _data;
    public TwitchBodyData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWarnChatUserBody object.
    /// </summary> 
    public static TwitchWarnChatUserBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchWarnChatUserBody
        {
            Data = data.Get("data").As<TwitchBodyData>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("data", Data?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// A list that contains information about the warning. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string Reason { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchBodyData
            {
                UserId = data.Get("user_id").AsString(),
                Reason = data.Get("reason").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
            var twitchBodyDataClass = script.Get("BodyData").AsGodotObject();
            var request = twitchBodyDataClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("reason", Reason);
            return request;
        }
    
    }

}
