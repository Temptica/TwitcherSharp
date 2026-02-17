using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

/// <summary> 
///  
/// </summary>
public partial class TwitchGetCheermotesResponse : Resource, ITwitcherSharp<TwitchGetCheermotesResponse>
{
    private GodotObject _data;
	public TwitchCheermote[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCheermotesResponse object.
    /// </summary> 
    public static TwitchGetCheermotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetCheermotesResponse
		{
			Data = dataArray.Select(TwitchCheermote.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_cheermotes.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchCheermote : Resource, ITwitcherSharp<TwitchCheermote>
	{
	    private GodotObject _data;
		public string Prefix { get; set; }
		public TwitchTiers[] Tiers { get; set; }
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
			var tiersArray = data.Get("tiers").AsGodotArray<GodotObject>();
			return new TwitchCheermote
			{
				Prefix = data.Get("prefix").AsString(),
				Tiers = tiersArray.Select(TwitchTiers.FromObject).ToArray(),
				Type = data.Get("type").AsString(),
				Order = data.Get("order").AsInt32(),
				LastUpdated = data.Get("last_updated").AsString(),
				IsCharitable = data.Get("is_charitable").AsBool(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("prefix", Prefix);
			request.Set("tiers", Tiers);
			request.Set("type", Type);
			request.Set("order", Order);
			request.Set("last_updated", LastUpdated);
			request.Set("is_charitable", IsCharitable);
			return request;
		}
		
		/// <summary> 
		/// A list of tier levels that the Cheermote supports. Each tier identifies the range of Bits that you can cheer at that tier level and an image that graphically identifies the tier level. 
		/// </summary>
		public partial class TwitchTiers : Resource, ITwitcherSharp<TwitchTiers>
		{
		    private GodotObject _data;
			public int MinBits { get; set; }
			public string Id { get; set; }
			public string Color { get; set; }
			public TwitchImages Images { get; set; }
			public bool CanCheer { get; set; }
			public bool ShowInBitsCard { get; set; }
		
		    /// <summary> 
		    /// Transforms the godot data into a TwitchTiers object.
		    /// </summary> 
		    public static TwitchTiers FromObject(GodotObject data)
		    {
		        if(data == null) return null;
				return new TwitchTiers
				{
					MinBits = data.Get("min_bits").AsInt32(),
					Id = data.Get("id").AsString(),
					Color = data.Get("color").AsString(),
					Images = data.Get("images").As<TwitchImages>(),
					CanCheer = data.Get("can_cheer").AsBool(),
					ShowInBitsCard = data.Get("show_in_bits_card").AsBool(),
				};
			}
		
			public GodotObject ToGodotObject()
			{
				var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_tiers.gd");
				var request = script.Call("new").AsGodotObject();
				request.Set("min_bits", MinBits);
				request.Set("id", Id);
				request.Set("color", Color);
				request.Set("images", Images);
				request.Set("can_cheer", CanCheer);
				request.Set("show_in_bits_card", ShowInBitsCard);
				return request;
			}
			
			/// <summary> 
			///  
			/// </summary>
			public partial class TwitchImages : Resource, ITwitcherSharp<TwitchImages>
			{
			    private GodotObject _data;
				public TwitchLight Light { get; set; }
				public TwitchDark Dark { get; set; }
			
			    /// <summary> 
			    /// Transforms the godot data into a TwitchImages object.
			    /// </summary> 
			    public static TwitchImages FromObject(GodotObject data)
			    {
			        if(data == null) return null;
					return new TwitchImages
					{
						Light = data.Get("light").As<TwitchLight>(),
						Dark = data.Get("dark").As<TwitchDark>(),
					};
				}
			
				public GodotObject ToGodotObject()
				{
					var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_images.gd");
					var request = script.Call("new").AsGodotObject();
					if(Light != null) request.Set("light", Light);
					if(Dark != null) request.Set("dark", Dark);
					return request;
				}
				
				/// <summary> 
				///  
				/// </summary>
				public partial class TwitchLight : Resource, ITwitcherSharp<TwitchLight>
				{
				    private GodotObject _data;
					public TwitchAnimated Animated { get; set; }
					public TwitchStatic Static { get; set; }
				
				    /// <summary> 
				    /// Transforms the godot data into a TwitchLight object.
				    /// </summary> 
				    public static TwitchLight FromObject(GodotObject data)
				    {
				        if(data == null) return null;
						return new TwitchLight
						{
							Animated = data.Get("animated").As<TwitchAnimated>(),
							Static = data.Get("static").As<TwitchStatic>(),
						};
					}
				
					public GodotObject ToGodotObject()
					{
						var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_light.gd");
						var request = script.Call("new").AsGodotObject();
						if(Animated != null) request.Set("animated", Animated);
						if(Static != null) request.Set("static", Static);
						return request;
					}
					
					/// <summary> 
					///  
					/// </summary>
					public partial class TwitchAnimated : Resource, ITwitcherSharp<TwitchAnimated>
					{
					    private GodotObject _data;
						public string _1 { get; set; }
						public string _2 { get; set; }
						public string _3 { get; set; }
						public string _4 { get; set; }
						public string _1_5 { get; set; }
					
					    /// <summary> 
					    /// Transforms the godot data into a TwitchAnimated object.
					    /// </summary> 
					    public static TwitchAnimated FromObject(GodotObject data)
					    {
					        if(data == null) return null;
							return new TwitchAnimated
							{
								_1 = data.Get("__1").AsString(),
								_2 = data.Get("__2").AsString(),
								_3 = data.Get("__3").AsString(),
								_4 = data.Get("__4").AsString(),
								_1_5 = data.Get("__1___5").AsString(),
							};
						}
					
						public GodotObject ToGodotObject()
						{
							var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_animated.gd");
							var request = script.Call("new").AsGodotObject();
							if(_1 != null) request.Set("__1", _1);
							if(_2 != null) request.Set("__2", _2);
							if(_3 != null) request.Set("__3", _3);
							if(_4 != null) request.Set("__4", _4);
							if(_1_5 != null) request.Set("__1___5", _1_5);
							return request;
						}
					
					}
					
					/// <summary> 
					///  
					/// </summary>
					public partial class TwitchStatic : Resource, ITwitcherSharp<TwitchStatic>
					{
					    private GodotObject _data;
						public string _1 { get; set; }
						public string _2 { get; set; }
						public string _3 { get; set; }
						public string _4 { get; set; }
						public string _1_5 { get; set; }
					
					    /// <summary> 
					    /// Transforms the godot data into a TwitchStatic object.
					    /// </summary> 
					    public static TwitchStatic FromObject(GodotObject data)
					    {
					        if(data == null) return null;
							return new TwitchStatic
							{
								_1 = data.Get("__1").AsString(),
								_2 = data.Get("__2").AsString(),
								_3 = data.Get("__3").AsString(),
								_4 = data.Get("__4").AsString(),
								_1_5 = data.Get("__1___5").AsString(),
							};
						}
					
						public GodotObject ToGodotObject()
						{
							var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_static.gd");
							var request = script.Call("new").AsGodotObject();
							if(_1 != null) request.Set("__1", _1);
							if(_2 != null) request.Set("__2", _2);
							if(_3 != null) request.Set("__3", _3);
							if(_4 != null) request.Set("__4", _4);
							if(_1_5 != null) request.Set("__1___5", _1_5);
							return request;
						}
					
					}
				
				}
				
				/// <summary> 
				///  
				/// </summary>
				public partial class TwitchDark : Resource, ITwitcherSharp<TwitchDark>
				{
				    private GodotObject _data;
					public TwitchAnimated Animated { get; set; }
					public TwitchStatic Static { get; set; }
				
				    /// <summary> 
				    /// Transforms the godot data into a TwitchDark object.
				    /// </summary> 
				    public static TwitchDark FromObject(GodotObject data)
				    {
				        if(data == null) return null;
						return new TwitchDark
						{
							Animated = data.Get("animated").As<TwitchAnimated>(),
							Static = data.Get("static").As<TwitchStatic>(),
						};
					}
				
					public GodotObject ToGodotObject()
					{
						var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_dark.gd");
						var request = script.Call("new").AsGodotObject();
						if(Animated != null) request.Set("animated", Animated);
						if(Static != null) request.Set("static", Static);
						return request;
					}
					
					/// <summary> 
					///  
					/// </summary>
					public partial class TwitchAnimated : Resource, ITwitcherSharp<TwitchAnimated>
					{
					    private GodotObject _data;
						public string _1 { get; set; }
						public string _2 { get; set; }
						public string _3 { get; set; }
						public string _4 { get; set; }
						public string _1_5 { get; set; }
					
					    /// <summary> 
					    /// Transforms the godot data into a TwitchAnimated object.
					    /// </summary> 
					    public static TwitchAnimated FromObject(GodotObject data)
					    {
					        if(data == null) return null;
							return new TwitchAnimated
							{
								_1 = data.Get("__1").AsString(),
								_2 = data.Get("__2").AsString(),
								_3 = data.Get("__3").AsString(),
								_4 = data.Get("__4").AsString(),
								_1_5 = data.Get("__1___5").AsString(),
							};
						}
					
						public GodotObject ToGodotObject()
						{
							var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_animated.gd");
							var request = script.Call("new").AsGodotObject();
							if(_1 != null) request.Set("__1", _1);
							if(_2 != null) request.Set("__2", _2);
							if(_3 != null) request.Set("__3", _3);
							if(_4 != null) request.Set("__4", _4);
							if(_1_5 != null) request.Set("__1___5", _1_5);
							return request;
						}
					
					}
					
					/// <summary> 
					///  
					/// </summary>
					public partial class TwitchStatic : Resource, ITwitcherSharp<TwitchStatic>
					{
					    private GodotObject _data;
						public string _1 { get; set; }
						public string _2 { get; set; }
						public string _3 { get; set; }
						public string _4 { get; set; }
						public string _1_5 { get; set; }
					
					    /// <summary> 
					    /// Transforms the godot data into a TwitchStatic object.
					    /// </summary> 
					    public static TwitchStatic FromObject(GodotObject data)
					    {
					        if(data == null) return null;
							return new TwitchStatic
							{
								_1 = data.Get("__1").AsString(),
								_2 = data.Get("__2").AsString(),
								_3 = data.Get("__3").AsString(),
								_4 = data.Get("__4").AsString(),
								_1_5 = data.Get("__1___5").AsString(),
							};
						}
					
						public GodotObject ToGodotObject()
						{
							var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_static.gd");
							var request = script.Call("new").AsGodotObject();
							if(_1 != null) request.Set("__1", _1);
							if(_2 != null) request.Set("__2", _2);
							if(_3 != null) request.Set("__3", _3);
							if(_4 != null) request.Set("__4", _4);
							if(_1_5 != null) request.Set("__1___5", _1_5);
							return request;
						}
					
					}
				
				}
			
			}
		
		}
	
	}

}
