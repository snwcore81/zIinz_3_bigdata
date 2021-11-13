using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class StateObjectReferenceIsNull : Exception
    {
        public StateObjectReferenceIsNull() :
            base("Referencja do obiektu ma wartość null!")
        {
        }
    }
}
