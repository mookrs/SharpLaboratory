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
            PizzaStore nyPizzaStore = new NYPizzaStore();
            nyPizzaStore.OrderPizza("cheese");
            PizzaStore chicagoStore = new ChicagoPizzaStore();
            chicagoStore.OrderPizza("veggie");

            Console.ReadKey();
        }
    }
}
