using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleClassLibrary.Delegate
{
    public delegate void WorkPerformedDelegate(int Antal);
    public delegate void WorkProgressDelegate(int currentItem);

    public class DelegateWork
    {
        public void DoSomeWork(int AntalRepetitioner, WorkProgressDelegate progress, WorkPerformedDelegate performed)
        {
            for (int i = 0; i < AntalRepetitioner; i++)
            {
                Thread.Sleep(200);
                progress(i+1);
            }
            performed(AntalRepetitioner);
        }
    }
}
