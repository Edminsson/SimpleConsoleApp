using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleApp
{
    class DoWork : DoWorkTemplate<ArgsConfig>
    {
        private int _linesProcessed = 0;

        protected override void PreProcess()
        {
            Console.WriteLine("Converting to " + Options.TargetCase);
        }
        protected override void PostProcess()
        {
            base.PostProcess();
        }
        protected override void ProcessLine(string line)
        {
            _linesProcessed++;
            switch(Options.TargetCase)
            {
                case Case.Upper:
                    Output.WriteLine(line.ToUpper());
                    break;
                case Case.Lower:
                    Output.WriteLine(line.ToLower());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
