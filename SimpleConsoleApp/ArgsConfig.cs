using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SimpleConsoleApp
{
    internal enum Case
    {
        Upper,
        Lower
    }


    class ArgsConfig
    {
        [Option('c',"case", Required=true, HelpText="upper/lower")]
        public Case TargetCase { get; set; }
    }
}
