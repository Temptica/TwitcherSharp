using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Schedule;

public partial class TwitchChannelStreamScheduleSegment : RefCounted, ITwitcherSharp<TwitchChannelStreamScheduleSegment>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string CanceledUntil { get; set; } = null!;
    public TwitchCategory Category { get => field ??= _data.Get<TwitchCategory>("category")!; set; } = null!;
    public bool IsRecurring { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelStreamScheduleSegment object.
    /// </summary> 
    public static TwitchChannelStreamScheduleSegment? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelStreamScheduleSegment
        {
            Id = data.Read("id", static v => v.AsString()),
            StartTime = data.Read("start_time", static v => v.AsString()),
            EndTime = data.Read("end_time", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            CanceledUntil = data.Read("canceled_until", static v => v.AsString()),
            IsRecurring = data.Read("is_recurring", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_channel_stream_schedule_segment.gd");
        if(Id != null) request.SetValue("id", Id);
        if(StartTime != null) request.SetValue("start_time", StartTime);
        if(EndTime != null) request.SetValue("end_time", EndTime);
        if(Title != null) request.SetValue("title", Title);
        if(CanceledUntil != null) request.SetValue("canceled_until", CanceledUntil);
        if(Category != null) request.SetObject("category", Category);
        request.SetValue("is_recurring", IsRecurring);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The type of content that the broadcaster plans to stream or **null** if not specified. 
    /// </summary>
    public partial class TwitchCategory : RefCounted, ITwitcherSharp<TwitchCategory>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCategory object.
        /// </summary> 
        public static TwitchCategory? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCategory
            {
                Id = data.Read("id", static v => v.AsString()),
                Name = data.Read("name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_channel_stream_schedule_segment.gd", "Category");
            if(Id != null) request.SetValue("id", Id);
            if(Name != null) request.SetValue("name", Name);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
