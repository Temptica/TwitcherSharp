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
                else if (chr == '_') result += type[++i].ToString().ToUpper();
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
            
            foreach (var chr in type)
            {
                if (string.Equals(chr.ToString().ToUpper(),chr.ToString())) result += $"_{chr.ToString().ToLower()}";
                else result += chr.ToString();
            }

            return result.StartsWith('_') ? result[1..] : result;
        }
    }
}