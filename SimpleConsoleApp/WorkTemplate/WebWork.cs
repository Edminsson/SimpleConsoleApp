using SimpleClassLibrary.WorkTemplates;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace SimpleConsoleApp.WorkTemplate
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
