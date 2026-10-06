using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchGetClipsDownloadResponse : RefCounted, ITwitcherSharp<TwitchGetClipsDownloadResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetClipsDownloadResponse object.
    /// </summary> 
    public static TwitchGetClipsDownloadResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetClipsDownloadResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_clips_download.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// List of clips and their download URLs. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string ClipId { get; set; } = null!;
        public string LandscapeDownloadUrl { get; set; } = null!;
        public string PortraitDownloadUrl { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                ClipId = data.Read("clip_id", static v => v.AsString()),
                LandscapeDownloadUrl = data.Read("landscape_download_url", static v => v.AsString()),
                PortraitDownloadUrl = data.Read("portrait_download_url", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_clips_download.gd", "ResponseData");
            if(ClipId != null) request.SetValue("clip_id", ClipId);
            if(LandscapeDownloadUrl != null) request.SetValue("landscape_download_url", LandscapeDownloadUrl);
            if(PortraitDownloadUrl != null) request.SetValue("portrait_download_url", PortraitDownloadUrl);
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
