using finSuite.InputClasses;

namespace finSuite.Generators.Consts
{
    public class ConstsClassGenerator
    {
        public static void CreateConstsClassFile(ClassDatas classDatas, string folderPath, string folderName)
        {
            ConstsClassTemplateGenerator constsClassTemplateGenerator = new ConstsClassTemplateGenerator();
            string constsClassContent = constsClassTemplateGenerator.GenerateConstsClassTemplate(classDatas, folderName);


            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = @$"{folderPath}\{solutionName}.Domain.Shared\{folderName}\{classDatas.ClassName}Consts.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, constsClassContent);
        }



        public static void CreateConstsClassFile(CreatedClassDatas createdClassDatas, string folderPath, string folderName)
        {
            ConstsClassTemplateGenerator constsClassTemplateGenerator = new ConstsClassTemplateGenerator();
            string constsClassContent = constsClassTemplateGenerator.GenerateConstsClassTemplate(createdClassDatas, folderName);


            // Çözüm adını ve hedef dizin yolunu oluşturma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = @$"{folderPath}\{solutionName}.Domain.Shared\{folderName}\{createdClassDatas.ClassName}Consts.cs";

            // İçeriği dosyaya yazma
            File.WriteAllText(newFilePath, constsClassContent);
        }
    }
}
