using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserActiveExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetUserActiveExtensionsResponse>
{
    private Variant _data;
    public TwitchResponseData? Data { get => field ??= _data.Get<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserActiveExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserActiveExtensionsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserActiveExtensionsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd", "Response");
        if(Data != null) request.SetValue("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The active extensions that the broadcaster has installed. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public Variant? Panel { get; set; }
        public Variant? Overlay { get; set; }
        public Variant? Component { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Panel = data.Read("panel", static v => v.As<Variant>()),
                Overlay = data.Read("overlay", static v => v.As<Variant>()),
                Component = data.Read("component", static v => v.As<Variant>()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd", "ResponseData");
            if(Panel.HasValue) request.SetValue("panel", Panel.Value);
            if(Overlay.HasValue) request.SetValue("overlay", Overlay.Value);
            if(Component.HasValue) request.SetValue("component", Component.Value);
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
