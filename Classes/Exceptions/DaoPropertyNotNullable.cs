using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class DaoPropertyNotNullable : Exception
    {
        public DaoPropertyNotNullable(object a_oDbObj, string a_sPropName)
            : base($"W obiekcie <{a_oDbObj.GetType().Name}> własność <{a_sPropName}> jest oznaczona jako NotNull! Nie można przypisać wartości")
        {

        }
    }
}
