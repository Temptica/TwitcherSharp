using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Extensions;

public static class VariantExtension
{
    extension(Variant task)
    {
        public async Task<T> ToResultAsync<T>(Node context) where T : ITwitcherSharp<T>
        {
            var result = await context.ToSignal(task.AsGodotObject(), "completed");
            return T.FromObject(result[0].AsGodotObject());
        }
    }
}