using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Extensions;

public static class VariantExtension
{
    extension(Variant variant)
    {
        public async Task<T> ToResultAsync<T>(Node context) where T : RefCounted, ITwitcherSharp<T>
        {
            var result = await context.ToSignal(variant.AsGodotObject(), "completed");
            return T.FromObject(result[0].AsGodotObject());
        }

        internal T AsTwitcherObject<T>() where T : RefCounted, ITwitcherSharp<T>
        {
            return T.FromObject(variant.AsGodotObject());
        }
    }
}