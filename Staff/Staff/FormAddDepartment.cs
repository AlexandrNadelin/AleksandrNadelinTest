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
    //Класс Формы добавления подразделения
    public partial class FormAddDepartment : Form
    {
        //Переменная которая хранит обьект для работы с базой данных
        private Controller controller = null;

        //Переменная которая хранит обьект реализующий интерфейс IView (главная форма)
        private IView mainView = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private FormAddDepartment()
        {
            InitializeComponent();
        }

        //Рабочий конструктор в нем инициализируются переменные и задаются начальные значения текстовых полей формы
        public FormAddDepartment(Controller controller,IView mainView)
        {
            InitializeComponent();
            this.controller = controller;
            this.mainView = mainView;
            string selectedNodeText = mainView.getSelectedNodeText();
            if(selectedNodeText!=null) comboBoxParentDepartmentName.Text = mainView.getSelectedNodeText();

            comboBoxParentDepartmentName.Items.Add("");
            HashSet<string> set = controller.GetAllDepartments();
            foreach(string str in set)
            {
                comboBoxParentDepartmentName.Items.Add(str);
            }
        }

        //Метод вызывается при нажатии на кнопку добавить подразделение
        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            //текстовое поле названия подразделения не должно быть пустым
            if (textBoxDepartmentName.Text.Equals(""))
            {
                MessageBox.Show("Введите название подразделения");
                return;
            }

            //Добавление подразделения
            bool result = controller.AddDepartment(textBoxDepartmentName.Text, comboBoxParentDepartmentName.Text == "" ? null : comboBoxParentDepartmentName.Text);
            //Если не получилось можно попробовать опять
            if (result == false) return;

            //Перезагрузка дерева подразделений
            mainView.refreshTreeView();

            //Закрытие формы
            Close();
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            //Закрытие формы
            Close();
        }
    }
}
