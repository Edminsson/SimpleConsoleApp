using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerLibrary
{
    public delegate void WorkProgressDelegate(int progress);
    public delegate void WorkCompletedDelegate(int count);
    public class SlowWorker
    {
        public WorkProgressDelegate ProgressDelegate;
        public WorkCompletedDelegate CompletedDelegate;
        public void WorkerUsingDelegates(int repeatCount, WorkProgressDelegate progress, WorkCompletedDelegate completed)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                progress(i);
                System.Threading.Thread.Sleep(200);
            }
            completed(repeatCount);
        }
    }
}
