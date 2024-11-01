using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.IRepositories
{
    public class IRepositoryTemplateGenerator
    {

        public string GenerateRepositoryInterfaceTemplate(ClassDatas classDatas)
        {
            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Domain.Repositories;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public interface I{classDatas.ClassName}Repository : IRepository<{classDatas.ClassName}, Guid>");
            sb.AppendLine("    {");
            sb.AppendLine($"        Task<List<{classDatas.ClassName}>> GetListAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (type == "string" || type == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Max = null,");
                }
                else if (type == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (type == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }
            }


            // Statik parametreler
            sb.AppendLine("            string? sorting = null,");
            sb.AppendLine("            int maxResultCount = int.MaxValue,");
            sb.AppendLine("            int skipCount = 0,");
            sb.AppendLine("            CancellationToken cancellationToken = default");
            sb.AppendLine("        );");
            sb.AppendLine();

            sb.AppendLine($"        Task<long> GetCountAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string" || type == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Max = null,");
                }
                else if (type == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (type == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }

            }

            sb.AppendLine("            CancellationToken cancellationToken = default);");
            sb.AppendLine("    }");
            sb.Append("}");


            return sb.ToString();
        }


        public string GenerateRepositoryInterfaceTemplate(CreatedClassDatas classDatas)
        {
            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Domain.Repositories;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public interface I{classDatas.ClassName}Repository : IRepository<{classDatas.ClassName}, Guid>");
            sb.AppendLine("    {");
            sb.AppendLine($"        Task<List<{classDatas.ClassName}>> GetListAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (type == "string" || type == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Max = null,");
                }
                else if (type == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (type == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }
            }


            // Statik parametreler
            sb.AppendLine("            string? sorting = null,");
            sb.AppendLine("            int maxResultCount = int.MaxValue,");
            sb.AppendLine("            int skipCount = 0,");
            sb.AppendLine("            CancellationToken cancellationToken = default");
            sb.AppendLine("        );");
            sb.AppendLine();

            sb.AppendLine($"        Task<long> GetCountAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string" || type == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Max = null,");
                }
                else if (type == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (type == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }

            }

            sb.AppendLine("            CancellationToken cancellationToken = default);");
            sb.AppendLine("    }");
            sb.Append("}");


            return sb.ToString();
        }
    }
}
