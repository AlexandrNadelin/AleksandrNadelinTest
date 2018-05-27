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

            Workers worker = mainView.getSelectedWorker();
            if(worker!=null)
            {
                textBoxIndividualTaxNumber.Text = worker.individualTaxNumber;
                textBoxFullName.Text = worker.fullName;
                textBoxDepartmentWorker.Text = worker.department;
            }
        }

        //Метод вызывается при нажатии на кнопку удаления работника
        private void buttonRemoveWorker_Click(object sender, EventArgs e)
        {
            string individualTaxNumber = textBoxIndividualTaxNumber.Text;
            string department = textBoxDepartmentWorker.Text;

            //Удаление работника с указанным И.Н.Н.
            bool result = controller.RemoveWorker(individualTaxNumber);
            //Если не получилось - пробуем еще раз
            if (result == false) return;

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
