using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class StateObjectDataIsNull : Exception
    {
        public StateObjectDataIsNull() :
            base("Referencja do danych ma wartość null!")
        {

        }
    }
}
