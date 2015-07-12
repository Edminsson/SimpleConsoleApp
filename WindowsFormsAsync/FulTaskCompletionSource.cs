using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAsync
{
    public class FulTaskCompletionSource
    {
        TaskCompletionSource<List<string>> tcs = new TaskCompletionSource<List<string>>();

        public FulTaskCompletionSource()
        {
            starta();
        }

        private void starta()
        {
            List<string> lista = new List<string> { "Skapad", "av", "TaskCompletionSource", "som", "fejkar", "lite." };
            Thread.Sleep(5000);
            tcs.SetResult(lista);
        }

        public Task<List<string>> GetStringListTask()
        {
            return tcs.Task;
        }

    }
}
