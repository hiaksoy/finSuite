using finSuite.InputClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finSuite
{
    public partial class AddPropertyForm : Form
    {
        string[] allowedTypes = { "byte", "decimal", "double", "float", "int", "ushort", "long", "sbyte", "short", "string", "uint", "ulong" };
        public string NewItem { get; private set; }
        public CreatedProperties newCreatedProperties { get; set; }

        public AddPropertyForm()
        {
            InitializeComponent();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

            StringBuilder sb = new();
            sb.Append("public ");
            sb.Append($"{propertyTypeComboBox.SelectedItem}");
            if (nullableCheckBox.Checked)
            {
                sb.Append("?");
            }
            sb.Append(" ");
            sb.Append($"{propertyNameTextBox.Text} ");
            sb.Append("{ get; set; }");
            sb.AppendLine();
            if (!string.IsNullOrEmpty(minTextBox.Text) && allowedTypes.Contains(propertyTypeComboBox.SelectedItem))
            {
                sb.Append($"{minTextBox.Text}");
                sb.Append("/");
            }

            if (!string.IsNullOrEmpty(maxTextBox.Text) && allowedTypes.Contains(propertyTypeComboBox.SelectedItem))
            {
                sb.Append($"{maxTextBox.Text}");
                sb.Append("/");
            }
            if ((!string.IsNullOrEmpty(regexTextBox.Text)) && propertyTypeComboBox.SelectedItem == "string")
            {
                sb.Append($"{regexTextBox.Text}");
            }

            NewItem = sb.ToString(); // TextBox'tan yeni elemanı al

            CreatedProperties createdProperties = new();
            createdProperties.Name = propertyNameTextBox.Text;
            createdProperties.Type = propertyTypeComboBox.SelectedItem.ToString();
            createdProperties.MinLength = string.IsNullOrEmpty(minTextBox.Text) ? null : (int?)int.Parse(minTextBox.Text);
            createdProperties.MaxLength = string.IsNullOrEmpty(maxTextBox.Text) ? null : (int?)int.Parse(maxTextBox.Text);
            createdProperties.Regex = string.IsNullOrEmpty(regexTextBox.Text) ? null : regexTextBox.Text;
            createdProperties.Nullable = nullableCheckBox.Checked;

            newCreatedProperties = createdProperties;

            this.DialogResult = DialogResult.OK; // Dialog sonucunu belirle
            this.Close(); // Formu kapat
        }

        private void propertyTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {


            if (propertyTypeComboBox.SelectedItem == "string")
            {
                regexTextBox.Enabled = true;
            }
            else
            {
                regexTextBox.Enabled = false;
            }


            if (allowedTypes.Contains(propertyTypeComboBox.SelectedItem))
            {
                minTextBox.Enabled = true;
                maxTextBox.Enabled = true;
            }
            else
            {
                minTextBox.Enabled = false;
                maxTextBox.Enabled = false;
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Formu kapat
        }

        private void propertyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
