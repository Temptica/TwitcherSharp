using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;

public partial class TwitchImageTransformer : Resource, ITwitcherSharp<TwitchImageTransformer>
{
    public Texture2D FallbackTexture { get; set; }

    public bool IsSupportingAnimation => false;
    public bool IsSupported => true;

    public SpriteFrames ConvertImage(string path, byte[] bufferIn, string outputPath)
    {
        if(ResourceLoader.HasCached(outputPath)) return ResourceLoader.Load<SpriteFrames>(outputPath);
        
        var img = new Image();
        var err = img.LoadPngFromBuffer(bufferIn);
        var spriteFrames = new SpriteFrames();
        if (err == Error.Ok)
        {
            var texture = new ImageTexture();
            texture.SetImage(img);
            spriteFrames.AddFrame("default", texture);
            ResourceSaver.Save(spriteFrames, outputPath, ResourceSaver.SaverFlags.Compress);
            spriteFrames.TakeOverPath(path);
            return spriteFrames;
        }
        spriteFrames.AddFrame("default", FallbackTexture);
        GD.Print($"Can't load {outputPath}. Using fallback texture");
        return spriteFrames;
    }

    public static TwitchImageTransformer FromObject(GodotObject data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return new TwitchImageTransformer
        {
            FallbackTexture = data.Get("fallback_texture").As<Texture2D>()
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/media/twitch_image_transformer.gd");
        var data = script.New().AsGodotObject();
        data.Set("fallback_texture", FallbackTexture);

        return data;
    }
}