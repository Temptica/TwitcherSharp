using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Schedule;
 
/// <summary> 
///  
/// </summary>
public partial class CreateChannelStreamScheduleSegmentResponse : Resource, ITwitcherSharp<CreateChannelStreamScheduleSegmentResponse>
{
    private GodotObject _data;
	public Data Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateChannelStreamScheduleSegmentResponse object.
    /// </summary> 
    public static CreateChannelStreamScheduleSegmentResponse FromObject(GodotObject data)
    {
        return new CreateChannelStreamScheduleSegmentResponse
        {

			Data = data.Get("data").As<Data>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_channel_stream_schedule_segment_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
