using System;
using System.Net.Http;
using Contracts;
using Contracts.Abstract;
using Microsoft.Practices.Unity;

namespace ClientConsoleApp
{
    // Please make sure RestfulService is running prior to running ClientConsoleApp
    internal class Program
    {
        private static void Main(string[] args)
        {
            BootStrapper.Init(); 
            var consoleWriter = BootStrapper.Container.Resolve<IStoreWriter>();
            var settings = BootStrapper.Container.Resolve<IApplicationSettings>();

            string uri = settings.GetValue("restfulServiceUri");
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(uri);
                var response = httpClient.GetStringAsync("api/Message/").Result;

                consoleWriter.Write(response); // console writer
            }

            Console.ReadKey();
        }
    }

    public static class BootStrapper
    {
        public static UnityContainer Container { get; } = new UnityContainer();

        public static void Init()
        {
            Container.RegisterType<IApplicationSettings, ConfigAppSettings>();
            Container.RegisterType<IStoreWriter, ConsoleStore>();

            // other options
            //Container.RegisterType<IStoreWriter, SqlStore>();
            //Container.RegisterType<IStoreReader, SqlStore>();
        }
    }
}