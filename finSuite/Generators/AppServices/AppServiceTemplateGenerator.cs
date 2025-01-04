using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.AppServices
{
    public class AppServiceTemplateGenerator
    {

        public string GenerateEntityAppServiceTemplate(ClassDatas classDatas ,string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);

            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"using {classDatas.NamespaceName}.Permissions;");
            sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Default)]");
            sb.AppendLine($"    public class {folderName}AppService : {classDatas.NamespaceName}AppService, I{folderName}AppService");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine($"        protected I{classDatas.ClassName}Repository _{classNameWithCamelCase}Repository;");
            sb.AppendLine($"        protected {classDatas.ClassName}Manager _{classNameWithCamelCase}Manager;");
            sb.AppendLine();
            sb.AppendLine($"        public {folderName}AppService(I{classDatas.ClassName}Repository {classNameWithCamelCase}Repository, {classDatas.ClassName}Manager {classNameWithCamelCase}Manager)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine($"            _{classNameWithCamelCase}Repository = {classNameWithCamelCase}Repository;");
            sb.AppendLine($"            _{classNameWithCamelCase}Manager = {classNameWithCamelCase}Manager;");
            sb.AppendLine();
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public virtual async Task<PagedResultDto<{classDatas.ClassName}Dto>> GetListAsync(Get{folderName}Input input)");
            sb.AppendLine("        {");
            //sb.Append($"            var totalCount = await _{classNameWithCamelCase}Repository.GetCountAsync(input.FilterText, input.Name, input.AgeMin, input.AgeMax, input.IsAlive);");
            sb.Append($"            var totalCount = await _{classNameWithCamelCase}Repository.GetCountAsync(input.FilterText,");

            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.Append($" input.{name}Min,");
                    sb.Append($" input.{name}Max");

                    if (i < classDatas.Properties.Count -1)
                        sb.Append(",");
                }
                else
                {
                    sb.Append($" input.{name}");

                    if (i < classDatas.Properties.Count -1)
                        sb.Append(",");
                }

            }
            sb.AppendLine(");");


            sb.Append($"            var items = await _{classNameWithCamelCase}Repository.GetListAsync(input.FilterText,");

            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.Append($" input.{name}Min,");
                    sb.Append($" input.{name}Max,");
                }
                else
                {
                    sb.Append($" input.{name},");

                }

            }
            sb.Append(" input.Sorting, input.MaxResultCount, input.SkipCount");
            sb.AppendLine(");");


            sb.AppendLine();
            sb.AppendLine($"            return new PagedResultDto<{classDatas.ClassName}Dto>");
            sb.AppendLine("            {");
            sb.AppendLine("                TotalCount = totalCount,");
            sb.AppendLine($"                Items = ObjectMapper.Map<List<{classDatas.ClassName}>, List<{classDatas.ClassName}Dto>>(items)");
            sb.AppendLine("            };");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}Dto> GetAsync(Guid id)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return ObjectMapper.Map<{classDatas.ClassName}, {classDatas.ClassName}Dto>(await _{classNameWithCamelCase}Repository.GetAsync(id));");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Delete)]");
            sb.AppendLine($"        public virtual async Task DeleteAsync(Guid id)");
            sb.AppendLine("        {");
            sb.AppendLine($"            await _{classNameWithCamelCase}Repository.DeleteAsync(id);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Create)]");
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}Dto> CreateAsync({classDatas.ClassName}CreateDto input)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine($"            var author = await _{classNameWithCamelCase}Manager.CreateAsync(");
            sb.Append("            ");



            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"input.{name}");
                if (i < classDatas.Properties.Count -1)
                    sb.Append(",");

            }


            sb.AppendLine("            );");
            sb.AppendLine();
            sb.AppendLine($"            return ObjectMapper.Map<{classDatas.ClassName}, {classDatas.ClassName}Dto>(author);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Edit)]");
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}Dto> UpdateAsync(Guid id, {classDatas.ClassName}UpdateDto input)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine($"            var {classNameWithCamelCase} = await _{classNameWithCamelCase}Manager.UpdateAsync(");
            sb.AppendLine("            id,");
            sb.Append("            ");
            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"input.{name}, ");
            }
            sb.AppendLine("input.ConcurrencyStamp");


            sb.AppendLine("            );");
            sb.AppendLine();
            sb.AppendLine($"            return ObjectMapper.Map<{classDatas.ClassName}, {classDatas.ClassName}Dto>({classNameWithCamelCase});");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }


        public string GenerateEntityAppServiceTemplate(CreatedClassDatas classDatas, string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);

            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"using {classDatas.NamespaceName}.Permissions;");
            sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abpi;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Default)]");
            sb.AppendLine($"    public class {folderName}AppService : {classDatas.NamespaceName}AppService, I{folderName}AppService");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine($"        protected I{classDatas.ClassName}Repository _{classNameWithCamelCase}Repository;");
            sb.AppendLine($"        protected {classDatas.ClassName}Manager _{classNameWithCamelCase}Manager;");
            sb.AppendLine();
            sb.AppendLine($"        public {folderName}AppService(I{classDatas.ClassName}Repository {classNameWithCamelCase}Repository, {classDatas.ClassName}Manager {classNameWithCamelCase}Manager)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine($"            _{classNameWithCamelCase}Repository = {classNameWithCamelCase}Repository;");
            sb.AppendLine($"            _{classNameWithCamelCase}Manager = {classNameWithCamelCase}Manager;");
            sb.AppendLine();
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public virtual async Task<PagedResultDto<{classDatas.ClassName}Dto>> GetListAsync(Get{folderName}Input input)");
            sb.AppendLine("        {");
            //sb.Append($"            var totalCount = await _{classNameWithCamelCase}Repository.GetCountAsync(input.FilterText, input.Name, input.AgeMin, input.AgeMax, input.IsAlive);");
            sb.Append($"            var totalCount = await _{classNameWithCamelCase}Repository.GetCountAsync(input.FilterText,");

            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.Append($" input.{name}Min,");
                    sb.Append($" input.{name}Max");

                    if (i < classDatas.CreatedProperties.Count -1)
                        sb.Append(",");
                }
                else
                {
                    sb.Append($" input.{name}");

                    if (i < classDatas.CreatedProperties.Count -1)
                        sb.Append(",");
                }

            }
            sb.AppendLine(");");


            sb.Append($"            var items = await _{classNameWithCamelCase}Repository.GetListAsync(input.FilterText,");

            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.Append($" input.{name}Min,");
                    sb.Append($" input.{name}Max,");
                }
                else
                {
                    sb.Append($" input.{name},");

                }

            }
            sb.Append(" input.Sorting, input.MaxResultCount, input.SkipCount");
            sb.AppendLine(");");


            sb.AppendLine();
            sb.AppendLine($"            return new PagedResultDto<{classDatas.ClassName}Dto>");
            sb.AppendLine("            {");
            sb.AppendLine("                TotalCount = totalCount,");
            sb.AppendLine($"                Items = ObjectMapper.Map<List<{classDatas.ClassName}>, List<{classDatas.ClassName}Dto>>(items)");
            sb.AppendLine("            };");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}Dto> GetAsync(Guid id)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return ObjectMapper.Map<{classDatas.ClassName}, {classDatas.ClassName}Dto>(await _{classNameWithCamelCase}Repository.GetAsync(id));");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Delete)]");
            sb.AppendLine($"        public virtual async Task DeleteAsync(Guid id)");
            sb.AppendLine("        {");
            sb.AppendLine($"            await _{classNameWithCamelCase}Repository.DeleteAsync(id);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Create)]");
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}Dto> CreateAsync({classDatas.ClassName}CreateDto input)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine($"            var author = await _{classNameWithCamelCase}Manager.CreateAsync(");
            sb.Append("            ");



            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"input.{name}");
                if (i < classDatas.CreatedProperties.Count -1)
                    sb.Append(",");

            }


            sb.AppendLine("            );");
            sb.AppendLine();
            sb.AppendLine($"            return ObjectMapper.Map<{classDatas.ClassName}, {classDatas.ClassName}Dto>(author);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Edit)]");
            sb.AppendLine($"        public virtual async Task<{classDatas.ClassName}Dto> UpdateAsync(Guid id, {classDatas.ClassName}UpdateDto input)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine($"            var {classNameWithCamelCase} = await _{classNameWithCamelCase}Manager.UpdateAsync(");
            sb.AppendLine("            id,");
            sb.Append("            ");
            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                sb.Append($"input.{name}, ");
            }
            sb.AppendLine("input.ConcurrencyStamp");


            sb.AppendLine("            );");
            sb.AppendLine();
            sb.AppendLine($"            return ObjectMapper.Map<{classDatas.ClassName}, {classDatas.ClassName}Dto>({classNameWithCamelCase});");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
