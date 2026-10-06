using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBanUserBody : RefCounted, ITwitcherSharp<TwitchBanUserBody>
{
    private Variant _data;
    public TwitchBodyData Data { get => field ??= _data.Get<TwitchBodyData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserBody object.
    /// </summary> 
    public static TwitchBanUserBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBanUserBody();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_ban_user.gd", "Body");
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
    /// Identifies the user and type of ban. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private Variant _data;
        public string UserId { get; set; } = null!;
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
                UserId = data.Read("user_id", static v => v.AsString()),
                Duration = data.Read("duration", static v => v.AsInt32()),
                Reason = data.Read("reason", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_ban_user.gd", "BodyData");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(Duration.HasValue) request.SetValue("duration", Duration.Value);
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
