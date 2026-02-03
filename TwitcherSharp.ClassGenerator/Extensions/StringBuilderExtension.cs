using System.Text;

namespace ClassGenerator.Extensions;

public static class StringBuilderExtension
{
    extension(StringBuilder sb)
    {
        public void AppendIndented(string code, int level = 0)
        {
            var tabs = "";
            for (var i = 0; i < level; i++)
            {
                tabs += "\t";
            }
            sb.Append(tabs + code);
        }
        
        public void AppendIndentedLine(string code, int level = 0)
        {
            var tabs = "";
            for (var i = 0; i < level; i++)
            {
                tabs += "\t";
            }
            sb.AppendLine(tabs + code);
        }
    }
}