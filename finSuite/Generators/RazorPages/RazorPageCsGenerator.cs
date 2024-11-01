using finSuite.InputClasses;

namespace finSuite.Generators.RazorPages
{
    public class RazorPageCsGenerator
    {
        public static void CreateRazorPageCsTemplateTextFile(ClassDatas classDatas, string folderName, string folderPath)
        {
            RazorPageCsTemplateGenerator razorPageCsTemplateGenerator = new RazorPageCsTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = razorPageCsTemplateGenerator.GenerateRazorPageCsTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\Pages\{folderName}\{folderName}.razor.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }

        public static void CreateRazorPageCsTemplateTextFile(CreatedClassDatas classDatas, string folderName, string folderPath)
        {
            RazorPageCsTemplateGenerator razorPageCsTemplateGenerator = new RazorPageCsTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = razorPageCsTemplateGenerator.GenerateRazorPageCsTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\Pages\{folderName}\{folderName}.razor.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }



    }
}
