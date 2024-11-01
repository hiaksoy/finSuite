using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Configs
{
    public class ConfigTemplateGenerator
    {
        public string GenerateConfigTemplate(ClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new();

            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine($"using {classDatas.NamespaceName};");
            sb.AppendLine($"using {classDatas.NamespaceName};");
            sb.AppendLine($"using Volo.Abp.EntityFrameworkCore.Modeling;");

            for (int i = 0; i < classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                sb.AppendLine($"using {classDatas.NamespaceName}.{name};");

            }

            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}.EntityFrameworkCore.EFCustomConfigurations");
            sb.AppendLine("{");
            sb.AppendLine($"    public static class {folderName}Configuration");
            sb.AppendLine("    {");
            sb.AppendLine($"        public static void {folderName}Config (this ModelBuilder builder)");
            sb.AppendLine("        {");
            sb.AppendLine($"            builder.Entity<{classDatas.ClassName}>(b =>");
            sb.AppendLine("            {");
            sb.AppendLine($"                b.ToTable({classDatas.NamespaceName}Consts.DbTablePrefix + \"{folderName}\");");
            sb.AppendLine("                b.ConfigureByConvention();");

            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.AppendLine($"                b.Property(x => x.{name}).HasColumnName(nameof({classDatas.ClassName}.{name}));");
            }
         
            sb.AppendLine("            });");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");





            return sb.ToString();
        }


        public string GenerateConfigTemplate(CreatedClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new();

            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine($"using {classDatas.NamespaceName};");
            sb.AppendLine($"using {classDatas.NamespaceName};");
            sb.AppendLine($"using Volo.Abp.EntityFrameworkCore.Modeling;");

            for (int i = 0; i < classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                sb.AppendLine($"using {classDatas.NamespaceName}.{name};");

            }

            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}.EntityFrameworkCore.EFCustomConfigurations");
            sb.AppendLine("{");
            sb.AppendLine($"    public static class {folderName}Configuration");
            sb.AppendLine("    {");
            sb.AppendLine($"        public static void {folderName}Config (this ModelBuilder builder)");
            sb.AppendLine("        {");
            sb.AppendLine($"            builder.Entity<{classDatas.ClassName}>(b =>");
            sb.AppendLine("            {");
            sb.AppendLine($"                b.ToTable({classDatas.NamespaceName}Consts.DbTablePrefix + \"{folderName}\");");
            sb.AppendLine("                b.ConfigureByConvention();");

            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.AppendLine($"                b.Property(x => x.{name}).HasColumnName(nameof({classDatas.ClassName}.{name}));");
            }

            sb.AppendLine("            });");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");





            return sb.ToString();
        }
    }
}
