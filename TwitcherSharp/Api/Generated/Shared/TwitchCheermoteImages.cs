using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchCheermoteImages : RefCounted, ITwitcherSharp<TwitchCheermoteImages>
{
    private GodotObject _data;
    public TwitchLight Light { get; set; }
    public TwitchDark Dark { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImages object.
    /// </summary> 
    public static TwitchCheermoteImages FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCheermoteImages
        {
            Light = data.Get("light").As<TwitchLight>(),
            Dark = data.Get("dark").As<TwitchDark>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_images.gd");
        var request = script.Call("new").AsGodotObject();
        if(Light != null) request.Set("light", Light);
        if(Dark != null) request.Set("dark", Dark);
        return request;
    }
    public partial class TwitchLight : RefCounted, ITwitcherSharp<TwitchLight>
    {
        private GodotObject _data;
        public TwitchAnimated Animated { get; set; }
        public TwitchStatic Static { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchLight object.
        /// </summary> 
        public static TwitchLight FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchLight
            {
                Animated = data.Get("animated").As<TwitchAnimated>(),
                Static = data.Get("static").As<TwitchStatic>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_light.gd");
            var request = script.Call("new").AsGodotObject();
            if(Animated != null) request.Set("animated", Animated);
            if(Static != null) request.Set("static", Static);
            return request;
        }
        public partial class TwitchAnimated : RefCounted, ITwitcherSharp<TwitchAnimated>
        {
            private GodotObject _data;
            public string _1 { get; set; }
            public string _2 { get; set; }
            public string _3 { get; set; }
            public string _4 { get; set; }
            public string _1_5 { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchAnimated object.
            /// </summary> 
            public static TwitchAnimated FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchAnimated
                {
                    _1 = data.Get("1").AsString(),
                    _2 = data.Get("2").AsString(),
                    _3 = data.Get("3").AsString(),
                    _4 = data.Get("4").AsString(),
                    _1_5 = data.Get("1_5").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_animated.gd");
                var request = script.Call("new").AsGodotObject();
                if(_1 != null) request.Set("1", _1);
                if(_2 != null) request.Set("2", _2);
                if(_3 != null) request.Set("3", _3);
                if(_4 != null) request.Set("4", _4);
                if(_1_5 != null) request.Set("1_5", _1_5);
                return request;
            }
        
        }
        public partial class TwitchStatic : RefCounted, ITwitcherSharp<TwitchStatic>
        {
            private GodotObject _data;
            public string _1 { get; set; }
            public string _2 { get; set; }
            public string _3 { get; set; }
            public string _4 { get; set; }
            public string _1_5 { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchStatic object.
            /// </summary> 
            public static TwitchStatic FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchStatic
                {
                    _1 = data.Get("1").AsString(),
                    _2 = data.Get("2").AsString(),
                    _3 = data.Get("3").AsString(),
                    _4 = data.Get("4").AsString(),
                    _1_5 = data.Get("1_5").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_static.gd");
                var request = script.Call("new").AsGodotObject();
                if(_1 != null) request.Set("1", _1);
                if(_2 != null) request.Set("2", _2);
                if(_3 != null) request.Set("3", _3);
                if(_4 != null) request.Set("4", _4);
                if(_1_5 != null) request.Set("1_5", _1_5);
                return request;
            }
        
        }
    
    }
    public partial class TwitchDark : RefCounted, ITwitcherSharp<TwitchDark>
    {
        private GodotObject _data;
        public TwitchAnimated Animated { get; set; }
        public TwitchStatic Static { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDark object.
        /// </summary> 
        public static TwitchDark FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchDark
            {
                Animated = data.Get("animated").As<TwitchAnimated>(),
                Static = data.Get("static").As<TwitchStatic>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_dark.gd");
            var request = script.Call("new").AsGodotObject();
            if(Animated != null) request.Set("animated", Animated);
            if(Static != null) request.Set("static", Static);
            return request;
        }
        public partial class TwitchAnimated : RefCounted, ITwitcherSharp<TwitchAnimated>
        {
            private GodotObject _data;
            public string _1 { get; set; }
            public string _2 { get; set; }
            public string _3 { get; set; }
            public string _4 { get; set; }
            public string _1_5 { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchAnimated object.
            /// </summary> 
            public static TwitchAnimated FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchAnimated
                {
                    _1 = data.Get("1").AsString(),
                    _2 = data.Get("2").AsString(),
                    _3 = data.Get("3").AsString(),
                    _4 = data.Get("4").AsString(),
                    _1_5 = data.Get("1_5").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_animated.gd");
                var request = script.Call("new").AsGodotObject();
                if(_1 != null) request.Set("1", _1);
                if(_2 != null) request.Set("2", _2);
                if(_3 != null) request.Set("3", _3);
                if(_4 != null) request.Set("4", _4);
                if(_1_5 != null) request.Set("1_5", _1_5);
                return request;
            }
        
        }
        public partial class TwitchStatic : RefCounted, ITwitcherSharp<TwitchStatic>
        {
            private GodotObject _data;
            public string _1 { get; set; }
            public string _2 { get; set; }
            public string _3 { get; set; }
            public string _4 { get; set; }
            public string _1_5 { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchStatic object.
            /// </summary> 
            public static TwitchStatic FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchStatic
                {
                    _1 = data.Get("1").AsString(),
                    _2 = data.Get("2").AsString(),
                    _3 = data.Get("3").AsString(),
                    _4 = data.Get("4").AsString(),
                    _1_5 = data.Get("1_5").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_static.gd");
                var request = script.Call("new").AsGodotObject();
                if(_1 != null) request.Set("1", _1);
                if(_2 != null) request.Set("2", _2);
                if(_3 != null) request.Set("3", _3);
                if(_4 != null) request.Set("4", _4);
                if(_1_5 != null) request.Set("1_5", _1_5);
                return request;
            }
        
        }
    
    }

}
