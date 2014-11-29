using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SimpleConsoleApp
{
    public enum Work
    {
        Static,
        Template,
        Event,
        Delegate
    }

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
        [Option('w', "Work", DefaultValue=Work.Template,  HelpText = "Template/Static/Event/Delegate")]
        public Work Work { get; set; }
        [Option('c', "case", HelpText = "upper/lower")]
        public Case TargetCase { get; set; }
        [Option('o', "order", HelpText = "asc/desc")]
        public Order Order { get; set; }
        [Option('u', "url", HelpText = "Page Url")]
        public string Uri { get; set; }
    }
}
