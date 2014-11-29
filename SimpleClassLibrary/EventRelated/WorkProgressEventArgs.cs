using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary.EventRelated
{
    public class WorkProgressEventArgs : System.EventArgs
    {
        public int CurrentItem { get; set; }
    }
}
