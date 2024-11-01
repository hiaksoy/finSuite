namespace finSuite
{
    partial class AddPropertyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            nullableCheckBox = new CheckBox();
            panel2 = new Panel();
            label4 = new Label();
            maxTextBox = new TextBox();
            minTextBox = new TextBox();
            regexTextBox = new TextBox();
            regexLabel = new Label();
            label3 = new Label();
            propertyTypeComboBox = new ComboBox();
            label2 = new Label();
            propertyNameTextBox = new TextBox();
            label1 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(nullableCheckBox);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(regexTextBox);
            panel1.Controls.Add(regexLabel);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(propertyTypeComboBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(propertyNameTextBox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnOk);
            panel1.Controls.Add(btnCancel);
            panel1.Location = new Point(12, 12);
            panel1.MinimumSize = new Size(360, 541);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 541);
            panel1.TabIndex = 12;
            panel1.Paint += panel1_Paint;
            // 
            // nullableCheckBox
            // 
            nullableCheckBox.AutoSize = true;
            nullableCheckBox.Location = new Point(0, 196);
            nullableCheckBox.Name = "nullableCheckBox";
            nullableCheckBox.Size = new Size(70, 19);
            nullableCheckBox.TabIndex = 6;
            nullableCheckBox.Text = "Nullable";
            nullableCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(maxTextBox);
            panel2.Controls.Add(minTextBox);
            panel2.Location = new Point(0, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 30);
            panel2.TabIndex = 22;
            panel2.Paint += panel2_Paint;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(178, 7);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 22;
            label4.Text = "-";
            // 
            // maxTextBox
            // 
            maxTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxTextBox.Location = new Point(210, 4);
            maxTextBox.Name = "maxTextBox";
            maxTextBox.Size = new Size(150, 23);
            maxTextBox.TabIndex = 4;
            // 
            // minTextBox
            // 
            minTextBox.Location = new Point(0, 4);
            minTextBox.Name = "minTextBox";
            minTextBox.Size = new Size(150, 23);
            minTextBox.TabIndex = 3;
            // 
            // regexTextBox
            // 
            regexTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            regexTextBox.Location = new Point(0, 157);
            regexTextBox.Name = "regexTextBox";
            regexTextBox.Size = new Size(360, 23);
            regexTextBox.TabIndex = 5;
            // 
            // regexLabel
            // 
            regexLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            regexLabel.AutoSize = true;
            regexLabel.Location = new Point(2, 139);
            regexLabel.Name = "regexLabel";
            regexLabel.Size = new Size(39, 15);
            regexLabel.TabIndex = 20;
            regexLabel.Text = "Regex";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(0, 95);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 16;
            label3.Text = "Min - Max Length";
            // 
            // propertyTypeComboBox
            // 
            propertyTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propertyTypeComboBox.FormattingEnabled = true;
            propertyTypeComboBox.Items.AddRange(new object[] { "Guid", "bool", "byte", "DateTime", "DateOnly", "decimal", "double", "enum", "float", "int", "long", "sbyte", "short", "string", "TimeOnly", "uint", "ulong", "ushort" });
            propertyTypeComboBox.Location = new Point(0, 69);
            propertyTypeComboBox.Name = "propertyTypeComboBox";
            propertyTypeComboBox.Size = new Size(360, 23);
            propertyTypeComboBox.TabIndex = 2;
            propertyTypeComboBox.SelectedIndexChanged += propertyTypeComboBox_SelectedIndexChanged;
            propertyTypeComboBox.SelectedValueChanged += propertyTypeComboBox_SelectedValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(0, 51);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 14;
            label2.Text = "Property Type";
            // 
            // propertyNameTextBox
            // 
            propertyNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propertyNameTextBox.Location = new Point(0, 26);
            propertyNameTextBox.Name = "propertyNameTextBox";
            propertyNameTextBox.Size = new Size(360, 23);
            propertyNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(0, 7);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 12;
            label1.Text = "Property Name";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(204, 518);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 7;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(285, 518);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // AddPropertyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 565);
            Controls.Add(panel1);
            MinimumSize = new Size(400, 604);
            Name = "AddPropertyForm";
            Text = "AddPropertyForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnCancel;
        private Button btnOk;
        private Panel panel2;
        private TextBox regexTextBox;
        private Label regexLabel;
        private Label label3;
        private ComboBox propertyTypeComboBox;
        private Label label2;
        private TextBox propertyNameTextBox;
        private Label label1;
        private Label label4;
        private TextBox maxTextBox;
        private TextBox minTextBox;
        private CheckBox nullableCheckBox;
    }
}