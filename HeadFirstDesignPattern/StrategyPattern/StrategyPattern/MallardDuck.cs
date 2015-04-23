using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class MallardDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("I have red head.");
        }
    }
}
