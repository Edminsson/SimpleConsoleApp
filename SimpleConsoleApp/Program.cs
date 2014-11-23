using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoWork worker = new DoWork();
            WebWork worker = new WebWork();
            worker.Work(args, Console.Error, Console.In,Console.Out);
        }
    }
}
