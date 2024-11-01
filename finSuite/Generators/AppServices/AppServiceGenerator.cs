using finSuite.InputClasses;

namespace finSuite.Generators.AppServices
{
    public class AppServiceGenerator
    {

        public static void CreateEntityAppServiceFile(ClassDatas classDatas,string folderPath, string folderName)
        {
            AppServiceTemplateGenerator appServiceTemplateGenerator = new AppServiceTemplateGenerator();
            // Manager sınıfını oluştur
            string entityAppServiceContent = appServiceTemplateGenerator.GenerateEntityAppServiceTemplate(classDatas ,folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Application\{folderName}\{folderName}AppService.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, entityAppServiceContent);
        }

        public static void CreateEntityAppServiceFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            AppServiceTemplateGenerator appServiceTemplateGenerator = new AppServiceTemplateGenerator();
            // Manager sınıfını oluştur
            string entityAppServiceContent = appServiceTemplateGenerator.GenerateEntityAppServiceTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Application\{folderName}\{folderName}AppService.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, entityAppServiceContent);
        }


    }
}
