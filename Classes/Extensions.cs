using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
