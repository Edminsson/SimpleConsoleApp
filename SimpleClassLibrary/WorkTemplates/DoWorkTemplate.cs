using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleClassLibrary.WorkTemplates
{
    public abstract class DoWorkTemplate<TOptions> where TOptions: new()
    {
        protected TextWriter Error;
        protected TextReader Input;
        protected TextWriter Output;
        protected TOptions Options;

        public void Work(string[] args, TextWriter error, TextReader input, TextWriter output)
        {
            Error = error;
            Input = input;
            Output = output;

            ParseOptions(args);
            var isValidArguments = ValidateArguments();
            if (isValidArguments)
            {
                PreProcess();
                ProcessLines();
                PostProcess();
            }
 
        }

        private void ParseOptions(string[] args)
        {
            Options = new TOptions();
            Parser.Default.ParseArgumentsStrict(args, Options);
        }

        protected virtual bool ValidateArguments()
        {
            return true;
        }
        protected virtual void PreProcess()
        {
        }
        protected void ProcessLines()
        {
            var currentLine = Input.ReadLine();
            while (currentLine != null)
            {
                ProcessLine(currentLine);
                currentLine = Input.ReadLine();
            }
        }
        protected virtual void ProcessLine(string line)
        {
        }
        protected virtual void PostProcess()
        {
        }

    }
}
