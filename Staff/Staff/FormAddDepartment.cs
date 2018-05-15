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
            if(selectedNodeText!=null)textBoxParentDepartmentName.Text = mainView.getSelectedNodeText();
        }

        //Метод вызывается при нажатии на кнопку добавить подразделение
        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            //текстовое поле названия подразделения не должно быть пустым
            if (textBoxDepartmentName.Text.Equals(""))
            {
                MessageBox.Show("Введите название отдела");
                return;
            }

            //проверка - существует ли подразделение с таким же названием (По ТЗ не должно)
            TypeResult typeResult = controller.isDepartmentExist(textBoxDepartmentName.Text);
            if (typeResult == TypeResult.positiveResult)
            {
                MessageBox.Show("Подразделение с таким названием уже существует");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //Текстовое поле названия родительского подразделения должно быть пустым если создается фирма. В этом случае название фирмы помещается в корневой каталог
            if (textBoxParentDepartmentName.Text.Equals(""))
            {
                if(!controller.addDepartment("root", textBoxDepartmentName.Text))return;
            }
            else//В противном случае создается подразделение. родительским для которого является подразделение указанное в соответствующем текстовом поле
            {
                if(!controller.addDepartment(textBoxParentDepartmentName.Text, textBoxDepartmentName.Text))return;
            }

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
