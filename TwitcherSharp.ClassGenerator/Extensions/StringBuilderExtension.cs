using System.Text;

namespace ClassGenerator.Extensions;

public static class StringBuilderExtension
{
    extension(StringBuilder sb)
    {
        public void AppendIndented(string code, int level = 0, string prefix = "")
        {
            var tabs = "";
            for (var i = 0; i < level; i++)
            {
                tabs += "    ";
            }
            
            code = code.Replace("\n", "\n"+tabs + prefix);
            sb.Append(tabs + code);
        }
        public void AppendIndentedLine(string code, int level = 0, string prefix = "")
        {
            var tabs = "";
            for (var i = 0; i < level; i++)
            {
                tabs += "    ";
            }
            
            code = code.Replace("\n", "\n"+tabs + prefix);
            sb.AppendLine(tabs + code);
        }
    }
}