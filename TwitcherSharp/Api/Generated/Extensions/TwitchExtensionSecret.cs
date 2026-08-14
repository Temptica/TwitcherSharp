using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionSecret : RefCounted, ITwitcherSharp<TwitchExtensionSecret>
{
    private GodotObject? _data;
    public int FormatVersion { get; set; }
    public TwitchSecrets[]? Secrets { get => field ??= _data?.GetArray<TwitchSecrets>("secrets"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionSecret object.
    /// </summary> 
    public static TwitchExtensionSecret? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionSecret
        {
            FormatVersion = data.Get("format_version").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_secret.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("format_version", FormatVersion);
        if(Secrets != null) request.Set("secrets", Secrets.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// The list of secrets. 
    /// </summary>
    public partial class TwitchSecrets : RefCounted, ITwitcherSharp<TwitchSecrets>
    {
        private GodotObject? _data;
        public string? Content { get; set; }
        public string? ActiveAt { get; set; }
        public string? ExpiresAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSecrets object.
        /// </summary> 
        public static TwitchSecrets? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSecrets
            {
                Content = data.Get("content").AsString(),
                ActiveAt = data.Get("active_at").AsString(),
                ExpiresAt = data.Get("expires_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_secret.gd");
            var twitchSecretsClass = script.Get("Secrets").AsGodotObject();
            var request = twitchSecretsClass.Call("new").AsGodotObject();
            if(Content != null) request.Set("content", Content);
            if(ActiveAt != null) request.Set("active_at", ActiveAt);
            if(ExpiresAt != null) request.Set("expires_at", ExpiresAt);
            return request;
        }
    
    }

}
