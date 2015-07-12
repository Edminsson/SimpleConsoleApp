using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Models
{
    public class Player : Member
    {
        public int ShirtNumber { get; set; }
        public Position Position { get; set; }
    }
}
