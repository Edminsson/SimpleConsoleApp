using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SimpleConsoleApp
{
    public enum Case
    {
        Upper,
        Lower
    }

    public enum Order
    {
        asc,
        desc
    }


    public class ArgsConfig
    {
        [Option('c',"case", HelpText="upper/lower")]
        public Case TargetCase { get; set; }
        [Option('o', "order", HelpText = "asc/desc")]
        public Order Order { get; set; }
    }
}
