using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            Workers worker = mainView.getSelectedWorker();
            if (worker == null) return;
            textBoxIndividualTaxNumber.Text = worker.individualTaxNumber;
            textBoxFullName.Text = worker.fullName;
            textBoxPositionWorker.Text = worker.positionWorker;
            textBoxPhoneNumber.Text = worker.phoneNumber;
            textBoxEmail.Text = worker.email;
            textBoxDepartmentWorker.Text = worker.department;

            textBoxNewIndividualTaxNumber.Text = worker.individualTaxNumber;
            textBoxNewFullName.Text = worker.fullName;
            comboBoxNewPositionWorker.Text = worker.positionWorker;
            textBoxNewPhoneNumber.Text = worker.phoneNumber;
            textBoxNewEmail.Text = worker.email;
            comboBoxNewDepartmentWorker.Text = worker.department;

            comboBoxNewPositionWorker.Items.Add("Директор");
            comboBoxNewPositionWorker.Items.Add("Бухгалтер");
            comboBoxNewPositionWorker.Items.Add("Программист");
            comboBoxNewPositionWorker.Items.Add("ИТД И ТП");

            HashSet<string> departments = controller.GetAllDepartments();
            foreach (string department in departments)
            {
                comboBoxNewDepartmentWorker.Items.Add(department);
            }
        }

        //Проверка строки ИНН (в инн должно быть 12 цифр)
        private bool СheckIndividualTaxNumber(string individualTaxNumber)
        {
            string pattern = "[0-9]{12}";
            if (individualTaxNumber.Length != 12) return false;
            if (Regex.IsMatch(individualTaxNumber, pattern)) return true;
            return false;
        }

        //Проверка корректности Ф.И.О.
        private bool СheckFullName(string fullName)
        {
            string pattern = @"([А-ЯЁ][а-яё]+[\-\s]?){3,}";
            if (Regex.IsMatch(fullName, pattern)) return true;
            return false;
        }

        //Проверка корректности должности работника (не пустое поле )
        private bool СheckPositionWorker(string positionWorker)
        {
            if (positionWorker == "") return false;
            return true;
        }

        //Проверка корректности номера телефона
        private bool СheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == "") return true;

            string pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            if (Regex.IsMatch(phoneNumber, pattern)) return true;
            return false;
        }

        //Пооверка корректности email
        private bool СheckEmail(string email)
        {
            if (email == "") return true;

            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (Regex.IsMatch(email, pattern)) return true;
            return false;
        }

        //Проверка корректности введенного подразделения, так как подразделение можно не только выбирать но и вводить вручную
        private bool CheckDepartment(string departmentName)
        {
            HashSet<string> departments = controller.GetAllDepartments();
            return departments.Contains(departmentName);
        }

        //Метод вызывается при нажатии на кнопку редактировать данные работника
        private void buttonEditWorker_Click(object sender, EventArgs e)
        {
            //Поле не должно быть пустым
            if (textBoxNewIndividualTaxNumber.Text == "")
            {
                MessageBox.Show("Введите И.Н.Н.");
                return;
            }

            //Проверка корректности И.Н.Н.
            if (!СheckIndividualTaxNumber(textBoxNewIndividualTaxNumber.Text))
            {
                MessageBox.Show("Не корректный И.Н.Н.");
                return;
            }

            //Проверка - существует ли уже такой работник. Проверка по И.Н.Н. А не по Ф.И.О. потому что встречаются полные однофамильцы
            if (controller.IsWorkerExist(textBoxNewIndividualTaxNumber.Text)&&(!textBoxNewIndividualTaxNumber.Text.Equals(textBoxIndividualTaxNumber.Text)))
            {
                MessageBox.Show("Работник с таким И.Н.Н. уже существует");
                return;
            }

            //Поле не должно быть пустым
            if (textBoxNewFullName.Text == "")
            {
                MessageBox.Show("Введите Ф.И.О.");
                return;
            }

            //Проверка корректности Ф.И.О. (В реальной базе данных я бы не проводил , потому что бывают разные -аглы,-кызы,ибн и т. д.)
            if (!СheckFullName(textBoxNewFullName.Text))
            {
                MessageBox.Show("Не корректный Ф.И.О.");
                return;
            }

            //Проверка корректности должности работника
            if (!СheckPositionWorker(comboBoxNewPositionWorker.Text))
            {
                MessageBox.Show("Введите или выберите название должности");
                return;
            }

            //Проверка корректности номера телефона
            if (!СheckPhoneNumber(textBoxNewPhoneNumber.Text))
            {
                MessageBox.Show("Не корректный номер телефона");
                return;
            }

            //Проверка коректности email
            if (!СheckEmail(textBoxNewEmail.Text))
            {
                MessageBox.Show("Не корректный email");
                return;
            }

            //Поле не должно быть пустым
            if (comboBoxNewDepartmentWorker.Text == "")
            {
                MessageBox.Show("Выберите название подразделения");
                return;
            }

            //Проверка корректности подразделения
            if (!CheckDepartment(comboBoxNewDepartmentWorker.Text))
            {
                MessageBox.Show("Такого подразделения не существует");
                return;
            }

            //Добавление работника
            bool result = controller.EditWorker(textBoxIndividualTaxNumber.Text,textBoxNewIndividualTaxNumber.Text, textBoxNewFullName.Text, comboBoxNewPositionWorker.Text, textBoxNewPhoneNumber.Text, textBoxNewEmail.Text, comboBoxNewDepartmentWorker.Text);
            //если ошибка - пробуем еще раз
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
