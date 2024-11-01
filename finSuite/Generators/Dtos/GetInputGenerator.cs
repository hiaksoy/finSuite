using finSuite.InputClasses;

namespace finSuite.Generators.Dtos
{
    public class GetInputGenerator
    {
        public static void CreateGetInputFile(ClassDatas classDatas, string folderPath, string folderName)
        {
            GetInputTemplateGenerator getTemplateGenerator = new GetInputTemplateGenerator();
            // `GetAuthorsInput` şablonu oluştur
            string getInputClassContent = getTemplateGenerator.GenerateGetInputTemplate(classDatas, folderName);

            // `GetAuthorsInput` dosyasını oluşturma ve yazma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string getInputFilePath = @$"{folderPath + "\\" + solutionName + ".Application.Contracts" + "\\" + folderName}\Get{folderName}Input.cs";
            File.WriteAllText(getInputFilePath, getInputClassContent);
        }

        public static void CreateGetInputFile(CreatedClassDatas createdClassDatas, string folderPath, string folderName)
        {
            GetInputTemplateGenerator getTemplateGenerator = new GetInputTemplateGenerator();
            // `GetAuthorsInput` şablonu oluştur
            string getInputClassContent = getTemplateGenerator.GenerateGetInputTemplate(createdClassDatas, folderName);

            // `GetAuthorsInput` dosyasını oluşturma ve yazma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string getInputFilePath = @$"{folderPath + "\\" + solutionName + ".Application.Contracts" + "\\" + folderName}\Get{folderName}Input.cs";
            File.WriteAllText(getInputFilePath, getInputClassContent);
        }
    }
}
