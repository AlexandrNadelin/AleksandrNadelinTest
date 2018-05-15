using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff
{
    //Клас создан специально для передачи данных работника между методами
    public class WorkerProperties
    {
        private string individualTaxNumber = null;//И.Н.Н
        private string fullName = null;           //Ф.И.О
        private string positionWorker = null;     //Должность
        private string phoneNumber = null;        //Номер телефона
        private string email = null;              //email
        private string departmentWorker = null;   //подразделение предприятия к которому относится работник

        //Конструктор по умолчанию. private - чтобы нельзя было его создать :)
        private WorkerProperties(){}

        //Рабочий конструктор
        public WorkerProperties(string individualTaxNumber, string fullName,string positionWorker,string phoneNumber,string email,string departmentWorker)
        {
            this.individualTaxNumber = individualTaxNumber;
            this.fullName = fullName;
            this.positionWorker = positionWorker;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.departmentWorker = departmentWorker;
        }

        //Геттеры соответствующие полям
        public string getIndividualTaxNumber() { return individualTaxNumber; } //И.Н.Н
        public string getFullName() { return fullName; }                       //Ф.И.О
        public string getPositionWorker() { return positionWorker; }           //Должность
        public string getPhoneNumber() { return phoneNumber; }                 //Номер телефона
        public string getEmail() { return email; }                             //email
        public string getDepartmentWorker() { return departmentWorker; }       //подразделение предприятия к которому относится работник

    }
}
