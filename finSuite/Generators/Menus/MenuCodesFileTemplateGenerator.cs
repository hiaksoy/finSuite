using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Menus
{
    public class MenuCodesFileTemplateGenerator
    {
        public string GenerateBlazorLayerMenuFileTemplate(ClassDatas classDatas,string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Add this line of code to your Menu.cs file in blazor layer of your project");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine($"public const string {folderName} = Prefix + \".{folderName}\";");
            sb.AppendLine();
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Add this line of code to your MenuContributor.cs file in blazor layer of your project");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine("        context.Menu.AddItem(");
            sb.AppendLine("            new ApplicationMenuItem(");
            sb.AppendLine($"                {classDatas.NamespaceName}Menus.{folderName},");
            sb.AppendLine($"                l[\"Menu:{folderName}\"],");
            sb.AppendLine($"                url: \"/{classNameWithCamelCase}\",");
            sb.AppendLine("icon: \"fa fa-file-alt\",");
            sb.AppendLine($"                requiredPermissionName: {classDatas.NamespaceName}Permissions.{folderName}.Default)");
            sb.AppendLine("        );");
            sb.AppendLine();
            sb.AppendLine("--------------------------------------------------------------------------");


            return sb.ToString();
        }

        public string GenerateBlazorLayerMenuFileTemplate(CreatedClassDatas classDatas, string folderName)
        {
            var classNameWithCamelCase = char.ToLower(classDatas.ClassName[0], System.Globalization.CultureInfo.InvariantCulture) + classDatas.ClassName.Substring(1);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Add this line of code to your Menu.cs file in blazor layer of your project");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine($"public const string {folderName} = Prefix + \".{folderName}\";");
            sb.AppendLine();
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Add this line of code to your MenuContributor.cs file in blazor layer of your project");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine("        context.Menu.AddItem(");
            sb.AppendLine("            new ApplicationMenuItem(");
            sb.AppendLine($"                {classDatas.NamespaceName}Menus.{folderName},");
            sb.AppendLine($"                l[\"Menu:{folderName}\"],");
            sb.AppendLine($"                url: \"/{classNameWithCamelCase}\",");
            sb.AppendLine("icon: \"fa fa-file-alt\",");
            sb.AppendLine($"                requiredPermissionName: {classDatas.NamespaceName}Permissions.{folderName}.Default)");
            sb.AppendLine("        );");
            sb.AppendLine();
            sb.AppendLine("--------------------------------------------------------------------------");


            return sb.ToString();
        }



    }
}
