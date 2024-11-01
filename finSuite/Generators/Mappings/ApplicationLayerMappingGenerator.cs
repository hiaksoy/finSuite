using finSuite.InputClasses;

namespace finSuite.Generators.Mappings
{
    public class ApplicationLayerMappingGenerator
    {
        public static void CreateApplicationLayerMappingFile(ClassDatas classDatas , string folderPath, string folderName)
        {
            ApplicationLayerMappingTemplateGenerator templateGenerator = new ApplicationLayerMappingTemplateGenerator();
            // Manager sınıfını oluştur
            string mappingContent = templateGenerator.GenerateApplicationLayerMappingFileTemplate(classDatas ,folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Application\MapperProfiler\{classDatas.ClassName}Mapping.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, mappingContent);
        }


        public static void CreateApplicationLayerMappingFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            ApplicationLayerMappingTemplateGenerator templateGenerator = new ApplicationLayerMappingTemplateGenerator();
            // Manager sınıfını oluştur
            string mappingContent = templateGenerator.GenerateApplicationLayerMappingFileTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Application\MapperProfiler\{classDatas.ClassName}Mapping.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, mappingContent);
        }

    }
}
