using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchCreateClipFromVODResponse : Resource, ITwitcherSharp<TwitchCreateClipFromVODResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipFromVODResponse object.
    /// </summary> 
    public static TwitchCreateClipFromVODResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateClipFromVODResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_from_v_o_d.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	/// A list containing the created clip. 
	/// </summary>
	public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
	{
	    private GodotObject _data;
		public string Id { get; set; }
		public string EditUrl { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchData object.
	    /// </summary> 
	    public static TwitchData FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchData
			{
				Id = data.Get("id").AsString(),
				EditUrl = data.Get("edit_url").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("id", Id);
			request.Set("edit_url", EditUrl);
			return request;
		}
	
	}

}
