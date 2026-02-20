using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchGetClipsDownloadResponse : Resource, ITwitcherSharp<TwitchGetClipsDownloadResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetClipsDownloadResponse object.
    /// </summary> 
    public static TwitchGetClipsDownloadResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetClipsDownloadResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips_download.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	/// List of clips and their download URLs. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string ClipId { get; set; }
		public string LandscapeDownloadUrl { get; set; }
		public string PortraitDownloadUrl { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				ClipId = data.Get("clip_id").AsString(),
				LandscapeDownloadUrl = data.Get("landscape_download_url").AsString(),
				PortraitDownloadUrl = data.Get("portrait_download_url").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("clip_id", ClipId);
			request.Set("landscape_download_url", LandscapeDownloadUrl);
			request.Set("portrait_download_url", PortraitDownloadUrl);
			return request;
		}
	
	}

}
