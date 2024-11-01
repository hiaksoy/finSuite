using finSuite.InputClasses;
using System.Text;

namespace finSuite
{
    public partial class CreateEntity : Form
    {
        public CreateEntity()
        {
            InitializeComponent();
        }

        List<string> propertyList = new List<string>();
        List<string> configsList = new List<string>();
        List<string> propertiesListBoxList = new List<string>();
        public CreatedClassDatas createdClassDatas;
        List<CreatedProperties> createdPropertiesList = new List<CreatedProperties>();

        private void button1_Click(object sender, EventArgs e)
        {
            AddPropertyForm addPropertyForm = new AddPropertyForm();
            addPropertyForm.StartPosition = FormStartPosition.Manual;
            addPropertyForm.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
            if (addPropertyForm.ShowDialog() == DialogResult.OK)
            {
                string newItem = addPropertyForm.NewItem;

                propertiesListBox.Items.Add(newItem); // Listeye yeni elemanı ekle
                propertiesListBoxList.Add(newItem);

                createdPropertiesList.Add(addPropertyForm.newCreatedProperties);
            }


            //this.DialogResult = DialogResult.OK; // Dialog sonucunu belirle
            //this.Close(); // Formu kapat
        }



        private void buttonRemoveProperty_Click(object sender, EventArgs e)
        {
            if (propertiesListBox.SelectedItem != null)
            {
                // Show confirmation dialog
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to remove the selected item?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // If user clicked Yes, remove the item
                if (dialogResult == DialogResult.Yes)
                {
                    propertiesListBox.Items.Remove(propertiesListBox.SelectedItem); // Seçilen elemanı sil
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnCancelCreateEntity_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkCreateEntity_Click(object sender, EventArgs e)
        {

            createdClassDatas = ExtensionFuncs.CreateClassFromEntries(
            createdPropertiesList, entityNameTextBox.Text, pluralNameTextBox.Text, baseClassComboBox.SelectedItem.ToString(), primaryKeyComboBox.SelectedItem.ToString(),
            nameSpaceTextBox.Text);

            this.Close();
            this.DialogResult = DialogResult.OK; // Dialog sonucunu belirle
        }

        private void searchMasterEntityButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Filtre belirleyin (örneğin, sadece metin dosyalarını göster)
            openFileDialog.Filter = "Class files (*.cs)|*.cs|All files (*.*)|*.*";

            // Dosya seçildiğinde
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosya yolunu al

                string masterEnitiyFileName = Path.GetFileName(openFileDialog.FileName);


                masterEntityTextBox.Text = masterEnitiyFileName;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entityTypeComboBox.SelectedIndex == 1)
            {
                searchMasterEntityButton.Enabled = true;
            }
            else
            {
                searchMasterEntityButton.Enabled = false;
            }
        }
    }
}
