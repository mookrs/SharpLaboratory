using System;

namespace StrategyPattern
{
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            QuackBehavior = new NormalQuack();
            FlyBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Redhead duck.");
        }
    }
}