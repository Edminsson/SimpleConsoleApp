﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
        public Lag Lag { get; set; }
    }
}
