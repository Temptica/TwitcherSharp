using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.Http;

public partial class ResponseData: RefCounted, ITwitcherSharp<ResponseData>
{
    private GodotObject? _data;
    public int Result { get; set; }
    public int ResponseCode { get; set; }
    public RequestData? RequestData { get; set; }
    public byte[]? RawResponseData { get; set; }
    public Dictionary? ResponseHeader { get; set; }
    public bool Error { get; set; }

    public static ResponseData? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        return new ResponseData
        {
            _data = data,
            Result = data.Get("result").AsInt32(),
            ResponseCode = data.Get("response_code").AsInt32(),
            RequestData = RequestData.FromObject(data.Get("request_data").AsGodotObject()),
            RawResponseData = data.Get("raw_response_data").AsByteArray(),
            ResponseHeader = data.Get("response_header").As<Dictionary>(),
            Error = data.Get("error").AsBool()
        };
    }

    public GodotObject ToGodotObject()
    {
        return _data!;
    }
}