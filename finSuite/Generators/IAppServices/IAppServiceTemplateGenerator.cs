using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.IAppServices
{
    public class IAppServiceTemplateGenerator
    {
        public string GenerateIAppServiceTemplate(ClassDatas classDatas,string interfaceName, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            // Namespace ve class tanımı

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using Volo.Abp.Application.Services;");
            sb.AppendLine();
            sb.AppendLine($"namespace {classDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public interface {interfaceName} : IApplicationService");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine($"        Task<PagedResultDto<{classDatas.ClassName}Dto>> GetListAsync(Get{folderName}Input input);");
            sb.AppendLine();
            sb.AppendLine($"        Task<{classDatas.ClassName}Dto> GetAsync(Guid id);");
            sb.AppendLine();
            sb.AppendLine("        Task DeleteAsync(Guid id);");
            sb.AppendLine();
            sb.AppendLine($"        Task<{classDatas.ClassName}Dto> CreateAsync({classDatas.ClassName}CreateDto input);");
            sb.AppendLine();
            sb.AppendLine($"        Task<{classDatas.ClassName}Dto> UpdateAsync(Guid id, {classDatas.ClassName}UpdateDto input);");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public string GenerateIAppServiceTemplate(CreatedClassDatas createdClassDatas, string interfaceName, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            // Namespace ve class tanımı

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using Volo.Abp.Application.Services;");
            sb.AppendLine();
            sb.AppendLine($"namespace {createdClassDatas.NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public interface {interfaceName} : IApplicationService");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine($"        Task<PagedResultDto<{createdClassDatas.ClassName}Dto>> GetListAsync(Get{folderName}Input input);");
            sb.AppendLine();
            sb.AppendLine($"        Task<{createdClassDatas.ClassName}Dto> GetAsync(Guid id);");
            sb.AppendLine();
            sb.AppendLine("        Task DeleteAsync(Guid id);");
            sb.AppendLine();
            sb.AppendLine($"        Task<{createdClassDatas.ClassName}Dto> CreateAsync({createdClassDatas.ClassName}CreateDto input);");
            sb.AppendLine();
            sb.AppendLine($"        Task<{createdClassDatas.ClassName}Dto> UpdateAsync(Guid id, {createdClassDatas.ClassName}UpdateDto input);");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

    }
}
