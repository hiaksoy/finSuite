using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Consts
{
    public class ConstsClassTemplateGenerator
    {
        public string GenerateConstsClassTemplate(ClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"namespace {classDatas.NamespaceName}.{folderName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public static class {classDatas.ClassName}Consts");
            sb.AppendLine("    {");
            sb.AppendLine("        private const string DefaultSorting = \"{0}CreationTime asc\";");
            sb.AppendLine("");
            sb.AppendLine("        public static string GetDefaultSorting(bool withEntityName)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return string.Format(DefaultSorting, withEntityName ? \"{classDatas.ClassName}.\" : string.Empty);");
            sb.AppendLine("        }");

            for (int i = 0; i < classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);




                if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte"   || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?"   || prop.Value == "long?" || prop.Value == "sbyte?"  || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"                    public const {type} {name}MinLength = {type}.MinValue;");
                    sb.AppendLine($"                    public const {type} {name}MaxLength = {type}.MaxValue;");
                }

                else if (prop.Value == "string" || prop.Value == "string?")
                {
                    sb.AppendLine($"                    public const int {name}MinLength = int.MinValue;");
                    sb.AppendLine($"                    public const int {name}MaxLength = int.MaxValue;");
                }


            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }


        public string GenerateConstsClassTemplate(CreatedClassDatas createdClassDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"namespace {createdClassDatas.NamespaceName}.Insans");
            sb.AppendLine("{");
            sb.AppendLine($"    public static class {createdClassDatas.ClassName}Consts");
            sb.AppendLine("    {");
            sb.AppendLine("        private const string DefaultSorting = \"{0}CreationTime asc\";");
            sb.AppendLine("");
            sb.AppendLine("        public static string GetDefaultSorting(bool withEntityName)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return string.Format(DefaultSorting, withEntityName ? \"{createdClassDatas.ClassName}.\" : string.Empty);");
            sb.AppendLine("        }");

            for (int i = 0; i < createdClassDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = createdClassDatas.CreatedProperties.ElementAt(i);


                if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte"   || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?"   || prop.Type == "long?" || prop.Type == "sbyte?"  || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.Append($"                    public const {prop.Type} {prop.Name}MinLength =");
                    if (!string.IsNullOrEmpty(prop.MinLength.ToString())) 
                    {
                        sb.AppendLine($" {prop.MinLength};");
                    }
                    else
                    {
                        sb.AppendLine($" {prop.Type}.MinValue;");
                    }

                    sb.Append($"                    public const {prop.Type} {prop.Name}MaxLength =");
                    if (!string.IsNullOrEmpty(prop.MaxLength.ToString()))
                    {
                        sb.AppendLine($" {prop.MaxLength};");
                    }
                    else
                    {
                        sb.AppendLine($" {prop.Type}.MaxValue;");
                    }
                }

                else if (prop.Type == "string" || prop.Type == "string?")
                {
                    sb.Append($"                    public const int {prop.Name}MinLength =");
                    if (!string.IsNullOrEmpty(prop.MinLength.ToString()))
                    {
                        sb.AppendLine($" {prop.MinLength};");
                    }
                    else
                    {
                        sb.AppendLine($" int.MinValue;");
                    }

                    sb.Append($"                    public const int {prop.Name}MaxLength =");
                    if (!string.IsNullOrEmpty(prop.MaxLength.ToString()))
                    {
                        sb.AppendLine($" {prop.MaxLength};");
                    }
                    else
                    {
                        sb.AppendLine($" int.MaxValue;");
                    }


                }


            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }




    }
}
