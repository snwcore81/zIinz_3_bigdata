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
        }
    }
}
