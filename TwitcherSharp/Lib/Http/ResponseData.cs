using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.Http;

public partial class ResponseData: RefCounted, ITwitcherSharp<ResponseData>
{
    private Variant _data;
    public long Result { get; set; }
    public long ResponseCode { get; set; }
    public RequestData? RequestData { get; set; }
    public byte[]? RawResponseData { get; set; }
    public Dictionary? ResponseHeader { get; set; }
    public bool Error { get; set; }

    public static ResponseData? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        return new ResponseData
        {
            _data = Variant.CreateFrom(data),
            Result = data.ReadAsInt64("result"),
            ResponseCode = data.ReadAsInt64("response_code"),
            RequestData = data.Get<RequestData>("request_data"),
            RawResponseData = data.Read("raw_response_data", static v => v.AsByteArray()),
            ResponseHeader = data.Read("response_header", static v => v.As<Dictionary>()),
            Error = data.ReadAsBool("error")
        };
    }

    /// <summary>
    /// The twitcher response this was mapped from (a response is only ever received, never created in C#).
    /// The caller owns the returned wrapper.
    /// </summary>
    public GodotObject ToGodotObject()
    {
        return _data.AsGodotObject();
    }

    /// <summary> Releases the twitcher object this response was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        // Only when disposed explicitly: when finalized, the Variant is finalized on its own.
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}