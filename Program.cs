using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml;
using ConsoleGame.Logger;
using ConsoleGame.Music;
using ConsoleGame.Scenes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ConsoleGame
{
    public class Program
    {
        public static Map LevelMap;

        public static ILoggerFactory LoggerFactory;
        private static IServiceProvider _serviceProvider;

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

        static void Main()
        {
            File.WriteAllText("C:\\Temp\\app.log", String.Empty); // очистка лог файла

            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\Log4net.config");
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(path));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            RegisterServices();
            LoggerFactory = new LoggerFactory().AddLog4Net();
            log.Info("App Start");

            //Размеры консоли
            int width = 150;
            int height = 50;

            Console.SetWindowSize(width, height + 1);
            Console.SetBufferSize(width, height + 2);
            Console.CursorVisible = false;

            LevelMap = new StartGame(Resources.Menu);
            //LevelMap = new Level(Resources.Level_1);
            //LevelMap.RunGamePlay();
            DisposeServices();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            
            
            collection.AddScoped<ILoggerFactory, LoggerFactory>();
            // ...
            // Add other services
            // ...
            _serviceProvider = collection.BuildServiceProvider();
        }
    }
    


    
}
