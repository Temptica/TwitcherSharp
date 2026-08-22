using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStreamMarkers : RefCounted, ITwitcherSharp<TwitchStreamMarkers>
{
    private GodotObject? _data;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public TwitchResponseVideos[] Videos { get => field ??= _data?.GetArray<TwitchResponseVideos>("videos")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamMarkers object.
    /// </summary> 
    public static TwitchStreamMarkers? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamMarkers
        {
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_markers.gd");
        var request = script.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserName != null) request.Set("user_name", UserName);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(Videos != null) request.Set("videos", Videos.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list of videos that contain markers. The list contains a single video. 
    /// </summary>
    public partial class TwitchResponseVideos : RefCounted, ITwitcherSharp<TwitchResponseVideos>
    {
        private GodotObject? _data;
        public string VideoId { get; set; } = null!;
        public TwitchResponseMarkers[] Markers { get => field ??= _data?.GetArray<TwitchResponseMarkers>("markers")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseVideos object.
        /// </summary> 
        public static TwitchResponseVideos? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseVideos
            {
                VideoId = data.Get("video_id").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_markers.gd");
            var twitchResponseVideosClass = script.Get("Videos").AsGodotObject();
            var request = twitchResponseVideosClass.Call("new").AsGodotObject();
            if(VideoId != null) request.Set("video_id", VideoId);
            if(Markers != null) request.Set("markers", Markers.ToGodotArray());
            return request;
        }
        
        /// <summary> 
        /// The list of markers in this video. The list in ascending order by when the marker was created. 
        /// </summary>
        public partial class TwitchResponseMarkers : RefCounted, ITwitcherSharp<TwitchResponseMarkers>
        {
            private GodotObject? _data;
            public string Id { get; set; } = null!;
            public string CreatedAt { get; set; } = null!;
            public string Description { get; set; } = null!;
            public int PositionSeconds { get; set; }
            public string Url { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMarkers object.
            /// </summary> 
            public static TwitchResponseMarkers? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMarkers
                {
                    Id = data.Get("id").AsString(),
                    CreatedAt = data.Get("created_at").AsString(),
                    Description = data.Get("description").AsString(),
                    PositionSeconds = data.Get("position_seconds").AsInt32(),
                    Url = data.Get("url").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_markers.gd");
                var twitchResponseMarkersClass = script.Get("Markers").AsGodotObject();
                var request = twitchResponseMarkersClass.Call("new").AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(CreatedAt != null) request.Set("created_at", CreatedAt);
                if(Description != null) request.Set("description", Description);
                request.Set("position_seconds", PositionSeconds);
                if(Url != null) request.Set("url", Url);
                return request;
            }
        
        }
    
    }

}
