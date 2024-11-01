using finSuite.InputClasses;

namespace finSuite.Generators.Managers
{
    public class ManagerGenerator
    {
        public static void CreateManagerClassFile(ClassDatas classDatas ,string folderPath, string folderName)
        {
            ManagerTemplateGenerator managerTemplateGenerator = new ManagerTemplateGenerator();
            // Manager sınıfını oluştur
            string managerClassContent = managerTemplateGenerator.GenerateManagerTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Domain\{folderName}\{classDatas.ClassName}Manager.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, managerClassContent);
        }


        public static void CreateManagerClassFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            ManagerTemplateGenerator managerTemplateGenerator = new ManagerTemplateGenerator();
            // Manager sınıfını oluştur
            string managerClassContent = managerTemplateGenerator.GenerateManagerTemplate(classDatas);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Domain\{folderName}\{classDatas.ClassName}Manager.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, managerClassContent);
        }

    }
}
