using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionSecret : RefCounted, ITwitcherSharp<TwitchExtensionSecret>
{
    private GodotObject _data;
    public int FormatVersion { get; set; }
    public TwitchSecrets[] Secrets { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionSecret object.
    /// </summary> 
    public static TwitchExtensionSecret FromObject(GodotObject data)
    {
        if(data == null) return null;
        var secretsArray = data.Get("secrets").AsGodotArray<GodotObject>();
        return new TwitchExtensionSecret
        {
            FormatVersion = data.Get("format_version").AsInt32(),
            Secrets = secretsArray.Select(TwitchSecrets.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_secret.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("format_version", FormatVersion);
        request.Set("secrets", Secrets);
        return request;
    }
    
    /// <summary> 
    /// The list of secrets. 
    /// </summary>
    public partial class TwitchSecrets : RefCounted, ITwitcherSharp<TwitchSecrets>
    {
        private GodotObject _data;
        public string Content { get; set; }
        public string ActiveAt { get; set; }
        public string ExpiresAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSecrets object.
        /// </summary> 
        public static TwitchSecrets FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSecrets
            {
                Content = data.Get("content").AsString(),
                ActiveAt = data.Get("active_at").AsString(),
                ExpiresAt = data.Get("expires_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_secrets.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("content", Content);
            request.Set("active_at", ActiveAt);
            request.Set("expires_at", ExpiresAt);
            return request;
        }
    
    }

}
