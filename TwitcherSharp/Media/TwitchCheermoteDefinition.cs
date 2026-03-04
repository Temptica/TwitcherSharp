using System.Xml;
using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;

public partial class TwitchCheermoteDefinition(string prefix, string tier)
    : Resource, ITwitcherSharp<TwitchCheermoteDefinition>
{
    public const string ThemeDark = "dark";
    public const string ThemeLight = "light";

    public const string TypeAnimated = "animated_format";
    public const string TypeStatic = "static_format";

    public const string Scale1 = "1";
    public const string Scale2 = "2";
    public const string Scale3 = "3";
    public const string Scale4 = "4";

    // ReSharper disable once InconsistentNaming
    public const string Scale1_5 = "1.5";

    private static readonly Dictionary<float, string> ScaleMap = new()
    {
        { 1f, Scale1 },
        { 1.5f, Scale1_5 },
        { 2f, Scale2 },
        { 3f, Scale3 },
        { 4f, Scale4 },
    };

    public string Prefix { get; set; } = prefix;
    public string Tier { get; set; } = tier;
    public string Theme { get; set; }
    public string Type { get; set; }

    public string Scale
    {
        get;
        set => field = SetScale(value);
    }

    private string SetScale(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Scale cannot be null or empty", nameof(value));
        }

        if (!ScaleMap.ContainsKey(float.Parse(value)))
        {
            throw new ArgumentException("Invalid scale value", nameof(value));
        }

        return value;
    }

    public TwitchCheermoteDefinition SetThemeDark()
    {
        Theme = ThemeDark;
        return this;
    }

    public TwitchCheermoteDefinition SetThemeLight()
    {
        Theme = ThemeLight;
        return this;
    }

    public TwitchCheermoteDefinition SetTypeAnimated()
    {
        Type = TypeAnimated;
        return this;
    }

    public TwitchCheermoteDefinition SetTypeStatic()
    {
        Type = TypeStatic;
        return this;
    }

    public TwitchCheermoteDefinition SetScale1()
    {
        Scale = Scale1;
        return this;
    }

    public TwitchCheermoteDefinition SetScale2()
    {
        Scale = Scale2;
        return this;
    }

    public TwitchCheermoteDefinition SetScale3()
    {
        Scale = Scale3;
        return this;
    }

    public TwitchCheermoteDefinition SetScale4()
    {
        Scale = Scale4;
        return this;
    }

    public TwitchCheermoteDefinition SetScale1_5()
    {
        Scale = Scale1_5;
        return this;
    }

    public override string ToString()
    {
        return $"Cheer[{Prefix}/{Tier}]";
    }

    public string GetId()
    {
        return $"/{Prefix}/{Tier}/{Theme}/{Type}/{Scale}";
    }

    public static TwitchCheermoteDefinition FromObject(GodotObject data)
    {
        return new TwitchCheermoteDefinition(data.Get("prefix").AsString(), data.Get("tier").AsString())
        {
            Theme = data.Get("theme").AsString(),
            Type = data.Get("type").AsString(),
            Scale = data.Get("scale").AsString()
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_definition.gd");
        var request = script.New().AsGodotObject();
        request.Set("prefix", Prefix);
        request.Set("tier", Tier);
        request.Set("theme", Theme);
        request.Set("type", Type);
        request.Set("scale", Scale);
        return request;
    }
}