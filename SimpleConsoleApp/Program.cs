using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using SimpleConsoleApp.Static;
using SimpleConsoleApp.WorkTemplate;
using SimpleConsoleApp.Event;
using SimpleConsoleApp.Delegate;

namespace SimpleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsConfig argsConfig = new ArgsConfig();
            CommandLine.Parser.Default.ParseArgumentsStrict(args, argsConfig);

            switch(argsConfig.Work)
            {
                case Work.Event:
                    WorkerWithEventHandler.Work();
                    break;
                case Work.Delegate:
                    WorkWithDelegate.DoSomeWork();
                    break;
                case Work.Static:
                    WaitAndIncrement.Start(argsConfig.Order);
                    break;
                case Work.Template:
                    //DoWork worker = new DoWork();
                    WebWork worker = new WebWork();
                    worker.Work(args, Console.Error, Console.In,Console.Out);
                    break;
            }
            Console.WriteLine("Klart. Tryck på en knapp för att avsluta.");
            Console.ReadKey();
        }
    }
}
