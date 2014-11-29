using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleApp.WorkTemplate
{
    class WebArgsConfig
    {
        [Option('u', "url", Required = true, HelpText = "Page Url")]
        public string Uri { get; set; }
    }
}
