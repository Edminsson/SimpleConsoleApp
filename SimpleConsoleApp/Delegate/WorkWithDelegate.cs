using SimpleClassLibrary.Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleApp.Delegate
{
    class WorkWithDelegate
    {
        public static void DoSomeWork()
        {
            WorkProgressDelegate progress = (a) => Console.WriteLine(string.Format("Arbete pågår: {0}", a));
            WorkPerformedDelegate performed = (a) => Console.WriteLine(string.Format("Klart! Antal: {0}", a));
            DelegateWork worker = new DelegateWork();
            worker.DoSomeWork(6, progress, performed);
            
        }
    }
}
