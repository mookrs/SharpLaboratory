using System;

namespace StrategyPattern
{
    public class NormalQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("呱呱叫！");
        }
    }
}