using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAsync.Models;

namespace WindowsFormsAsync
{
    public partial class Form1 : Form
    {
        List<string> stranglista = new List<string>();
        List<string> teckenlista = new List<string> { "-","/","\\"};

        public Form1()
        {
            InitializeComponent();
            comboAction.SelectedIndex = 1;
            comboActionNoAsync.SelectedIndex = 1;
            textResultat.Text = string.Format("Antal kärnor: {0}", Environment.ProcessorCount);
            comboAction.DataSource = new List<string> { "NoDeadlock", "NoDeadlockWithContinue", "Enkel await", "Anrop av konstig TaskCompletionSource", "Bättre TaskCompletionSource", "Nada" };
            comboActionNoAsync.DataSource = new List<string> { "Deadlock", "Lambda Task", "Implicit wait", "Simple TaskCompletionSource", "Anropa enkel task-klass", "Threadpool" };
            comboAntal.DataSource = new List<string> { "One", "Two", "Three", "Four", "Five", "Six" };
            comboAntal.SelectedIndex = 2;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            waitDialog wait = new waitDialog();
            wait.Show();
            List<Task> tasks = new List<Task>();
            var t = DoWorkAsync(100, "uno").ContinueWith((tsk) => {
                writeToResult("Ska köras när uno är klar. ", "ContinueWith-efter-uno");
                SlowMethod("Långsam process", "ContinueWith-efter-uno");
            }); ;
            var t2 = DoWorkAsync(1000, "dos");
            var t3 = DoWorkAsync(3000, "tres");
            var t4 = DoWorkAsync(100, "cuatro");
            tasks.Add(t);tasks.Add(t2);tasks.Add(t3);tasks.Add(t4);
            var t_alla = Task.WhenAll(tasks);
            t_alla.ContinueWith((tsk) => writeToResult("Ska köras när allt är klart. ", "WhenAll"));
            t2.ContinueWith((tsk)=> writeToResult("Ska köras när task dos är klar. ","ContinueWith"));
            wait.Hide();
            writeToResult("Har anropat alla tasks", "MAIN");
        }

        private async Task DoWorkAsync(int msDelay, string id)
        {
            writeToResult("Startar DoWork", id);
            await Task.Delay(msDelay);
            writeToResult("Klar med DoWork", id);
        }

        private async Task<string> GetStringWithTimeAsync(int msDelay)
        {
            //await Task.Delay(msDelay).ConfigureAwait(false);
            await Task.Delay(msDelay);
            return (string.Format("Hej {0:HH:mm:ss}", DateTime.Now));
        }

        private void SlowMethod(string meddelande, string id)
        {
            writeToResult("START:"+meddelande, id);
            Thread.Sleep(7000);
            writeToResult("END:"+meddelande, id);
        }

        private void writeToResult(string message, string id)
        {
            this.textResultat.Text += String.Format("\r\n {0:HH:mm:ss} - {1} - {2}. Tråd: {3}", DateTime.Now, message, id, Thread.CurrentThread.ManagedThreadId);
        }

        private void writeWaitCharacter(string message)
        {
            var res = textResultat.Text;
            var lastChar = res.Substring(res.Length-1);
            if (teckenlista.Contains(lastChar))
            {
                var tmpstr = res.Substring(0, res.Length-1);
                res = tmpstr + message;
            }
            else
                res += message;
            this.textResultat.Text = res;
        }
        private void simpleWriteToResult(string message)
        {
            this.textResultat.Text += String.Format("\r\n{0}", message);
        }
        private void writeStringListaToResult(IEnumerable<string> stringList)
        {
            simpleWriteToResult("===========================");
            foreach (var s in stringList)
            {
                simpleWriteToResult(s);
            }
        }

        private void btnRensa_Click(object sender, EventArgs e)
        {
            textResultat.Text = "";
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            simpleWriteToResult("Startar operation");
            //Klassen TaskCompSourceTest startar med ett vanligt anrop av en async metod utan await 
            //eller annan wait i constructorn.
            var tCompSourceTest = new TaskCompSourceTest();
            tCompSourceTest.Rapportera = (s) => { writeWaitCharacter(s); };
            var analysTask = tCompSourceTest.AnalysResultat;
            foreach(var tradinfo in analysTask.Result.ProcessFrekvens)
            {
                simpleWriteToResult(string.Format("Process:{0} Antal:{1}",tradinfo.Key, tradinfo.Value));
            }
            simpleWriteToResult("Sista raden");
        }

        private void btnDeadLock_Click(object sender, EventArgs e)
        {
            if(comboActionNoAsync.SelectedIndex == 0)
            {
                //Intended deadlock for demonstration
                var task = GetStringAsync();
                textResultat.Text = task.Result;
            }
            else if(comboActionNoAsync.SelectedIndex == 1)
            {
                //unwanted deadlock?
                writeToResult("Initiating the lambda task", "Main");
                var uppgift = new Task<string>(() => {
                    writeToResult("Egen uppgift", "Lambda Task");
                    stranglista.Add("Rad som vanligtvis inte visas");
                    return "slut"; 
                });
                uppgift.Start();
                //uppgift.ContinueWith((t) => { writeToResult("Hej","ContinueWith"); });
                writeToResult("Last row", "Main");

                //Wait krävs för att stringlista ska skrivas ut
                //uppgift.Wait();
                writeStringListaToResult(stranglista);
            }
            else if (comboActionNoAsync.SelectedIndex == 2)
            {
                var t = GetStringWithTimeAsync(500);
                simpleWriteToResult(t.Result);
            }
            else if (comboActionNoAsync.SelectedIndex == 3)
            {
                var o = new FulTaskCompletionSource();
                var t=o.GetStringListTask();
                writeStringListaToResult(t.Result);
            }
            else if (comboActionNoAsync.SelectedIndex == 4)
            {
                var o = new EnkelTaskFactory();
                var t = o.Starta();
                writeStringListaToResult(t.Result);
            }
            else if (comboActionNoAsync.SelectedIndex == 5)
            {
                writeToResult("Start", "Threadpool");
                QueueThreadPool();
            }
        }
        private void QueueThreadPool()
        {
            ThreadPool.QueueUserWorkItem((t) => {
                writeToResult("Queued thread", "Threadpool");
                Thread.Sleep(5000);
                simpleWriteToResult("Threadpool item was queued"); 
            });
        }
        private async Task<string> GetStringAsync()
        {
            await Task.Delay(3000);
            stranglista.Add(string.Format("{0:HH:mm:ss} Hello world",DateTime.Now));
            return "hello world!";
        }

        private async void btnNoDeadlock_Click(object sender, EventArgs e)
        {
            if (comboAction.SelectedIndex == 0)
            {
                var taskResult = await GetStringAsync();
                textResultat.Text = taskResult;
            }
            else if(comboAction.SelectedIndex == 1)
            {
                var taskResult = await GetStringAsync().ContinueWith(t => {
                    stranglista.Add(string.Format("{0:HH:mm:ss} Hola mundo + {1}", DateTime.Now, t.Result));
                    return string.Format("{0}/{1}", "Hola mundo",t.Result); 
                })
                .ContinueWith(tt=>{
                    stranglista.Add(string.Format("{0:HH:mm:ss} Hej värld + {1}", DateTime.Now, tt.Result));
                    return string.Format("{0}/{1}", "Hej värld", tt.Result); 
                });
                textResultat.Text = taskResult;
                writeStringListaToResult(stranglista);
            }
            else if (comboAction.SelectedIndex == 2)
            {
                var res = await GetStringWithTimeAsync(500);
                simpleWriteToResult(res);
            }
            else if (comboAction.SelectedIndex == 3)
            {
                var o = new FulTaskCompletionSource();
                var tResult = await o.GetStringListTask();
                writeStringListaToResult(tResult);
            }
            else if (comboAction.SelectedIndex == 4)
            {
                var tResult = await BetterTaskCompletionSource.Starta();
                writeStringListaToResult(tResult);
            }

        }

        private async void btnOwnAwaitable_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var antal = comboAntal.SelectedIndex;
            writeToResult("Start","ownAwaitable");
            var own = new OwnAwaitable();
            List<Task<OwnAwaitResultat>> tasklista = new List<Task<OwnAwaitResultat>>();
            for (int i = 0; i < antal+1; i++)
            {
                tasklista.Add(own.GetDateTimeAsync());
            }
            await Task.WhenAll(tasklista).ContinueWith((res) => {
                foreach(var t in res.Result)
                {
                    writeToResult(string.Format("avslut: {0:HH:mm:ss} antal_ms:{1} tradId:{2}",t.DatumTid,t.AntalMs,t.ThreadId), "flera own awaitables");
                }
                watch.Stop();
                writeToResult(string.Format("Slut. Antal ms: {0}", watch.ElapsedMilliseconds), "ownAwaitable");
            });
        }

        private async void btnSerie_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var antal = comboAntal.SelectedIndex;
            writeToResult("Start", "ownAwaitable");
            var own = new OwnAwaitable();
            List<Task<DateTime>> tasklista = new List<Task<DateTime>>();
            for (int i = 0; i < antal + 1; i++)
            {
                var res = await own.GetDateTimeAsync();
                writeToResult(string.Format("avslut: {0:HH:mm:ss} antal_ms:{1} tradId:{2}", res.DatumTid, res.AntalMs, res.ThreadId), "flera own awaitables");
            }
            watch.Stop();
            writeToResult(string.Format("Slut. Antal ms: {0}", watch.ElapsedMilliseconds), "ownAwaitable");
        }

        private async void btnTcsTask_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var antal = comboAntal.SelectedIndex;
            writeToResult("Start", "ownAwaitable");
            var own = new TradpoolTask();
            List<Task<OwnAwaitResultat>> tasklista = new List<Task<OwnAwaitResultat>>();
            for (int i = 0; i < antal + 1; i++)
            {
                tasklista.Add(own.GetDateTimeAsync());
            }
            await Task.WhenAll(tasklista).ContinueWith((res) =>
            {
                foreach (var t in res.Result)
                {
                    writeToResult(string.Format("avslut: {0:HH:mm:ss} antal_ms:{1} tradId:{2}", t.DatumTid, t.AntalMs, t.ThreadId), "flera own awaitables");
                }
                watch.Stop();
                writeToResult(string.Format("Slut. Antal ms: {0}", watch.ElapsedMilliseconds), "ownAwaitable");
            });
        }
 
    }
}
