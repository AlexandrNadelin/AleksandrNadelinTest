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

namespace Staff
{
    //Класс главной формы
    public partial class Form1 : Form, IView
    {
        //Обьект класса для работы с базой данных
        private Controller controller = null;

        //переменная для хранения названия выбранного узла
        private string selectedNodeText = null;

        //Словарь. Нужен чтобы по названию выбранного узла всегда можно было найти сам узел. используется при перезагрузке дерева из базы данных
        private Dictionary<string, TreeNode> dictionary = new Dictionary<string, TreeNode>();

        //Конструктор класса формы
        public Form1()
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

                ArrayList list = new ArrayList();
                list.Add(selectedNodeText);
                fullTableWorkersRecursive(list);
                dataGridViewWorkers.Rows.RemoveAt(dataGridViewWorkers.Rows.Count - 1);
            }
        }

        //Метод интерфейса IView перезагружает дерево отделов
        public void refreshTreeView()
        {
            treeViewDepartments.Nodes.Clear();
            dictionary.Clear();
            populateTree(null, treeViewDepartments.Nodes);
            treeViewDepartments.ExpandAll();
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node)) treeViewDepartments.SelectedNode = node;
            }
            refreshTableWorkers();//!!!!!
        }

        //Метод интерфейса IView выводит сообщение на экран
        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        //Метод интерфейса IView передает название выбранного узла дерева подразделений
        public string getSelectedNodeText()
        {
            if (treeViewDepartments.SelectedNode == null) return null;
            return treeViewDepartments.SelectedNode.Text;
        }

        //Метод интерфейса IView передает данные выбранного работника из таблицы работников
        public WorkerProperties getSelectedWorker()
        {
            int rowIndex = dataGridViewWorkers.CurrentCell.RowIndex;
            if (rowIndex == -1) return null;
            if (dataGridViewWorkers[0, rowIndex].Value == null
                || dataGridViewWorkers[1, rowIndex].Value == null
                || dataGridViewWorkers[2, rowIndex].Value == null
                || dataGridViewWorkers[3, rowIndex].Value == null
                || dataGridViewWorkers[4, rowIndex].Value == null
                || dataGridViewWorkers[5, rowIndex].Value == null) return null;

            return new WorkerProperties(dataGridViewWorkers[0, rowIndex].Value.ToString()
                , dataGridViewWorkers[1, rowIndex].Value.ToString()
                , dataGridViewWorkers[2, rowIndex].Value.ToString()
                , dataGridViewWorkers[3, rowIndex].Value.ToString()
                , dataGridViewWorkers[4, rowIndex].Value.ToString()
                , dataGridViewWorkers[5, rowIndex].Value.ToString());
        }
        //-----------------------------------------------------------------------------------------------//

        //----------Вспомогательные методы--------------------------------------------------------------//        
        //Заполняет дерево отделов из базы данных
        public void populateTree(string parentNameDepartment, TreeNodeCollection nodes)
        {
            if (parentNameDepartment == null) parentNameDepartment = "root";
            ArrayList list = controller.listChildDepartments(parentNameDepartment);
            if (list != null)
            {
                foreach (string str in list)
                {
                    TreeNode node = new TreeNode(str);
                    nodes.Add(node);
                    dictionary.Add(str, node);
                    populateTree(str, node.Nodes);
                }
            }
        }

        //Загружает одну таблицу работников из базы данных в общую таблицу работников предприятия
        private void fullTableWorkers(string selectedDepartment)
        {
            ArrayList[] table = controller.getTableWorker(selectedDepartment);
            for (int j = 0; j < table[0].Count; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    dataGridViewWorkers[i, dataGridViewWorkers.RowCount - 1].Value = table[i][j];
                }
                dataGridViewWorkers.RowCount++;
            }
        }

        //Загружает таблицы работников из базы данных в общую таблицу
        private void fullTableWorkersRecursive(ArrayList listDepartments)
        {
            foreach (string department in listDepartments)
            {
                fullTableWorkers(department);

                ArrayList list = controller.listChildDepartments(department);
                fullTableWorkersRecursive(list);
            }
        }
        //---------------------------------------------------------------------------------------------------//

        //-----------Методы - обработчики событий----------------------------------------------//
        //Метод вызывается при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList listTables = controller.listTable();
            if (listTables == null)
            {
                MessageBox.Show("Невозможно связаться с базой данных. Приложение будет закрыто.");
                Application.Exit();
                return;
            }
            if (!listTables.Contains("root departments")) controller.createTableRoot();
            if (!listTables.Contains("IndividualTaxNumbers")) controller.createTableIndividualTaxNumbers();

            dictionary.Clear();
            populateTree(null, treeViewDepartments.Nodes);
            treeViewDepartments.ExpandAll();
            if (treeViewDepartments.Nodes.Count > 0) selectedNodeText = treeViewDepartments.Nodes[0].Text;
            if (selectedNodeText != null)
            {
                TreeNode node;
                if (dictionary.TryGetValue(selectedNodeText, out node))
                {
                    treeViewDepartments.SelectedNode = node;
                    refreshTableWorkers();
                }
            }
        }

        //Метод вызывается при нажатии кнопки удалить подразделение
        private void buttonRemoveDepartment_Click(object sender, EventArgs e)
        {
            FormRemoveDepartment formRemoveDepartment = new FormRemoveDepartment(controller, this);
            formRemoveDepartment.Show();
        }

        //Метод вызывается при нажатии кнопки добавить подразделение
        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            FormAddDepartment formAddDepartment = new FormAddDepartment(controller, this);
            formAddDepartment.Show();
        }

        //Метод вызывается при нажатии кнопки редактировать свойства подразделения
        private void buttonEditDepartment_Click(object sender, EventArgs e)
        {
            FormEditDepartment formEditDepartment = new FormEditDepartment(controller, this);
            formEditDepartment.Show();
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
            formAddWorker.Show();
        }

        //Метод вызывается при нажатии на кнопку удалить работника
        private void buttonRemoveWorker_Click(object sender, EventArgs e)
        {
            FormRemoveWorker formRemoveWorker = new FormRemoveWorker(controller, this);
            formRemoveWorker.Show();
        }

        //Метод вызывается при нажатии на кнопку редакировать данные работника
        private void buttonEditWorker_Click(object sender, EventArgs e)
        {
            FormEditWorker formEditWorker = new FormEditWorker(controller, this);
            formEditWorker.Show();
        }

        //Метод вызывается при щелчке кнопки мыши на элементе выбора отображения вложеных узлов
        private void checkBoxShowNestedNodeData_Click(object sender, EventArgs e)
        {
            refreshTableWorkers();
        }
        //----------------------------------------------------------------------------------------//
    }
}
