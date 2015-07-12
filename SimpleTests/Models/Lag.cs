using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTests.Models
{
    public class Lag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Member Coach { get; set; }
        public string Town { get; set; }
        public Lag()
        {
        }
    }
}
