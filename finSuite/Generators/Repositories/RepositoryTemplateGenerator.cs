using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Repositories
{
    public class RepositoryTemplateGenerator
    {
        public string GenerateRepositoryTemplate(ClassDatas classDatas)
        {


            var sb = new StringBuilder();

            // 1. Using tanımları
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Linq.Dynamic.Core;");
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine("using Volo.Abp.Domain.Repositories.EntityFrameworkCore;");
            sb.AppendLine("using Volo.Abp.EntityFrameworkCore;");
            sb.AppendLine($"using {classDatas.NamespaceName}.EntityFrameworkCore;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class EfCore{classDatas.ClassName}Repository : EfCoreRepository<{classDatas.NamespaceName}DbContext, {classDatas.ClassName}, Guid>, I{classDatas.ClassName}Repository");
            sb.AppendLine("    {");
            sb.AppendLine($"        public EfCore{classDatas.ClassName}Repository(IDbContextProvider<{classDatas.NamespaceName}DbContext> dbContextProvider)");
            sb.AppendLine("            : base(dbContextProvider)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public virtual async Task<List<{classDatas.ClassName}>> GetListAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            foreach (var prop in classDatas.Properties)
            {
                // Property ismini camelCase formata dönüştür
                var nameWithCamelCase = char.ToLower(prop.Key[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Key.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (prop.Value == "string" || prop.Value == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"            {prop.Value}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {prop.Value}? {nameWithCamelCase}Max = null,");
                }
                else if (prop.Value == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (prop.Value == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }
            }


            // Statik parametreler
            sb.AppendLine("            string? sorting = null,");
            sb.AppendLine("            int maxResultCount = int.MaxValue,");
            sb.AppendLine("            int skipCount = 0,");
            sb.AppendLine("            CancellationToken cancellationToken = default)");
            sb.AppendLine("        {");

            // Dinamik parametrelerle `ApplyFilter` çağrısı oluşturma
            sb.Append("            var query = ApplyFilter((await GetQueryableAsync()), filterText");

            // Dinamik parametreleri ApplyFilter'a ekleme
            foreach (var prop in classDatas.Properties)
            {
                var nameWithCamelCase = char.ToLower(prop.Key[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Key.Substring(1);

                if (nameWithCamelCase != "filterText") // filterText zaten her türlü ekleniyor, tekrarlamaya gerek yok.
                {

                    if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                    {
                        sb.Append($", {nameWithCamelCase}Min");
                        sb.Append($", {nameWithCamelCase}Max");
                    }
                    else
                    {
                        sb.Append($", {nameWithCamelCase}");
                    }
                }
            }

            sb.AppendLine(");"); // `ApplyFilter` metodunu kapatma
            sb.AppendLine($"            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? {classDatas.ClassName}Consts.GetDefaultSorting(false) : sorting);");
            sb.AppendLine("            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);");
            sb.AppendLine("        }");
            sb.AppendLine();

            // 4. GetCountAsync metodu başlatma
            sb.AppendLine("        public virtual async Task<long> GetCountAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            foreach (var prop in classDatas.Properties)
            {
                var nameWithCamelCase = char.ToLower(prop.Key[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Key.Substring(1);

                if (prop.Value == "string" || prop.Value == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"            {prop.Value}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {prop.Value}? {nameWithCamelCase}Max = null,");
                }
                else if (prop.Value == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (prop.Value == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }
            }

            sb.AppendLine("            CancellationToken cancellationToken = default)");
            sb.AppendLine("        {");

            // Dinamik parametrelerle `ApplyFilter` çağrısı oluşturma
            sb.Append("            var query = ApplyFilter((await GetDbSetAsync()), filterText");

            foreach (var prop in classDatas.Properties)
            {
                var nameWithCamelCase = char.ToLower(prop.Key[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Key.Substring(1);

                if (nameWithCamelCase != "filterText")
                {
                    if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                    {
                        sb.Append($", {nameWithCamelCase}Min");
                        sb.Append($", {nameWithCamelCase}Max");
                    }
                    else
                    {
                        sb.Append($", {nameWithCamelCase}");
                    }
                }
            }

            sb.AppendLine(");");
            sb.AppendLine("            return await query.LongCountAsync(GetCancellationToken(cancellationToken));");
            sb.AppendLine("        }");
            sb.AppendLine();

            // 5. ApplyFilter metodu başlatma
            sb.AppendLine($"        protected virtual IQueryable<{classDatas.ClassName}> ApplyFilter(");
            sb.AppendLine($"            IQueryable<{classDatas.ClassName}> query,");
            sb.AppendLine("            string? filterText = null,");


            for (int i = 0; i < classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // StringBuilder'e type'a göre ekleme yap
                if (type == "string" || prop.Value == "string?")
                {
                    sb.Append($"            string? {nameWithCamelCase} = null");
                }
                else if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Min = null,");
                    sb.Append($"            {type}? {nameWithCamelCase}Max = null");
                }
                else if (type == "bool")
                {
                    sb.Append($"            bool? {nameWithCamelCase} = null");
                }
                else
                {
                    sb.Append($"            {type}? {nameWithCamelCase} = null");
                }

                // Virgül ekleme kontrolü: Eğer son property değilse, satır sonuna virgül ekle, son property ise ekleme
                if (i < classDatas.Properties.Count - 1)
                {
                    sb.AppendLine(",");
                }

            }






            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.AppendLine("            return query");

            // Dinamik filtreleme ekleme


            var stringPropertyCount = classDatas.Properties.Count(p => p.Value == "string" || p.Value == "string?");

            int stringPropertyIndex = 0; // İşlediğimiz string property'leri saymak için bir sayaç oluşturuyoruz


            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string" || type == "string?")
                {
                    sb.Append("                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => ");
                    sb.AppendLine($"e.{name}!.Contains(filterText!))");

                    stringPropertyIndex++; // Her string property'den sonra sayaç artacak

                    // Son string property değilse, ' || ' ekle
                    if (stringPropertyIndex < stringPropertyCount)
                    {
                        sb.Append(" || ");
                    }
                }


            }

            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string" || type == "string?")
                {
                    sb.Append($"                    .WhereIf(!string.IsNullOrWhiteSpace({nameWithCamelCase}), e => e.{name}.Contains({nameWithCamelCase}))");

                    if (i == classDatas.Properties.Count -1)
                        sb.Append(";");
                    sb.AppendLine();

                }
                else if (
                    prop.Value == "int" || prop.Value == "float" || prop.Value == "double" || prop.Value == "decimal" || prop.Value == "byte" || prop.Value == "DateTime" || prop.Value == "DateOnly" || prop.Value == "long" || prop.Value == "sbyte" || prop.Value == "TimeOnly" || prop.Value == "uint" || prop.Value == "ulong" || prop.Value == "ushort" ||
                    prop.Value == "int?" || prop.Value == "float?" || prop.Value == "double?" || prop.Value == "decimal?" || prop.Value == "byte?" || prop.Value == "DateTime?" || prop.Value == "DateOnly?" || prop.Value == "long?" || prop.Value == "sbyte?" || prop.Value == "TimeOnly?" || prop.Value == "uint?" || prop.Value == "ulong?" || prop.Value == "ushort?"

                    )
                {
                    sb.AppendLine($"                    .WhereIf({nameWithCamelCase}Min.HasValue, e => e.{name} >= {nameWithCamelCase}Min!.Value)");
                    sb.Append($"                    .WhereIf({nameWithCamelCase}Max.HasValue, e => e.{name} <= {nameWithCamelCase}Max!.Value)");

                    if (i == classDatas.Properties.Count -1)
                        sb.Append(";");
                    sb.AppendLine();
                }
                else if (type == "bool")
                {
                    sb.Append($"                    .WhereIf({nameWithCamelCase}.HasValue, e => e.{name} == {nameWithCamelCase})");

                    if (i == classDatas.Properties.Count -1)
                        sb.Append(";");
                    sb.AppendLine();
                }




            }

            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.Append("}");

            return sb.ToString();
        }



        public string GenerateRepositoryTemplate(CreatedClassDatas classDatas)
        {


            var sb = new StringBuilder();

            // 1. Using tanımları
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Linq.Dynamic.Core;");
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine("using Volo.Abp.Domain.Repositories.EntityFrameworkCore;");
            sb.AppendLine("using Volo.Abp.EntityFrameworkCore;");
            sb.AppendLine($"using {classDatas.NamespaceName}.EntityFrameworkCore;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class EfCore{classDatas.ClassName}Repository : EfCoreRepository<{classDatas.NamespaceName}DbContext, {classDatas.ClassName}, Guid>, I{classDatas.ClassName}Repository");
            sb.AppendLine("    {");
            sb.AppendLine($"        public EfCore{classDatas.ClassName}Repository(IDbContextProvider<{classDatas.NamespaceName}DbContext> dbContextProvider)");
            sb.AppendLine("            : base(dbContextProvider)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public virtual async Task<List<{classDatas.ClassName}>> GetListAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            foreach (var prop in classDatas.CreatedProperties)
            {
                // Property ismini camelCase formata dönüştür
                var nameWithCamelCase = char.ToLower(prop.Name[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Name.Substring(1);

                // Type'a göre string builder'a ekleme yap
                if (prop.Type == "string" || prop.Type == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.AppendLine($"            {prop.Type}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {prop.Type}? {nameWithCamelCase}Max = null,");
                }
                else if (prop.Type == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (prop.Type == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }
            }


            // Statik parametreler
            sb.AppendLine("            string? sorting = null,");
            sb.AppendLine("            int maxResultCount = int.MaxValue,");
            sb.AppendLine("            int skipCount = 0,");
            sb.AppendLine("            CancellationToken cancellationToken = default)");
            sb.AppendLine("        {");

            // Dinamik parametrelerle `ApplyFilter` çağrısı oluşturma
            sb.Append("            var query = ApplyFilter((await GetQueryableAsync()), filterText");

            // Dinamik parametreleri ApplyFilter'a ekleme
            foreach (var prop in classDatas.CreatedProperties)
            {
                var nameWithCamelCase = char.ToLower(prop.Name[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Name.Substring(1);

                if (nameWithCamelCase != "filterText") // filterText zaten her türlü ekleniyor, tekrarlamaya gerek yok.
                {

                    if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                    {
                        sb.Append($", {nameWithCamelCase}Min");
                        sb.Append($", {nameWithCamelCase}Max");
                    }
                    else
                    {
                        sb.Append($", {nameWithCamelCase}");
                    }
                }
            }

            sb.AppendLine(");"); // `ApplyFilter` metodunu kapatma
            sb.AppendLine($"            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? {classDatas.ClassName}Consts.GetDefaultSorting(false) : sorting);");
            sb.AppendLine("            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);");
            sb.AppendLine("        }");
            sb.AppendLine();

            // 4. GetCountAsync metodu başlatma
            sb.AppendLine("        public virtual async Task<long> GetCountAsync(");
            sb.AppendLine("            string? filterText = null,");

            // Dinamik parametre tanımlama
            foreach (var prop in classDatas.CreatedProperties)
            {
                var nameWithCamelCase = char.ToLower(prop.Name[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Name.Substring(1);

                if (prop.Type == "string" || prop.Type == "string?")
                {
                    sb.AppendLine($"            string? {nameWithCamelCase} = null,");
                }
                else if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.AppendLine($"            {prop.Type}? {nameWithCamelCase}Min = null,");
                    sb.AppendLine($"            {prop.Type}? {nameWithCamelCase}Max = null,");
                }
                else if (prop.Type == "bool")
                {
                    sb.AppendLine($"            bool? {nameWithCamelCase} = null,");
                }
                else if (prop.Type == "Guid")
                {
                    sb.AppendLine($"            Guid? {nameWithCamelCase} = null,");
                }
            }

            sb.AppendLine("            CancellationToken cancellationToken = default)");
            sb.AppendLine("        {");

            // Dinamik parametrelerle `ApplyFilter` çağrısı oluşturma
            sb.Append("            var query = ApplyFilter((await GetDbSetAsync()), filterText");

            foreach (var prop in classDatas.CreatedProperties)
            {
                var nameWithCamelCase = char.ToLower(prop.Name[0], System.Globalization.CultureInfo.InvariantCulture) + prop.Name.Substring(1);

                if (nameWithCamelCase != "filterText")
                {
                    if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                    {
                        sb.Append($", {nameWithCamelCase}Min");
                        sb.Append($", {nameWithCamelCase}Max");
                    }
                    else
                    {
                        sb.Append($", {nameWithCamelCase}");
                    }
                }
            }

            sb.AppendLine(");");
            sb.AppendLine("            return await query.LongCountAsync(GetCancellationToken(cancellationToken));");
            sb.AppendLine("        }");
            sb.AppendLine();

            // 5. ApplyFilter metodu başlatma
            sb.AppendLine($"        protected virtual IQueryable<{classDatas.ClassName}> ApplyFilter(");
            sb.AppendLine($"            IQueryable<{classDatas.ClassName}> query,");
            sb.AppendLine("            string? filterText = null,");


            for (int i = 0; i < classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Type property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                // StringBuilder'e type'a göre ekleme yap
                if (type == "string" || prop.Type == "string?")
                {
                    sb.Append($"            string? {nameWithCamelCase} = null");
                }
                else if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.AppendLine($"            {type}? {nameWithCamelCase}Min = null,");
                    sb.Append($"            {type}? {nameWithCamelCase}Max = null");
                }
                else if (type == "bool")
                {
                    sb.Append($"            bool? {nameWithCamelCase} = null");
                }
                else
                {
                    sb.Append($"            {type}? {nameWithCamelCase} = null");
                }

                // Virgül ekleme kontrolü: Eğer son property değilse, satır sonuna virgül ekle, son property ise ekleme
                if (i < classDatas.CreatedProperties.Count - 1)
                {
                    sb.AppendLine(",");
                }

            }






            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.AppendLine("            return query");

            // Dinamik filtreleme ekleme

            var stringPropertyCount = classDatas.CreatedProperties.Count(p => p.Type == "string" || p.Type == "string?");

            int stringPropertyIndex = 0; // İşlediğimiz string property'leri saymak için bir sayaç oluşturuyoruz


            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Type property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string" || type == "string?")
                {
                    sb.Append("                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => ");
                    sb.AppendLine($"e.{name}!.Contains(filterText!))");

                    stringPropertyIndex++; // Her string property'den sonra sayaç artacak

                    // Son string property değilse, ' || ' ekle
                    if (stringPropertyIndex < stringPropertyCount)
                    {
                        sb.Append(" || ");
                    }
                }


            }
           

            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'classDatas.Properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Type property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "string" || type == "string?")
                {
                    sb.Append($"                    .WhereIf(!string.IsNullOrWhiteSpace({nameWithCamelCase}), e => e.{name}.Contains({nameWithCamelCase}))");

                    if (i == classDatas.CreatedProperties.Count -1)
                        sb.Append(";");
                    sb.AppendLine();

                }
                else if (
                    prop.Type == "int" || prop.Type == "float" || prop.Type == "double" || prop.Type == "decimal" || prop.Type == "byte" || prop.Type == "DateTime" || prop.Type == "DateOnly" || prop.Type == "long" || prop.Type == "sbyte" || prop.Type == "TimeOnly" || prop.Type == "uint" || prop.Type == "ulong" || prop.Type == "ushort" ||
                    prop.Type == "int?" || prop.Type == "float?" || prop.Type == "double?" || prop.Type == "decimal?" || prop.Type == "byte?" || prop.Type == "DateTime?" || prop.Type == "DateOnly?" || prop.Type == "long?" || prop.Type == "sbyte?" || prop.Type == "TimeOnly?" || prop.Type == "uint?" || prop.Type == "ulong?" || prop.Type == "ushort?"

                    )
                {
                    sb.AppendLine($"                    .WhereIf({nameWithCamelCase}Min.HasValue, e => e.{name} >= {nameWithCamelCase}Min!.Value)");
                    sb.Append($"                    .WhereIf({nameWithCamelCase}Max.HasValue, e => e.{name} <= {nameWithCamelCase}Max!.Value)");

                    if (i == classDatas.CreatedProperties.Count -1)
                        sb.Append(";");
                    sb.AppendLine();
                }
                else if (type == "bool")
                {
                    sb.Append($"                    .WhereIf({nameWithCamelCase}.HasValue, e => e.{name} == {nameWithCamelCase})");

                    if (i == classDatas.CreatedProperties.Count -1)
                        sb.Append(";");
                    sb.AppendLine();
                }




            }

            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.Append("}");

            return sb.ToString();
        }

    }
}
