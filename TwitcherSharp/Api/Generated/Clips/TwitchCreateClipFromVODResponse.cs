using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

public partial class TwitchCreateClipFromVODResponse : RefCounted, ITwitcherSharp<TwitchCreateClipFromVODResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipFromVODResponse object.
    /// </summary> 
    public static TwitchCreateClipFromVODResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCreateClipFromVODResponse
        {
            Data = dataArray.Select(TwitchResponseData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_from_vod.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list containing the created clip. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string EditUrl { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                Id = data.Get("id").AsString(),
                EditUrl = data.Get("edit_url").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_from_vod.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("edit_url", EditUrl);
            return request;
        }
    
    }

}
