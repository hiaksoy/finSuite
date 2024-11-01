using finSuite.InputClasses;

namespace finSuite.Generators.IAppServices
{
    public class IAppServiceGenerator
    {

        public static void CreateIAppServiceInterfaceFile(ClassDatas classDatas, string folderPath, string folderName)
        {
            IAppServiceTemplateGenerator iAppServiceTemplateGenerator = new IAppServiceTemplateGenerator();
            // IAppService arayüzü adı
            string interfaceName = $"I{folderName}AppService";

            // Arayüz içeriği oluşturma
            string interfaceContent = iAppServiceTemplateGenerator.GenerateIAppServiceTemplate(classDatas, interfaceName, folderName);

            // Yeni dosya yolu
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string interfaceFilePath = @$"{folderPath + "\\" + solutionName + ".Application.Contracts" + "\\" + folderName}\{interfaceName}.cs";

            // Dosyayı yazma
            File.WriteAllText(interfaceFilePath, interfaceContent);

        }


        public static void CreateIAppServiceInterfaceFile(CreatedClassDatas createdClassDatas, string folderPath, string folderName)
        {
            IAppServiceTemplateGenerator iAppServiceTemplateGenerator = new IAppServiceTemplateGenerator();
            // IAppService arayüzü adı
            string interfaceName = $"I{folderName}AppService";

            // Arayüz içeriği oluşturma
            string interfaceContent = iAppServiceTemplateGenerator.GenerateIAppServiceTemplate(createdClassDatas, interfaceName, folderName);

            // Yeni dosya yolu
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string interfaceFilePath = @$"{folderPath + "\\" + solutionName + ".Application.Contracts" + "\\" + folderName}\{interfaceName}.cs";

            // Dosyayı yazma
            File.WriteAllText(interfaceFilePath, interfaceContent);

        }
    }
}
