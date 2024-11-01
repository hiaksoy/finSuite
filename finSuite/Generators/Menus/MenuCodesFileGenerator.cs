using finSuite.InputClasses;

namespace finSuite.Generators.Menus
{
    public class MenuCodesFileGenerator
    {
        public static void CreateBlazorLayerMenuFileTemplateTextFile(ClassDatas classDatas,string folderName, string folderPath)
        {
            MenuCodesFileTemplateGenerator menuCodesFileTemplateGenerator = new MenuCodesFileTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = menuCodesFileTemplateGenerator.GenerateBlazorLayerMenuFileTemplate(classDatas ,folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\{classDatas.NamespaceName}MenusREADME.txt";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }

        public static void CreateBlazorLayerMenuFileTemplateTextFile(CreatedClassDatas classDatas, string folderName, string folderPath)
        {
            MenuCodesFileTemplateGenerator menuCodesFileTemplateGenerator = new MenuCodesFileTemplateGenerator();
            // Manager sınıfını oluştur
            string razorPageContent = menuCodesFileTemplateGenerator.GenerateBlazorLayerMenuFileTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\{classDatas.NamespaceName}MenusREADME.txt";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, razorPageContent);
        }


    }
}
