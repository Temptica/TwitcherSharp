using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;

public partial class TwitchImageTransformer : RefCounted, ITwitcherSharp<TwitchImageTransformer>
{
    public Texture2D? FallbackTexture { get; set; }

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

    public static TwitchImageTransformer FromObject(GodotObject? data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return new TwitchImageTransformer
        {
            FallbackTexture = data.Read("fallback_texture", static v => v.As<Texture2D>())
        };
    }

    public GodotObject ToGodotObject()
    {
        var data = InteropExtension.NewObject("res://addons/twitcher/media/twitch_image_transformer.gd");
        if (FallbackTexture != null) data.SetValue("fallback_texture", FallbackTexture);

        return data;
    }
}