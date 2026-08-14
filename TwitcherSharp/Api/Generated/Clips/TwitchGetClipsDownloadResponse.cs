using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchGetClipsDownloadResponse : RefCounted, ITwitcherSharp<TwitchGetClipsDownloadResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetClipsDownloadResponse object.
    /// </summary> 
    public static TwitchGetClipsDownloadResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetClipsDownloadResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips_download.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// List of clips and their download URLs. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string? ClipId { get; set; }
        public string? LandscapeDownloadUrl { get; set; }
        public string? PortraitDownloadUrl { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                ClipId = data.Get("clip_id").AsString(),
                LandscapeDownloadUrl = data.Get("landscape_download_url").AsString(),
                PortraitDownloadUrl = data.Get("portrait_download_url").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips_download.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(ClipId != null) request.Set("clip_id", ClipId);
            if(LandscapeDownloadUrl != null) request.Set("landscape_download_url", LandscapeDownloadUrl);
            if(PortraitDownloadUrl != null) request.Set("portrait_download_url", PortraitDownloadUrl);
            return request;
        }
    
    }

}
