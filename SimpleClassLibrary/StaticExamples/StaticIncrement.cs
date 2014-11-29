using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary.StaticExamples
{
    public static class StaticIncrement
    {
        public static int Oka = 0;

        public static void IncrementByOne()
        {
            Oka++;
        }

        public static void DecrementByOne()
        {
            Oka--;
        }

    }
}
