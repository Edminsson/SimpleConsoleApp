using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsAsync.Models;

namespace WindowsFormsAsync
{
    public class TradpoolTask
    {
        TaskCompletionSource<OwnAwaitResultat> tcs = new TaskCompletionSource<OwnAwaitResultat>();
        public async Task<OwnAwaitResultat> GetDateTimeAsync()
        {
            return await GetDateTimeTask();
        }
        private Task<OwnAwaitResultat> GetDateTimeTask()
        {
            //return Task.Run<OwnAwaitResultat>(() => { return SlowGetDate(); });
            ThreadPool.QueueUserWorkItem((t) =>
            {
                SlowGetDate();
            });

            return tcs.Task;
        }
        private void SlowGetDate()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            int tal = 0;
            for (int i = 0; i < 100000000; i++)
            {
                tal = random.Next(1, 1000);
            }
            watch.Stop();
            var resultat = new OwnAwaitResultat();
            resultat.DatumTid = DateTime.Now;
            resultat.ThreadId = Thread.CurrentThread.ManagedThreadId;
            resultat.AntalMs = watch.ElapsedMilliseconds;

            tcs.SetResult(resultat);
        }
    }
}
