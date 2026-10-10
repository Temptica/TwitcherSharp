using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermote : RefCounted, ITwitcherSharp<TwitchCheermote>
{
    private Variant _data;
    public string Prefix { get; set; } = null!;
    public TwitchResponseTiers[] Tiers { get => field ??= _data.GetArray<TwitchResponseTiers>("tiers")!; set; } = null!;
    public string Type { get; set; } = null!;
    public int Order { get; set; }
    public string LastUpdated { get; set; } = null!;
    public bool IsCharitable { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermote object.
    /// </summary> 
    public static TwitchCheermote? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermote
        {
            Prefix = data.ReadAsString("prefix"),
            Type = data.ReadAsString("type"),
            Order = data.ReadAsInt32("order"),
            LastUpdated = data.ReadAsString("last_updated"),
            IsCharitable = data.ReadAsBool("is_charitable"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_cheermote.gd");
        if(Prefix != null) request.SetValue("prefix", Prefix);
        if(Tiers != null) request.SetArray("tiers", Tiers);
        if(Type != null) request.SetValue("type", Type);
        request.SetValue("order", Order);
        if(LastUpdated != null) request.SetValue("last_updated", LastUpdated);
        request.SetValue("is_charitable", IsCharitable);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list of tier levels that the Cheermote supports. Each tier identifies the range of Bits that you can cheer at that tier level and an image that graphically identifies the tier level. 
    /// </summary>
    public partial class TwitchResponseTiers : RefCounted, ITwitcherSharp<TwitchResponseTiers>
    {
        private Variant _data;
        public int MinBits { get; set; }
        public string Id { get; set; } = null!;
        public string Color { get; set; } = null!;
        public TwitchCheermoteImages Images { get => field ??= _data.Get<TwitchCheermoteImages>("images")!; set; } = null!;
        public bool CanCheer { get; set; }
        public bool ShowInBitsCard { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseTiers object.
        /// </summary> 
        public static TwitchResponseTiers? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseTiers
            {
                MinBits = data.ReadAsInt32("min_bits"),
                Id = data.ReadAsString("id"),
                Color = data.ReadAsString("color"),
                CanCheer = data.ReadAsBool("can_cheer"),
                ShowInBitsCard = data.ReadAsBool("show_in_bits_card"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_cheermote.gd", "Tiers");
            request.SetValue("min_bits", MinBits);
            if(Id != null) request.SetValue("id", Id);
            if(Color != null) request.SetValue("color", Color);
            if(Images != null) request.SetObject("images", Images);
            request.SetValue("can_cheer", CanCheer);
            request.SetValue("show_in_bits_card", ShowInBitsCard);
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
