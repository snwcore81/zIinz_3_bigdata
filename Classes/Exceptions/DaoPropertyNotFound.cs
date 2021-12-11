using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class DaoPropertyNotFound : Exception
    {
        public DaoPropertyNotFound(object a_oDbObj, string a_sPropName)
            : base($"W obiekcie <{a_oDbObj.GetType().Name}> nie odnaleziono własności <{a_sPropName}>!")
        {

        }
    }
}
