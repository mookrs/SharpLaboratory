using System;

namespace StrategyPattern
{
    // 模型鸭
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new NormalQuack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck.");
        }
    }
}