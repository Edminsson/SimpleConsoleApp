using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAsync.Models
{
    public class ParallelLoop
    {
        public static Task<List<string>> Starta()
        {
            TaskCompletionSource<List<string>> tcs = new TaskCompletionSource<List<string>>();
            Task.Run(() =>
            {
                tcs.SetResult(doWork());
            });
            return tcs.Task;
        }

        private static List<string> doWork()
        {
            Random random = new Random();
            List<string> resultatLista = new List<string>();
            int[] items = { 4, 1, 6, 2, 9, 5, 10, 3 };
            resultatLista.Add(string.Format("Startar: {0:HH:mm:ss.fff}", DateTime.Now));
            Parallel.ForEach(items, item =>
            {
                var sleepTime = random.Next(200, 2000);
                Thread.Sleep(sleepTime);
                resultatLista.Add(string.Format("Thread: {0}. Item: {1}. SleepTime: {2}. Now: {3:HH:mm:ss.fff}", Thread.CurrentThread.ManagedThreadId, item, sleepTime, DateTime.Now));
            });
            resultatLista.Add(string.Format("Slutar: {0:HH:mm:ss.fff}", DateTime.Now));
            return resultatLista;
        }

    }
}
