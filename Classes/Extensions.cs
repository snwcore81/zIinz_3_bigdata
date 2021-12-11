using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace zIinz_3_bigdata.Classes
{
    public static class Extensions
    {
        public static string CleanType(this string TypeName)
        {
            if (!string.IsNullOrEmpty(TypeName) && TypeName.Contains('`'))
            {
                TypeName = TypeName.Substring(0, TypeName.IndexOf('`')) + "<T>";
            }

            return TypeName;
        }

        public static string ToDb(this object a_oValue)
        {
            string _sResult = string.Empty;

            if (a_oValue == null)
                _sResult = "null";
            else if (a_oValue is string)
                _sResult = $"'{a_oValue}'";
            else if (a_oValue is DateTime)
            {
                var _oDate = (DateTime)a_oValue;
                _sResult = $"STR_TO_DATE('{_oDate.Day}-{_oDate.Month}-{_oDate.Year}','%d-%m-%Y')";
            }
            else if (Regex.IsMatch(a_oValue.ToString(), @"-?\d+(\.\d+)?"))
                _sResult = a_oValue.ToString();

            return _sResult;
        }
    }
}
