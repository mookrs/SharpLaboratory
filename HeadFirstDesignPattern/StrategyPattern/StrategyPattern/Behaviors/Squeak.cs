using System;

namespace StrategyPattern
{
    public class Squeak : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("吱吱叫！");
        }
    }
}