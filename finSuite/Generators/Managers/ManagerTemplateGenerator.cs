using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Managers
{
    public class ManagerTemplateGenerator
    {
        public string GenerateManagerTemplate(ClassDatas classDatas)
        {
            var sb = new StringBuilder();
            string classNameWithCamelCase = char.ToLower(classDatas.ClassName[0]) + classDatas.ClassName.Substring(1);


            sb.AppendLine("using JetBrains.Annotations;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Data;");
            sb.AppendLine("using Volo.Abp.Domain.Services;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}Manager : DomainService");
            sb.AppendLine("    {");
            sb.AppendLine($"        protected I{classDatas.ClassName}Repository _{classNameWithCamelCase}Repository;");
            sb.AppendLine();
            sb.AppendLine($"        public {classDatas.ClassName}Manager(I{classDatas.ClassName}Repository {classNameWithCamelCase}Repository)");
            sb.AppendLine("        {");
            sb.AppendLine($"           _{classNameWithCamelCase}Repository = {classNameWithCamelCase}Repository;");
            sb.AppendLine("        }");
            sb.AppendLine();

            // CreateAsync metodu ekleniyor
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}> CreateAsync(");
            sb.Append("        ");

            for (int i = 0; i < classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string")
                {
                    sb.Append($"string {nameWithCamelCase}");
                }
                else
                {
                    sb.Append($"{type} {nameWithCamelCase}");
                }

                // Son eleman için virgülü kaldır
                if (i < classDatas.Properties.Count - 1)
                {
                    sb.Append(",");
                }
                else
                {
                    sb.AppendLine(")"); // Son eleman ise yeni satıra geç
                }
            }

            sb.AppendLine("        {");
            sb.AppendLine($"            var {classNameWithCamelCase} = new {classDatas.ClassName}(");
            sb.AppendLine("                GuidGenerator.Create(),");
            sb.Append("                ");

            for (int i = 0; i<classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"{nameWithCamelCase}");

                if (i< classDatas.Properties.Count -1)

                {
                    sb.Append(",");
                }
                else
                {
                    sb.AppendLine();
                }
            }

            sb.AppendLine("            );");
            sb.AppendLine();
            sb.AppendLine($"            return await _{classNameWithCamelCase}Repository.InsertAsync({classNameWithCamelCase});");
            sb.AppendLine("        }");
            sb.AppendLine();

            // UpdateAsync metodu ekleniyor
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}> UpdateAsync(");
            sb.AppendLine("            Guid id,");
            sb.Append("            ");

            for (int i = 0; i < classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"{type} {nameWithCamelCase}, ");
            }

            sb.AppendLine("[CanBeNull] string? concurrencyStamp = null");
            sb.AppendLine("        )");
            sb.AppendLine("        {");
            sb.AppendLine($"            var {classNameWithCamelCase} = await _{classNameWithCamelCase}Repository.GetAsync(id);");
            sb.AppendLine();

            for (int i = 0; i<classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.AppendLine($"            {classNameWithCamelCase}.{name} = {nameWithCamelCase};");
            }

            sb.AppendLine();
            sb.AppendLine($"            {classNameWithCamelCase}.SetConcurrencyStampIfNotNull(concurrencyStamp);");
            sb.AppendLine($"            return await _{classNameWithCamelCase}Repository.UpdateAsync({classNameWithCamelCase});");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }




        public string GenerateManagerTemplate(CreatedClassDatas classDatas)
        {
            var sb = new StringBuilder();
            string classNameWithCamelCase = char.ToLower(classDatas.ClassName[0]) + classDatas.ClassName.Substring(1);


            sb.AppendLine("using JetBrains.Annotations;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Data;");
            sb.AppendLine("using Volo.Abp.Domain.Services;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}Manager : DomainService");
            sb.AppendLine("    {");
            sb.AppendLine($"        protected I{classDatas.ClassName}Repository _{classNameWithCamelCase}Repository;");
            sb.AppendLine();
            sb.AppendLine($"        public {classDatas.ClassName}Manager(I{classDatas.ClassName}Repository {classNameWithCamelCase}Repository)");
            sb.AppendLine("        {");
            sb.AppendLine($"           _{classNameWithCamelCase}Repository = {classNameWithCamelCase}Repository;");
            sb.AppendLine("        }");
            sb.AppendLine();

            // CreateAsync metodu ekleniyor
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}> CreateAsync(");
            sb.Append("        ");

            for (int i = 0; i < classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string")
                {
                    sb.Append($"string {nameWithCamelCase}");
                }
                else
                {
                    sb.Append($"{type} {nameWithCamelCase}");
                }

                // Son eleman için virgülü kaldır
                if (i < classDatas.CreatedProperties.Count - 1)
                {
                    sb.Append(",");
                }
                else
                {
                    sb.AppendLine(")"); // Son eleman ise yeni satıra geç
                }
            }

            sb.AppendLine("        {");
            sb.AppendLine($"            var {classNameWithCamelCase} = new {classDatas.ClassName}(");
            sb.AppendLine("                GuidGenerator.Create(),");
            sb.Append("                ");

            for (int i = 0; i<classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"{nameWithCamelCase}");

                if (i< classDatas.CreatedProperties.Count -1)

                {
                    sb.Append(",");
                }
                else
                {
                    sb.AppendLine();
                }
            }

            sb.AppendLine("            );");
            sb.AppendLine();
            sb.AppendLine($"            return await _{classNameWithCamelCase}Repository.InsertAsync({classNameWithCamelCase});");
            sb.AppendLine("        }");
            sb.AppendLine();

            // UpdateAsync metodu ekleniyor
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}> UpdateAsync(");
            sb.AppendLine("            Guid id,");
            sb.Append("            ");

            for (int i = 0; i < classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"{type} {nameWithCamelCase}, ");
            }

            sb.AppendLine("[CanBeNull] string? concurrencyStamp = null");
            sb.AppendLine("        )");
            sb.AppendLine("        {");
            sb.AppendLine($"            var {classNameWithCamelCase} = await _{classNameWithCamelCase}Repository.GetAsync(id);");
            sb.AppendLine();

            for (int i = 0; i<classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.AppendLine($"            {classNameWithCamelCase}.{name} = {nameWithCamelCase};");
            }

            sb.AppendLine();
            sb.AppendLine($"            {classNameWithCamelCase}.SetConcurrencyStampIfNotNull(concurrencyStamp);");
            sb.AppendLine($"            return await _{classNameWithCamelCase}Repository.UpdateAsync({classNameWithCamelCase});");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
