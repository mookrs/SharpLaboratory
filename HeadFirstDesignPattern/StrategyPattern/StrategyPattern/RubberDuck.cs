using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class RubberDuck : Duck
    {
        public new void Quack()
        {
            Console.WriteLine("吱吱叫！");
        }

        public override void Display()
        {
            Console.WriteLine("I'm made up of rubber.");
        }

        public new void Fly()
        {
            
        }
    }
}
