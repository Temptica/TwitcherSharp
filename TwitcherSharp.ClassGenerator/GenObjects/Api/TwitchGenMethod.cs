namespace ClassGenerator.GenObjects.Api;

public class TwitchGenMethod
{
    public string HttpVerb { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Path { get; set; }
    public string DocUrl { get; set; }
    public List<TwitchGenParameter> Parameters { get; set; } = [];
    public List<TwitchGenParameter> RequiredParameters => Parameters.Where(p => p.Required).ToList();
    public List<TwitchGenParameter> OptionalParameters => Parameters.Where(p => !p.Required).ToList();
    public string BodyType { get; set; }
    public string ResultType { get; set; }
    public string ContentType { get; set; }
    public bool ContainsOptional { get; private set; }
    public bool ContainsBody => !string.IsNullOrEmpty(BodyType);

    public void AddParameter(TwitchGenParameter parameter)
    {
        Parameters.Add(parameter);
        ContainsOptional = ContainsOptional || !parameter.Required;
    }

    public TwitchGenParameter GetParameterByName(string name) => Parameters.FirstOrDefault(p => p.Name == name);

    public string GetOptionalClassName() => "Twitch" + Name + "Opt";

    public string GetOptionalType() => "#/components/schemas/" + GetOptionalClassName();

    public TwitchGenComponent GetOptionalComponent()
    {
        var description = $"All optional parameters for TwitchAPI.{Name}";
        var component = new TwitchGenComponent(GetOptionalClassName(), GetOptionalType(), description);

        foreach (var parameter in OptionalParameters)
        {
            component.AddField(new TwitchGenField
            {
                Name = parameter.Name,
                Type = parameter.Type,
                Description = parameter.Description,
                IsRequired = false,
                IsArray = parameter.IsArray
            });
        }

        return component;
    }
}