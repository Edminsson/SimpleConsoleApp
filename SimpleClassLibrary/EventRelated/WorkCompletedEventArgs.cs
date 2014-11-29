using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary.EventRelated
{
    public class WorkCompletedEventArgs : System.EventArgs
    {
        public int Antal { get; set; }
        public TimeSpan Arbetstid { get; set; }
    }
}
