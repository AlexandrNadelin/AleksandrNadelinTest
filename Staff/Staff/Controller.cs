using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Staff
{
    //Клас создан для получения данных и внесения изменений в базу данных
    //Сначала хотел реализовать MVC, но Model здеси не очень то и нужна :)
    public class Controller
    {
        //Переменная для хранения обьекта, реализующего интерфейс IView. (Главная форма)
        private IView view = null;

        //LinqToSqlStaffdbmlDataContext context =null;

        //Конструктор по умолчанию. private - чтобы нельзя было его создать
        private Controller() { }

        //Рабочий конструктор
        public Controller(IView view)
        {
            this.view = view;            
        }

        //------------Методы для работы с деревом подразделений-----------------------------------------------//
        //Метод добавляет подразделение
        public bool AddDepartment(string departmentName,string parentDepartmentName)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                int parentId = -1;
                if (parentDepartmentName != null)
                {
                    var departments = from dep in context.Departments where dep.Department == parentDepartmentName select dep;
                    parentId = departments.First().Id;
                }                

                Departments newDep = new Departments
                {
                    Department = departmentName,
                    ParentId_ = parentId,
                };

                context.Departments.InsertOnSubmit(newDep);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return false;
                }
            }
            return true;
        }

        //Метод удаляет подразделение
        public bool RemoveDepartment(string departmentName)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                List<int> list = new List<int>();
                try
                {
                    var department = (from dep in context.Departments where dep.Department == departmentName select dep).Single();
                    if (department == null) return false;
                    list.Add(department.Id);
                }
                catch (Exception ex)
                {
                    return false;
                }                
                RemoveListDepartments(context, list);
            }
            return true;
        }

        //Метод удаляет список подразделений
        private bool RemoveListDepartments(LinqToSqlStaffdbmlDataContext context, List<int> listIdDepartments)
        {
            foreach(int depId in listIdDepartments)
            {
                var departments = from dep in context.Departments where dep.ParentId_ == depId select dep;
                List<int> list = new List<int>();
                foreach (var department in departments)
                {
                    list.Add(department.Id);
                }
                RemoveListDepartments(context, list);

                try
                {
                    var department = (from dep in context.Departments where dep.Id == depId select dep).Single();
                    string departmentName = department.Department;
                    context.Departments.DeleteOnSubmit(department);
                    context.SubmitChanges();

                    var workers = from work in context.Workers where work.department == departmentName select work;
                    foreach (var worker in workers)
                    {
                        context.Workers.DeleteOnSubmit(worker);
                        context.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }                
            }
            return true;
        }

        //Метод возвращяет множество всех подразделений
        public HashSet<string> GetAllDepartments()
        {
            HashSet<string> list = new HashSet<string>();
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                var departments = context.Departments;
                foreach(var dep in departments)
                {
                    list.Add(dep.Department);
                }
            }

            return list;
        }

        //Метод возвращяет множество дочерних подразделений
        public HashSet<string> GetChildDepartments(LinqToSqlStaffdbmlDataContext context, string parentDepartmentName)
        {
            HashSet<string> list = new HashSet<string>();
            int parentId = -1;
            if (parentDepartmentName != null)
            {
                try
                {
                    var department = (from dep in context.Departments where dep.Department == parentDepartmentName select dep).Single();
                    parentId = department.Id;
                }
                catch(Exception ex)
                {
                    return list;
                }       
            }

            var departments = from dep in context.Departments where dep.ParentId_ == parentId select dep;
            foreach(var dep in departments)
            {
                list.Add(dep.Department);
            }

            return list;
        }

        //Метод возвращяет множество всех дочерних подразделений
        public void GetAllChildDepartments(LinqToSqlStaffdbmlDataContext context,string parentDepartmentsName,HashSet<string> allChildDepartments)
        {
            HashSet<string> childDepartments = GetChildDepartments(context, parentDepartmentsName);
            foreach(string dep in childDepartments)
            {
               allChildDepartments.Add(dep);
               GetAllChildDepartments(context, dep, allChildDepartments);
            }
        }

        //Метод изменяет название подразделения
        public bool ChangeNameDepartment(string departmentName,string departmentNewName)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                try
                {
                    var department = (from dep in context.Departments where dep.Department == departmentName select dep).Single();
                    department.Department = departmentNewName;
                    context.SubmitChanges();

                    var workers = from items in context.Workers where items.department == departmentName select items;
                    foreach (var worker in workers)
                    {
                        worker.department = departmentNewName;
                        context.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        //Метод возвращает название родительского подразделения для указанного подразделения
        public string GetParentDepartment(string departmentName)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                try
                {
                    var department = (from dep in context.Departments where dep.Department == departmentName select dep).Single();
                    if (department == null) return null;

                    int parentId = department.ParentId_;

                    if (parentId == -1) return null;

                    department = (from dep in context.Departments where dep.Id == parentId select dep).Single();
                    if (department == null) return null;
                    return department.Department;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        //Метод изменяет родительское подразделение для указанного подразделения
        public bool ChangeParentDepartment(string departmentName, string parentDepartmentNewName)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                try
                {
                    int parentDepartmentNewNameId = -1;

                    if (parentDepartmentNewName != null)
                    {
                        var department = (from dep in context.Departments where dep.Department == parentDepartmentNewName select dep).Single();
                        if (department == null) return false;
                        parentDepartmentNewNameId = department.Id;
                    }

                    var department_ = (from dep in context.Departments where dep.Department == departmentName select dep).Single();
                    department_.ParentId_ = parentDepartmentNewNameId;
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                 
            }
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------//
        
        //------------Методы для работы с таблицей работников-----------------------------------------------//
        //Метод добавляет работника
        public bool AddWorker(string individualTaxNumber, string fullName, string positionWorker, string phoneNumber, string email, string departmentWorker)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                Workers newWorker = new Workers
                {
                    individualTaxNumber = individualTaxNumber,
                    fullName = fullName,
                    positionWorker = positionWorker,
                    phoneNumber=phoneNumber,
                    email=email,
                    department=departmentWorker
                };

                context.Workers.InsertOnSubmit(newWorker);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return false;
                }

                return true;
            }
        }

        //Метод проверяет - существует ли работник с указанным И.Н.Н.
        public bool IsWorkerExist(string individualTaxNumber)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                try
                {
                    var worker = (from work in context.Workers where work.individualTaxNumber == individualTaxNumber select work).Single();
                    return(worker != null);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //Метод возвращает таблицу работников, принадлежащих указанному подразделению
        public HashSet<Workers> GetTableWorkers(string selectedDepartment)
        {
            HashSet<Workers> workersSet = new HashSet<Workers>();
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                var workers = from work in context.Workers where work.department == selectedDepartment select work;
                foreach(var worker in workers)
                {
                    workersSet.Add(worker);
                }
                return workersSet;
            }
        }

        //Метод удаляет работника с указанным И.Н.Н.
        public bool RemoveWorker(string individualTaxNumber)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                try
                {
                    var worker = (from work in context.Workers where work.individualTaxNumber== individualTaxNumber select work).Single();
                    context.Workers.DeleteOnSubmit(worker);
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    view.showMessage(ex.Message);
                    return false;
                }
            }
            return true;
        }

        //Метод изменяет данные работника с указанным И.Н.Н.
        public bool EditWorker(string individualTaxNumber, string newIndividualTaxNumber, string newFullName, string newPositionWorker, string newPhoneNumber, string newEmail, string newDepartmentWorker)
        {
            using (LinqToSqlStaffdbmlDataContext context = new LinqToSqlStaffdbmlDataContext())
            {
                try
                {
                    var worker = (from work in context.Workers where work.individualTaxNumber == individualTaxNumber select work).Single();
                    if (individualTaxNumber.Equals(newIndividualTaxNumber))
                    {
                        worker.fullName = newFullName;
                        worker.positionWorker = newPositionWorker;
                        worker.phoneNumber = newPhoneNumber;
                        worker.email = newEmail;
                        worker.department = newDepartmentWorker;

                        context.SubmitChanges();
                    }
                    else
                    {
                        context.Workers.DeleteOnSubmit(worker);
                        context.SubmitChanges();

                        Workers newWorker = new Workers
                        {
                            individualTaxNumber = newIndividualTaxNumber,
                            fullName = newFullName,
                            positionWorker = newPositionWorker,
                            phoneNumber = newPhoneNumber,
                            email = newEmail,
                            department = newDepartmentWorker
                        };

                        context.Workers.InsertOnSubmit(newWorker);
                        context.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------//
    }
}


