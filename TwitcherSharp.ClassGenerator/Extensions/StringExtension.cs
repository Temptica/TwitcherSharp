namespace ClassGenerator.Extensions;

public static class StringExtension
{
    extension(string type)
    {
        public string ToPascalCase()
        {
            var result = "";
            
            for (var i = 0; i < type.Length; i++)
            {
                var chr = type[i];
                if (i == 0) result += chr.ToString().ToUpper();
                else if (chr is '_' or ' ') result += type[++i].ToString().ToUpper();
                else result += chr.ToString();
            }

            return result;
        }

        public string ToCamelCase()
        {
            var result = "";
            
            for (var i = 0; i < type.Length; i++)
            {
                var chr = type[i];
                if (i == 0) result += chr.ToString().ToLower();
                else if (chr == '_') result += type[++i].ToString().ToUpper();
                else result += chr.ToString();
            }

            return result;
        }

        public string ToSnakeCase()
        {
            var result = "";

            for (var i = 0; i < type.Length; i++)
            {
                var chr = type[i];

                if (char.IsUpper(chr))
                {
                    if (i > 0 && (char.IsLower(type[i - 1]) || char.IsDigit(type[i - 1]) || (i + 1 < type.Length && char.IsLower(type[i + 1]))))
                        result += "_";

                    result += char.ToLowerInvariant(chr);
                }
                else if (char.IsDigit(chr))
                {
                    if (i > 0 && !char.IsDigit(type[i - 1]) && type[i - 1] != '_')
                        result += "_";

                    result += chr;
                }
                else
                {
                    result += chr;
                }
            }

            return result.StartsWith('_') ? result[1..] : result;
        }

        public string Remove(string searchToRemove)
        {
            return type.Replace(searchToRemove, "");
        }
    }
}