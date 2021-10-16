using System;
using System.IO;
using System.Text;
using zIinz_3_bigdata.Classes;
using zIinz_3_bigdata.Classes.Bussines;

namespace zIinz_3_bigdata
{
    class Program
    {
        static void Main(string[] args)
        {
            string sXmlString = @"<User xmlns=""http://schemas.datacontract.org/2004/07/zIinz_3_bigdata.Classes.Bussines"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>Jacek</Login><Password>12jacek34</Password><Permission>1</Permission><Response><ResponseString>Wszystko poszło ok :-)</ResponseString></Response></User>";

            User user = new User();

            user.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(sXmlString)));

            Console.WriteLine(user);

            /*
            User user = new User
            {
                Login = "Jacek",
                Password = "12jacek34",
                Permission = 1,
                Response = new ResponseObject
                {
                    ResponseString = "Wszystko poszło ok :-)"
                }
            };

            string sXmlString = Encoding.UTF8.GetString(user.ToXml().ToArray());

            Console.WriteLine(sXmlString);
            */
        }
    }
}
