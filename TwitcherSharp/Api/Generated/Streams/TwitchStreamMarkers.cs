using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStreamMarkers : RefCounted, ITwitcherSharp<TwitchStreamMarkers>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserLogin { get; set; }
    public TwitchVideos[] Videos { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamMarkers object.
    /// </summary> 
    public static TwitchStreamMarkers FromObject(GodotObject data)
    {
        if(data == null) return null;
        var videosArray = data.Get("videos").AsGodotArray<GodotObject>();
        return new TwitchStreamMarkers
        {
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            Videos = videosArray.Select(TwitchVideos.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_markers.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_name", UserName);
        request.Set("user_login", UserLogin);
        if(Videos != null) request.Set("videos", new Godot.Collections.Array<GodotObject>(Videos.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }
    
    /// <summary> 
    /// A list of videos that contain markers. The list contains a single video. 
    /// </summary>
    public partial class TwitchVideos : RefCounted, ITwitcherSharp<TwitchVideos>
    {
        private GodotObject _data;
        public string VideoId { get; set; }
        public TwitchMarkers[] Markers { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVideos object.
        /// </summary> 
        public static TwitchVideos FromObject(GodotObject data)
        {
            if(data == null) return null;
            var markersArray = data.Get("markers").AsGodotArray<GodotObject>();
            return new TwitchVideos
            {
                VideoId = data.Get("video_id").AsString(),
                Markers = markersArray.Select(TwitchMarkers.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_videos.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("video_id", VideoId);
            if(Markers != null) request.Set("markers", new Godot.Collections.Array<GodotObject>(Markers.Select(x => x.ToGodotObject()).ToArray()));
            return request;
        }
        
        /// <summary> 
        /// The list of markers in this video. The list in ascending order by when the marker was created. 
        /// </summary>
        public partial class TwitchMarkers : RefCounted, ITwitcherSharp<TwitchMarkers>
        {
            private GodotObject _data;
            public string Id { get; set; }
            public string CreatedAt { get; set; }
            public string Description { get; set; }
            public int PositionSeconds { get; set; }
            public string Url { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchMarkers object.
            /// </summary> 
            public static TwitchMarkers FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchMarkers
                {
                    Id = data.Get("id").AsString(),
                    CreatedAt = data.Get("created_at").AsString(),
                    Description = data.Get("description").AsString(),
                    PositionSeconds = data.Get("position_seconds").AsInt32(),
                    Url = data.Get("url").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_markers.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("id", Id);
                request.Set("created_at", CreatedAt);
                request.Set("description", Description);
                request.Set("position_seconds", PositionSeconds);
                request.Set("url", Url);
                return request;
            }
        
        }
    
    }

}
