using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Dtos
{
    public class DtoTemplateGenerator
    {
        public string GenerateNewDtoTemplate(ClassDatas classDatas, string inheritance, bool hasConcurrency, string dtoSuffix)
        {
            // StringBuilder kullanımı
            var sb = new StringBuilder();

            // Using tanımları
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using Volo.Abp.Application.Services;");
            sb.AppendLine("using Volo.Abp.Domain.Entities;");
            sb.AppendLine(); // Boş satır

            // Namespace ve class tanımı
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}{dtoSuffix}{inheritance}");
            sb.AppendLine("    {");

            // Property tanımları
            foreach (var prop in classDatas.Properties)
            {
                sb.AppendLine($"        public {prop.Value} {prop.Key} {{ get; set; }}");
            }

            // ConcurrencyStamp tanımı sadece hasConcurrency true ise eklenir
            if (hasConcurrency)
            {
                sb.AppendLine(); // Boş satır
                sb.AppendLine("        public string ConcurrencyStamp { get; set; } = null!;");
            }

            // Sınıf kapanışları
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }


        public string GenerateNewDtoTemplate(CreatedClassDatas createdClassDatas, string inheritance, bool hasConcurrency, string dtoSuffix)
        {
            // StringBuilder kullanımı
            var sb = new StringBuilder();

            // Using tanımları
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using Volo.Abp.Application.Services;");
            sb.AppendLine("using Volo.Abp.Domain.Entities;");
            sb.AppendLine(); // Boş satır

            // Namespace ve class tanımı
            sb.AppendLine($"namespace {createdClassDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {createdClassDatas.ClassName}{dtoSuffix}{inheritance}");
            sb.AppendLine("    {");

            // Property tanımları
            foreach (var prop in createdClassDatas.CreatedProperties)
            {
                sb.AppendLine($"        public {prop.Type} {prop.Name} {{ get; set; }}");
            }

            // ConcurrencyStamp tanımı sadece hasConcurrency true ise eklenir
            if (hasConcurrency)
            {
                sb.AppendLine(); // Boş satır
                sb.AppendLine("        public string ConcurrencyStamp { get; set; } = null!;");
            }

            // Sınıf kapanışları
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
