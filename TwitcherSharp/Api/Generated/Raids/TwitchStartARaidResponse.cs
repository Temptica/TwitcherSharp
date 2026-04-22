using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Raids;

public partial class TwitchStartARaidResponse : RefCounted, ITwitcherSharp<TwitchStartARaidResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartARaidResponse object.
    /// </summary> 
    public static TwitchStartARaidResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchStartARaidResponse
        {
            Data = dataArray.Select(TwitchResponseData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_a_raid.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains a single object with information about the pending raid. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string CreatedAt { get; set; }
        public bool IsMature { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                CreatedAt = data.Get("created_at").AsString(),
                IsMature = data.Get("is_mature").AsBool(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_a_raid.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("created_at", CreatedAt);
            request.Set("is_mature", IsMature);
            return request;
        }
    
    }

}
