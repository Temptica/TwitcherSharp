using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The reporting window’s start and end dates, in RFC3339 format. The dates are calculated by using the _started\_at_ and _period_ query parameters. If you don’t specify the _started\_at_ query parameter, the fields contain empty strings. 
/// </summary>
public partial class DateRange : Resource, ITwitcherSharp<DateRange>
{
    private GodotObject _data;
	public string StartedAt { get; set; }
	public string EndedAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DateRange object.
    /// </summary> 
    public static DateRange FromObject(GodotObject data)
    {
        return new DateRange
        {

			StartedAt = data.Get("started_at").AsString(),
			EndedAt = data.Get("ended_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_date_range.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("started_at", StartedAt);
		request.Set("ended_at", EndedAt);
		return request;
	}
}
