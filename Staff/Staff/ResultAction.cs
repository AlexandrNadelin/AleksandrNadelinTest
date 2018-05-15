using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff
{
    //Перечисление возможных вариантов завершения метода
    public enum TypeResult
    {
        positiveResult,//метод завершился с результатом true
        negativeResult,//метод завершился с результатом false
        exceptionResult//метод завершился исключением
    }
}
