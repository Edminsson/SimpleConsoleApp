using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleConsoleApp
{
    public class WaitAndIncrement
    {
        public int oka;
        private Order order;
        private Random random = new Random();

        public WaitAndIncrement(Order order)
        {
            this.order = order;
        }

        public void Start()
        {
            if (this.order == Order.asc)
            {
                var length = 10;
                for (int i = 0; i < length; i++)
                {
                    var vantetid = random.Next(1000, 2000);
                    Thread.Sleep(vantetid);
                    StaticIncrement.IncrementByOne();
                    Console.WriteLine(StaticIncrement.Oka);
                }
            }
            else if (this.order == Order.desc)
            {
                var length = 10;
                StaticIncrement.Oka = 10;
                for (int i = 0; i < length; i++)
                {
                    Thread.Sleep(1000);
                    StaticIncrement.DecrementByOne();
                    Console.WriteLine(StaticIncrement.Oka);
                }
            }
        }
    }
}
