using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Permissions
{
    public class PermissionTemplateGenerator
    {
        public string GenerateApplicationContractsPermissionsAddons(ClassDatas classDatas,string folderName)
        {
            StringBuilder sb = new();

            sb.AppendLine("//Add these codes to the Permissions.cs file in the Application.Contracts\\Permissions Layer of your solution.");
            sb.AppendLine();

            sb.AppendLine($"public static class {folderName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public const string Default = NamespaceName + \".{folderName}\";");
            sb.AppendLine($"    public const string Edit = Default + \".Edit\";");
            sb.AppendLine($"    public const string Create = Default + \".Create\";");
            sb.AppendLine($"    public const string Delete = Default + \".Delete\";");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("//Add these codes to the PermissionDefinitionProvider.cs file in the Application.Contracts\\Permissions Layer of your solution.");
            sb.AppendLine();
            sb.AppendLine($" var {classDatas.ClassName}Permission = myGroup.AddPermission({classDatas.NamespaceName}Permissions.{folderName}.Default, L(\"Permission:{folderName}\"));");
            sb.AppendLine($"{classDatas.ClassName}Permission.AddChild({classDatas.NamespaceName}Permissions.{folderName}.Create, L(\"Permission:Create\"));");
            sb.AppendLine($"{classDatas.ClassName}Permission.AddChild({classDatas.NamespaceName}Permissions.{folderName}.Edit, L(\"Permission:Edit\"));");
            sb.AppendLine($"{classDatas.ClassName}Permission.AddChild({classDatas.NamespaceName}Permissions.{folderName}.Delete, L(\"Permission:Delete\"));");




            return sb.ToString();

        }

        public string GenerateApplicationContractsPermissionsAddons(CreatedClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new();

            sb.AppendLine("//Add these codes to the Permissions.cs file in the Application.Contracts\\Permissions Layer of your solution.");
            sb.AppendLine();

            sb.AppendLine($"public static class {folderName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public const string Default = NamespaceName + \".{folderName}\";");
            sb.AppendLine($"    public const string Edit = Default + \".Edit\";");
            sb.AppendLine($"    public const string Create = Default + \".Create\";");
            sb.AppendLine($"    public const string Delete = Default + \".Delete\";");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("//Add these codes to the PermissionDefinitionProvider.cs file in the Application.Contracts\\Permissions Layer of your solution.");
            sb.AppendLine();
            sb.AppendLine($" var {classDatas.ClassName}Permission = myGroup.AddPermission({classDatas.NamespaceName}Permissions.{folderName}.Default, L(\"Permission:{folderName}\"));");
            sb.AppendLine($"{classDatas.ClassName}Permission.AddChild({classDatas.NamespaceName}Permissions.{folderName}.Create, L(\"Permission:Create\"));");
            sb.AppendLine($"{classDatas.ClassName}Permission.AddChild({classDatas.NamespaceName}Permissions.{folderName}.Edit, L(\"Permission:Edit\"));");
            sb.AppendLine($"{classDatas.ClassName}Permission.AddChild({classDatas.NamespaceName}Permissions.{folderName}.Delete, L(\"Permission:Delete\"));");




            return sb.ToString();

        }




    }
}
