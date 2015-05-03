using System;

namespace StrategyPattern
{
    // 橡皮鸭
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            QuackBehavior = new Squeak();
            FlyBehavior = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm made up of rubber.");
        }
    }
}