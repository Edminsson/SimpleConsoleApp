using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleClassLibrary.EventRelated
{
    public class DoSimpleWork
    {
        public event EventHandler<WorkCompletedEventArgs> WorkPerformed;
        public event EventHandler<WorkProgressEventArgs> WorkProgress;

        public void DoSomeWork(int AntalRepetitioner)
        {
            for (int i = 0; i < AntalRepetitioner; i++)
            {
                Thread.Sleep(200);
                OnWorkProgress(i + 1);
            }
            OnWorkCompleted(AntalRepetitioner);
        }

        private void OnWorkCompleted(int AntalRepetitioner)
        {
            if (WorkPerformed != null)
                WorkPerformed(this, new WorkCompletedEventArgs { Antal = AntalRepetitioner});
        }

        private void OnWorkProgress(int current)
        {
            if (WorkProgress != null)
                WorkProgress(this, new WorkProgressEventArgs { CurrentItem = current });
        }
    }
}
