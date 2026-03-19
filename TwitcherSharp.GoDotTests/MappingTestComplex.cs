using System.Collections.Generic;
using Chickensoft.GoDotTest;
using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.GoDotTests;

public class MappingTestComplex(Node testScene) : TestClass(testScene)
{
    public List<ITwitcherSharp> TwitcherSharpObjects { get; set; }
    
    [Test]
    public void TestParsing()
    {
        
    }
}