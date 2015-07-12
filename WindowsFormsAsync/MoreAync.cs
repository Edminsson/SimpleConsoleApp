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
    public partial class MoreAync : Form
    {
        List<KundAnalys> kundlista = new List<KundAnalys>();
        Random random = new Random();

        public MoreAync()
        {
            InitializeComponent();
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            //var tResult = await BetterTaskCompletionSource.Starta();
            //writeStringListaToResult(tResult);

            //var loopResult = await ParallelLoop.Starta();
            //writeStringListaToResult(loopResult);

            WebCallLoop webcalls = new WebCallLoop();
            var resultat = await webcalls.Starta();
            writeStringListaToResult(resultat);

            //Task.Run(async () => { await Task.Delay(1000); });
        }

        private void compactWriteStringListaToResult(IEnumerable<string> stringList)
        {
            foreach (var s in stringList)
            {
                simpleWriteToResult(s);
            }
        }
        private void writeStringListaToResult(IEnumerable<string> stringList, bool writeCompact = false, bool skapaAvgransare = false)
        {
            if(skapaAvgransare)
                simpleWriteToResult("===========================");

            foreach (var s in stringList)
            {
                simpleWriteToResult(s, writeCompact);
            }
        }
        private void simpleWriteToResult(string message, bool writeCompact = false)
        {
            if(writeCompact)
                this.txtResult.AppendText(String.Format("; {0}", message));
            else
                this.txtResult.AppendText(String.Format("\r\n{0}", message));
        }
        private void writeToResult(string message, string id)
        {
            this.txtResult.Text += String.Format("\r\n {0:HH:mm:ss} - {1} - {2}. Tråd: {3}", DateTime.Now, message, id, Thread.CurrentThread.ManagedThreadId);
        }
        private void btnSkriv_Click(object sender, EventArgs e)
        {
            simpleWriteToResult(string.Format("[{0}] {{{1:HH:mm:ss.fff}}}", Thread.CurrentThread.ManagedThreadId, DateTime.Now));
        }
        private void btnRensa_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private async void btnMedWhenAll_Click(object sender, EventArgs e)
        {
            WebCallLoop webcalls = new WebCallLoop();
            var resultat = await webcalls.StartaMedWhenAll();
            writeStringListaToResult(resultat);

        }

        private async void btnFilltext_Click(object sender, EventArgs e)
        {
            List<List<string>> listlista = new List<List<string>>();
            List<string> simpleResult = new List<string>(); ;
            for (int i = 0; i < 3; i++)
            {
                listlista.Add(await Filltext.GetNames(2));
            }
            foreach (var t in listlista)
            {
                writeStringListaToResult(t);
            }
        }

        private async void btnFilltextParallel_Click(object sender, EventArgs e)
        {
            simpleWriteToResult("===Start===");
            var taskList = new List<Task<List<string>>>();
            var dic = new Dictionary<int, List<string>>();
            List<string> simpleResult = new List<string>(); ;
            for (int i = 0; i < 1000; i++)
            {
                var t = Filltext.GetNames(2);
                taskList.Add(t);
            }
            //Thread.Sleep(2000);
            await Task.WhenAll(taskList);
            foreach (var t in taskList)
            {
                if (t.Result != null)
                    writeStringListaToResult(t.Result);
                else
                    simpleWriteToResult("Resultatet är null");
            }
            simpleWriteToResult("===Slut===");
        }

        private async void btnAzureDb_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch(); watch.Start();
            simpleWriteToResult(string.Format("===Start {0:HH:mm:ss.fff}===", DateTime.Now)); simpleWriteToResult("");
            for (int i = 0; i < 100; i++)
            {
                var randomCustomId = random.Next(1, 800);
                var customer = await AzureDb.GetCustomerByIdAsync(randomCustomId);
                simpleWriteToResult(string.Format("{0}", customer.LastName),true);
            }

            watch.Stop();
            simpleWriteToResult(string.Format("===Slut {0:HH:mm:ss.fff} ({1})===", DateTime.Now, watch.ElapsedMilliseconds));
        }

        private async void btnAzureDbBatchvis_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch(); watch.Start();
            List<Task<Customer>> taskList = new List<Task<Customer>>();
            simpleWriteToResult(string.Format("===Start {0:HH:mm:ss.fff}===", DateTime.Now)); simpleWriteToResult("");
            int numberOfPrintedCustomers = 0;
            for (int i = 0; i < 500; i++)
            {
                var randomCustomId = random.Next(1, 800);
                taskList.Add(AzureDb.GetCustomerByIdAsync(randomCustomId));
                if (taskList.Count == 10)
                {
                    var customers = await Task.WhenAll(taskList);
                    foreach(var customer in customers)
                    {
                        simpleWriteToResult(string.Format("{0}", customer.LastName), true);
                        numberOfPrintedCustomers++;
                    }
                    taskList.Clear();
                }
            }
            if (taskList.Count > 0)
            {
                var customers = await Task.WhenAll(taskList);
                foreach (var customer in customers)
                {
                    simpleWriteToResult(string.Format("{0}", customer.LastName), true);
                    numberOfPrintedCustomers++;
                }
                taskList.Clear();
            }

            watch.Stop();
            simpleWriteToResult(string.Format("===Slut Antal:{2} - {0:HH:mm:ss.fff} ({1})===", DateTime.Now, watch.ElapsedMilliseconds, numberOfPrintedCustomers));
        }

        private async void btnLoopTest_Click(object sender, EventArgs e)
        {
            //Problemet med den här varianten är att när det fanns ett fel i string.format och det uppstod ett
            //undantag så märkte man inget i applikationen om inte hela click-hanteraren var async och man awaitade
            //task-objektet som Task.Run-returnerar.
            Stopwatch watch = new Stopwatch(); watch.Start();
            List<Task> tasklista = new List<Task>();
            simpleWriteToResult(string.Format("===Start {0:HH:mm:ss.fff}===", DateTime.Now)); simpleWriteToResult("");
            for (int i = 0; i < 100; i++)
            {
                var customerID = random.Next(1, 800);
                var t = Task.Run(async () => {
                    KundAnalys analys = new KundAnalys();
                    analys.Customer = await AzureDb.GetCustomerByIdAsync(customerID);
                    kundlista.Add(analys);
                    analys.Tid = DateTime.Now;
                    analys.ThreadId = Thread.CurrentThread.ManagedThreadId;
                    analys.Anm = string.Format("[{0}]/{1:HH:mm:ss.fff}/{2}", analys.ThreadId, analys.Tid, analys.Customer.FirstName);
                    //simpleWriteToResult(analys.Anm, true);
                    kundlista.Add(analys);
                });
                tasklista.Add(t);
                //await t;
            }
            await Task.WhenAll(tasklista);
            watch.Stop();
            visaKundlista();
            simpleWriteToResult(string.Format("===Slut {0:HH:mm:ss.fff} ({1})===", DateTime.Now, watch.ElapsedMilliseconds));
        }

        private void visaKundlista()
        {
            if (kundlista.Count == 0)
                simpleWriteToResult("Kundlistan är tom");
            foreach (var kund in kundlista)
            {
                string details = kund == null || kund.Anm == null ? "[TOM]" : kund.Anm;
                simpleWriteToResult(details, true);
            }
        }

        private void btnVisaKundlista_Click(object sender, EventArgs e)
        {
            visaKundlista();
        }

        private async void btnTaskRunTests_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch(); watch.Start();
            TaskRunVariations trv = new TaskRunVariations();
            simpleWriteToResult(string.Format("===Start {0:HH:mm:ss.fff}===", DateTime.Now)); simpleWriteToResult("");

            var test = await Task.Run(() => { return trv.GetStrAsync(); });
            simpleWriteToResult(string.Format("Klar: {0}", test));

            test = await trv.GetStrAsync();
            simpleWriteToResult(string.Format("Klar: {0}", test));

            test = await Task.Run(() => { return trv.AltGetStrAsync(); });
            simpleWriteToResult(string.Format("Klar: {0}", test));

            test = await trv.AltGetStrAsync();
            simpleWriteToResult(string.Format("Klar: {0}", test));

            test = await Task.Run(() => { return trv.Alt2GetStrAsync(); });
            simpleWriteToResult(string.Format("Klar: {0}", test));

            test = await trv.Alt2GetStrAsync();
            simpleWriteToResult(string.Format("Klar: {0}", test));

            test = await Task.Run(() => { return trv.GetStr(); });
            simpleWriteToResult(string.Format("Klar: {0}", test));

            watch.Stop();
            simpleWriteToResult(string.Format("===Slut {0:HH:mm:ss.fff} ({1})===", DateTime.Now, watch.ElapsedMilliseconds));
        
        }
    
    }
}
