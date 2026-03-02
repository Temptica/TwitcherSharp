using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserActiveExtensionsResponse : Resource, ITwitcherSharp<TwitchGetUserActiveExtensionsResponse>
{
    private GodotObject _data;
    public TwitchData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserActiveExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserActiveExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetUserActiveExtensionsResponse
        {
            Data = data.Get("data").As<TwitchData>(),
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
    public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public Variant? Panel { get; set; }
        public Variant? Overlay { get; set; }
        public Variant? Component { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                Panel = data.Get("panel").As<Variant>(),
                Overlay = data.Get("overlay").As<Variant>(),
                Component = data.Get("component").As<Variant>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            if(Panel.HasValue) request.Set("panel", Panel.Value);
            if(Overlay.HasValue) request.Set("overlay", Overlay.Value);
            if(Component.HasValue) request.Set("component", Component.Value);
            return request;
        }
    
    }

}
