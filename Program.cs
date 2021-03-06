using System;
using System.IO;
using System.Text;
using zIinz_3_bigdata.Classes;
using zIinz_3_bigdata.Classes.Bussines;
using zIinz_3_bigdata.Classes.Bussines.ClientServerImplementation;
using zIinz_3_bigdata.Classes.Bussines.DbObjects;
using zIinz_3_bigdata.Classes.Bussines.Messages;
using zIinz_3_bigdata.Classes.Bussines.MySqlSource;
using zIinz_3_bigdata.Classes.Exceptions;
using zIinz_3_bigdata.Classes.Network;

namespace zIinz_3_bigdata
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.CurrentLevel = Log.LevelEnum.DEB;

            using var log = Log.DEB("Program", "Main");

            var dbSource = new MySqlSource
            {
                Host = "127.0.0.1",
                Port = 3306,
                Login = "admin",
                Password = "mydatabase1234",
                Schema = "mydatabase"
            };

            dbSource.Connect();


            foreach (var loginInDb in dbSource.ExecuteReader<LoginDbObject>())
            {
                try
                {
                    dbSource.TransactionStart();

                    Console.WriteLine(loginInDb);

                    Console.Write($"Podaj nowe hasło dla użytkownika <{loginInDb.Login}>:");
                    loginInDb.Password = Console.ReadLine();

                    if (loginInDb.IsChanged)
                    {
                        loginInDb.LastUpdate = DateTime.Now;
                        loginInDb.Update(dbSource);
                    }

                    dbSource.TransactionCommit();

                }
                catch (Exception e)
                {
                    log.PR_DEB($"Wyjątek! {e.Message}");

                    dbSource.TransactionRollback();
                }
            }

            dbSource.Disconnect();

            /* -- aplikacja chat - poki co off
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
            */
        }
    }
}
