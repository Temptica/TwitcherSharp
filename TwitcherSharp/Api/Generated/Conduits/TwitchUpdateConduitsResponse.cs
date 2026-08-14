using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitsResponse : RefCounted, ITwitcherSharp<TwitchUpdateConduitsResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitsResponse object.
    /// </summary> 
    public static TwitchUpdateConduitsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateConduitsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduits.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// List of information about the client’s conduits. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string? Id { get; set; }
        public int ShardCount { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Id = data.Get("id").AsString(),
                ShardCount = data.Get("shard_count").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduits.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            request.Set("shard_count", ShardCount);
            return request;
        }
    
    }

}
