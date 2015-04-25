using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mallardDuck = new MallardDuck();
            var redheadDuck = new RedheadDuck();
            var rubberDuck = new RubberDuck();

            mallardDuck.Display();
            redheadDuck.Display();
            rubberDuck.Display();

            mallardDuck.PerformQuack();
            //redheadDuck.PerformQuack();
            //rubberDuck.PerformQuack();

            Console.ReadKey();
        }
    }
}
