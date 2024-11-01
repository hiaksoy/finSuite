using finSuite.InputClasses;

namespace finSuite.Generators.IRepositories
{
    public class IRepositoryGenerator
    {

        public static void CreateRepositoryInterfaceFile(ClassDatas classDatas,string folderPath, string folderName)
        {
            IRepositoryTemplateGenerator repositoryTemplateGenerator = new IRepositoryTemplateGenerator();
            // Manager sınıfını oluştur
            string repositoryInterfaceContent = repositoryTemplateGenerator.GenerateRepositoryInterfaceTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Domain\{folderName}\I{classDatas.ClassName}Repository.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, repositoryInterfaceContent);
        }


        public static void CreateRepositoryInterfaceFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            IRepositoryTemplateGenerator repositoryTemplateGenerator = new IRepositoryTemplateGenerator();
            // Manager sınıfını oluştur
            string repositoryInterfaceContent = repositoryTemplateGenerator.GenerateRepositoryInterfaceTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Domain\{folderName}\I{classDatas.ClassName}Repository.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, repositoryInterfaceContent);
        }

    }
}
