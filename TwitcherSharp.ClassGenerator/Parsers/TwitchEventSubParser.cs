using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.EventSub;
using HtmlAgilityPack;

namespace ClassGenerator.Parsers;

public class TwitchEventSubParser
{
    //"https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/";
    private const string Path = "EventSub.html";

    public List<TwitchEventSubGenComponent> Components { get; } = [];
    public List<TwitchEventSubGenComponent> SubComponents { get; } = [];
    public List<TwitchEventSubGenComponent> ConditionComponents { get; } = [];

    public async Task ParseEventSub()
    {
        await using var stream = Path.StartsWith("https://")
            ? await new HttpClient().GetStreamAsync(Path)
            : File.OpenRead(Path);
        var html = await new StreamReader(stream).ReadToEndAsync();

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        ParseSubComponents(doc);

        foreach (var component in SubComponents)
        {
            foreach (var field in component.Fields.Values.Where(f =>
                         f.IsTyped && SubComponents.All(c => c != f.TypedComponent)))
            {
                var subComponent = SubComponents.First(c => c.ClassName == field.TypedComponent.ClassName);

                component.SubComponents.Remove(field.TypedComponent.ClassName);
                component.AddSubComponent(subComponent);
                field.TypedComponent = subComponent;
                // AddSubComponent above replaces this field in component.Fields with a fresh, non-array one
                // (it doesn't know this field already existed) — put the original back now that it points
                // at the correctly-populated shared component, so IsArray/IsRequired survive the re-link.
                component.Fields[field.Name] = field;
                subComponent.IsShared = true;
            }
        }

        ParseComponents(doc);
        ParseConditions(doc);
        ReconcileArrayCardinality();

        Console.WriteLine($"{Components.Count} eventsub components parsed");
    }

    /// <summary>
    /// Twitch's own docs are inconsistent about whether a shared object (e.g. "top_contributions") is
    /// documented as an array on every page that references it — sometimes the type column literally says
    /// "object[]", sometimes it's just a bare link with no array wording anywhere nearby, even though the
    /// field is the same schema object every time. Since <see cref="TwitchEventSubGenField.IsArray"/> is
    /// parsed per field-occurrence from local text, that inconsistency otherwise survives into the C# model.
    /// This reconciles it: if ANY occurrence of a shared component was recognized as an array, every
    /// occurrence of that same component is treated as one.
    /// </summary>
    private void ReconcileArrayCardinality()
    {
        var allComponents = EnumerateAllComponents().ToList();

        var arrayComponentNames = allComponents
            .SelectMany(c => c.Fields.Values)
            .Where(f => f.IsArray && f.TypedComponent != null)
            .Select(f => f.TypedComponent.ClassName)
            .ToHashSet();

        foreach (var field in allComponents.SelectMany(c => c.Fields.Values))
        {
            if (field.IsArray || field.TypedComponent == null) continue;
            if (!arrayComponentNames.Contains(field.TypedComponent.ClassName)) continue;

            field.IsArray = true;
            if (!field.Type.EndsWith("[]")) field.Type += "[]";
        }
    }

    private IEnumerable<TwitchEventSubGenComponent> EnumerateAllComponents()
    {
        IEnumerable<TwitchEventSubGenComponent> Walk(TwitchEventSubGenComponent component)
        {
            yield return component;
            foreach (var child in component.SubComponents.Values)
            foreach (var descendant in Walk(child))
                yield return descendant;
        }

        return Components.Concat(ConditionComponents).Concat(SubComponents).SelectMany(Walk);
    }

    private void ParseSubComponents(HtmlDocument doc)
    {
        var objectsNode = doc.DocumentNode.SelectSingleNode("//h1[@id='objects']");
        var lastNode = objectsNode;
        while (lastNode.GetNextElementSibling() != null)
        {
            var h2Node = lastNode.GetNextElementSibling();
            switch (h2Node.Id)
            {
                case "conditions" or "events" or "subscription":
                {
                    var nextNode = h2Node.GetNextElementSibling();
                    while (nextNode?.Name != "h2")
                    {
                        if (nextNode is null) return;

                        nextNode = nextNode.GetNextElementSibling();
                    }

                    lastNode = nextNode.PreviousSibling;
                    continue;
                }
                case "transport":
                {
                    var transport = new TwitchEventSubGenComponent("Transport")
                    {
                        Description = h2Node.GetNextElementSibling().InnerText.Trim(),
                        IsShared = true
                    };

                    var transportTable = h2Node.GetNextElementSibling().GetNextElementSibling();
                    ParseTable(transportTable, transport);
                    SubComponents.Add(transport);
                    return;
                }
            }

            var subComponent = new TwitchEventSubGenComponent(h2Node.InnerText.Trim())
            {
                IsShared = true
            };

            var p = h2Node.GetNextElementSibling();
            HtmlNode table;

            if (p.Name == "p")
            {
                subComponent.Description = p.InnerText.Trim();
                table = p.GetNextElementSibling();
            }
            else
            {
                table = p;
            }

            ParseTable(table, subComponent);

            SubComponents.Add(subComponent);

            lastNode = table;
        }
    }

    private void ParseComponents(HtmlDocument doc)
    {
        var events = doc.DocumentNode.SelectSingleNode("//h2[@id='events']");
        var startPos = events.Line;
        var nextH2Node = doc.DocumentNode.SelectNodes("//h2").FirstOrDefault(n => n.Line > startPos) ??
                         doc.DocumentNode.LastChild;

        var lastNode = events;
        while (lastNode.GetNextElementSibling() != nextH2Node)
        {
            var h3Node = lastNode.GetNextElementSibling();

            var eventSubComponent = new TwitchEventSubGenComponent(h3Node.InnerText.Trim());

            var blockQuote = h3Node.GetNextElementSibling();
            HtmlNode table;

            if (blockQuote.Name is "blockquote" or "p")
            {
                eventSubComponent.Description = blockQuote.InnerText.Trim();
                table = blockQuote.GetNextElementSibling();
            }
            else
            {
                table = blockQuote;
            }

            if (table.Name != "table") break;

            //parse table
            ParseTable(table, eventSubComponent);
            Components.Add(eventSubComponent);

            var nextSibling = table.GetNextElementSibling();
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse // can be null!!
            if (nextSibling == null)
            {
                break;
            }

            if (nextSibling.Name == "p" && nextSibling.InnerText.Contains("Object"))
                //To battle the stupidity of twitch (such as Drop Entitlement Grant Event)
            {
                table = nextSibling.GetNextElementSibling();
                var dataComponent = eventSubComponent.SubComponents.FirstOrDefault(s => s.Key == "TwitchData");
                if (dataComponent.Value != null) ParseTable(table, dataComponent.Value);
            }

            lastNode = table;
        }
    }

    private void ParseConditions(HtmlDocument doc)
    {
        var condition = doc.DocumentNode.SelectSingleNode("//h2[@id='conditions']");
        var startPos = condition.Line;
        var nextH2Node = doc.DocumentNode.SelectNodes("//h2").FirstOrDefault(n => n.Line > startPos) ??
                         doc.DocumentNode.LastChild;

        var lastNode = condition;
        while (lastNode.GetNextElementSibling() != nextH2Node)
        {
            var h3Node = lastNode.GetNextElementSibling();
            var conditionComponent = new TwitchEventSubGenComponent(h3Node.InnerText.Trim());
            var table = h3Node.GetNextElementSibling();
            ParseTable(table, conditionComponent, true);
            ConditionComponents.Add(conditionComponent);
            lastNode = table;
        }
    }

    private void ParseTable(HtmlNode table, TwitchEventSubGenComponent eventSubComponent, bool isCondition = false)
    {
        var rows = table.ChildNodes
            .First(n => n.Name == "tbody")
            .ChildNodes
            .Where(n => n.Name == "tr")
            .ToList();

        var currentParent = eventSubComponent;
        var parentWhiteSpaces = -1;
        foreach (var row in rows)
        {
            var whiteSpaces = row.GetFirstElementChild().GetDirectInnerText().TakeWhile(char.IsWhiteSpace).Count();

            // example: current parent has 1 whitespace. You have 1 whitespace. This means you're a sibling, not a child.
            // so parent goes one up and whitespaces go one up
            if (whiteSpaces > 0) whiteSpaces /= 3;

            if (whiteSpaces == parentWhiteSpaces && currentParent.Fields.Count == 0)
            {
                //Stupid twitch, make dictionary instead...
                var dictionaryFieldName = currentParent.ClassName.Remove("Twitch");
                currentParent.Parent.Fields.Remove(dictionaryFieldName);
                currentParent.Parent.AddField(new TwitchEventSubGenField(dictionaryFieldName, currentParent.Description, "Dictionary"));
                currentParent.Parent.SubComponents.Remove(currentParent.ClassName);
                
            }
            
            if (whiteSpaces <= parentWhiteSpaces)
            {
                var parent = currentParent;
                for (var i = 0;
                     i <= parentWhiteSpaces - whiteSpaces && parent != eventSubComponent && parent.Parent != null;
                     i++)
                {
                    parent = parent.Parent;
                }

                currentParent = parent;
                parentWhiteSpaces = whiteSpaces - 1;
            }
            else if (currentParent.IsShared && currentParent.Parent != null)
            {
                //This is an issue, must be a new component instead
                var component = new TwitchEventSubGenComponent(currentParent.ClassName)
                {
                    Description = currentParent.Description
                };
                var parent = currentParent.Parent;
                currentParent.Parent = null;
                parent.AddSubComponent(component);
                
                currentParent = component;
            }

            var isParentV2 = currentParent.ClassName.EndsWith("V2");

            var fieldName = row.SelectSingleNode("td[1]/code").InnerText.Trim();
            var type = row.SelectSingleNode("td[2]").InnerText.Trim();
            var required = isCondition && row.SelectSingleNode("td[3]").InnerText.Trim().Equals("Yes", StringComparison.CurrentCultureIgnoreCase);
            var description = row.SelectSingleNode(isCondition ? "td[4]" : "td[3]").InnerText.Trim();

            if (type.EndsWith("[]") || type == "array" || type == "Array"
                || description.Contains("array", StringComparison.CurrentCultureIgnoreCase)
                || (description.Contains("list ", StringComparison.CurrentCultureIgnoreCase) &&
                    !type.Equals("string", StringComparison.CurrentCultureIgnoreCase) &&
                    !type.Equals("integer", StringComparison.CurrentCultureIgnoreCase) &&
                    !type.Equals("boolean", StringComparison.CurrentCultureIgnoreCase)))
            {
                var arrayField = new TwitchEventSubGenField(fieldName, description, type)
                {
                    IsArray = true,
                };

                if (type.Equals("string[]", StringComparison.CurrentCultureIgnoreCase) ||
                    type.Equals("[]string", StringComparison.CurrentCultureIgnoreCase))
                {
                    currentParent.AddField(arrayField);
                    continue;
                }

                var typedComponent =
                    SubComponents.FirstOrDefault(c => c.ClassName == "Twitch" + type.ToPascalCase())
                    ?? new TwitchEventSubGenComponent(fieldName+ (isParentV2 ? "V2" : ""))
                    {
                        Description = description
                    };

                arrayField.Type = typedComponent.ClassName + "[]";
                arrayField.TypedComponent = typedComponent;
                currentParent.AddField(arrayField);
                currentParent = typedComponent;
                parentWhiteSpaces = whiteSpaces;
            }
            else if (type.Contains("Object", StringComparison.InvariantCultureIgnoreCase))
            {
                var subComponent = SubComponents.FirstOrDefault(c => c.ClassName == "Twitch" + fieldName.ToPascalCase())
                                   ?? new TwitchEventSubGenComponent(fieldName + (isParentV2 ? "V2" : ""))
                                   {
                                       Description = description
                                   };


                if (fieldName.StartsWith("shared_chat_"))
                {
                    var nonSharedField = fieldName[12..];
                    var sharedComponent =
                        eventSubComponent.SubComponents.First(c => c.Key == "Twitch" + nonSharedField.ToPascalCase() + (isParentV2 ? "V2" : ""));
                    eventSubComponent.AddField(new TwitchEventSubGenField(fieldName, description, sharedComponent.Key)
                    {
                        TypedComponent = sharedComponent.Value
                    });

                    continue;
                }

                currentParent.AddSubComponent(subComponent);
                currentParent = subComponent;
                parentWhiteSpaces = whiteSpaces;
            }
            else
            {
                if (currentParent == null) throw new Exception("current parent is null");

                var subComponent = SubComponents.FirstOrDefault(c => c.ClassName == "Twitch" + type.ToPascalCase());
                if (subComponent is null)
                {
                    var field = new TwitchEventSubGenField(fieldName, description, type, required);
                    currentParent.AddField(field);
                }
                else
                {
                    currentParent.AddSubComponent(subComponent);
                }
            }
        }
    }
}

//<h2 id="events">Events</h2>
//<h3 ...> class name </h3>
//<blockQuote> //optional description </blockQuote>
//<table>
//  <thead>
//      <tr>
//          <th>ignore</th>
//          <th>ignore</th>
//      </tr>
//  </thead>
//  <tbody>
//      <tr>
//            (optional, one level is 3 spaces)
//          <td><code>event name</co    de></td>
//          <td>type</td>
//          <td>description</td> -> can have <strong>Optional</strong>
//      </tr>
//      ...//
//  </tbody>
//</table>


//bug in their stuff -> Text is somewhere an object instead of string