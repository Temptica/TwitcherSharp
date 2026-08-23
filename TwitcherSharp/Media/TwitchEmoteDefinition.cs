using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;

public partial class TwitchEmoteDefinition(string emoteId) : RefCounted, ITwitcherSharp<TwitchEmoteDefinition>
{
    public string Id { get; set; } = emoteId;
    public int Scale { get; set; }
    public StringName? Type { get; set; }
    public StringName? Theme { get; set; }

    public const int Scale1 = 1;
    public const int Scale2 = 2;
    public const int Scale3 = 3;

    public const string TypeDefault = "default";
    public const string TypeStatic = "static";
    public const string TypeAnimated = "animated";

    public const string ThemeDark = "dark";
    public const string ThemeLight = "light";

    public TwitchEmoteDefinition SetScale1()
    {
        Scale = Scale1;
        return this;
    }

    public TwitchEmoteDefinition SetScale2()
    {
        Scale = Scale2;
        return this;
    }

    public TwitchEmoteDefinition SetScale3()
    {
        Scale = Scale3;
        return this;
    }

    public TwitchEmoteDefinition SetTypeDefault()
    {
        Type = TypeDefault;
        return this;
    }

    public TwitchEmoteDefinition SetTypeStatic()
    {
        Type = TypeStatic;
        return this;
    }

    public TwitchEmoteDefinition SetTypeAnimated()
    {
        Type = TypeAnimated;
        return this;
    }

    public TwitchEmoteDefinition SetThemeDark()
    {
        Theme = ThemeDark;
        return this;
    }

    public TwitchEmoteDefinition SetThemeLight()
    {
        Theme = ThemeLight;
        return this;
    }

    public static TwitchEmoteDefinition? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        return new TwitchEmoteDefinition(data.Get("id").AsString())
        {
            Scale = data.Get("scale").AsInt32(),
            Type = data.Get("type").AsString(),
            Theme = data.Get("theme").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/media/twitch_emote_definition.gd");
        var data = script.New().AsGodotObject();
        data.Set("id", Id);
        data.Set("scale", Scale);
        if (Type != null) data.Set("type", Type);
        if (Theme != null) data.Set("theme", Theme);
        return data;
    }
}