using System;
using System.Collections.Generic;
using System.Text;
using zIinz_3_bigdata.Interfaces;

namespace zIinz_3_bigdata.Classes
{
    public class ConsoleLogWriter : ILogWriter
    {
        public object Write(string Text)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                Console.WriteLine(Text);
            }

            return Text;
        }
    }
}
