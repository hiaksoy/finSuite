using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.RazorPages
{
    public class RazorPageCsTemplateGenerator
    {
        public string GenerateRazorPageCsTemplate(ClassDatas classDatas,string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.Globalization;");
            sb.AppendLine("using System.IO;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using Blazorise;");
            sb.AppendLine("using Blazorise.DataGrid;");
            sb.AppendLine("using Volo.Abp.BlazoriseUI.Components;");
            sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;");
            sb.AppendLine($"using {classDatas.NamespaceName}.{folderName};");
            sb.AppendLine($"using {classDatas.NamespaceName}.Permissions;");
            sb.AppendLine($"using {classDatas.NamespaceName}.Shared;");
            sb.AppendLine("using Microsoft.AspNetCore.Components.Forms;");
            sb.AppendLine("using Microsoft.AspNetCore.Components;");
            sb.AppendLine("using Microsoft.JSInterop;");
            sb.AppendLine("using Volo.Abp;");
            sb.AppendLine("using Volo.Abp.Content;");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"namespace {classDatas.NamespaceName}.Blazor.Pages.{folderName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {folderName}");
            sb.AppendLine("    {");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("            ");
            sb.AppendLine("        ");
            sb.AppendLine("            ");
            sb.AppendLine("        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();");
            sb.AppendLine("        protected PageToolbar Toolbar {get;} = new PageToolbar();");
            sb.AppendLine("        protected bool ShowAdvancedFilters { get; set; }");
            sb.AppendLine($"        private IReadOnlyList<{classDatas.ClassName}Dto> {classDatas.ClassName}List {{ get; set; }}");
            sb.AppendLine("        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;");
            sb.AppendLine("        private int CurrentPage { get; set; } = 1;");
            sb.AppendLine("        private string CurrentSorting { get; set; } = string.Empty;");
            sb.AppendLine("        private int TotalCount { get; set; }");
            sb.AppendLine($"        private bool CanCreate{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private bool CanEdit{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private bool CanDelete{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private {classDatas.ClassName}CreateDto New{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private Validations New{classDatas.ClassName}Validations {{ get; set; }} = new();");
            sb.AppendLine($"        private {classDatas.ClassName}UpdateDto Editing{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private Validations Editing{classDatas.ClassName}Validations {{ get; set; }} = new();");
            sb.AppendLine($"        private Guid Editing{classDatas.ClassName}Id {{ get; set; }}");
            sb.AppendLine($"        private Modal Create{classDatas.ClassName}Modal {{ get; set; }} = new();");
            sb.AppendLine($"        private Modal Edit{classDatas.ClassName}Modal {{ get; set; }} = new();");
            sb.AppendLine($"        private Get{folderName}Input Filter {{ get; set; }}");
            sb.AppendLine($"        private DataGridEntityActionsColumn<{classDatas.ClassName}Dto> EntityActionsColumn {{ get; set; }} = new();");
            sb.AppendLine($"        protected string SelectedCreateTab = \"{classNameWithCamelCase}-create-tab\";");
            sb.AppendLine($"        protected string SelectedEditTab = \"{classNameWithCamelCase}-edit-tab\";");
            sb.AppendLine($"        private {classDatas.ClassName}Dto? Selected{classDatas.ClassName};");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine($"        public {folderName}()");
            sb.AppendLine("        {");
            sb.AppendLine($"            New{classDatas.ClassName} = new {classDatas.ClassName}CreateDto();");
            sb.AppendLine($"            Editing{classDatas.ClassName} = new {classDatas.ClassName}UpdateDto();");
            sb.AppendLine($"            Filter = new Get{folderName}Input");
            sb.AppendLine("            {");
            sb.AppendLine("                MaxResultCount = PageSize,");
            sb.AppendLine("                SkipCount = (CurrentPage - 1) * PageSize,");
            sb.AppendLine("                Sorting = CurrentSorting");
            sb.AppendLine("            };");
            sb.AppendLine($"            {classDatas.ClassName}List = new List<{classDatas.ClassName}Dto>();");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected override async Task OnInitializedAsync()");
            sb.AppendLine("        {");
            sb.AppendLine("            await SetPermissionsAsync();");
            sb.AppendLine("            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected override async Task OnAfterRenderAsync(bool firstRender)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (firstRender)");
            sb.AppendLine("            {");
            sb.AppendLine("                ");
            sb.AppendLine("                await SetBreadcrumbItemsAsync();");
            sb.AppendLine("                await SetToolbarItemsAsync();");
            sb.AppendLine("                await InvokeAsync(StateHasChanged);");
            sb.AppendLine("            }");
            sb.AppendLine("        }  ");
            sb.AppendLine("");
            sb.AppendLine("        protected virtual ValueTask SetBreadcrumbItemsAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L[\"{folderName}\"]));");
            sb.AppendLine("            return ValueTask.CompletedTask;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected virtual ValueTask SetToolbarItemsAsync()");
            sb.AppendLine("        {");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine($"            Toolbar.AddButton(L[\"New{classDatas.ClassName}\"], async () =>");
            sb.AppendLine("            {");
            sb.AppendLine($"                await OpenCreate{classDatas.ClassName}ModalAsync();");
            sb.AppendLine($"            }}, IconName.Add, requiredPolicyName: {classDatas.NamespaceName}Permissions.{folderName}.Create);");
            sb.AppendLine("");
            sb.AppendLine("            return ValueTask.CompletedTask;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private async Task SetPermissionsAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            CanCreate{classDatas.ClassName} = await AuthorizationService");
            sb.AppendLine($"                .IsGrantedAsync({classDatas.NamespaceName}Permissions.{folderName}.Create);");
            sb.AppendLine($"            CanEdit{classDatas.ClassName} = await AuthorizationService");
            sb.AppendLine($"                            .IsGrantedAsync({classDatas.NamespaceName}Permissions.{folderName}.Edit);");
            sb.AppendLine($"            CanDelete{classDatas.ClassName} = await AuthorizationService");
            sb.AppendLine($"                            .IsGrantedAsync({classDatas.NamespaceName}Permissions.{folderName}.Delete);");
            sb.AppendLine("                            ");
            sb.AppendLine("                            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Get{folderName}Async()");
            sb.AppendLine("        {");
            sb.AppendLine("            Filter.MaxResultCount = PageSize;");
            sb.AppendLine("            Filter.SkipCount = (CurrentPage - 1) * PageSize;");
            sb.AppendLine("            Filter.Sorting = CurrentSorting;");
            sb.AppendLine("");
            sb.AppendLine($"            var result = await {folderName}AppService.GetListAsync(Filter);");
            sb.AppendLine($"            {classDatas.ClassName}List = result.Items;");
            sb.AppendLine("            TotalCount = (int)result.TotalCount;");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected virtual async Task SearchAsync()");
            sb.AppendLine("        {");
            sb.AppendLine("            CurrentPage = 1;");
            sb.AppendLine($"            await Get{folderName}Async();");
            sb.AppendLine("            await InvokeAsync(StateHasChanged);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<{classDatas.ClassName}Dto> e)");
            sb.AppendLine("        {");
            sb.AppendLine("            CurrentSorting = e.Columns");
            sb.AppendLine("                .Where(c => c.SortDirection != SortDirection.Default)");
            sb.AppendLine("                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? \" DESC\" : \"\"))");
            sb.AppendLine("                .JoinAsString(\",\");");
            sb.AppendLine("            CurrentPage = e.Page;");
            sb.AppendLine($"            await Get{folderName}Async();");
            sb.AppendLine("            await InvokeAsync(StateHasChanged);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task OpenCreate{classDatas.ClassName}ModalAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            New{classDatas.ClassName} = new {classDatas.ClassName}CreateDto{{");

            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);


                if (type == "DateTime")
                {
                    sb.AppendLine($"                {name} = DateTime.Now,");

                }
                if (type == "DateOnly")
                {
                    sb.AppendLine($"{name} = DateOnly.FromDateTime(DateTime.Now),");

                }
            }


            sb.AppendLine("");
            sb.AppendLine("                ");
            sb.AppendLine("            };");
            sb.AppendLine("");
            sb.AppendLine($"            SelectedCreateTab = \"{classNameWithCamelCase}-create-tab\";");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine($"            await New{classDatas.ClassName}Validations.ClearAll();");
            sb.AppendLine($"            await Create{classDatas.ClassName}Modal.Show();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task CloseCreate{classDatas.ClassName}ModalAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            New{classDatas.ClassName} = new {classDatas.ClassName}CreateDto{{");


            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);


                if (type == "DateTime")
                {
                    sb.AppendLine($"                {name} = DateTime.Now,");

                }
                if (type == "DateOnly")
                {
                    sb.AppendLine($"{name} = DateOnly.FromDateTime(DateTime.Now),");

                }
            }


            sb.AppendLine("");
            sb.AppendLine("                ");
            sb.AppendLine("            };");
            sb.AppendLine($"            await Create{classDatas.ClassName}Modal.Hide();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task OpenEdit{classDatas.ClassName}ModalAsync({classDatas.ClassName}Dto input)");
            sb.AppendLine("        {");
            sb.AppendLine($"            SelectedEditTab = \"{classNameWithCamelCase}-edit-tab\";");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine($"            var {classNameWithCamelCase} = await {folderName}AppService.GetAsync(input.Id);");
            sb.AppendLine("            ");
            sb.AppendLine($"            Editing{classDatas.ClassName}Id = {classNameWithCamelCase}.Id;");
            sb.AppendLine($"            Editing{classDatas.ClassName} = ObjectMapper.Map<{classDatas.ClassName}Dto, {classDatas.ClassName}UpdateDto>({classNameWithCamelCase});");
            sb.AppendLine("            ");
            sb.AppendLine($"            await Editing{classDatas.ClassName}Validations.ClearAll();");
            sb.AppendLine($"            await Edit{classDatas.ClassName}Modal.Show();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Delete{classDatas.ClassName}Async({classDatas.ClassName}Dto input)");
            sb.AppendLine("        {");
            sb.AppendLine($"            await {folderName}AppService.DeleteAsync(input.Id);");
            sb.AppendLine($"            await Get{folderName}Async();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Create{classDatas.ClassName}Async()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine($"                if (await New{classDatas.ClassName}Validations.ValidateAll() == false)");
            sb.AppendLine("                {");
            sb.AppendLine("                    return;");
            sb.AppendLine("                }");
            sb.AppendLine("");
            sb.AppendLine($"                await {folderName}AppService.CreateAsync(New{classDatas.ClassName});");
            sb.AppendLine($"                await Get{folderName}Async();");
            sb.AppendLine($"                await CloseCreate{classDatas.ClassName}ModalAsync();");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                await HandleErrorAsync(ex);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task CloseEdit{classDatas.ClassName}ModalAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            await Edit{classDatas.ClassName}Modal.Hide();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Update{classDatas.ClassName}Async()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine($"                if (await Editing{classDatas.ClassName}Validations.ValidateAll() == false)");
            sb.AppendLine("                {");
            sb.AppendLine("                    return;");
            sb.AppendLine("                }");
            sb.AppendLine("");
            sb.AppendLine($"                await {folderName}AppService.UpdateAsync(Editing{classDatas.ClassName}Id, Editing{classDatas.ClassName});");
            sb.AppendLine($"                await Get{folderName}Async();");
            sb.AppendLine($"                await Edit{classDatas.ClassName}Modal.Hide();                ");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                await HandleErrorAsync(ex);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private void OnSelectedCreateTabChanged(string name)");
            sb.AppendLine("        {");
            sb.AppendLine("            SelectedCreateTab = name;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private void OnSelectedEditTabChanged(string name)");
            sb.AppendLine("        {");
            sb.AppendLine("            SelectedEditTab = name;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");


            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "byte" ||
                    type == "DateOnly" ||
                    type == "decimal" ||
                    type == "double" ||
                    type == "float" ||
                    type == "int" ||
                    type == "long" ||
                    type == "sbyte" ||
                    type == "TimeOnly" ||
                    type == "uint" ||
                    type == "ulong" ||
                    type == "ushort")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}MinChangedAsync({type}? {name}Min)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Min = {name}Min;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                    sb.AppendLine($"        protected virtual async Task On{name}MaxChangedAsync({type}? {name}Max)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Max = {name}Max;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");

                }


                if (type == "byte?" ||
                    type == "DateOnly?" ||
                    type == "decimal?" ||
                    type == "double?" ||
                    type == "float?" ||
                    type == "int?" ||
                    type == "long?" ||
                    type == "sbyte?" ||
                    type == "TimeOnly?" ||
                    type == "uint?" ||
                    type == "ulong?" ||
                    type == "ushort?")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}MinChangedAsync({type} {name}Min)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Min = {name}Min;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                    sb.AppendLine($"        protected virtual async Task On{name}MaxChangedAsync({type} {name}Max)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Max = {name}Max;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");

                }

                else if (type == "DateTime")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}MinChangedAsync(DateTime? {name}Min)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Min = {name}Min.HasValue ? {name}Min.Value.Date : {name}Min;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                    sb.AppendLine($"        protected virtual async Task On{name}MaxChangedAsync(DateTime? {name}Max)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Max = {name}Max.HasValue ? {name}Max.Value.Date.AddDays(1).AddSeconds(-1) : {name}Max;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                }

                else if (type == "string" || type == "string?")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}ChangedAsync(string? {name})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name} = {name};");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                }

                else if (type == "bool" || type == "bool?")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}ChangedAsync(bool? {name})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name} = {name};");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                }

            }





            sb.AppendLine("        ");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");


            return sb.ToString();
        }




        public string GenerateRazorPageCsTemplate(CreatedClassDatas classDatas, string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.Globalization;");
            sb.AppendLine("using System.IO;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using Blazorise;");
            sb.AppendLine("using Blazorise.DataGrid;");
            sb.AppendLine("using Volo.Abp.BlazoriseUI.Components;");
            sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
            sb.AppendLine("using Volo.Abp.Application.Dtos;");
            sb.AppendLine("using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;");
            sb.AppendLine($"using {classDatas.NamespaceName}.{folderName};");
            sb.AppendLine($"using {classDatas.NamespaceName}.Permissions;");
            sb.AppendLine($"using {classDatas.NamespaceName}.Shared;");
            sb.AppendLine("using Microsoft.AspNetCore.Components.Forms;");
            sb.AppendLine("using Microsoft.AspNetCore.Components;");
            sb.AppendLine("using Microsoft.JSInterop;");
            sb.AppendLine("using Volo.Abp;");
            sb.AppendLine("using Volo.Abp.Content;");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"namespace {classDatas.NamespaceName}.Blazor.Pages.{folderName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {folderName}");
            sb.AppendLine("    {");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("            ");
            sb.AppendLine("        ");
            sb.AppendLine("            ");
            sb.AppendLine("        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();");
            sb.AppendLine("        protected PageToolbar Toolbar {get;} = new PageToolbar();");
            sb.AppendLine("        protected bool ShowAdvancedFilters { get; set; }");
            sb.AppendLine($"        private IReadOnlyList<{classDatas.ClassName}Dto> {classDatas.ClassName}List {{ get; set; }}");
            sb.AppendLine("        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;");
            sb.AppendLine("        private int CurrentPage { get; set; } = 1;");
            sb.AppendLine("        private string CurrentSorting { get; set; } = string.Empty;");
            sb.AppendLine("        private int TotalCount { get; set; }");
            sb.AppendLine($"        private bool CanCreate{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private bool CanEdit{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private bool CanDelete{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private {classDatas.ClassName}CreateDto New{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private Validations New{classDatas.ClassName}Validations {{ get; set; }} = new();");
            sb.AppendLine($"        private {classDatas.ClassName}UpdateDto Editing{classDatas.ClassName} {{ get; set; }}");
            sb.AppendLine($"        private Validations Editing{classDatas.ClassName}Validations {{ get; set; }} = new();");
            sb.AppendLine($"        private Guid Editing{classDatas.ClassName}Id {{ get; set; }}");
            sb.AppendLine($"        private Modal Create{classDatas.ClassName}Modal {{ get; set; }} = new();");
            sb.AppendLine($"        private Modal Edit{classDatas.ClassName}Modal {{ get; set; }} = new();");
            sb.AppendLine($"        private Get{folderName}Input Filter {{ get; set; }}");
            sb.AppendLine($"        private DataGridEntityActionsColumn<{classDatas.ClassName}Dto> EntityActionsColumn {{ get; set; }} = new();");
            sb.AppendLine($"        protected string SelectedCreateTab = \"{classNameWithCamelCase}-create-tab\";");
            sb.AppendLine($"        protected string SelectedEditTab = \"{classNameWithCamelCase}-edit-tab\";");
            sb.AppendLine($"        private {classDatas.ClassName}Dto? Selected{classDatas.ClassName};");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine("        ");
            sb.AppendLine($"        public {folderName}()");
            sb.AppendLine("        {");
            sb.AppendLine($"            New{classDatas.ClassName} = new {classDatas.ClassName}CreateDto();");
            sb.AppendLine($"            Editing{classDatas.ClassName} = new {classDatas.ClassName}UpdateDto();");
            sb.AppendLine($"            Filter = new Get{folderName}Input");
            sb.AppendLine("            {");
            sb.AppendLine("                MaxResultCount = PageSize,");
            sb.AppendLine("                SkipCount = (CurrentPage - 1) * PageSize,");
            sb.AppendLine("                Sorting = CurrentSorting");
            sb.AppendLine("            };");
            sb.AppendLine($"            {classDatas.ClassName}List = new List<{classDatas.ClassName}Dto>();");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected override async Task OnInitializedAsync()");
            sb.AppendLine("        {");
            sb.AppendLine("            await SetPermissionsAsync();");
            sb.AppendLine("            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected override async Task OnAfterRenderAsync(bool firstRender)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (firstRender)");
            sb.AppendLine("            {");
            sb.AppendLine("                ");
            sb.AppendLine("                await SetBreadcrumbItemsAsync();");
            sb.AppendLine("                await SetToolbarItemsAsync();");
            sb.AppendLine("                await InvokeAsync(StateHasChanged);");
            sb.AppendLine("            }");
            sb.AppendLine("        }  ");
            sb.AppendLine("");
            sb.AppendLine("        protected virtual ValueTask SetBreadcrumbItemsAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L[\"{folderName}\"]));");
            sb.AppendLine("            return ValueTask.CompletedTask;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected virtual ValueTask SetToolbarItemsAsync()");
            sb.AppendLine("        {");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine($"            Toolbar.AddButton(L[\"New{classDatas.ClassName}\"], async () =>");
            sb.AppendLine("            {");
            sb.AppendLine($"                await OpenCreate{classDatas.ClassName}ModalAsync();");
            sb.AppendLine($"            }}, IconName.Add, requiredPolicyName: {classDatas.NamespaceName}Permissions.{folderName}.Create);");
            sb.AppendLine("");
            sb.AppendLine("            return ValueTask.CompletedTask;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private async Task SetPermissionsAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            CanCreate{classDatas.ClassName} = await AuthorizationService");
            sb.AppendLine($"                .IsGrantedAsync({classDatas.NamespaceName}Permissions.{folderName}.Create);");
            sb.AppendLine($"            CanEdit{classDatas.ClassName} = await AuthorizationService");
            sb.AppendLine($"                            .IsGrantedAsync({classDatas.NamespaceName}Permissions.{folderName}.Edit);");
            sb.AppendLine($"            CanDelete{classDatas.ClassName} = await AuthorizationService");
            sb.AppendLine($"                            .IsGrantedAsync({classDatas.NamespaceName}Permissions.{folderName}.Delete);");
            sb.AppendLine("                            ");
            sb.AppendLine("                            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Get{folderName}Async()");
            sb.AppendLine("        {");
            sb.AppendLine("            Filter.MaxResultCount = PageSize;");
            sb.AppendLine("            Filter.SkipCount = (CurrentPage - 1) * PageSize;");
            sb.AppendLine("            Filter.Sorting = CurrentSorting;");
            sb.AppendLine("");
            sb.AppendLine($"            var result = await {folderName}AppService.GetListAsync(Filter);");
            sb.AppendLine($"            {classDatas.ClassName}List = result.Items;");
            sb.AppendLine("            TotalCount = (int)result.TotalCount;");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected virtual async Task SearchAsync()");
            sb.AppendLine("        {");
            sb.AppendLine("            CurrentPage = 1;");
            sb.AppendLine($"            await Get{folderName}Async();");
            sb.AppendLine("            await InvokeAsync(StateHasChanged);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<{classDatas.ClassName}Dto> e)");
            sb.AppendLine("        {");
            sb.AppendLine("            CurrentSorting = e.Columns");
            sb.AppendLine("                .Where(c => c.SortDirection != SortDirection.Default)");
            sb.AppendLine("                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? \" DESC\" : \"\"))");
            sb.AppendLine("                .JoinAsString(\",\");");
            sb.AppendLine("            CurrentPage = e.Page;");
            sb.AppendLine($"            await Get{folderName}Async();");
            sb.AppendLine("            await InvokeAsync(StateHasChanged);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task OpenCreate{classDatas.ClassName}ModalAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            New{classDatas.ClassName} = new {classDatas.ClassName}CreateDto{{");

            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);


                if (type == "DateTime")
                {
                    sb.AppendLine($"                {name} = DateTime.Now,");

                }
                if (type == "DateOnly")
                {
                    sb.AppendLine($"{name} = DateOnly.FromDateTime(DateTime.Now),");

                }
            }


            sb.AppendLine("");
            sb.AppendLine("                ");
            sb.AppendLine("            };");
            sb.AppendLine("");
            sb.AppendLine($"            SelectedCreateTab = \"{classNameWithCamelCase}-create-tab\";");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine($"            await New{classDatas.ClassName}Validations.ClearAll();");
            sb.AppendLine($"            await Create{classDatas.ClassName}Modal.Show();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task CloseCreate{classDatas.ClassName}ModalAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            New{classDatas.ClassName} = new {classDatas.ClassName}CreateDto{{");


            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);


                if (type == "DateTime")
                {
                    sb.AppendLine($"                {name} = DateTime.Now,");

                }
                if (type == "DateOnly")
                {
                    sb.AppendLine($"{name} = DateOnly.FromDateTime(DateTime.Now),");

                }
            }


            sb.AppendLine("");
            sb.AppendLine("                ");
            sb.AppendLine("            };");
            sb.AppendLine($"            await Create{classDatas.ClassName}Modal.Hide();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task OpenEdit{classDatas.ClassName}ModalAsync({classDatas.ClassName}Dto input)");
            sb.AppendLine("        {");
            sb.AppendLine($"            SelectedEditTab = \"{classNameWithCamelCase}-edit-tab\";");
            sb.AppendLine("            ");
            sb.AppendLine("            ");
            sb.AppendLine($"            var {classNameWithCamelCase} = await {folderName}AppService.GetAsync(input.Id);");
            sb.AppendLine("            ");
            sb.AppendLine($"            Editing{classDatas.ClassName}Id = {classNameWithCamelCase}.Id;");
            sb.AppendLine($"            Editing{classDatas.ClassName} = ObjectMapper.Map<{classDatas.ClassName}Dto, {classDatas.ClassName}UpdateDto>({classNameWithCamelCase});");
            sb.AppendLine("            ");
            sb.AppendLine($"            await Editing{classDatas.ClassName}Validations.ClearAll();");
            sb.AppendLine($"            await Edit{classDatas.ClassName}Modal.Show();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Delete{classDatas.ClassName}Async({classDatas.ClassName}Dto input)");
            sb.AppendLine("        {");
            sb.AppendLine($"            await {folderName}AppService.DeleteAsync(input.Id);");
            sb.AppendLine($"            await Get{folderName}Async();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Create{classDatas.ClassName}Async()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine($"                if (await New{classDatas.ClassName}Validations.ValidateAll() == false)");
            sb.AppendLine("                {");
            sb.AppendLine("                    return;");
            sb.AppendLine("                }");
            sb.AppendLine("");
            sb.AppendLine($"                await {folderName}AppService.CreateAsync(New{classDatas.ClassName});");
            sb.AppendLine($"                await Get{folderName}Async();");
            sb.AppendLine($"                await CloseCreate{classDatas.ClassName}ModalAsync();");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                await HandleErrorAsync(ex);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task CloseEdit{classDatas.ClassName}ModalAsync()");
            sb.AppendLine("        {");
            sb.AppendLine($"            await Edit{classDatas.ClassName}Modal.Hide();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine($"        private async Task Update{classDatas.ClassName}Async()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine($"                if (await Editing{classDatas.ClassName}Validations.ValidateAll() == false)");
            sb.AppendLine("                {");
            sb.AppendLine("                    return;");
            sb.AppendLine("                }");
            sb.AppendLine("");
            sb.AppendLine($"                await {folderName}AppService.UpdateAsync(Editing{classDatas.ClassName}Id, Editing{classDatas.ClassName});");
            sb.AppendLine($"                await Get{folderName}Async();");
            sb.AppendLine($"                await Edit{classDatas.ClassName}Modal.Hide();                ");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                await HandleErrorAsync(ex);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private void OnSelectedCreateTabChanged(string name)");
            sb.AppendLine("        {");
            sb.AppendLine("            SelectedCreateTab = name;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private void OnSelectedEditTabChanged(string name)");
            sb.AppendLine("        {");
            sb.AppendLine("            SelectedEditTab = name;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");


            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "byte" ||
                    type == "DateOnly" ||
                    type == "decimal" ||
                    type == "double" ||
                    type == "float" ||
                    type == "int" ||
                    type == "long" ||
                    type == "sbyte" ||
                    type == "TimeOnly" ||
                    type == "uint" ||
                    type == "ulong" ||
                    type == "ushort")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}MinChangedAsync({type}? {name}Min)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Min = {name}Min;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                    sb.AppendLine($"        protected virtual async Task On{name}MaxChangedAsync({type}? {name}Max)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Max = {name}Max;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");

                }


                if (type == "byte?" ||
                    type == "DateOnly?" ||
                    type == "decimal?" ||
                    type == "double?" ||
                    type == "float?" ||
                    type == "int?" ||
                    type == "long?" ||
                    type == "sbyte?" ||
                    type == "TimeOnly?" ||
                    type == "uint?" ||
                    type == "ulong?" ||
                    type == "ushort?")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}MinChangedAsync({type} {name}Min)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Min = {name}Min;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                    sb.AppendLine($"        protected virtual async Task On{name}MaxChangedAsync({type} {name}Max)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Max = {name}Max;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");

                }

                else if (type == "DateTime")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}MinChangedAsync(DateTime? {name}Min)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Min = {name}Min.HasValue ? {name}Min.Value.Date : {name}Min;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                    sb.AppendLine($"        protected virtual async Task On{name}MaxChangedAsync(DateTime? {name}Max)");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name}Max = {name}Max.HasValue ? {name}Max.Value.Date.AddDays(1).AddSeconds(-1) : {name}Max;");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                }

                else if (type == "string" || type == "string?")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}ChangedAsync(string? {name})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name} = {name};");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                }

                else if (type == "bool" || type == "bool?")
                {
                    sb.AppendLine($"        protected virtual async Task On{name}ChangedAsync(bool? {name})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            Filter.{name} = {name};");
                    sb.AppendLine("            await SearchAsync();");
                    sb.AppendLine("        }");
                }

            }





            sb.AppendLine("        ");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");


            return sb.ToString();
        }

    }
}
