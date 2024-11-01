using System.Text;
using finSuite.InputClasses;

namespace finSuite.Generators.Dtos
{
    public class DtoGenerator
    {

        // Belirtilen DTO türü için dosya oluşturma
        public static void CreateDtoFile(string dtoSuffix, string folderPath, string folderName, bool hasConcurrency, ClassDatas classDatas)
        {
            DtoTemplateGenerator dtoTemplateGenerator = new DtoTemplateGenerator();
            // Yeni DTO class adı oluştur
            string newClassName = classDatas.ClassName + dtoSuffix;

            // Dto türüne göre eklemeleri yaparken FullAuditedEntityDto<Guid> ekleyip eklemeyeceğini kontrol et
            string inheritance = string.Empty;

            if (dtoSuffix == "Dto")
            {
                // Dto suffix'i varsa FullAuditedEntityDto<Guid> ekle ve hasConcurrency true ise sonrasına IHasConcurrencyStamp ekle
                inheritance = hasConcurrency
                    ? " : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp"
                    : " : FullAuditedEntityDto<Guid>";
            }
            else if (hasConcurrency)
            {
                // Diğer durumlar için sadece IHasConcurrencyStamp ekle
                inheritance = " : IHasConcurrencyStamp";
            }

            // Yeni şablon oluşturma
            string newClassContent = dtoTemplateGenerator.GenerateNewDtoTemplate(classDatas, inheritance, hasConcurrency, dtoSuffix);

            // Yeni dosyaya yazma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = @$"{folderPath + "\\" + solutionName + ".Application.Contracts" + "\\" + folderName}\{newClassName}.cs";


            File.WriteAllText(newFilePath, newClassContent);


        }


        // Belirtilen DTO türü için dosya oluşturma
        public static void CreateDtoFile(string dtoSuffix, string folderPath, string folderName, bool hasConcurrency, CreatedClassDatas createdClassDatas)
        {
            DtoTemplateGenerator dtoTemplateGenerator = new DtoTemplateGenerator();
            // Yeni DTO class adı oluştur
            string newClassName = createdClassDatas.ClassName + dtoSuffix;

            // Dto türüne göre eklemeleri yaparken FullAuditedEntityDto<Guid> ekleyip eklemeyeceğini kontrol et
            string inheritance = string.Empty;

            if (dtoSuffix == "Dto")
            {
                // Dto suffix'i varsa FullAuditedEntityDto<Guid> ekle ve hasConcurrency true ise sonrasına IHasConcurrencyStamp ekle
                inheritance = hasConcurrency
                    ? " : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp"
                    : " : FullAuditedEntityDto<Guid>";
            }
            else if (hasConcurrency)
            {
                // Diğer durumlar için sadece IHasConcurrencyStamp ekle
                inheritance = " : IHasConcurrencyStamp";
            }

            // Yeni şablon oluşturma
            string newClassContent = dtoTemplateGenerator.GenerateNewDtoTemplate(createdClassDatas, inheritance, hasConcurrency, dtoSuffix);

            // Yeni dosyaya yazma
            string solutionName = Path.GetFileNameWithoutExtension(folderPath);
            string newFilePath = @$"{folderPath + "\\" + solutionName + ".Application.Contracts" + "\\" + folderName}\{newClassName}.cs";

            File.WriteAllText(newFilePath, newClassContent);
        }
    }
}
