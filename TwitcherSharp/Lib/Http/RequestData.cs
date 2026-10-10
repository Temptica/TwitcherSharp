using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.Http;

public partial class RequestData : RefCounted, ITwitcherSharp<RequestData>
{
    public HttpRequest? HttpRequest { get; set; }
    public string? Path { get; set; }
    public long Method { get; set; }
    public Dictionary Headers { get; set; } = new();
    public string Body { get; set; } = "";
    public long Retry { get; set; }

    public static RequestData? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        return new RequestData
        {
            HttpRequest = data.Read("http_request", static v => v.As<HttpRequest>()),
            Path = data.ReadAsString("path"),
            Method = data.ReadAsInt64("method"),
            Headers = data.Read("headers", static v => v.As<Dictionary>()),
            Body = data.ReadAsString("body"),
            Retry = data.ReadAsInt64("retry")
        };
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/lib/http/buffered_http_client.gd", "RequestData");
        if (HttpRequest != null) request.SetValue("http_request", HttpRequest);
        if (Path != null) request.SetValue("path", Path);
        request.SetValue("method", Method);
        request.SetValue("headers", Headers);
        request.SetValue("body", Body);
        request.SetValue("retry", Retry);
        return request;
    }
}