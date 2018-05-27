namespace Staff
{
    partial class FormRemoveWorker
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
            this.buttonRemoveWorker = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDepartmentWorker = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCansel
            // 
            this.buttonCansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(281, 178);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(150, 29);
            this.buttonCansel.TabIndex = 27;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "И.Н.Н.";
            // 
            // textBoxIndividualTaxNumber
            // 
            this.textBoxIndividualTaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIndividualTaxNumber.Location = new System.Drawing.Point(166, 48);
            this.textBoxIndividualTaxNumber.Name = "textBoxIndividualTaxNumber";
            this.textBoxIndividualTaxNumber.ReadOnly = true;
            this.textBoxIndividualTaxNumber.Size = new System.Drawing.Size(323, 26);
            this.textBoxIndividualTaxNumber.TabIndex = 25;
            // 
            // buttonRemoveWorker
            // 
            this.buttonRemoveWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveWorker.Location = new System.Drawing.Point(58, 178);
            this.buttonRemoveWorker.Name = "buttonRemoveWorker";
            this.buttonRemoveWorker.Size = new System.Drawing.Size(150, 29);
            this.buttonRemoveWorker.TabIndex = 24;
            this.buttonRemoveWorker.Text = "Удалить работника";
            this.buttonRemoveWorker.UseVisualStyleBackColor = true;
            this.buttonRemoveWorker.Click += new System.EventHandler(this.buttonRemoveWorker_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Ф.И.О.";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFullName.Location = new System.Drawing.Point(166, 86);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.ReadOnly = true;
            this.textBoxFullName.Size = new System.Drawing.Size(323, 26);
            this.textBoxFullName.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Подразделение";
            // 
            // textBoxDepartmentWorker
            // 
            this.textBoxDepartmentWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDepartmentWorker.Location = new System.Drawing.Point(166, 128);
            this.textBoxDepartmentWorker.Name = "textBoxDepartmentWorker";
            this.textBoxDepartmentWorker.ReadOnly = true;
            this.textBoxDepartmentWorker.Size = new System.Drawing.Size(323, 26);
            this.textBoxDepartmentWorker.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(78, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "Подтвердите удаление работника";
            // 
            // FormRemoveWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(504, 222);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDepartmentWorker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIndividualTaxNumber);
            this.Controls.Add(this.buttonRemoveWorker);
            this.MaximumSize = new System.Drawing.Size(520, 260);
            this.MinimumSize = new System.Drawing.Size(520, 260);
            this.Name = "FormRemoveWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление работника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIndividualTaxNumber;
        private System.Windows.Forms.Button buttonRemoveWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDepartmentWorker;
        private System.Windows.Forms.Label label3;
    }
}