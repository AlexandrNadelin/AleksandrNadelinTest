using System;
using System.Collections;
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
    //Класс формы добавления работника
    public partial class FormAddWorker : Form
    {
        //Переменная которая хранит обьект для работы с базой данных
        private Controller controller = null;

        //Переменная которая хранит обьект реализующий интерфейс IView (главная форма)
        private IView mainView = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private FormAddWorker()
        {
            InitializeComponent();
        }

        //Рабочий конструктор в нем инициализируются переменные и задаются начальные значения текстовых полей формы
        public FormAddWorker(Controller controller, IView mainView)
        {
            InitializeComponent();
            this.controller = controller;
            this.mainView = mainView;
            string selectedNodeText = mainView.getSelectedNodeText();
            if (selectedNodeText != null) textBoxDepartmentWorker.Text = selectedNodeText;
        }

        //Метод вызывается при нажатии на кнопку добавить работника
        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            string individualTaxNumber = textBoxIndividualTaxNumber.Text;
            string department = textBoxDepartmentWorker.Text;

            //Поля И.Н.Н. работника и название его подразделения не могут быть пустыми
            if (individualTaxNumber == "") { MessageBox.Show("Введите индивидуальный налоговый номер");return;}
            if (department == "") { MessageBox.Show("Введите название подразделения"); return; }

            //проверка - существует ли указанное подразделение
            TypeResult typeResult = controller.isDepartmentExist(department);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделения с таким названием не существует");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //Не может быть двух работником с одинаковым И.Н.Н. это нужно проверить
            typeResult = controller.isWorkerExist(individualTaxNumber);
            if (typeResult == TypeResult.positiveResult)
            {
                MessageBox.Show("Сотрудник с данным И.Н.Н. уже работает в одном из подразделений");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //Добавление работника в базу данных
            TypeResult result = controller.addWorker(individualTaxNumber, textBoxFullName.Text, textBoxPositionWorker.Text, textBoxPhoneNumber.Text, textBoxEmail.Text, department);
            if (result == TypeResult.exceptionResult) return;

            //Перезагрузка таблицы работников
            mainView.refreshTableWorkers();

            //Закрытие формы добавления работника
            Close();
        }

        //Метод вызывается при нажатии на кнопку отмена
        private void buttonCansel_Click(object sender, EventArgs e)
        {
            //Закрытие формы добавления работника
            Close();
        }
    }
}
