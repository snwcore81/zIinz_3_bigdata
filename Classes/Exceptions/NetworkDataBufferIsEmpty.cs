using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class NetworkDataBufferIsEmpty : Exception
    {
        public NetworkDataBufferIsEmpty(string a_sBufferName) : base($"<{a_sBufferName}> - bufor danych jest pusty!")
        {
        }
    }
}
