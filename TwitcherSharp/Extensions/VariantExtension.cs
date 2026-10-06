using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Extensions;

public static class VariantExtension
{
    extension(Variant variant)
    {
        internal T AsTwitcherObject<T>() where T : RefCounted, ITwitcherSharp<T>
        {
            return GodotObjectExtension.Map<T>(variant)!;
        }
    }
}