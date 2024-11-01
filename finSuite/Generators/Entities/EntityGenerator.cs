using finSuite.InputClasses;

namespace finSuite.Generators.Entities
{
    public class EntityGenerator
    {
        public static void CreateEntityClassFile(ClassDatas classDatas ,string folderPath, string folderName)
        {
            EntityTemplateGenerator entityTemplateGenerator = new EntityTemplateGenerator();
            // Manager sınıfını oluştur
            string entityClassContent = entityTemplateGenerator.GenerateEntityTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Domain\{folderName}\{classDatas.ClassName}.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, entityClassContent);
        }



        public static void CreateEntityClassFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            EntityTemplateGenerator entityTemplateGenerator = new EntityTemplateGenerator();
            // Manager sınıfını oluştur
            string entityClassContent = entityTemplateGenerator.GenerateEntityTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Domain\{folderName}\{classDatas.ClassName}.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, entityClassContent);
        }

    }
}
