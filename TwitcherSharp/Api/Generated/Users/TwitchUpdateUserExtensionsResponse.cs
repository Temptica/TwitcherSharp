using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUpdateUserExtensionsResponse : RefCounted, ITwitcherSharp<TwitchUpdateUserExtensionsResponse>
{
    private Variant _data;
    public TwitchResponseData Data { get => field ??= _data.Get<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserExtensionsResponse object.
    /// </summary> 
    public static TwitchUpdateUserExtensionsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateUserExtensionsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_user_extensions.gd", "Response");
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
    /// The extensions that the broadcaster updated. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public Variant Panel { get; set; }
        public Variant Overlay { get; set; }
        public Variant Component { get; set; }
    
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_user_extensions.gd", "ResponseData");
            request.SetValue("panel", Panel);
            request.SetValue("overlay", Overlay);
            request.SetValue("component", Component);
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
