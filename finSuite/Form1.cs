using finSuite.Extensions;
using finSuite.Generators;
using finSuite.InputClasses;
using MetroFramework.Forms;

namespace finSuite

{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }



        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        string selectedFilePath;
        string selectedFolderPath;
        ExtensionFuncs extensionFuncs = new ExtensionFuncs();
        CreatedClassDatas createdClassDatas = new();



        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Filtre belirleyin (örneðin, sadece metin dosyalarýný göster)
            openFileDialog.Filter = "Class files (*.cs)|*.cs|All files (*.*)|*.*";

            // Dosya seçildiðinde
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosya yolunu al
                selectedFilePath = openFileDialog.FileName;

                // Dosya yolu ile ilgili iþlem yap
                string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);
                lblFileSource.Text = selectedFilePath;
                txtFolderName.Text = fileName+"s";
                entityDtoCheckBox.Text = fileName+"Dto.cs";
                entityCreateDtoCheckBox.Text = fileName+"CreateDto.cs";
                entityUpdateDtoCheckBox.Text = fileName+"UpdateDto.cs";
                IEntityAppServiceCheckBox.Text = "I"+fileName+"AppService.cs";
                getEntityInputCheckBox.Text = "Get"+fileName+"Input.cs";
                entityConstsCheckBox.Text = fileName + "Consts.cs";
                entityRepositoryCheckBox.Text = "EfCore"+fileName+"Repository";
                entityManagerCheckBox.Text = fileName+"Manager";
                entityCheckBox.Text = fileName;
                entityRepositoryInterfaceCheckBox.Text = "I"+fileName+"Repository";
                entityAppServiceCheckBox.Text = fileName+"AppService";
                entityMappingApplicationCheckbox.Text = fileName + "Mapping";
                entityPermissionsChechkbox.Text = fileName + "Permissions";
                entityConfigsChechkbox.Text = fileName + "Configurations";
                entityMappingBlazorCheckbox.Text = fileName + "Mapping";
                entityRazorCheckBox.Text = fileName + ".razor";
                entityRazorCsCheckBox.Text = fileName +".razor.cs";
                entityRazorJsCheckBox.Text = fileName + ".razor.js";
                richTextBox1.Text = File.ReadAllText(selectedFilePath);
            }
        }

        private void btnSelectSolutionPath_Click(object sender, EventArgs e)
        {
            // FolderBrowserDialog oluþtur
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Klasör seçimi için diyalogu göster
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen klasörün yolunu al
                selectedFolderPath = folderBrowserDialog.SelectedPath;

                // Klasör yolu ile ilgili iþlem yap
                lblSolutionSourcePath.Text = selectedFolderPath;
            }

            //if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string selectedPath = folderBrowserDialog.SelectedPath;
            //    treeView1.Nodes.Clear();

            //    TreeNode rootNode = new TreeNode(selectedPath);
            //    rootNode.Tag = selectedPath;
            //    rootNode.Nodes.Add("Loading..."); // Alt düðümler için yer tutucu
            //    treeView1.Nodes.Add(rootNode);
            //}


        }


        //private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (e.Node.Nodes[0].Text == "Loading...")
        //    {
        //        e.Node.Nodes.Clear();
        //        LoadDirectory(e.Node, (string)e.Node.Tag);
        //    }
        //}

        //private void LoadDirectory(TreeNode node, string path)
        //{
        //    try
        //    {
        //        // Alt dizinleri ekle
        //        foreach (string directory in Directory.GetDirectories(path))
        //        {
        //            TreeNode dirNode = new TreeNode(Path.GetFileName(directory));
        //            dirNode.Tag = directory;
        //            dirNode.Nodes.Add("Loading..."); // Alt düðümler için yer tutucu
        //            node.Nodes.Add(dirNode);
        //        }

        //        // Dosyalarý ekle
        //        foreach (string file in Directory.GetFiles(path))
        //        {
        //            TreeNode fileNode = new TreeNode(Path.GetFileName(file));
        //            fileNode.Tag = file;
        //            node.Nodes.Add(fileNode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error accessing {path}: {ex.Message}");
        //    }
        //}











        private void btnTest_Click(object sender, EventArgs e)
        {
            FileGenerator fileGenerator = new FileGenerator();
            FolderGenerator folderGenerator = new FolderGenerator();

            Dictionary<string, bool> checkboxStates = new Dictionary<string, bool>
            {
                 { "CreateDto", entityDtoCheckBox.Checked },
                 { "CreateCreateDto", entityCreateDtoCheckBox.Checked },
                 { "CreateUpdateDto", entityUpdateDtoCheckBox.Checked },
                 { "CreateIAppService", IEntityAppServiceCheckBox.Checked },
                 { "CreateGetInput", getEntityInputCheckBox.Checked },
                 { "CreateConsts", entityConstsCheckBox.Checked },
                 { "CreateRepository", entityRepositoryCheckBox.Checked },
                 { "CreateManager", entityManagerCheckBox.Checked },
                 { "CreateEntity", entityCheckBox.Checked },
                 { "CreateRepositoryInterface", entityRepositoryInterfaceCheckBox.Checked },
                 { "CreateAppService", entityAppServiceCheckBox.Checked },
                 { "CreateMappingApplication", entityMappingApplicationCheckbox.Checked },
                 { "CreatePermissions", entityPermissionsChechkbox.Checked },
                 { "CreateConfigs", entityConfigsChechkbox.Checked },
                 { "CreateMappingBlazor", entityMappingBlazorCheckbox.Checked },
                 { "CreateRazorPage", entityRazorCheckBox.Checked },
                 { "CreateRazorCs", entityRazorCsCheckBox.Checked },
                 { "CreateRazorJs", entityRazorJsCheckBox.Checked },
                 { "CreateNavbarMenus", navbarMenusCheckBox.Checked }

            };


            if (string.IsNullOrEmpty(selectedFilePath) || string.IsNullOrEmpty(selectedFolderPath) || string.IsNullOrEmpty(txtFolderName.Text))
            {
                MessageBox.Show("Lütfen Gerekli Alanlarý Doldurunuz.");
            }
            else
            {
                if (chkCreateFolders.Checked)
                {
                    folderGenerator.CreateFolders(selectedFolderPath, txtFolderName.Text);
                }
                fileGenerator.Generate(selectedFilePath, txtFolderName.Text, selectedFolderPath, checkboxStates);

            }


        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            folderBrowserDialog1.Reset();

            selectedFilePath = null;
            selectedFolderPath = null;

            lblFileSource.Text = selectedFilePath;
            txtFolderName.Text = Path.GetFileNameWithoutExtension(selectedFilePath);
            richTextBox1.Text = null;
            lblSolutionSourcePath.Text = selectedFolderPath;

            entityDtoCheckBox.Text = "EntityDto";
            entityCreateDtoCheckBox.Text = "EntityCreateDto";
            entityUpdateDtoCheckBox.Text = "EntityUpdateDto";
            getEntityInputCheckBox.Text = "GetEntityInput";
            IEntityAppServiceCheckBox.Text = "IEntityAppService";
            entityConstsCheckBox.Text = "EntityConsts";
            entityRepositoryCheckBox.Text = "EfCoreEntityRepository";
            entityManagerCheckBox.Text = "EntityManager";
            entityCheckBox.Text = "Entity";
            entityRepositoryInterfaceCheckBox.Text = "IEntityRepository";
            entityAppServiceCheckBox.Text = "EntityAppService";
            entityMappingApplicationCheckbox.Text = "EntityMapping";
            entityPermissionsChechkbox.Text = "EntityPermissions";
            entityConfigsChechkbox.Text = "EntityConfigurations";
            entityMappingBlazorCheckbox.Text = "EntityMapping";
            entityRazorCheckBox.Text = "Entity.razor";
            entityRazorCsCheckBox.Text = "Entity.razor.cs";
            entityRazorJsCheckBox.Text = "Entity.razor.js";

            txtFolderName.Text.Remove(0);
        }

        private void btnTest_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            entityDtoCheckBox.Checked = checkAll.Checked;
            entityCreateDtoCheckBox.Checked = checkAll.Checked;
            entityUpdateDtoCheckBox.Checked = checkAll.Checked;
            IEntityAppServiceCheckBox.Checked = checkAll.Checked;
            getEntityInputCheckBox.Checked = checkAll.Checked;
            entityConstsCheckBox.Checked = checkAll.Checked;
            entityRepositoryCheckBox.Checked = checkAll.Checked;
            entityManagerCheckBox.Checked = checkAll.Checked;
            entityCheckBox.Checked = checkAll.Checked;
            entityRepositoryInterfaceCheckBox.Checked = checkAll.Checked;
            entityAppServiceCheckBox.Checked = checkAll.Checked;
            entityMappingApplicationCheckbox.Checked = checkAll.Checked;
            entityPermissionsChechkbox.Checked = checkAll.Checked;
            entityConfigsChechkbox.Checked = checkAll.Checked;
            entityMappingBlazorCheckbox.Checked = checkAll.Checked;
            entityRazorCheckBox.Checked = checkAll.Checked;
            entityRazorCsCheckBox.Checked = checkAll.Checked;
            entityRazorJsCheckBox.Checked = checkAll.Checked;
            navbarMenusCheckBox.Checked = checkAll.Checked;
            checkAppCon.Checked = checkAll.Checked;
            checkShared.Checked = checkAll.Checked;
            checkEf.Checked = checkAll.Checked;
            checkDomain.Checked = checkAll.Checked;
            checkApp.Checked = checkAll.Checked;
            checkBlazor.Checked = checkAll.Checked;
            checkMenus.Checked = checkAll.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateEntity_Click(object sender, EventArgs e)
        {
            CreateEntity createEntity = new CreateEntity();
            createEntity.StartPosition = FormStartPosition.Manual;
            createEntity.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
            //createEntity.ShowDialog();


            if (createEntity.ShowDialog() == DialogResult.OK)
            {
                createdClassDatas = createEntity.createdClassDatas; // Popup formdan yeni elemaný al

                richTextBox1.Text = createdClassDatas.ToString();

                txtFolderName.Text = createdClassDatas.PluralName;
            }
        }

        private void checkAppCon_CheckedChanged(object sender, EventArgs e)
        {
            entityDtoCheckBox.Checked = checkAppCon.Checked;
            entityCreateDtoCheckBox.Checked = checkAppCon.Checked;
            entityUpdateDtoCheckBox.Checked = checkAppCon.Checked;
            getEntityInputCheckBox.Checked = checkAppCon.Checked;
            IEntityAppServiceCheckBox.Checked = checkAppCon.Checked;
            entityPermissionsChechkbox.Checked = checkAppCon.Checked;

        }

        private void checkShared_CheckedChanged(object sender, EventArgs e)
        {
            entityConstsCheckBox.Checked = checkShared.Checked;
        }

        private void checkEf_CheckedChanged(object sender, EventArgs e)
        {
            entityRepositoryCheckBox.Checked = checkEf.Checked;
            entityConfigsChechkbox.Checked = checkEf.Checked;
        }

        private void checkDomain_CheckedChanged(object sender, EventArgs e)
        {
            entityManagerCheckBox.Checked = checkDomain.Checked;
            entityCheckBox.Checked = checkDomain.Checked;
            entityRepositoryInterfaceCheckBox.Checked = checkDomain.Checked;
        }

        private void checkApp_CheckedChanged(object sender, EventArgs e)
        {
            entityAppServiceCheckBox.Checked = checkApp.Checked;
            entityMappingApplicationCheckbox.Checked = checkApp.Checked;
        }

        private void checkBlazor_CheckedChanged(object sender, EventArgs e)
        {
            entityMappingBlazorCheckbox.Checked = checkBlazor.Checked;
            entityRazorCheckBox.Checked = checkBlazor.Checked;
            entityRazorCsCheckBox.Checked = checkBlazor.Checked;
            entityRazorJsCheckBox.Checked = checkBlazor.Checked;
        }

        private void checkMenus_CheckedChanged(object sender, EventArgs e)
        {
            navbarMenusCheckBox.Checked = checkMenus.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebViewForm webViewForm = new WebViewForm();
            webViewForm.ShowDialog();
        }

        private void btnCreateFromGenerated_Click(object sender, EventArgs e)
        {
            FileGenerator fileGenerator = new FileGenerator();
            FolderGenerator folderGenerator = new FolderGenerator();

            Dictionary<string, bool> checkboxStates = new Dictionary<string, bool>
            {
                 { "CreateDto", entityDtoCheckBox.Checked },
                 { "CreateCreateDto", entityCreateDtoCheckBox.Checked },
                 { "CreateUpdateDto", entityUpdateDtoCheckBox.Checked },
                 { "CreateIAppService", IEntityAppServiceCheckBox.Checked },
                 { "CreateGetInput", getEntityInputCheckBox.Checked },
                 { "CreateConsts", entityConstsCheckBox.Checked },
                 { "CreateRepository", entityRepositoryCheckBox.Checked },
                 { "CreateManager", entityManagerCheckBox.Checked },
                 { "CreateEntity", entityCheckBox.Checked },
                 { "CreateRepositoryInterface", entityRepositoryInterfaceCheckBox.Checked },
                 { "CreateAppService", entityAppServiceCheckBox.Checked },
                 { "CreateMappingApplication", entityMappingApplicationCheckbox.Checked },
                 { "CreatePermissions", entityPermissionsChechkbox.Checked },
                 { "CreateConfigs", entityConfigsChechkbox.Checked },
                 { "CreateMappingBlazor", entityMappingBlazorCheckbox.Checked },
                 { "CreateRazorPage", entityRazorCheckBox.Checked },
                 { "CreateRazorCs", entityRazorCsCheckBox.Checked },
                 { "CreateRazorJs", entityRazorJsCheckBox.Checked },
                 { "CreateNavbarMenus", navbarMenusCheckBox.Checked }

            };


            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                MessageBox.Show("Lütfen Gerekli Alanlarý Doldurunuz.");
            }
            else
            {
                if (chkCreateFolders.Checked)
                {
                    folderGenerator.CreateFolders(selectedFolderPath, txtFolderName.Text);
                }
                fileGenerator.Generate(createdClassDatas.PluralName, selectedFolderPath, checkboxStates, createdClassDatas);

            }
        }
    }
}
