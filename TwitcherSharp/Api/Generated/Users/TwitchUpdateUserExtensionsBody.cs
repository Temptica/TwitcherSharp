using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUpdateUserExtensionsBody : RefCounted, ITwitcherSharp<TwitchUpdateUserExtensionsBody>
{
    private Variant _data;
    public TwitchBodyData Data { get => field ??= _data.Get<TwitchBodyData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserExtensionsBody object.
    /// </summary> 
    public static TwitchUpdateUserExtensionsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateUserExtensionsBody();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_user_extensions.gd", "Body");
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
    /// The extensions to update. The `data` field is a dictionary of extension types. The dictionary’s possible keys are: panel, overlay, or component. The key’s value is a dictionary of extensions.  
    ///   
    /// For the extension’s dictionary, the key is a sequential number beginning with 1\. For panel and overlay extensions, the key’s value is an object that contains the following fields: `active` (true/false), `id` (the extension’s ID), and `version` (the extension’s version).  
    ///   
    /// For component extensions, the key’s value includes the above fields plus the `x` and `y` fields, which identify the coordinate where the extension is placed. 
    /// </summary>
    public partial class TwitchBodyData : RefCounted, ITwitcherSharp<TwitchBodyData>
    {
        private Variant _data;
        public Variant? Panel { get; set; }
        public Variant? Overlay { get; set; }
        public Variant? Component { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyData
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_user_extensions.gd", "BodyData");
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
