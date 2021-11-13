using System;
using System.IO;
using System.Text;
using zIinz_3_bigdata.Classes;
using zIinz_3_bigdata.Classes.Bussines;
using zIinz_3_bigdata.Classes.Bussines.ClientServerImplementation;
using zIinz_3_bigdata.Classes.Bussines.Messages;
using zIinz_3_bigdata.Classes.Exceptions;
using zIinz_3_bigdata.Classes.Network;

namespace zIinz_3_bigdata
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.CurrentLevel = Log.LevelEnum.DET;

            using var log = Log.DEB("Program", "Main");

            MessageFactory.Instance.Register<LoginMessage>();
            MessageFactory.Instance.Register<TextMessage>();

            Console.Write("Wybierz wariant działania programu:\n1-serwer\n2-klient\n:");

            switch (Console.ReadLine())
            {
                case "1":
                    new ChatServer().Run();
                    break;

                case "2":
                    new ChatClient().Run();
                    break;
            }

            /*
            try
            {
                NetworkData obj = new NetworkData(320);

                log.PR_DEB("To jest początek naszego programu");

                string sXmlString = @"<User xmlns=""http://schemas.datacontract.org/2004/07/zIinz_3_bigdata.Classes.Bussines"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>Jacek</Login><Password>12jacek34</Password><Permission>1</Permission><Response><ResponseString>Wszystko poszło ok :-)</ResponseString></Response></User>";

                obj.Buffer = Encoding.UTF8.GetBytes(sXmlString);

                log.PR_DEB(obj.ToString());

                User user = new User();

                user.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(sXmlString)));

                log.PR_DEB(user.ToString());
            }
            catch (NetworkDataBufferIsEmpty e)
            {
                log.PR_DEB($"Wystąpił wyjątek krytyczny <{e.GetType().Name}>!: {e.Message}");
            }
            catch (NetworkDataBufferToLarge e)
            {
                log.PR_DEB($"Wystąpił wyjątek krytyczny <{e.GetType().Name}>!: {e.Message}");

                log.PR_DEB("Sugerowana akcja: zwiększyć wartość inicjalną dla klasy NetworkData");
            }
            catch (Exception e)
            {
                log.PR_DEB($"Wystąpił ogólny wyjątek krytyczny!: {e.Message}");
            }
            */

            //Console.WriteLine(user);

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
