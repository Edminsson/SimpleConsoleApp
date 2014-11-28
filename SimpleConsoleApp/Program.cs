using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SimpleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoWork worker = new DoWork();
            //WebWork worker = new WebWork();
            //worker.Work(args, Console.Error, Console.In,Console.Out);
            ArgsConfig argsConfig = new ArgsConfig();
            CommandLine.Parser.Default.ParseArgumentsStrict(args, argsConfig);
            WaitAndIncrement waitAndIncrement = new WaitAndIncrement(argsConfig.Order);
            waitAndIncrement.Start();
            Console.WriteLine("Klart. Tryck på en knapp för att avsluta.");
            Console.ReadKey();
        }
    }
}
