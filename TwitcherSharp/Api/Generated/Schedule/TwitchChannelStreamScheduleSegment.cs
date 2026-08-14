using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchChannelStreamScheduleSegment : RefCounted, ITwitcherSharp<TwitchChannelStreamScheduleSegment>
{
    private GodotObject? _data;
    public string? Id { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? Title { get; set; }
    public string? CanceledUntil { get; set; }
    public TwitchCategory? Category { get => field ??= _data?.Get<TwitchCategory>("category"); set; }
    public bool IsRecurring { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelStreamScheduleSegment object.
    /// </summary> 
    public static TwitchChannelStreamScheduleSegment? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelStreamScheduleSegment
        {
            Id = data.Get("id").AsString(),
            StartTime = data.Get("start_time").AsString(),
            EndTime = data.Get("end_time").AsString(),
            Title = data.Get("title").AsString(),
            CanceledUntil = data.Get("canceled_until").AsString(),
            IsRecurring = data.Get("is_recurring").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_stream_schedule_segment.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(StartTime != null) request.Set("start_time", StartTime);
        if(EndTime != null) request.Set("end_time", EndTime);
        if(Title != null) request.Set("title", Title);
        if(CanceledUntil != null) request.Set("canceled_until", CanceledUntil);
        if(Category != null) request.Set("category", Category.ToGodotObject());
        request.Set("is_recurring", IsRecurring);
        return request;
    }
    
    /// <summary> 
    /// The type of content that the broadcaster plans to stream or **null** if not specified. 
    /// </summary>
    public partial class TwitchCategory : RefCounted, ITwitcherSharp<TwitchCategory>
    {
        private GodotObject? _data;
        public string? Id { get; set; }
        public string? Name { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCategory object.
        /// </summary> 
        public static TwitchCategory? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCategory
            {
                Id = data.Get("id").AsString(),
                Name = data.Get("name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_stream_schedule_segment.gd");
            var twitchCategoryClass = script.Get("Category").AsGodotObject();
            var request = twitchCategoryClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            if(Name != null) request.Set("name", Name);
            return request;
        }
    
    }

}
