using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
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
            HttpRequest = data.Read("http_request", static v => v.As<HttpRequest>()),
            Path = data.Read("path", static v => v.AsString()),
            Method = data.Read("method", static v => v.AsInt32()),
            Headers = data.Read("headers", static v => v.As<Dictionary>()),
            Body = data.Read("body", static v => v.AsString()),
            Retry = data.Read("retry", static v => v.AsInt32())
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