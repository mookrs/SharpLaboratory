using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public abstract class Duck
    {
        public void Quack()
        {
            Console.WriteLine("呱呱叫！");
        }

        public void Swim()
        {
            Console.WriteLine("I'm Swimming.");
        }

        public abstract void Display();

        public void Fly()
        {
            Console.WriteLine("I'm flying.");
        }
    }
}
