namespace Staff
{
    partial class Form1
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
            this.treeViewDepartments = new System.Windows.Forms.TreeView();
            this.buttonAddDepartment = new System.Windows.Forms.Button();
            this.buttonEditDepartment = new System.Windows.Forms.Button();
            this.buttonRemoveDepartment = new System.Windows.Forms.Button();
            this.checkBoxShowNestedNodeData = new System.Windows.Forms.CheckBox();
            this.dataGridViewWorkers = new System.Windows.Forms.DataGridView();
            this.ColumnIndividualTaxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPositionWorker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRemoveWorker = new System.Windows.Forms.Button();
            this.buttonEditWorker = new System.Windows.Forms.Button();
            this.buttonAddWorker = new System.Windows.Forms.Button();
            this.panelTree = new System.Windows.Forms.Panel();
            this.panelWorkers = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).BeginInit();
            this.panelTree.SuspendLayout();
            this.panelWorkers.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewDepartments
            // 
            this.treeViewDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewDepartments.Location = new System.Drawing.Point(3, 3);
            this.treeViewDepartments.Name = "treeViewDepartments";
            this.treeViewDepartments.Size = new System.Drawing.Size(362, 395);
            this.treeViewDepartments.TabIndex = 0;
            this.treeViewDepartments.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDepartments_NodeMouseClick);
            // 
            // buttonAddDepartment
            // 
            this.buttonAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddDepartment.Location = new System.Drawing.Point(3, 442);
            this.buttonAddDepartment.Name = "buttonAddDepartment";
            this.buttonAddDepartment.Size = new System.Drawing.Size(104, 27);
            this.buttonAddDepartment.TabIndex = 1;
            this.buttonAddDepartment.Text = "Добавить";
            this.buttonAddDepartment.UseVisualStyleBackColor = true;
            this.buttonAddDepartment.Click += new System.EventHandler(this.buttonAddDepartment_Click);
            // 
            // buttonEditDepartment
            // 
            this.buttonEditDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditDepartment.Location = new System.Drawing.Point(133, 442);
            this.buttonEditDepartment.Name = "buttonEditDepartment";
            this.buttonEditDepartment.Size = new System.Drawing.Size(104, 27);
            this.buttonEditDepartment.TabIndex = 2;
            this.buttonEditDepartment.Text = "Изменить";
            this.buttonEditDepartment.UseVisualStyleBackColor = true;
            this.buttonEditDepartment.Click += new System.EventHandler(this.buttonEditDepartment_Click);
            // 
            // buttonRemoveDepartment
            // 
            this.buttonRemoveDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveDepartment.Location = new System.Drawing.Point(261, 442);
            this.buttonRemoveDepartment.Name = "buttonRemoveDepartment";
            this.buttonRemoveDepartment.Size = new System.Drawing.Size(104, 27);
            this.buttonRemoveDepartment.TabIndex = 3;
            this.buttonRemoveDepartment.Text = "Удалить";
            this.buttonRemoveDepartment.UseVisualStyleBackColor = true;
            this.buttonRemoveDepartment.Click += new System.EventHandler(this.buttonRemoveDepartment_Click);
            // 
            // checkBoxShowNestedNodeData
            // 
            this.checkBoxShowNestedNodeData.AutoSize = true;
            this.checkBoxShowNestedNodeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowNestedNodeData.Location = new System.Drawing.Point(3, 413);
            this.checkBoxShowNestedNodeData.Name = "checkBoxShowNestedNodeData";
            this.checkBoxShowNestedNodeData.Size = new System.Drawing.Size(277, 21);
            this.checkBoxShowNestedNodeData.TabIndex = 4;
            this.checkBoxShowNestedNodeData.Text = "Показывать данные вложенных узлов";
            this.checkBoxShowNestedNodeData.UseVisualStyleBackColor = true;
            this.checkBoxShowNestedNodeData.Click += new System.EventHandler(this.checkBoxShowNestedNodeData_Click);
            // 
            // dataGridViewWorkers
            // 
            this.dataGridViewWorkers.AllowUserToAddRows = false;
            this.dataGridViewWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndividualTaxNumber,
            this.ColumnFullName,
            this.ColumnPositionWorker,
            this.ColumnPhoneNumber,
            this.ColumnEMail,
            this.ColumnDepartment});
            this.dataGridViewWorkers.Location = new System.Drawing.Point(4, 3);
            this.dataGridViewWorkers.Name = "dataGridViewWorkers";
            this.dataGridViewWorkers.Size = new System.Drawing.Size(690, 430);
            this.dataGridViewWorkers.TabIndex = 6;
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
            // buttonRemoveWorker
            // 
            this.buttonRemoveWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveWorker.Location = new System.Drawing.Point(275, 441);
            this.buttonRemoveWorker.Name = "buttonRemoveWorker";
            this.buttonRemoveWorker.Size = new System.Drawing.Size(104, 27);
            this.buttonRemoveWorker.TabIndex = 9;
            this.buttonRemoveWorker.Text = "Удалить";
            this.buttonRemoveWorker.UseVisualStyleBackColor = true;
            this.buttonRemoveWorker.Click += new System.EventHandler(this.buttonRemoveWorker_Click);
            // 
            // buttonEditWorker
            // 
            this.buttonEditWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditWorker.Location = new System.Drawing.Point(139, 441);
            this.buttonEditWorker.Name = "buttonEditWorker";
            this.buttonEditWorker.Size = new System.Drawing.Size(104, 27);
            this.buttonEditWorker.TabIndex = 8;
            this.buttonEditWorker.Text = "Изменить";
            this.buttonEditWorker.UseVisualStyleBackColor = true;
            this.buttonEditWorker.Click += new System.EventHandler(this.buttonEditWorker_Click);
            // 
            // buttonAddWorker
            // 
            this.buttonAddWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddWorker.Location = new System.Drawing.Point(4, 441);
            this.buttonAddWorker.Name = "buttonAddWorker";
            this.buttonAddWorker.Size = new System.Drawing.Size(104, 27);
            this.buttonAddWorker.TabIndex = 7;
            this.buttonAddWorker.Text = "Добавить";
            this.buttonAddWorker.UseVisualStyleBackColor = true;
            this.buttonAddWorker.Click += new System.EventHandler(this.buttonAddWorker_Click);
            // 
            // panelTree
            // 
            this.panelTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTree.Controls.Add(this.treeViewDepartments);
            this.panelTree.Controls.Add(this.buttonAddDepartment);
            this.panelTree.Controls.Add(this.buttonEditDepartment);
            this.panelTree.Controls.Add(this.buttonRemoveDepartment);
            this.panelTree.Controls.Add(this.checkBoxShowNestedNodeData);
            this.panelTree.Location = new System.Drawing.Point(3, 8);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(370, 480);
            this.panelTree.TabIndex = 10;
            // 
            // panelWorkers
            // 
            this.panelWorkers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWorkers.Controls.Add(this.dataGridViewWorkers);
            this.panelWorkers.Controls.Add(this.buttonAddWorker);
            this.panelWorkers.Controls.Add(this.buttonRemoveWorker);
            this.panelWorkers.Controls.Add(this.buttonEditWorker);
            this.panelWorkers.Location = new System.Drawing.Point(379, 8);
            this.panelWorkers.Name = "panelWorkers";
            this.panelWorkers.Size = new System.Drawing.Size(700, 480);
            this.panelWorkers.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1083, 498);
            this.Controls.Add(this.panelWorkers);
            this.Controls.Add(this.panelTree);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных работников";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).EndInit();
            this.panelTree.ResumeLayout(false);
            this.panelTree.PerformLayout();
            this.panelWorkers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewDepartments;
        private System.Windows.Forms.Button buttonAddDepartment;
        private System.Windows.Forms.Button buttonEditDepartment;
        private System.Windows.Forms.Button buttonRemoveDepartment;
        private System.Windows.Forms.CheckBox checkBoxShowNestedNodeData;
        private System.Windows.Forms.DataGridView dataGridViewWorkers;
        private System.Windows.Forms.Button buttonRemoveWorker;
        private System.Windows.Forms.Button buttonEditWorker;
        private System.Windows.Forms.Button buttonAddWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndividualTaxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPositionWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDepartment;
        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Panel panelWorkers;
    }
}

