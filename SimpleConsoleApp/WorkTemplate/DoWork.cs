using SimpleClassLibrary.WorkTemplates;
using System;

namespace SimpleConsoleApp.WorkTemplate
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
