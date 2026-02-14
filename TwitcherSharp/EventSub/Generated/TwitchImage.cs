using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchImage : Resource, ITwitcherSharpEventSub<TwitchImage>
{

	/// <summary> 
	/// URL for the image at 1x size.
	/// </summary>
	public string Url1x { get; set; }

	/// <summary> 
	/// URL for the image at 2x size.
	/// </summary>
	public string Url2x { get; set; }

	/// <summary> 
	/// URL for the image at 4x size.
	/// </summary>
	public string Url4x { get; set; }

	public static TwitchImage FromData(Dictionary data)
	{
	    return new TwitchImage
	    {
			Url1x = data["url_1x"].AsString(),
			Url2x = data["url_2x"].AsString(),
			Url4x = data["url_4x"].AsString(),
		};
	}

}
