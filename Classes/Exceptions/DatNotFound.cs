using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class DatNotFound : Exception
    {
        public DatNotFound(string TableName,string PrimaryKey) :
            base($"W tabeli <{TableName}> nie odnaleziono rekordu o kluczu [{PrimaryKey}]")
        {

        }
    }
}
