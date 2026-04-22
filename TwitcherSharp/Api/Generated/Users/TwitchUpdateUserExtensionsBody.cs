using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUpdateUserExtensionsBody : RefCounted, ITwitcherSharp<TwitchUpdateUserExtensionsBody>
{
    private GodotObject _data;
    public TwitchBodyData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserExtensionsBody object.
    /// </summary> 
    public static TwitchUpdateUserExtensionsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUpdateUserExtensionsBody
        {
            Data = data.Get("data").As<TwitchBodyData>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("data", Data?.ToGodotObject());
        return request;
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
        private GodotObject _data;
        public Variant? Panel { get; set; }
        public Variant? Overlay { get; set; }
        public Variant? Component { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyData object.
        /// </summary> 
        public static TwitchBodyData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchBodyData
            {
                Panel = data.Get("panel").As<Variant>(),
                Overlay = data.Get("overlay").As<Variant>(),
                Component = data.Get("component").As<Variant>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions.gd");
            var twitchBodyDataClass = script.Get("BodyData").AsGodotObject();
            var request = twitchBodyDataClass.Call("new").AsGodotObject();
            if(Panel.HasValue) request.Set("panel", Panel.Value);
            if(Overlay.HasValue) request.Set("overlay", Overlay.Value);
            if(Component.HasValue) request.Set("component", Component.Value);
            return request;
        }
    
    }

}
