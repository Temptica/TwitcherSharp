using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;
public partial class TwitchBadgeDefinition : Resource, ITwitcherSharp<TwitchBadgeDefinition>
{
    public TwitchBadgeDefinition(string setId, string id, int badgeScale, string badgeChannel)
    {
        BadgeSet = setId;
        BadgeId = id;
        Scale = badgeScale;
        Channel = badgeChannel;
        _cacheId = $"{Channel}_{BadgeSet}_{BadgeId}_{Scale}";
    }

    public const int Scale1 = 1;
    public const int Scale2 = 2;
    public const int Scale4 = 4;

    public string BadgeSet { get; set; }
    public string BadgeId { get; set; }
    public int Scale { get;
        set => field = SetScale(value);
    }
    public string Channel { get; set; }
    
    private string _cacheId;

    public TwitchBadgeDefinition SetScale1()
    {
        Scale = Scale1;
        return this;
    }

    public TwitchBadgeDefinition SetScale2()
    {
        Scale = Scale2;
        return this;
    }

    public TwitchBadgeDefinition SetScale4()
    {
        Scale = Scale4;
        return this;
    }

    /// <summary>
    /// Sets the scale of the badge. If less than or equal to 1, it will be set to 1. If greater than or equal to 4, it will be set to 4. Otherwise, it will be set to 2.
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public int SetScale(int scale)
    {
        //clamp to 1,2,4
        return scale switch
        {
            <= 1 => Scale1,
            >= 4 => Scale4,
            _ => Scale2
        };
    }

    public override string ToString() => "Badge[" + Channel + "/" + BadgeSet + "/" + BadgeId + "]";
    public string GetCacheId() => _cacheId;
    
    public static TwitchBadgeDefinition FromObject(GodotObject data)
    {
        return new TwitchBadgeDefinition(data.Get("set_id").AsString(), data.Get("id").AsString(), data.Get("badge_scale").AsInt32(), data.Get("badge_channel").AsString());
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/media/twitch_badge_definition.gd");
        var data = script.New().AsGodotObject();
        data.Set("set_id", BadgeSet);
        data.Set("id", BadgeId);
        data.Set("badge_scale", Scale);
        data.Set("badge_channel", Channel);
        return data;   
    }
}