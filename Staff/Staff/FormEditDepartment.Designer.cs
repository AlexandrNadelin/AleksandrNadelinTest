namespace Staff
{
    partial class FormEditDepartment
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
            this.buttonCansel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditDepartment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDepartmentNewName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDepartmentName = new System.Windows.Forms.ComboBox();
            this.comboBoxParentDepartmentNewName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCansel
            // 
            this.buttonCansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(198, 206);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(150, 29);
            this.buttonCansel.TabIndex = 13;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Название подразделения";
            // 
            // buttonEditDepartment
            // 
            this.buttonEditDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditDepartment.Location = new System.Drawing.Point(8, 206);
            this.buttonEditDepartment.Name = "buttonEditDepartment";
            this.buttonEditDepartment.Size = new System.Drawing.Size(150, 29);
            this.buttonEditDepartment.TabIndex = 8;
            this.buttonEditDepartment.Text = "Редактировать";
            this.buttonEditDepartment.UseVisualStyleBackColor = true;
            this.buttonEditDepartment.Click += new System.EventHandler(this.buttonEditDepartment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Новое название подразделения";
            // 
            // textBoxDepartmentNewName
            // 
            this.textBoxDepartmentNewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDepartmentNewName.Location = new System.Drawing.Point(16, 94);
            this.textBoxDepartmentNewName.Name = "textBoxDepartmentNewName";
            this.textBoxDepartmentNewName.Size = new System.Drawing.Size(323, 26);
            this.textBoxDepartmentNewName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Новое родительское подразделение";
            // 
            // comboBoxDepartmentName
            // 
            this.comboBoxDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDepartmentName.FormattingEnabled = true;
            this.comboBoxDepartmentName.Location = new System.Drawing.Point(16, 29);
            this.comboBoxDepartmentName.Name = "comboBoxDepartmentName";
            this.comboBoxDepartmentName.Size = new System.Drawing.Size(322, 28);
            this.comboBoxDepartmentName.TabIndex = 16;
            this.comboBoxDepartmentName.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartmentName_SelectedIndexChanged);
            // 
            // comboBoxParentDepartmentNewName
            // 
            this.comboBoxParentDepartmentNewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxParentDepartmentNewName.FormattingEnabled = true;
            this.comboBoxParentDepartmentNewName.Location = new System.Drawing.Point(16, 160);
            this.comboBoxParentDepartmentNewName.Name = "comboBoxParentDepartmentNewName";
            this.comboBoxParentDepartmentNewName.Size = new System.Drawing.Size(322, 28);
            this.comboBoxParentDepartmentNewName.TabIndex = 19;
            // 
            // FormEditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(359, 242);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxDepartmentName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxParentDepartmentNewName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDepartmentNewName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonEditDepartment);
            this.MaximumSize = new System.Drawing.Size(375, 280);
            this.MinimumSize = new System.Drawing.Size(375, 280);
            this.Name = "FormEditDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование подразделения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDepartmentNewName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDepartmentName;
        private System.Windows.Forms.ComboBox comboBoxParentDepartmentNewName;
    }
}