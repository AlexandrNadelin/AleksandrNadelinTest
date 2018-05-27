namespace Staff
{
    partial class FormAddDepartment
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
            this.buttonAddDepartment = new System.Windows.Forms.Button();
            this.textBoxDepartmentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.comboBoxParentDepartmentName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonAddDepartment
            // 
            this.buttonAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddDepartment.Location = new System.Drawing.Point(12, 189);
            this.buttonAddDepartment.Name = "buttonAddDepartment";
            this.buttonAddDepartment.Size = new System.Drawing.Size(150, 29);
            this.buttonAddDepartment.TabIndex = 2;
            this.buttonAddDepartment.Text = "Добавить";
            this.buttonAddDepartment.UseVisualStyleBackColor = true;
            this.buttonAddDepartment.Click += new System.EventHandler(this.buttonAddDepartment_Click);
            // 
            // textBoxDepartmentName
            // 
            this.textBoxDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDepartmentName.Location = new System.Drawing.Point(12, 52);
            this.textBoxDepartmentName.Name = "textBoxDepartmentName";
            this.textBoxDepartmentName.Size = new System.Drawing.Size(323, 26);
            this.textBoxDepartmentName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Название подразделения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Родительское подразделение";
            // 
            // buttonCansel
            // 
            this.buttonCansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(185, 189);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(150, 29);
            this.buttonCansel.TabIndex = 7;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // comboBoxParentDepartmentName
            // 
            this.comboBoxParentDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxParentDepartmentName.FormattingEnabled = true;
            this.comboBoxParentDepartmentName.Location = new System.Drawing.Point(12, 130);
            this.comboBoxParentDepartmentName.Name = "comboBoxParentDepartmentName";
            this.comboBoxParentDepartmentName.Size = new System.Drawing.Size(322, 28);
            this.comboBoxParentDepartmentName.TabIndex = 8;
            // 
            // FormAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(344, 232);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxParentDepartmentName);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDepartmentName);
            this.Controls.Add(this.buttonAddDepartment);
            this.MaximumSize = new System.Drawing.Size(360, 270);
            this.MinimumSize = new System.Drawing.Size(360, 270);
            this.Name = "FormAddDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление подразделения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDepartment;
        private System.Windows.Forms.TextBox textBoxDepartmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.ComboBox comboBoxParentDepartmentName;
    }
}