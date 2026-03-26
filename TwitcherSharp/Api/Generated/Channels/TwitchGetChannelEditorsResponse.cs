using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchGetChannelEditorsResponse : RefCounted, ITwitcherSharp<TwitchGetChannelEditorsResponse>
{
    private GodotObject _data;
    public TwitchChannelEditor[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEditorsResponse object.
    /// </summary> 
    public static TwitchGetChannelEditorsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelEditorsResponse
        {
            Data = dataArray.Select(TwitchChannelEditor.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_editors.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }
    public partial class TwitchChannelEditor : RefCounted, ITwitcherSharp<TwitchChannelEditor>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CreatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchChannelEditor object.
        /// </summary> 
        public static TwitchChannelEditor FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchChannelEditor
            {
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_editor.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_name", UserName);
            request.Set("created_at", CreatedAt);
            return request;
        }
    
    }

}
