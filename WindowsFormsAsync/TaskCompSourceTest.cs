using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsAsync.Models;

namespace WindowsFormsAsync
{
    public class TaskCompSourceTest
    {
        Queue<string> itemQueue = new Queue<string>();
        Dictionary<int, int> tradfrekvens = new Dictionary<int, int>();
        Dictionary<string, int> slumptalsfrekvens = new Dictionary<string, int>();
        public Action<string> Rapportera;
        private int antalBehandladeRader = 0;
        private char[] tecken = new char[4];
        private int currentWaitChar = 0;

        public TaskCompSourceTest()
        {
            var slumpgenerator = new Random();
            for (int i = 0; i < 500; i++)
            {
                var slumptal = slumpgenerator.Next(1, 20);
                itemQueue.Enqueue(string.Format("Slumptal:{0}", slumptal));
                //itemQueue.Enqueue(string.Format("Radnr {0}:{1}", i, slumptal));
            }
            tecken[0] = '-';
            tecken[1] = '\\';
            tecken[2] = '-';
            tecken[3] = '/';
            readNext();
        }

        private TaskCompletionSource<AnalysResultat> tCompletionSource = new TaskCompletionSource<AnalysResultat>();
        public Task<AnalysResultat> AnalysResultat
        {
            get 
            {
                return tCompletionSource.Task;
            }
        }

        private string getNextWaitCharacter()
        {
            currentWaitChar++;
            if (currentWaitChar == 4)
                currentWaitChar = 0;
            return tecken[currentWaitChar].ToString();
        }
        private void readNext()
        {
            getNextItemAsync().ContinueWith(behandlaItem);
        }
        private async Task<string> getNextItemAsync()
        {
            string item;
            antalBehandladeRader++;
            if (itemQueue.Count > 0)
                item = itemQueue.Dequeue();
            else
                item = null;
            //writeToResult("Start", item);
            await Task.Delay(2).ConfigureAwait(false);
            if(antalBehandladeRader % 20 == 0)
                this.Rapportera(getNextWaitCharacter());
            //writeToResult("End", item);
            return item;
        }
        private void incrementOrAdd<T>(IDictionary<T,int> dic, T keyvalue)
        {
            if (dic.Count > 0 && dic.ContainsKey(keyvalue))
            {
                var antal = dic[keyvalue];
                antal++;
                dic[keyvalue] = antal;

            }
            else
                dic.Add(keyvalue, 1);
        }
        private void analyseraTrad()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            incrementOrAdd(tradfrekvens, threadId);
        }
        private void analyseraSlumptal(string item)
        {
            incrementOrAdd(slumptalsfrekvens, item);
        }
        private void behandlaItem(Task<string> task)
        {
            //writeToResult("ContinueWith", task.Result);
            if (!string.IsNullOrEmpty(task.Result))
            {
                analyseraTrad();
                analyseraSlumptal(task.Result);
                readNext();
            }
            else
            {
                var analysresultat = new AnalysResultat();
                analysresultat.ProcessFrekvens = tradfrekvens;
                analysresultat.Slumpfrekvens = slumptalsfrekvens;
                tCompletionSource.SetResult(analysresultat);
            }
        }
    
    
    }
}
