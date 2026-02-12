namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeStrings
{
    public const string EventSubNameSpaces = """
                                             using Godot;
                                             using Godot.Collections;
                                             using TwitcherSharp.Interfaces;

                                             namespace TwitcherSharp.EventSub.Generated;
                                             """;

    /// <summary>
    /// Param: {{ClassName}}
    /// </summary>
    public const string EventSubHeader =
        "public partial class {{ClassName}} : Resource, ITwitcherSharpEventSub<{{ClassName}}>";

    public const string FieldDescription = """
                                           /// <summary> 
                                           /// {{Description}}
                                           /// </summary>
                                           """;

    public const string FromDictionary = """
                                         public static {{ClassName}} FromData(Dictionary data)
                                         {
                                             return new {{ClassName}}
                                             {
                                         """;
}