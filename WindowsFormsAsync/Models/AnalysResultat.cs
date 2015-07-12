using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAsync.Models
{
    public class AnalysResultat
    {
        public Dictionary<int, int> ProcessFrekvens { get; set; }
        public Dictionary<string, int> Slumpfrekvens { get; set; }
    }
}
