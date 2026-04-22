using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserActiveExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetUserActiveExtensionsResponse>
{
    private GodotObject _data;
    public TwitchResponseData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserActiveExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserActiveExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetUserActiveExtensionsResponse
        {
            Data = data.Get("data").As<TwitchResponseData>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data);
        return request;
    }
    
    /// <summary> 
    /// The active extensions that the broadcaster has installed. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public Variant? Panel { get; set; }
        public Variant? Overlay { get; set; }
        public Variant? Component { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                Panel = data.Get("panel").As<Variant>(),
                Overlay = data.Get("overlay").As<Variant>(),
                Component = data.Get("component").As<Variant>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Panel.HasValue) request.Set("panel", Panel.Value);
            if(Overlay.HasValue) request.Set("overlay", Overlay.Value);
            if(Component.HasValue) request.Set("component", Component.Value);
            return request;
        }
    
    }

}
