using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff
{
    public interface IView
    {
        //Перезагружает таблицу работников предприятия
        void refreshTableWorkers();

        //Перезагружает дерево отделов
        void refreshTreeView();

        //Передает название выбранного узла дерева подразделений
        string getSelectedNodeText();

        //Передает данные выбранного работника из таблицы работников
        WorkerProperties getSelectedWorker();

        //Выводит сообщение на экран
        void showMessage(string message);
    }
}
