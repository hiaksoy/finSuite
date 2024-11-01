namespace finSuite.Generators.RazorPages
{
    public class RazorPageJsGenerator
    {
        public static void CreateRazorPageJsTemplateTextFile(string folderName, string folderPath)
        {
            RazorPageJsTemplateGenerator razorPageJsTemplateGenerator = new RazorPageJsTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = razorPageJsTemplateGenerator.GenerateRazorPageJsTemplate();

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\Pages\{folderName}\{folderName}.razor.js";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }
    }
}
