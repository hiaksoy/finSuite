using finSuite.InputClasses;

namespace finSuite.Generators.Mappings
{
    public class BlazorLayerMappingGenerator
    {
        public static void CreateBlazorLayerMappingFile(ClassDatas classDatas,string folderPath, string folderName)
        {
            BlazorLayerMappingTemplateGenerator blazorLayerMappingTemplateGenerator = new BlazorLayerMappingTemplateGenerator();
            // Manager sınıfını oluştur
            string mappingContent = blazorLayerMappingTemplateGenerator.GenerateBlazorLayerMappingFileTemplate(classDatas ,folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\MapperProfilers\{classDatas.ClassName}Mapping.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, mappingContent);
        }


        public static void CreateBlazorLayerMappingFile(CreatedClassDatas classDatas, string folderPath, string folderName)
        {
            BlazorLayerMappingTemplateGenerator blazorLayerMappingTemplateGenerator = new BlazorLayerMappingTemplateGenerator();
            // Manager sınıfını oluştur
            string mappingContent = blazorLayerMappingTemplateGenerator.GenerateBlazorLayerMappingFileTemplate(classDatas, folderName);

            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = $@"{folderPath}\{solutionName}.Blazor\MapperProfilers\{classDatas.ClassName}Mapping.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, mappingContent);
        }



    }
}
