using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchCheckAutoModStatusResponse : Resource, ITwitcherSharp<TwitchCheckAutoModStatusResponse>
{
    private GodotObject _data;
    public TwitchAutoModStatus[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckAutoModStatusResponse object.
    /// </summary> 
    public static TwitchCheckAutoModStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCheckAutoModStatusResponse
        {
            Data = dataArray.Select(TwitchAutoModStatus.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }
    public partial class TwitchAutoModStatus : Resource, ITwitcherSharp<TwitchAutoModStatus>
    {
        private GodotObject _data;
        public string MsgId { get; set; }
        public bool IsPermitted { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAutoModStatus object.
        /// </summary> 
        public static TwitchAutoModStatus FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchAutoModStatus
            {
                MsgId = data.Get("msg_id").AsString(),
                IsPermitted = data.Get("is_permitted").AsBool(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_auto_mod_status.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("msg_id", MsgId);
            request.Set("is_permitted", IsPermitted);
            return request;
        }
    
    }

}
