using finSuite.InputClasses;

namespace finSuite.Generators.Repositories
{
    public class RepositoryGenerator
    {
        public static void CreateRepositoryClassFile(ClassDatas classDatas, string folderPath, string folderName)
        {
            RepositoryTemplateGenerator repositoryTemplateGenerator = new RepositoryTemplateGenerator();
            // Repository sınıfını oluştur
            string repositoryClassContent = repositoryTemplateGenerator.GenerateRepositoryTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = @$"{folderPath}\{solutionName}.EntityFrameworkCore\{folderName}\EfCore{classDatas.ClassName}Repository.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, repositoryClassContent);
        }

        public static void CreateRepositoryClassFile(CreatedClassDatas createdClassDatas, string folderPath, string folderName)
        {
            RepositoryTemplateGenerator repositoryTemplateGenerator = new RepositoryTemplateGenerator();
            // Repository sınıfını oluştur
            string repositoryClassContent = repositoryTemplateGenerator.GenerateRepositoryTemplate(createdClassDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = @$"{folderPath}\{solutionName}.EntityFrameworkCore\{folderName}\EfCore{createdClassDatas.ClassName}Repository.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, repositoryClassContent);
        }
    }
}
