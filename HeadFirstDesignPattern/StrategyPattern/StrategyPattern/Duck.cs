using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public abstract class Duck
    {
        public IQuackBehavior QuackBehavior;
        public IFlyBehavior FlyBehavior;

        public void PerformQuack()
        {
            QuackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("I'm Swimming.");
        }

        public abstract void Display();

        public void PerformFly()
        {
            FlyBehavior.Fly();
        }
    }
}
