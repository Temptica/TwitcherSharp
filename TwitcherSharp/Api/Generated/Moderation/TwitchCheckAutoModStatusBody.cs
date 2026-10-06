using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchCheckAutoModStatusBody : RefCounted, ITwitcherSharp<TwitchCheckAutoModStatusBody>
{
    private Variant _data;
    public TwitchBodyData[] Data { get => field ??= _data.GetArray<TwitchBodyData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusBody object.
    /// </summary> 
    public static TwitchCheckAutoModStatusBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheckAutoModStatusBody();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd", "Body");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The list of messages to check. The list must contain at least one message and may contain up to a maximum of 100 messages. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private Variant _data;
        public string MsgId { get; set; } = null!;
        public string MsgText { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyData
            {
                MsgId = data.Read("msg_id", static v => v.AsString()),
                MsgText = data.Read("msg_text", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd", "BodyData");
            if(MsgId != null) request.SetValue("msg_id", MsgId);
            if(MsgText != null) request.SetValue("msg_text", MsgText);
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
