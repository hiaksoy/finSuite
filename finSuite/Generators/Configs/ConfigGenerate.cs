using finSuite.InputClasses;

namespace finSuite.Generators.Configs
{
    public class ConfigGenerate
    {
        public static void CreateConfigClassFile(ClassDatas classDatas, string folderPath, string folderName)
        {
            ConfigTemplateGenerator configTemplateGenerator = new ConfigTemplateGenerator();
            // Manager sınıfını oluştur
            string configContent = configTemplateGenerator.GenerateConfigTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.EntityFrameworkCore\EFCustomConfigurations\{folderName}\{folderName}Configuration.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, configContent);
        }



        public static void CreateConfigClassFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            ConfigTemplateGenerator configTemplateGenerator = new ConfigTemplateGenerator();
            // Manager sınıfını oluştur
            string configContent = configTemplateGenerator.GenerateConfigTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.EntityFrameworkCore\EFCustomConfigurations\{folderName}\{folderName}Configuration.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, configContent);
        }

    }

}
