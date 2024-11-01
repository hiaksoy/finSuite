
using finSuite.Generators.AppServices;
using finSuite.Generators.Configs;
using finSuite.Generators.Entities;
using finSuite.Generators.IRepositories;
using finSuite.Generators.Managers;
using finSuite.Generators.Mappings;
using finSuite.Generators.Menus;
using finSuite.Generators.Permissions;
using finSuite.Generators.RazorPages;
using finSuite.InputClasses;

namespace finSuite.Generators
{
    public class FileGenerator
    {
        public void Generate(string filePath, string folderName, string folderPath, Dictionary<string, bool> checkboxStates)
        {


            ExtensionFuncs.ParseClassProperties(filePath, finSuiteConsts.accessModifiers, out ClassDatas classDatas);

            if (checkboxStates["CreateDto"])
                DtoGenerator.CreateDtoFile("Dto", folderPath, folderName, true, classDatas);
            if (checkboxStates["CreateCreateDto"])
                DtoGenerator.CreateDtoFile("CreateDto", folderPath, folderName, false, classDatas);
            if (checkboxStates["CreateUpdateDto"])
                DtoGenerator.CreateDtoFile("UpdateDto", folderPath, folderName, true, classDatas);
            if (checkboxStates["CreateIAppService"])
                IAppServiceGenerator.CreateIAppServiceInterfaceFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateGetInput"])
                GetInputGenerator.CreateGetInputFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateConsts"])
                ConstsClassGenerator.CreateConstsClassFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateRepository"])
                RepositoryGenerator.CreateRepositoryClassFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateManager"])
                ManagerGenerator.CreateManagerClassFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateEntity"])
                EntityGenerator.CreateEntityClassFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateRepositoryInterface"])
                IRepositoryGenerator.CreateRepositoryInterfaceFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateAppService"])
                AppServiceGenerator.CreateEntityAppServiceFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateConfigs"])
                ConfigGenerate.CreateConfigClassFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateMappingApplication"])
                ApplicationLayerMappingGenerator.CreateApplicationLayerMappingFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreateMappingBlazor"])
                BlazorLayerMappingGenerator.CreateBlazorLayerMappingFile(classDatas, folderPath, folderName);
            if (checkboxStates["CreatePermissions"])
                PermissonGenerator.CreateApplicationContractsPermissionsAddonsTextFile(classDatas, folderName, folderPath);
            if (checkboxStates["CreateRazorPage"])
                RazorPageGenerator.CreateRazorPageTemplateTextFile(classDatas, folderName, folderPath);
            if (checkboxStates["CreateRazorCs"])
                RazorPageCsGenerator.CreateRazorPageCsTemplateTextFile(classDatas, folderName, folderPath);
            if (checkboxStates["CreateRazorJs"])
                RazorPageJsGenerator.CreateRazorPageJsTemplateTextFile(folderName, folderPath);
            if (checkboxStates["CreateNavbarMenus"])
                MenuCodesFileGenerator.CreateBlazorLayerMenuFileTemplateTextFile(classDatas, folderName, folderPath);

            MessageBox.Show("İşlem Başarılı!");


        }

        public void Generate(string folderName, string folderPath, Dictionary<string, bool> checkboxStates, CreatedClassDatas createdClassDatas)
        {



            if (checkboxStates["CreateDto"])
                DtoGenerator.CreateDtoFile("Dto", folderPath, folderName, true, createdClassDatas);
            if (checkboxStates["CreateCreateDto"])
                DtoGenerator.CreateDtoFile("CreateDto", folderPath, folderName, false, createdClassDatas);
            if (checkboxStates["CreateUpdateDto"])
                DtoGenerator.CreateDtoFile("UpdateDto", folderPath, folderName, true, createdClassDatas);
            if (checkboxStates["CreateIAppService"])
                IAppServiceGenerator.CreateIAppServiceInterfaceFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateGetInput"])
                GetInputGenerator.CreateGetInputFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateConsts"])
                ConstsClassGenerator.CreateConstsClassFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateRepository"])
                RepositoryGenerator.CreateRepositoryClassFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateManager"])
                ManagerGenerator.CreateManagerClassFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateEntity"])
                EntityGenerator.CreateEntityClassFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateRepositoryInterface"])
                IRepositoryGenerator.CreateRepositoryInterfaceFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateAppService"])
                AppServiceGenerator.CreateEntityAppServiceFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateConfigs"])
                ConfigGenerate.CreateConfigClassFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateMappingApplication"])
                ApplicationLayerMappingGenerator.CreateApplicationLayerMappingFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreateMappingBlazor"])
                BlazorLayerMappingGenerator.CreateBlazorLayerMappingFile(createdClassDatas, folderPath, folderName);
            if (checkboxStates["CreatePermissions"])
                PermissonGenerator.CreateApplicationContractsPermissionsAddonsTextFile(createdClassDatas, folderName, folderPath);
            if (checkboxStates["CreateRazorPage"])
                RazorPageGenerator.CreateRazorPageTemplateTextFile(createdClassDatas, folderName, folderPath);
            if (checkboxStates["CreateRazorCs"])
                RazorPageCsGenerator.CreateRazorPageCsTemplateTextFile(createdClassDatas, folderName, folderPath);
            if (checkboxStates["CreateRazorJs"])
                RazorPageJsGenerator.CreateRazorPageJsTemplateTextFile(folderName, folderPath);
            if (checkboxStates["CreateNavbarMenus"])
                MenuCodesFileGenerator.CreateBlazorLayerMenuFileTemplateTextFile(createdClassDatas, folderName, folderPath);

            MessageBox.Show("İşlem Başarılı!");


        }

    }
}
