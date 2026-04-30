using System.Collections.Generic;
using Entities;

namespace TwitcherSharp.SourceGenerator.Sample;

// This code will not compile until you build the project with the Source Generators

public class Examples
{
    // Create generated entities, based on DDD.UbiquitousLanguageRegistry.txt
    public object[] CreateEntities()
    {
        return new object[]
        {
            new Customer(),
            new Employee(),
            new Product(),
            new Shop(),
            new Stock()
        };
    }

    // Execute generated method Report
    public IEnumerable<string> CreateEntityReport(SampleEntity entity)
    {
        return entity.Report();
    }
}