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
    //Класс формы редактирования данных работника
    public partial class FormEditWorker : Form
    {
        //Переменная которая хранит обьект для работы с базой данных
        private Controller controller = null;

        //Переменная которая хранит обьект реализующий интерфейс IView (главная форма)
        private IView mainView = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private FormEditWorker()
        {
            InitializeComponent();
        }

        //Рабочий конструктор в нем инициализируются переменные и задаются начальные значения текстовых полей формы
        public FormEditWorker(Controller controller, IView mainView)
        {
            InitializeComponent();
            this.controller = controller;
            this.mainView = mainView;

            WorkerProperties worker = mainView.getSelectedWorker();
            if (worker != null)
            {
                textBoxIndividualTaxNumber.Text = worker.getIndividualTaxNumber();
                textBoxFullName.Text = worker.getFullName();
                textBoxPositionWorker.Text = worker.getPositionWorker();
                textBoxPhoneNumber.Text = worker.getPhoneNumber();
                textBoxEmail.Text = worker.getEmail();
                textBoxDepartmentWorker.Text = worker.getDepartmentWorker();

                textBoxNewIndividualTaxNumber.Text = worker.getIndividualTaxNumber();
                textBoxNewFullName.Text = worker.getFullName();
                textBoxNewPositionWorker.Text = worker.getPositionWorker();
                textBoxNewPhoneNumber.Text = worker.getPhoneNumber();
                textBoxNewEmail.Text = worker.getEmail();
                textBoxNewDepartmentWorker.Text = worker.getDepartmentWorker();
            }
        }

        //Метод вызывается при нажатии на кнопку редактировать данные работника
        private void buttonEditWorker_Click(object sender, EventArgs e)
        {
            string individualTaxNumber = textBoxIndividualTaxNumber.Text;
            string department = textBoxDepartmentWorker.Text;

            //Поля И.Н.Н. работника и название его подразделения не могут быть пустыми
            if (individualTaxNumber == "") { MessageBox.Show("Введите индивидуальный налоговый номер"); return; }
            if (department == "") { MessageBox.Show("Введите название подразделения"); return; }

            string newIndividualTaxNumber = textBoxNewIndividualTaxNumber.Text;
            string newDepartment = textBoxNewDepartmentWorker.Text;

            //Поля И.Н.Н. работника и название его подразделения не могут быть пустыми
            if (newIndividualTaxNumber == "") { MessageBox.Show("Введите новый индивидуальный налоговый номер"); return; }
            if (newDepartment == "") { MessageBox.Show("Введите новое название подразделения"); return; }

            //проверка - существует ли указанное подразделение
            TypeResult typeResult = controller.isDepartmentExist(department);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделения с таким названием не существует");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //проверка - существует ли указанное подразделение
            typeResult = controller.isDepartmentExist(newDepartment);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделения с таким названием не существует");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //Не может быть двух работником с одинаковым И.Н.Н. это нужно проверить
            typeResult = controller.isWorkerExist(individualTaxNumber);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Сотрудник с данным И.Н.Н. не работает в этом подразделении");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //Редактирование даннных работника
            TypeResult result = controller.editWorker(individualTaxNumber, department, newIndividualTaxNumber, textBoxNewFullName.Text, textBoxNewPositionWorker.Text, textBoxNewPhoneNumber.Text, textBoxNewEmail.Text, newDepartment);
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
