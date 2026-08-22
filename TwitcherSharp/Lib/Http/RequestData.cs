using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.Http;

public partial class RequestData : RefCounted, ITwitcherSharp<RequestData>
{
    public HttpRequest? HttpRequest { get; set; }
    public string? Path { get; set; }
    public int Method { get; set; }
    public Dictionary Headers { get; set; } = new();
    public string Body { get; set; } = "";
    public int Retry { get; set; }

    public static RequestData? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        return new RequestData
        {
            HttpRequest = data.Get("http_request").As<HttpRequest>(),
            Path = data.Get("path").AsString(),
            Method = data.Get("method").AsInt32(),
            Headers = data.Get("headers").As<Dictionary>(),
            Body = data.Get("body").AsString(),
            Retry = data.Get("retry").AsInt32()
        };
    }

    public GodotObject ToGodotObject()
    {
		var script = GD.Load<GDScript>("res://addons/twitcher/lib/http/buffered_http_client.gd");
        var requestData = script.Get("ResponseData").AsGodotObject();
        var request = requestData.Call("new").AsGodotObject();
        if (HttpRequest != null) request.Set("http_request", HttpRequest);
        if (Path != null) request.Set("path", Path);
        request.Set("method", Method);
        request.Set("headers", Headers);
        request.Set("body", Body);
        request.Set("retry", Retry);
        return request;
    }
}