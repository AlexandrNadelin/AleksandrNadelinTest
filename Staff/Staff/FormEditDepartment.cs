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
            string selectedNodeText = mainView.getSelectedNodeText();
            if (selectedNodeText == null) return;
            else
            {
                textBoxDepartmentName.Text = selectedNodeText;
                textBoxDepartmentNewName.Text = selectedNodeText;
            }

            string parentDepartment = controller.getParentDepartment(selectedNodeText);
            if (parentDepartment == null || parentDepartment.Equals("root"))
            {
                textBoxParentDepartmentName.Text = "";
                textBoxParentDepartmentNewName.Text = "";
            }
            else
            {
                textBoxParentDepartmentName.Text = parentDepartment;
                textBoxParentDepartmentNewName.Text = parentDepartment;
            }
        }

        //Метод вызывается при нажатии на кнопку редактировать свойства подразделение
        private void buttonEditDepartment_Click(object sender, EventArgs e)
        {
            string departmentName = textBoxDepartmentName.Text;
            string parentDepartmentName = textBoxParentDepartmentName.Text;
            string departmentNewName = textBoxDepartmentNewName.Text;
            string parentDepartmentNewName = textBoxParentDepartmentNewName.Text;

            //root - название корневого каталога, так что при попытке его переименовать мы потеряем все данные. Надо этого избежать.
            if (departmentName.Equals("root")||parentDepartmentName.Equals("root")||departmentNewName.Equals("root") || departmentNewName.Equals("") || parentDepartmentNewName.Equals("root")) MessageBox.Show("Недопустимое имя");

            //Если текстовое поле названия родительского подразделения пустое, значит добавлять подразделение нужно в корневой каталог
            if (parentDepartmentName.Equals("")) parentDepartmentName = "root";
            if (parentDepartmentNewName.Equals("")) parentDepartmentNewName = "root";

            //проверка - существует ли подразделение с данным названием
            TypeResult result = controller.isDepartmentExist(departmentName);
            if (result == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделения с таким названием не существует");
                return;
            }
            else if (result == TypeResult.exceptionResult) return;

            //проверка - существует ли подразделение с данным названием
            result = controller.isDepartmentExist(parentDepartmentName);
            if (result == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделение с таким названием не существует");
                return;
            }
            else if (result == TypeResult.exceptionResult) return;

            //проверка - существует ли подразделение с данным названием
            result = controller.isDepartmentExist(departmentNewName);
            if (result == TypeResult.positiveResult && (!departmentName.Equals(departmentNewName)))
            {
                MessageBox.Show("Подразделение с таким названием уже существует");
                return;
            }
            else if (result == TypeResult.exceptionResult) return;

            if(!departmentName.Equals(departmentNewName))
            {
                //Изменение названия подразделения
                controller.renameDepartment(departmentName, departmentNewName);

                if (!parentDepartmentName.Equals(parentDepartmentNewName))
                {
                    //Изменение родительского подразделения
                    controller.changeParentDepartment(departmentNewName, parentDepartmentNewName);
                }
            }
            else
            {
                if (!parentDepartmentName.Equals(parentDepartmentNewName))
                {
                    //Изменение родительского подразделения
                    controller.changeParentDepartment(departmentName, parentDepartmentNewName);
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
    }
}
