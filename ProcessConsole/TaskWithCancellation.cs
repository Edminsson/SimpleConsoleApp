using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessConsole
{
    public class TaskWithCancellation
    {
        public int DoWork(CancellationToken ct)
        {
            Thread.Sleep(1000);
            ct.ThrowIfCancellationRequested();
            return 10;
        }
    }
}
