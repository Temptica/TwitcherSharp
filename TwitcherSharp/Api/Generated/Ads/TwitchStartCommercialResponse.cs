using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Ads;

public partial class TwitchStartCommercialResponse : RefCounted, ITwitcherSharp<TwitchStartCommercialResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartCommercialResponse object.
    /// </summary> 
    public static TwitchStartCommercialResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchStartCommercialResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_commercial.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }
    
    /// <summary> 
    /// An array that contains a single object with the status of your start commercial request. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public int Length { get; set; }
        public string Message { get; set; }
        public int RetryAfter { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Length = data.Get("length").AsInt32(),
                Message = data.Get("message").AsString(),
                RetryAfter = data.Get("retry_after").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_commercial.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("length", Length);
            request.Set("message", Message);
            request.Set("retry_after", RetryAfter);
            return request;
        }
    
    }

}
