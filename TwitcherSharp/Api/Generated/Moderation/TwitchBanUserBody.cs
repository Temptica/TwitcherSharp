using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBanUserBody : RefCounted, ITwitcherSharp<TwitchBanUserBody>
{
    private GodotObject? _data;
    public TwitchBodyData? Data { get => field ??= _data?.Get<TwitchBodyData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserBody object.
    /// </summary> 
    public static TwitchBanUserBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBanUserBody();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// Identifies the user and type of ban. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private GodotObject? _data;
        public string? UserId { get; set; }
        public int? Duration { get; set; }
        public string? Reason { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyData
            {
                UserId = data.Get("user_id").AsString(),
                Duration = data.Get("duration").AsInt32(),
                Reason = data.Get("reason").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
            var twitchBodyDataClass = script.Get("BodyData").AsGodotObject();
            var request = twitchBodyDataClass.Call("new").AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(Duration.HasValue) request.Set("duration", Duration.Value);
            if(Reason != null) request.Set("reason", Reason);
            return request;
        }
    
    }

}
