using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.OOuch;

public partial class OAuthDeviceCodeResponse : RefCounted, ITwitcherSharp<OAuthDeviceCodeResponse>
{
    public string DeviceCode { get; set; } = null!;
    public int ExpiresIn { get; set; }
    public int Interval { get; set; }
    public string UserCode { get; set; } = null!;
    public string VerificationUri { get; set; } = null!;

    public static OAuthDeviceCodeResponse? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var response = new OAuthDeviceCodeResponse();
        response.DeviceCode = data.ReadAsString("device_code");
        response.ExpiresIn = data.ReadAsInt32("expires_in");
        response.Interval = data.ReadAsInt32("interval");
        response.UserCode = data.ReadAsString("user_code");
        response.VerificationUri = data.ReadAsString("verification_uri");
        return response;
    }

    public GodotObject ToGodotObject()
    {
        var dict = new Godot.Collections.Dictionary<string, Variant>()
        {
            ["device_code"] = DeviceCode,
            ["expires_in"] = ExpiresIn,
            ["interval"] = Interval,
            ["user_code"] = UserCode,
            ["verification_uri"] = VerificationUri
        };

        var response = InteropExtension.NewObject("res://addons/twitcher/lib/oOuch/oauth_device_code_response.gd", dict);
        return response;
    }
}
/*
   ## Response of the inital device code request
   
   var device_code: String;
   var expires_in: int;
   var interval: int;
   var user_code: String;
   var verification_uri: String;
   
   func _init(json: Dictionary):
   	device_code = json["device_code"];
   	expires_in = int(json["expires_in"]);
   	interval = int(json["interval"]);
   	user_code = json["user_code"];
   	verification_uri = json["verification_uri"];*/