using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessConsole
{
    delegate void EgenDelegate(int uno, string dos);
    class Program
    {
        static CancellationTokenSource cts;
        static void Main(string[] args)
        {

            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            do
            {
                Console.Clear();
                Console.WriteLine("Press 1 to start new Process");
                Console.WriteLine("Press 2 to start TaskCompletionSourceTest");
                Console.WriteLine("Press 3 to start some TaskThredTest");
                Console.WriteLine("Press 4 to start some TaskAsynchronousTest");
                Console.WriteLine("Press 5 testa enkel wait");
                Console.WriteLine("Press 6 testa enkel continueWith");
                Console.WriteLine("Press 7 testa async som inte returnerar resultat");
                Console.WriteLine("Press 8 testa wait-problem");
                Console.WriteLine("Press 9 testa enkel loop");
                Console.WriteLine("Press 0 to exit");

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D0)
                    Environment.Exit(0);
                else if (key.Key == ConsoleKey.D1)
                    OldFunction();
                else if (key.Key == ConsoleKey.D2)
                    OldFunction();
                else if (key.Key == ConsoleKey.D3)
                    TaskThreadTest();
                else if (key.Key == ConsoleKey.D4)
                    TaskAsynchronousTest();
                else if (key.Key == ConsoleKey.D5)
                    TestaEnkelWait();
                else if (key.Key == ConsoleKey.D6)
                    TestaEnkelContinueWith();
                else if (key.Key == ConsoleKey.D7)
                    TestaAsyncSomInteReturnerarResultat();
                else if (key.Key == ConsoleKey.D8)
                {
                    //Task t1 = Task.Factory.StartNew(Accept);
                    //Task t1 = Task.Run(() => { Accept(); });
                    Task t1 = Accept();
                    t1.Wait();
                    Console.WriteLine("Main ended!!!!!!!!!!!!!");
                }
                else if (key.Key == ConsoleKey.D9)
                    TestaTaskMedCancellation();
                else
                    Console.WriteLine("No choice !!!!!!!");

                Console.WriteLine("Avvaktar tangenttryck.");
                Console.ReadKey();

            } while(true);

        }

        private static void TestaTaskMedCancellation()
        {
            cts = new CancellationTokenSource();
            Console.WriteLine("\r\nLoop som tar 10 sekunder startar.");
            Console.WriteLine("Tryck på Ctrl+C för att avbryta.");
            TaskWithCancellation tmc = new TaskWithCancellation();

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var resultat = tmc.DoWork(cts.Token);
                }
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Du avbröt operationen");
            }
            Console.Write("Klar med loop");
        }

        private static void myHandler(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Du vill avbryta operationen. Var god vänta.");
            cts.Cancel();
            e.Cancel = true;
        }

        public static async Task Accept()
        {
            await Task.Delay(100);
            await Task.Delay(100);
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(100);
            }

            Console.WriteLine("Stopped");
        }

        private static void TaskThreadTest()
        {
            Console.WriteLine("TaskTest on thread " + Thread.CurrentThread.ManagedThreadId);
            var client = new WebClient();
            Task<byte[]> t = Task<byte[]>.Factory.StartNew(() =>
            {
                Console.WriteLine("Loading data on thread " + Thread.CurrentThread.ManagedThreadId);
                return client.DownloadData("http://www.elmercurio.cl/");
            });
            Console.WriteLine("Setting up things on thread " + Thread.CurrentThread.ManagedThreadId);
            t.ContinueWith(tsk =>
            {
                if (tsk.Exception != null)
                    Console.WriteLine("There was an error.  Thread " + Thread.CurrentThread.ManagedThreadId);
                else
                    Console.WriteLine("Antal tecken: " + tsk.Result.Length + " Thread " + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("The asynchronous operation was started on thread " + Thread.CurrentThread.ManagedThreadId);
        }

        private static void TaskAsynchronousTest()
        {
            Console.WriteLine("TaskTest on thread " + Thread.CurrentThread.ManagedThreadId);
            var client = new WebClient();
            Task<byte[]> t = client.DownloadDataTaskAsync("http://www.tv.nu/");
            Console.WriteLine("Setting up things on thread " + Thread.CurrentThread.ManagedThreadId);
            t.ContinueWith(tsk =>
            {
                if (tsk.Exception != null)
                    Console.WriteLine("There was an error.  Thread " + Thread.CurrentThread.ManagedThreadId);
                else
                    Console.WriteLine("Antal tecken: " + tsk.Result.Length + " Thread " + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("The asynchronous operation was started on thread " + Thread.CurrentThread.ManagedThreadId);
        
        }

        static void TaskCompletionTest()
        {
            var task = DoWork();
            Console.WriteLine("DoWork called, takes about three seconds to complete");
            // We call .Result because Main cannot be async
            Console.WriteLine(task.Result);
            Console.WriteLine("Väntar....");
        }

        static Task<int> DoWork()
        {
            var tcs = new TaskCompletionSource<int>();
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                tcs.SetResult(6);
            });
            return tcs.Task;
        }

        static void OldFunction()
        {
            var process = new Process()
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "ping.exe",
                    Arguments = "127.0.0.1",
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };
            process.Exited += (sender, argumets) =>
            {
                if (process.ExitCode != 0)
                {
                    var errorMessage = process.StandardError.ReadToEnd();
                    throw new InvalidOperationException(errorMessage);
                }
                Console.WriteLine("The process has exited.");
                process.Dispose();
            };
            process.Start();
            Console.WriteLine("Tryck på en tangent!!!!!!!!");
            Console.ReadKey();

        }

        private static void showThreadInfo()
        {
            var threads = Process.GetCurrentProcess().Threads;
            Console.WriteLine(string.Format("Antal trådar: {0}", threads.Count));
        }

        private static Task<byte[]> getWebTask()
        {
            var client = new WebClient();
            Task<byte[]> t = client.DownloadDataTaskAsync("http://www.tv.nu/");
            return t;
        }

        private static void TestaEnkelWait()
        {
            Console.WriteLine("EnkelWait. Tråd " + Thread.CurrentThread.ManagedThreadId);
            showThreadInfo();
            Task<byte[]> t = getWebTask();
            Console.WriteLine("Setting up things on thread " + Thread.CurrentThread.ManagedThreadId);
            t.Wait();
            if (t.Exception != null)
                Console.WriteLine("There was an error.  Thread " + Thread.CurrentThread.ManagedThreadId);
            else
                Console.WriteLine("Antal tecken: " + t.Result.Length + " Thread " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Sista raden. tråd " + Thread.CurrentThread.ManagedThreadId);

        }

        private static void TestaEnkelContinueWith()
        {
            Console.WriteLine("TaskTest on thread " + Thread.CurrentThread.ManagedThreadId);
            showThreadInfo();
            var client = new WebClient();
            Task<byte[]> t = client.DownloadDataTaskAsync("http://www.tv.nu/");
            Console.WriteLine("Setting up things on thread " + Thread.CurrentThread.ManagedThreadId);
            t.ContinueWith(tsk =>
            {
                showThreadInfo();
                if (tsk.Exception != null)
                    Console.WriteLine("There was an error.  Thread " + Thread.CurrentThread.ManagedThreadId);
                else
                    Console.WriteLine("Antal tecken: " + tsk.Result.Length + " Thread " + Thread.CurrentThread.ManagedThreadId);
            });
            showThreadInfo();
            Console.WriteLine("The asynchronous operation was started on thread " + Thread.CurrentThread.ManagedThreadId);
        }

        private static void TestaAsyncSomInteReturnerarResultat()
        {
            Console.WriteLine("Testar AsyncMetod. Tråd " + Thread.CurrentThread.ManagedThreadId);
            var t = DoWorkAsync();
            Console.WriteLine("Sista raden. tråd " + Thread.CurrentThread.ManagedThreadId);
        }

        private async static Task DoWorkAsync()
        {
            Console.WriteLine("Anropar await {0:HH:mm:ss}. Tråd {1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Efter await {0:HH:mm:ss}. Tråd {1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
        }




    }
}
