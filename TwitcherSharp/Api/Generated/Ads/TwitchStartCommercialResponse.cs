using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchStartCommercialResponse : Resource, ITwitcherSharp<TwitchStartCommercialResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartCommercialResponse object.
    /// </summary> 
    public static TwitchStartCommercialResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchStartCommercialResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_commercial.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }
    
    /// <summary> 
    /// An array that contains a single object with the status of your start commercial request. 
    /// </summary>
    public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public int Length { get; set; }
        public string Message { get; set; }
        public int RetryAfter { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                Length = data.Get("length").AsInt32(),
                Message = data.Get("message").AsString(),
                RetryAfter = data.Get("retry_after").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("length", Length);
            request.Set("message", Message);
            request.Set("retry_after", RetryAfter);
            return request;
        }
    
    }

}
