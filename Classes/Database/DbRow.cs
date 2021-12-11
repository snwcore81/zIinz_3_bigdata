using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Classes.Database
{
    public class DbRow : Dictionary<string,object>
    {
        public bool Contains(string a_sKey) => ContainsKey(a_sKey);
        public override string ToString()
        {
            string _sResult = "";

            foreach (var _oElement in this)
                _sResult += $"[{_oElement.Key}={_oElement.Value}]";

            return _sResult;
        }

    }
}
