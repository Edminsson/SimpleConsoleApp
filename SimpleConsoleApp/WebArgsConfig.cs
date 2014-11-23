using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SimpleConsoleApp
{

    class WebArgsConfig
    {
        [Option('u',"url", Required=true, HelpText="Page Url")]
        public string Uri { get; set; }
    }
}
