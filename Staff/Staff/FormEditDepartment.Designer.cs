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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxParentDepartmentName = new System.Windows.Forms.TextBox();
            this.textBoxDepartmentName = new System.Windows.Forms.TextBox();
            this.buttonEditDepartment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDepartmentNewName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxParentDepartmentNewName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCansel
            // 
            this.buttonCansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(198, 263);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(150, 29);
            this.buttonCansel.TabIndex = 13;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Родительское подразделение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Название подразделения";
            // 
            // textBoxParentDepartmentName
            // 
            this.textBoxParentDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxParentDepartmentName.Location = new System.Drawing.Point(7, 27);
            this.textBoxParentDepartmentName.Name = "textBoxParentDepartmentName";
            this.textBoxParentDepartmentName.Size = new System.Drawing.Size(323, 26);
            this.textBoxParentDepartmentName.TabIndex = 10;
            // 
            // textBoxDepartmentName
            // 
            this.textBoxDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDepartmentName.Location = new System.Drawing.Point(7, 30);
            this.textBoxDepartmentName.Name = "textBoxDepartmentName";
            this.textBoxDepartmentName.Size = new System.Drawing.Size(323, 26);
            this.textBoxDepartmentName.TabIndex = 9;
            // 
            // buttonEditDepartment
            // 
            this.buttonEditDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditDepartment.Location = new System.Drawing.Point(8, 263);
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
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Новое название подразделения";
            // 
            // textBoxDepartmentNewName
            // 
            this.textBoxDepartmentNewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDepartmentNewName.Location = new System.Drawing.Point(7, 88);
            this.textBoxDepartmentNewName.Name = "textBoxDepartmentNewName";
            this.textBoxDepartmentNewName.Size = new System.Drawing.Size(323, 26);
            this.textBoxDepartmentNewName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Новое родительское подразделение";
            // 
            // textBoxParentDepartmentNewName
            // 
            this.textBoxParentDepartmentNewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxParentDepartmentNewName.Location = new System.Drawing.Point(7, 88);
            this.textBoxParentDepartmentNewName.Name = "textBoxParentDepartmentNewName";
            this.textBoxParentDepartmentNewName.Size = new System.Drawing.Size(323, 26);
            this.textBoxParentDepartmentNewName.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxDepartmentName);
            this.panel1.Controls.Add(this.textBoxDepartmentNewName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(8, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 122);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxParentDepartmentName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxParentDepartmentNewName);
            this.panel2.Location = new System.Drawing.Point(8, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 122);
            this.panel2.TabIndex = 19;
            // 
            // FormEditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(359, 303);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonEditDepartment);
            this.Name = "FormEditDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование подразделения";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParentDepartmentName;
        private System.Windows.Forms.TextBox textBoxDepartmentName;
        private System.Windows.Forms.Button buttonEditDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDepartmentNewName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxParentDepartmentNewName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}