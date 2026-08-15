using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermote : RefCounted, ITwitcherSharp<TwitchCheermote>
{
    private GodotObject _data;
    public string Prefix { get; set; }
    public TwitchResponseTiers[] Tiers { get => field ??= _data?.GetArray<TwitchResponseTiers>("tiers"); set; }
    public string Type { get; set; }
    public int Order { get; set; }
    public string LastUpdated { get; set; }
    public bool IsCharitable { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermote object.
    /// </summary> 
    public static TwitchCheermote FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermote
        {
            Prefix = data.Get("prefix").AsString(),
            Type = data.Get("type").AsString(),
            Order = data.Get("order").AsInt32(),
            LastUpdated = data.Get("last_updated").AsString(),
            IsCharitable = data.Get("is_charitable").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("prefix", Prefix);
        if(Tiers != null) request.SetArray("tiers", Tiers);
        request.Set("type", Type);
        request.Set("order", Order);
        request.Set("last_updated", LastUpdated);
        request.Set("is_charitable", IsCharitable);
        return request;
    }
    
    /// <summary> 
    /// A list of tier levels that the Cheermote supports. Each tier identifies the range of Bits that you can cheer at that tier level and an image that graphically identifies the tier level. 
    /// </summary>
    public partial class TwitchResponseTiers : RefCounted, ITwitcherSharp<TwitchResponseTiers>
    {
        private GodotObject _data;
        public int MinBits { get; set; }
        public string Id { get; set; }
        public string Color { get; set; }
        public TwitchCheermoteImages Images { get => field ??= _data?.Get<TwitchCheermoteImages>("images"); set; }
        public bool CanCheer { get; set; }
        public bool ShowInBitsCard { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseTiers object.
        /// </summary> 
        public static TwitchResponseTiers FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseTiers
            {
                MinBits = data.Get("min_bits").AsInt32(),
                Id = data.Get("id").AsString(),
                Color = data.Get("color").AsString(),
                CanCheer = data.Get("can_cheer").AsBool(),
                ShowInBitsCard = data.Get("show_in_bits_card").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote.gd");
            var twitchResponseTiersClass = script.Get("Tiers").AsGodotObject();
            var request = twitchResponseTiersClass.Call("new").AsGodotObject();
            request.Set("min_bits", MinBits);
            request.Set("id", Id);
            request.Set("color", Color);
            request.Set("images", Images?.ToGodotObject());
            request.Set("can_cheer", CanCheer);
            request.Set("show_in_bits_card", ShowInBitsCard);
            return request;
        }
    
    }

}
