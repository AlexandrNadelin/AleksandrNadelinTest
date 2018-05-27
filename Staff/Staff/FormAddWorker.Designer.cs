namespace Staff
{
    partial class FormAddWorker
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
            this.textBoxIndividualTaxNumber = new System.Windows.Forms.TextBox();
            this.buttonAddWorker = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.comboBoxPositionWorker = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartmentWorker = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCansel
            // 
            this.buttonCansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(239, 239);
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
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "И.Н.Н.";
            // 
            // textBoxIndividualTaxNumber
            // 
            this.textBoxIndividualTaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIndividualTaxNumber.Location = new System.Drawing.Point(166, 18);
            this.textBoxIndividualTaxNumber.Name = "textBoxIndividualTaxNumber";
            this.textBoxIndividualTaxNumber.Size = new System.Drawing.Size(323, 26);
            this.textBoxIndividualTaxNumber.TabIndex = 1;
            // 
            // buttonAddWorker
            // 
            this.buttonAddWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddWorker.Location = new System.Drawing.Point(16, 239);
            this.buttonAddWorker.Name = "buttonAddWorker";
            this.buttonAddWorker.Size = new System.Drawing.Size(150, 29);
            this.buttonAddWorker.TabIndex = 8;
            this.buttonAddWorker.Text = "Добавить";
            this.buttonAddWorker.UseVisualStyleBackColor = true;
            this.buttonAddWorker.Click += new System.EventHandler(this.buttonAddWorker_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ф.И.О.";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFullName.Location = new System.Drawing.Point(166, 52);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(323, 26);
            this.textBoxFullName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Должность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Подразделение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmail.Location = new System.Drawing.Point(166, 156);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(323, 26);
            this.textBoxEmail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Номер телефона";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(166, 122);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(323, 26);
            this.textBoxPhoneNumber.TabIndex = 4;
            // 
            // comboBoxPositionWorker
            // 
            this.comboBoxPositionWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPositionWorker.FormattingEnabled = true;
            this.comboBoxPositionWorker.Location = new System.Drawing.Point(166, 87);
            this.comboBoxPositionWorker.Name = "comboBoxPositionWorker";
            this.comboBoxPositionWorker.Size = new System.Drawing.Size(323, 28);
            this.comboBoxPositionWorker.TabIndex = 3;
            // 
            // comboBoxDepartmentWorker
            // 
            this.comboBoxDepartmentWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDepartmentWorker.FormattingEnabled = true;
            this.comboBoxDepartmentWorker.Location = new System.Drawing.Point(166, 189);
            this.comboBoxDepartmentWorker.Name = "comboBoxDepartmentWorker";
            this.comboBoxDepartmentWorker.Size = new System.Drawing.Size(323, 28);
            this.comboBoxDepartmentWorker.TabIndex = 6;
            // 
            // FormAddWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(504, 282);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxDepartmentWorker);
            this.Controls.Add(this.comboBoxPositionWorker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIndividualTaxNumber);
            this.Controls.Add(this.buttonAddWorker);
            this.MaximumSize = new System.Drawing.Size(520, 320);
            this.MinimumSize = new System.Drawing.Size(520, 320);
            this.Name = "FormAddWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление работника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIndividualTaxNumber;
        private System.Windows.Forms.Button buttonAddWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.ComboBox comboBoxPositionWorker;
        private System.Windows.Forms.ComboBox comboBoxDepartmentWorker;
    }
}