using finSuite.InputClasses;

namespace finSuite.Generators.RazorPages
{
    public class RazorPageGenerator
    {
        public static void CreateRazorPageTemplateTextFile(ClassDatas classDatas, string folderName, string folderPath)
        {
            RazorPageTemplateGenerator razorPageTemplateGenerator = new RazorPageTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = razorPageTemplateGenerator.GenerateRazorPageTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\Pages\{folderName}\{folderName}.razor";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }


        public static void CreateRazorPageTemplateTextFile(CreatedClassDatas classDatas, string folderName, string folderPath)
        {
            RazorPageTemplateGenerator razorPageTemplateGenerator = new RazorPageTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = razorPageTemplateGenerator.GenerateRazorPageTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\Pages\{folderName}\{folderName}.razor";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }


    }
}
