namespace Staff
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewWorkers = new System.Windows.Forms.DataGridView();
            this.ColumnIndividualTaxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPositionWorker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddWorker = new System.Windows.Forms.Button();
            this.buttonRemoveWorker = new System.Windows.Forms.Button();
            this.buttonEditWorker = new System.Windows.Forms.Button();
            this.treeViewDepartments = new System.Windows.Forms.TreeView();
            this.buttonAddDepartment = new System.Windows.Forms.Button();
            this.buttonEditDepartment = new System.Windows.Forms.Button();
            this.buttonRemoveDepartment = new System.Windows.Forms.Button();
            this.checkBoxShowNestedNodeData = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewWorkers
            // 
            this.dataGridViewWorkers.AllowUserToAddRows = false;
            this.dataGridViewWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndividualTaxNumber,
            this.ColumnFullName,
            this.ColumnPositionWorker,
            this.ColumnPhoneNumber,
            this.ColumnEMail,
            this.ColumnDepartment});
            this.dataGridViewWorkers.Location = new System.Drawing.Point(315, 12);
            this.dataGridViewWorkers.Name = "dataGridViewWorkers";
            this.dataGridViewWorkers.RowHeadersVisible = false;
            this.dataGridViewWorkers.Size = new System.Drawing.Size(609, 430);
            this.dataGridViewWorkers.TabIndex = 11;
            // 
            // ColumnIndividualTaxNumber
            // 
            this.ColumnIndividualTaxNumber.HeaderText = "И.Н.Н.";
            this.ColumnIndividualTaxNumber.Name = "ColumnIndividualTaxNumber";
            // 
            // ColumnFullName
            // 
            this.ColumnFullName.HeaderText = "Ф.И.О.";
            this.ColumnFullName.Name = "ColumnFullName";
            // 
            // ColumnPositionWorker
            // 
            this.ColumnPositionWorker.HeaderText = "Должность";
            this.ColumnPositionWorker.Name = "ColumnPositionWorker";
            // 
            // ColumnPhoneNumber
            // 
            this.ColumnPhoneNumber.HeaderText = "Номер телефона";
            this.ColumnPhoneNumber.Name = "ColumnPhoneNumber";
            // 
            // ColumnEMail
            // 
            this.ColumnEMail.HeaderText = "email";
            this.ColumnEMail.Name = "ColumnEMail";
            // 
            // ColumnDepartment
            // 
            this.ColumnDepartment.HeaderText = "Подразделение";
            this.ColumnDepartment.Name = "ColumnDepartment";
            // 
            // buttonAddWorker
            // 
            this.buttonAddWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddWorker.Location = new System.Drawing.Point(315, 451);
            this.buttonAddWorker.Name = "buttonAddWorker";
            this.buttonAddWorker.Size = new System.Drawing.Size(104, 27);
            this.buttonAddWorker.TabIndex = 12;
            this.buttonAddWorker.Text = "Добавить";
            this.buttonAddWorker.UseVisualStyleBackColor = true;
            this.buttonAddWorker.Click += new System.EventHandler(this.buttonAddWorker_Click);
            // 
            // buttonRemoveWorker
            // 
            this.buttonRemoveWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveWorker.Location = new System.Drawing.Point(575, 451);
            this.buttonRemoveWorker.Name = "buttonRemoveWorker";
            this.buttonRemoveWorker.Size = new System.Drawing.Size(104, 27);
            this.buttonRemoveWorker.TabIndex = 14;
            this.buttonRemoveWorker.Text = "Удалить";
            this.buttonRemoveWorker.UseVisualStyleBackColor = true;
            this.buttonRemoveWorker.Click += new System.EventHandler(this.buttonRemoveWorker_Click);
            // 
            // buttonEditWorker
            // 
            this.buttonEditWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditWorker.Location = new System.Drawing.Point(441, 451);
            this.buttonEditWorker.Name = "buttonEditWorker";
            this.buttonEditWorker.Size = new System.Drawing.Size(104, 27);
            this.buttonEditWorker.TabIndex = 13;
            this.buttonEditWorker.Text = "Изменить";
            this.buttonEditWorker.UseVisualStyleBackColor = true;
            this.buttonEditWorker.Click += new System.EventHandler(this.buttonEditWorker_Click);
            // 
            // treeViewDepartments
            // 
            this.treeViewDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewDepartments.Location = new System.Drawing.Point(7, 12);
            this.treeViewDepartments.Name = "treeViewDepartments";
            this.treeViewDepartments.Size = new System.Drawing.Size(297, 395);
            this.treeViewDepartments.TabIndex = 15;
            this.treeViewDepartments.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDepartments_NodeMouseClick);
            // 
            // buttonAddDepartment
            // 
            this.buttonAddDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddDepartment.Location = new System.Drawing.Point(7, 451);
            this.buttonAddDepartment.Name = "buttonAddDepartment";
            this.buttonAddDepartment.Size = new System.Drawing.Size(89, 27);
            this.buttonAddDepartment.TabIndex = 16;
            this.buttonAddDepartment.Text = "Добавить";
            this.buttonAddDepartment.UseVisualStyleBackColor = true;
            this.buttonAddDepartment.Click += new System.EventHandler(this.buttonAddDepartment_Click);
            // 
            // buttonEditDepartment
            // 
            this.buttonEditDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditDepartment.Location = new System.Drawing.Point(112, 451);
            this.buttonEditDepartment.Name = "buttonEditDepartment";
            this.buttonEditDepartment.Size = new System.Drawing.Size(86, 27);
            this.buttonEditDepartment.TabIndex = 17;
            this.buttonEditDepartment.Text = "Изменить";
            this.buttonEditDepartment.UseVisualStyleBackColor = true;
            this.buttonEditDepartment.Click += new System.EventHandler(this.buttonEditDepartment_Click);
            // 
            // buttonRemoveDepartment
            // 
            this.buttonRemoveDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveDepartment.Location = new System.Drawing.Point(212, 451);
            this.buttonRemoveDepartment.Name = "buttonRemoveDepartment";
            this.buttonRemoveDepartment.Size = new System.Drawing.Size(92, 27);
            this.buttonRemoveDepartment.TabIndex = 18;
            this.buttonRemoveDepartment.Text = "Удалить";
            this.buttonRemoveDepartment.UseVisualStyleBackColor = true;
            this.buttonRemoveDepartment.Click += new System.EventHandler(this.buttonRemoveDepartment_Click);
            // 
            // checkBoxShowNestedNodeData
            // 
            this.checkBoxShowNestedNodeData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowNestedNodeData.AutoSize = true;
            this.checkBoxShowNestedNodeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowNestedNodeData.Location = new System.Drawing.Point(7, 422);
            this.checkBoxShowNestedNodeData.Name = "checkBoxShowNestedNodeData";
            this.checkBoxShowNestedNodeData.Size = new System.Drawing.Size(277, 21);
            this.checkBoxShowNestedNodeData.TabIndex = 19;
            this.checkBoxShowNestedNodeData.Text = "Показывать данные вложенных узлов";
            this.checkBoxShowNestedNodeData.UseVisualStyleBackColor = true;
            this.checkBoxShowNestedNodeData.Click += new System.EventHandler(this.checkBoxShowNestedNodeData_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(934, 482);
            this.Controls.Add(this.treeViewDepartments);
            this.Controls.Add(this.buttonAddDepartment);
            this.Controls.Add(this.buttonEditDepartment);
            this.Controls.Add(this.buttonRemoveDepartment);
            this.Controls.Add(this.checkBoxShowNestedNodeData);
            this.Controls.Add(this.dataGridViewWorkers);
            this.Controls.Add(this.buttonAddWorker);
            this.Controls.Add(this.buttonRemoveWorker);
            this.Controls.Add(this.buttonEditWorker);
            this.MinimumSize = new System.Drawing.Size(950, 520);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных работников";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewWorkers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndividualTaxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPositionWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDepartment;
        private System.Windows.Forms.Button buttonAddWorker;
        private System.Windows.Forms.Button buttonRemoveWorker;
        private System.Windows.Forms.Button buttonEditWorker;
        private System.Windows.Forms.TreeView treeViewDepartments;
        private System.Windows.Forms.Button buttonAddDepartment;
        private System.Windows.Forms.Button buttonEditDepartment;
        private System.Windows.Forms.Button buttonRemoveDepartment;
        private System.Windows.Forms.CheckBox checkBoxShowNestedNodeData;
    }
}

