using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.OOuch;

public partial class OAuthDeviceCodeResponse : RefCounted, ITwitcherSharp<OAuthDeviceCodeResponse>
{
    public string? DeviceCode { get; set; }
    public int ExpiresIn { get; set; }
    public int Interval { get; set; }
    public string? UserCode { get; set; }
    public string? VerificationUri { get; set; }

    public static OAuthDeviceCodeResponse? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var response = new OAuthDeviceCodeResponse();
        response.DeviceCode = data.Get("device_code").AsString();
        response.ExpiresIn = data.Get("expires_in").AsInt32();
        response.Interval = data.Get("interval").AsInt32();
        response.UserCode = data.Get("user_code").AsString();
        response.VerificationUri = data.Get("verification_uri").AsString();
        return response;
    }

    public GodotObject ToGodotObject()
    {
        var dict = new Godot.Collections.Dictionary<string, Variant>()
        {
            ["device_code"] = DeviceCode!,
            ["expires_in"] = ExpiresIn,
            ["interval"] = Interval,
            ["user_code"] = UserCode!,
            ["verification_uri"] = VerificationUri!
        };

        var script = GD.Load<GDScript>("res://addons/twitcher/lib/oOuch/oauth_device_code_response.gd");
        var response = script.New(dict).AsGodotObject();
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