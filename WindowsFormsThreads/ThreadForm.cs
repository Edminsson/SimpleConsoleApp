using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkerLibrary;

namespace WindowsFormsThreads
{
    public partial class ThreadForm : Form
    {

        public ThreadForm()
        {
            InitializeComponent();
            lblInfo.Text = "";
        }

        private void btnStarta_Click(object sender, EventArgs e)
        {
            //start thread
            var WorkerThread = new Thread(new ThreadStart(StartSlowWorker));
            WorkerThread.Start();
        }

        private void StartSlowWorker()
        {
            WorkProgressDelegate progress = new WorkProgressDelegate(ShowProgress);
            WorkCompletedDelegate completed = new WorkCompletedDelegate(ShowCompletedMessage);
            SlowWorker slowWorker = new SlowWorker();
            slowWorker.WorkerUsingDelegates(10, progress, completed);
        }

        private void ShowProgress(int progress)
        {
            //if (lblInfo.InvokeRequired)
            //    this.Invoke();
            //lblInfo.Text = progress.ToString();
        }

        private void ShowCompletedMessage(int count)
        {
            lblInfo.Text = string.Format("Klart! Antal: {0}", count.ToString());
        }
    }
}
