namespace finSuite
{
    partial class CreateEntity
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
            tabControl1 = new TabControl();
            entityInfoTabPage = new TabPage();
            masterEntityTextBox = new TextBox();
            searchMasterEntityButton = new Button();
            label8 = new Label();
            nameSpaceTextBox = new TextBox();
            label7 = new Label();
            btnCancelCreateEntity = new Button();
            btnOkCreateEntity = new Button();
            btnCancel = new Button();
            btnOk = new Button();
            primaryKeyComboBox = new ComboBox();
            label5 = new Label();
            baseClassComboBox = new ComboBox();
            label4 = new Label();
            pluralNameTextBox = new TextBox();
            label3 = new Label();
            entityNameTextBox = new TextBox();
            label2 = new Label();
            entityTypeComboBox = new ComboBox();
            label1 = new Label();
            entityPropertiesTabPage = new TabPage();
            buttonRemoveProperty = new Button();
            buttonAddProperty = new Button();
            label6 = new Label();
            propertiesListBox = new ListBox();
            entityNavigationsTabPage = new TabPage();
            openFileDialog1 = new OpenFileDialog();
            tabControl1.SuspendLayout();
            entityInfoTabPage.SuspendLayout();
            entityPropertiesTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(entityInfoTabPage);
            tabControl1.Controls.Add(entityPropertiesTabPage);
            tabControl1.Controls.Add(entityNavigationsTabPage);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(360, 541);
            tabControl1.TabIndex = 0;
            // 
            // entityInfoTabPage
            // 
            entityInfoTabPage.Controls.Add(masterEntityTextBox);
            entityInfoTabPage.Controls.Add(searchMasterEntityButton);
            entityInfoTabPage.Controls.Add(label8);
            entityInfoTabPage.Controls.Add(nameSpaceTextBox);
            entityInfoTabPage.Controls.Add(label7);
            entityInfoTabPage.Controls.Add(btnCancelCreateEntity);
            entityInfoTabPage.Controls.Add(btnOkCreateEntity);
            entityInfoTabPage.Controls.Add(btnCancel);
            entityInfoTabPage.Controls.Add(btnOk);
            entityInfoTabPage.Controls.Add(primaryKeyComboBox);
            entityInfoTabPage.Controls.Add(label5);
            entityInfoTabPage.Controls.Add(baseClassComboBox);
            entityInfoTabPage.Controls.Add(label4);
            entityInfoTabPage.Controls.Add(pluralNameTextBox);
            entityInfoTabPage.Controls.Add(label3);
            entityInfoTabPage.Controls.Add(entityNameTextBox);
            entityInfoTabPage.Controls.Add(label2);
            entityInfoTabPage.Controls.Add(entityTypeComboBox);
            entityInfoTabPage.Controls.Add(label1);
            entityInfoTabPage.Location = new Point(4, 24);
            entityInfoTabPage.Name = "entityInfoTabPage";
            entityInfoTabPage.Padding = new Padding(3);
            entityInfoTabPage.Size = new Size(352, 513);
            entityInfoTabPage.TabIndex = 0;
            entityInfoTabPage.Text = "Entity info";
            entityInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // masterEntityTextBox
            // 
            masterEntityTextBox.Enabled = false;
            masterEntityTextBox.Location = new Point(7, 345);
            masterEntityTextBox.Name = "masterEntityTextBox";
            masterEntityTextBox.Size = new Size(234, 23);
            masterEntityTextBox.TabIndex = 18;
            // 
            // searchMasterEntityButton
            // 
            searchMasterEntityButton.Enabled = false;
            searchMasterEntityButton.Location = new Point(247, 344);
            searchMasterEntityButton.Name = "searchMasterEntityButton";
            searchMasterEntityButton.Size = new Size(99, 24);
            searchMasterEntityButton.TabIndex = 17;
            searchMasterEntityButton.Text = "Search";
            searchMasterEntityButton.UseVisualStyleBackColor = true;
            searchMasterEntityButton.Click += searchMasterEntityButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(7, 327);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 16;
            label8.Text = "Master Entity";
            // 
            // nameSpaceTextBox
            // 
            nameSpaceTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameSpaceTextBox.Location = new Point(6, 259);
            nameSpaceTextBox.Name = "nameSpaceTextBox";
            nameSpaceTextBox.Size = new Size(346, 23);
            nameSpaceTextBox.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 241);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 14;
            label7.Text = "NameSpace";
            // 
            // btnCancelCreateEntity
            // 
            btnCancelCreateEntity.Location = new Point(277, 490);
            btnCancelCreateEntity.Name = "btnCancelCreateEntity";
            btnCancelCreateEntity.Size = new Size(75, 23);
            btnCancelCreateEntity.TabIndex = 8;
            btnCancelCreateEntity.Text = "Cancel";
            btnCancelCreateEntity.UseVisualStyleBackColor = true;
            btnCancelCreateEntity.Click += btnCancelCreateEntity_Click;
            // 
            // btnOkCreateEntity
            // 
            btnOkCreateEntity.Location = new Point(196, 490);
            btnOkCreateEntity.Name = "btnOkCreateEntity";
            btnOkCreateEntity.Size = new Size(75, 23);
            btnOkCreateEntity.TabIndex = 7;
            btnOkCreateEntity.Text = "Ok";
            btnOkCreateEntity.UseVisualStyleBackColor = true;
            btnOkCreateEntity.Click += btnOkCreateEntity_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(921, 682);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(840, 682);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 10;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // primaryKeyComboBox
            // 
            primaryKeyComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            primaryKeyComboBox.FormattingEnabled = true;
            primaryKeyComboBox.Items.AddRange(new object[] { "int", "long", "Guid", "string" });
            primaryKeyComboBox.Location = new Point(6, 197);
            primaryKeyComboBox.Name = "primaryKeyComboBox";
            primaryKeyComboBox.Size = new Size(346, 23);
            primaryKeyComboBox.TabIndex = 5;
            primaryKeyComboBox.Text = "Guid";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 179);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 8;
            label5.Text = "Primary key type";
            // 
            // baseClassComboBox
            // 
            baseClassComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            baseClassComboBox.FormattingEnabled = true;
            baseClassComboBox.Items.AddRange(new object[] { "Entity", "AuditedEntity", "FullAuditedEntity", "BasicAggregateRoot", "AggregateRoot", "AuditedAggregateRoot", "FullAuditedAggregateRoot" });
            baseClassComboBox.Location = new Point(6, 153);
            baseClassComboBox.Name = "baseClassComboBox";
            baseClassComboBox.Size = new Size(346, 23);
            baseClassComboBox.TabIndex = 4;
            baseClassComboBox.Text = "FullAuditedAggregateRoot";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 135);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "Base Class";
            // 
            // pluralNameTextBox
            // 
            pluralNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pluralNameTextBox.Location = new Point(6, 109);
            pluralNameTextBox.Name = "pluralNameTextBox";
            pluralNameTextBox.Size = new Size(346, 23);
            pluralNameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 91);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Plural Name";
            // 
            // entityNameTextBox
            // 
            entityNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            entityNameTextBox.Location = new Point(6, 65);
            entityNameTextBox.Name = "entityNameTextBox";
            entityNameTextBox.Size = new Size(346, 23);
            entityNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 47);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // entityTypeComboBox
            // 
            entityTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            entityTypeComboBox.FormattingEnabled = true;
            entityTypeComboBox.Items.AddRange(new object[] { "Master", "Child" });
            entityTypeComboBox.Location = new Point(6, 21);
            entityTypeComboBox.Name = "entityTypeComboBox";
            entityTypeComboBox.Size = new Size(346, 23);
            entityTypeComboBox.TabIndex = 1;
            entityTypeComboBox.Text = "Master";
            entityTypeComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Entity Type";
            // 
            // entityPropertiesTabPage
            // 
            entityPropertiesTabPage.Controls.Add(buttonRemoveProperty);
            entityPropertiesTabPage.Controls.Add(buttonAddProperty);
            entityPropertiesTabPage.Controls.Add(label6);
            entityPropertiesTabPage.Controls.Add(propertiesListBox);
            entityPropertiesTabPage.Location = new Point(4, 24);
            entityPropertiesTabPage.Name = "entityPropertiesTabPage";
            entityPropertiesTabPage.Padding = new Padding(3);
            entityPropertiesTabPage.Size = new Size(352, 513);
            entityPropertiesTabPage.TabIndex = 1;
            entityPropertiesTabPage.Text = "Properties";
            entityPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveProperty
            // 
            buttonRemoveProperty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRemoveProperty.BackColor = Color.IndianRed;
            buttonRemoveProperty.ForeColor = Color.White;
            buttonRemoveProperty.Location = new Point(88, 8);
            buttonRemoveProperty.Name = "buttonRemoveProperty";
            buttonRemoveProperty.Size = new Size(126, 32);
            buttonRemoveProperty.TabIndex = 3;
            buttonRemoveProperty.Text = "Delete Property";
            buttonRemoveProperty.UseVisualStyleBackColor = false;
            buttonRemoveProperty.Click += buttonRemoveProperty_Click;
            // 
            // buttonAddProperty
            // 
            buttonAddProperty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddProperty.Location = new Point(220, 8);
            buttonAddProperty.Name = "buttonAddProperty";
            buttonAddProperty.Size = new Size(126, 32);
            buttonAddProperty.TabIndex = 2;
            buttonAddProperty.Text = "Add Property";
            buttonAddProperty.UseVisualStyleBackColor = true;
            buttonAddProperty.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 16);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 1;
            label6.Text = "Properties";
            // 
            // propertiesListBox
            // 
            propertiesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertiesListBox.FormattingEnabled = true;
            propertiesListBox.ItemHeight = 15;
            propertiesListBox.Location = new Point(6, 46);
            propertiesListBox.Name = "propertiesListBox";
            propertiesListBox.Size = new Size(343, 484);
            propertiesListBox.TabIndex = 0;
            // 
            // entityNavigationsTabPage
            // 
            entityNavigationsTabPage.Location = new Point(4, 24);
            entityNavigationsTabPage.Name = "entityNavigationsTabPage";
            entityNavigationsTabPage.Size = new Size(352, 513);
            entityNavigationsTabPage.TabIndex = 2;
            entityNavigationsTabPage.Text = "Navigations";
            entityNavigationsTabPage.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // CreateEntity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 565);
            Controls.Add(tabControl1);
            MinimumSize = new Size(400, 604);
            Name = "CreateEntity";
            Text = "CreateEntity";
            tabControl1.ResumeLayout(false);
            entityInfoTabPage.ResumeLayout(false);
            entityInfoTabPage.PerformLayout();
            entityPropertiesTabPage.ResumeLayout(false);
            entityPropertiesTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage entityInfoTabPage;
        private TabPage entityPropertiesTabPage;
        private TabPage entityNavigationsTabPage;
        private TextBox pluralNameTextBox;
        private Label label3;
        private TextBox entityNameTextBox;
        private Label label2;
        private ComboBox entityTypeComboBox;
        private Label label1;
        private Label label5;
        private ComboBox baseClassComboBox;
        private Label label4;
        private ComboBox primaryKeyComboBox;
        private Label label6;
        private ListBox propertiesListBox;
        private Button buttonAddProperty;
        private Button buttonRemoveProperty;
        private Button btnOk;
        private Button btnCancel;
        private Button btnCancelCreateEntity;
        private Button btnOkCreateEntity;
        private TextBox nameSpaceTextBox;
        private Label label7;
        private Label label8;
        private TextBox masterEntityTextBox;
        private Button searchMasterEntityButton;
        private OpenFileDialog openFileDialog1;
    }
}