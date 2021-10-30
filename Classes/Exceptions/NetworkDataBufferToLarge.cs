using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Exceptions
{
    public class NetworkDataBufferToLarge : Exception
    {
        public NetworkDataBufferToLarge(string a_sBufferName, int a_iLength,int a_iMaxLength) : 
            base($"Dane ze źródła <{a_sBufferName}> są zbyt duże, rozmiar: {a_iLength} bajt/-ów! Maksymalny rozmiar: {a_iMaxLength} bajt/-ów")
        {
        }
    }
}
