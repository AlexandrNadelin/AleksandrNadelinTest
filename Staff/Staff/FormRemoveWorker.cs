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
    public partial class FormRemoveWorker : Form
    {
        //Переменная которая хранит обьект для работы с базой данных
        private Controller controller = null;

        //Переменная которая хранит обьект реализующий интерфейс IView (главная форма)
        private IView mainView = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private FormRemoveWorker()
        {
            InitializeComponent();
        }

        //Рабочий конструктор в нем инициализируются переменные и задаются начальные значения текстовых полей формы
        public FormRemoveWorker(Controller controller, IView mainView)
        {
            InitializeComponent();
            this.controller = controller;
            this.mainView = mainView;

            WorkerProperties worker = mainView.getSelectedWorker();
            if(worker!=null)
            {
                textBoxIndividualTaxNumber.Text = worker.getIndividualTaxNumber();
                textBoxFullName.Text = worker.getFullName();
                textBoxDepartmentWorker.Text = worker.getDepartmentWorker();
            }
        }

        //Метод вызывается при нажатии на кнопку удаления работника
        private void buttonRemoveWorker_Click(object sender, EventArgs e)
        {
            string individualTaxNumber = textBoxIndividualTaxNumber.Text;
            string department = textBoxDepartmentWorker.Text;

            //Поля И.Н.Н. работника и название его подразделения не могут быть пустыми
            if (individualTaxNumber == "") { MessageBox.Show("Введите индивидуальный налоговый номер"); return; }
            if (department == "") { MessageBox.Show("Введите название подразделения"); return; }

            //проверка - существует ли указанное подразделение
            TypeResult typeResult = controller.isDepartmentExist(department);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Подразделения с таким названием не существует");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //проверка - существует ли указанный работник
            typeResult = controller.isWorkerExist(individualTaxNumber);
            if (typeResult == TypeResult.negativeResult)
            {
                MessageBox.Show("Сотрудник с данным И.Н.Н. уже не работает в этом подразделении");
                return;
            }
            else if (typeResult == TypeResult.exceptionResult) return;

            //удаление работника
            TypeResult result = controller.removeWorker(individualTaxNumber, department);
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
