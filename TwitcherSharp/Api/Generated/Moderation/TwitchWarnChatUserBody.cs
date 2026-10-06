using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchWarnChatUserBody : RefCounted, ITwitcherSharp<TwitchWarnChatUserBody>
{
    private Variant _data;
    public TwitchBodyData Data { get => field ??= _data.Get<TwitchBodyData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchWarnChatUserBody object.
    /// </summary> 
    public static TwitchWarnChatUserBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchWarnChatUserBody();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_warn_chat_user.gd", "Body");
        if(Data != null) request.SetObject("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list that contains information about the warning. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private Variant _data;
        public string UserId { get; set; } = null!;
        public string Reason { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyData
            {
                UserId = data.Read("user_id", static v => v.AsString()),
                Reason = data.Read("reason", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_warn_chat_user.gd", "BodyData");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(Reason != null) request.SetValue("reason", Reason);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
