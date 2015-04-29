using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Behaviors;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mallardDuck = new MallardDuck();
            var redheadDuck = new RedheadDuck();
            var rubberDuck = new RubberDuck();
            var modelDuck = new ModelDuck();


            mallardDuck.Display();
            mallardDuck.PerformQuack();
            mallardDuck.PerformFly();

            redheadDuck.Display();
            redheadDuck.PerformQuack();
            redheadDuck.PerformFly();

            rubberDuck.Display();
            rubberDuck.PerformQuack();
            rubberDuck.PerformFly();

            modelDuck.Display();
            modelDuck.PerformFly();
            modelDuck.SetFlayBehavior(new FlyRocketPowered());
            modelDuck.PerformFly();

            Console.ReadKey();
        }
    }
}
