using finSuite.Helpers;
using finSuite.InputClasses;
using System.Text;

namespace finSuite.Generators.RazorPages
{
    public class RazorPageTemplateGenerator
    {
        public string GenerateRazorPageTemplate(ClassDatas classDatas,string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"@page \"/{classNameWithCamelCase}\"");
            sb.AppendLine("");
            sb.AppendLine($"@attribute [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Default)]");
            sb.AppendLine($"@using {classDatas.NamespaceName}.{folderName}");
            sb.AppendLine($"@using {classDatas.NamespaceName}.Localization");
            sb.AppendLine($"@using {classDatas.NamespaceName}.Shared");
            sb.AppendLine("@using Microsoft.AspNetCore.Authorization");
            sb.AppendLine("@using Microsoft.Extensions.Localization");
            sb.AppendLine("@using Microsoft.AspNetCore.Components.Web");
            sb.AppendLine("@using Blazorise");
            sb.AppendLine("@using Blazorise.Components");
            sb.AppendLine("@using Blazorise.DataGrid");
            sb.AppendLine("@using Volo.Abp.BlazoriseUI");
            sb.AppendLine("@using Volo.Abp.BlazoriseUI.Components");
            sb.AppendLine("@using Volo.Abp.ObjectMapping");
            sb.AppendLine("@using Volo.Abp.AspNetCore.Components.Messages");
            sb.AppendLine("@using Volo.Abp.AspNetCore.Components.Web.Theming.Layout");
            sb.AppendLine("");
            sb.AppendLine($"@using {classDatas.NamespaceName}.Permissions");
            sb.AppendLine("@using Volo.Abp.AspNetCore.Components.Web");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"@inherits {classDatas.NamespaceName}ComponentBase");
            sb.AppendLine($"@inject I{folderName}AppService {folderName}AppService");
            sb.AppendLine("");
            sb.AppendLine("@inject IUiMessageService UiMessageService");
            sb.AppendLine($"@inject AbpBlazorMessageLocalizerHelper<{classDatas.NamespaceName}Resource> LH");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            #region page header
            sb.Append(AbpPageHeaderHelper.CreatePageHeaderTemplate(classDatas, folderName));
            #endregion

            #region search 
            sb.Append(AbpSearchComponentHelper.CreateSearchTemplate(classDatas, folderName));
            #endregion

            #region data grid
            sb.Append(DataGridHelper.CreateDataGridTemplate(classDatas));
            #endregion

            #region create modal
            sb.Append(AbpCreateModalHelper.CreateCreateModalTemplate(classDatas));
            #endregion

            #region edit modal
            sb.Append(AbpEditModalHelper.CreateEditModalTemplate(classDatas));
            #endregion


            return sb.ToString();
        }


        public string GenerateRazorPageTemplate(CreatedClassDatas classDatas, string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"@page \"/{classNameWithCamelCase}\"");
            sb.AppendLine("");
            sb.AppendLine($"@attribute [Authorize({classDatas.NamespaceName}Permissions.{folderName}.Default)]");
            sb.AppendLine($"@using {classDatas.NamespaceName}.{folderName}");
            sb.AppendLine($"@using {classDatas.NamespaceName}.Localization");
            sb.AppendLine($"@using {classDatas.NamespaceName}.Shared");
            sb.AppendLine("@using Microsoft.AspNetCore.Authorization");
            sb.AppendLine("@using Microsoft.Extensions.Localization");
            sb.AppendLine("@using Microsoft.AspNetCore.Components.Web");
            sb.AppendLine("@using Blazorise");
            sb.AppendLine("@using Blazorise.Components");
            sb.AppendLine("@using Blazorise.DataGrid");
            sb.AppendLine("@using Volo.Abp.BlazoriseUI");
            sb.AppendLine("@using Volo.Abp.BlazoriseUI.Components");
            sb.AppendLine("@using Volo.Abp.ObjectMapping");
            sb.AppendLine("@using Volo.Abp.AspNetCore.Components.Messages");
            sb.AppendLine("@using Volo.Abp.AspNetCore.Components.Web.Theming.Layout");
            sb.AppendLine("");
            sb.AppendLine($"@using {classDatas.NamespaceName}.Permissions");
            sb.AppendLine("@using Volo.Abp.AspNetCore.Components.Web");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"@inherits {classDatas.NamespaceName}ComponentBase");
            sb.AppendLine($"@inject I{folderName}AppService {folderName}AppService");
            sb.AppendLine("");
            sb.AppendLine("@inject IUiMessageService UiMessageService");
            sb.AppendLine($"@inject AbpBlazorMessageLocalizerHelper<{classDatas.NamespaceName}Resource> LH");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            #region page header
            sb.Append(AbpPageHeaderHelper.CreatePageHeaderTemplate(classDatas, folderName));
            #endregion

            #region search 
            sb.Append(AbpSearchComponentHelper.CreateSearchTemplate(classDatas, folderName));
            #endregion

            #region data grid
            sb.Append(DataGridHelper.CreateDataGridTemplate(classDatas));
            #endregion

            #region create modal
            sb.Append(AbpCreateModalHelper.CreateCreateModalTemplate(classDatas));
            #endregion

            #region edit modal
            sb.Append(AbpEditModalHelper.CreateEditModalTemplate(classDatas));
            #endregion


            return sb.ToString();
        }






    }
}
