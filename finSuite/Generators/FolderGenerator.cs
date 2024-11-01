namespace finSuite.Generators
{
    public class FolderGenerator
    {
        public void CreateFolders(string filePath, string folderName)
        {
            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(folderName))
            {
                try
                {
                    string shortFolderName = Path.GetFileNameWithoutExtension(filePath);


                    string[] filePaths = { filePath+"\\"+shortFolderName+".Application"+"\\"+folderName ,
                                           filePath+"\\"+shortFolderName+".Application"+"\\"+"MapperProfiler" ,
                                           filePath+"\\"+shortFolderName+".Application.Contracts"+"\\"+folderName ,
                                           filePath+"\\"+shortFolderName+".Application.Contracts"+"\\"+"Permissions" ,
                                           filePath+"\\"+shortFolderName+".Domain"+"\\"+folderName ,
                                           filePath+"\\"+shortFolderName+".Domain.Shared"+"\\"+folderName ,
                                           filePath+"\\"+shortFolderName+".Blazor"+"\\"+"MapperProfilers" ,
                                           filePath+"\\"+shortFolderName+".Blazor"+"\\"+"Pages"+"\\"+folderName ,
                                           filePath+"\\"+shortFolderName+".EntityFrameworkCore"+"\\"+folderName ,
                                           filePath+"\\"+shortFolderName+".EntityFrameworkCore\\EFCustomConfigurations" ,
                                           filePath+"\\"+shortFolderName+".EntityFrameworkCore\\EFCustomConfigurations"+"\\"+folderName ,
                };

                    // Klasörleri oluştur
                    foreach (string filePathh in filePaths)
                    {
                        Directory.CreateDirectory(filePathh);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Öncelikle bir klasör ve klasör ismi seçmelisiniz.");
            }
        }
    }
}
