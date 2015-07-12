using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAsync
{
    public class BetterTaskCompletionSource
    {
        //Observera att metoden inte är async men den kan awaitas och kommer att fungera asynkront
        //på grund av Task.Run som skapar en ny tråd (från ThreadPool?)
        //Hade vi inte skapat en ny tråd så hade operationen blivit synkron.
        public static Task<List<string>> Starta()
        {
            TaskCompletionSource<List<string>> tcs = new TaskCompletionSource<List<string>>();
            Task.Run(() =>
            {
                var tradinfo = string.Format("Trådid: {0}", Thread.CurrentThread.ManagedThreadId);
                List<string> lista = new List<string> { "Skapad av", "TaskCompletionSource", tradinfo };
                Thread.Sleep(3000);
                tcs.SetResult(lista);
            });
            return tcs.Task;
        }

    }
}
