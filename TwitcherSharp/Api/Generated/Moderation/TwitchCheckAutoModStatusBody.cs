using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchCheckAutoModStatusBody : RefCounted, ITwitcherSharp<TwitchCheckAutoModStatusBody>
{
    private GodotObject? _data;
    public TwitchBodyData[]? Data { get => field ??= _data?.GetArray<TwitchBodyData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusBody object.
    /// </summary> 
    public static TwitchCheckAutoModStatusBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheckAutoModStatusBody();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// The list of messages to check. The list must contain at least one message and may contain up to a maximum of 100 messages. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private GodotObject? _data;
        public string? MsgId { get; set; }
        public string? MsgText { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyData
            {
                MsgId = data.Get("msg_id").AsString(),
                MsgText = data.Get("msg_text").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
            var twitchBodyDataClass = script.Get("BodyData").AsGodotObject();
            var request = twitchBodyDataClass.Call("new").AsGodotObject();
            if(MsgId != null) request.Set("msg_id", MsgId);
            if(MsgText != null) request.Set("msg_text", MsgText);
            return request;
        }
    
    }

}
