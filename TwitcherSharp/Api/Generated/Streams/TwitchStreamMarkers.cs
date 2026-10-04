using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

public partial class TwitchStreamMarkers : RefCounted, ITwitcherSharp<TwitchStreamMarkers>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public TwitchResponseVideos[] Videos { get => field ??= _data.GetArray<TwitchResponseVideos>("videos")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamMarkers object.
    /// </summary> 
    public static TwitchStreamMarkers? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamMarkers
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_stream_markers.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(Videos != null) request.SetArray("videos", Videos);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list of videos that contain markers. The list contains a single video. 
    /// </summary>
    public partial class TwitchResponseVideos : RefCounted, ITwitcherSharp<TwitchResponseVideos>
    {
        private Variant _data;
        public string VideoId { get; set; } = null!;
        public TwitchResponseMarkers[] Markers { get => field ??= _data.GetArray<TwitchResponseMarkers>("markers")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseVideos object.
        /// </summary> 
        public static TwitchResponseVideos? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseVideos
            {
                VideoId = data.Read("video_id", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_stream_markers.gd", "Videos");
            if(VideoId != null) request.SetValue("video_id", VideoId);
            if(Markers != null) request.SetArray("markers", Markers);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// The list of markers in this video. The list in ascending order by when the marker was created. 
        /// </summary>
        public partial class TwitchResponseMarkers : RefCounted, ITwitcherSharp<TwitchResponseMarkers>
        {
            private Variant _data;
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
                    Id = data.Read("id", static v => v.AsString()),
                    CreatedAt = data.Read("created_at", static v => v.AsString()),
                    Description = data.Read("description", static v => v.AsString()),
                    PositionSeconds = data.Read("position_seconds", static v => v.AsInt32()),
                    Url = data.Read("url", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_stream_markers.gd", "Markers");
                if(Id != null) request.SetValue("id", Id);
                if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
                if(Description != null) request.SetValue("description", Description);
                request.SetValue("position_seconds", PositionSeconds);
                if(Url != null) request.SetValue("url", Url);
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

}
