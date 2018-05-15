using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff
{
    //Клас создан для получения данных и внесения изменений в базу данных
    //Сначала хотел реализовать MVC, но Model здеси не очень то и нужна :)
    public class Controller
    {
        //Строка подключения в случае когда нужно работать с базой данных на сервере. В настройках сервера не было пароля, но при желании его можно добавить, тогда в строку будет входить также логин и пароль
        //"Data Source=MARI_PK;Initial Catalog=CompanyEmployees;Integrated Security=True";

        //Строка подключения для работы с локальной базой данных, которая находится в папках проэкта
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length-@"\bin\Debug".Length, @"\bin\Debug".Length) + @"\CompanyEmployees.mdf;Integrated Security=True";

        //Переменная для хранения обьекта, реализующего интерфейс IView. (Главная форма)
        private IView view = null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private Controller() { }

        //Рабочий конструктор
        public Controller(IView view)
        {
            this.view = view;
        }

        //------------Методы для работы с таблицей работников-----------------------------------------------//
        //Метод проверяет был ли добавлен ранее работник с таким И.Н.Н (однофамильцы то бывают, а людей с одинаковым И.Н.Н нет)
        public TypeResult isWorkerExist(string individualTaxNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    ArrayList list = new ArrayList();
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM IndividualTaxNumbers WHERE individualTaxNumber = '" + individualTaxNumber + "'";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0));
                    }
                    reader.Close();
                    if (list.Count > 0) return TypeResult.positiveResult;

                    return TypeResult.negativeResult;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("16");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
            return TypeResult.exceptionResult;
        }

        //Метод добавляет данные нового работника в базу данных
        public TypeResult addWorker(string individualTaxNumber,string fullName,string positionWorker,string phoneNumber,string Email,string departmentWorker)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO [" + departmentWorker + " workers] VALUES ('" + individualTaxNumber + "','" + fullName + "','" + positionWorker + "','" + phoneNumber + "','" + Email + "')";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "INSERT INTO IndividualTaxNumbers VALUES ('" + individualTaxNumber + "')";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("15");
                    return TypeResult.exceptionResult;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return TypeResult.exceptionResult;
                }
            }
            return TypeResult.positiveResult;
        }

        //Метод удаляет данные работника из базы данных
        public TypeResult removeWorker(string individualTaxNumber, string departmentWorker)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "DELETE FROM [" + departmentWorker + " workers] WHERE individualTaxNumber = '" + individualTaxNumber + "'";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "DELETE FROM IndividualTaxNumbers WHERE individualTaxNumber = '" + individualTaxNumber + "'";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("14");
                    return TypeResult.exceptionResult;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return TypeResult.exceptionResult;
                }
            }
            return TypeResult.positiveResult;
        }

        //Метод позволяет редактировать данные работника
        public TypeResult editWorker(string individualTaxNumber, string departmentWorker, string newIndividualTaxNumber, string newFullName, string newPositionWorker, string newPhoneNumber, string newEmail, string newDepartment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (departmentWorker.Equals(newDepartment))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "UPDATE [" + departmentWorker + " workers] SET individualTaxNumber = '" + newIndividualTaxNumber + "',fullName = '" + newFullName + "',positionWorker = '" + newPositionWorker + "',phoneNumber = '" + newPhoneNumber + "',email = '" + newEmail + "' WHERE individualTaxNumber = '" + individualTaxNumber + "'";
                        command.Connection = connection;
                        int rows = command.ExecuteNonQuery();
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "DELETE FROM [" + departmentWorker + " workers] WHERE individualTaxNumber = '" + individualTaxNumber + "'";
                        command.Connection = connection;
                        int rows = command.ExecuteNonQuery();

                        command = new SqlCommand();
                        command.CommandText = "INSERT INTO [" + newDepartment + " workers] VALUES ('" + newIndividualTaxNumber + "','" + newFullName + "','" + newPositionWorker + "','" + newPhoneNumber + "','" + newEmail + "')";
                        command.Connection = connection;
                        rows = command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("13");
                    return TypeResult.exceptionResult;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return TypeResult.exceptionResult;
                }
            }
            return TypeResult.positiveResult;
        }

        //Метод позволяет получить данные работников указанного департамента
        public ArrayList[] getTableWorker(string department)
        {
            ArrayList[] table = new ArrayList[] {new ArrayList(),new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM [" + department + " workers]";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        table[0].Add(reader.GetValue(0));
                        table[1].Add(reader.GetValue(1));
                        table[2].Add(reader.GetValue(2));
                        table[3].Add(reader.GetValue(3));
                        table[4].Add(reader.GetValue(4));
                        table[5].Add(department);
                    }
                    reader.Close();

                    return table;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("12");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }

            return table;
        }
        //----------------------------------------------------------------------------------------------------------------//

        //------------Методы для работы с деревом подразделений-----------------------------------------------//
        //Метод проверяет было ли добавлено ранее подразделение с таким же названием
        public TypeResult isDepartmentExist(string nameDepartment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    ArrayList list = new ArrayList();
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM sys.objects WHERE type in (N'U')";//"SELECT * FROM ["+ parentNameDepartment + " departments] WHERE Departments = '" + nameDepartment+"'";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0));
                    }
                    reader.Close();
                    if (list.Contains(nameDepartment)) return TypeResult.positiveResult;

                    return TypeResult.negativeResult;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("1");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
            return TypeResult.exceptionResult;
        }

        //Метод возвращает список дочерних подразделений для указанного подразделения
        public ArrayList listChildDepartments(string parentDepartmentName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    ArrayList list = new ArrayList();
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM [" + parentDepartmentName + " departments]";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0));
                    }
                    reader.Close();
                    return list;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("2");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
            return null;
        }

        //Метод возвращает родительское подразделение для указанного подразделения
        public string getParentDepartment(string nameDepartment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string parentNameDepartment = null;
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM [" + nameDepartment + "]";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        parentNameDepartment = (string)reader.GetValue(2);
                    }
                    reader.Close();
                    return parentNameDepartment;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("3");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
            return null;
        }

        //Метод позволяет переименовать указанное подразделение
        public TypeResult renameDepartment(string nameDepartment,string newNameDepartment)
        {
            string parentDepartment = getParentDepartment(nameDepartment);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE [" + parentDepartment + " departments] SET Departments = '"+ newNameDepartment + "' WHERE  Departments = '" + nameDepartment + "'";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "UPDATE [" + nameDepartment + "] SET tableDepartments = '" + newNameDepartment + " departments',tableWorkers = '" + newNameDepartment + " workers'";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    ArrayList listDep = new ArrayList();
                    command = new SqlCommand();
                    command.CommandText = "SELECT * FROM [" + nameDepartment + " departments]";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listDep.Add((string)reader.GetValue(0));
                    }
                    reader.Close();

                    foreach(string nameDep in listDep)
                    {
                        command = new SqlCommand();
                        command.CommandText = "UPDATE [" + nameDep + "] SET parentDepartment = '" + newNameDepartment + "'";
                        command.Connection = connection;
                        rows = command.ExecuteNonQuery();
                    }

                    command = new SqlCommand();
                    command.CommandText = "sp_rename [" + nameDepartment + "], [" + newNameDepartment + "];";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "sp_rename [" + nameDepartment + " departments], [" + newNameDepartment + " departments];";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "sp_rename [" + nameDepartment + " workers], [" + newNameDepartment + " workers];";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("4");
                    return TypeResult.exceptionResult;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return TypeResult.exceptionResult;
                }
            }

            return TypeResult.positiveResult;
        }

        //Метод позволяет изменить родительское подразделение для указанного подразделения
        public TypeResult changeParentDepartment(string nameDepartment, string newParentDepartment)
        {
            string parentDepartment = getParentDepartment(nameDepartment);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE [" + nameDepartment + "] SET parentDepartment = '" + newParentDepartment + "'";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "DELETE FROM [" + parentDepartment + " departments] WHERE Departments='" + nameDepartment + "'";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "INSERT INTO [" + newParentDepartment + " departments] VALUES ('" + nameDepartment + "')";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("5");
                    return TypeResult.exceptionResult;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return TypeResult.exceptionResult;
                }
            }

            return TypeResult.positiveResult;
        }

        //Метод позволяет добавить новое подразделение
        public bool addDepartment(string parentNameDepartment,string nameDepartment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO [" + parentNameDepartment + " departments] VALUES ('" + nameDepartment + "')";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "CREATE TABLE [" + nameDepartment + "] (tableDepartments NVARCHAR(100), tableWorkers NVARCHAR(100), parentDepartment NVARCHAR(100));";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "INSERT INTO [" + nameDepartment + "] VALUES ('" + nameDepartment + " departments','" + nameDepartment + " workers','" + parentNameDepartment + "')";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "CREATE TABLE [" + nameDepartment + " departments] (Departments NVARCHAR(100));";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "CREATE TABLE [" + nameDepartment + " workers] (individualTaxNumber NVARCHAR(20) NOT NULL,fullName NVARCHAR(100), positionWorker NVARCHAR(100), phoneNumber NVARCHAR(50), email NVARCHAR(50));";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("6");
                    return false;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return false;
                }
            }
        }

        //Метод позволяет удалить ветвь подразделений
        private TypeResult dropTablesTree(ArrayList listDepartments)
        {
            TypeResult result = TypeResult.exceptionResult;
            foreach (string nameDepartment in listDepartments)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        ArrayList list = new ArrayList();
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "SELECT * FROM [" + nameDepartment + " departments]";
                        command.Connection = connection;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add((string)reader.GetValue(0));
                        }
                        reader.Close();

                        if (list.Count > 0) result = dropTablesTree(list);

                        ArrayList listITN = new ArrayList();
                        command = new SqlCommand();
                        command.CommandText = "SELECT * FROM [" + nameDepartment + " workers]";
                        command.Connection = connection;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listITN.Add(reader.GetValue(0));
                        }
                        reader.Close();

                        foreach (string ITN in listITN)
                        {
                            command = new SqlCommand();
                            command.CommandText = "DELETE FROM IndividualTaxNumbers WHERE individualTaxNumber='" + ITN + "'";
                            command.Connection = connection;
                            command.ExecuteNonQuery();
                        }

                        command = new SqlCommand();
                        command.CommandText = "DROP TABLE [" + nameDepartment + "]";
                        command.Connection = connection;
                        int rows = command.ExecuteNonQuery();

                        command = new SqlCommand();
                        command.CommandText = "DROP TABLE [" + nameDepartment + " departments]";
                        command.Connection = connection;
                        rows = command.ExecuteNonQuery();

                        command = new SqlCommand();
                        command.CommandText = "DROP TABLE [" + nameDepartment + " workers]";
                        command.Connection = connection;
                        rows = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        view.showMessage(ex.Message);
                        view.showMessage("7");
                        return TypeResult.exceptionResult;
                    }
                    catch (Exception ex)
                    {
                        view.showMessage(ex.Message);
                        return TypeResult.exceptionResult;
                    }
                }
            }
            return TypeResult.positiveResult;
        }

        //Метод позволяет удалить указанное подразделение
        public bool removeDepartment(string nameDepartment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string parentNameDepartment = null;
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM ["+ nameDepartment + "]";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        parentNameDepartment=(string)reader.GetValue(2);
                    }
                    reader.Close();

                    ArrayList listITN = new ArrayList();
                    command = new SqlCommand();
                    command.CommandText = "SELECT * FROM [" + nameDepartment + " workers]";
                    command.Connection = connection;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listITN.Add(reader.GetValue(0));
                    }
                    reader.Close();

                    foreach(string ITN in listITN)
                    {
                        command = new SqlCommand();
                        command.CommandText = "DELETE FROM IndividualTaxNumbers WHERE individualTaxNumber='" + ITN + "'";
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                    }

                    command = new SqlCommand();
                    command.CommandText = "DELETE FROM [" + parentNameDepartment + " departments] WHERE Departments='"+ nameDepartment + "'";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    ArrayList list = new ArrayList();
                    list.Add(nameDepartment);
                    TypeResult result = dropTablesTree(list);
                    if (result == TypeResult.exceptionResult) return false;
                    return true;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("8");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
            return false;
        }

        //------------------------Вспомогательные методы------------------------------------//
        //Метод создает корневое подразделение
        public void createTableRoot()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "CREATE TABLE root (tableDepartments NVARCHAR(100), tableWorkers NVARCHAR(100), parentDepartment NVARCHAR(100));";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "INSERT INTO root VALUES ('root departments',NULL,NULL)";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();

                    command = new SqlCommand();
                    command.CommandText = "CREATE TABLE [root departments] (Departments NVARCHAR(100));";
                    command.Connection = connection;
                    rows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("9");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
        }

        //Метод позволяет получить список всех таблиц в базе данных
        public ArrayList listTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    ArrayList list = new ArrayList();
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM sys.objects WHERE type in (N'U')";
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0));
                    }
                    reader.Close();
                    return list;
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("10");
                    return null;
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return null;
                }
            }
        }

        //Метод создает таблицу для хранения И.Н.Н. каждого работника
        public void createTableIndividualTaxNumbers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "CREATE TABLE IndividualTaxNumbers (individualTaxNumber NVARCHAR(20));";
                    command.Connection = connection;
                    int rows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    view.showMessage(ex.Message);
                    view.showMessage("11");
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                }
            }
        }
        //---------------------------------------------------------------------------------------------//        
    }
}
