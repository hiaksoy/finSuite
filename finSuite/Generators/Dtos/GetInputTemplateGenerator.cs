using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Dtos
{
    public class GetInputTemplateGenerator
    {
        public string GenerateGetInputTemplate(ClassDatas classDatas, string folderName)

        {
            StringBuilder sb = new StringBuilder();

            // Namespace ve sınıf adını düzenle
            string inputClassName = $"Get{folderName}Input";
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {inputClassName} : PagedAndSortedResultRequestDto");
            sb.AppendLine("    {");
            // FilterText property'i zorunlu olarak eklenir
            sb.AppendLine("        public string? FilterText { get; set; }\n");

            // Property tanımları
            foreach (var prop in classDatas.Properties)
            {

                // Sayısal tür kontrolü (int, float, double, decimal vs.)
                if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    // Sayısal türler için Min ve Max versiyonlarını ekle
                    sb.AppendLine($"        public {prop.Value}? {prop.Key}Min {{ get; set; }}");
                    sb.AppendLine($"        public {prop.Value}? {prop.Key}Max {{ get; set; }}");
                }
                else
                {
                    // Diğer türler için nullable olarak ekle
                    sb.AppendLine($"        public {prop.Value}? {prop.Key} {{ get; set; }}");
                }

            }

            sb.AppendLine();
            sb.AppendLine($"        public {inputClassName}()");
            sb.AppendLine("        {");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }


        public string GenerateGetInputTemplate(CreatedClassDatas createdClassDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            // Namespace ve sınıf adını düzenle
            string inputClassName = $"Get{folderName}Input";
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine($"namespace {createdClassDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {inputClassName} : PagedAndSortedResultRequestDto");
            sb.AppendLine("    {");
            // FilterText property'i zorunlu olarak eklenir
            sb.AppendLine("        public string? FilterText { get; set; }\n");

            // Property tanımları
            foreach (var prop in createdClassDatas.CreatedProperties)
            {

                // Sayısal tür kontrolü (int, float, double, decimal vs.)
                if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    // Sayısal türler için Min ve Max versiyonlarını ekle
                    sb.AppendLine($"        public {prop.Type}? {prop.Name}Min {{ get; set; }}");
                    sb.AppendLine($"        public {prop.Type}? {prop.Name}Max {{ get; set; }}");
                }
                else
                {
                    // Diğer türler için nullable olarak ekle
                    sb.AppendLine($"        public {prop.Type}? {prop.Name} {{ get; set; }}");
                }
            }

            sb.AppendLine();
            sb.AppendLine($"        public {inputClassName}()");
            sb.AppendLine("        {");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
