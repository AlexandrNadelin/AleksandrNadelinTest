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
    //Класс Формы удаления подразделения
    public partial class FormRemoveDepartment : Form
    {
        //Переменная которая хранит обьект для работы с базой данных
        private Controller controller = null;

        //Переменная которая хранит обьект реализующий интерфейс IView (главная форма)
        private IView mainView = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private FormRemoveDepartment()
        {
            InitializeComponent();
        }

        //Рабочий конструктор в нем инициализируются переменные и задаются начальные значения текстовых полей формы
        public FormRemoveDepartment(Controller controller, IView mainView)
        {
            InitializeComponent();
            this.controller = controller;
            this.mainView = mainView;
            string selectedNodeText = mainView.getSelectedNodeText();
            if (selectedNodeText != null) textBoxDepartmentName.Text = mainView.getSelectedNodeText();
        }

        //Метод вызывается при нажатии на кнопку удалить подразделение
        private void buttonRemoveDepartment_Click(object sender, EventArgs e)
        {
            //Текстовое поле удаляемого подразделения не должно быть пустым
            if (textBoxDepartmentName.Text.Equals(""))
            {
                MessageBox.Show("Введите название отдела");
                return;
            }

            //Проверка - существует ли подразделение с данным названием
            TypeResult typeResult = controller.isDepartmentExist(textBoxDepartmentName.Text);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделения с таким названием не существует");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //Удаление подразделения
            controller.removeDepartment(textBoxDepartmentName.Text);

            //Перезагрузка дерева подразделений
            mainView.refreshTreeView();

            //Закрытие формы удаления подразделения
            Close();
        }

        //Метод вызывается при нажатии на кнопку отмена
        private void buttonCansel_Click(object sender, EventArgs e)
        {
            //Закрытие формы удаления подразделения
            Close();
        }
    }
}
