using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Staff
{
    //Класс главной формы
    public partial class FormMain : Form, IView
    {
        //Обьект класса для работы с базой данных
        private Controller controller = null;

        //переменная для хранения названия выбранного узла
        private string selectedNodeText = null;

        //Словарь. Нужен чтобы по названию выбранного узла всегда можно было найти сам узел. используется при перезагрузке дерева из базы данных
        private Dictionary<string, TreeNode> dictionary = new Dictionary<string, TreeNode>();        

        //Конструктор класса формы
        public FormMain()
        {
            InitializeComponent();
            controller= new Controller(this);
        }

        //------Реализация интерфейса IView-------------------------------------//
        //Метод интерфейса IView перезагружает таблицу работников предприятия
        public void refreshTableWorkers()
        {
            dataGridViewWorkers.Rows.Clear();
            dataGridViewWorkers.Refresh();
            dataGridViewWorkers.RowCount = 1;

            if (checkBoxShowNestedNodeData.Checked == false)
            {
                if (selectedNodeText == null)
                {
                    dataGridViewWorkers.RowCount = 0;
                    return;
                }

                TreeNode node;
                if (!dictionary.TryGetValue(selectedNodeText, out node))
                {
                    dataGridViewWorkers.RowCount = 0;
                    return;
                }

                fullTableWorkers(selectedNodeText);
                dataGridViewWorkers.Rows.RemoveAt(dataGridViewWorkers.Rows.Count - 1);
            }
            else
            {
                if (selectedNodeText == null)
                {
                    dataGridViewWorkers.RowCount = 0;
                    return;
                }

                TreeNode node;
                if (!dictionary.TryGetValue(selectedNodeText, out node))
                {
                    dataGridViewWorkers.RowCount = 0;
                    return;
                }

                HashSet<string> departments = new HashSet<string>();
                using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
                {
                    controller.GetAllChildDepartments(context, selectedNodeText, departments);
                }
                departments.Add(selectedNodeText);
                foreach(string department in departments)
                {
                    fullTableWorkers(department);
                }
                dataGridViewWorkers.Rows.RemoveAt(dataGridViewWorkers.Rows.Count - 1);
            }
        }

        //Метод интерфейса IView перезагружает дерево отделов
        public void refreshTreeView()
        {
            treeViewDepartments.Nodes.Clear();
            dictionary.Clear();
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                populateTree(context,null, treeViewDepartments.Nodes);
            }
            treeViewDepartments.ExpandAll();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
            refreshTableWorkers();
        }

        //Метод интерфейса IView выводит сообщение на экран
        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        //Метод интерфейса IView передает название выбранного узла дерева подразделений
        public string getSelectedNodeText()
        {
            if (treeViewDepartments.SelectedNode == null)
            {
                if (treeViewDepartments.Nodes.Count == 0) return null;
                else return treeViewDepartments.Nodes[0].Text;
            }
            return treeViewDepartments.SelectedNode.Text;
        }

        //Метод интерфейса IView передает данные выбранного работника из таблицы работников
        public Workers getSelectedWorker()
        {
            if (dataGridViewWorkers.CurrentCell == null) return null;
            int rowIndex = dataGridViewWorkers.CurrentCell.RowIndex;
            if (rowIndex == -1) return null;

            return new Workers()
            {
                individualTaxNumber = dataGridViewWorkers[0, rowIndex].Value.ToString(),
                fullName = dataGridViewWorkers[1, rowIndex].Value.ToString(),
                positionWorker = dataGridViewWorkers[2, rowIndex].Value.ToString(),
                phoneNumber = dataGridViewWorkers[3, rowIndex].Value.ToString(),
                email = dataGridViewWorkers[4, rowIndex].Value.ToString(),
                department = dataGridViewWorkers[5, rowIndex].Value.ToString()
            };
        }
        //-----------------------------------------------------------------------------------------------//

        //----------Вспомогательные методы--------------------------------------------------------------//        
        //Заполняет дерево отделов из базы данных
        public void populateTree(LinqToSqlStaffdbmlDataContext context,string parentNameDepartment, TreeNodeCollection nodes)
        {
            HashSet<string> set = controller.GetChildDepartments(context, parentNameDepartment);
            foreach (string str in set)
            {
                TreeNode node = new TreeNode(str);
                nodes.Add(node);
                dictionary.Add(str, node);
                populateTree(context,str, node.Nodes);
            }
        }

        //Загружает одну таблицу работников из базы данных в общую таблицу работников предприятия
        private void fullTableWorkers(string selectedDepartment)
        {
            HashSet<Workers> workers = controller.GetTableWorkers(selectedDepartment);
            foreach(var worker in workers)
            {
                dataGridViewWorkers[0, dataGridViewWorkers.RowCount - 1].Value = worker.individualTaxNumber;
                dataGridViewWorkers[1, dataGridViewWorkers.RowCount - 1].Value = worker.fullName;
                dataGridViewWorkers[2, dataGridViewWorkers.RowCount - 1].Value = worker.positionWorker;
                dataGridViewWorkers[3, dataGridViewWorkers.RowCount - 1].Value = worker.phoneNumber;
                dataGridViewWorkers[4, dataGridViewWorkers.RowCount - 1].Value = worker.email;
                dataGridViewWorkers[5, dataGridViewWorkers.RowCount - 1].Value = worker.department;

                dataGridViewWorkers.RowCount++;
            }
        }
        //---------------------------------------------------------------------------------------------------//

        //-----------Методы - обработчики событий----------------------------------------------//
        //Метод вызывается при загрузке формы
        private void FormMain_Load(object sender, EventArgs e)
        {
            refreshTreeView();
            if (treeViewDepartments.Nodes.Count > 0)
            {
                selectedNodeText = treeViewDepartments.Nodes[0].Text;
                treeViewDepartments.SelectedNode = treeViewDepartments.Nodes[0];
            }
        }

        //Метод вызывается при нажатии кнопки удалить подразделение
        private void buttonRemoveDepartment_Click(object sender, EventArgs e)
        {
            FormRemoveDepartment formRemoveDepartment = new FormRemoveDepartment(controller, this);
            formRemoveDepartment.ShowDialog();            
        }

        //Метод вызывается при нажатии кнопки добавить подразделение
        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            FormAddDepartment formAddDepartment = new FormAddDepartment(controller, this);
            formAddDepartment.ShowDialog();

            treeViewDepartments.Select();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
        }

        //Метод вызывается при нажатии кнопки редактировать свойства подразделения
        private void buttonEditDepartment_Click(object sender, EventArgs e)
        {
            FormEditDepartment formEditDepartment = new FormEditDepartment(controller, this);
            formEditDepartment.ShowDialog();

            treeViewDepartments.Select();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
        }

        //Метод вызывается при щелчке мышью на элементе дерева подразделений
        private void treeViewDepartments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedNodeText = e.Node.Text;
            refreshTableWorkers();
        }

        //Метод вызывается при нажатии на кнопку добавить работника
        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            FormAddWorker formAddWorker = new FormAddWorker(controller, this);
            formAddWorker.ShowDialog();

            treeViewDepartments.Select();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
        }

        //Метод вызывается при нажатии на кнопку удалить работника
        private void buttonRemoveWorker_Click(object sender, EventArgs e)
        {
            if (dataGridViewWorkers.CurrentCell == null) return;
            FormRemoveWorker formRemoveWorker = new FormRemoveWorker(controller, this);
            formRemoveWorker.ShowDialog();

            treeViewDepartments.Select();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
        }

        //Метод вызывается при нажатии на кнопку редакировать данные работника
        private void buttonEditWorker_Click(object sender, EventArgs e)
        {
            if (dataGridViewWorkers.CurrentCell == null) return;
            FormEditWorker formEditWorker = new FormEditWorker(controller, this);
            formEditWorker.ShowDialog();

            treeViewDepartments.Select();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
        }

        //Метод вызывается при щелчке кнопки мыши на элементе выбора отображения вложеных узлов
        private void checkBoxShowNestedNodeData_Click(object sender, EventArgs e)
        {
            refreshTableWorkers();

            treeViewDepartments.Select();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
        }
        //----------------------------------------------------------------------------------------//
    }
}
