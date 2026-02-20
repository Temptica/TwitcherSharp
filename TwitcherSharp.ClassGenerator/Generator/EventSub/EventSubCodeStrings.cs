namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeStrings
{
    /// <summary>
    /// Param: {{SharedNamespace}} {{NameSpace}}
    /// </summary>
    public const string EventSubNameSpaces = """
                                             using Godot;
                                             using Godot.Collections;
                                             using TwitcherSharp.Interfaces;
                                             {{SharedNamespace}}

                                             namespace TwitcherSharp.EventSub.Generated.{{NameSpace}};
                                             """;

    /// <summary>
    /// Param: {{ClassName}}
    /// </summary>
    public const string EventSubHeader =
        "public partial class {{ClassName}} : Resource, ITwitcherSharpEventSub<{{ClassName}}>";
    
    /// <summary>
    /// Param: {{ClassName}}
    /// </summary>
    public const string ConditionSubHeader =
        "public partial class {{ClassName}} : Resource, ITwitcherSharpCondition<{{ClassName}}>";

    public const string FieldDescription = """
                                           /// <summary> 
                                           /// {{Description}}
                                           /// </summary>
                                           """;

    public const string ComponentFromBody = """
                                                /// <summary> 
                                                /// Transforms the godot data into a {{className}} object.
                                                /// </summary> 
                                                public static {{className}} FromObject(GodotObject data)
                                                {
                                                    if(data == null) return null;
                                            """;

    public const string FromDictionary = """
                                         public static {{ClassName}} FromData(Dictionary data)
                                         {
                                             return new {{ClassName}}
                                             {
                                         """;
}