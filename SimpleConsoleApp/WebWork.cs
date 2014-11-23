using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleApp
{
    class WebWork : DoWorkTemplate<WebArgsConfig>
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        protected override void PreProcess()
        {
            _stopwatch.Start();
            WebClient client = new WebClient();
            var page = client.DownloadString(Options.Uri);
            Input = new StringReader(page);
        }
        protected override void PostProcess()
        {
            _stopwatch.Stop();
            Output.WriteLine(string.Format("Total time: {0} ms",_stopwatch.ElapsedMilliseconds));
        }
        protected override void ProcessLine(string line)
        {
            if (line.StartsWith("<a"))
                Output.WriteLine(line);
        }
    }
}
