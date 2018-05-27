using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff
{
    //Класс Формы редактирования свойств подразделения
    public partial class FormEditDepartment : Form
    {
        //Переменная которая хранит обьект для работы с базой данных
        private Controller controller = null;

        //Переменная которая хранит обьект реализующий интерфейс IView (главная форма)
        private IView mainView = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private FormEditDepartment()
        {
            InitializeComponent();
        }

        //Рабочий конструктор в нем инициализируются переменные и задаются начальные значения текстовых полей формы
        public FormEditDepartment(Controller controller, IView mainView)
        {
            InitializeComponent();

            this.controller = controller;
            this.mainView = mainView;

            //Получить название текущего узла
            string selectedNodeText = mainView.getSelectedNodeText();
            if (selectedNodeText == null) return;
            else
            {
                comboBoxDepartmentName.Text = selectedNodeText;
                textBoxDepartmentNewName.Text = selectedNodeText;
            }

            //Получение названий всех подразделений и заполнение элемента combobox в котором хранятся названия подразделений
            HashSet<string> allDepartments = controller.GetAllDepartments();
            foreach (string dep in allDepartments)
            {
                comboBoxDepartmentName.Items.Add(dep);
            }

            //Получение названия родительского подразделения для текущего подразделения
            string parentDepartment = controller.GetParentDepartment(selectedNodeText);
            if (parentDepartment == null) comboBoxParentDepartmentNewName.Text = "";
            else comboBoxParentDepartmentNewName.Text = parentDepartment;

            //Получение названия возможных родительских подразделений
            HashSet<string> departments = new HashSet<string>();
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                controller.GetAllChildDepartments(context, comboBoxDepartmentName.Text, departments);
            }
            departments.Add(comboBoxDepartmentName.Text);
            var resultSet = allDepartments.Except(departments);

            //Заполнение этими названиями компонента combobox в котором они хранятся
            comboBoxParentDepartmentNewName.Items.Add("");
            foreach (string department in resultSet)
            {
                comboBoxParentDepartmentNewName.Items.Add(department);
            }
        }

        //Метод вызывается при нажатии на кнопку редактировать свойства подразделение
        private void buttonEditDepartment_Click(object sender, EventArgs e)
        {
            string departmentName = comboBoxDepartmentName.Text;
            string departmentNewName = textBoxDepartmentNewName.Text;
            string parentDepartmentName = controller.GetParentDepartment(departmentName);
            if (parentDepartmentName == null) parentDepartmentName = "";
            string parentDepartmentNewName = comboBoxParentDepartmentNewName.Text;

            //Если название подразделения и его родительское подразделение не изменились - возвращаемся к главной форме
            if (departmentName.Equals(departmentNewName) && parentDepartmentName.Equals(parentDepartmentNewName))
            {
                Close();
                return;
            }

            HashSet<string> allDepartments;

            //Если новое название подразделения не совпадает со старым - переименовываем подразделение
            if (!departmentName.Equals(departmentNewName))
            {
                //Получаем список подразделений
                allDepartments = controller.GetAllDepartments();

                //Проверка - существует ли подразделение, которое нужно переименовать
                if (!allDepartments.Contains(departmentName))
                {
                    MessageBox.Show("Подразделение, которое вы собираетесь переименовать не существует");
                    return;
                }

                //Проверка - существует ли подразделение с названием таким же как новое название подразделения
                if (allDepartments.Contains(departmentNewName))
                {
                    MessageBox.Show("Подразделение с таким названием уже существует");
                    return;
                }

                //Редактируем название подразделения
                bool res = controller.ChangeNameDepartment(departmentName, departmentNewName);
                //Если произошла ошибка - пробуем еще раз
                if (res == false) return;

                //Если новое название родительского подразделения не совпадает с названием родительского подразделения
                if (!parentDepartmentName.Equals(parentDepartmentNewName))
                {
                    if (parentDepartmentName == "") parentDepartmentName = null;
                    if (parentDepartmentNewName == "") parentDepartmentNewName = null;

                    //Получение списка всех возможных названий родительских подразделений
                    allDepartments = controller.GetAllDepartments();
                    allDepartments.Add(null);
                    HashSet<string> departments = new HashSet<string>();
                    using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
                    {
                        controller.GetAllChildDepartments(context, departmentNewName, departments);
                    }
                    departments.Add(departmentNewName);
                    var resultSet = allDepartments.Except(departments);

                    //Проверка корректности нового родительского подразделения
                    if (!resultSet.Contains(parentDepartmentNewName))
                    {
                        MessageBox.Show("Указанное родительское подразделение недопустимо");
                        return;
                    }

                    //Изменение родительского подразделения
                    bool result = controller.ChangeParentDepartment(departmentNewName, parentDepartmentNewName);
                    //Если не получилось - пробуем еще раз
                    if (result == false) return;
                }
            }
            else
            {
                if (!parentDepartmentName.Equals(parentDepartmentNewName))
                {
                    if (parentDepartmentName == "") parentDepartmentName = null;
                    if (parentDepartmentNewName == "") parentDepartmentNewName = null;

                    //Получение списка всех возможных названий родительских подразделений
                    allDepartments = controller.GetAllDepartments();
                    allDepartments.Add(null);
                    HashSet<string> departments = new HashSet<string>();
                    using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
                    {
                        controller.GetAllChildDepartments(context, departmentName, departments);
                    }
                    departments.Add(departmentName);

                    var resultSet = allDepartments.Except(departments);

                    //Проверка корректности нового родительского подразделения
                    if (!resultSet.Contains(parentDepartmentNewName))
                    {
                        MessageBox.Show("Указанное родительское подразделение недопустимо");
                        return;
                    }

                    //Изменение родительского подразделения
                    bool result = controller.ChangeParentDepartment(departmentName, parentDepartmentNewName);
                    //Если не получилось - пробуем еще раз
                    if (result == false) return;
                }
            }            

            //Перезагрузка дерева подразделений
            mainView.refreshTreeView();

            //Закрытие формы редактирования подразделения
            Close();
        }

        //Метод вызывается при нажатии на кнопку отмена
        private void buttonCansel_Click(object sender, EventArgs e)
        {
            //Закрытие формы редактирования подразделения
            Close();
        }

        //Метод вызывается при изменении названия текущего подразделения. При этом меняются возможные родительские подразделения
        private void comboBoxDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxParentDepartmentNewName.Items.Clear();

            HashSet<string> allDepartments = controller.GetAllDepartments();
            string parentDepartment = controller.GetParentDepartment(comboBoxDepartmentName.Text);
            if (parentDepartment == null) comboBoxParentDepartmentNewName.Text = "";
            else comboBoxParentDepartmentNewName.Text = parentDepartment;

            HashSet<string> departments = new HashSet<string>();
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                controller.GetAllChildDepartments(context, comboBoxDepartmentName.Text, departments);
            }
            departments.Add(comboBoxDepartmentName.Text);
            var resultSet = allDepartments.Except(departments);
            comboBoxParentDepartmentNewName.Items.Add("");
            foreach (string department in resultSet)
            {
                comboBoxParentDepartmentNewName.Items.Add(department);
            }
        }
    }
}
