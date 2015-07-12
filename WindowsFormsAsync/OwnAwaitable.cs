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
    public class OwnAwaitable
    {
        public async Task<OwnAwaitResultat> GetDateTimeAsync()
        {
            return await GetDateTimeTask();
        }
        private Task<OwnAwaitResultat> GetDateTimeTask()
        {
            return Task.Run<OwnAwaitResultat>(() => { return SlowGetDate(); });
        }
        private OwnAwaitResultat SlowGetDate()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            int tal =0;
            for (int i = 0; i < 100000000; i++)
            {
                tal = random.Next(1, 1000);
            }
            watch.Stop();
            var resultat = new OwnAwaitResultat();
            resultat.DatumTid = DateTime.Now;
            resultat.ThreadId = Thread.CurrentThread.ManagedThreadId;
            resultat.AntalMs = watch.ElapsedMilliseconds;

            return resultat;
        }
    }
}
