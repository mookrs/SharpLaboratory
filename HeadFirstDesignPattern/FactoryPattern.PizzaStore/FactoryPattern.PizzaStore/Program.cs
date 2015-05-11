using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.PizzaStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            SimplePizzaFactory factory = new SimplePizzaFactory();
            PizzaStore nyStore = new PizzaStore(factory);
            nyStore.OrderPizza("veggie");

            Console.ReadKey();
        }
    }
}
