namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeStrings
{
    /// <summary>
    /// Param: {{SharedNamespace}} {{NameSpace}}
    /// </summary>
    public const string EventSubNameSpaces = """
                                             using Godot;
                                             using Godot.Collections;
                                             using TwitcherSharp.Extensions;
                                             using TwitcherSharp.Interfaces;
                                             {{SharedNamespace}}

                                             namespace TwitcherSharp.EventSub.Generated.{{NameSpace}};
                                             """;

    /// <summary>
    /// Param: {{ClassName}}
    /// </summary>
    public const string EventSubHeader =
        "public partial class {{ClassName}} : RefCounted, ITwitcherSharpEventSub<{{ClassName}}>";
    
    /// <summary>
    /// Param: {{ClassName}}
    /// </summary>
    public const string ConditionSubHeader =
        "public partial class {{ClassName}}({{requiredFields}}) : RefCounted, ITwitcherSharpCondition<{{ClassName}}>";

    public const string FieldDescription = """
                                           /// <summary> 
                                           /// {{Description}}
                                           /// </summary>
                                           """;

    public const string ComponentFromBody = """
                                                /// <summary> 
                                                /// Transforms the godot data into a {{className}} object.
                                                /// </summary> 
                                                public static {{className}}? FromObject(GodotObject? data)
                                                {
                                                    if(data == null) return null;
                                            """;

    public const string FromDictionary = """
                                         public static {{ClassName}} FromDictionary(Dictionary data)
                                         {
                                             return new {{ClassName}}{{RequiredProperties}}
                                             {
                                         """;
    
    public const string ToDictionary = """
                                         public Dictionary ToDictionary()
                                         {
                                             return new Dictionary
                                             {
                                         """;
}