using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchExtension : Resource, ITwitcherSharp<TwitchExtension>
{
    private GodotObject _data;
	public string AuthorName { get; set; }
	public bool BitsEnabled { get; set; }
	public bool CanInstall { get; set; }
	public string ConfigurationLocation { get; set; }
	public string Description { get; set; }
	public string EulaTosUrl { get; set; }
	public bool HasChatSupport { get; set; }
	public string IconUrl { get; set; }
	public TwitchIconUrls IconUrls { get; set; }
	public string Id { get; set; }
	public string Name { get; set; }
	public string PrivacyPolicyUrl { get; set; }
	public bool RequestIdentityLink { get; set; }
	public string[] ScreenshotUrls { get; set; }
	public string State { get; set; }
	public string SubscriptionsSupportLevel { get; set; }
	public string Summary { get; set; }
	public string SupportEmail { get; set; }
	public string Version { get; set; }
	public string ViewerSummary { get; set; }
	public TwitchViews Views { get; set; }
	public string[] AllowlistedConfigUrls { get; set; }
	public string[] AllowlistedPanelUrls { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchExtension object.
    /// </summary> 
    public static TwitchExtension FromObject(GodotObject data)
    {
		return new TwitchExtension
		{
			AuthorName = data.Get("author_name").AsString(),
			BitsEnabled = data.Get("bits_enabled").AsBool(),
			CanInstall = data.Get("can_install").AsBool(),
			ConfigurationLocation = data.Get("configuration_location").AsString(),
			Description = data.Get("description").AsString(),
			EulaTosUrl = data.Get("eula_tos_url").AsString(),
			HasChatSupport = data.Get("has_chat_support").AsBool(),
			IconUrl = data.Get("icon_url").AsString(),
			IconUrls = data.Get("icon_urls").As<TwitchIconUrls>(),
			Id = data.Get("id").AsString(),
			Name = data.Get("name").AsString(),
			PrivacyPolicyUrl = data.Get("privacy_policy_url").AsString(),
			RequestIdentityLink = data.Get("request_identity_link").AsBool(),
			ScreenshotUrls = data.Get("screenshot_urls").AsStringArray(),
			State = data.Get("state").AsString(),
			SubscriptionsSupportLevel = data.Get("subscriptions_support_level").AsString(),
			Summary = data.Get("summary").AsString(),
			SupportEmail = data.Get("support_email").AsString(),
			Version = data.Get("version").AsString(),
			ViewerSummary = data.Get("viewer_summary").AsString(),
			Views = data.Get("views").As<TwitchViews>(),
			AllowlistedConfigUrls = data.Get("allowlisted_config_urls").AsStringArray(),
			AllowlistedPanelUrls = data.Get("allowlisted_panel_urls").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("author_name", AuthorName);
		request.Set("bits_enabled", BitsEnabled);
		request.Set("can_install", CanInstall);
		request.Set("configuration_location", ConfigurationLocation);
		request.Set("description", Description);
		request.Set("eula_tos_url", EulaTosUrl);
		request.Set("has_chat_support", HasChatSupport);
		request.Set("icon_url", IconUrl);
		request.Set("icon_urls", IconUrls);
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("privacy_policy_url", PrivacyPolicyUrl);
		request.Set("request_identity_link", RequestIdentityLink);
		request.Set("screenshot_urls", ScreenshotUrls);
		request.Set("state", State);
		request.Set("subscriptions_support_level", SubscriptionsSupportLevel);
		request.Set("summary", Summary);
		request.Set("support_email", SupportEmail);
		request.Set("version", Version);
		request.Set("viewer_summary", ViewerSummary);
		request.Set("views", Views);
		request.Set("allowlisted_config_urls", AllowlistedConfigUrls);
		request.Set("allowlisted_panel_urls", AllowlistedPanelUrls);
		return request;
	}
}
