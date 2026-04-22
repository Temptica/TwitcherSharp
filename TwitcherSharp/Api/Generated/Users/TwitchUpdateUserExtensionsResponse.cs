using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUpdateUserExtensionsResponse : RefCounted, ITwitcherSharp<TwitchUpdateUserExtensionsResponse>
{
    private GodotObject _data;
    public TwitchResponseData Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserExtensionsResponse object.
    /// </summary> 
    public static TwitchUpdateUserExtensionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUpdateUserExtensionsResponse
        {
            Data = data.Get("data").As<TwitchResponseData>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The extensions that the broadcaster updated. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public Variant Panel { get; set; }
        public Variant Overlay { get; set; }
        public Variant Component { get; set; }
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("panel", Panel);
            request.Set("overlay", Overlay);
            request.Set("component", Component);
            return request;
        }
    
    }

}
