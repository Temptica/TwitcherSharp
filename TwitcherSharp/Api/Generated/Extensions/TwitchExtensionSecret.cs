using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionSecret : RefCounted, ITwitcherSharp<TwitchExtensionSecret>
{
    private Variant _data;
    public int FormatVersion { get; set; }
    public TwitchSecrets[] Secrets { get => field ??= _data.GetArray<TwitchSecrets>("secrets")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionSecret object.
    /// </summary> 
    public static TwitchExtensionSecret? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionSecret
        {
            FormatVersion = data.ReadAsInt32("format_version"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_secret.gd");
        request.SetValue("format_version", FormatVersion);
        if(Secrets != null) request.SetArray("secrets", Secrets);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The list of secrets. 
    /// </summary>
    public partial class TwitchSecrets : RefCounted, ITwitcherSharp<TwitchSecrets>
    {
        private Variant _data;
        public string Content { get; set; } = null!;
        public string ActiveAt { get; set; } = null!;
        public string ExpiresAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSecrets object.
        /// </summary> 
        public static TwitchSecrets? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSecrets
            {
                Content = data.ReadAsString("content"),
                ActiveAt = data.ReadAsString("active_at"),
                ExpiresAt = data.ReadAsString("expires_at"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension_secret.gd", "Secrets");
            if(Content != null) request.SetValue("content", Content);
            if(ActiveAt != null) request.SetValue("active_at", ActiveAt);
            if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
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
