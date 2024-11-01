using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Mappings
{
    public class BlazorLayerMappingTemplateGenerator
    {
        public string GenerateBlazorLayerMappingFileTemplate(ClassDatas classDatas,string folderName)
        {
            StringBuilder sb = new();

            sb.AppendLine($"using {classDatas.NamespaceName}.Blazor;");
            sb.AppendLine($"namespace {classDatas.NamespaceName}.Blazor.MapperProfilers");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}Mapping : {classDatas.NamespaceName}BlazorAutoMapperProfile");
            sb.AppendLine("    {");
            sb.AppendLine($"        public {classDatas.ClassName}Mapping()");
            sb.AppendLine("        {");
            sb.AppendLine($"            CreateMap<{classDatas.ClassName}Dto, {classDatas.ClassName}UpdateDto>();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }

        public string GenerateBlazorLayerMappingFileTemplate(CreatedClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new();

            sb.AppendLine($"using {classDatas.NamespaceName}.Blazor;");
            sb.AppendLine($"namespace {classDatas.NamespaceName}.Blazor.MapperProfilers");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}Mapping : {classDatas.NamespaceName}BlazorAutoMapperProfile");
            sb.AppendLine("    {");
            sb.AppendLine($"        public {classDatas.ClassName}Mapping()");
            sb.AppendLine("        {");
            sb.AppendLine($"            CreateMap<{classDatas.ClassName}Dto, {classDatas.ClassName}UpdateDto>();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }


    }
}
