using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Mappings
{
    public class ApplicationLayerMappingTemplateGenerator
    {
        public string GenerateApplicationLayerMappingFileTemplate(ClassDatas classDatas ,string folderName)
        {
            StringBuilder sb = new();


            sb.AppendLine($"namespace {classDatas.NamespaceName}.MapperProfiler");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}Mapping : {classDatas.NamespaceName}ApplicationAutoMapperProfile");
            sb.AppendLine("    {");
            sb.AppendLine($"        public {classDatas.ClassName}Mapping()");
            sb.AppendLine("        {");
            sb.AppendLine($"            CreateMap<{classDatas.ClassName}, {classDatas.ClassName}Dto>();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }

        public string GenerateApplicationLayerMappingFileTemplate(CreatedClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new();


            sb.AppendLine($"namespace {classDatas.NamespaceName}.MapperProfiler");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {classDatas.ClassName}Mapping : {classDatas.NamespaceName}ApplicationAutoMapperProfile");
            sb.AppendLine("    {");
            sb.AppendLine($"        public {classDatas.ClassName}Mapping()");
            sb.AppendLine("        {");
            sb.AppendLine($"            CreateMap<{classDatas.ClassName}, {classDatas.ClassName}Dto>();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }



    }
}
