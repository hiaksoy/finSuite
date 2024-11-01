using finSuite.InputClasses;

namespace finSuite.Generators.Permissions
{
    public class PermissonGenerator
    {

        public static void CreateApplicationContractsPermissionsAddonsTextFile(ClassDatas classDatas, string folderName, string folderPath)
        {
            PermissionTemplateGenerator permissionTemplateGenerator = new PermissionTemplateGenerator();
            // Manager sınıfını oluştur
            string permissionsContent = permissionTemplateGenerator.GenerateApplicationContractsPermissionsAddons(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Application.Contracts\Permissions\{folderName}Permissions.txt";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, permissionsContent);
        }

        public static void CreateApplicationContractsPermissionsAddonsTextFile(CreatedClassDatas classDatas, string folderName, string folderPath)
        {
            PermissionTemplateGenerator permissionTemplateGenerator = new PermissionTemplateGenerator();
            // Manager sınıfını oluştur
            string permissionsContent = permissionTemplateGenerator.GenerateApplicationContractsPermissionsAddons(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Application.Contracts\Permissions\{folderName}Permissions.txt";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, permissionsContent);
        }



    }
}
