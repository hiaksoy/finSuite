using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Entities
{
    public class EntityTemplateGenerator
    {
        public string GenerateEntityTemplate(ClassDatas classDatas)
        {


            var sb = new StringBuilder();

            // Using tanımları
            sb.AppendLine("using System;");
            sb.AppendLine("using Volo.Abp.Domain.Entities;");
            sb.AppendLine("using Volo.Abp.Domain.Entities.Auditing;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName} : FullAuditedAggregateRoot<Guid>");
            sb.AppendLine("    {");

            // Property tanımları
            foreach (var prop in classDatas.Properties)
            {
                sb.AppendLine($"        public {prop.Value} {prop.Key} {{ get; set;}}");
            }

            // Navigation property tanımları
            foreach (var navProp in classDatas.NavigationProperties)
            {
                sb.AppendLine($"        public {navProp.Value} {navProp.Key} {{ get; set;}}");
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.Append($"        public {classDatas.ClassName}(Guid id, ");

            for (int i = 0; i < classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);


                sb.Append($"{type} {nameWithCamelCase}");

                if (i < classDatas.Properties.Count -1)
                    sb.Append(", ");

            }

            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.AppendLine("            Id = id;");

            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.AppendLine($"            {name} = {nameWithCamelCase};");
            }

            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }



        public string GenerateEntityTemplate(CreatedClassDatas classDatas)
        {


            var sb = new StringBuilder();

            // Using tanımları
            sb.AppendLine("using System;");
            sb.AppendLine("using Volo.Abp.Domain.Entities;");
            sb.AppendLine("using Volo.Abp.Domain.Entities.Auditing;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName} : FullAuditedAggregateRoot<Guid>");
            sb.AppendLine("    {");

            // Property tanımları
            foreach (var prop in classDatas.CreatedProperties)
            {
                sb.AppendLine($"        public {prop.Type} {prop.Name} {{ get; set;}}");
            }

            // Navigation property tanımları
            foreach (var navProp in classDatas.NavigationProperties)
            {
                sb.AppendLine($"        public {navProp.Value} {navProp.Key} {{ get; set;}}");
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.Append($"        public {classDatas.ClassName}(Guid id, ");

            for (int i = 0; i < classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);


                sb.Append($"{type} {nameWithCamelCase}");

                if (i < classDatas.CreatedProperties.Count -1)
                    sb.Append(", ");

            }

            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.AppendLine("            Id = id;");

            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.AppendLine($"            {name} = {nameWithCamelCase};");
            }

            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }
    }
}
